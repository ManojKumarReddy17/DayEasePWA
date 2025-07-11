using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainModels
{
    public class UserResponseModel
    {
        public bool Success { get; set; }           // Indicates success or failure
        public string Message { get; set; }

        public string RegistrationStatus { get; set; } // Message for success or error
        public int StatusCode { get; internal set; }
    }
}
