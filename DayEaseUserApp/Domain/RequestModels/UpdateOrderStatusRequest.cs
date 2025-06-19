using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestModels
{
    public class UpdateOrderStatusRequest
    {
        public string OrderId { get; set; }
        public string OrderStatus { get; set; }
    }
}
