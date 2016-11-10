using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HummusInWonderland.Models
{
    public class Branch
    {
        public int BranchId { get; set; }

        [Display(Name = "שם החנות")]
        [Required(ErrorMessage = "שדה חובה")]
        public string BranchName { get; set; }

        [Display(Name = "עיר")]
        [Required(ErrorMessage = "שדה חובה")]
        public string BranchCity { get; set; }

        [Display(Name = "רחוב")]
        [Required(ErrorMessage = "שדה חובה")]
        public string BranchStreet { get; set; }

        [Display(Name = "מספר בית")]
        [Required(ErrorMessage = "שדה חובה")]
        public int BranchsHouseNumber { get; set; }

        [Display(Name = "מספר טלפון")]
        public string BranchsPhoneNumber { get; set; }
    }
}