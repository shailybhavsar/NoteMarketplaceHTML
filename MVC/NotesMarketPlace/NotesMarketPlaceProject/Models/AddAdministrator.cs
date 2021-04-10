using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NotesMarketPlaceProject.Context;

namespace NotesMarketPlaceProject.Models
{
    public class AddAdministrator
    {
        [Required(AllowEmptyStrings =false,ErrorMessage ="Please Enter FirstName")]
        public string  FirstName { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Please Enter LastName")]
        public string  LastName { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Please Enter EmailId")]
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumberCountryCOde { get; set; }
        public string phonenumber { get; set; }

        public User usertbl { get; set; }
        public UserProfile userprofiletbl { get; set; }
    }
}