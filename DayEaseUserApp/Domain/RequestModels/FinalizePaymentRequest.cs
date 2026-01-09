using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestModels
{
    public class FinalizePaymentRequest
    {
        public string PaymentId { get; set; }
        public string UserId { get; set; }
        public string StoreId { get; set; }

        public decimal Amount { get; set; }
        public decimal RainCharges { get; set; }
        public decimal DeliveryCharges { get; set; }

        public List<OrderItemModel> Items { get; set; }
    }
}
