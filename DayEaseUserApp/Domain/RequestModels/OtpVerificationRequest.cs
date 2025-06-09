using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Domain.RequestModels
{
    public class OtpVerificationRequest
    {
       
        public string PhoneNumber { get; set; }
        public int Otp { get; set; }
    }
    public class OtpResponse
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
