using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*新闻公告业务逻辑层实现*/
    public class dalNotice
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加新闻公告实现*/
        public static bool AddNotice(ENTITY.Notice notice)
        {
            string sql = "insert into Notice(title,content,publishDate) values(@title,@content,@publishDate)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@publishDate",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = notice.title; //标题
            parm[1].Value = notice.content; //公告内容
            parm[2].Value = notice.publishDate; //发布时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据noticeId获取某条新闻公告记录*/
        public static ENTITY.Notice getSomeNotice(int noticeId)
        {
            /*构建查询sql*/
            string sql = "select * from Notice where noticeId=" + noticeId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Notice notice = null;
            /*如果查询存在记录，就包装到对象中返回*/
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

        /*更新新闻公告实现*/
        public static bool EditNotice(ENTITY.Notice notice)
        {
            string sql = "update Notice set title=@title,content=@content,publishDate=@publishDate where noticeId=@noticeId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@publishDate",SqlDbType.DateTime),
             new SqlParameter("@noticeId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = notice.title;
            parm[1].Value = notice.content;
            parm[2].Value = notice.publishDate;
            parm[3].Value = notice.noticeId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除新闻公告*/
        public static bool DelNotice(string p)
        {
            string sql = "delete from Notice where noticeId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询新闻公告*/
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

        /*查询新闻公告*/
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
