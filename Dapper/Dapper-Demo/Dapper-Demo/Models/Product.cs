using System.ComponentModel.DataAnnotations;

namespace Dapper_Demo.Models
{
    public class Product
    {
        public int ProdId { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
    }
}