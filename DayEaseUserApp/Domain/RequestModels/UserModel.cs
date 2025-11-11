using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.RequestModels
{
    public class UserModel
    {
        public string PhoneNumber { get; set; }

        //[Required(ErrorMessage = "First name is required")]
        //[RegularExpression(@"^[A-Za-z\s]{1,20}$", ErrorMessage = "First name must be letters and spaces only")]

        public string FName { get; set; }

        //[Required(ErrorMessage = "Last name is required")]
        //[RegularExpression(@"^[A-Za-z\s]{1,20}$", ErrorMessage = "Last name can contain only letters and spaces")]

        public string LName { get; set; }

        public string Country { get; set; } = "India";

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Area (Sublocation) is required")]
        public string Sublocation { get; set; }

        [Required(ErrorMessage = "Latitude is required")]
        public string Latitude { get; set; }

        [Required(ErrorMessage = "Longitude is required")]
        public string Longitude { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Address is required")]
    
        public string Address { get; set; }

        //[Required(ErrorMessage = "Password is required")]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,15}$",
        // ErrorMessage = "Password must be 7–15 characters and include uppercase, lowercase, number, and special character.")]
        public string Password { get; set; }
    }

}
