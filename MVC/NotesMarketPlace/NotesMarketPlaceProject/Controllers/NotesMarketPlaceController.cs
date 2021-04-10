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

namespace NotesMarketPlaceProject.Controllers
{
    public class NotesMarketPlaceController : Controller
    {
        NotesMarketPlaceTablesEntities2 db = new NotesMarketPlaceTablesEntities2();        // GET: NotesMarketPlace
        
        public ActionResult HomePage()
        {
            return View();
        }
        //SignUp
        public ActionResult Signup()
        {
            return View();
        }
        //To check email already exist??
        public bool IsEmailExists(string eMail)
        {
            var IsCheck = db.Users.Where(x => x.EmailID == eMail).FirstOrDefault();
            return IsCheck != null;
        }

        [HttpPost]
        public ActionResult SignUp(RegisterUser Model)
        {
            var IsExist = IsEmailExists(Model.EmailID);
            if(IsExist)
            {
                ModelState.AddModelError("EmailExists", "Email Already Exists");
                return View("SignUp");
            }
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FirstName = Model.FirstName,
                    LastName = Model.LastName,
                    EmailID = Model.EmailID,
                    Password = Model.Password,
                    RoleID = 6,
                    IsEmailVerified = false,
                    CreatedDate = DateTime.Now,
                    IsActive=true
                };

                db.Users.Add(user);
                db.SaveChanges();
                TempData["Referrer"] = "SaveRegister";


                var SenderEMail = new MailAddress("aaabhavsar022@gmail.com", Model.FirstName);
                var receiverEmail = new MailAddress(Model.EmailID);
                var SenderPassword = "Shreya@3103";
                var body = string.Empty;
                var subject = "Notes-MarketPlace EMail Verification";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(SenderEMail.Address, SenderPassword);

                using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailTemplate/SendMail.html")))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("EmailID", user.EmailID);
                body = body.Replace("FirstName", user.FirstName); ;
                MailMessage mailMessage = new MailMessage(SenderEMail, receiverEmail);
                mailMessage.Body = body;
                mailMessage.Subject = subject;
                mailMessage.IsBodyHtml = true;
                smtp.Send(mailMessage);

            }

