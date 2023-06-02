using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*房源业务逻辑层实现*/
    public class dalHouse
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加房源实现*/
        public static bool AddHouse(ENTITY.House house)
        {
            string sql = "insert into House(houseName,rentMoney,housePhoto,huxingObj,mianji,houseTypeObj,changxiang,louceng,zhuangxiuObj,yaoqiu,xiaoqu,peitao,gaikuang,telephone,lianxiren) values(@houseName,@rentMoney,@housePhoto,@huxingObj,@mianji,@houseTypeObj,@changxiang,@louceng,@zhuangxiuObj,@yaoqiu,@xiaoqu,@peitao,@gaikuang,@telephone,@lianxiren)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@houseName",SqlDbType.VarChar),
             new SqlParameter("@rentMoney",SqlDbType.Float),
             new SqlParameter("@housePhoto",SqlDbType.VarChar),
             new SqlParameter("@huxingObj",SqlDbType.Int),
             new SqlParameter("@mianji",SqlDbType.Float),
             new SqlParameter("@houseTypeObj",SqlDbType.Int),
             new SqlParameter("@changxiang",SqlDbType.VarChar),
             new SqlParameter("@louceng",SqlDbType.VarChar),
             new SqlParameter("@zhuangxiuObj",SqlDbType.Int),
             new SqlParameter("@yaoqiu",SqlDbType.VarChar),
             new SqlParameter("@xiaoqu",SqlDbType.VarChar),
             new SqlParameter("@peitao",SqlDbType.VarChar),
             new SqlParameter("@gaikuang",SqlDbType.VarChar),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@lianxiren",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = house.houseName; //房源名城
            parm[1].Value = house.rentMoney; //租金(元/月)
            parm[2].Value = house.housePhoto; //房源图片
            parm[3].Value = house.huxingObj; //户型
            parm[4].Value = house.mianji; //面积
            parm[5].Value = house.houseTypeObj; //类型
            parm[6].Value = house.changxiang; //朝向
            parm[7].Value = house.louceng; //楼层
            parm[8].Value = house.zhuangxiuObj; //装修
            parm[9].Value = house.yaoqiu; //要求
            parm[10].Value = house.xiaoqu; //小区
            parm[11].Value = house.peitao; //房屋配套
            parm[12].Value = house.gaikuang; //房源概况
            parm[13].Value = house.telephone; //联系电话
            parm[14].Value = house.lianxiren; //联系人

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据houseId获取某条房源记录*/
        public static ENTITY.House getSomeHouse(int houseId)
        {
            /*构建查询sql*/
            string sql = "select * from House where houseId=" + houseId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.House house = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                house = new ENTITY.House();
                house.houseId = Convert.ToInt32(DataRead["houseId"]);
                house.houseName = DataRead["houseName"].ToString();
                house.rentMoney = float.Parse(DataRead["rentMoney"].ToString());
                house.housePhoto = DataRead["housePhoto"].ToString();
                house.huxingObj = Convert.ToInt32(DataRead["huxingObj"]);
                house.mianji = float.Parse(DataRead["mianji"].ToString());
                house.houseTypeObj = Convert.ToInt32(DataRead["houseTypeObj"]);
                house.changxiang = DataRead["changxiang"].ToString();
                house.louceng = DataRead["louceng"].ToString();
                house.zhuangxiuObj = Convert.ToInt32(DataRead["zhuangxiuObj"]);
                house.yaoqiu = DataRead["yaoqiu"].ToString();
                house.xiaoqu = DataRead["xiaoqu"].ToString();
                house.peitao = DataRead["peitao"].ToString();
                house.gaikuang = DataRead["gaikuang"].ToString();
                house.telephone = DataRead["telephone"].ToString();
                house.lianxiren = DataRead["lianxiren"].ToString();
            }
            return house;
        }

        /*更新房源实现*/
        public static bool EditHouse(ENTITY.House house)
        {
            string sql = "update House set houseName=@houseName,rentMoney=@rentMoney,housePhoto=@housePhoto,huxingObj=@huxingObj,mianji=@mianji,houseTypeObj=@houseTypeObj,changxiang=@changxiang,louceng=@louceng,zhuangxiuObj=@zhuangxiuObj,yaoqiu=@yaoqiu,xiaoqu=@xiaoqu,peitao=@peitao,gaikuang=@gaikuang,telephone=@telephone,lianxiren=@lianxiren where houseId=@houseId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@houseName",SqlDbType.VarChar),
             new SqlParameter("@rentMoney",SqlDbType.Float),
             new SqlParameter("@housePhoto",SqlDbType.VarChar),
             new SqlParameter("@huxingObj",SqlDbType.Int),
             new SqlParameter("@mianji",SqlDbType.Float),
             new SqlParameter("@houseTypeObj",SqlDbType.Int),
             new SqlParameter("@changxiang",SqlDbType.VarChar),
             new SqlParameter("@louceng",SqlDbType.VarChar),
             new SqlParameter("@zhuangxiuObj",SqlDbType.Int),
             new SqlParameter("@yaoqiu",SqlDbType.VarChar),
             new SqlParameter("@xiaoqu",SqlDbType.VarChar),
             new SqlParameter("@peitao",SqlDbType.VarChar),
             new SqlParameter("@gaikuang",SqlDbType.VarChar),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@lianxiren",SqlDbType.VarChar),
             new SqlParameter("@houseId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = house.houseName;
            parm[1].Value = house.rentMoney;
            parm[2].Value = house.housePhoto;
            parm[3].Value = house.huxingObj;
            parm[4].Value = house.mianji;
            parm[5].Value = house.houseTypeObj;
            parm[6].Value = house.changxiang;
            parm[7].Value = house.louceng;
            parm[8].Value = house.zhuangxiuObj;
            parm[9].Value = house.yaoqiu;
            parm[10].Value = house.xiaoqu;
            parm[11].Value = house.peitao;
            parm[12].Value = house.gaikuang;
            parm[13].Value = house.telephone;
            parm[14].Value = house.lianxiren;
            parm[15].Value = house.houseId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除房源*/
        public static bool DelHouse(string p)
        {
            string sql = "delete from House where houseId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询房源*/
        public static DataSet GetHouse(string strWhere)
        {
            try
            {
                string strSql = "select * from House" + strWhere + " order by houseId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询房源*/
        public static System.Data.DataTable GetHouse(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from House";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "houseId", strShow, strSql, strWhere, " houseId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllHouse()
        {
            try
            {
                string strSql = "select * from House";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
