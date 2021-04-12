using NotesMarketPlaceProject.Context;
using NotesMarketPlaceProject.Models;
using System.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using PagedList.Mvc;
using PagedList;
using System.Text;
using System.IO;
using NotesMarketPlaceProject.ViewModel;
using Newtonsoft.Json;
using System.Data.Entity.Validation;
using System.Globalization;

namespace NotesMarketPlaceProject.Controllers
{
    public class AdminController : Controller
    {
        NotesMarketPlaceTablesEntities2 db = new NotesMarketPlaceTablesEntities2();

        // GET: Admin

        //AddCountry
        public ActionResult AddCountry(int? id)
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "NotesMarketPlace");
            }
            if (id == null)
            {
                return View();
            }
            else
            {
                var check = db.Countries.Where(x => x.CountryID == id).FirstOrDefault();
                AddCountry Model = new AddCountry
                {
                    CountryCode = check.CountryCode,
                    CountryName = check.CountryName
                };
                return View(Model);
            }
        }

        [HttpPost]
        public ActionResult AddCountry(int? id, AddCountry model)
        {
            var admin = Convert.ToInt32(Session["ID"]);
            var checkid = db.Users.Where(x => x.ID == admin).FirstOrDefault();
            if (id == null)
            {
                if (ModelState.IsValid)
                {
                    Country obj = new Country
                    {
                        CountryName = model.CountryName,
                        CountryCode = model.CountryCode,
                        CreatedDate = DateTime.Now,
                        CreatedBy = checkid.ID,
                        IsActive = true
                    };
                    db.Countries.Add(obj);
                    db.SaveChanges();
                }
                return RedirectToAction("ManageCountry","Admin");
            }
            else
            {
                var check = db.Countries.Where(x => x.CountryID == id).FirstOrDefault();
                check.CountryCode = model.CountryCode;
                check.CountryName = model.CountryName;
                check.ModifiedDate = DateTime.Now;
                check.ModifiedBy = checkid.ID;
                db.SaveChanges();
                return RedirectToAction("ManageCountry", "Admin");
            }
        }

        //Add-Edit Type 
        public ActionResult AddType(int? id)
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "NotesMarketPlace");
            }
            if (id == null)
            {
                return View();
            }
            else
            {
                var check = db.NoteTypes.Where(x => x.TypeID == id).FirstOrDefault();
                AddType model = new AddType
                {
                    TypeName = check.TypeName,
                    Description = check.Description
                };
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult AddType(int? id, AddType model)
        {
            var admin = Convert.ToInt32(Session["ID"]);
            var checkid = db.Users.Where(x => x.ID == admin).FirstOrDefault();
            if (id == null)
            {
                if (ModelState.IsValid)
                {
                    NoteType obj = new NoteType
                    {
                        TypeName = model.TypeName,
                        Description = model.Description,
                        CreatedDate = DateTime.Now,
                        CreatedBy = checkid.ID,
                        IsActive = true
                    };
                    db.NoteTypes.Add(obj);
                    db.SaveChanges();
                }
                return RedirectToAction("ManageType","Admin");
            }
            else
            {
                var check = db.NoteTypes.Where(x => x.TypeID == id).FirstOrDefault();
                check.TypeName = model.TypeName;
                check.Description = model.Description;
                check.ModifiedDate = DateTime.Now;
                check.ModifiedBy = checkid.ID;
                db.SaveChanges();
                return RedirectToAction("ManageType","Admin");
            }
        }



        //Add Category
        public ActionResult AddCategory(int? id)
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "NotesMarketPlace");
            }
            if (id == null)
            {
                return View();
            }
            else
            {
                var check = db.NoteCategories.Where(x => x.CategoryID == id).FirstOrDefault();
                AddCategory Model = new AddCategory
                {
                    CategoryName = check.CategoryName,
                    Description = check.Description
                };
                return View(Model);
            }
        }
        [HttpPost]
        public ActionResult AddCategory(int? id, AddCategory model)
        {
            var admin = Convert.ToInt32(Session["ID"]);
            var checkid = db.Users.Where(x => x.ID == admin).FirstOrDefault();
            if (id == null)
            {
                if (ModelState.IsValid)
                {
                    NoteCategory obj = new NoteCategory
                    {
                        CategoryName = model.CategoryName,
                        Description = model.Description,
                        CreatedDate = DateTime.Now,
                        CreatedBy = checkid.ID,
                        IsActive = true
                    };
                    db.NoteCategories.Add(obj);
                    db.SaveChanges();
                }
                return RedirectToAction("ManageCategory", "Admin");
            }
            else
            {
                var check = db.NoteCategories.Where(x => x.CategoryID == id).FirstOrDefault();
                check.CategoryName = model.CategoryName;
                check.Description = model.Description;
                check.ModifiedDate = DateTime.Now;
                check.ModifiedBy = checkid.ID;
                db.SaveChanges();
                return RedirectToAction("ManageCategory", "Admin");
            }
            
        }

        //Add Administrator
        public ActionResult AddAdministrator(int? id)
        {
            List<Country> countrcode = db.Countries.ToList();
            ViewBag.countrycode = new SelectList(countrcode, "CountryCode", "CountryCode");
            var checksuperadmin = Convert.ToInt32(Session["ID"]);
            var existindb = db.Users.Where(x => x.ID == checksuperadmin).FirstOrDefault();
            if (Session["ID"] != null && existindb.RoleID==8)
            {
                if (id == null)
                {
                    return View();
                }
                else
                {
                    var check = db.Users.Where(x => x.ID == id).FirstOrDefault();
                    var exist = db.UserProfiles.Where(x => x.UserID == id).FirstOrDefault();

                    AddAdministrator Model = new AddAdministrator
                    {
                        FirstName = check.FirstName,
                        LastName = check.LastName,
                        Email = check.EmailID,
                        PhoneNumberCountryCOde = exist.PhoneNumberCountryCOde,
                        phonenumber = exist.PhoneNumber
                    };
                    return View(Model);
                }
            }
            else
            {
                return RedirectToAction("Login", "NotesMarketPlace");
            }
        }

        [HttpPost]
        public ActionResult AddAdministrator(int? id, AddAdministrator Model)
        {
            List<Country> countrcode = db.Countries.ToList();
            ViewBag.countrycode = new SelectList(countrcode, "CountryCode", "CountryCode");

            string strNewPassword = null;
            if (id == null)
            {
                if (ModelState.IsValid)
                {
                    strNewPassword = GeneratePassword().ToString();
                    User obj = new User
                    {
                        RoleID = 7,
                        FirstName = Model.FirstName,
                        LastName = Model.LastName,
                        EmailID = Model.Email,
                        Password = strNewPassword,
                        IsEmailVerified = false,
                        CreatedDate = DateTime.Now,
                        IsActive = true
                    };
                    db.Users.Add(obj);
                    UserProfile obj1 = new UserProfile
                    {
                        UserID = obj.ID,
                        PhoneNumberCountryCOde = Model.PhoneNumberCountryCOde,
                        PhoneNumber = Model.phonenumber,
                        AddressLine1 = "Tatvasoft",
                        AddressLine2 = "xxx",
                        City = "Ahmedabad",
                        State = "Gujarat",
                        Country = "India",
                        ZipCode = "380056"
                    };
                    db.UserProfiles.Add(obj1);
                    db.SaveChanges();
                }
                var SenderEMail = new MailAddress("aaabhavsar022@gmail.com");
                var receiverEmail = new MailAddress(Model.Email);
                var SenderPassword = "Shreya@3103";
                var subject = "Password has been created for you for NotesMarketPlace";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(SenderEMail.Address, SenderPassword);

                MailMessage mailMessage = new MailMessage(SenderEMail.Address, receiverEmail.Address);
                mailMessage.Subject = subject;
                mailMessage.Body = "<br/>Hello, " + Model.FirstName + "<br/>We have generated password for you" + "<br/>" + strNewPassword + "<br/>" + "Regards, <br/> Notes MarketPlace.";

                mailMessage.IsBodyHtml = true;
                smtp.Send(mailMessage);
                return View();
            }
            else
            {
                var check = db.Users.Where(x => x.ID == id).FirstOrDefault();
                var exist = db.UserProfiles.Where(x => x.UserID == id).FirstOrDefault();
                check.FirstName = Model.FirstName;
                check.LastName = Model.LastName;
                check.EmailID = Model.Email;
                check.ModifiedDate = DateTime.Now;
                exist.PhoneNumberCountryCOde = Model.PhoneNumberCountryCOde;
                exist.PhoneNumber = Model.phonenumber;

                db.SaveChanges();
                return View();
            }

        }

        public string GeneratePassword()
        {
            string PasswordLength = "8";
            string NewPassword = "";

            string allowedChars = "";
            allowedChars = "1,2,3,4,5,6,7,8,9,0";
            allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
            allowedChars += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";


            char[] sep = { ',' };
            string[] arr = allowedChars.Split(sep);


            string IDString = "";
            string temp = "";

            Random rand = new Random();

            for (int i = 0; i < Convert.ToInt32(PasswordLength); i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                IDString += temp;
                NewPassword = IDString;

            }
            return NewPassword;
        }

        //Manage country
        public ActionResult ManageCountry()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "NotesMarketPlace");
            }
            List<Country> countrytbl = db.Countries.ToList();
            List<User> usertbl = db.Users.ToList();
            var managecountry = from c in countrytbl
                                join u in usertbl on c.CreatedBy equals u.ID 
                                orderby c.CreatedDate descending
                                select new AddCountry { countrytbl = c, usertbl = u };
            return View(managecountry);
        }

        //Manage type
        public ActionResult ManageType()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "NotesMarketPlace");
            }
            List<NoteType> notetypetbl = db.NoteTypes.ToList();
            List<User> usertbl = db.Users.ToList();
            var managetype = from n in notetypetbl
                             join u in usertbl on n.CreatedBy equals u.ID
                             orderby n.CreatedDate descending
                             select new AddType { notetypetbl = n, usertbl = u };
            return View(managetype);
        }
        
        public ActionResult ManageAdmin()
        {
            var checksuperadmin = Convert.ToInt32(Session["ID"]);
            var existindb = db.Users.Where(x => x.ID == checksuperadmin).FirstOrDefault();
            if (Session["ID"] != null && existindb.RoleID == 8)
            {
                if (Session["ID"] == null)
                {
                    return RedirectToAction("Login", "NotesMarketPlace");
                }
                List<User> usertbl = db.Users.Where(x => x.RoleID == 7).ToList();
                List<UserProfile> userprofiletbl = db.UserProfiles.ToList();
                var manageadmin = from u in usertbl
                                  join up in userprofiletbl on u.ID equals up.UserID
                                  orderby u.CreatedDate descending
                                  select new AddAdministrator { usertbl = u, userprofiletbl = up };
                return View(manageadmin);
            }
            else
            {
                return RedirectToAction("Login", "NotesMarketPlace");
            }
        }

        //Manage category
        public ActionResult ManageCategory()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "NotesMarketPlace");
            }
            List<NoteCategory> notecategorytbl = db.NoteCategories.ToList();
            List<User> usertbl = db.Users.ToList();
            var managecategory = from n in notecategorytbl
                                 join u in usertbl on n.CreatedBy equals u.ID 
                                 orderby n.CreatedDate descending
                                 select new AddCategory { notecategorytbl = n, usertbl = u };
            return View(managecategory);
        }

        //Manage System Configuration
        public ActionResult ManageSystemConfiguration()
        {
            return View();
        }

        //Delete Country
        public ActionResult DeleteCountry(int id)
        {

            var check = db.Countries.Where(x => x.CountryID == id).FirstOrDefault();
            check.IsActive = false;
            db.SaveChanges();
            return RedirectToAction("ManageCountry");
        }

        //Delete Category
        public ActionResult DeleteCategory(int id)
        {
            var check = db.NoteCategories.Where(x => x.CategoryID == id).FirstOrDefault();
            check.IsActive = false;
            db.SaveChanges();
            return RedirectToAction("ManageCategory");
        }

        //Delete Type
        public ActionResult DeleteType(int id)
        {
            var check = db.NoteTypes.Where(x => x.TypeID == id).FirstOrDefault();
            check.IsActive = false;
            db.SaveChanges();
            return RedirectToAction("ManageType");
        }

        //delete admin
        public ActionResult DeleteAdmin(int id)
        {
            var check = db.Users.Where(x => x.ID == id).FirstOrDefault();
            check.IsActive = false;
            db.SaveChanges();
            return RedirectToAction("ManageAdmin");
        }

        //Notes Under Review
        public ActionResult NotesUnderReview(int? id)
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "NotesMarketPlace");
            }
            //For common member
            List<User> usertbl = db.Users.ToList();

            //For particular member
            List<User> memberuser = db.Users.Where(x => x.ID == id).ToList();

            List<SellerNote> sellernotetbl = db.SellerNotes.Where(x => x.Status == 7 || x.Status == 8).ToList();
            List<NoteCategory> notecategorytbl = db.NoteCategories.ToList();

            //For seller dropdown
            List<SellerNote> sellernoteobj = db.SellerNotes.Where(x => x.Status == 7 || x.Status == 8).GroupBy(x => x.SellerID).Select(x => x.FirstOrDefault()).ToList();
            
            if (id == null)
            {
                var notesunderreview = from u in usertbl
                                       join s in sellernotetbl on u.ID equals s.SellerID into table1
                                       from s in table1
                                       join n in notecategorytbl on s.Category equals n.CategoryID
                                       orderby s.CreatedDate descending
                                       select new Notesunderreview { notecategorytbl = n, sellernotetbl = s, usertbl = u };

                List<User> userobj = db.Users.ToList();

                ViewBag.Sellername = (from s in sellernoteobj
                                      join u in userobj on s.SellerID equals u.ID into table1
                                      from u in table1
                                      select new Notesunderreview { usertblfordropdown = u, sellertbldropdown = s });

                return View(notesunderreview);
            }
            else
            {
                List<User> userobj = db.Users.Where(x => x.ID == id).ToList();
                var notesunderreview= from m in memberuser
                                      join s in sellernotetbl on m.ID equals s.SellerID into table1
                                      from s in table1
                                      join n in notecategorytbl on s.Category equals n.CategoryID
                                      orderby s.CreatedDate descending
                                      select new Notesunderreview { notecategorytbl = n, sellernotetbl = s, usertbl = m };

                ViewBag.Sellername = (from s in sellernoteobj
                                      join u in userobj on s.SellerID equals u.ID into table1
                                      from u in table1
                                      select new Notesunderreview { usertblfordropdown = u, sellertbldropdown = s });

                return View(notesunderreview);
            }
        }

        //When Admin clicks on Inreview button
        public ActionResult ReviewNotes(int id)
        {
            var check = db.SellerNotes.Where(x => x.ID == id && x.Status == 7).FirstOrDefault();
            check.Status = 8;
            db.SaveChanges();
            return RedirectToAction("NotesUnderReview", "Admin");
        }

        //When Admin clicks on Approve button
        public ActionResult ApproveNotes(int id)
        {
            var check = db.SellerNotes.Where(x => x.ID == id && (x.Status == 7 || x.Status == 8)).FirstOrDefault();
            check.Status = 9;
            check.PublishedDate = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("NotesUnderReview", "Admin");
        }

        //When  Admin clicks on Reject button
        [HttpPost]
        public ActionResult RejectNotes(int id)
        {
            var comments = Request.Form["Comment"];
            var check = db.SellerNotes.Where(x => x.ID == id).FirstOrDefault();
            check.AdminRemarks = comments;
            check.Status = 10;
            db.SaveChanges();
            return RedirectToAction("NotesUnderReview", "Admin");
        }

        //When Admin clicks on download table
        public ActionResult DownloadPdf(int id)
        {
            var temp = db.SellerNotesAttachments.Where(x => x.NoteID == id).FirstOrDefault();
            string path = Server.MapPath("~/Uploadimg/") + temp.FileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            // Send the File to Download.
            return File(bytes, "application/octet-stream", temp.FileName);
        }

        //Member Details
        public ActionResult MemberDetails(int? id)
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "NotesMarketPlace");
            }
            
                List<User> userobj = db.Users.Where(x => x.ID == id).ToList();
                var SingleMember = (from user in db.Users
                                    join userprofile in db.UserProfiles on user.ID equals userprofile.UserID
                                    where user.ID == id
                                    select new MemberDetails
                                    {
                                        singleuser = user,
                                        singleuserprofile = userprofile
                                    }).FirstOrDefault();

                var Singlemembertbl = (from user in db.Users.Where(x=>x.ID==id)
                                       join sellerdata in db.SellerNotes on user.ID equals sellerdata.SellerID into table1
                                       from sellerdata in table1
                                       join category in db.NoteCategories on sellerdata.Category equals category.CategoryID
                                       where sellerdata.Status != 6 && sellerdata.Status != 11 && sellerdata.SellerID == id
                                       select new MemberDetails
                                       {
                                           sellernotetbl = sellerdata,
                                           categorytbl = category,
                                           usertbl = user
                                       });
                List<SellerNote> selllerobj = db.SellerNotes.Where(x => x.SellerID == id).ToList();

                var check = db.Users.Where(x => x.ID == id).FirstOrDefault();
                var exist = db.SellerNotes.Where(x => x.SellerID == check.ID).ToList();
                //var downloadtblrecord = db.Downloads.Where(x => x.NoteID == exist.ID).ToList();
                MemberDetaiviewModel model = new MemberDetaiviewModel
                {
                    memberdetailsingledata = SingleMember,
                    memberdetailstable = Singlemembertbl
                };

                //foreach (var u in Singlemembertbl)
                //{
                //    List<Download> downloadnotes = db.Downloads.Where(x => x.NoteID == u.sellernotetbl.ID && x.Seller != x.Downloader && x.IsAttachmentDownloaded == true && x.IsSellerHasAllowedDownload).ToList();
                //    string downloadnotescount = Convert.ToString(u.sellernotetbl.ID);
                //    TempData[downloadnotescount + "1"] = downloadnotes.Count;
                //}

                //foreach (var u in Singlemembertbl)
                //{
                //    List<Download> earning = db.Downloads.Where(x => x.NoteID == u.sellernotetbl.ID && x.IsAttachmentDownloaded == true).ToList();
                //    var sum = earning.Sum(x => x.PurchasedPrice);
                //    string totalearning = Convert.ToString(u.sellernotetbl.ID);
                //    TempData[totalearning + "2"] = sum;
                //}
                foreach(SellerNote s in selllerobj)
            {
                List<Download> downloadnotes = db.Downloads.Where(x => x.NoteID == s.ID && x.IsAttachmentDownloaded == true).ToList();
                string downloadnotescount = Convert.ToString(s.ID);
                TempData[downloadnotescount + "1"] = downloadnotes.Count;
            }

                foreach(SellerNote s in selllerobj)
            {
                List<Download> earning = db.Downloads.Where(x => x.NoteID == s.ID && x.IsAttachmentDownloaded == true).ToList();
                var sum = earning.Sum(x => x.PurchasedPrice);
                string totalearning = Convert.ToString(s.ID);
                TempData[totalearning + "2"] = sum;
            }
            return View(model);
        }

        //Member Profile Photo
        public FileContentResult MemberProfilePhoto(int id)
        {
            var exist = db.UserProfiles.Where(x => x.ID == id).FirstOrDefault();
            if (exist.ProfilePicture == null)
            {
                string profilephoto = "member.png";
                string fileName = HttpContext.Server.MapPath("~/Uploadprofileimg/" + profilephoto);
                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(fileName);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);

                return File(imageData, "image/png");
            }
            else
            {
                string fileName = HttpContext.Server.MapPath("~/Uploadprofileimg/" + exist.ProfilePicture);
                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(fileName);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);
                return File(imageData, "image/png");
            }
        }
    
        public ActionResult RejectedNotes()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "NotesMarketPlace");
            }
            //usertbl for getting sellername
            List<User> usertbl = db.Users.ToList();
            //usertbladmin for getting adminname(who reject the notes)
            List<User> useradmintbl = db.Users.ToList();

            List<SellerNote> sellernotetbl = db.SellerNotes.Where(x => x.Status == 10).ToList();
            List<NoteCategory> notecattbl = db.NoteCategories.ToList();
            var rejectednotes = from u in usertbl
                                join s in sellernotetbl on u.ID equals s.SellerID into table1
                                from s in table1
                                join ua in useradmintbl on s.ActionedBy equals ua.ID into table2
                                from ua in table2
                                join n in notecattbl on s.Category equals n.CategoryID
                                orderby s.CreatedDate descending
                                select new RejectedNotesAdmin{ usertbl = u, sellernotetbl = s, notecattbl = n , useradmin =ua};

            List<SellerNote> sellernoteobj = db.SellerNotes.Where(x => x.Status == 10).GroupBy(x => x.SellerID).Select(x => x.FirstOrDefault()).ToList();

            ViewBag.Sellername = from u in usertbl
                                 join s in sellernoteobj on u.ID equals s.SellerID into table1
                                 from s in table1
                                 select new RejectedNotesAdmin { sellerdropdown = s, usertbl = u };
            return View(rejectednotes);
        }
        //When addmin approve notes from rejected notes
        public ActionResult ApproveNotesFromRejectedNotes(int id)
        {
            var check = db.SellerNotes.Where(x => x.ID == id && (x.Status == 10)).FirstOrDefault();
            check.Status = 9;
            check.PublishedDate = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("RejectedNotes", "Admin");
        }

        public ActionResult PublishedNotesByAdmin(int? id)
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "NotesMarketPlace");
            }
            //usertbl for getting sellername
            List<User> usertbl = db.Users.ToList();
            //single user(from member)
            List<User> memberuser = db.Users.Where(x => x.ID == id).ToList();
            //usertbladmin for getting adminname(who reject the notes)
            List<User> useradmintbl = db.Users.ToList();
            List<SellerNote> sellernotetbl = db.SellerNotes.Where(x => x.Status == 9).ToList();
            List<NoteCategory> notecattbl = db.NoteCategories.ToList();
            List<Download> downloadtbl = db.Downloads.ToList();

            //for dropdown
            List<SellerNote> sellernoteobj = db.SellerNotes.Where(x => x.Status == 9).GroupBy(x => x.SellerID).Select(x => x.FirstOrDefault()).ToList();


            if (id == null)
            {
                var publishednotes = from u in usertbl
                                     join s in sellernotetbl on u.ID equals s.SellerID into table1
                                     from s in table1
                                     join ua in useradmintbl on s.ActionedBy equals ua.ID into table2
                                     from ua in table2
                                     join n in notecattbl on s.Category equals n.CategoryID
                                     orderby s.PublishedDate descending
                                     select new PublishedNotesByAdmin { usertbl = u, sellernotetbl = s, notecattbl = n, useradmin = ua };

                ViewBag.sellername = from u in usertbl
                                     join s in sellernoteobj on u.ID equals s.SellerID into table1
                                     from s in table1
                                     select new PublishedNotesByAdmin { sellerdropdown = s, usertbl = u };

                PublishedNotesadminvm Model = new PublishedNotesadminvm
                {
                    singlerowdata = publishednotes,
                };

                foreach (SellerNote s in sellernotetbl)
                {
                    List<Download> data = db.Downloads.Where(x => x.NoteID == s.ID && x.IsSellerHasAllowedDownload == true && x.IsAttachmentDownloaded == true).ToList();
                    string ids = Convert.ToString(s.ID);
                    TempData[ids] = data.Count;
                }
                return View(Model);
            }
            else
            {
                var publishednotes = from u in memberuser
                                     join s in sellernotetbl on u.ID equals s.SellerID into table1
                                     from s in table1
                                     join ua in useradmintbl on s.ActionedBy equals ua.ID into table2
                                     from ua in table2
                                     join n in notecattbl on s.Category equals n.CategoryID
                                     orderby s.PublishedDate descending
                                     select new PublishedNotesByAdmin { usertbl = u, sellernotetbl = s, notecattbl = n, useradmin = ua };
                
                ViewBag.sellername = from u in memberuser
                                     join s in sellernoteobj on u.ID equals s.SellerID into table1
                                     from s in table1
                                     select new PublishedNotesByAdmin { sellerdropdown = s, usertbl = u };

                PublishedNotesadminvm Model = new PublishedNotesadminvm
                {
                    singlerowdata = publishednotes,
                };
                List<SellerNote> sellernotetblforsinglemember = db.SellerNotes.Where(x => x.Status == 9 && x.SellerID==id).ToList();
                foreach (SellerNote s in sellernotetblforsinglemember)
                {
                    List<Download> data = db.Downloads.Where(x => x.NoteID == s.ID && x.IsSellerHasAllowedDownload == true && x.IsAttachmentDownloaded == true).ToList();
                    string ids = Convert.ToString(s.ID);
                    TempData[ids] = data.Count;
                }
                return View(Model);

            }
        }
        public int GetCountBook(int id)
        {
            return db.Downloads.Where(x => x.NoteID == id).Count();
        }

        //when admin click on unpublish from dropdown of published books
        [HttpPost]
        public ActionResult UnpublishBook(int id)
        {
            var remarks = Request.Form["Remarks"];
            var check = db.SellerNotes.Where(x => x.ID == id).FirstOrDefault();
            check.AdminRemarks = remarks;
            check.Status = 11;
            db.SaveChanges();

            //to get the seller id
            var sellerid = db.Users.Where(x => x.ID == check.SellerID).FirstOrDefault();

            var SenderEMail = new MailAddress("aaabhavsar022@gmail.com");
            var receiverEmail = new MailAddress(sellerid.EmailID);
            var SenderPassword = "Shreya@3103";
            var subject = "Sorry!! we need to remove your notes from our portal.";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(SenderEMail.Address, SenderPassword);

            MailMessage mailMessage = new MailMessage(SenderEMail.Address, receiverEmail.Address);
            mailMessage.Subject = subject;
            mailMessage.Body = "<br/><br/><br/>Hello, " + sellerid.FirstName + "<br/><br/>We want to inform you that, your note " + check.Title + " has been removed from the portal." + "<br/><br/>Please Find our remarks as below." +"<br/><br/>" +check.AdminRemarks+ "<br/><br/> Regards, Notes MarketPlace.";

            mailMessage.IsBodyHtml = true;
            smtp.Send(mailMessage);

            return RedirectToAction("PublishedNotesByAdmin", "Admin");
        }

        public ActionResult Dashboard(string searchmonth)
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "NotesMarketPlace");
            }
            ViewBag.NoOfNotesInReview = db.SellerNotes.Where(x => x.Status == 8).Count();
            var dt = DateTime.Now.AddDays(-7);
            ViewBag.NoOfNotesDownloadedin7days = db.Downloads.Where(x => x.AttachmentDownloadedDate > dt).Count();
            ViewBag.NoOfNewRegistration = db.Users.Where(x=>x.RoleID==6 && x.CreatedDate > dt).Count();

            var minDate = DateTime.Now.AddMonths(-1);
            //List<SellerNote> sellerobj = db.SellerNotes.Where(x => x.Status == 9 && (x.PublishedDate>=dtFrom && x.PublishedDate<=dtTo)).ToList();
            List<User> userobj = db.Users.ToList();
            var a = DateTime.Now.AddMonths(-6);
            List<SellerNote> sellerobj = db.SellerNotes.Where(x=>x.PublishedDate>=a && x.Status==9).ToList();

            List<NoteCategory> notecatobj = db.NoteCategories.ToList();

            if(!String.IsNullOrEmpty(searchmonth))
            {
                sellerobj = sellerobj.Where(x => x.PublishedDate.Value.ToString("Y").Equals(searchmonth)).ToList();
            }
            else
            {
                sellerobj = sellerobj.Where(x => x.PublishedDate.Value.ToString("Y").Equals(DateTime.Now.ToString("Y"))).ToList();
            }

            foreach (SellerNote s in sellerobj)
            {
                List<Download> data = db.Downloads.Where(x => x.NoteID == s.ID && x.IsSellerHasAllowedDownload == true && x.IsAttachmentDownloaded == true).ToList();
                string ids = Convert.ToString(s.ID);
                TempData[ids] = data.Count;

                SellerNotesAttachment fileuploaddetail = db.SellerNotesAttachments.Where(x => x.NoteID == s.ID).FirstOrDefault();
                string path = null;
                if (fileuploaddetail.FilePath != null)
                {
                    path = fileuploaddetail.FilePath;
                    System.IO.FileInfo file = new System.IO.FileInfo(path);
                    string unit = "B";
                    long filesize = file.Length;
                    if (filesize >= 1024 * 1024)
                    {
                        filesize = filesize / (1024 * 1024);
                        unit = "MB";
                    }
                    if (filesize >= 1024)
                    {
                        filesize = filesize / 1024;
                        unit = "KB";
                    }
                    TempData[ids + "size"] = filesize.ToString() + unit;
                }

            }
            
                var dashboard = from u in userobj
                                join s in sellerobj on u.ID equals s.ActionedBy into table1
                                from s in table1
                                join n in notecatobj on s.Category equals n.CategoryID
                                orderby s.PublishedDate descending
                                select new DashboardAdmin { notecattbl = n, sellernotetbl = s, usertbl = u };
                return View(dashboard);
          
        }
        
        public ActionResult DownloadedNotes(int? id)
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "NotesMarketPlace");
            }
            if (id == null)
            {
                List<Download> downloadobj = db.Downloads.Where(x => x.IsAttachmentDownloaded == true && (x.Seller!=x.Downloader)).ToList();
                List<User> buyerdata = db.Users.ToList();
                List<User> sellerdata = db.Users.ToList();
                var downlodednotes = from d in downloadobj
                                     join b in buyerdata on d.Downloader equals b.ID into table1
                                     from b in table1
                                     join s in sellerdata on d.Seller equals s.ID
                                     orderby d.AttachmentDownloadedDate descending
                                     select new DownloadNotesbyadmin { downloaddata = d, buyeruser = b, selleruser = s };

                //dropdown for select note
                List<Download> selectnote = db.Downloads.GroupBy(x => x.NoteTitle).Select(x => x.FirstOrDefault()).Where(x => x.IsAttachmentDownloaded == true).ToList();
                ViewBag.Selectnote = selectnote;

                //dropdown for selecting seller
                List<Download> downloaddataseller = db.Downloads.Where(x => x.IsAttachmentDownloaded == true).GroupBy(x => x.Seller).Select(x => x.FirstOrDefault()).ToList();
                ViewBag.Seller = (from u in sellerdata
                                  join s in downloaddataseller on u.ID equals s.Seller into table1
                                  from s in table1
                                  select new DownloadNotesbyadmin { downloaddata = s, sellerdropdown = u });

                //dropdown for selecting buyer
                List<Download> downloaddatabuyer = db.Downloads.Where(x => x.IsAttachmentDownloaded == true).GroupBy(x => x.Downloader).Select(x => x.FirstOrDefault()).ToList();
                ViewBag.Buyer = from u in sellerdata
                                join s in downloaddatabuyer on u.ID equals s.Downloader into table1
                                from s in table1
                                select new DownloadNotesbyadmin { downloaddata = s, buyerdropdown = u };

                return View(downlodednotes);
            }
            else
            {
                List<Download> downloadobj = db.Downloads.Where(x => x.IsAttachmentDownloaded == true && x.Downloader==id).ToList();
                List<User> buyerdata = db.Users.ToList();
                List<User> sellerdata = db.Users.ToList();
                var downlodednotes = from d in downloadobj
                                     join b in buyerdata on d.Downloader equals b.ID into table1
                                     from b in table1
                                     join s in sellerdata on d.Seller equals s.ID
                                     orderby d.AttachmentDownloadedDate descending
                                     select new DownloadNotesbyadmin { downloaddata = d, buyeruser = b, selleruser = s };

                //dropdown for select note
                List<Download> selectnote = db.Downloads.Where(x => x.IsAttachmentDownloaded == true && x.Downloader == id).GroupBy(x => x.NoteTitle).Select(x => x.FirstOrDefault()).ToList();
                ViewBag.Selectnote = selectnote;

                //dropdown for selecting seller
                List<Download> downloaddataseller = db.Downloads.Where(x => x.IsAttachmentDownloaded == true && x.Downloader == id).GroupBy(x => x.Seller).Select(x => x.FirstOrDefault()).ToList();
                ViewBag.Seller = (from u in sellerdata
                                  join s in downloaddataseller on u.ID equals s.Seller into table1
                                  from s in table1
                                  select new DownloadNotesbyadmin { downloaddata = s, sellerdropdown = u });

                //dropdown for selecting buyer
                List<Download> downloaddatabuyer = db.Downloads.Where(x => x.IsAttachmentDownloaded == true && x.Downloader==id).GroupBy(x => x.Downloader).Select(x => x.FirstOrDefault()).ToList();
                ViewBag.Buyer = from u in sellerdata
                                join s in downloaddatabuyer on u.ID equals s.Downloader into table1
                                from s in table1
                                select new DownloadNotesbyadmin { downloaddata = s, buyerdropdown = u };

                return View(downlodednotes);
            }
        }
        public ActionResult Members()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "NotesMarketPlace");
            }
            List<User> userobj = db.Users.ToList();
            var Model = from u in db.Users.Where(x=>x.RoleID == 6) 
                        join up in db.UserProfiles on u.ID equals up.UserID
                        orderby u.CreatedDate descending
                        select new Members { usertbl = u };

            
            ViewBag.Users = db.Users.Where(x => x.RoleID == 6).ToList();
            foreach(User u in userobj)
            {
                List<SellerNote> noteunderreview = db.SellerNotes.Where(x => x.SellerID == u.ID && (x.Status == 7 || x.Status==8)).ToList();
                string noteunderreviewcount = Convert.ToString(u.ID);
                TempData[noteunderreviewcount+"1"] = noteunderreview.Count;
            }
            foreach(User u in userobj)
            {
                List<SellerNote> publishednotes = db.SellerNotes.Where(x => x.SellerID == u.ID && x.Status == 9).ToList();
                string publishednotescount = Convert.ToString(u.ID);
                TempData[publishednotescount+"2"] = publishednotes.Count;
            }
            foreach(User u in userobj)
            {
                List<Download> downloadnotes = db.Downloads.Where(x => x.Downloader == u.ID && x.IsAttachmentDownloaded == true && x.IsSellerHasAllowedDownload).ToList();
                string downloadnotescount = Convert.ToString(u.ID);
                TempData[downloadnotescount+"3"] = downloadnotes.Count;
            }
            foreach(User u in userobj)
            {
                List<Download> expense = db.Downloads.Where(x => x.Downloader == u.ID && x.IsAttachmentDownloaded == true && x.IsSellerHasAllowedDownload == true && x.IsPaid == true).ToList();
                var sum = expense.Sum(x => x.PurchasedPrice);
                string totalexpense = Convert.ToString(u.ID);
                TempData[totalexpense + "4"] = sum;
            }
            foreach(User u in userobj)
            {
                List<Download> earning = db.Downloads.Where(x => x.Seller == u.ID && x.IsAttachmentDownloaded == true && x.IsSellerHasAllowedDownload == true && x.IsPaid == true).ToList();
                var sum = earning.Sum(x => x.PurchasedPrice);
                string totalearning = Convert.ToString(u.ID);
                TempData[totalearning + "5"] = sum;
            }
            return View(Model);
        }
        public ActionResult Deactivate(int id)
        {
            var check = db.Users.Where(x => x.ID == id).FirstOrDefault();
            var checkinsellernotes = db.SellerNotes.Where(x => x.SellerID == id).FirstOrDefault();
            check.IsActive = false;
            if (checkinsellernotes != null)
            {
                checkinsellernotes.Status = 11;
            }
            db.SaveChanges();
            return RedirectToAction("Members", "Admin");
        }

        public ActionResult NoteDetails(int id)
        {
            var exist = db.SellerNotes.Where(x => x.ID == id).FirstOrDefault();

            int reportissuecount = db.SellerNotesReportedIssues.Where(x => x.NoteID == exist.ID).Count();
            int ratingcount = db.SellerNotesReviews.Where(x => x.NoteID == exist.ID).Count();

            var reviews = db.SellerNotesReviews.Where(x => x.NoteID == exist.ID).ToList();
            if (reviews != null)
            {
                decimal avg = Math.Round((from x in reviews select x.Ratings).DefaultIfEmpty().Average());
                ViewBag.Rating = avg;//To display stars
            }
            else
            {
                ViewBag.Rating = 0;
            }

            SearchNotes note = (from snote in db.SellerNotes
                                join category in db.NoteCategories on snote.Category equals category.CategoryID
                                where snote.ID == id
                                select new SearchNotes
                                {
                                    Singlenote = snote
                                }).SingleOrDefault();

            var cname = db.Countries.Where(x => x.CountryID == note.Singlenote.Country).SingleOrDefault();
            note.CountryName = cname.CountryName;

            //Passing data from viewbag for display review table
            ViewBag.Reviewtable = from u in db.Users
                                  join r in db.SellerNotesReviews on u.ID equals r.ReviewedByID into table1
                                  from r in table1
                                  join up in db.UserProfiles on r.ReviewedByID equals up.UserID into table2
                                  from up in table2
                                  where r.NoteID == id
                                  select new SearchNotes { userdata = u, reviewdata = r, userprofiledata = up };

            //if (Session["ID"] != null)
            //{
            //    ViewBag.BuyerName = buyername.FirstName;
            //}
            //ViewBag.SellerName = sellername.FirstName + " " + sellername.LastName;
            ViewBag.ReprtIssue = reportissuecount;//To display number of reported issues

            ViewBag.Numberofratings = ratingcount;//Display number of rating
            return View(note);
        }

        public ActionResult DeleteReview(int id)
        {
            SellerNotesReview record = db.SellerNotesReviews.Find(id);
            db.SellerNotesReviews.Remove(record);
            db.SaveChanges();
            
            return View("NoteDetails");
        }
        public ActionResult UpdateProfile()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "NotesMarketPlace");
            }
            List<Country> countrcode = db.Countries.ToList();
            ViewBag.countrycode = new SelectList(countrcode, "CountryCode", "CountryCode");

            var result = Convert.ToInt32(Session["ID"]);
            var exists = db.Users.Where(a => a.ID == result).FirstOrDefault();

            if (Session["ID"]==null)
            {
                return RedirectToAction("Login", "NotesMarketPlace");
            }
            else
            {
                MyProfile model = new MyProfile
                {
                    FirstName = exists.FirstName,
                    LastName = exists.LastName,
                    Email = exists.EmailID

                };
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult UpdateProfile(MyProfile model, HttpPostedFileBase upload)
        {
            List<Country> countrcode = db.Countries.ToList();
            ViewBag.countrycode = new SelectList(countrcode, "CountryCode", "CountryCode");

            var result = Convert.ToInt32(Session["ID"]);
            var check = db.Users.Where(x => x.ID == result).FirstOrDefault();
            var exist = db.UserProfiles.Where(x => x.UserID == result).FirstOrDefault();

            string name = null;
            string ex = null;
            if (upload != null)
            {
                ex = Path.GetExtension(upload.FileName);
                name = "DP_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ex;
                string path = Path.Combine(Server.MapPath("~/Uploadprofileimg"), name);
                upload.SaveAs(path);

            }

            check.FirstName = model.FirstName;
            check.LastName = model.LastName;


            exist.SecondaryEmailAddress = model.secondaryemail;
            exist.PhoneNumberCountryCOde = model.PhoneNumberCountryCOde;
            exist.PhoneNumber = model.phonenumber;
            exist.ProfilePicture = name;
            db.SaveChanges();
            return View();
            
        }
        public ActionResult SpamReports()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "NotesMarketPlace");
            }
            List<User> usertbl = db.Users.ToList();
            List<SellerNotesReportedIssue> reportedIssues = db.SellerNotesReportedIssues.ToList();
            List<Download> downloadtbl = db.Downloads.GroupBy(x => x.Downloader).Select(x => x.FirstOrDefault()).ToList();
            var reportedissue = from r in reportedIssues
                                join d in downloadtbl on r.ReportedByID equals d.Downloader into table1
                                from d in table1
                                join u in usertbl on d.Downloader equals u.ID
                                orderby r.CreatedDate descending
                                select new SpamReports { downloadtbl = d, reportedissuetbl = r, usertbl = u };
            return View(reportedissue);
        }
        public ActionResult RemoveReportedIssue(int? id)
        {
            SellerNotesReportedIssue record = db.SellerNotesReportedIssues.Find(id);
            db.SellerNotesReportedIssues.Remove(record);
            db.SaveChanges();
            return RedirectToAction("SpamReports");
        }

        public FileContentResult UserPhoto()
        {
            var tempvar = Convert.ToInt32(Session["ID"]);
            var exits = db.UserProfiles.Where(x => x.UserID == tempvar).FirstOrDefault();
            if (exits == null)
            {
                string profilephoto = "Defaultimg.png";
                string fileName = HttpContext.Server.MapPath("~/AdminProfilePhoto/" + profilephoto);
                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(fileName);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);
                return File(imageData, "image/png");

            }

            else
            {
                var userimg = db.UserProfiles.Where(x => x.UserID == tempvar).FirstOrDefault();
                //byte[] bytes = Encoding.ASCII.GetBytes(userimg.ProfilePicture);
                if (userimg.ProfilePicture != null)
                {
                    string fileName = HttpContext.Server.MapPath("~/AdminProfilePhoto/" + userimg.ProfilePicture);
                    byte[] imageData = null;
                    FileInfo fileInfo = new FileInfo(fileName);
                    long imageFileLength = fileInfo.Length;
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imageData = br.ReadBytes((int)imageFileLength);
                    return File(imageData, "image/png");
                }
                else
                {
                    string profilephoto = "Defaultimg.png";
                    string fileName = HttpContext.Server.MapPath("~/AdminProfilePhoto/" + profilephoto);
                    byte[] imageData = null;
                    FileInfo fileInfo = new FileInfo(fileName);
                    long imageFileLength = fileInfo.Length;
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imageData = br.ReadBytes((int)imageFileLength);

                    return File(imageData, "image/png");
                }

            }
        }

    }
}