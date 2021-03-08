using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotesMarketPlaceProject.Models;

namespace NotesMarketPlaceProject.ViewModel
{
    public class DashboardViewModel
    {
        public IEnumerable<GetSellerNotesData> inprogress { get; set; }
        public IEnumerable<GetSellerNotesData> published { get; set; }
        public string seacrhdraft { get; set; }
    }
}