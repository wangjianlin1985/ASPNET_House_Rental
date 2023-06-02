using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��������ҵ���߼���*/
    public class bllHouseType{
        /*��ӷ�������*/
        public static bool AddHouseType(ENTITY.HouseType houseType)
        {
            return DAL.dalHouseType.AddHouseType(houseType);
        }

        /*����typeId��ȡĳ���������ͼ�¼*/
        public static ENTITY.HouseType getSomeHouseType(int typeId)
        {
            return DAL.dalHouseType.getSomeHouseType(typeId);
        }

        /*���·�������*/
        public static bool EditHouseType(ENTITY.HouseType houseType)
        {
            return DAL.dalHouseType.EditHouseType(houseType);
        }

        /*ɾ����������*/
        public static bool DelHouseType(string p)
        {
            return DAL.dalHouseType.DelHouseType(p);
        }

        /*��ѯ��������*/
        public static System.Data.DataSet GetHouseType(string strWhere)
        {
            return DAL.dalHouseType.GetHouseType(strWhere);
        }

        /*����������ҳ��ѯ��������*/
        public static System.Data.DataTable GetHouseType(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalHouseType.GetHouseType(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еķ�������*/
        public static System.Data.DataSet getAllHouseType()
        {
            return DAL.dalHouseType.getAllHouseType();
        }
    }
}
