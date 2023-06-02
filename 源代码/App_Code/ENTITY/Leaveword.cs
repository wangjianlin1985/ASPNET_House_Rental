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
    ///Leaveword 的摘要说明：留言实体
    /// </summary>

    public class Leaveword
    {
        /*留言id*/
        private int _leaveWordId;
        public int leaveWordId
        {
            get { return _leaveWordId; }
            set { _leaveWordId = value; }
        }

        /*留言标题*/
        private string _leaveTitle;
        public string leaveTitle
        {
            get { return _leaveTitle; }
            set { _leaveTitle = value; }
        }

        /*留言内容*/
        private string _leaveContent;
        public string leaveContent
        {
            get { return _leaveContent; }
            set { _leaveContent = value; }
        }

        /*留言人*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*留言时间*/
        private DateTime _leaveTime;
        public DateTime leaveTime
        {
            get { return _leaveTime; }
            set { _leaveTime = value; }
        }

        /*管理回复*/
        private string _replyContent;
        public string replyContent
        {
            get { return _replyContent; }
            set { _replyContent = value; }
        }

        /*回复时间*/
        private DateTime _replyTime;
        public DateTime replyTime
        {
            get { return _replyTime; }
            set { _replyTime = value; }
        }

    }
}
