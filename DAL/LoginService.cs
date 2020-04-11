using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Models;
namespace DAL
{
    public class LoginService
    {
        public Login UserLogin(Login user)
        {
            string sql = "Select UserName from Login where LoginId=@LoginId and LoginPwd=@LoginPwd";
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@LoginId",user.LoginId),
                new SqlParameter("@LoginPwd",user.LoginPwd)
            };
            SqlDataReader result = null;
            result = new Helper.SQLHelper().queryAllResult(sql, param, false);
            if (result.Read())
            {
                user.UserName = result["UserName"].ToString();
                return user;
            }
            return null;    
        }
    }
}
