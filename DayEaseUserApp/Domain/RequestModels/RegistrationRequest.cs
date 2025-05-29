using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.RequestModels
{
    public class RegistrationRequest
    {
    
        public string PhoneNumber { get; set; }

        public string CountryCode { get; set; }
    }

    public class RegistrationResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }

}
