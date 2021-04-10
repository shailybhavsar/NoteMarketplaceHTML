using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NotesMarketPlaceProject.Context;


namespace NotesMarketPlaceProject.Models
{
    public class AddCategory
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Category Name")]
        public string CategoryName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Description of category")]
        public string Description { get; set; }
        public NoteCategory notecategorytbl { get; set; }
        public User usertbl { get; set; }
    }
}