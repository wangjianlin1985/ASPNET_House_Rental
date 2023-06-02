using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*���Ź���ҵ���߼���ʵ��*/
    public class dalNotice
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*������Ź���ʵ��*/
        public static bool AddNotice(ENTITY.Notice notice)
        {
            string sql = "insert into Notice(title,content,publishDate) values(@title,@content,@publishDate)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@publishDate",SqlDbType.DateTime)
            };
            /*��������ֵ*/
            parm[0].Value = notice.title; //����
            parm[1].Value = notice.content; //��������
            parm[2].Value = notice.publishDate; //����ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����noticeId��ȡĳ�����Ź����¼*/
        public static ENTITY.Notice getSomeNotice(int noticeId)
        {
            /*������ѯsql*/
            string sql = "select * from Notice where noticeId=" + noticeId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Notice notice = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                notice = new ENTITY.Notice();
                notice.noticeId = Convert.ToInt32(DataRead["noticeId"]);
                notice.title = DataRead["title"].ToString();
                notice.content = DataRead["content"].ToString();
                notice.publishDate = Convert.ToDateTime(DataRead["publishDate"].ToString());
            }
            return notice;
        }

        /*�������Ź���ʵ��*/
        public static bool EditNotice(ENTITY.Notice notice)
        {
            string sql = "update Notice set title=@title,content=@content,publishDate=@publishDate where noticeId=@noticeId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@publishDate",SqlDbType.DateTime),
             new SqlParameter("@noticeId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = notice.title;
            parm[1].Value = notice.content;
            parm[2].Value = notice.publishDate;
            parm[3].Value = notice.noticeId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ�����Ź���*/
        public static bool DelNotice(string p)
        {
            string sql = "delete from Notice where noticeId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ���Ź���*/
        public static DataSet GetNotice(string strWhere)
        {
            try
            {
                string strSql = "select * from Notice" + strWhere + " order by noticeId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ���Ź���*/
        public static System.Data.DataTable GetNotice(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Notice";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "noticeId", strShow, strSql, strWhere, " noticeId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllNotice()
        {
            try
            {
                string strSql = "select * from Notice";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
