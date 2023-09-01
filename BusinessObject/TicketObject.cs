using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class TicketObject
    {
        public int Ticketid { get; set; }
        public int Paymentid { get; set; }
        public int Memberid { get; set; }
        public int Bookid { get; set; }
        public string Moviename { get; set; }
        public System.DateTime Moviedate { get; set; }
        public System.TimeSpan Movietime { get; set; }
        public int Seatid { get; set; }
        public int Ticketprice { get; set; }

    }

    public class TicketBookingObjectSp_Result : TicketBookingObject_Result
    {
        public int SeatNo { get; set; }
    }
    public class TicketBookingObjectReturn_Result : TicketBookingObject_Result
    {
        public string SeatNo { get; set; }
    }
    public class TicketBookingObject_Result
    {
        public int Paymentid { get; set; }
        public string Moviename { get; set; }
        public string Screen { get; set; }
        public DateTime Moviedate { get; set; }
        public System.TimeSpan Movietime { get; set; }
        public int Total { get; set; }
    }



    public partial class TicketBookingObject
    {

        public string Username { get; set; }
        public string Moviename { get; set; }

        public string Screen { get; set; }
        public System.DateTime Moviedate { get; set; }
        public System.TimeSpan Movietime { get; set; }
        public int Seatid { get; set; }
        public int Ticketprice { get; set; }

    }
}
