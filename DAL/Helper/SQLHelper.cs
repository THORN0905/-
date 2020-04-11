using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DAL.Helper
{
    public class SQLHelper
    {
        static private string connStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();
        /// <summary>
        /// 对数据库执行增加 删除 修改操作
        /// </summary>
        /// <param name="sql">sql语句或存储过程名称</param>
        /// <param name="param">参数</param>
        /// <param name="isStoreProcedure">是否是存储过程</param>
        /// <returns>返回更新结果</returns>
        public int update(string sql, SqlParameter[] param, bool isStoreProcedure)
        {
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (isStoreProcedure)
                cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                writeLog("在调用public int update(string sql, SqlParameter[] param, bool isStoreProcedure)时出现错误" + ex.Message);
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }


        /// <summary>
        /// 执行返回单一结果的查询
        /// </summary>
        /// <param name="sql">sql语句或储存过程</param>
        /// <param name="param">参数</param>
        /// <param name="isStoreProcedure">判断是否是储存过程</param>
        /// <returns>返回查询的单一结果</returns>
        public object QuerySingleResult(string sql,SqlParameter[] param,bool isStoreProcedure)
        {
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (isStoreProcedure)
                cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                writeLog("在调用public object QuerySingleResult(string sql,SqlParameter[] param,bool isStoreProcedure)时出现错误" + ex.Message);
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        
        /// <summary>
        /// 执行返回结果集的查询
        /// </summary>
        /// <param name="sql">sql语句或储存过程</param>
        /// <param name="param">参数</param>
        /// <param name="isStoreProcedure">判断是否是储存过程</param>
        /// <returns>返回查询的结果集</returns>
        public SqlDataReader queryAllResult(string sql, SqlParameter[] param, bool isStoreProcedure)
        {
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (isStoreProcedure)
                cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                writeLog("在调用public SqlDataReader queryAllResult(string sql, SqlParameter[] param, bool isStoreProcedure)时出现错误" + ex.Message);
                return null;
            }
        }

        #region 写入日志
        protected void writeLog(string errorMsg)
        {
            FileStream fs = new FileStream("D:/ASP.NET文件/仓库信息系统管理日志/ProjectLog.log", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString() + "  " + errorMsg);
            sw.Close();
            fs.Close();
        }
        #endregion
    }
}
