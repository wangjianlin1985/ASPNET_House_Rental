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
    ///Huxing ��ժҪ˵��������ʵ��
    /// </summary>

    public class Huxing
    {
        /*����id*/
        private int _huxingId;
        public int huxingId
        {
            get { return _huxingId; }
            set { _huxingId = value; }
        }

        /*��������*/
        private string _huxingName;
        public string huxingName
        {
            get { return _huxingName; }
            set { _huxingName = value; }
        }

    }
}
