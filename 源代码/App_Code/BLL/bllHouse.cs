using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��Դҵ���߼���*/
    public class bllHouse{
        /*��ӷ�Դ*/
        public static bool AddHouse(ENTITY.House house)
        {
            return DAL.dalHouse.AddHouse(house);
        }

        /*����houseId��ȡĳ����Դ��¼*/
        public static ENTITY.House getSomeHouse(int houseId)
        {
            return DAL.dalHouse.getSomeHouse(houseId);
        }

        /*���·�Դ*/
        public static bool EditHouse(ENTITY.House house)
        {
            return DAL.dalHouse.EditHouse(house);
        }

        /*ɾ����Դ*/
        public static bool DelHouse(string p)
        {
            return DAL.dalHouse.DelHouse(p);
        }

        /*��ѯ��Դ*/
        public static System.Data.DataSet GetHouse(string strWhere)
        {
            return DAL.dalHouse.GetHouse(strWhere);
        }

        /*����������ҳ��ѯ��Դ*/
        public static System.Data.DataTable GetHouse(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalHouse.GetHouse(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еķ�Դ*/
        public static System.Data.DataSet getAllHouse()
        {
            return DAL.dalHouse.getAllHouse();
        }
    }
}
