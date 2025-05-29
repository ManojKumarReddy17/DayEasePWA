using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestModels
{
    public  class SubAreaModel
    {
        public string SubAreaId { get; set; }
        public string SubAreaName { get; set; }
        public string AreaId { get; set; }
        public bool IsActive { get; set; }
    }
}
