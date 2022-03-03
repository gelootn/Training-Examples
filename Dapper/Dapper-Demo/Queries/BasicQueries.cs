using System.Data.SqlClient;
using Dapper;
using Dapper_Demo.Models;

namespace Dapper_Demo.Queries
{
    internal class BasicQueries
    {
        private readonly string _connectionString;

        public BasicQueries(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            await using var db = new SqlConnection(_connectionString);
            var customers = await db.QueryAsync<Customer>("select * from customers");
            return customers;
        }

        public async Task<IEnumerable<Invoice>> GetInvoices()
        {
            var sql =
                "select i.*, il.InvoiceLineId, il.Amount, il.Quantity, p.ProdId, p.Description, p.Price from Invoices i " +
                "join InvoiceLines il on i.InvoiceNumber = il.InvoiceNumber " +
                "join Products p on il.ProductProdId = p.ProdId";
            using var db = new SqlConnection(_connectionString);
            var invoices = await db.QueryAsync<Invoice, InvoiceLine, Product, Invoice>(
                sql,
                (invoice, invoiceLine, product) =>
                {
                    invoiceLine.Product = product;
                    invoice.InvoiceLines.Add(invoiceLine);
                    return invoice;
                }, splitOn: "InvoiceLineId, prodId");
            return invoices;
        }
    }
}
