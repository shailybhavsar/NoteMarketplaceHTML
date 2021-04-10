using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotesMarketPlaceProject.Context;
using NotesMarketPlaceProject.Models;

namespace NotesMarketPlaceProject.ViewModel
{
    public class SearchNotesnewViewModel
    {
        public IEnumerable<NoteType> types1 { get; set; }
        public IEnumerable<NoteCategory> categories1 { get; set; }
        public IEnumerable<SearchNoteViewmodel> univercities1 { get; set; }
        public IEnumerable<SearchNoteViewmodel> courses1 { get; set; }
        public IEnumerable<Country> countries1 { get; set; }
        public IEnumerable<SellerNote> sellernotedata { get; set; }
        public int TypeID1 { get; set; }
        public int CategoryID1 { get; set; }
        public int CountryID1 { get; set; }
        public int UniversityID1 { get; set; }
        public int CourseID1 { get; set; }
        public int RatingID1 { get; set; }


        //Pagination
        public int TotalRecords { get; set; }
        public string PageNumber { get; set; }
        public string PageSize { get; set; }

        public IEnumerable<NewGetSellerNotesDetails_Result> newGetSellerNotesDetails_Results { get; set; }

    }
}