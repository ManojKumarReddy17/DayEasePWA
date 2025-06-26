using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestModels
{
    public class ForgotPasswordModel
    {
       
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{7,15}$",
         ErrorMessage = "Password must be 7–15 characters and include uppercase, lowercase, number, and special character.")]
        public string NewPassword { get; set; }

    }
}
