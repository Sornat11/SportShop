using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportShop.Models.DbModels
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [ForeignKey("Product")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string OrderStatus { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public int Quantity { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}