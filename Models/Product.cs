using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    [Serializable()]
    public class Product
    {
        [DisplayName("产品编号")]
        [Required(ErrorMessage = "{0}不得为空")]
        public string ProductId { set; get; }
        [DisplayName("产品名称")]
        [Required(ErrorMessage = "{0}不得为空")]
        public string ProductName { set; get; }
        [DisplayName("客户名称")]
        [Required(ErrorMessage = "{0}不得为空")]
        public string Customer { set; get; }
        public int Inventory { set; get; }
        [DisplayName("生产计划数")]
        [Required(ErrorMessage = "{0}不得为空")]
        [RegularExpression(@"^[1-9]\d*$",ErrorMessage = "请输入一个正整数！")]
        public int Plans { set; get; }
        public int SumIn { set; get; }
        public int SumOut { set; get; }
        public string PS { set; get; }
    }
}
