using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestModels
{
    public class CityModel
    {
       
            public string CityId { get; set; }
            public string CityName { get; set; }
            public string StateId { get; set; }
            public bool IsDelete { get; set; }
    }
}
