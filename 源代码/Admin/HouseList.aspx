<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HouseList.aspx.cs" Inherits="chengxusheji.Admin.HouseList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>房源列表</title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
   <script src="JavaScript/Admin.js" type="text/javascript"></script>
   <script type="text/javascript" src="../js/jsdate.js"></script>
</head>
<body>
   <form id="form1" runat="server">
    <div class="div_All">
    <div class="Body_Title">房源管理 》》房源列表</div>
     <div class="Body_Search">
        房源名城&nbsp;&nbsp;<asp:TextBox ID="houseName" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        户型&nbsp;&nbsp;<asp:DropDownList ID="huxingObj" runat="server"></asp:DropDownList>  &nbsp;&nbsp;
        类型&nbsp;&nbsp;<asp:DropDownList ID="houseTypeObj" runat="server"></asp:DropDownList>  &nbsp;&nbsp;
        朝向&nbsp;&nbsp;<asp:TextBox ID="changxiang" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        装修&nbsp;&nbsp;<asp:DropDownList ID="zhuangxiuObj" runat="server"></asp:DropDownList>  &nbsp;&nbsp;
        小区&nbsp;&nbsp;<asp:TextBox ID="xiaoqu" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="查询" onclick="btnSearch_Click" /> 
        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnExport" runat="server" Text="导出excel" OnClick="btnExport_Click" />
    <asp:Repeater ID="RpHouse" runat="server" onitemcommand="RpHouse_ItemCommand">
        <HeaderTemplate>
            <table cellpadding="2" cellspacing="1" class="Admin_Table">
                <thead>
                    <tr class="Admin_Table_Title">
                        <th>选择</th> 
                        <th>房源id</th>
                        <th>房源名城</th>
                        <th>租金(元/月)</th>
                        <th>房源图片</th>
                        <th>户型</th>
                        <th>面积</th>
                        <th>类型</th>
                        <th>朝向</th>
                        <th>楼层</th>
                        <th>装修</th>
                        <th>要求</th>
                        <th>小区</th>
                        <th>操作</th> 
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center"><input type="checkbox" value='<%#Eval("houseId") %>' name="CheckMes" id="DelChecked"/></td>
                <td align="center"><%#Eval("houseId")%> </td>
                <td align="center"><%#Eval("houseName")%> </td>
                <td align="center"><%#Eval("rentMoney")%> </td>
                <td align="center"><img src="../<%#Eval("housePhoto")%>" width=50 height=50 />
                  <td align="center"><%#GetHuxinghuxingObj(Eval("huxingObj").ToString())%></td>
                <td align="center"><%#Eval("mianji")%> </td>
                  <td align="center"><%#GetHouseTypehouseTypeObj(Eval("houseTypeObj").ToString())%></td>
                <td align="center"><%#Eval("changxiang")%> </td>
                <td align="center"><%#Eval("louceng")%> </td>
                  <td align="center"><%#GetZhuangxiuzhuangxiuObj(Eval("zhuangxiuObj").ToString())%></td>
                <td align="center"><%#Eval("yaoqiu")%> </td>
                <td align="center"><%#Eval("xiaoqu")%> </td>
                <td align="center"><a href="HouseEdit.aspx?houseId=<%#Eval("houseId") %>"><img src="Images/MillMes_ICO.gif" alt="修改信息..." /></a><asp:ImageButton class="DelClass" ID="IBDelClass" runat="server" CommandArgument='<%#Eval("houseId")%>' CommandName="Del" ImageUrl="Images/Delete.gif"  ToolTip="删除该信息..."/></td>
             </tr>
        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>

    <div class="Body_Search">
        <div class="page_Left">
            <input id="BtnAllSelect" type="button" value="全选" />&nbsp;
            <asp:Button ID="BtnAllDel" runat="server" Text=" 删除选中 " onclick="BtnAllDel_Click" />
        </div>
        <div class="page_Right">
        <span class="pageBtn">   <asp:Label runat="server" ID="PageMes"></asp:Label></span>
            <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn" 
                onclick="LBHome_Click">[首页]</asp:LinkButton>
            <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
                onclick="LBUp_Click">[上一页]</asp:LinkButton>
            <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn" 
                onclick="LBNext_Click">[下一页]</asp:LinkButton>
            <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn" 
                onclick="LBEnd_Click">[尾页]</asp:LinkButton>
        </div>
    </div>
    </div>
    <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
    <asp:HiddenField ID="HWhere" runat="server" Value=""/>
    <asp:HiddenField ID="HNowPage" runat="server" Value="1"/>
    <asp:HiddenField ID="HPageSize" runat="server" Value="5"/>
    <asp:HiddenField ID="HAllPage" runat="server" Value="0"/>
    </form>
</body>
</html>
