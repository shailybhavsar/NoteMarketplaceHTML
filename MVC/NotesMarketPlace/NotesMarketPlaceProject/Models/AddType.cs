using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NotesMarketPlaceProject.Context;

namespace NotesMarketPlaceProject.Models
{
    public class AddType
    {
        [Required(AllowEmptyStrings =false,ErrorMessage ="Please Enter Type Name")]
        public string TypeName { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Please Enter Description of type")]
        public string Description { get; set; }

        public NoteType notetypetbl { get; set; }
        public User usertbl { get; set; }
    }
}