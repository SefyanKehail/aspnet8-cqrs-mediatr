using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Features._Product.DTOs
{
    public class ProductQueryParamsDTO
    {
        public string? Search { get; set; }
        public string? SortBy { get; set; } = "Amount";
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
        public bool IsDescening { get; set; } = false;
    }
}