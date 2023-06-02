using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*户型业务逻辑层*/
    public class bllHuxing{
        /*添加户型*/
        public static bool AddHuxing(ENTITY.Huxing huxing)
        {
            return DAL.dalHuxing.AddHuxing(huxing);
        }

        /*根据huxingId获取某条户型记录*/
        public static ENTITY.Huxing getSomeHuxing(int huxingId)
        {
            return DAL.dalHuxing.getSomeHuxing(huxingId);
        }

        /*更新户型*/
        public static bool EditHuxing(ENTITY.Huxing huxing)
        {
            return DAL.dalHuxing.EditHuxing(huxing);
        }

        /*删除户型*/
        public static bool DelHuxing(string p)
        {
            return DAL.dalHuxing.DelHuxing(p);
        }

        /*查询户型*/
        public static System.Data.DataSet GetHuxing(string strWhere)
        {
            return DAL.dalHuxing.GetHuxing(strWhere);
        }

        /*根据条件分页查询户型*/
        public static System.Data.DataTable GetHuxing(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalHuxing.GetHuxing(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的户型*/
        public static System.Data.DataSet getAllHuxing()
        {
            return DAL.dalHuxing.getAllHuxing();
        }
    }
}
