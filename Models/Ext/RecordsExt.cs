using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Ext
{
    public class RecordsExt : Records
    {
        public string ProductName { set; get; }
        public string Customer { set; get; }
        public int Plans { set; get; }
    }
}
