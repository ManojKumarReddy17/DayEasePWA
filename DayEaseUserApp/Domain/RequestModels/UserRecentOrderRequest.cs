using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestModels
{
    public class UserRecentOrderRequest
    {
        public string userId { get; set; }
        public string userLatitude { get; set; }

        public string userLongitude { get; set; }
    }
}
