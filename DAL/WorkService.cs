using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;
using Models.Ext;
using System.Data.SqlClient;

namespace DAL
{
    public class WorkService
    {
        /// <summary>
        /// 查询所有产品信息
        /// </summary>
        /// <returns></returns>
        public List<Product> QueryAllProducts()
        {
            string sql = "Select ProductId,ProductName,Customer,SumIn,SumOut,Plans,PS,(SumIn-SumOut) as Inventory from Product";
            SqlDataReader result =  new Helper.SQLHelper().queryAllResult(sql, false);
            List<Product> prods = new List<Product>();
            while (result.Read())
            {
                prods.Add(new Product()
                {
                    ProductId = result["ProductId"].ToString(),
                    ProductName = result["ProductName"].ToString(),
                    Customer = result["Customer"].ToString(),
                    SumIn = Convert.ToInt32(result["SumIn"]),
                    SumOut = Convert.ToInt32(result["SumOut"]),
                    Plans = Convert.ToInt32(result["Plans"]),
                    PS = result["PS"].ToString(),
                    Inventory = Convert.ToInt32(result["Inventory"])
                });
            }
            return prods;
        }

        /// <summary>
        /// 查询某一产品的记录
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public List<RecordsExt> QueryAllRecords(string ProductId)
        {
            string sql = "select Id,InNum,OutNum,Time,userName,Plans,ProductName,Customer, (SumIn-SumOut) as Inventory" 
                +" from Records join Product on Records.ProductId=Product.ProductId where Records.ProductId=@ProductId";
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@ProductId",ProductId)
            };
            List<RecordsExt> recs = new List<RecordsExt>();
            SqlDataReader result = new Helper.SQLHelper().queryAllResult(sql, param, false);
            while (result.Read())
            {
                recs.Add(new RecordsExt()
                {
                    Id = Convert.ToInt32(result["Id"]),
                    ProductId = ProductId,
                    InNum = Convert.ToInt32(result["InNum"]),
                    OutNum = Convert.ToInt32(result["OutNum"]),
                    Time = Convert.ToDateTime(result["Time"]),
                    Plans=Convert.ToInt32(result["Plans"]),
                    userName = result["userName"].ToString(),
                    ProductName = result["ProductName"].ToString(),
                    Customer = result["Customer"].ToString(),
                    Inventory = Convert.ToInt32(result["Inventory"])
                });
            }
            return recs;
        }

        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="rec"></param>
        /// <returns></returns>
        public int InsertRecord(RecordsExt rec)
        {
            string sql1 = "insert into Records (ProductId,InNum,OutNum,Time,UserName) Values(@ProductId,@InNum,@OutNum,@Time,@UserName)";
            SqlParameter[] param1 = new SqlParameter[] {
                    new SqlParameter("@ProductId",rec.ProductId),
                    new SqlParameter("@InNum", rec.InNum),
                    new SqlParameter("@OutNum",rec.OutNum),
                    new SqlParameter("@Time",rec.Time),
                    new SqlParameter("@UserName",rec.userName)
                };
            int result1 = new Helper.SQLHelper().update(sql1, param1, false);
            string sql2 = "update Product set SumIn=SumIn+@InNum,SumOut=SumOut+@OutNum,Inventory=Inventory+@InNum-@OutNum where ProductId=@ProductId";
            SqlParameter[] param2 = new SqlParameter[] {
                    new SqlParameter("@InNum",rec.InNum),
                    new SqlParameter("@OutNum",rec.OutNum),
                    new SqlParameter("@ProductId",rec.ProductId)
            };
            int result2 = new Helper.SQLHelper().update(sql2, param2, false);
            if (result1 > 0 && result2 > 0)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// 通过Id查询产品名称
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public int QueryProductById(string ProductId)
        {
            string sql = "select ProductName from Product where ProductId=@ProductId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ProductId",ProductId)
            };
            object result = new Helper.SQLHelper().QuerySingleResult(sql, param, false);
            if (result == null)
                return 0;
            else return 1;
        }

        public int AddProduct(Product prod)
        {
            string sql = "insert into Product (ProductId,ProductName,Customer,Inventory,Plans,SumIn,SumOut) "
                                  + " values (@ProductId,@ProductName,@Customer,@Inventory,@Plans,@SumIn,@SumOut)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ProductId",prod.ProductId),
                new SqlParameter("@ProductName",prod.ProductName),
                new SqlParameter("@Customer",prod.Customer),
                new SqlParameter("@Inventory",prod.Inventory),
                new SqlParameter("@Plans",prod.Plans),
                new SqlParameter("@SumIn",prod.SumIn),
                new SqlParameter("@SumOut",prod.SumOut)
            };
            int result = new Helper.SQLHelper().update(sql, param, false);
            return result;
        }
    }
}
