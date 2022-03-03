using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dapper_Demo.Models
{
    public class InvoiceLine
    {
        public int InvoiceLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }

        public int Total => SumTotal();

        public int SumTotal()
        {
            return Amount * Quantity;
        }
    }
}