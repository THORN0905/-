using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
using Models.Ext;

namespace BLL
{
    public class WorkManage
    {
        /// <summary>
        /// 查询所有产品信息
        /// </summary>
        /// <returns></returns>
        public List<Product> QueryAllProductsService()
        {
            return new WorkService().QueryAllProducts();
        }

        /// <summary>
        /// 根据产品Id查询产品记录
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public List<RecordsExt> QueryAllRecordsByProductId(string ProductId)
        {
            return new WorkService().QueryAllRecords(ProductId);
        }

        /// <summary>
        /// 新增入库出库记录
        /// </summary>
        /// <param name="rec"></param>
        /// <returns></returns>
        public int InsertRecord(RecordsExt rec)
        {
            return new WorkService().InsertRecord(rec);
        }

        public int QueryIsExistProduct(string ProductId)
        {
            return new WorkService().QueryProductById(ProductId);
        }

        public int AddProduct(Product prod)
        {
            return new WorkService().AddProduct(prod);
        }
    }
}
