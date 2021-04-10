using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotesMarketPlaceProject.Models;
using NotesMarketPlaceProject.Context;

namespace NotesMarketPlaceProject.ViewModel
{
    public class MemberDetaiviewModel
    {
        public MemberDetails memberdetailsingledata { get; set; }
        public IEnumerable<MemberDetails> memberdetailstable { get; set; }
    
    }
}