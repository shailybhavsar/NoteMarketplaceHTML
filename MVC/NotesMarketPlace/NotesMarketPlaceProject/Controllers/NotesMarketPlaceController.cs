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

namespace NotesMarketPlaceProject.Controllers
{
    public class NotesMarketPlaceController : Controller
    {
        NotesMarketPlaceTablesEntities db = new NotesMarketPlaceTablesEntities();        // GET: NotesMarketPlace

        //SignUp
        public ActionResult Signup()
        {
            return View();
        }
        public bool IsEmailExists(string eMail)
        {
            var IsCheck = db.Users.Where(x => x.EmailID == eMail).FirstOrDefault();
            return IsCheck != null;
        }

        [HttpPost]
        public ActionResult SignUp(RegisterUser Model)
        {
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
                    CreatedDate = DateTime.Now
                };

                db.Users.Add(user);
                db.SaveChanges();


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

                //body ="< table style = 'height:60%;width: 60%; position: absolute;margin-left:10%;font-family:Open Sans !important;background: white;border-radius: 3px;padding-left: 2%;padding-right: 2%;' >< thead >< th >< img src = 'https://i.ibb.co/HVyPwqM/top-logo1.png' alt = 'logo' style = 'margin-top: 5%; margin-left: 0px;' ></ th ></ thead >< tbody >< tr style = 'height: 60px;font-family: Open Sans;font-size: 26px;font-weight: 600;line-height: 30px;color: #6255a5;' >< td class='text-1'>Email Verification</td></tr><tr style = 'height: 40px;font-family: Open Sans;font-size: 18px;font-weight: 600;line-height: 22px;color: #333333;margin-bottom: 20px;' >< td class='text-2'>Dear ,"+Model.FirstName+ "</td></tr><tr style = 'height: 60px;' >< td class='text-3'>Thanks for Signing up! <br>Simply click below for email verification.</td></tr> <tr style = 'height: 120px;font-size: 16px;font-weight: 400;line-height: 22px;color: #333333;margin-bottom: 50px;' >< td style= 'text-align: center;' >< button class='btn btn-verify' style='width: 100% !important;height:50px;font-family: Open Sans; font-size: 18px;font-weight: 600;line-height: 22px;color: #fff;background-color: #6255a5;border-radius: 3px;'><a class='btn' href='http://localhost:51609/NotesMarketPlace/EmailVerify?email='"+receiverEmail+ "role='button' style='color: #fff; text-decoration: none; text-transform: uppercase;'>Verify email address</a></button></td></tr></tbody></table>";

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
            if (v != null)
            {
                v.IsEmailVerified = true;
                db.SaveChanges();
                return RedirectToAction("Login", "NotesMarketPlace");
            }
            else
            {
                ViewBag.Message = "Invalid Email verification";
                return View("SignUp");
            }
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin Model)
        {
            if (ModelState.IsValid)
            {
                var r = getemail(Model.EmailID);
                if (r == null)
                {
                    TempData["msg"] = "Invalid Email !";
                    return View();
                }
                else
                {
                    if (r.EmailID == Model.EmailID && r.Password == Model.Password)
                    {

                        Session["IsActive"] = r.IsActive;
                        return RedirectToAction("Signup");
                    }
                    else
                    {
                        TempData["msg"] = "invalid credential";
                        return RedirectToAction("Login");
                    }
                }

            }
            return View("Login");
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
            if (IsExist)
            {
                emailexist = true;
            }
            if (emailexist == true)
            {
                string strNewPassword = GeneratePassword().ToString();
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
                mailMessage.Body = "<br/>Hello, " + "<br/>We have generated password for you" + "<br/>" + strNewPassword + "<br/>" + "Regards, <br/> Notes MarketPlace.";

                mailMessage.IsBodyHtml = true;
                smtp.Send(mailMessage);
            }
            return RedirectToAction("Login", "NotesMarketPlace");
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
        public ActionResult UserAddNotes()
        {
            AddEditNotes model = new AddEditNotes
            {
                types = GetNoteTypes(),
                categories = GetNoteCategories(),
                countries = GetCountryList()
            };

            return View(model);
        }
        [HttpPost]
        //upload_image = display picture image
        //upload_image1 = preview image
        public ActionResult UserAddNotes(AddEditNotes model, HttpPostedFileBase upload_image, HttpPostedFileBase upload_image1, HttpPostedFileBase upload_notes)
        {
            ViewBag.show = false;

            //Store Display picture in database
            var filename = Path.GetFileName(upload_image.FileName);
            string path = Path.Combine(Server.MapPath("~/Uploadimg"), filename);
            upload_image.SaveAs(path);

            //Store preview picture in database
            var preview_img = Path.GetFileName(upload_image1.FileName);
            string preview_path = Path.Combine(Server.MapPath("~/Uploadimg"), preview_img);
            upload_image1.SaveAs(preview_path);

            //Store Notes(pdf_form) in database
            var notes_pdf = Path.GetFileName(upload_notes.FileName);
            string notes_pdf_path = Path.Combine(Server.MapPath("~/Uploadimg"), notes_pdf);
            upload_notes.SaveAs(notes_pdf_path);

            string name = Path.GetFileName(filename);
            string preview_img_name = Path.GetFileName(preview_img);
            string upload_note_name = Path.GetFileName(notes_pdf);

            if (model.sellfor == "Free")
            {
                model.IsPaid = false;
            }
            if (model.sellfor == "Paid")
            {
                model.IsPaid = true;
            }

            bool flag = false;
            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                var sellernote = new SellerNote
                {
                    Title = model.Title,
                    Category = model.CategoryID,
                    NoteType = model.TypeID,
                    Status = 6,
                    DisplayPicture = name,
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
                    NotesPreview = preview_img_name,
                    SellerID = 3
                };
                var sellernotesattachments = new SellerNotesAttachment
                {
                    FileName = upload_note_name,
                    FilePath = notes_pdf_path,
                    CreatedDate = DateTime.Now
                };

                db.SellerNotes.Add(sellernote);
                db.SellerNotesAttachments.Add(sellernotesattachments);
                db.SaveChanges();
                //ViewBag.show = true;
                flag = true;
            }
            ModelState.Clear();
            return RedirectToAction("UserAddNotes", "NotesMarketPlace");
        }

