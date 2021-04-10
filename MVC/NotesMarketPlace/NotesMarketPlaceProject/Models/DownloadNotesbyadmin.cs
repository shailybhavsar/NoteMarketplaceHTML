using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotesMarketPlaceProject.Context;

namespace NotesMarketPlaceProject.Models
{
    public class DownloadNotesbyadmin
    {
        public User selleruser { get; set; }
        public User buyeruser { get; set; }
        public Download downloaddata { get; set; }
        public User sellerdropdown { get; set; }
        public User buyerdropdown { get; set; }
    }
}