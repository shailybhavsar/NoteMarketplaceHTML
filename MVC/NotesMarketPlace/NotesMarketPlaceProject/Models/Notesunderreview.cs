using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotesMarketPlaceProject.Context;

namespace NotesMarketPlaceProject.Models
{
    public class Notesunderreview
    {
        public User usertbl { get; set; }
        public SellerNote sellernotetbl { get; set; }
        public NoteCategory notecategorytbl { get; set; }

        public User usertblfordropdown { get; set; }
        public SellerNote sellertbldropdown { get; set; }
        public string firstname { get; set; }
    }
}