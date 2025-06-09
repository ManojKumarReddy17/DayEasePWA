using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestModels
{
    public class AreaModel
    {
        public string AreaId { get; set; }
        public string AreaName { get; set; }
        public string CityId { get; set; }
        public bool IsActive { get; set; }

    }
}
