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
    ///Zhuangxiu 的摘要说明：装修程度实体
    /// </summary>

    public class Zhuangxiu
    {
        /*装修程度id*/
        private int _zhuangxiuId;
        public int zhuangxiuId
        {
            get { return _zhuangxiuId; }
            set { _zhuangxiuId = value; }
        }

        /*装修程度*/
        private string _zhuangxiuName;
        public string zhuangxiuName
        {
            get { return _zhuangxiuName; }
            set { _zhuangxiuName = value; }
        }

    }
}
