using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NotesMarketPlaceProject.Models
{
    public class UserLogin
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter EmailID")]
        [EmailAddress(ErrorMessage = "InValid Email Address")]
        public string EmailID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Password")]
        public string  Password { get; set; }
    }
}