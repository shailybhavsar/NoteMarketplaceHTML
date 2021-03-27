using System;
using NotesMarketPlaceProject.Context;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NotesMarketPlaceProject.Models
{
    public class UserProfileModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter First Name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Last Name")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Last Name")]

        public int Gender { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Last Name")]
        [EmailAddress(ErrorMessage ="Please Enter Valid Email Address")]
        public string EmailID { get; set; }
        public DateTime DOB { get; set; }
        public string ProfilePicture { get; set; }
        public string  PhoneNumberCountryCOde { get; set; }
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Fill The Field")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter City Name")]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter State Name")]
        public string State { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Zip Code")]
        public string ZipCode { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Please Select Country Name")]
        public string  Country { get; set; }
        public string University { get; set; }

        public string College { get; set; } 

        public IEnumerable<Country> countries { get; set; }
        public IEnumerable<ReferenceData> referenceDatas { get; set; }
    }
}