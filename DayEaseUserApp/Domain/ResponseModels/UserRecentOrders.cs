using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ResponseModels
{
    public class UserRecentOrders
    {
        public bool status { get; set; }
        public string message { get; set; }
        public string storeId { get; set; }
        public string storeName { get; set; }
        public double distance { get; set; }
        public string orderId { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
