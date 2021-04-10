using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NotesMarketPlaceProject.Models
{
    public class RegisterUser
    {
        public int RoleID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter First Name")]
        public string FirstName { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Last Name")]
        public string LastName { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter EmailID")]
        [EmailAddress(ErrorMessage = "InValid Email Address")]
        public string EmailID { get; set; }

        public bool IsActive { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Password")]
        [RegularExpression(@"^(?=.{6,24})(?=.*[a-z])(?=.*[0-9])(?=.*[@#$%^&+=]).*$" , ErrorMessage ="Atleast 1 lowercase,1 special char,1 digit(char between 6-24)")]
        public string Password { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Confirm Password")]
        [Compare("Password", ErrorMessage ="Password does not match")]
        public string ConfirmPassword { get; set; }

        public string CreatedDate { get; set; }
        public bool IsEmailVerified { get; set; }
    }
}