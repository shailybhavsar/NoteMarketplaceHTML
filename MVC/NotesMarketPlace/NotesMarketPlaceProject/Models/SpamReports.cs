using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotesMarketPlaceProject.Context;

namespace NotesMarketPlaceProject.Models
{
    public class SpamReports
    {
        public Download downloadtbl { get; set; }
        public SellerNotesReportedIssue reportedissuetbl { get; set; }
        public User usertbl { get; set; }
    }
}