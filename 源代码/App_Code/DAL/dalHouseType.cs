using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*房屋类型业务逻辑层实现*/
    public class dalHouseType
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加房屋类型实现*/
        public static bool AddHouseType(ENTITY.HouseType houseType)
        {
            string sql = "insert into HouseType(typeName) values(@typeName)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@typeName",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = houseType.typeName; //类型名称

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据typeId获取某条房屋类型记录*/
        public static ENTITY.HouseType getSomeHouseType(int typeId)
        {
            /*构建查询sql*/
            string sql = "select * from HouseType where typeId=" + typeId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.HouseType houseType = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                houseType = new ENTITY.HouseType();
                houseType.typeId = Convert.ToInt32(DataRead["typeId"]);
                houseType.typeName = DataRead["typeName"].ToString();
            }
            return houseType;
        }

        /*更新房屋类型实现*/
        public static bool EditHouseType(ENTITY.HouseType houseType)
        {
            string sql = "update HouseType set typeName=@typeName where typeId=@typeId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@typeName",SqlDbType.VarChar),
             new SqlParameter("@typeId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = houseType.typeName;
            parm[1].Value = houseType.typeId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除房屋类型*/
        public static bool DelHouseType(string p)
        {
            string sql = "delete from HouseType where typeId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询房屋类型*/
        public static DataSet GetHouseType(string strWhere)
        {
            try
            {
                string strSql = "select * from HouseType" + strWhere + " order by typeId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询房屋类型*/
        public static System.Data.DataTable GetHouseType(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from HouseType";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "typeId", strShow, strSql, strWhere, " typeId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllHouseType()
        {
            try
            {
                string strSql = "select * from HouseType";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
