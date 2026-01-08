using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestModels
{
    public class ZohoPaymentRequest
    {
       
            public decimal Amount { get; set; }

            public string UserId { get; set; }
         
            //public string CustomerPhone { get; set; }
            public string OrderId { get; set; }
            public string Description { get; set; }

            public string RedirectUrl { get; set; }
    }
}
