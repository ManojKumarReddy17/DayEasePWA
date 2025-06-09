using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestModels
{
    public class RegistrationState
    {
        public string PhoneNumber { get; set; }
        public int? Otp { get; set; }
        public UserModel UserDetails { get; set; } = new UserModel();
    }
}
