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
    public partial class UserInfoEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                /*���뱾��Ϣ���ҳ��ʾ��ͼ��ͼƬ*/
                this.UserPhotoImage.ImageUrl = "../FileUpload/NoImage.jpg";
                if (Request["user_name"] != null)
                {
                    LoadData();
                }
            }
        }
        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "user_name")))
            {
                ENTITY.UserInfo userInfo = BLL.bllUserInfo.getSomeUserInfo(Common.GetMes.GetRequestQuery(Request, "user_name"));
                user_name.Value = userInfo.user_name;
                password.Value = userInfo.password;
                name.Value = userInfo.name;
                gender.Value = userInfo.gender;
                birthDate.Text = userInfo.birthDate.ToShortDateString();
                userPhoto.Text = userInfo.userPhoto;
                if (userInfo.userPhoto != "") this.UserPhotoImage.ImageUrl = "../" + userInfo.userPhoto;
                telephone.Value = userInfo.telephone;
                email.Value = userInfo.email;
                address.Value = userInfo.address;
                regTime.Text = userInfo.regTime.ToShortDateString() + " " + userInfo.regTime.ToLongTimeString();
            }
        }

        protected void BtnUserInfoSave_Click(object sender, EventArgs e)
        {
            ENTITY.UserInfo userInfo = new ENTITY.UserInfo();
            userInfo.user_name = this.user_name.Value;
            userInfo.password = password.Value;
            userInfo.name = name.Value;
            userInfo.gender = gender.Value;
            userInfo.birthDate = Convert.ToDateTime(birthDate.Text);
            if (userPhoto.Text == "") userPhoto.Text = "FileUpload/NoImage.jpg";
            userInfo.userPhoto = userPhoto.Text;
            userInfo.telephone = telephone.Value;
            userInfo.email = email.Value;
            userInfo.address = address.Value;
            userInfo.regTime = Convert.ToDateTime(regTime.Text);
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "user_name")))
            {
                userInfo.user_name = Request["user_name"];
                if (BLL.bllUserInfo.EditUserInfo(userInfo))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"UserInfoEdit.aspx?user_name=" + Request["user_name"] + "\"} else  {location.href=\"UserInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllUserInfo.AddUserInfo(userInfo))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"UserInfoEdit.aspx\"} else  {location.href=\"UserInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserInfoList.aspx");
        }
        protected void Btn_UserPhotoUpload_Click(object sender, EventArgs e)
        {
            /*����û��ϴ����ļ�*/
            if (this.UserPhotoUpload.PostedFile.ContentLength > 0)
            {
                /*��֤�ϴ����ļ���ʽ��ֻ��Ϊgif��jpeg��ʽ*/
                string mimeType = this.UserPhotoUpload.PostedFile.ContentType;
                if (String.Compare(mimeType, "image/gif", true) == 0 || String.Compare(mimeType, "image/pjpeg", true) == 0 || String.Compare(mimeType, "image/jpeg", true) == 0)
                {
                    this.userPhoto.Text = "�ϴ��ļ���....";
                    string extFileString = System.IO.Path.GetExtension(this.UserPhotoUpload.PostedFile.FileName); /*��ȡ�ļ���չ��*/
                    string saveFileName = DAL.Function.MakeFileName(extFileString); /*������չ�������ļ���*/
                    string imagePath = "FileUpload/" + saveFileName;/*ͼƬ·��*/
                    this.UserPhotoUpload.PostedFile.SaveAs(Server.MapPath("../" + imagePath));
                    this.UserPhotoImage.ImageUrl = "../" + imagePath;
                    this.userPhoto.Text = imagePath;
                }
                else
                {
                    Response.Write("<script>alert('�ϴ��ļ���ʽ����ȷ!');</script>");
                }
            }
        }
    }
}

