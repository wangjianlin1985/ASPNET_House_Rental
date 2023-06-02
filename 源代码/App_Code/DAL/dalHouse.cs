using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��Դҵ���߼���ʵ��*/
    public class dalHouse
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��ӷ�Դʵ��*/
        public static bool AddHouse(ENTITY.House house)
        {
            string sql = "insert into House(houseName,rentMoney,housePhoto,huxingObj,mianji,houseTypeObj,changxiang,louceng,zhuangxiuObj,yaoqiu,xiaoqu,peitao,gaikuang,telephone,lianxiren) values(@houseName,@rentMoney,@housePhoto,@huxingObj,@mianji,@houseTypeObj,@changxiang,@louceng,@zhuangxiuObj,@yaoqiu,@xiaoqu,@peitao,@gaikuang,@telephone,@lianxiren)";
            /*����sql����*/
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
            /*��������ֵ*/
            parm[0].Value = house.houseName; //��Դ����
            parm[1].Value = house.rentMoney; //���(Ԫ/��)
            parm[2].Value = house.housePhoto; //��ԴͼƬ
            parm[3].Value = house.huxingObj; //����
            parm[4].Value = house.mianji; //���
            parm[5].Value = house.houseTypeObj; //����
            parm[6].Value = house.changxiang; //����
            parm[7].Value = house.louceng; //¥��
            parm[8].Value = house.zhuangxiuObj; //װ��
            parm[9].Value = house.yaoqiu; //Ҫ��
            parm[10].Value = house.xiaoqu; //С��
            parm[11].Value = house.peitao; //��������
            parm[12].Value = house.gaikuang; //��Դ�ſ�
            parm[13].Value = house.telephone; //��ϵ�绰
            parm[14].Value = house.lianxiren; //��ϵ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����houseId��ȡĳ����Դ��¼*/
        public static ENTITY.House getSomeHouse(int houseId)
        {
            /*������ѯsql*/
            string sql = "select * from House where houseId=" + houseId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.House house = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*���·�Դʵ��*/
        public static bool EditHouse(ENTITY.House house)
        {
            string sql = "update House set houseName=@houseName,rentMoney=@rentMoney,housePhoto=@housePhoto,huxingObj=@huxingObj,mianji=@mianji,houseTypeObj=@houseTypeObj,changxiang=@changxiang,louceng=@louceng,zhuangxiuObj=@zhuangxiuObj,yaoqiu=@yaoqiu,xiaoqu=@xiaoqu,peitao=@peitao,gaikuang=@gaikuang,telephone=@telephone,lianxiren=@lianxiren where houseId=@houseId";
            /*����sql������Ϣ*/
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
            /*Ϊ������ֵ*/
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
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����Դ*/
        public static bool DelHouse(string p)
        {
            string sql = "delete from House where houseId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��Դ*/
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

        /*��ѯ��Դ*/
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
