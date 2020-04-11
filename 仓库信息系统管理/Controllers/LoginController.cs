using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

namespace 仓库信息系统管理.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View("AdminLogin");
        }

        public ActionResult AdminLogin(Login user)
        {
            
            user = new LoginManage().LoginService(user);
            if (user == null)
                return Content("<script>alert('用户名或密码错误！');window.location='" + Url.Action("Index") + "'</script>");
            else
            {
                Session["CurrentUser"] = user;
                TempData["user"] = user.UserName;
                return RedirectToAction("Index", "Home");
            }              
        }
    }
}
