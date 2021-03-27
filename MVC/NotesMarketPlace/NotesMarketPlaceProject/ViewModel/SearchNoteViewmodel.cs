using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotesMarketPlaceProject.Models;
using NotesMarketPlaceProject.Context;

namespace NotesMarketPlaceProject.ViewModel
{
    public class SearchNoteViewmodel
    {
        public int ID { get; set; }
        public string DisplayPicture { get; set; }
        public string Title { get; set; }
        public string UniversityName { get; set; }
        public int? NumberOfPages { get; set; }
        public DateTime? CreatedDate { get; set; }
        public decimal avg { get; set; }
        public int RateCount { get; set; }
        public int ReportCount { get; set; }
        public string Course { get; set; }
        // public SellerNotesReview reviewdata { get; set; }
    }
}