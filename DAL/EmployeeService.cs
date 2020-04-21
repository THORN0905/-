 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models;
using Models.Ext;
namespace DAL
{
    public class EmployeeService
    {
        /// <summary>
        /// 显示所有员工信息
        /// </summary>
        /// <returns></returns>
        public List<EmployeeExt> ShowAllInfo()
        {
            List<EmployeeExt> Emplist = new List<EmployeeExt>();
            try
            {
                SqlDataReader result = new Helper.SQLHelper().queryAllResult("GetEmpAll", true);
                while (result.Read())
                {
                    Emplist.Add(new EmployeeExt()
                    {
                        EmpId = Convert.ToInt32(result["EmpId"]),
                        EmpName = result["EmpName"].ToString(),
                        EmpGender = result["EmpGender"].ToString(),
                        EmpAddress = result["EmpAddress"].ToString(),
                        EmpPhone = result["EmpPhone"].ToString(),
                        EmpIdNo = result["EmpIdNo"].ToString(),
                        EmpDepId = Convert.ToInt32(result["EmpDepId"]),
                        EmpRole1 = Convert.ToInt32(result["EmpRole1"]),
                        EmpRole2 = Convert.ToInt32(result["EmpRole2"]),
                        EmpRole3 = Convert.ToInt32(result["EmpRole3"]),
                        RoleName1 = result["RoleName1"].ToString(),
                        RoleName2 = result["RoleName2"].ToString(),
                        RoleName3 = result["RoleName3"].ToString(),
                        DepName = result["DepName"].ToString(),
                        EmpBirthday = Convert.ToDateTime(result["EmpBirthday"])
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
           
            return Emplist;
        }

        /// <summary>
        /// 查询员工共信息
        /// </summary>
        /// <param name="DepId"></param>
        /// <param name="RoleId"></param>
        /// <param name="EmpName"></param>
        /// <returns></returns>
        public List<EmployeeExt> QueryEmpInfo(int DepId,int RoleId ,string EmpName)
        {
            string sql = "SELECT Employee.EmpId, Employee.EmpName, Employee.EmpGender, Employee.EmpBirthday,  "+
               " Employee.EmpIdNo, Employee.EmpDepId, Employee.EmpAddress, Employee.EmpPhone, Employee.EmpRole1,Employee.EmpRole2,Employee.EmpRole3, "+
	            "(select RoleName from Role where RoleId = Employee.EmpRole1) as RoleName1, " +
	            "(select RoleName from Role where RoleId = Employee.EmpRole2) as RoleName2," +
	            "(select RoleName from Role where RoleId = Employee.EmpRole3) as RoleName3," + 
	               " Department.DepName FROM  dbo.Employee  join dbo.Department on Employee.EmpDepId = Department.DepId "+
                    " WHERE Employee.EmpId > 10000";
            if (DepId != 0)
                sql += " and Department.DepId="+DepId;
            if (RoleId != 0)
                sql += " and (Employee.EmpRole1="+RoleId +"or Employee.EmpRole2="+RoleId+" or Employee.EmpRole3="+RoleId+")";
            if (EmpName != "")
                sql += " and Employee.EmpName='"+EmpName+"'";
            List<EmployeeExt> Emplist = new List<EmployeeExt>();
            SqlDataReader result = new Helper.SQLHelper().queryAllResult(sql,false);
            while (result.Read())
            {
                Emplist.Add(new EmployeeExt()
                {
                    EmpId = Convert.ToInt32(result["EmpId"]),
                    EmpName = result["EmpName"].ToString(),
                    EmpGender = result["EmpGender"].ToString(),
                    EmpAddress = result["EmpAddress"].ToString(),
                    EmpPhone = result["EmpPhone"].ToString(),
                    EmpIdNo = result["EmpIdNo"].ToString(),
                    EmpDepId = Convert.ToInt32(result["EmpDepId"]),
                    EmpRole1 = Convert.ToInt32(result["EmpRole1"]),
                    EmpRole2 = Convert.ToInt32(result["EmpRole2"]),
                    EmpRole3 = Convert.ToInt32(result["EmpRole3"]),
                    RoleName1 = result["RoleName1"].ToString(),
                    RoleName2 = result["RoleName2"].ToString(),
                    RoleName3 = result["RoleName3"].ToString(),
                    DepName = result["DepName"].ToString(),
                    EmpBirthday = Convert.ToDateTime(result["EmpBirthday"])
                });
            }
            return Emplist;
        }

        /// <summary>
        /// 显示所有职称
        /// </summary>
        /// <returns></returns>
        public List<Role> ShowRoleAll()
        {
            string sql = "SELECT Role.RoleId, Role.RoleName FROM dbo.Role";
            SqlDataReader result = new Helper.SQLHelper().queryAllResult(sql, false);
            List<Role> RoleList = new List<Role>();
            while (result.Read())
            {
                RoleList.Add(new Role()
                {
                    RoleId= Convert.ToInt32(result["RoleId"]),
                    RoleName = result["RoleName"].ToString()
                });
            }
            return RoleList;
        }

        /// <summary>
        /// 显示所有部门
        /// </summary>
        /// <returns></returns>
        public  List<Department> ShowDepAll()
        {
            string sql = "SELECT  Department.DepId,Department.DepName,Department.DepAddress,Department.DepPhone FROM dbo.Department";
            SqlDataReader result = new Helper.SQLHelper().queryAllResult(sql, false);
            List<Department> DepList = new List<Department>();
            while (result.Read())
            {
                DepList.Add(new Department()
                {
                    DepId = Convert.ToInt32(result["DepId"]),
                    DepName = result["DepName"].ToString(),
                    DepAddress = result["DepAddress"].ToString(),
                    DepPhone = result["DepPhone"].ToString()
                });
            }
            return DepList;
        }

        /// <summary>
        /// 按编号查询员工
        /// </summary>
        /// <param name="EmpId"></param>
        /// <returns></returns>
        public EmployeeExt queryEmpById(int EmpId)
        {
            string sql = "SELECT Employee.EmpId, Employee.EmpName, Employee.EmpGender, Employee.EmpBirthday,  " +
               " Employee.EmpIdNo, Employee.EmpDepId, Employee.EmpAddress, Employee.EmpPhone, Employee.EmpRole1,Employee.EmpRole2,Employee.EmpRole3, " +
                "(select RoleName from Role where RoleId = Employee.EmpRole1) as RoleName1, " +
                "(select RoleName from Role where RoleId = Employee.EmpRole2) as RoleName2," +
                "(select RoleName from Role where RoleId = Employee.EmpRole3) as RoleName3," +
                   " Department.DepName FROM  dbo.Employee  join dbo.Department on Employee.EmpDepId = Department.DepId " +
                    " WHERE Employee.EmpId = @EmpId";
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@EmpId",EmpId)
            };
            EmployeeExt Emp = new EmployeeExt();
            SqlDataReader result = new Helper.SQLHelper().queryAllResult(sql, param,false);
            while (result.Read())
            {
                Emp.EmpId = Convert.ToInt32(result["EmpId"]);
                Emp.EmpName = result["EmpName"].ToString();
                Emp.EmpGender = result["EmpGender"].ToString();
                Emp.EmpAddress = result["EmpAddress"].ToString();
                Emp.EmpPhone = result["EmpPhone"].ToString();
                Emp.EmpIdNo = result["EmpIdNo"].ToString();
                Emp.EmpDepId = Convert.ToInt32(result["EmpDepId"]);
                Emp.EmpRole1 = Convert.ToInt32(result["EmpRole1"]);
                Emp.EmpRole2 = Convert.ToInt32(result["EmpRole2"]);
                Emp.EmpRole3 = Convert.ToInt32(result["EmpRole3"]);
                Emp.RoleName1 = result["RoleName1"].ToString();
                Emp.RoleName2 = result["RoleName2"].ToString();
                Emp.RoleName3 = result["RoleName3"].ToString();
                Emp.DepName = result["DepName"].ToString();
                Emp.EmpBirthday = Convert.ToDateTime(result["EmpBirthday"]);
            }
            return Emp;
        }
    }
}
