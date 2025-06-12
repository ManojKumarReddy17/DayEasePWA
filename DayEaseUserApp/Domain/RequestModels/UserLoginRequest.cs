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
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Please enter a valid 10-digit mobile number.")]
        public string phonenumber { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{7,15}$",
           ErrorMessage = "Password must be 7–15 characters and include uppercase, lowercase, number, and special character.")]
        public string password { get; set; }


    }
}
