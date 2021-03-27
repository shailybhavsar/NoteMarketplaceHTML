using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NotesMarketPlaceProject.Context;

namespace NotesMarketPlaceProject.Models
{
    public class DownloadnNotesModel
    {
        public User usertbl { get; set; }
        public Download downloadtbl { get; set; }
        public decimal Ratings { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Remarks")]
        //public string Remarks { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Comments")]
        //public string Comments { get; set; }
    }
}