using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainModels
{
    public class UserLoginResponse
    {
        public string PhoneNumber { get; set; }
        public string UserId { get; set; }
        public int Active { get; set; }
        /// <summary>
        public string Status { get; set; }
        /// </summary>
        public string FName { get; set; }
        public string LName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string RefreshTokenExpiry { get; set; }
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
        public string Message { get; set; }
        public int Success { get; set; }


    }
}
