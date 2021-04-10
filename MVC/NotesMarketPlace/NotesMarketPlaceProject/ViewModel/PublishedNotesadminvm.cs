using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotesMarketPlaceProject.Context;
using NotesMarketPlaceProject.Models;

namespace NotesMarketPlaceProject.ViewModel
{
    public class PublishedNotesadminvm
    {
        public IEnumerable<PublishedNotesByAdmin> singlerowdata { get; set; }
        //public int count_no_of_downloads { get; set; }
        public IEnumerable<SearchNotes> sellerdatacount { get; set; }
    }
}