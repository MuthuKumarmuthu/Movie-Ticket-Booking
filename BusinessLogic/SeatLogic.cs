using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class SeatLogic
    {
        public SeatData seatData;
        public SeatLogic()
        {
            seatData = new SeatData();
        }

        public SeatBook Seat(SeatBook Seat)
        {

            return seatData.Seat(Seat);

        }

        public List<SeatsToBeRendered> GetSeatData(SeatsToBeRendered Obj)
        {
            return seatData.GetSeatData(Obj);
        }
        //public PaymentObject Getpay(int Memberid, int Movieid)
        //{
        //    return seatData.Getpay(Memberid, Movieid);
        //}
        //public PaymentObject Postpay(PaymentObject Pay)
        //{
        //    return seatData.Postpay(Pay);
        //}
        //public TicketObject Ticket(int Memberid)
        //{
        //    return seatData.Ticket(Memberid);
        //}
        public void Cancel(int Paymentid)
        {
            seatData.Cancel(Paymentid);
        }


        public List<TicketBookingObjectReturn_Result> GetMovieDetailsByMemberID(int memberID)
        {
            return seatData.GetMovieDetailsByMemberID(memberID);
        }

    }
}
