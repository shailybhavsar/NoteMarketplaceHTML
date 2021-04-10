using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NotesMarketPlaceProject.Context;


namespace NotesMarketPlaceProject.Models
{
    public class AddCountry
    {
        [Required(AllowEmptyStrings =false,ErrorMessage ="Please Enter CountryName")]
        public string CountryName { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Please Enter CountryCode")]
        public string CountryCode { get; set; }

        public Country countrytbl { get; set; }
        public User usertbl { get; set; }
    }
}