using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*用户业务逻辑层实现*/
    public class dalUserInfo
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加用户实现*/
        public static bool AddUserInfo(ENTITY.UserInfo userInfo)
        {
            string sql = "insert into UserInfo(user_name,password,name,gender,birthDate,userPhoto,telephone,email,address,regTime) values(@user_name,@password,@name,@gender,@birthDate,@userPhoto,@telephone,@email,@address,@regTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@user_name",SqlDbType.VarChar),
             new SqlParameter("@password",SqlDbType.VarChar),
             new SqlParameter("@name",SqlDbType.VarChar),
             new SqlParameter("@gender",SqlDbType.VarChar),
             new SqlParameter("@birthDate",SqlDbType.DateTime),
             new SqlParameter("@userPhoto",SqlDbType.VarChar),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@email",SqlDbType.VarChar),
             new SqlParameter("@address",SqlDbType.VarChar),
             new SqlParameter("@regTime",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = userInfo.user_name; //用户名
            parm[1].Value = userInfo.password; //登录密码
            parm[2].Value = userInfo.name; //姓名
            parm[3].Value = userInfo.gender; //性别
            parm[4].Value = userInfo.birthDate; //出生日期
            parm[5].Value = userInfo.userPhoto; //用户照片
            parm[6].Value = userInfo.telephone; //联系电话
            parm[7].Value = userInfo.email; //邮箱
            parm[8].Value = userInfo.address; //家庭地址
            parm[9].Value = userInfo.regTime; //注册时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据user_name获取某条用户记录*/
        public static ENTITY.UserInfo getSomeUserInfo(string user_name)
        {
            /*构建查询sql*/
            string sql = "select * from UserInfo where user_name='" + user_name + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.UserInfo userInfo = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                userInfo = new ENTITY.UserInfo();
                userInfo.user_name = DataRead["user_name"].ToString();
                userInfo.password = DataRead["password"].ToString();
                userInfo.name = DataRead["name"].ToString();
                userInfo.gender = DataRead["gender"].ToString();
                userInfo.birthDate = Convert.ToDateTime(DataRead["birthDate"].ToString());
                userInfo.userPhoto = DataRead["userPhoto"].ToString();
                userInfo.telephone = DataRead["telephone"].ToString();
                userInfo.email = DataRead["email"].ToString();
                userInfo.address = DataRead["address"].ToString();
                userInfo.regTime = Convert.ToDateTime(DataRead["regTime"].ToString());
            }
            return userInfo;
        }

        /*更新用户实现*/
        public static bool EditUserInfo(ENTITY.UserInfo userInfo)
        {
            string sql = "update UserInfo set password=@password,name=@name,gender=@gender,birthDate=@birthDate,userPhoto=@userPhoto,telephone=@telephone,email=@email,address=@address,regTime=@regTime where user_name=@user_name";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@password",SqlDbType.VarChar),
             new SqlParameter("@name",SqlDbType.VarChar),
             new SqlParameter("@gender",SqlDbType.VarChar),
             new SqlParameter("@birthDate",SqlDbType.DateTime),
             new SqlParameter("@userPhoto",SqlDbType.VarChar),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@email",SqlDbType.VarChar),
             new SqlParameter("@address",SqlDbType.VarChar),
             new SqlParameter("@regTime",SqlDbType.DateTime),
             new SqlParameter("@user_name",SqlDbType.VarChar)
            };
            /*为参数赋值*/
            parm[0].Value = userInfo.password;
            parm[1].Value = userInfo.name;
            parm[2].Value = userInfo.gender;
            parm[3].Value = userInfo.birthDate;
            parm[4].Value = userInfo.userPhoto;
            parm[5].Value = userInfo.telephone;
            parm[6].Value = userInfo.email;
            parm[7].Value = userInfo.address;
            parm[8].Value = userInfo.regTime;
            parm[9].Value = userInfo.user_name;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除用户*/
        public static bool DelUserInfo(string p)
        {
            string sql = "";
            string[] ids = p.Split(',');
            for(int i=0;i<ids.Length;i++)
            {
                if(i != ids.Length-1)
                  sql += "'" + ids[i] + "',";
                else
                  sql += "'" + ids[i] + "'";
            }
            sql = "delete from UserInfo where user_name in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询用户*/
        public static DataSet GetUserInfo(string strWhere)
        {
            try
            {
                string strSql = "select * from UserInfo" + strWhere + " order by user_name asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询用户*/
        public static System.Data.DataTable GetUserInfo(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from UserInfo";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "user_name", strShow, strSql, strWhere, " user_name asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllUserInfo()
        {
            try
            {
                string strSql = "select * from UserInfo";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