        //function for notetypes dropdown
        public List<NoteType> GetNoteTypes()
        {
            List<NoteType> noteTypes = db.NoteTypes.ToList();
            return noteTypes;

        }

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

        public List<SellerNote> GetTitles()
        {
            List<SellerNote> obj = db.SellerNotes.ToList();
            return obj;
        }

        public List<ReferenceData> GetStatus()
        {
            List<ReferenceData> obj = db.ReferenceDatas.ToList();
            return obj;
        }

        public ActionResult Dashboard()
        {
            //ViewBag.SortingDate = Sorting_Order == "Date" ? "Date_Desc" : "Date";
            //ViewBag.SortingTitle = Sorting_Order == "Titlle_Name" ? "Title_name_desc" : "Titlle_Name";
            //ViewBag.SortingCategory = Sorting_Order ==  "Categoty_Name" ? "Category_name_desc" : "Categoty_Name";
            //ViewBag.SortingStatus = Sorting_Order == "Status_Name" ? "Status_desc" : "Status_Name"; 

            List<SellerNote> titlelist = db.SellerNotes.ToList();
            List<NoteCategory> categorylist = db.NoteCategories.ToList();
            List<ReferenceData> statuslist = db.ReferenceDatas.ToList();

            var inprogressnotes = from c in categorylist
                                  join t in titlelist on c.CategoryID equals t.Category into table1
                                  from t in table1
                                  join r in statuslist on t.Status equals r.ID into table2
                                  from r in table2
                                  select new GetSellerNotesData { titlelist = t, categorylist = c, statuslist = r };

            //var publishednotes = from c in categorylist
            //                     join t in titlelist on c.CategoryID equals t.Category into table1
            //                     from t in table1
            //                     join r in statuslist on t.Status equals 

            //var publishenotes
            DashboardViewModel model = new DashboardViewModel
            {
                inprogress = inprogressnotes,
                ////published = publishednotes
            };
            //tempobj.titlelist = dashboardrecord;
            //switch (Sorting_Order)
            //{
            //    case "Date_Desc":
            //        dashboardrecord = dashboardrecord.OrderByDescending(x => x.titlelist.CreatedDate);
            //        break;
            //    case "Date":
            //        dashboardrecord = dashboardrecord.OrderBy(x => x.titlelist.CreatedDate);
            //        break;

            //    case "Title_name_desc":
            //        dashboardrecord = dashboardrecord.OrderByDescending(x => x.titlelist.Title);
            //        break;
            //    case "Titlle_Name":
            //        dashboardrecord = dashboardrecord.OrderBy(x => x.titlelist.Title); 
            //        break;

            //    case "Category_name_desc":
            //        dashboardrecord = dashboardrecord.OrderByDescending(x => x.categorylist.CategoryName);
            //        break;
            //    case "Categoty_Name":
            //        dashboardrecord = dashboardrecord.OrderBy(x => x.categorylist.CategoryName);
            //        break;

            //    case "Status_desc":
            //        dashboardrecord = dashboardrecord.OrderBy(x => x.categorylist.CategoryName);
            //        break;
            //    case "Status_Name":
            //        dashboardrecord = dashboardrecord.OrderBy(x => x.categorylist.CategoryName);
            //        break;
            //    default:
            //        dashboardrecord = dashboardrecord.OrderByDescending(x => x.titlelist.CreatedDate);
            //        break;
            //}

            //return View(ViewData["jointable"]);
            //int Size_Of_Page = 5;
            //int No_Of_Page = (Page_No ?? 1);
            return View(model);
        }
        public ActionResult SearchNotes()
        {
            SearchNotes Model = new SearchNotes
            {
                types = GetNoteTypes(),
                categories = GetNoteCategories(),
                univercities = GetTitles(),
                courses = GetTitles(),
                countries = GetCountryList()
            };
            return View(Model);
        }
        public ActionResult BuyerRequest()
        {
            List<SellerNote> sellertbl = db.SellerNotes.ToList();
            List<NoteCategory> categorytbl = db.NoteCategories.ToList();
            List<User> usertbl = db.Users.ToList();
            List<ReferenceData> reftbl = db.ReferenceDatas.ToList();

            var buyerrequest = from c in categorytbl
                               join s in sellertbl on c.CategoryID equals s.Category into table1
                               from s in table1
                               join u in usertbl on s.SellerID equals u.ID into table2
                               from u in table2
                               select new BuyerRequest { categorytbl = c, sellertbl = s, usertbl = u };

            return View(buyerrequest);
        }

        //Contact us
        public ActionResult ContactUs()
        {
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

            SearchNotes note = (from snote in db.SellerNotes
                                join category in db.NoteCategories on snote.Category equals category.CategoryID
                                where snote.ID == id
                                select new SearchNotes
                                {
                                    Singlenote = snote
                                }).SingleOrDefault();

            var cname = db.Countries.Where(x => x.CountryID == note.Singlenote.Country).SingleOrDefault();

            note.CountryName = cname.CountryName;
            return View(note);
        }
    }
}