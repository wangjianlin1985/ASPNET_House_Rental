using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*房屋类型业务逻辑层*/
    public class bllHouseType{
        /*添加房屋类型*/
        public static bool AddHouseType(ENTITY.HouseType houseType)
        {
            return DAL.dalHouseType.AddHouseType(houseType);
        }

        /*根据typeId获取某条房屋类型记录*/
        public static ENTITY.HouseType getSomeHouseType(int typeId)
        {
            return DAL.dalHouseType.getSomeHouseType(typeId);
        }

        /*更新房屋类型*/
        public static bool EditHouseType(ENTITY.HouseType houseType)
        {
            return DAL.dalHouseType.EditHouseType(houseType);
        }

        /*删除房屋类型*/
        public static bool DelHouseType(string p)
        {
            return DAL.dalHouseType.DelHouseType(p);
        }

        /*查询房屋类型*/
        public static System.Data.DataSet GetHouseType(string strWhere)
        {
            return DAL.dalHouseType.GetHouseType(strWhere);
        }

        /*根据条件分页查询房屋类型*/
        public static System.Data.DataTable GetHouseType(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalHouseType.GetHouseType(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的房屋类型*/
        public static System.Data.DataSet getAllHouseType()
        {
            return DAL.dalHouseType.getAllHouseType();
        }
    }
}
