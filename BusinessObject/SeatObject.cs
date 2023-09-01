using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class SeatObject
    {
        public int Bookid { get; set; }
        public int Movieid { get; set; }
        public int Memberid { get; set; }
        public string Screen { get; set; }
        public System.DateTime Moviedate { get; set; }
        public System.TimeSpan Movietime { get; set; }
        public int[] Seatno { get; set; }
        public int SeatID { get; set; }
        public int Seatid { get; set; }
        public bool IsBooked { get; set; }
        public string Seats { get; set; }
        public int Ticketprice { get; set; }


    }
    public class SeatBook
    {

        public int Id { get; set; }
        public int Movieid { get; set; }
        public int Memberid { get; set; }
        public int[] Seatid { get; set; }
        public bool Status { get; set; }
        public string Screen { get; set; }
        public System.DateTime Moviedate { get; set; }
        public System.TimeSpan Movietime { get; set; }
        public int Price { get; set; }
        public System.DateTime Createdon { get; set; }
        public System.DateTime Updatedon { get; set; }

        public PayMentDetails PayMentDetails { get; set; }
    }

    public class PayMentDetails
    {
        public string Cardnumber { get; set; }
        public string Nameoncard { get; set; }
        public System.DateTime Expirydate { get; set; }
        public int Cvv { get; set; }
        public int Total { get; set; }
    }

    public class SeatsToBeRendered
    {
        public int Movieid { get; set; }
        public int Memberid { get; set; }
        [Required(ErrorMessage = "Please Enter Screen ")]
        public string Screen { get; set; }
        public string Moviename { get; set; }
        [Required(ErrorMessage = "Please Enter Date Time ")]
        public string Moviedate { get; set; }
        [Required(ErrorMessage = "Please Enter Movie Time")]
        public System.TimeSpan Movietime { get; set; }


        public int Price { get; set; }
        public int SeatID { get; set; }
        public int SeatNo { get; set; }
        public bool IsBooked { get; set; }
    }

    public class SeatBookingObject
    {
        public int Bookid { get; set; }
        public int Movieid { get; set; }
        public int Memberid { get; set; }
        public string Screen { get; set; }
        public System.DateTime Moviedate { get; set; }
        public System.TimeSpan Movietime { get; set; }
        //public int[] Seatno { get; set; }
        //public int SeatID { get; set; }
        public int Seatid { get; set; }
        //public bool IsBooked { get; set; }
        //public string Seats { get; set; }
        public int Ticketprice { get; set; }
        public int Paymentid { get; set; }


    }
}
