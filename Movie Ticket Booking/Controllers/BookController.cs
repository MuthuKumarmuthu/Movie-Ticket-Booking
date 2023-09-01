using BusinessLogic;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie_Ticket_Booking.Controllers
{
    public class BookController : Controller
    {

        public SeatLogic SeatLog;

        public BookController()
        {

            SeatLog = new SeatLogic();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Seat()
        {

            return View();
        }
        public JsonResult Seatbook(SeatBook Seat)
        {


            var mv = SeatLog.Seat(Seat);
            return Json(mv, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSeatData(SeatsToBeRendered Obj)
        {
            var mv = SeatLog.GetSeatData(Obj);

            return Json(mv, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Ticket()
        {
            int memberID = (Int32)Session["Memberid"];
            List<TicketBookingObjectReturn_Result> movieDetails = SeatLog.GetMovieDetailsByMemberID(memberID);
            return View(movieDetails);
        }


        //[HttpGet]
        //public ActionResult Payment()
        //{

        //    int memberID = (Int32)Session["Memberid"];
        //    var movieDetails = SeatLog.GetMovieDetailsByMemberID(memberID);
        //    return Json(movieDetails, JsonRequestBehavior.AllowGet);
        //}
        //[HttpGet]
        //public ActionResult Payment(int Memberid,int Movieid)
        //{
        //    var mv = SeatLog.Getpay(Memberid, Movieid);
        //    Session["Bookid"] = mv.Bookid;
        //    return View(mv);
        //}
        //[HttpPost]
        //public ActionResult Payment(PaymentObject Pay)
        //{
        //     SeatLog.Postpay(Pay);
        //   // return RedirectToAction("Ticket");
        //   return RedirectToAction("Ticket", "Book", new { Memberid = Session["Memberid"] });
        //}
        //public ActionResult Ticket()
        //{
        //    return View();
        //}

        //public ActionResult Tickets(TicketObject tc)
        //{

        //    return View();
        //}

        public ActionResult Cancel(int Paymentid)
        {
                SeatLog.Cancel(Paymentid);
            return RedirectToAction("Ticket");
            
       


        }


    }

}