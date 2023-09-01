using BusinessObject;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.ModelBinding;
using System.Web.UI.WebControls;

namespace Movie_Ticket_Booking.Controllers
{
    public class MovieController : Controller
    {

        public MovieLogic MovLog;
        public SeatLogic SeatLog;
        public MovieController()
        {
          
            MovLog = new MovieLogic();
             SeatLog = new SeatLogic();
        }

        public ActionResult MovieAdd()
        {
            if (Session["Memberid"]==null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult MovieAdd(MovieDetails MovObj)
        {
            if (ModelState.IsValid)
            { 
                MovLog.Insert(MovObj);
            return RedirectToAction("GetMovieAll");
        }
            return View();

        }

        public ActionResult GetMovieAll()
        {
            var Mov = MovLog.GetMovieAll();
            return View(Mov);

        }

        [HttpGet]
        public ActionResult Edit(int Movieid)
        {

            var mv = MovLog.Edit(Movieid);
            Session["Movieid"] = mv.Movieid;
            return View(mv);

        }
        [HttpPost]
        public ActionResult Edit(MovieDetails MovObj)
        {
            if (ModelState.IsValid)
            {

                MovLog.Edits(MovObj);
                return RedirectToAction("GetMovieAll");
            }
            return View();
        }

        public ActionResult Index()
        {
            try
            {
                var Mov = MovLog.Index();
                return View(Mov);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }
        [HttpGet]
        public ActionResult GetImage(string filename)
        {
            string fileDirectory = WebConfigurationManager.AppSettings["imagepath"];
            string filepath = Path.Combine(fileDirectory, filename + "." + "Jpeg");
            byte[] imageArray = System.IO.File.ReadAllBytes(filepath);
            MemoryStream imgStream = new MemoryStream(imageArray);
            return File(imgStream, "image/png");

        }
       
        //public ActionResult Delete(int Movieid)
        //{
        //    try
        //    {
                
        //        MovLog.Delete(Movieid);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return RedirectToAction("GetMovieAll");
        //}


        [HttpGet]
        public ActionResult GetMovieById(int Movieid)
        {
            var mv = MovLog.GetMovieById(Movieid);
            Session["Movieid"] = mv.Movieid;
            return View(mv);

        }
        //[HttpPost]
        //public ActionResult GetMovieById(SeatObject Obj)
        //{
        //    var mv = MovLog.Seats(Obj);
        //    return View(Obj);
        //}
       // [HttpGet]
       //public ActionResult Seats(SeatObject De)
       // {
       //     var mv = MovLog.Seats(De);
       //     return View(mv);
       // }
        //[HttpPost]
        //public ActionResult Seats(SeatObject Obj)
        //{
        //    var mv = MovLog.Seat(Obj);
        //    return View(mv);
        //}
        public ActionResult Select()
        {
            if (Session["Memberid"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Select(SeatsToBeRendered Obj)
        {
            if (ModelState.IsValid)
            {
                TempData["Screen"] = Obj.Screen;
                TempData["Moviedate"] = Obj.Moviedate;
                TempData["Movietime"] = Obj.Movietime;
                var mv = MovLog.Select(Obj);
                TempData["price"] = mv.Price;
          
                return RedirectToAction("Seat", "Book");
            }
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        //public ActionResult Seat()
        //{

        //    return View();
        //}
        //public JsonResult Seatbook(SeatBook Seat)
        //{

        //    SeatLog.Seat(Seat);
        //    return Json(Seat, JsonRequestBehavior.AllowGet);
        //}

        //[HttpGet]
        //public JsonResult GetSeatData(SeatsToBeRendered Obj)
        //{
        //    return Json(SeatLog.GetSeatData(Obj), JsonRequestBehavior.AllowGet);
        //}
    }
 
}