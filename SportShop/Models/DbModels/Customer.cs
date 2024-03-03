using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportShop.Models.DbModels
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Email { get; set; }

        [RegularExpression(@"^\d{9}$", ErrorMessage = "Phone number must consist of 9 digits.")]
        public string PhoneNumber { get; set; }
       
        public string Adress { get; set; }
    }
}