using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*���Ź���ҵ���߼���*/
    public class bllNotice{
        /*������Ź���*/
        public static bool AddNotice(ENTITY.Notice notice)
        {
            return DAL.dalNotice.AddNotice(notice);
        }

        /*����noticeId��ȡĳ�����Ź����¼*/
        public static ENTITY.Notice getSomeNotice(int noticeId)
        {
            return DAL.dalNotice.getSomeNotice(noticeId);
        }

        /*�������Ź���*/
        public static bool EditNotice(ENTITY.Notice notice)
        {
            return DAL.dalNotice.EditNotice(notice);
        }

        /*ɾ�����Ź���*/
        public static bool DelNotice(string p)
        {
            return DAL.dalNotice.DelNotice(p);
        }

        /*��ѯ���Ź���*/
        public static System.Data.DataSet GetNotice(string strWhere)
        {
            return DAL.dalNotice.GetNotice(strWhere);
        }

        /*����������ҳ��ѯ���Ź���*/
        public static System.Data.DataTable GetNotice(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalNotice.GetNotice(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е����Ź���*/
        public static System.Data.DataSet getAllNotice()
        {
            return DAL.dalNotice.getAllNotice();
        }
    }
}
