using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportShop.Models.DbModels
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Description { get; set; }
        public decimal Price { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int AvailableQuantity { get; set; }
    }
}