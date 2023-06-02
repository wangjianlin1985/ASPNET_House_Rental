using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*装修程度业务逻辑层实现*/
    public class dalZhuangxiu
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加装修程度实现*/
        public static bool AddZhuangxiu(ENTITY.Zhuangxiu zhuangxiu)
        {
            string sql = "insert into Zhuangxiu(zhuangxiuName) values(@zhuangxiuName)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@zhuangxiuName",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = zhuangxiu.zhuangxiuName; //装修程度

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据zhuangxiuId获取某条装修程度记录*/
        public static ENTITY.Zhuangxiu getSomeZhuangxiu(int zhuangxiuId)
        {
            /*构建查询sql*/
            string sql = "select * from Zhuangxiu where zhuangxiuId=" + zhuangxiuId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Zhuangxiu zhuangxiu = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                zhuangxiu = new ENTITY.Zhuangxiu();
                zhuangxiu.zhuangxiuId = Convert.ToInt32(DataRead["zhuangxiuId"]);
                zhuangxiu.zhuangxiuName = DataRead["zhuangxiuName"].ToString();
            }
            return zhuangxiu;
        }

        /*更新装修程度实现*/
        public static bool EditZhuangxiu(ENTITY.Zhuangxiu zhuangxiu)
        {
            string sql = "update Zhuangxiu set zhuangxiuName=@zhuangxiuName where zhuangxiuId=@zhuangxiuId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@zhuangxiuName",SqlDbType.VarChar),
             new SqlParameter("@zhuangxiuId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = zhuangxiu.zhuangxiuName;
            parm[1].Value = zhuangxiu.zhuangxiuId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除装修程度*/
        public static bool DelZhuangxiu(string p)
        {
            string sql = "delete from Zhuangxiu where zhuangxiuId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询装修程度*/
        public static DataSet GetZhuangxiu(string strWhere)
        {
            try
            {
                string strSql = "select * from Zhuangxiu" + strWhere + " order by zhuangxiuId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询装修程度*/
        public static System.Data.DataTable GetZhuangxiu(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Zhuangxiu";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "zhuangxiuId", strShow, strSql, strWhere, " zhuangxiuId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllZhuangxiu()
        {
            try
            {
                string strSql = "select * from Zhuangxiu";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
