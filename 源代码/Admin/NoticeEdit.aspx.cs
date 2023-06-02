using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace chengxusheji.Admin
{
    public partial class NoticeEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                if (Request["noticeId"] != null)
                {
                    LoadData();
                }
            }
        }
        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "noticeId")))
            {
                ENTITY.Notice notice = BLL.bllNotice.getSomeNotice(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "noticeId")));
                title.Value = notice.title;
                content.Value = notice.content;
                publishDate.Text = notice.publishDate.ToShortDateString() + " " + notice.publishDate.ToLongTimeString();
            }
        }

        protected void BtnNoticeSave_Click(object sender, EventArgs e)
        {
            ENTITY.Notice notice = new ENTITY.Notice();
            notice.title = title.Value;
            notice.content = content.Value;
            notice.publishDate = Convert.ToDateTime(publishDate.Text);
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "noticeId")))
            {
                notice.noticeId = int.Parse(Request["noticeId"]);
                if (BLL.bllNotice.EditNotice(notice))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"NoticeEdit.aspx?noticeId=" + Request["noticeId"] + "\"} else  {location.href=\"NoticeList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllNotice.AddNotice(notice))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"NoticeEdit.aspx\"} else  {location.href=\"NoticeList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("NoticeList.aspx");
        }
    }
}

