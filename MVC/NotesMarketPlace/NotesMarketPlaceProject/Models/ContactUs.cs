using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NotesMarketPlaceProject.Models
{
    public class ContactUs
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Your Full Name")]
        public string FullName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Your EMialID")]
        [EmailAddress]
        public string  EMailid { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Your Subject")]
        public string Subject  { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Your Questions/Comments")]
        public string  Questions { get; set; }
    }
}