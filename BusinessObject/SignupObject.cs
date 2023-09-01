using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessObject
{


    public class RegisterData
    {
        public int Memberid { get; set; }
        [Display(Name = "User Name")]
       [Required(ErrorMessage = "Please Enter Name")]
        public string Username { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Role")]
        [Required(ErrorMessage = "Please Enter Role")]
        public string Role { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please Enter First Name ")]
        public string Firstname { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please Enter Last Name")]
        public string Lastname { get; set; }
        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "Please Enter Date Of Birth ")]
        public DateTime Dateofbirth { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please Enter Email")]
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please Enter ")]

        [RegularExpression(@"\d{10}", ErrorMessage = "Please enter 10 digit Mobile No.")]
        public string Phonenumber { get; set; }
        public System.DateTime Createdon { get; set; }
        public string Createdby { get; set; }
        public System.DateTime Updatedon { get; set; }
        public string Updatedby { get; set; }
  
    }
    public class Loginobject
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please Enter Name")]
        public string Username { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    
        public string Role { get; set; }
        public int Memberid { get; set; }

    }
    public class AdminObject
    {
        public int Memberid { get; set; }
        public int Movieid { get; set; }
        public int Total { get; set; }
        public int Movie { get; set; }
        public int Booking { get; set; }
        public int Payment { get; set; }

    }

    public class SignupObject
    {
        public int Memberid { get; set; }
   
        public string Username { get; set; }
     
        public string Password { get; set; }
    
        public string Role { get; set; }
      
        public System.DateTime Createdon { get; set; }
        public string Createdby { get; set; }
        public System.DateTime Updatedon { get; set; }
        public string Updatedby { get; set; }


    }


}
