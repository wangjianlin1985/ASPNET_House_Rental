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
    ///Zhuangxiu ��ժҪ˵����װ�޳̶�ʵ��
    /// </summary>

    public class Zhuangxiu
    {
        /*װ�޳̶�id*/
        private int _zhuangxiuId;
        public int zhuangxiuId
        {
            get { return _zhuangxiuId; }
            set { _zhuangxiuId = value; }
        }

        /*װ�޳̶�*/
        private string _zhuangxiuName;
        public string zhuangxiuName
        {
            get { return _zhuangxiuName; }
            set { _zhuangxiuName = value; }
        }

    }
}
