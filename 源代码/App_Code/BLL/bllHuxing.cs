using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*����ҵ���߼���*/
    public class bllHuxing{
        /*��ӻ���*/
        public static bool AddHuxing(ENTITY.Huxing huxing)
        {
            return DAL.dalHuxing.AddHuxing(huxing);
        }

        /*����huxingId��ȡĳ�����ͼ�¼*/
        public static ENTITY.Huxing getSomeHuxing(int huxingId)
        {
            return DAL.dalHuxing.getSomeHuxing(huxingId);
        }

        /*���»���*/
        public static bool EditHuxing(ENTITY.Huxing huxing)
        {
            return DAL.dalHuxing.EditHuxing(huxing);
        }

        /*ɾ������*/
        public static bool DelHuxing(string p)
        {
            return DAL.dalHuxing.DelHuxing(p);
        }

        /*��ѯ����*/
        public static System.Data.DataSet GetHuxing(string strWhere)
        {
            return DAL.dalHuxing.GetHuxing(strWhere);
        }

        /*����������ҳ��ѯ����*/
        public static System.Data.DataTable GetHuxing(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalHuxing.GetHuxing(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĻ���*/
        public static System.Data.DataSet getAllHuxing()
        {
            return DAL.dalHuxing.getAllHuxing();
        }
    }
}
