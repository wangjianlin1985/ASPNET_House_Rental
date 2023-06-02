using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��������ҵ���߼���ʵ��*/
    public class dalHouseType
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��ӷ�������ʵ��*/
        public static bool AddHouseType(ENTITY.HouseType houseType)
        {
            string sql = "insert into HouseType(typeName) values(@typeName)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@typeName",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = houseType.typeName; //��������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����typeId��ȡĳ���������ͼ�¼*/
        public static ENTITY.HouseType getSomeHouseType(int typeId)
        {
            /*������ѯsql*/
            string sql = "select * from HouseType where typeId=" + typeId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.HouseType houseType = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                houseType = new ENTITY.HouseType();
                houseType.typeId = Convert.ToInt32(DataRead["typeId"]);
                houseType.typeName = DataRead["typeName"].ToString();
            }
            return houseType;
        }

        /*���·�������ʵ��*/
        public static bool EditHouseType(ENTITY.HouseType houseType)
        {
            string sql = "update HouseType set typeName=@typeName where typeId=@typeId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@typeName",SqlDbType.VarChar),
             new SqlParameter("@typeId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = houseType.typeName;
            parm[1].Value = houseType.typeId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����������*/
        public static bool DelHouseType(string p)
        {
            string sql = "delete from HouseType where typeId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��������*/
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

        /*��ѯ��������*/
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
