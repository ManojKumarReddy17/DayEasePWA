﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestModels
{
    public class NearbyStoresRequest
    {
        public string AreaId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
