using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*装修程度业务逻辑层*/
    public class bllZhuangxiu{
        /*添加装修程度*/
        public static bool AddZhuangxiu(ENTITY.Zhuangxiu zhuangxiu)
        {
            return DAL.dalZhuangxiu.AddZhuangxiu(zhuangxiu);
        }

        /*根据zhuangxiuId获取某条装修程度记录*/
        public static ENTITY.Zhuangxiu getSomeZhuangxiu(int zhuangxiuId)
        {
            return DAL.dalZhuangxiu.getSomeZhuangxiu(zhuangxiuId);
        }

        /*更新装修程度*/
        public static bool EditZhuangxiu(ENTITY.Zhuangxiu zhuangxiu)
        {
            return DAL.dalZhuangxiu.EditZhuangxiu(zhuangxiu);
        }

        /*删除装修程度*/
        public static bool DelZhuangxiu(string p)
        {
            return DAL.dalZhuangxiu.DelZhuangxiu(p);
        }

        /*查询装修程度*/
        public static System.Data.DataSet GetZhuangxiu(string strWhere)
        {
            return DAL.dalZhuangxiu.GetZhuangxiu(strWhere);
        }

        /*根据条件分页查询装修程度*/
        public static System.Data.DataTable GetZhuangxiu(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalZhuangxiu.GetZhuangxiu(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的装修程度*/
        public static System.Data.DataSet getAllZhuangxiu()
        {
            return DAL.dalZhuangxiu.getAllZhuangxiu();
        }
    }
}
