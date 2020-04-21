using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models.Ext;
using Models;

namespace BLL
{
    public class EmployeeManage
    {
        /// <summary>
        /// 查询所有员工信息
        /// </summary>
        /// <returns></returns>
        public List<EmployeeExt> getAllInfo()
        {
            return new EmployeeService().ShowAllInfo();
        }

        /// <summary>
        /// 查询员工信息
        /// </summary>
        /// <param name="DepId"></param>
        /// <param name="RoleId"></param>
        /// <param name="EmpName"></param>
        /// <returns></returns>
        public List<EmployeeExt> queryEmpInfo(int DepId,int RoleId,string EmpName)
        {
            return new EmployeeService().QueryEmpInfo(DepId, RoleId, EmpName);
        }

        /// <summary>
        /// 显示所有职称信息
        /// </summary>
        /// <returns></returns>
        public List<Role> ShowAllRole()
        {
            return new EmployeeService().ShowRoleAll();
        }

        /// <summary>
        /// 显示所有职称信息
        /// </summary>
        /// <returns></returns>
        public List<Department> ShowDepAll()
        {
            return new EmployeeService().ShowDepAll();
        }

        public EmployeeExt QueryEmpById(int EmpId)
        {
            return new EmployeeService().queryEmpById(EmpId);
        }
    }
}
