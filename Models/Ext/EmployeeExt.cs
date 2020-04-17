using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Ext
{
    public class EmployeeExt:Employee
    {
        public string DepName { set; get; }
        public string RoleName1 { set; get; }
        public string RoleName2 { set; get; }
        public string RoleName3 { set; get; }
    }
}
