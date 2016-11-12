﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HummusInWonderland.Models
{
    public class Menu
    {
        [Key]
        public int MenuID { get; set; }

        [Display(Name = "שם המנה")]
        [Required(ErrorMessage = "שדה חובה")]
        public string ProductName { get; set; }

        [Display(Name = "תיאור המנה")]
        [Required(ErrorMessage = "שדה חובה")]
        public string ProductDescription { get; set; }

        [Display(Name = "מחיר המנה")]
        [Required(ErrorMessage = "שדה חובה")]
        public int Price { get; set; }

        [Display(Name = "תמונת המנה")]
        public string ProductImage { get; set; }
    }
}
