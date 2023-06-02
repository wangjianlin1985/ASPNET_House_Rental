using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*房源业务逻辑层*/
    public class bllHouse{
        /*添加房源*/
        public static bool AddHouse(ENTITY.House house)
        {
            return DAL.dalHouse.AddHouse(house);
        }

        /*根据houseId获取某条房源记录*/
        public static ENTITY.House getSomeHouse(int houseId)
        {
            return DAL.dalHouse.getSomeHouse(houseId);
        }

        /*更新房源*/
        public static bool EditHouse(ENTITY.House house)
        {
            return DAL.dalHouse.EditHouse(house);
        }

        /*删除房源*/
        public static bool DelHouse(string p)
        {
            return DAL.dalHouse.DelHouse(p);
        }

        /*查询房源*/
        public static System.Data.DataSet GetHouse(string strWhere)
        {
            return DAL.dalHouse.GetHouse(strWhere);
        }

        /*根据条件分页查询房源*/
        public static System.Data.DataTable GetHouse(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalHouse.GetHouse(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的房源*/
        public static System.Data.DataSet getAllHouse()
        {
            return DAL.dalHouse.getAllHouse();
        }
    }
}
