using BusinessObject;
using BusinessLogic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Text;
using System.Web.Helpers;
using System.Web.UI.WebControls;

namespace Movie_Ticket_Booking.Controllers
{

    public class LoginController : Controller
    {

        public SignupLogic SignLog;
        public MovieLogic MovLog;
        public LoginController()
        {
            SignLog = new SignupLogic();
            MovLog = new MovieLogic();

        }



        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Membership()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Membership(RegisterData Reg )
        {
            if (ModelState.IsValid)
            {
                var mv = SignLog.ValidateUser(Reg);

                if (mv == "UserName Exists")
                {
                    ViewBag.Notification = "Username already Exists";
                    return View();
                }
                SignLog.RegisterUser(Reg);
                return RedirectToAction("Login");
            }
            return View();
            
        }
        public ActionResult Login()
       {
          
                return View();
        }
        [HttpPost]
        public ActionResult Login(Loginobject Log)
        {

            if (ModelState.IsValid)
            {
                var mv = SignLog.LoginUser(Log);
                Session["Username"] = mv.Username;
                Session["Memberid"] = mv.Memberid;
                //Session["Role"] = mv.Role;
                if (mv.Role == "Admin")
                {
                    return RedirectToAction("GetMovieAll", "Movie");
                }
                else if (mv.Role == "User")
                {
                    return RedirectToAction("Index", "Movie");
                }
                else
                {
                    ViewBag.Notification = "UserName Or Password Incorrect";
                    return View();
                }
            }
            return View();

            }


    }
}