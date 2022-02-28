using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dapper_Demo.Models
{
    public class Invoice
    {
        public Invoice()
        {
            InvoiceLines = new List<InvoiceLine>();
        }

        public int InvoiceNumber { get; set; }
        public Customer Customer { get; set; }
        public DateTime Date { get; set; }
        public List<InvoiceLine> InvoiceLines { get; set; }

        public int InvoiceTotal => SumInvoiceTotal();

        public int SumInvoiceTotal()
        {
            return InvoiceLines.Sum(x => x.Total);
        }
    }
}
