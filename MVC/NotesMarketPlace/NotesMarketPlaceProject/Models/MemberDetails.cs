using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotesMarketPlaceProject.Context;

namespace NotesMarketPlaceProject.Models
{
    public class MemberDetails
    {
        public User usertbl { get; set; }
        public UserProfile userprofiletbl { get; set; }
        public SellerNote sellernotetbl { get; set; }
        public NoteCategory categorytbl { get; set; }
        public User singleuser { get; set; }
        public UserProfile singleuserprofile { get; set; }
        public Download downloadtbl { get; set; }

    }
}