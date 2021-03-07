using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NotesMarketPlace.Models;


namespace NotesMarketPlace.Controllers
{
    public class NotesMarketPlaceController : Controller
    {

        NotesMarketPlaceTablesEntities1 db = new NotesMarketPlaceTablesEntities1();

        // GET: NotesMarketPlace HomePage
        public ActionResult HomePage()
        {
            return View();
        }

        // GET: NotesMarketPlace LoginPage
        public ActionResult Login()
        {
            return View();
        }

        // GET: NotesMarketPlace SignUpPage
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSignUp(User data)
        {
            if (ModelState.IsValid)
            {
                User obj = new User();
                obj.FirstName = data.FirstName;
                obj.LastName = data.LastName;
                obj.EmailID = data.EmailID;
                obj.Password = data.Password;
                obj.RoleID = 6;
                db.Users.Add(obj);
                db.SaveChanges();
            }
            ModelState.Clear();

            return View("SignUp");
        }

        // GET: NotesMarketPlace ForgotPassword
        public ActionResult ForgotPassword()
        {
            return View();
        }

        // GET: NotesMarketPlace SearchNotes
        public ActionResult SearchNotes()
        {
            return View();
        }

        // GET: NotesMarketPlace SellYourNotes
        public ActionResult SellYourNotes()
        {
            return View();
        }

        // GET: NotesMarketPlace FAQ
        public ActionResult FAQ()
        {
            return View();
        }

        //Testing
        public ActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Test(NameTable obj)
        {
            if (ModelState.IsValid)
            {
                db.NameTables.Add(obj);
                db.SaveChanges();
            }
            return View(obj);
        }
    } 
}