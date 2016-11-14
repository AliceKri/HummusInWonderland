using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HummusInWonderland.Models
{
    public class Order
    {
        public Order()
        {
            this.Products = new List<Product>();
        }
        public int OrderID { get; set; }

        [Required(ErrorMessage = "שדה חובה")]
        public int CustomerId { get; set; }

        [Display(Name = "תאריך הזמנה")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "מחיר כולל")]
        public int TotalPrice { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual Customer Customer { get; set; }
    }
}