using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NotesMarketPlaceProject.Models
{
    public class ChangepasswordModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Old Password")]
        public string OldPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter New Password")]
        [RegularExpression(@"^(?=.{6,24})(?=.*[a-z])(?=.*[0-9])(?=.*[@#$%^&+=]).*$", ErrorMessage = "Atleast 1 lowercase,1 special char,1 digit(char between 6-24)")]
        public string NewPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "Password does not match")]
        public string ConfirmPassword { get; set; }


    }
}