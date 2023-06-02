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
                /*进入本信息添加页显示无图的图片*/
                this.UserPhotoImage.ImageUrl = "../FileUpload/NoImage.jpg";
                if (Request["user_name"] != null)
                {
                    LoadData();
                }
            }
        }
        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
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
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"UserInfoEdit.aspx?user_name=" + Request["user_name"] + "\"} else  {location.href=\"UserInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllUserInfo.AddUserInfo(userInfo))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"UserInfoEdit.aspx\"} else  {location.href=\"UserInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserInfoList.aspx");
        }
        protected void Btn_UserPhotoUpload_Click(object sender, EventArgs e)
        {
            /*如果用户上传了文件*/
            if (this.UserPhotoUpload.PostedFile.ContentLength > 0)
            {
                /*验证上传的文件格式，只能为gif和jpeg格式*/
                string mimeType = this.UserPhotoUpload.PostedFile.ContentType;
                if (String.Compare(mimeType, "image/gif", true) == 0 || String.Compare(mimeType, "image/pjpeg", true) == 0 || String.Compare(mimeType, "image/jpeg", true) == 0)
                {
                    this.userPhoto.Text = "上传文件中....";
                    string extFileString = System.IO.Path.GetExtension(this.UserPhotoUpload.PostedFile.FileName); /*获取文件扩展名*/
                    string saveFileName = DAL.Function.MakeFileName(extFileString); /*根据扩展名生成文件名*/
                    string imagePath = "FileUpload/" + saveFileName;/*图片路径*/
                    this.UserPhotoUpload.PostedFile.SaveAs(Server.MapPath("../" + imagePath));
                    this.UserPhotoImage.ImageUrl = "../" + imagePath;
                    this.userPhoto.Text = imagePath;
                }
                else
                {
                    Response.Write("<script>alert('上传文件格式不正确!');</script>");
                }
            }
        }
    }
}

