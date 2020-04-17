using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using Models.Ext;

namespace 仓库信息系统管理.Controllers
{
    public class WorkController : Controller
    {
        //
        // GET: /Work/

        public ActionResult Index()
        {
            List<Product> prods = new WorkManage().QueryAllProductsService();
            return View("Product",prods);
        }

        public ActionResult showDetail(string ProductId)
        {
            List<RecordsExt> recs = new WorkManage().QueryAllRecordsByProductId(ProductId);
            return View("Records", recs);
        }

        public ActionResult AddRecords(Product rec)
        {
            List<Product> prods = new WorkManage().QueryAllProductsService();
            return View("AddRecords",prods);
        }
  
        public ActionResult updateRecord()
        {

            //string ProductId = Request.Params["ProductId"].ToString();
            //string ProductName = Request.Params["ProductName"].ToString();
            //string Customer = Request.Params["Customer"].ToString();
            //int InNum = Convert.ToInt32(Request.Params["InNum"]);
            //int OutNum = Convert.ToInt32(Request.Params["OutNum"]);
            //string userName = ((Login)Session["CurrentUser"]).UserName;
            //DateTime Time = DateTime.Now;
            RecordsExt recd = new RecordsExt()
            {
                ProductId = Request.Params["ProductId"].ToString(),
                ProductName = Request.Params["ProductName"].ToString(),
                Customer = Request.Params["Customer"].ToString(),
                InNum = Convert.ToInt32(Request.Params["InNum"]),
                OutNum = Convert.ToInt32(Request.Params["OutNum"]),
                userName = ((Login)Session["CurrentUser"]).UserName,
                Time = DateTime.Now
            };
            int result = new WorkManage().InsertRecord(recd);
            if (result > 0)
                return Content("更新成功！");
            return Content("更新失败！");
        }

        public ActionResult ShowAddProduct()
        {
            return View("AddProduct");
        }

        [HttpPost]
        public ActionResult Addproduct(Product prod)
        {
            if (ModelState.IsValid)
            {
                if (new WorkManage().QueryIsExistProduct(prod.ProductId) != 0)
                {
                    ModelState.AddModelError("IsExist", "该产品已存在！");
                    return View();
                }
                int result = new WorkManage().AddProduct(prod);
                if (result > 0)
                    return Content("<script>alert('添加成功!');window.loction='" + Url.Content("/work") + "'</script>");
                else
                    return Content("<script>alert('添加失败!');window.loction='" + Url.Content("/work/ShowAddProduct") + "'</script>");
            }
            return View();
        }
    }
}
