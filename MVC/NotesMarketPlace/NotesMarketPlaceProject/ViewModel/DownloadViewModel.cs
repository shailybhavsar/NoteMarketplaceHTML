using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NotesMarketPlaceProject.Models;

namespace NotesMarketPlaceProject.ViewModel
{
    public class DownloadViewModel
    {
        public IEnumerable<DownloadnNotesModel> downloadnNotes { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Remarks")]
        public string Remarks { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Comments")]
        public string Comments { get; set; }
        public decimal Ratings { get; set; }
    }
}