using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Caching;
using System.Web.ModelBinding;

namespace DataAccess
{
    public class SignupData
    {
        public MoviebookingEntities db;
        public SignupData()
        {
            db = new MoviebookingEntities();
        }
  
       

        public void RegisterUser(RegisterData registerData)
        {


            Membership Member = new Membership
            {
                Username = registerData.Username,
                Password = registerData.Password,
                Role = registerData.Role,
                Createdon = DateTime.Now,
                Createdby = registerData.Username,
                Updatedon=DateTime.Now,
                Updatedby=registerData.Username

            };

            Contactdetail Cont = new Contactdetail
            {
                
                Firstname = registerData.Firstname,
                Lastname = registerData.Lastname,
                Dateofbirth = registerData.Dateofbirth,
                Phonenumber = registerData.Phonenumber,
                Email = registerData.Email,
                Createdon = DateTime.Now,
                Createdby = registerData.Username,
                Updatedon = DateTime.Now,
                Updatedy = registerData.Username
            };
            Member.Contactdetails.Add(Cont);
            db.Memberships.Add(Member);
            db.SaveChanges();


        }


        public string ValidateUser(RegisterData Reg)
        {
            MoviebookingEntities db = new MoviebookingEntities();
            RegisterData Rg = new RegisterData();
            bool Mov = db.Memberships.Any(x => x.Username == Reg.Username );
            if(Mov==true)
            {
                return "UserName Exists";
            }
            return "Username";
        }

        public Loginobject LoginUser(Loginobject Log)
        {
            Loginobject Reg = new Loginobject();
            using (MoviebookingEntities db = new MoviebookingEntities())
           
            {
                var obj= db.Memberships.Where(a => a.Username.Equals(Log.Username) && a.Password.Equals(Log.Password));
                if (obj.Any())
                {
                   var Mem= obj.FirstOrDefault();
                    Reg.Memberid = Mem.Memberid;
                    Reg.Username = Mem.Username;
                    Reg.Password =Mem.Password;
                    Reg.Role = Mem.Role;
                    return Reg;
                }
                return Reg;
            }
        }

    }

  
    


     
    
  


}
