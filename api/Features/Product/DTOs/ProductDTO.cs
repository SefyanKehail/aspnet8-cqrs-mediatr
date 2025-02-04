using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Features.Product.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public decimal Amount { get; set; }
    }
}