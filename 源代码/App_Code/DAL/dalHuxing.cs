using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*����ҵ���߼���ʵ��*/
    public class dalHuxing
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��ӻ���ʵ��*/
        public static bool AddHuxing(ENTITY.Huxing huxing)
        {
            string sql = "insert into Huxing(huxingName) values(@huxingName)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@huxingName",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = huxing.huxingName; //��������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����huxingId��ȡĳ�����ͼ�¼*/
        public static ENTITY.Huxing getSomeHuxing(int huxingId)
        {
            /*������ѯsql*/
            string sql = "select * from Huxing where huxingId=" + huxingId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Huxing huxing = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                huxing = new ENTITY.Huxing();
                huxing.huxingId = Convert.ToInt32(DataRead["huxingId"]);
                huxing.huxingName = DataRead["huxingName"].ToString();
            }
            return huxing;
        }

        /*���»���ʵ��*/
        public static bool EditHuxing(ENTITY.Huxing huxing)
        {
            string sql = "update Huxing set huxingName=@huxingName where huxingId=@huxingId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@huxingName",SqlDbType.VarChar),
             new SqlParameter("@huxingId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = huxing.huxingName;
            parm[1].Value = huxing.huxingId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ������*/
        public static bool DelHuxing(string p)
        {
            string sql = "delete from Huxing where huxingId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ����*/
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

        /*��ѯ����*/
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
