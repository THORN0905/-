using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
    public class LoginManage
    {
        public Login LoginService(Login user)
        {
            return new LoginService().UserLogin(user);
        }
    }
}
