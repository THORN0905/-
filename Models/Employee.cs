using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Employee
    {
        public int EmpId { set; get; }
        public string EmpName { set; get; }
        public string EmpGender { set; get; }
        public DateTime EmpBirthday { set; get; }
        public string EmpIdNo { set; get; }
        public int EmpDepId { set; get; }
        public string EmpAddress { set; get; }
        public string EmpPhone { set; get; }
        public int EmpRole1 { set; get; }
        public int EmpRole2 { set; get; }
        public int EmpRole3 { set; get; }
    }
}
