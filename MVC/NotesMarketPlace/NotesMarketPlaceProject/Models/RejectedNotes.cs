using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotesMarketPlaceProject.Context;

namespace NotesMarketPlaceProject.Models
{
    public class RejectedNotes
    {
        public SellerNote sellernote { get; set; }
        public NoteCategory notecattbl { get; set; }
    }
}