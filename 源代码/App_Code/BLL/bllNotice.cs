using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*新闻公告业务逻辑层*/
    public class bllNotice{
        /*添加新闻公告*/
        public static bool AddNotice(ENTITY.Notice notice)
        {
            return DAL.dalNotice.AddNotice(notice);
        }

        /*根据noticeId获取某条新闻公告记录*/
        public static ENTITY.Notice getSomeNotice(int noticeId)
        {
            return DAL.dalNotice.getSomeNotice(noticeId);
        }

        /*更新新闻公告*/
        public static bool EditNotice(ENTITY.Notice notice)
        {
            return DAL.dalNotice.EditNotice(notice);
        }

        /*删除新闻公告*/
        public static bool DelNotice(string p)
        {
            return DAL.dalNotice.DelNotice(p);
        }

        /*查询新闻公告*/
        public static System.Data.DataSet GetNotice(string strWhere)
        {
            return DAL.dalNotice.GetNotice(strWhere);
        }

        /*根据条件分页查询新闻公告*/
        public static System.Data.DataTable GetNotice(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalNotice.GetNotice(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的新闻公告*/
        public static System.Data.DataSet getAllNotice()
        {
            return DAL.dalNotice.getAllNotice();
        }
    }
}
