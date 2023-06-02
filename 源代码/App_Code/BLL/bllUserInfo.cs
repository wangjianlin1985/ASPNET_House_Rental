using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�û�ҵ���߼���*/
    public class bllUserInfo{
        /*����û�*/
        public static bool AddUserInfo(ENTITY.UserInfo userInfo)
        {
            return DAL.dalUserInfo.AddUserInfo(userInfo);
        }

        /*����user_name��ȡĳ���û���¼*/
        public static ENTITY.UserInfo getSomeUserInfo(string user_name)
        {
            return DAL.dalUserInfo.getSomeUserInfo(user_name);
        }

        /*�����û�*/
        public static bool EditUserInfo(ENTITY.UserInfo userInfo)
        {
            return DAL.dalUserInfo.EditUserInfo(userInfo);
        }

        /*ɾ���û�*/
        public static bool DelUserInfo(string p)
        {
            return DAL.dalUserInfo.DelUserInfo(p);
        }

        /*��ѯ�û�*/
        public static System.Data.DataSet GetUserInfo(string strWhere)
        {
            return DAL.dalUserInfo.GetUserInfo(strWhere);
        }

        /*����������ҳ��ѯ�û�*/
        public static System.Data.DataTable GetUserInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalUserInfo.GetUserInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е��û�*/
        public static System.Data.DataSet getAllUserInfo()
        {
            return DAL.dalUserInfo.getAllUserInfo();
        }
    }
}
