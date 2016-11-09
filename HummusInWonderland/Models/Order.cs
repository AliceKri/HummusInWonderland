using System;
using System.ComponentModel.DataAnnotations;

namespace HummusInWonderland.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = "שדה חובה")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "שדה חובה")]
        public int ProductID { get; set; }

        [Display(Name = "תאריך הזמנה")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "מחיר כולל")]
        public int TotalPrice { get; set; }

        public virtual Menu menu { get; set; }
        public virtual Customer Customer { get; set; }
    }
}