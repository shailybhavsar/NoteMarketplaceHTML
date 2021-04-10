using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotesMarketPlaceProject.Context;

namespace NotesMarketPlaceProject.Models
{
    public class PublishedNotesByAdmin
    {
        public SellerNote sellernotetbl { get; set; }
        public NoteCategory notecattbl { get; set; }
        public User usertbl { get; set; }

        //for seller dropdown
        public SellerNote sellerdropdown { get; set; }
        public Download downloadtbl { get; set; }

        //for getting name of the admin
        public User useradmin { get; set; }

    }
}