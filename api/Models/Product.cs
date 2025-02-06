using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public int StockQuantity { get; set; }
        public bool IsAvailableInStock { get; set; } = false;
    }
}