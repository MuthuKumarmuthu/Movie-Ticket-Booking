using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace DataAccess
{
    public class AdminData
    {
        public MoviebookingEntities db;
        public AdminData()
        {
            db = new MoviebookingEntities();
        }
        public AdminObject AdminUser()
        {
            AdminObject Adm = new AdminObject();

            var obj = db.Memberships.Count();
            Adm.Total = obj;
            var Abj = db.AddMovies.Count();
            Adm.Movie = Abj;
            var Bookings = db.Seatbookings.Count();
            Adm.Booking = Bookings;
            var Payments = db.Payments.Count();
            Adm.Payment= Payments;
            return Adm;
        }

        public IEnumerable<SignupObject> SignupUser()
        {
          

            var result = (from mov in db.Memberships
                          select new SignupObject
                          {
                              Memberid = mov.Memberid,
                              Username = mov.Username ,
                              Password=mov.Password,
                              Role=mov.Role,
                              Createdon = mov.Createdon,
                              Createdby = mov.Createdby,
                              Updatedon = mov.Updatedon,
                              Updatedby = mov.Updatedby,
                          }).ToList();


            return result;


        }
        public IEnumerable<MovieListObject> MovieList()
        {


            string imageurl = WebConfigurationManager.AppSettings["imageurl"];
            var result = (from mov in db.AddMovies
                          select new MovieListObject
                          {
                              Moviename = mov.Moviename,
                              ImageUrl = imageurl + mov.Movieimage,
                              Genre = mov.Genre,
                              Language=mov.Language,
                              Releasedate=mov.Releasedate,
                              Description = mov.Description,
                              Price=mov.Price
                              
                          }).ToList();


            return result;


        }
        public IEnumerable<SeatBookingObject> BookingList()
        {


            var result = (from mov in db.Seatbookings
                          select new SeatBookingObject
                          {
                              Movieid=mov.Movieid,
                              Memberid=mov.Memberid,
                              Screen = mov.Screen,
                              Moviedate = mov.Moviedate,
                              Movietime = mov.Movietime,
                              Seatid = mov.Seatid,
                              Ticketprice = mov.Ticketprice,
                              Paymentid = mov.Paymentid,
                            

                          }).ToList();


            return result;


        }
        public IEnumerable<PaymentObject> PaymentList()
        {


            var result = (from paymentData in db.Payments
                          select new PaymentObject
                          {
                              Paymentid = paymentData.Paymentid,
                              Cardnumber = paymentData.Cardnumber,
                              Cvv = paymentData.Cvv,
                              Expirydate = paymentData.Expirydate,
                              Nameoncard = paymentData.Nameoncard,
                              Total = paymentData.Total,


                          }).ToList();


            return result;


        }
    }
}