            ModelState.Clear();
            return View("Signup");
        }


        public ActionResult EmailVerify(string email)
        {
            var v = db.Users.Where(x => x.EmailID == email).FirstOrDefault();
            if (v.IsEmailVerified == false)
            {
                v.IsEmailVerified = true;
                db.SaveChanges();
                return RedirectToAction("Login", "NotesMarketPlace");
            }
            else
            {
                return RedirectToAction("Login", "NotesMarketPlace");
            }
        }
        public ActionResult Login()
        {
            //Session is used to store the Unique value

            return View();
        }

        [HttpPost]

        public ActionResult Login(UserLogin Model)
        {
            
            if (ModelState.IsValid)
            {
                var r = getemail(Model.EmailID);
                if (r == null)
                {
                    ModelState.AddModelError("EmailID","InValid Email,Please Enter correct Email ID");
                    return View();
                }
                else
                {
                    var loginSession = db.Users.Where(x => x.EmailID == Model.EmailID).FirstOrDefault();
                    Session["ID"] = loginSession.ID.ToString();

                    int check = Convert.ToInt32(Session["ID"]);
                    var exits = db.UserProfiles.Where(x => x.UserID == check).FirstOrDefault();

                    var checkinusertbl = db.Users.Where(x => x.ID == check).FirstOrDefault();
                    if (checkinusertbl.RoleID == 7 && Session["ID"] != null)
                    {
                        return RedirectToAction("Dashboard", "Admin");
                    }
                    if (r.EmailID == Model.EmailID && r.Password == Model.Password)
                    {
                        if (exits != null)
                        {
                            return RedirectToAction("SearchNotes");
                        }
                        else
                        {
                            return RedirectToAction("UserProfile");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("EmailID", "Emailid or Password not found or not matched");
                    }
                }

            }
            //return RedirectToAction("UserProfile");
            return View();
        }

        [HttpPost]
        public User getemail(string emailid)
        {
            var res = db.Users.Where(x => x.EmailID == emailid).ToList();
            if (res != null && res.Count > 0)
            {
                return (User)res[0];
            }
            else
            {
                return null;
            }
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(RegisterUser Model)
        {
            bool emailexist = false;
            var IsExist = IsEmailExists(Model.EmailID);
            var user = db.Users.Where(x => x.EmailID == Model.EmailID).FirstOrDefault();
            if(user==null)
            {
                ModelState.AddModelError("EmailID", "Please enter registered Email ID");
            }
            if (IsExist)
            {
                emailexist = true;
            }
            string strNewPassword = null;
            if (emailexist == true)
            {
                strNewPassword = GeneratePassword().ToString();
                var SenderEMail = new MailAddress("aaabhavsar022@gmail.com");
                var receiverEmail = new MailAddress(Model.EmailID);
                var SenderPassword = "Shreya@3103";
                var subject = "New Temporary Password has been created for you";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(SenderEMail.Address, SenderPassword);

                MailMessage mailMessage = new MailMessage(SenderEMail.Address, receiverEmail.Address);
                mailMessage.Subject = subject;
                mailMessage.Body = "<br/>Hello  "+user.FirstName +"," + "<br/></br>We have generated password for you" + "<br/>" + strNewPassword + "<br/>" + "Regards, <br/> Notes MarketPlace.";

                mailMessage.IsBodyHtml = true;
                smtp.Send(mailMessage);

                //Added
                user.Password = strNewPassword;
                user.ModifiedDate = DateTime.Now;
                db.SaveChanges();

                TempData["forgotpwd"] = "Displaymsg";
                return RedirectToAction("Login", "NotesMarketPlace");
            }
            return View();
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
        public ActionResult Changepassword()
        {
            return View("Changepassword");
        }
        [HttpPost]
        public ActionResult Changepassword(ChangepasswordModel model)
        {
            string modelpwd = model.OldPassword;
            var temp = db.Users.Where(x => x.Password.Equals(modelpwd)).FirstOrDefault();
            if (temp != null)
            {
                temp.Password = model.ConfirmPassword;
                temp.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                //Message will be display when password has been changed successfully
                TempData["changepwd"] = "Displaypwdchange";
                return RedirectToAction("Login", "NotesMarketPlace");
            }
            else
            {
                //OldPassword through message will be passedif password do not match with the database.
                ModelState.AddModelError("OldPassword", "Password not found or matched");
                return View(model);
            }

        }
        public ActionResult UserProfile()
        {

            List<Country> countryobj = db.Countries.ToList();
            ViewBag.countryobj = new SelectList(countryobj, "CountryName", "CountryName");

            List<Country> countryobj1 = db.Countries.ToList();
            ViewBag.countryobj1 = new SelectList(countryobj1, "CountryCode", "CountryCode");

            List<ReferenceData> refdataobj = db.ReferenceDatas.Where(x => x.RefCategory == "Gender").ToList();
            ViewBag.refdataobj = new SelectList(refdataobj, "ID", "Value");

            //Result variable is used to use session variable
            var result = Convert.ToInt32(Session["ID"]);
            var exists = db.Users.Where(a => a.ID == result).FirstOrDefault();

            if (Session["ID"] != null)
            {
                UserProfileModel model = new UserProfileModel
                {
                    FirstName = exists.FirstName,
                    LastName = exists.LastName,
                    EmailID = exists.EmailID

                };
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "NotesMarketPlace");
            }
        }

        [HttpPost]
        public ActionResult UserProfile(UserProfileModel model, HttpPostedFileBase upload)
        {
            string name = null;
            string ex = null;
            if (upload != null)
            {
                ex = Path.GetExtension(upload.FileName);
                name= "DP_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ex;
                string path = Path.Combine(Server.MapPath("~/Uploadprofileimg"), name);
                upload.SaveAs(path);
                
            }

            List<Country> countryobj = db.Countries.ToList();
            ViewBag.countryobj = new SelectList(countryobj, "CountryName", "CountryName");

            List<Country> countryobj1 = db.Countries.ToList();
            ViewBag.countryobj1 = new SelectList(countryobj1, "CountryCode", "CountryCode");

            //List<ReferenceData> refdataobj = db.ReferenceDatas.ToList();
            List<ReferenceData> refdataobj = db.ReferenceDatas.Where(x => x.RefCategory == "Gender").ToList();
            //ViewBag.refdataobj = new SelectList(refdataobj.Where(x=>x.RefCategory=="Gender"), "RefCategory", "Value");
            ViewBag.refdataobj = new SelectList(refdataobj, "ID", "Value");
            var result = Convert.ToInt32(Session["ID"]);

            if (ModelState.IsValid)
            {
                var userprofile = new UserProfile
                {
                    UserID = result,
                    DOB = Convert.ToDateTime(model.DOB),
                    Gender = model.Gender,
                    PhoneNumberCountryCOde = model.PhoneNumberCountryCOde,
                    PhoneNumber = model.PhoneNumber,
                    ProfilePicture = name,
                    AddressLine1 = model.AddressLine1,
                    AddressLine2 = model.AddressLine2,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode,
                    Country = model.Country,
                    University = model.University,
                    College = model.College,
                    CreatedDate=DateTime.Now
                };

                db.UserProfiles.Add(userprofile);
                db.SaveChanges();
            }
            return RedirectToAction("UserAddNotes", "NotesMarketPlace");
        }

        public ActionResult EditProfile()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login");
            }
            List<Country> countryobj = db.Countries.ToList();
            ViewBag.countryobj = new SelectList(countryobj, "CountryName", "CountryName");

            List<Country> countryobj1 = db.Countries.ToList();
            ViewBag.countryobj1 = new SelectList(countryobj1, "CountryCode", "CountryCode");

            List<ReferenceData> refdataobj = db.ReferenceDatas.Where(x => x.RefCategory == "Gender").ToList();
            ViewBag.refdataobj = new SelectList(refdataobj, "ID", "Value");

            var result = Convert.ToInt32(Session["ID"]);
            var check = db.Users.Where(a => a.ID == result).FirstOrDefault();
            var exists = db.UserProfiles.Where(a => a.UserID == result).FirstOrDefault();

            UserProfileModel model = new UserProfileModel()
            {
                FirstName=check.FirstName,
                LastName=check.LastName,
                DOB = (DateTime)exists.DOB,
                Gender = (int)exists.Gender,
                EmailID = check.EmailID,
                PhoneNumberCountryCOde = exists.PhoneNumberCountryCOde,
                PhoneNumber = exists.PhoneNumber,
                ProfilePicture = exists.ProfilePicture,
                AddressLine1=exists.AddressLine1,
                AddressLine2=exists.AddressLine2,
                State=exists.State,
                City=exists.City,
                University=exists.University,
                College=exists.College,
                Country=exists.Country,
                ZipCode=exists.ZipCode
                
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditProfile(UserProfileModel model, HttpPostedFileBase upload)
        {
            var result = Convert.ToInt32(Session["ID"]);
            var check = db.Users.Where(a => a.ID == result).FirstOrDefault();
            var exists = db.UserProfiles.Where(a => a.UserID == result).FirstOrDefault();

            string userprofile = null;
            string userprofilepath = null;

            string name = null;
            string ex = null;

            if (upload!=null)
            {
                ex = Path.GetExtension(upload.FileName);
                name = "DP_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ex;
                
                if(name!=exists.ProfilePicture)
                {
                    userprofilepath= Path.Combine(Server.MapPath("~/Uploadprofileimg"), name);
                    upload.SaveAs(userprofilepath);
                    exists.ProfilePicture = userprofile;
                }
            }

            //saving other data
            check.FirstName = model.FirstName;
            check.LastName = model.LastName;
            exists.DOB = model.DOB;
            exists.Gender = model.Gender;
            exists.PhoneNumberCountryCOde = model.PhoneNumberCountryCOde;
            exists.PhoneNumber = model.PhoneNumber;
            exists.AddressLine1 = model.AddressLine1;
            exists.AddressLine2 = model.AddressLine2;
            exists.State = model.State;
            exists.City = model.City;
            exists.University = model.University;
            exists.College = model.College;
            exists.Country = model.Country;
            exists.ZipCode = model.ZipCode;
            exists.ModifiedDate = DateTime.Now;
            exists.ModifiedBy = check.ID;
            db.SaveChanges();
            return RedirectToAction("EditProfile");
        }
        public ActionResult UserAddNotes()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login");
            }
            AddEditNotes model = new AddEditNotes
            {
                types = GetNoteTypes(),
                categories = GetNoteCategories(),
                countries = GetCountryList(),
            };

            return View(model);
        }
        [HttpPost]
        //upload_image = display picture image
        //upload_image1 = preview image
        public ActionResult UserAddNotes(AddEditNotes model, HttpPostedFileBase upload_image, HttpPostedFileBase upload_image1, HttpPostedFileBase upload_notes)
        {
            
            //The session which we have created during login is converted into an int and assigned to sellerid
            int sellerid = Convert.ToInt32(Session["ID"]);
            string filename = null;
            string path = null;

            string preview_img = null;
            string preview_path = null;

            string notes_pdf = null;
            string notes_pdf_path = null;
            string upload_note_name = null;

            string dp_ex=null;;
            string un_ex = null;
            string pi_ex = null;

            //Store Display picture in database
            if (upload_image != null)
            {
                //filename = Path.GetFileNameWithoutExtension(upload_image.FileName);
                dp_ex = Path.GetExtension(upload_image.FileName);
                filename = "DP_" + DateTime.Now.ToString("yyyyMMddHHmmss") + dp_ex;
                path = Path.Combine(Server.MapPath("~/Uploadimg"), filename);
                upload_image.SaveAs(path);
                //name = Path.GetFileName(filename);
            }

            //Store preview picture in database
            if (upload_image1 != null)
            {
                pi_ex = Path.GetExtension(upload_image1.FileName);
                preview_img = "DP_" + DateTime.Now.ToString("yyyyMMddHHmmss")+pi_ex;
                preview_path = Path.Combine(Server.MapPath("~/Uploadimg"), preview_img);
                upload_image1.SaveAs(preview_path);
                //preview_img_name = Path.GetFileName(preview_img);
            }

            //Store Notes(pdf_form) in database
            if (upload_notes != null)
            {
                un_ex = Path.GetExtension(upload_notes.FileName);
                notes_pdf = "DP_" + DateTime.Now.ToString("yyyyMMddHHmmss") + un_ex;
                notes_pdf_path = Path.Combine(Server.MapPath("~/Uploadimg"), notes_pdf);
                upload_notes.SaveAs(notes_pdf_path);
                upload_note_name = Path.GetFileName(notes_pdf);
                ////foreach(HttpPostedFileBase file in upload_notes)
                ////{
                ////    //string strpath = "~/Members/" +sellerid+"/"+ noteid +"/Attachments/";
                ////    string strpath = "~/Members/" + sellerid  + "/Attachments/";
                ////    un_ex = Path.GetExtension(file.FileName);
                ////    notes_pdf = "DP_" + DateTime.Now.ToString("yyyyMMddHHmmss") + un_ex;
                ////    notes_pdf_path= Path.Combine(Server.MapPath(strpath), notes_pdf);
                ////    file.SaveAs(notes_pdf_path);
                ////}
            }

            try
            {
                if (ModelState.IsValid)
                {
                    var sellernote = new SellerNote
                    {
                        SellerID = sellerid,
                        Title = model.Title,
                        Category = model.CategoryID,
                        NoteType = model.TypeID,
                        Status = 6,
                        DisplayPicture = filename,
                        NumberOfPages = model.NumberOfPages,
                        Description = model.Description,
                        UniversityName = model.UniversityName,
                        Country = model.CountryID,
                        Course = model.Course,
                        CourseCode = model.CourseCode,
                        Professor = model.Professor,
                        IsPaid = model.IsPaid,
                        SellingPrice = model.SellingPrice,
                        CreatedDate = DateTime.Now,
                        NotesPreview = preview_img,
                        IsActive=true
                    };
                    db.SellerNotes.Add(sellernote);
                    var sellernotesattachments = new SellerNotesAttachment
                    {
                        NoteID=sellernote.ID,
                        FileName = notes_pdf,
                        FilePath = notes_pdf_path,
                        CreatedDate = DateTime.Now,
                        CreatedBy=sellerid,
                        IsActive=true
                    };
                    db.SellerNotesAttachments.Add(sellernotesattachments);
                    db.SaveChanges();
                    //return RedirectToAction("Login", "NotesMarketPlace");
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;

            }
            AddEditNotes obj = new AddEditNotes {
                types = GetNoteTypes(),
                categories = GetNoteCategories(),
                countries = GetCountryList(),
                Title = model.Title,
                CategoryID = model.CategoryID,
                TypeID = model.TypeID,
                DisplayPicture = filename,
                NumberOfPages = model.NumberOfPages,
                Description = model.Description,
                UniversityName = model.UniversityName,
                CountryID = model.CountryID,
                Course = model.Course,
                CourseCode = model.CourseCode,
                Professor = model.Professor,
                IsPaid = model.IsPaid,
                SellingPrice = model.SellingPrice,
                NotesPreview = preview_img,
                FileName = notes_pdf
            };
            TempData["displaypublish"] = "Displaymsg";
            return View(obj);
            //return RedirectToAction("UserAddNotes", "NotesMarketPlace");
        }
        public ActionResult DashboardEditNote(int id)
        {
            //exits var for sellernote id,check for sellernote attachment
            var exits = db.SellerNotes.Where(x => x.ID == id).FirstOrDefault();
            var check = db.SellerNotesAttachments.Where(x => x.NoteID == id).FirstOrDefault();
            if (exits != null && check != null)
            {
                AddEditNotes model = new AddEditNotes
                {
                    types = GetNoteTypes(),
                    categories = GetNoteCategories(),
                    countries = GetCountryList(),
                    Title = exits.Title,
                    CategoryID = exits.Category,
                    TypeID = (int)exits.NoteType,
                    DisplayPicture = exits.DisplayPicture,
                    NumberOfPages = (int)exits.NumberOfPages,
                    Description = exits.Description,
                    UniversityName = exits.UniversityName,
                    CountryID = (int)exits.Country,
                    Course = exits.Course,
                    CourseCode = exits.CourseCode,
                    Professor = exits.Professor,
                    IsPaid = exits.IsPaid,
                    SellingPrice = (decimal)exits.SellingPrice,
                    NotesPreview = exits.NotesPreview,
                    FileName = check.FileName,
                    FilePath = check.FilePath,
                };
                return View(model);
            }
            
            else
            {
                return RedirectToAction("Dashboard");
            }
        }

        //Httppost method to update notes from dashboard
        [HttpPost]
        public ActionResult DashboardEditNote(int id,AddEditNotes model, HttpPostedFileBase upload_image, HttpPostedFileBase upload_image1, HttpPostedFileBase upload_notes)
        {
            var exists = db.SellerNotes.Where(x => x.ID == id).FirstOrDefault();
            var check = db.SellerNotesAttachments.Where(x => x.NoteID == id).FirstOrDefault();

            //Display picture
            string displaypicture = null;
            string displaypicturepath = null;
            if (upload_image != null)
            {
                displaypicture = Path.GetFileName(upload_image.FileName);
                //Check display picture already exits or not,if not then strore it in folder
                if (displaypicture != exists.DisplayPicture)
                {
                    displaypicturepath = Path.Combine(Server.MapPath("~/Uploadimg"), displaypicture);
                    upload_image.SaveAs(displaypicturepath);
                    exists.DisplayPicture = displaypicture;
                }
            }

            //Upload notes
            string uploadnotes = null;
            string uploadnotespath = null;
            if (upload_notes != null)
            {
                uploadnotes = Path.GetFileName(upload_notes.FileName);
                //Check in sellernotes Attachment
                if (uploadnotes != check.FileName)
                {
                    uploadnotespath = Path.Combine(Server.MapPath("~/Uploadimg"), uploadnotes);
                    upload_notes.SaveAs(uploadnotespath);
                    check.FileName = uploadnotes;
                    check.FilePath = uploadnotespath;
                }
            }

            //Preview pdf
            string previewpdf = null;
            string previewpdfpath = null;
            if (upload_image1 != null)
            {
                previewpdf = Path.GetFileName(upload_image1.FileName);
                //Check for preview in sellernote
                if (previewpdf != exists.NotesPreview)
                {
                    previewpdfpath = Path.Combine(Server.MapPath("~/Uploadimg"), previewpdf);
                    upload_image1.SaveAs(previewpdfpath);
                    exists.NotesPreview = previewpdf;
                }
            }


            //Updating data of sellernote
            exists.Title = model.Title;
            exists.Category = model.CategoryID;
            exists.NoteType = model.TypeID;
            exists.NumberOfPages = model.NumberOfPages;
            exists.Description = model.Description;
            exists.UniversityName = model.UniversityName;
            exists.Country = model.CountryID;
            exists.Course = model.Course;
            exists.CourseCode = model.CourseCode;
            exists.Professor= model.Professor;
            exists.IsPaid = model.IsPaid;
            exists.SellingPrice = model.SellingPrice;
            exists.ModifiedDate = DateTime.Now;
            exists.ModifiedBy = exists.SellerID;
            db.SaveChanges();
            return RedirectToAction("DashboardEditNote");
        }
        //function for notetypes dropdown
        public List<NoteType> GetNoteTypes()
        {
            List<NoteType> noteTypes = db.NoteTypes.ToList();
            return noteTypes;

        }
        //public IEnumerable<SearchNoteViewmodel> GetUnivercityName()
        //{
        //    IEnumerable<SearchNoteViewmodel> obj = se
        //    return obj;
        //}

        //function for notecategories
        public List<NoteCategory> GetNoteCategories()
        {
            List<NoteCategory> noteCategories = db.NoteCategories.ToList();
            return noteCategories;
        }

        //function for country dropdown
        public List<Country> GetCountryList()
        {
            List<Country> countries = db.Countries.ToList();
            return countries;
        }

        public IEnumerable<SearchNoteViewmodel> GetTitles()
        {
            //List<SellerNote> obj = db.SellerNotes.ToList();
            //return obj;
            return (from note in db.SellerNotes
                    where note.Status == 9 
                    select new SearchNoteViewmodel
                    {
                        ID = note.ID,
                        Title = note.Title,
                        DisplayPicture = note.DisplayPicture,
                        CreatedDate = note.CreatedDate,
                        NumberOfPages = note.NumberOfPages,
                        UniversityName = note.UniversityName,
                        Course = note.Course
                    }
                    ).ToList();
        }

        public List<ReferenceData> GetStatus()
        {
            List<ReferenceData> obj = db.ReferenceDatas.ToList();
            return obj;
        }
        public List<User> GetUserID()
        {
            List<User> obj = db.Users.ToList();
            return obj;
        }

        public ActionResult Publishnote()
        {
            var max = db.SellerNotes.OrderByDescending(x => x.ID).FirstOrDefault();
            var sellernote = db.SellerNotes.Where(x => x.ID == max.ID).FirstOrDefault();
            var sellername = db.Users.Where(x => x.ID == sellernote.SellerID).FirstOrDefault();
            var supportemail = db.SystemConfigurations.Where(x => x.ID == 1).FirstOrDefault();
            sellernote.Status = 7;
            db.SaveChanges();

            var SenderEMail = new MailAddress("aaabhavsar022@gmail.com");
            var receiverEmail = new MailAddress(supportemail.Value);
            var SenderPassword = "Shreya@3103";
            var subject = sellername.FirstName + "sent note for review";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(SenderEMail.Address, SenderPassword);

            MailMessage mailMessage = new MailMessage(SenderEMail.Address, receiverEmail.Address);
            mailMessage.Subject = subject;
            mailMessage.Body = "<br/><br/><br/>Hello Admins We want to inform you that, " + sellername.FirstName + " sent his note " + sellernote.Title + "For Review  Please look at the notes and take required actions." + "<br/><br/> Regards, Notes MarketPlace.";

            mailMessage.IsBodyHtml = true;
            smtp.Send(mailMessage);
            return RedirectToAction("DashBoard", "NotesMarketPlace");
        }

        public ActionResult Dashboard()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login");
            }
            var tempvar = Convert.ToInt32(Session["ID"]);
            //titlelist for In Progress notes,titlelist1 for published notes
            List<SellerNote> titlelist = db.SellerNotes.Where(x=>x.Status==6 || x.Status==7 || x.Status==8).ToList();
            List<SellerNote> titlelist1 = db.SellerNotes.Where(x=>x.Status==9 && x.SellerID==tempvar).ToList();
            List<NoteCategory> categorylist = db.NoteCategories.ToList();
            List<ReferenceData> statuslist = db.ReferenceDatas.ToList();

            var inprogressnotes = from c in categorylist
                                  join t in titlelist.Where(x=>x.SellerID==tempvar) on c.CategoryID equals t.Category into table1
                                  from t in table1
                                  join r in statuslist on t.Status equals r.ID into table2
                                  from r in table2
                                  select new GetSellerNotesData { titlelist = t, categorylist = c, statuslist = r };

            var publishednotes = from c in categorylist
                                 join t in titlelist1 on c.CategoryID equals t.Category
                                 select new GetSellerNotesData { titlelist1 = t, categorylist = c };

            //var publishenotes
            DashboardViewModel model = new DashboardViewModel
            {
                inprogress = inprogressnotes,
                published = publishednotes
            };

            //query to count number of sold notes
            List<User> usertbl = db.Users.ToList();
            List<Download> downloadtbl = db.Downloads.Where(x => x.Seller == tempvar && (x.IsAttachmentDownloaded == true) && (x.Seller != x.Downloader)).ToList();
            var soldnotes = from u in usertbl
                            join d in downloadtbl on u.ID equals d.Downloader into table1
                            from d in table1
                            select new SoldNotesModel { usertbl = u, downloadtbl = d };

            ViewBag.countsoldnote = soldnotes.Count();

            //Query to count number of download notes
            List<User> usertbl1 = db.Users.ToList();
            List<Download> downloadtbl1 = db.Downloads.Where(x => x.Downloader == tempvar && (x.IsSellerHasAllowedDownload == true)).ToList();
            var mydownloadnotes1 = from u in usertbl1
                                  join d in downloadtbl1 on u.ID equals d.Downloader into table1
                                  from d in table1
                                  select new DownloadnNotesModel { usertbl = u, downloadtbl = d };

            ViewBag.countdownloadnotes = mydownloadnotes1.Count();

            //Query to count number of rejected notes
            List<SellerNote> sellernote2 = db.SellerNotes.Where(x => x.SellerID == tempvar && x.Status == 10).ToList();
            List<NoteCategory> notecattbl2 = db.NoteCategories.ToList();

            var rejectednotes = from n in notecattbl2
                                join s in sellernote2 on n.CategoryID equals s.Category into table1
                                from s in table1
                                select new RejectedNotes { notecattbl = n, sellernote = s };

            ViewBag.countrejectednotes = rejectednotes.Count();

            //foreach (User u in userobj)
            //{
            //    List<Download> earning = db.Downloads.Where(x => x.Seller == u.ID && x.IsAttachmentDownloaded == true && x.IsSellerHasAllowedDownload == true && x.IsPaid == true).ToList();
            //    var sum = earning.Sum(x => x.PurchasedPrice);
            //    string totalearning = Convert.ToString(u.ID);
            //    TempData[totalearning + "5"] = sum;
            //}
            List<Download> earning = db.Downloads.Where(x => x.Seller == tempvar && x.IsAttachmentDownloaded == true && x.IsSellerHasAllowedDownload == true).ToList();
            var sum = earning.Sum(x => x.PurchasedPrice);
            ViewBag.totalearning = sum;

            //Query to count number of Buyer Requests
            List<User> usertbl3 = db.Users.ToList();
            List<Download> downloadtbl3 = db.Downloads.Where(x => x.Seller == tempvar && (x.IsSellerHasAllowedDownload == false)).ToList();
            List<UserProfile> userprofiletbl3 = db.UserProfiles.ToList();

            var buyerrequest = from d in downloadtbl3
                               join u in usertbl3 on d.Downloader equals u.ID into table1
                               from u in table1
                               join up in userprofiletbl3 on u.ID equals up.UserID into table2
                               from up in table2
                               select new BuyerRequest { downloadtbl = d, usertbl = u, userprofiletbl = up };

            ViewBag.countbuyerrequest = buyerrequest.Count();
            return View(model);
        }

        //deletenotes (dashboard view)
        public ActionResult DeleteNotes(int id)
        {
            SellerNote obj = db.SellerNotes.Find(id);
            var attachment = db.SellerNotesAttachments.Where(x => x.NoteID == id).FirstOrDefault();
            SellerNotesAttachment obj1 = db.SellerNotesAttachments.Find(attachment.ID);
            
            db.SellerNotesAttachments.Remove(obj1);
            db.SellerNotes.Remove(obj);
            db.SaveChanges();
       
            return RedirectToAction("Dashboard");
        }
        public ActionResult SearchNotes()
        {
            ViewBag.Sessioncheck = Session["ID"];
            List<SellerNote> univercityname = db.SellerNotes.GroupBy(x=>x.UniversityName).Select(x=>x.FirstOrDefault()).Where(x=>x.UniversityName!=null).ToList();
            ViewBag.countryobj = new SelectList(univercityname, "UniversityName", "UniversityName");

            List<SellerNote> coursename = db.SellerNotes.GroupBy(x => x.Course).Select(x => x.FirstOrDefault()).Where(x => x.Course != null).ToList();
            ViewBag.courseobj = new SelectList(coursename, "Course", "Course");

            List<SellerNotesReview> reviews = db.SellerNotesReviews.GroupBy(x => x.Ratings).Select(x => x.FirstOrDefault()).ToList();
            ViewBag.reviewobj = new SelectList(reviews, "Ratings", "Ratings");

            SearchNotesnewViewModel Model = new SearchNotesnewViewModel
            {
                types1 = GetNoteTypes(),
                categories1 = GetNoteCategories(),
                univercities1 = GetTitles().Where(x => x.UniversityName != null),
                courses1 = GetTitles(),
                countries1= GetCountryList(),
            };

            foreach(var note in Model.courses1)
            {
                note.avg = GetAvgRating(note.ID);
                note.RateCount = GetRatingCount(note.ID);
                note.ReportCount = GetReportCount(note.ID);
            }

            ViewBag.CountBooks = GetTitles().Count();

            return View(Model);
        }
        public int GetRatingCount(int id)
        {
            return db.SellerNotesReviews.Where(n => n.NoteID == id).Count();

        }
        public int GetReportCount(int id)
        {
            return db.SellerNotesReportedIssues.Where(n => n.NoteID == id).Count();
        }
        public decimal GetAvgRating(int id)
        {
            List<SellerNotesReview> a = db.SellerNotesReviews.Where(n => n.NoteID == id).ToList();
            if (a.Count() != 0)
            {
                var sum = a.Sum(n => n.Ratings);
                var count = a.Count();
                return (sum / count);
            }
            else
            {
                return 0;
            }
        }
        [HttpPost]
        public ActionResult FilterNotes(int FK_Type=0,string FK_Course=null,int FK_Country=0,string FK_University=null,int FK_Category=0,string FK_Searchdata=null,decimal FK_Ratings=0, string pageNumber = "1",string pageSize = "5")
        {
            ///*List<SellerNote> obj = new List<SellerNote>();*/
            if (string.IsNullOrEmpty(FK_University))
                FK_University = null;
            if (string.IsNullOrEmpty(FK_Course))
                FK_Course = null;
            if (string.IsNullOrEmpty(FK_Searchdata))
                FK_Searchdata = null;
            
            SearchNotesnewViewModel Model = new SearchNotesnewViewModel();
            Model.PageSize = "9";
            Model.PageNumber = pageNumber;

            int PageNumber = Convert.ToInt32(pageNumber);
            int PageSize = 9; /*Convert.ToInt32(PageSize);*/
            List<NewGetSellerNotesDetails_Result> getData = db.NewGetSellerNotesDetails(FK_Type, FK_Category, FK_Country, FK_University, FK_Course, FK_Ratings, PageSize, PageNumber, FK_Searchdata).ToList();
            
            Model.newGetSellerNotesDetails_Results = getData;

            foreach(var data in getData)
            {
                Model.TotalRecords = (int)data.TotalCount;
            }

            return PartialView("_SearchNote",Model);
        }

        public ActionResult BuyerRequest()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login");
            }
            var tempvar = Convert.ToInt32(Session["ID"]);
            List<User> usertbl = db.Users.ToList();
            List<Download> downloadtbl = db.Downloads.Where(x=>x.Seller==tempvar && (x.IsSellerHasAllowedDownload==false)).ToList();
            List<UserProfile> userprofiletbl = db.UserProfiles.ToList();
            
            var buyerrequest = from d in downloadtbl
                               join u in usertbl on d.Downloader equals u.ID into table1
                               from u in table1
                               join up in userprofiletbl on u.ID equals up.UserID into table2
                               from up in table2
                               select new BuyerRequest { downloadtbl = d, usertbl = u, userprofiletbl = up };

            return View(buyerrequest);
        }
        public  ActionResult RejectedNotes()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login");
            }
            var tempvar = Convert.ToInt32(Session["ID"]);
              
            List<SellerNote> sellernote = db.SellerNotes.Where(x=>x.SellerID == tempvar && x.Status==10).ToList();
            List<NoteCategory> notecattbl = db.NoteCategories.ToList();

            var rejectednotes = from n in notecattbl
                                join s in sellernote on n.CategoryID equals s.Category into table1
                                from s in table1
                                select new RejectedNotes { notecattbl = n, sellernote = s };

            return View(rejectednotes);
        }
        public ActionResult Updatedownloadtbl(int id)
        {
            var result = Convert.ToInt32(Session["ID"]);
            var updatevar = db.Downloads.Where(x => x.ID == id).FirstOrDefault();
            var checkinsellernoteattachment = db.SellerNotesAttachments.Where(x => x.NoteID == updatevar.NoteID).FirstOrDefault();
            updatevar.IsSellerHasAllowedDownload = true;
            updatevar.AttachmentPath = checkinsellernoteattachment.FilePath;
            updatevar.ModifiedBy = result;
            db.SaveChanges();
            
            //to get the buyer id
            var buyerid = db.Users.Where(x => x.ID == updatevar.Downloader).FirstOrDefault();
            //to get the seller id
            var sellerid = db.Users.Where(x => x.ID == updatevar.Seller).FirstOrDefault();

            var SenderEMail = new MailAddress("aaabhavsar022@gmail.com");
            var receiverEmail = new MailAddress(buyerid.EmailID);
            var SenderPassword = "Shreya@3103";
            var subject = sellerid.FirstName + "Allows you to download a note";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(SenderEMail.Address, SenderPassword);

            MailMessage mailMessage = new MailMessage(SenderEMail.Address, receiverEmail.Address);
            mailMessage.Subject = subject;
            mailMessage.Body = "<br/><br/><br/>Hello, " + buyerid.FirstName + "<br/><br/>We would like to inform you that, " + sellerid.FirstName + "Allows you to downoload a note." +"<br/><br/>Please Login and see My Download tabs to download particular note."+ "<br/><br/> Regards, Notes MarketPlace.";

            mailMessage.IsBodyHtml = true;
            smtp.Send(mailMessage);

            return RedirectToAction("BuyerRequest");
        }
        //This is for downloadnotes view
        public ActionResult DownloadNotes()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login");
            }
            var tempvar = Convert.ToInt32(Session["ID"]);
            List<User> usertbl = db.Users.ToList();
            List<Download> downloadtbl = db.Downloads.Where(x=>x.Downloader==tempvar && (x.IsSellerHasAllowedDownload==true)).ToList();
            var mydownloadnotes = from u in usertbl
                                join d in downloadtbl on u.ID equals d.Downloader into table1
                                from d in table1
                                select new DownloadnNotesModel { usertbl=u,downloadtbl=d};
            DownloadViewModel obj = new DownloadViewModel
            {
                downloadnNotes = mydownloadnotes
            };
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddReview(int id)
        {
            //if (Convert.ToString(model.Ratings)==String.Empty)
            //{
            //    ModelState.AddModelError("Ratings", "Please Enter Ratings");
            //}
            //if (model.Comments == null)
            //{
            //    ModelState.AddModelError("Comments", "Please Enter Your Comments");
            //}
            var ratings = Convert.ToDecimal(Request.Form["rating"]);
            var comment = Request.Form["comments"];

            var exists = db.Downloads.Where(x => x.ID == id).FirstOrDefault();
            
            //if (ModelState.IsValid)
            //{
                var obj = new SellerNotesReview
                {
                    NoteID = exists.NoteID,
                    ReviewedByID = exists.Downloader,
                    AgainstDownloadsID = exists.ID,
                    Ratings = ratings,
                    Comments = comment,
                    CreatedDate = DateTime.Now,
                    CreatedBy = exists.Downloader,
                    IsActive=true
                };
                db.SellerNotesReviews.Add(obj);
                db.SaveChanges();
            ////}
            
            return RedirectToAction("DownloadNotes");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReportIssue(int id,DownloadViewModel model)
        {

            var exists = db.Downloads.Where(x => x.ID == id).FirstOrDefault();
            var downloader = db.Users.Where(x => x.ID == exists.Downloader).FirstOrDefault();
            var seller = db.Users.Where(x => x.ID == exists.Seller).FirstOrDefault();
            var supportemail = db.SystemConfigurations.Where(x => x.ID == 1).FirstOrDefault();
            var remarks = Request.Form["remark"];
            
                    var obj = new SellerNotesReportedIssue
                    {
                        NoteID=exists.NoteID,
                        ReportedByID=exists.Downloader,
                        AgainstDownloadID=exists.ID,
                        Remarks = remarks,
                        CreatedDate=DateTime.Now,
                        CreatedBy= exists.Downloader
                    };
                    db.SellerNotesReportedIssues.Add(obj);
                    db.SaveChanges();
            
            var SenderEMail = new MailAddress("aaabhavsar022@gmail.com");
            var receiverEmail = new MailAddress(supportemail.Value);
            var SenderPassword = "Shreya@3103";
            var subject = downloader.FirstName + " Reported an issue for " + exists.NoteTitle;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(SenderEMail.Address, SenderPassword);

            MailMessage mailMessage = new MailMessage(SenderEMail.Address, receiverEmail.Address);
            mailMessage.Subject = subject;
            mailMessage.Body = "<br/><br/><br/>Hello Admins We want to inform you that, " + downloader.FirstName + " Reported an issue for" +seller.FirstName+ "'s Note with" +exists.NoteTitle+" Please look at the notes and take required actions." + "<br/><br/> Regards, Notes MarketPlace.";

            mailMessage.IsBodyHtml = true;
            smtp.Send(mailMessage);

            return RedirectToAction("DownloadNotes");
        }
        public ActionResult SoldNotes()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login");
            }
            var tempvar = Convert.ToInt32(Session["ID"]);
            List<User> usertbl = db.Users.ToList();
            List<Download> downloadtbl = db.Downloads.Where(x => x.Seller == tempvar && (x.IsAttachmentDownloaded == true)  && (x.Seller != x.Downloader)).ToList();
            var soldnotes = from u in usertbl
                                join d in downloadtbl on u.ID equals d.Downloader into table1
                                from d in table1
                                select new SoldNotesModel { usertbl = u, downloadtbl = d };
            return View(soldnotes);
        }
        public ActionResult DownloadFromSoldNotes(int id)
        {
            var check = db.Downloads.Where(x => x.NoteID == id).FirstOrDefault();
            var getid = db.SellerNotesAttachments.Where(x => x.NoteID == check.NoteID).FirstOrDefault();

            string path = Server.MapPath("~/Uploadimg/") + getid.FileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            Download download = new Download
            {
                NoteID = check.NoteID,
                Seller = check.Seller,
                Downloader = check.Downloader,
                IsSellerHasAllowedDownload = true,
                AttachmentPath = check.AttachmentPath,
                IsAttachmentDownloaded = true,
                AttachmentDownloadedDate = DateTime.Now,
                IsPaid = check.IsPaid,
                PurchasedPrice = check.PurchasedPrice,
                NoteTitle = check.NoteTitle,
                NoteCategory = check.NoteCategory,
                CreatedDate = DateTime.Now,
                CreatedBy = check.CreatedBy,
                ModifiedDate = DateTime.Now,
                ModifiedBy = check.ModifiedBy
            };
            db.Downloads.Add(download);
            db.SaveChanges();
            return File(bytes, "application/octet-stream", getid.FileName);
        }

        //This method is called from Mydownload notes
        public ActionResult DownloadNotePdf(int id)
        {
            //Check that whether this note is paid or free
            var check = db.Downloads.Where(x => x.ID == id).FirstOrDefault();

            //getting noteid for getting filename from sellernotesattachments
            var getid = db.SellerNotesAttachments.Where(x => x.NoteID == check.NoteID).FirstOrDefault();

            string path = Server.MapPath("~/Uploadimg/") + getid.FileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //if free then insert into database
            if (check.IsPaid == false)
            {
                Download download = new Download
                {
                    NoteID = check.NoteID,
                    Seller = check.Seller,
                    Downloader = check.Downloader,
                    IsSellerHasAllowedDownload = true,
                    AttachmentPath = check.AttachmentPath,
                    IsAttachmentDownloaded = true,
                    AttachmentDownloadedDate = DateTime.Now,
                    IsPaid = false,
                    PurchasedPrice = null,
                    NoteTitle = check.NoteTitle,
                    NoteCategory = check.NoteCategory,
                    CreatedDate = DateTime.Now,
                    CreatedBy = check.CreatedBy,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = check.ModifiedBy
                };
                db.Downloads.Add(download);
                db.SaveChanges();

                return File(bytes, "application/octet-stream", getid.FileName);
            }
            //else update paid notes
            else
            {
                check.IsSellerHasAllowedDownload = true;
                check.AttachmentPath = path;
                check.IsAttachmentDownloaded = true;
                check.AttachmentDownloadedDate = DateTime.Now;
                db.SaveChanges();
                return File(bytes, "application/octet-stream", getid.FileName);
            }

        }

        //Contact us
        public ActionResult ContactUs()
        {
            var result = Convert.ToInt32(Session["ID"]);
            var exists = db.Users.Where(a => a.ID == result).FirstOrDefault();
            ViewBag.Sessioncheck=Session["ID"];
            if (Session["ID"] != null)
            {
                ContactUs model = new ContactUs
                {
                    FullName = exists.FirstName + " " + exists.LastName, 
                    EMailid = exists.EmailID
                };
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public ActionResult ContactUs(ContactUs Model)
        {
            if (ModelState.IsValid)
            {
                var SenderEMail = new MailAddress("aaabhavsar022@gmail.com");
                var receiverEmail = new MailAddress("shailyjbhavsar@gmail.com");
                var SenderPassword = "Shreya@3103";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                // smtp.Timeout = 100000;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(SenderEMail.Address, SenderPassword);

                MailMessage mailMessage = new MailMessage(SenderEMail, receiverEmail);
                mailMessage.Subject = Model.FullName;
                mailMessage.Body = "<br/>Hello " + "<br/>" + Model.Questions + "<br/>Regards," + "<br/>" + Model.FullName;


                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;

                smtp.Send(mailMessage);
            }
            ModelState.Clear();
            return View("ContactUs");
        }


        public ActionResult NoteDetails(int id)
        {
            ViewBag.Sessioncheck = Session["ID"];
            var temp = Convert.ToInt32(Session["ID"]);
            var buyername = db.Users.Where(x => x.ID == temp).FirstOrDefault();

            var exist = db.SellerNotes.Where(x => x.ID == id).FirstOrDefault();
            var sellername = db.Users.Where(x => x.ID == exist.SellerID).FirstOrDefault();

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
                                  where r.NoteID==id
                                  select new SearchNotes { userdata = u, reviewdata = r, userprofiledata = up };

            if (Session["ID"] != null)
            {
                ViewBag.BuyerName = buyername.FirstName;
            }
            ViewBag.SellerName = sellername.FirstName + " " + sellername.LastName;
            ViewBag.ReprtIssue = reportissuecount;//To display number of reported issues
            
            ViewBag.Numberofratings = ratingcount;//Display number of rating
            return View(note);
        }
        
        //download free notes
        public ActionResult DownloadPdf(int id)
        {
            //Get file
            var temp = db.SellerNotesAttachments.Where(x => x.NoteID == id).FirstOrDefault();
            string path = Server.MapPath("~/Uploadimg/") + temp.FileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            int downloaderid = Convert.ToInt32(Session["ID"]);
            var sellerid = db.SellerNotes.Where(x => x.ID == id).FirstOrDefault();
            var notecategoryid = db.NoteCategories.Where(x => x.CategoryID == sellerid.Category).FirstOrDefault();
            Download download = new Download
            {
                NoteID = id,
                Seller = sellerid.SellerID,
                Downloader = downloaderid,
                IsSellerHasAllowedDownload = true,
                AttachmentPath =path,
                IsAttachmentDownloaded = true,
                AttachmentDownloadedDate = DateTime.Now,
                IsPaid = false,
                PurchasedPrice=0,
                NoteTitle=sellerid.Title,
                NoteCategory=notecategoryid.CategoryName,
                CreatedDate=DateTime.Now,
                CreatedBy=downloaderid,
                ModifiedDate=DateTime.Now,
                ModifiedBy=downloaderid
            };
            db.Downloads.Add(download);
            db.SaveChanges();

            //Send the File to Download.
            return File(bytes, "application/octet-stream", temp.FileName);
        }

        //download paid pdf
        public ActionResult DownloadPaidPdf(int id)
        { 
            int downloaderid = Convert.ToInt32(Session["ID"]);
            var sellerid = db.SellerNotes.Where(x => x.ID == id).FirstOrDefault();
            var selleremailid = db.Users.Where(x => x.ID == sellerid.SellerID).FirstOrDefault();
            var buyername = db.Users.Where(x => x.ID == downloaderid).FirstOrDefault();
            var notecategoryid = db.NoteCategories.Where(x => x.CategoryID == sellerid.Category).FirstOrDefault();
            Download download = new Download
            {
                NoteID = id,
                Seller = sellerid.SellerID,
                Downloader = downloaderid,
                IsSellerHasAllowedDownload = false,
                AttachmentPath = null,
                IsAttachmentDownloaded = false,
                AttachmentDownloadedDate = DateTime.Now,
                IsPaid = true,
                PurchasedPrice = sellerid.SellingPrice,
                NoteTitle = sellerid.Title,
                NoteCategory = notecategoryid.CategoryName,
                CreatedDate = DateTime.Now,
                CreatedBy = downloaderid,
                ModifiedDate = DateTime.Now,
                ModifiedBy = downloaderid
            };
            db.Downloads.Add(download);
            db.SaveChanges();

            var SenderEMail = new MailAddress("aaabhavsar022@gmail.com");
            var receiverEmail = new MailAddress(selleremailid.EmailID);
            var SenderPassword = "Shreya@3103";
            var subject = buyername.FirstName + " Wants to purchase your notes";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(SenderEMail.Address, SenderPassword);

            MailMessage mailMessage = new MailMessage(SenderEMail.Address, receiverEmail.Address);
            mailMessage.Subject = subject;
            mailMessage.Body = "<br/><br/><br/>Hello, " +selleremailid.FirstName + "<br/><br/>We would like to inform you that, " +buyername.FirstName + " wants to purchase your notes. Please see buyer request tab and allow download access to Buyer if you have received the payment from him." + "<br/><br/> Regards, Notes MarketPlace.";

            mailMessage.IsBodyHtml = true;
            smtp.Send(mailMessage);

            return new EmptyResult();
        }

        public ActionResult FAQ()
        {
            return View();
        }
        public FileContentResult UserPhoto()
        {
            var tempvar = Convert.ToInt32(Session["ID"]);
            var exits = db.UserProfiles.Where(x => x.UserID == tempvar).FirstOrDefault();
            if (exits == null)
            {
                string profilephoto = "user-img.png";
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
                var userimg = db.UserProfiles.Where(x => x.UserID == tempvar).FirstOrDefault();
                //byte[] bytes = Encoding.ASCII.GetBytes(userimg.ProfilePicture);
                if (userimg.ProfilePicture != null)
                {
                    string fileName = HttpContext.Server.MapPath("~/Uploadprofileimg/" + userimg.ProfilePicture);
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
                    string profilephoto = "user-img.png";
                    string fileName = HttpContext.Server.MapPath("~/Uploadprofileimg/" + profilephoto);
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

        public ActionResult Logout()
        {
            Session["ID"] = null;
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}
