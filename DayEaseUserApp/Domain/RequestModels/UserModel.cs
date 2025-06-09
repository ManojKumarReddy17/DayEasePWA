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
        // PhoneNumber is optional
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(7, MinimumLength = 1, ErrorMessage = "First Name must be between 1 and 7 characters")]
        public string FName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(7, MinimumLength = 1, ErrorMessage = "Last Name must be between 1 and 7 characters")]
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
        [StringLength(50, ErrorMessage = "Address cannot exceed 50 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(15, MinimumLength = 7, ErrorMessage = "Password must be between 7 and 15 characters")]
        public string Password { get; set; }
    }

}
