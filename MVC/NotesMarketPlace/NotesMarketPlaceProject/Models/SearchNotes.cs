using NotesMarketPlaceProject.Context;
using NotesMarketPlaceProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotesMarketPlaceProject.Models
{
    public class SearchNotes
    {
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public int NumberOfPages { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryID { get; set; }
        public string UniversityName { get; set; }
        public string Course { get; set; }
        public int CountryID { get; set; }
        public string DisplayPicture { get; set; }
        public string Title { get; set; }
        public string CountryName { get; set; }
        public string CourseCode { get; set; }
        public string Professor { get; set; }
        public decimal ratings { get; set; }
        public SellerNote Singlenote { get; set; }
        public IEnumerable<NoteType> types { get; set; }
        public IEnumerable<NoteCategory> categories { get; set; }
        public IEnumerable<SearchNoteViewmodel> univercities { get; set; }
        public IEnumerable<SearchNoteViewmodel> courses { get; set; }
        //public IEnumerable<SellerNote> sellerNotes { get; set; }
        public IEnumerable<SearchNoteViewmodel> sellerNotes { get; set; }
        public IEnumerable<SellerNote> courselist { get; set; }

        public IEnumerable<SearchNoteViewmodel> countbooks { get; set; }
        public IEnumerable<Country> countries { get; set; }
        public IEnumerable<SellerNote> filterdata { get; set; }
        public IEnumerable<SellerNotesReview> reviews { get; set; }

        //For SellerNotes Attachments
        public SellerNotesAttachment Singlenotepdf { get; set; }
        public string pdffilename { get; set; }

        //For SellerReview Table
        public User userdata { get; set; }
        public UserProfile userprofiledata { get; set; }
        public SellerNotesReview reviewdata { get; set; }
    }
}