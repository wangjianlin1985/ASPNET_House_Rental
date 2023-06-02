<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NoticeEdit.aspx.cs" Inherits="chengxusheji.Admin.NoticeEdit" %>
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
            var title = document.getElementById("title").value;
            if (title == "") {
                alert("请输入标题...");
                document.getElementById("title").focus();
                return false;
            }

            var content = document.getElementById("content").value;
            if (content == "") {
                alert("请输入公告内容...");
                document.getElementById("content").focus();
                return false;
            }

            var publishDate = document.getElementById("publishDate").value;
            if (publishDate == "") {
                alert("请输入发布时间...");
                document.getElementById("publishDate").focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">新闻公告管理 》》编辑新闻公告</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   标题：</td>
                    <td width="650px;">
                         <input id="title" type="text"   style="width:800px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入标题！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   公告内容：</td>
                    <td width="650px;">
                        <textarea id="content" rows=6 cols=80 runat="server"></textarea><span class="WarnMes">*</span>请输入公告内容！</td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  发布时间：</td>
                    <td width="650px;">
                          <asp:TextBox ID="publishDate"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd hh:mm:ss');"></asp:TextBox></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnNoticeSave" runat="server" Text=" 保存信息 "
                            OnClientClick="return CheckIn()" onclick="BtnNoticeSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="取消" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

