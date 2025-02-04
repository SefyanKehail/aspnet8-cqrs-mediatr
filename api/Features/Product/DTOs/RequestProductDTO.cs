using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Features.Product.DTOs
{
    public class RequestProductDTO
    {
        // made this null so I can only update certain fields 
        public string? Name { get; set; } = null;
        public decimal? Amount { get; set; } = null;
    }
}