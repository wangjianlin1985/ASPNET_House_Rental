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
    ///Huxing 的摘要说明：户型实体
    /// </summary>

    public class Huxing
    {
        /*户型id*/
        private int _huxingId;
        public int huxingId
        {
            get { return _huxingId; }
            set { _huxingId = value; }
        }

        /*户型名称*/
        private string _huxingName;
        public string huxingName
        {
            get { return _huxingName; }
            set { _huxingName = value; }
        }

    }
}
