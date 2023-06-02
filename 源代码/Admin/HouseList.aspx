<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HouseList.aspx.cs" Inherits="chengxusheji.Admin.HouseList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>��Դ�б�</title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
   <script src="JavaScript/Admin.js" type="text/javascript"></script>
   <script type="text/javascript" src="../js/jsdate.js"></script>
</head>
<body>
   <form id="form1" runat="server">
    <div class="div_All">
    <div class="Body_Title">��Դ���� ������Դ�б�</div>
     <div class="Body_Search">
        ��Դ����&nbsp;&nbsp;<asp:TextBox ID="houseName" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        ����&nbsp;&nbsp;<asp:DropDownList ID="huxingObj" runat="server"></asp:DropDownList>  &nbsp;&nbsp;
        ����&nbsp;&nbsp;<asp:DropDownList ID="houseTypeObj" runat="server"></asp:DropDownList>  &nbsp;&nbsp;
        ����&nbsp;&nbsp;<asp:TextBox ID="changxiang" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        װ��&nbsp;&nbsp;<asp:DropDownList ID="zhuangxiuObj" runat="server"></asp:DropDownList>  &nbsp;&nbsp;
        С��&nbsp;&nbsp;<asp:TextBox ID="xiaoqu" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="��ѯ" onclick="btnSearch_Click" /> 
        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnExport" runat="server" Text="����excel" OnClick="btnExport_Click" />
    <asp:Repeater ID="RpHouse" runat="server" onitemcommand="RpHouse_ItemCommand">
        <HeaderTemplate>
            <table cellpadding="2" cellspacing="1" class="Admin_Table">
                <thead>
                    <tr class="Admin_Table_Title">
                        <th>ѡ��</th> 
                        <th>��Դid</th>
                        <th>��Դ����</th>
                        <th>���(Ԫ/��)</th>
                        <th>��ԴͼƬ</th>
                        <th>����</th>
                        <th>���</th>
                        <th>����</th>
                        <th>����</th>
                        <th>¥��</th>
                        <th>װ��</th>
                        <th>Ҫ��</th>
                        <th>С��</th>
                        <th>����</th> 
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
                <td align="center"><a href="HouseEdit.aspx?houseId=<%#Eval("houseId") %>"><img src="Images/MillMes_ICO.gif" alt="�޸���Ϣ..." /></a><asp:ImageButton class="DelClass" ID="IBDelClass" runat="server" CommandArgument='<%#Eval("houseId")%>' CommandName="Del" ImageUrl="Images/Delete.gif"  ToolTip="ɾ������Ϣ..."/></td>
             </tr>
        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>

    <div class="Body_Search">
        <div class="page_Left">
            <input id="BtnAllSelect" type="button" value="ȫѡ" />&nbsp;
            <asp:Button ID="BtnAllDel" runat="server" Text=" ɾ��ѡ�� " onclick="BtnAllDel_Click" />
        </div>
        <div class="page_Right">
        <span class="pageBtn">   <asp:Label runat="server" ID="PageMes"></asp:Label></span>
            <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn" 
                onclick="LBHome_Click">[��ҳ]</asp:LinkButton>
            <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
                onclick="LBUp_Click">[��һҳ]</asp:LinkButton>
            <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn" 
                onclick="LBNext_Click">[��һҳ]</asp:LinkButton>
            <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn" 
                onclick="LBEnd_Click">[βҳ]</asp:LinkButton>
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
