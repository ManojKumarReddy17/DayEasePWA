using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainModels
{
    public class OrderStatusResponse
    {
        public string OrderId { get; set; }
        public string OrderStatus { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
