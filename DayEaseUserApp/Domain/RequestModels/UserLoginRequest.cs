using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestModels
{
    public class UserLoginRequest
    {

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Username must be exactly 10 characters.")]
        public string phonenumber { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        public string password { get; set; }


    }
}
