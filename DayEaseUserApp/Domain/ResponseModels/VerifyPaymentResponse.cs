using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ResponseModels
{
    public class VerifyPaymentResponse
    {
        public bool IsSuccess { get; set; }
        public string OrderId { get; set; } = string.Empty;
        public string PaymentId { get; set; }
        public string Message { get; set; }
    }

}
