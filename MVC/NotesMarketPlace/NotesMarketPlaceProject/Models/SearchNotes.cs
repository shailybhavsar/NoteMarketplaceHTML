using NotesMarketPlaceProject.Context;
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
        public SellerNote Singlenote { get; set; }
        public IEnumerable<NoteType> types { get; set; }
        public IEnumerable<NoteCategory> categories { get; set; }
        public IEnumerable<SellerNote> univercities { get; set; }
        public IEnumerable<SellerNote> courses { get; set; }
        public IEnumerable<Country> countries { get; set; }
    }
}