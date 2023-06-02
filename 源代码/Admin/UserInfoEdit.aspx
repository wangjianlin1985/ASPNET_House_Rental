<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInfoEdit.aspx.cs" Inherits="chengxusheji.Admin.UserInfoEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script type="text/javascript" src="JavaScript/Admin.js"></script>
    <script type="text/javascript" src="../js/jsdate.js"></script>
    <script type="text/javascript">
        function CheckIn() {
            var re = /^[0-9]+.?[0-9]*$/;
            var resc=/^[1-9]+[0-9]*]*$/ ;
            var user_name = document.getElementById("user_name").value;
            if (user_name == "") {
                alert("请输入用户名...");
                document.getElementById("user_name").focus();
                return false;
            }

            var password = document.getElementById("password").value;
            if (password == "") {
                alert("请输入登录密码...");
                document.getElementById("password").focus();
                return false;
            }

            var name = document.getElementById("name").value;
            if (name == "") {
                alert("请输入姓名...");
                document.getElementById("name").focus();
                return false;
            }

            var gender = document.getElementById("gender").value;
            if (gender == "") {
                alert("请输入性别...");
                document.getElementById("gender").focus();
                return false;
            }

            var birthDate = document.getElementById("birthDate").value;
            if (birthDate == "") {
                alert("请输入出生日期...");
                document.getElementById("birthDate").focus();
                return false;
            }

            var telephone = document.getElementById("telephone").value;
            if (telephone == "") {
                alert("请输入联系电话...");
                document.getElementById("telephone").focus();
                return false;
            }

            var email = document.getElementById("email").value;
            if (email == "") {
                alert("请输入邮箱...");
                document.getElementById("email").focus();
                return false;
            }

            var regTime = document.getElementById("regTime").value;
            if (regTime == "") {
                alert("请输入注册时间...");
                document.getElementById("regTime").focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">用户管理 》》编辑用户</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   用户名：</td>
                    <td width="650px;">
                         <input id="user_name" type="text"   style="width:300px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入用户名！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   登录密码：</td>
                    <td width="650px;">
                         <input id="password" type="text"   style="width:300px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入登录密码！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   姓名：</td>
                    <td width="650px;">
                         <input id="name" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入姓名！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   性别：</td>
                    <td width="650px;">
                         <input id="gender" type="text"   style="width:40px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入性别！</td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  出生日期：</td>
                    <td width="650px;">
                          <asp:TextBox ID="birthDate"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd');"></asp:TextBox></td>                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   用户照片：</td>
                    <td width="650px;">
                       <table cellpadding="0px" cellspacing="0px" width="90%">
                        <tr><td width="400px">
                         图片路径：<asp:TextBox ID="userPhoto" runat="server" ReadOnly="True" Width="228px" Enabled="False"></asp:TextBox> &nbsp; &nbsp; &nbsp
                         <br />
                         <br />
                         上传图片：<asp:FileUpload ID="UserPhotoUpload" runat="server" Width="237px" />&nbsp;
                         <asp:Button ID="Btn_UserPhotoUpload" runat="server" Text="上传" OnClick="Btn_UserPhotoUpload_Click" /></td><td>
                         <asp:Image ID="UserPhotoImage" runat="server" Height="90px" Width="99px" />
                         </td></tr>
                       </table>
                    </td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   联系电话：</td>
                    <td width="650px;">
                         <input id="telephone" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入联系电话！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   邮箱：</td>
                    <td width="650px;">
                         <input id="email" type="text"   style="width:500px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入邮箱！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   家庭地址：</td>
                    <td width="650px;">
                         <input id="address" type="text"   style="width:800px;" runat="server" maxlength="25"/></td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  注册时间：</td>
                    <td width="650px;">
                          <asp:TextBox ID="regTime"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd hh:mm:ss');"></asp:TextBox></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnUserInfoSave" runat="server" Text=" 保存信息 "
                            OnClientClick="return CheckIn()" onclick="BtnUserInfoSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="取消" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

