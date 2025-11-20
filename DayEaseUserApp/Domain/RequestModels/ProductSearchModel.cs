using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestModels
{
    public  class ProductSearchModel
    {
        public string StoreId { get; set; }
        public string? CategoryId { get; set; }
        public string? ProductName { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
