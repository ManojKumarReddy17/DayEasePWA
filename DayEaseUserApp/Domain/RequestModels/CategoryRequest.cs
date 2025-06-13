using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestModels
{
    public class CategoryRequest
    {   
        public string StoreId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
