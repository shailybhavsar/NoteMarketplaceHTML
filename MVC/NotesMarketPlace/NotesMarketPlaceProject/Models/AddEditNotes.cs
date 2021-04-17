using NotesMarketPlaceProject.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NotesMarketPlaceProject.Helper_Code;

namespace NotesMarketPlaceProject.Models
{
    public class AddEditNotes
    {
        public int ID { get; set; }
        public int SellerID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Title")]
        public string Title { get; set; }
        public string CategoryName { get; set; }


        //Added
        //[AllowExtensionsAttribute(ErrorMessage = "Please select only Supported Files .png | .jpg | .jpeg",Extensions ="jpg,png,jpeg")]
        public string DisplayPicture { get; set; }
        //public HttpPostedFileBase DisplayPicture { get; set; }

        //public IEnumerable<int> TypeName { get; set; }
        public IEnumerable<string> TypeName { get; set; }
        public int NumberOfPages { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Description")]
        public string Description { get; set; }
        public string UniversityName { get; set; }
        public IEnumerable<int> CountryName { get; set; }
        public string Course { get; set; }
        public string CourseCode { get; set; }
        public string Professor { get; set; }
        public bool IsPaid { get; set; }
        public string sellfor { get; set; }
        public decimal SellingPrice { get; set; }
        public string NotesPreview { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Preview { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select Category")]
        public int CategoryID { get; set; }
        //[Required]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Upload Notes")]
        //[ValidateFile(ErrorMessage = "Please ensure a file is selected.")]
        public HttpPostedFileBase upload_notes { get; set; }
            
        //NoteTypes
        public int TypeID { get; set; }

        //Country
        public int CountryID { get; set; }

        public IEnumerable<NoteType> types { get; set; }
        public IEnumerable<NoteCategory> categories { get; set;} 
        public IEnumerable<Country> countries { get; set; }

        
        //Dashboard edit view 
        public SellerNote sellernoteobj { get; set; }
        public SellerNotesAttachment selllernoteattachobj { get; set; }
    }
}