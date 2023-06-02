using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*户型业务逻辑层实现*/
    public class dalHuxing
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加户型实现*/
        public static bool AddHuxing(ENTITY.Huxing huxing)
        {
            string sql = "insert into Huxing(huxingName) values(@huxingName)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@huxingName",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = huxing.huxingName; //户型名称

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据huxingId获取某条户型记录*/
        public static ENTITY.Huxing getSomeHuxing(int huxingId)
        {
            /*构建查询sql*/
            string sql = "select * from Huxing where huxingId=" + huxingId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Huxing huxing = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                huxing = new ENTITY.Huxing();
                huxing.huxingId = Convert.ToInt32(DataRead["huxingId"]);
                huxing.huxingName = DataRead["huxingName"].ToString();
            }
            return huxing;
        }

        /*更新户型实现*/
        public static bool EditHuxing(ENTITY.Huxing huxing)
        {
            string sql = "update Huxing set huxingName=@huxingName where huxingId=@huxingId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@huxingName",SqlDbType.VarChar),
             new SqlParameter("@huxingId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = huxing.huxingName;
            parm[1].Value = huxing.huxingId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除户型*/
        public static bool DelHuxing(string p)
        {
            string sql = "delete from Huxing where huxingId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询户型*/
        public static DataSet GetHuxing(string strWhere)
        {
            try
            {
                string strSql = "select * from Huxing" + strWhere + " order by huxingId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询户型*/
        public static System.Data.DataTable GetHuxing(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Huxing";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "huxingId", strShow, strSql, strWhere, " huxingId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllHuxing()
        {
            try
            {
                string strSql = "select * from Huxing";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
