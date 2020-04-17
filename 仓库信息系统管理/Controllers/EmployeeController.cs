using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models.Ext;
using Models;

namespace 仓库信息系统管理.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/

        public ActionResult Index()
        {
            List<EmployeeExt> EmpList = new EmployeeManage().getAllInfo();
            List<Role> RoleList = new EmployeeManage().ShowAllRole();
            List<Department> DepList = new EmployeeManage().ShowDepAll();
            SelectList list1 = new SelectList(RoleList,"RoleId","RoleName",RoleList[0].RoleId);
            SelectList list2 = new SelectList(DepList, "DepId", "DepName", DepList[0].DepId);
            ViewBag.RoleList = list1;
            ViewBag.DepList = list2;
            TempData["status"] = "full";
            return View("Index", EmpList);
        }

        public ActionResult Query(int DepId, int RoleId, string EmpName)
        {
            List<EmployeeExt> EmpList = new EmployeeManage().queryEmpInfo(DepId, RoleId,EmpName);
            List<Role> RoleList = new EmployeeManage().ShowAllRole();
            List<Department> DepList = new EmployeeManage().ShowDepAll();
            SelectList list1 = new SelectList(RoleList, "RoleId", "RoleName", RoleList[0].RoleId);
            SelectList list2 = new SelectList(DepList, "DepId", "DepName", DepList[0].DepId);
            ViewBag.RoleList = list1;
            ViewBag.DepList = list2;
            if (EmpList.Count == 0)
                TempData["status"] = "Empty";
            else
                TempData["status"] = "full";
            return View("Index", EmpList);
        }

    }
}
