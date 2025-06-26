using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainModels
{
    public class UserOtpResponseModel
    {
        public bool Success { get; set; }           // Indicates success or failure
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
        public int otp { get; set; }
        public string RegistrationStatus { get; set; }
        public string Message { get; set; }
        public bool IsOtpValid { get; set; }
        public int? OtpAttempts { get; set; }  // Number of OTP attempts remaining
        public int StatusCode { get; set; }
    }
}
