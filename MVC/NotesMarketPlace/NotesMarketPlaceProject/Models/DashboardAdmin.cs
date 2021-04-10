using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotesMarketPlaceProject.Context;

namespace NotesMarketPlaceProject.Models
{
    public class DashboardAdmin
    {
        public SellerNote sellernotetbl { get; set; }
        public NoteCategory notecattbl { get; set; }
        public User usertbl { get; set; }
    }
}