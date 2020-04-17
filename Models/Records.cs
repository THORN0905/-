using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Records
    {
        public int Id { set; get; }
        public string ProductId { set; get; }
        public int InNum { set; get; }
        public int OutNum { set; get; }
        public int Inventory { set; get; }
        public DateTime Time { set; get; }
        public string userName { get; set; }
    }
}
