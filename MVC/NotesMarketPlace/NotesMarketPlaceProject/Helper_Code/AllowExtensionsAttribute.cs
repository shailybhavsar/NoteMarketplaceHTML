using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.IO;
namespace NotesMarketPlaceProject.Helper_Code
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class AllowExtensionsAttribute : ValidationAttribute
    {
        public string Extensions { get; set; }

        public override bool IsValid(object value)  
        {
            HttpPostedFileBase myfile = value as HttpPostedFileBase;
            string ext=Path.GetExtension(myfile.FileName);
            ext = ext.TrimStart('.');
            return Extensions.Contains(ext);
        }
    }
}