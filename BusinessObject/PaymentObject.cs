using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class PaymentObject
    {
        public int Paymentid { get; set; }
       
        public int Memberid { get; set; }
        public int Movieid { get; set; }
        public int Bookid { get; set; }
        public string Cardnumber { get; set; }
        public string Nameoncard { get; set; }
        public System.DateTime Expirydate { get; set; }
        public int Cvv { get; set; }
        public int Total { get; set; }
    }
}
