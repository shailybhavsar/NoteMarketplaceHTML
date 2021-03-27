using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotesMarketPlaceProject.Context;

namespace NotesMarketPlaceProject.Models
{
    public class BuyerRequest
    { 
        public User usertbl { get; set; }
        public Download downloadtbl { get; set; }
        public UserProfile userprofiletbl { get; set; }
    }
}