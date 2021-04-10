using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotesMarketPlaceProject.Context;

namespace NotesMarketPlaceProject.Models
{
    public class Members
    {
        public User usertbl { get; set; }
        public SearchNotes sellertbl { get; set; }
    }
}