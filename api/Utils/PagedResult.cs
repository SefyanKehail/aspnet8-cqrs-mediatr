using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Utils
{
    public class PagedResult<T>
    {

        public List<T> Items { get; set; }
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public PagedResult(List<T> items, int totalItems, int pageSize, int pageNumber)
        {
            Items = items;
            TotalItems = totalItems;
            PageSize = pageSize;
            PageNumber = pageNumber;
        }
    }
}