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
    ///House ��ժҪ˵������Դʵ��
    /// </summary>

    public class House
    {
        /*��Դid*/
        private int _houseId;
        public int houseId
        {
            get { return _houseId; }
            set { _houseId = value; }
        }

        /*��Դ����*/
        private string _houseName;
        public string houseName
        {
            get { return _houseName; }
            set { _houseName = value; }
        }

        /*���(Ԫ/��)*/
        private float _rentMoney;
        public float rentMoney
        {
            get { return _rentMoney; }
            set { _rentMoney = value; }
        }

        /*��ԴͼƬ*/
        private string _housePhoto;
        public string housePhoto
        {
            get { return _housePhoto; }
            set { _housePhoto = value; }
        }

        /*����*/
        private int _huxingObj;
        public int huxingObj
        {
            get { return _huxingObj; }
            set { _huxingObj = value; }
        }

        /*���*/
        private float _mianji;
        public float mianji
        {
            get { return _mianji; }
            set { _mianji = value; }
        }

        /*����*/
        private int _houseTypeObj;
        public int houseTypeObj
        {
            get { return _houseTypeObj; }
            set { _houseTypeObj = value; }
        }

        /*����*/
        private string _changxiang;
        public string changxiang
        {
            get { return _changxiang; }
            set { _changxiang = value; }
        }

        /*¥��*/
        private string _louceng;
        public string louceng
        {
            get { return _louceng; }
            set { _louceng = value; }
        }

        /*װ��*/
        private int _zhuangxiuObj;
        public int zhuangxiuObj
        {
            get { return _zhuangxiuObj; }
            set { _zhuangxiuObj = value; }
        }

        /*Ҫ��*/
        private string _yaoqiu;
        public string yaoqiu
        {
            get { return _yaoqiu; }
            set { _yaoqiu = value; }
        }

        /*С��*/
        private string _xiaoqu;
        public string xiaoqu
        {
            get { return _xiaoqu; }
            set { _xiaoqu = value; }
        }

        /*��������*/
        private string _peitao;
        public string peitao
        {
            get { return _peitao; }
            set { _peitao = value; }
        }

        /*��Դ�ſ�*/
        private string _gaikuang;
        public string gaikuang
        {
            get { return _gaikuang; }
            set { _gaikuang = value; }
        }

        /*��ϵ�绰*/
        private string _telephone;
        public string telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        /*��ϵ��*/
        private string _lianxiren;
        public string lianxiren
        {
            get { return _lianxiren; }
            set { _lianxiren = value; }
        }

    }
}
