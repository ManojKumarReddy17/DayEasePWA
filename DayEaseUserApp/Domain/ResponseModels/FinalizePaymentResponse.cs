using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ResponseModels
{
    public class FinalizePaymentResponse
    {
        public bool Success { get; set; }
        public string Status { get; set; }
        public string TransactionReference { get; set; }
        public string Message { get; set; }
    }
}
