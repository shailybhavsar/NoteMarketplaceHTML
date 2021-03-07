using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NotesMarketPlaceProject.Models
{
    public class UserAddNotes
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Title")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select Category")]
        public IEnumerable<int> Category { get; set; }
        public byte[] DisplayPicture { get; set; }
        public IEnumerable<int> NoteType { get; set; }
        public int NumberOfPages { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Description")]
        public string Description { get; set; }
        public string UniversityName { get; set; }
        public IEnumerable<int> Country { get; set; }
        public string Course { get; set; }
        public string CourseCode { get; set; }
        public string Professor { get; set; }
        public bool IsPaid { get; set; }
        public decimal SellingPrice { get; set; }
        public string NotesPreview { get; set; }

        public string FileName { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Please Upload Your Notes")]
        public string FilePath { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select Category")]
        public int NoteCategoryID { get; set; }

        //NoteTypes
        public int NoteTypeID { get; set; }

        //Country
        public int CountryID { get; set; }
    }
}