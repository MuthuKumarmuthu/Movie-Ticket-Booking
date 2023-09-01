using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AdminLogic
    {
        public AdminData Admindb;
        public AdminLogic()
        {
            Admindb = new AdminData();
        }
        public AdminObject AdminUser()
        {
            return Admindb.AdminUser();
        }
        public IEnumerable<SignupObject> SignupUser()
        {
            return Admindb.SignupUser();

        }
        public IEnumerable<MovieListObject> MovieList()
        {
            return Admindb.MovieList();

        }
        public IEnumerable<SeatBookingObject> BookingList()
        {
            return Admindb.BookingList();

        }

        public IEnumerable<PaymentObject> PaymentList()
        {
            return Admindb.PaymentList();

        }
    }
}