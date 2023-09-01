using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie_Ticket_Booking.Controllers
{
    public class AdminController : Controller
    {
        public AdminLogic AdminLog;
     
        public AdminController()
        {
            AdminLog = new AdminLogic();
            

        }

        [HttpGet]
        public ActionResult Admin()
        {

            var mv = AdminLog.AdminUser();
            ViewBag.User = mv.Total;
            ViewBag.Movie = mv.Movie;
            ViewBag.Booking = mv.Booking;
            ViewBag.Payment = mv.Payment;
            return View();
        }
        [HttpGet]
        public ActionResult SignupUser()
        {
            var mv = AdminLog.SignupUser();
            return View(mv);
        }

        public ActionResult MovieList()
        {
            var mv = AdminLog.MovieList();
            return View(mv);

        }
        public ActionResult BookingList()
        {
            var mv = AdminLog.BookingList();
            return View(mv);

        }
        public ActionResult PaymentList()
        {
            var mv = AdminLog.PaymentList();
            return View(mv);

        }
    }
}