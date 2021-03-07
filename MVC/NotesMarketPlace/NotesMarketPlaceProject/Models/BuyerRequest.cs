using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotesMarketPlaceProject.Context;

namespace NotesMarketPlaceProject.Models
{
    public class BuyerRequest
    {
        public SellerNote sellertbl { get; set; }
        public NoteCategory categorytbl { get; set; }
        public User usertbl { get; set; }
        public ReferenceData reftbl { get; set; }
    }
}