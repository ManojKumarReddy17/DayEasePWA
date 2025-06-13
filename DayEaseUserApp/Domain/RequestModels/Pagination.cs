using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestModels
{
   public class Pagination<T>
    {
      
            public int? pageNumber { get; set; }
            public int? pageSize { get; set; }
            public int TotalItems { set; get; }
            public int TotalPageCount { set; get; }
            public List<T> Items { get; set; }
        }
        public class PaginationInput
        {
            public string StoreId { get; set; }
            public int? PageNumber { get; set; }
            public int? PageSize { get; set; }

        }
    public class PaginationQueryInput
    {
        public ProductRequestModel Product { get; set; }
        public PaginationInput PaginationInput { get; set; } = new PaginationInput();
    }



}
