using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestModels
{
    public class NearbyStoresRequest
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int pageNumber { set; get; }
        public int pageSize { set; get; }
    }
}
