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
        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
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
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"NoticeEdit.aspx?noticeId=" + Request["noticeId"] + "\"} else  {location.href=\"NoticeList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllNotice.AddNotice(notice))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"NoticeEdit.aspx\"} else  {location.href=\"NoticeList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("NoticeList.aspx");
        }
    }
}

