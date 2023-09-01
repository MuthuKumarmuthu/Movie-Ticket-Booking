using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;



namespace BusinessLogic
{
    public class SignupLogic
    {
        public SignupData Signdb;
        public SignupLogic()
        {
            Signdb= new SignupData();   
        }
        public void RegisterUser(RegisterData registerData)
        {

            Signdb.RegisterUser(registerData);
        }
        public string ValidateUser (RegisterData Reg)
        {
           return Signdb.ValidateUser(Reg);
        }
        public Loginobject LoginUser(Loginobject Log)
        {
            return Signdb.LoginUser(Log);
        }



    }


}

