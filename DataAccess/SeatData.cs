using BusinessObject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace DataAccess
{
    public class SeatData
    {


        public MoviebookingEntities db;
        public SeatData()
        {
            db = new MoviebookingEntities();
        }
        public SeatBook Seat(SeatBook Seat)
        {

            PayMentDetails paymentData = Seat.PayMentDetails;

            Payment payment = new Payment()
            {
                Cardnumber = paymentData.Cardnumber,
                Cvv = paymentData.Cvv,
                Expirydate = paymentData.Expirydate,
                Nameoncard = paymentData.Nameoncard,
                Total = paymentData.Total,
            };

            //db.Payments.Add(payment);
            //db.SaveChanges();

            //int id = payment.Paymentid;

            for (var i = 0; i < Seat.Seatid.Length; i++)
            {
                Seatbooking Seatbooks = new Seatbooking();
                Seatbooks.Memberid = Seat.Memberid; ;
                Seatbooks.Movieid = Seat.Movieid;
                Seatbooks.Screen = Seat.Screen;
                Seatbooks.Moviedate = Seat.Moviedate;
                Seatbooks.Movietime = Seat.Movietime;
                Seatbooks.Ticketprice = Seat.Price;
                Seatbooks.Seatid = Seat.Seatid[i];
                //db.Seatbookings.Add(Seatbooks);
                //db.SaveChanges();

                payment.Seatbookings.Add(Seatbooks);
                db.Payments.Add(payment);




            };
            db.SaveChanges();

            return Seat;


        }

        public List<SeatsToBeRendered> GetSeatData(SeatsToBeRendered Mov)
        {
            List<SeatsToBeRendered> seatData = new List<SeatsToBeRendered>();
            DateTime dt = DateTime.Parse(Mov.Moviedate);

            seatData = (from seat in db.Seats
                        join ms in (db.Seatbookings.Where(x => x.Movieid == Mov.Movieid && x.Moviedate==dt && x.Screen == Mov.Screen && x.Movietime == Mov.Movietime)) on
                       seat.Seatid equals ms.Seatid into seats
                        from ms in seats.DefaultIfEmpty()
                        select new SeatsToBeRendered

                        {
                            SeatID = seat.Seatid,
                            SeatNo = seat.Seatno,
                            IsBooked = ms != null ? true : false,


                        }).ToList();
       
       

            return seatData;
        }
        //public PaymentObject Getpay(int Memberid, int Movieid)
        //{
        //    Payment Reg = new Payment();
        //    PaymentObject payt = new PaymentObject();
        //    using (MoviebookingEntities db = new MoviebookingEntities())

        //    {
        //        var obj = db.Seatbookings.Where(a => a.Memberid == Memberid && a.Movieid == Movieid);
        //        if (obj.Any())
        //        {
        //            var Mem = obj.FirstOrDefault();
        //            payt.Memberid = Mem.Memberid;
        //            payt.Bookid = Mem.Bookid;
        //        }
        //        return payt;
        //    }
        //}
        //public PaymentObject Postpay(PaymentObject Pay)
        //{


        //using (MoviebookingEntities db = new MoviebookingEntities())

        //{
        //    var obj = db.Payments.Where(a => a.Bookid == Pay.Bookid);
        //    if (obj.Any())
        //    {
        //var Mem = obj.FirstOrDefault();
        //    Payment Obj = new Payment();
        //    {
        //        Obj.Bookid = Pay.Bookid;
        //        //Obj.Paymentid = Pay.Paymentid;
        //        Obj.Cardnumber = Pay.Cardnumber;
        //        Obj.Nameoncard = Pay.Nameoncard;
        //        Obj.Expirydate = Pay.Expirydate;
        //        Obj.Cvv = Pay.Cvv;
        //    }
        //    db.Payments.Add(Obj);
        //    db.SaveChanges();
        //    return Pay;


        //}

        //public TicketObject Ticket(int Memberid)
        //{

        //List<TicketObject> seatData = new List<TicketObject>();


        //var result = (from mov in db.Seatbookings.Where(x => x.Memberid == Memberid)
        //              select new TicketObject
        //              {


        //                  Seatid = mov.Seatid,
        //                  Moviedate = mov.Moviedate,
        //                  Movietime = mov.Movietime,
        //                  Ticketprice = mov.Ticketprice,
        //              });
        //TicketObject tc = new TicketObject();
        //var result = db.Seatbookings.Where(x => x.Memberid == Memberid);
        //if (result.Any())
        //var result = (from mov in db.Seatbookings.Where(x => x.Memberid == Memberid)
        //              select new TicketObject
        //              {


        //                  Seatid = mov.Seatid,
        //                  Moviedate = mov.Moviedate,
        //                  Ticketprice = mov.Ticketprice,

        //              }).ToList();
        //return result; 
        //var result = (from mov in db.AddMovies
        //              select new MovieDetails
        //              {

        //                  Movieid = mov.Movieid,
        //                  Memberid = mov.Memberid,
        //                  Moviename = mov.Moviename,
        //                  ImageUrl = imageurl + mov.Movieimage,
        //                  Genre = mov.Genre,
        //                  Language = mov.Language,
        //                  Releasedate = mov.Releasedate,
        //                  Description = mov.Description,
        //                  Enddate = mov.Enddate,
        //                  price = mov.price,
        //              }).ToList();

        //var result = db.Seatbookings.Where(x => x.Memberid == Memberid);

        //TicketObject tc = new TicketObject();
        //{
        //    var Mem = result.FirstOrDefault();

        //    tc.Seatid = Mem.Seatid;
        //    tc.Moviedate = Mem.Moviedate;
        //    tc.Ticketprice = Mem.Ticketprice;
        //    var mv = db.Payments.Where(x => x.Bookid == Mem.Bookid).FirstOrDefault();
        //    tc.Paymentid = mv.Paymentid;
        //    tc.Moviedate = Mem.Moviedate;
        //    tc.Movietime = Mem.Movietime;
        //    return tc;
        //}
        //var results = db.Seatbookings
        //    .Where(e => e.Memberid == Memberid)
        //    .Select(e => new TicketObject
        //    {
        //        Seatid = e.Seatid,
        //        Moviedate = e.Moviedate,
        //        Movietime = e.Movietime
        //    }).ToList();
        //return results;


        //    }

        public List<TicketBookingObjectReturn_Result> GetMovieDetailsByMemberID(int memberID)
        {

            List<TicketBookingObjectSp_Result> data_sp = db.Database.SqlQuery<TicketBookingObjectSp_Result>("Sp_GetMovieDetails @MemberID", new SqlParameter("MemberID", value: memberID)).ToList();

            var data = (from gr in data_sp
                        group gr by new
                        {
                            gr.Paymentid,
                            gr.Moviename,
                            gr.Screen,
                            gr.Moviedate,
                            gr.Movietime,
                            gr.Total
                        }
                     into gcs
                        select new TicketBookingObjectReturn_Result()
                        {

                            Paymentid=gcs.Key.Paymentid,
                            Moviename = gcs.Key.Moviename,
                            Screen = gcs.Key.Screen,
                            Moviedate = gcs.Key.Moviedate,
                            Movietime = gcs.Key.Movietime,
                            Total = gcs.Key.Total,
                            SeatNo = string.Join(",", gcs.Select(x => x.SeatNo).ToList())
                        }).ToList();

            return data;

        }
        public void Cancel(int Paymentid)
        {

            MoviebookingEntities db = new MoviebookingEntities();
            MovieDetails Mov = new MovieDetails();
            var pay = db.Payments.Where(x => x.Paymentid == Paymentid).SingleOrDefault();
            db.Payments.Remove(pay);
            var payment = db.Seatbookings.Where(x => x.Paymentid == Paymentid).ToList();
            db.Seatbookings.RemoveRange(payment);
            db.SaveChanges();


        }

    }


}
