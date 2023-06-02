using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ENTITY
{
    /// <summary>
    ///House 的摘要说明：房源实体
    /// </summary>

    public class House
    {
        /*房源id*/
        private int _houseId;
        public int houseId
        {
            get { return _houseId; }
            set { _houseId = value; }
        }

        /*房源名城*/
        private string _houseName;
        public string houseName
        {
            get { return _houseName; }
            set { _houseName = value; }
        }

        /*租金(元/月)*/
        private float _rentMoney;
        public float rentMoney
        {
            get { return _rentMoney; }
            set { _rentMoney = value; }
        }

        /*房源图片*/
        private string _housePhoto;
        public string housePhoto
        {
            get { return _housePhoto; }
            set { _housePhoto = value; }
        }

        /*户型*/
        private int _huxingObj;
        public int huxingObj
        {
            get { return _huxingObj; }
            set { _huxingObj = value; }
        }

        /*面积*/
        private float _mianji;
        public float mianji
        {
            get { return _mianji; }
            set { _mianji = value; }
        }

        /*类型*/
        private int _houseTypeObj;
        public int houseTypeObj
        {
            get { return _houseTypeObj; }
            set { _houseTypeObj = value; }
        }

        /*朝向*/
        private string _changxiang;
        public string changxiang
        {
            get { return _changxiang; }
            set { _changxiang = value; }
        }

        /*楼层*/
        private string _louceng;
        public string louceng
        {
            get { return _louceng; }
            set { _louceng = value; }
        }

        /*装修*/
        private int _zhuangxiuObj;
        public int zhuangxiuObj
        {
            get { return _zhuangxiuObj; }
            set { _zhuangxiuObj = value; }
        }

        /*要求*/
        private string _yaoqiu;
        public string yaoqiu
        {
            get { return _yaoqiu; }
            set { _yaoqiu = value; }
        }

        /*小区*/
        private string _xiaoqu;
        public string xiaoqu
        {
            get { return _xiaoqu; }
            set { _xiaoqu = value; }
        }

        /*房屋配套*/
        private string _peitao;
        public string peitao
        {
            get { return _peitao; }
            set { _peitao = value; }
        }

        /*房源概况*/
        private string _gaikuang;
        public string gaikuang
        {
            get { return _gaikuang; }
            set { _gaikuang = value; }
        }

        /*联系电话*/
        private string _telephone;
        public string telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        /*联系人*/
        private string _lianxiren;
        public string lianxiren
        {
            get { return _lianxiren; }
            set { _lianxiren = value; }
        }

    }
}
