using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*װ�޳̶�ҵ���߼���ʵ��*/
    public class dalZhuangxiu
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*���װ�޳̶�ʵ��*/
        public static bool AddZhuangxiu(ENTITY.Zhuangxiu zhuangxiu)
        {
            string sql = "insert into Zhuangxiu(zhuangxiuName) values(@zhuangxiuName)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@zhuangxiuName",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = zhuangxiu.zhuangxiuName; //װ�޳̶�

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����zhuangxiuId��ȡĳ��װ�޳̶ȼ�¼*/
        public static ENTITY.Zhuangxiu getSomeZhuangxiu(int zhuangxiuId)
        {
            /*������ѯsql*/
            string sql = "select * from Zhuangxiu where zhuangxiuId=" + zhuangxiuId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Zhuangxiu zhuangxiu = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                zhuangxiu = new ENTITY.Zhuangxiu();
                zhuangxiu.zhuangxiuId = Convert.ToInt32(DataRead["zhuangxiuId"]);
                zhuangxiu.zhuangxiuName = DataRead["zhuangxiuName"].ToString();
            }
            return zhuangxiu;
        }

        /*����װ�޳̶�ʵ��*/
        public static bool EditZhuangxiu(ENTITY.Zhuangxiu zhuangxiu)
        {
            string sql = "update Zhuangxiu set zhuangxiuName=@zhuangxiuName where zhuangxiuId=@zhuangxiuId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@zhuangxiuName",SqlDbType.VarChar),
             new SqlParameter("@zhuangxiuId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = zhuangxiu.zhuangxiuName;
            parm[1].Value = zhuangxiu.zhuangxiuId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��װ�޳̶�*/
        public static bool DelZhuangxiu(string p)
        {
            string sql = "delete from Zhuangxiu where zhuangxiuId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯװ�޳̶�*/
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

        /*��ѯװ�޳̶�*/
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
