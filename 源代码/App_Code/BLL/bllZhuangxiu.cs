using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*װ�޳̶�ҵ���߼���*/
    public class bllZhuangxiu{
        /*���װ�޳̶�*/
        public static bool AddZhuangxiu(ENTITY.Zhuangxiu zhuangxiu)
        {
            return DAL.dalZhuangxiu.AddZhuangxiu(zhuangxiu);
        }

        /*����zhuangxiuId��ȡĳ��װ�޳̶ȼ�¼*/
        public static ENTITY.Zhuangxiu getSomeZhuangxiu(int zhuangxiuId)
        {
            return DAL.dalZhuangxiu.getSomeZhuangxiu(zhuangxiuId);
        }

        /*����װ�޳̶�*/
        public static bool EditZhuangxiu(ENTITY.Zhuangxiu zhuangxiu)
        {
            return DAL.dalZhuangxiu.EditZhuangxiu(zhuangxiu);
        }

        /*ɾ��װ�޳̶�*/
        public static bool DelZhuangxiu(string p)
        {
            return DAL.dalZhuangxiu.DelZhuangxiu(p);
        }

        /*��ѯװ�޳̶�*/
        public static System.Data.DataSet GetZhuangxiu(string strWhere)
        {
            return DAL.dalZhuangxiu.GetZhuangxiu(strWhere);
        }

        /*����������ҳ��ѯװ�޳̶�*/
        public static System.Data.DataTable GetZhuangxiu(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalZhuangxiu.GetZhuangxiu(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�װ�޳̶�*/
        public static System.Data.DataSet getAllZhuangxiu()
        {
            return DAL.dalZhuangxiu.getAllZhuangxiu();
        }
    }
}
