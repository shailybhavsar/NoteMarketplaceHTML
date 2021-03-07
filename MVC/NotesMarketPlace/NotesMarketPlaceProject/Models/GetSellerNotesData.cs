using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotesMarketPlaceProject.Context;

namespace NotesMarketPlaceProject.Models
{
    public class GetSellerNotesData
    {
        public SellerNote titlelist { get; set; }
        public NoteCategory categorylist { get; set; }
        public ReferenceData statuslist { get; set; }
        public String Search_Data { get; set; }
    }
}