<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="House_frontList" %>
<%@ Register Src="../header.ascx" TagName="header" TagPrefix="uc" %>
<%@ Register Src="../footer.ascx" TagName="footer" TagPrefix="uc" %>
<%
    String path = Request.ApplicationPath;
    String basePath = path + "/"; 
%>
<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1 , user-scalable=no">
<title>房源查询</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
 <form id="form1" runat="server">
	<div class="col-md-9 wow fadeInLeft">
		<ul class="breadcrumb">
  			<li><a href="../index.aspx">首页</a></li>
  			<li><a href="frontList.aspx">房源信息列表</a></li>
  			<li class="active">查询结果显示</li>
  			<a class="pull-right" href="frontAdd.aspx" style="display:none;">添加房源</a>
		</ul>
		<div class="row">
			<asp:Repeater ID="RpHouse" runat="server">
			<ItemTemplate>
			<div class="col-md-3 bottom15" <%#(((Container.ItemIndex+0)%4==0)?"style='clear:left;'":"") %>>
			  <a href="frontshow.aspx?houseId=<%#Eval("houseId")%>"><img class="img-responsive" src="../<%#Eval("housePhoto")%>" /></a>
			     <div class="showFields">
			     	<div class="field">
	            		房源id: <%#Eval("houseId")%>
			     	</div>
			     	<div class="field">
	            		房源名城: <%#Eval("houseName")%>
			     	</div>
			     	<div class="field">
	            		租金(元/月): <%#Eval("rentMoney")%>
			     	</div>
			     	<div class="field">
	            		户型:<%#GetHuxinghuxingObj(Eval("huxingObj").ToString())%>
			     	</div>
			     	<div class="field">
	            		面积: <%#Eval("mianji")%>
			     	</div>
			     	<div class="field">
	            		类型:<%#GetHouseTypehouseTypeObj(Eval("houseTypeObj").ToString())%>
			     	</div>
			     	<div class="field">
	            		朝向: <%#Eval("changxiang")%>
			     	</div>
			     	<div class="field">
	            		楼层: <%#Eval("louceng")%>
			     	</div>
			     	<div class="field">
	            		装修:<%#GetZhuangxiuzhuangxiuObj(Eval("zhuangxiuObj").ToString())%>
			     	</div>
			     	<div class="field">
	            		要求: <%#Eval("yaoqiu")%>
			     	</div>
			     	<div class="field">
	            		小区: <%#Eval("xiaoqu")%>
			     	</div>
			        <a class="btn btn-primary top5" href="frontShow.aspx?houseId=<%#Eval("houseId")%>">详情</a>
			        <a class="btn btn-primary top5" onclick="houseEdit('<%#Eval("houseId")%>');" style="display:none;">修改</a>
			        <a class="btn btn-primary top5" onclick="houseDelete('<%#Eval("houseId")%>');" style="display:none;">删除</a>
			     </div>
			</div>
			</ItemTemplate>
			</asp:Repeater>

			<div class="row">
				<div class="col-md-12">
					<nav class="pull-left">
						<ul class="pagination">
 						        <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn" 
 						            onclick="LBHome_Click">[首页]</asp:LinkButton>
 						        <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
 						            onclick="LBUp_Click">[上一页]</asp:LinkButton>
 						        <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn"
 						            onclick="LBNext_Click">[下一页]</asp:LinkButton>
 						        <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn" 
 						            onclick="LBEnd_Click">[尾页]</asp:LinkButton>
 						        <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
 						        <asp:HiddenField ID="HWhere" runat="server" Value=""/>
 						        <asp:HiddenField ID="HNowPage" runat="server" Value="1"/>
 						        <asp:HiddenField ID="HPageSize" runat="server" Value="8"/>
 						        <asp:HiddenField ID="HAllPage" runat="server" Value="0"/>
						</ul>
					</nav>
					<div class="pull-right" style="line-height:75px;" ><asp:Label runat="server" ID="PageMes"></asp:Label></div>
				</div>
			</div>
		</div>
	</div>

	<div class="col-md-3 wow fadeInRight">
		<div class="page-header">
    		<h1>房源查询</h1>
		</div>
			<div class="form-group">
				<label for="houseName">房源名城:</label>
				<asp:TextBox ID="houseName" runat="server"  CssClass="form-control" placeholder="请输入房源名城"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="huxingObj_huxingId">户型：</label>
                <asp:DropDownList ID="huxingObj" runat="server"  CssClass="form-control" placeholder="请选择户型"></asp:DropDownList>
            </div>
            <div class="form-group">
            	<label for="houseTypeObj_typeId">类型：</label>
                <asp:DropDownList ID="houseTypeObj" runat="server"  CssClass="form-control" placeholder="请选择类型"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="changxiang">朝向:</label>
				<asp:TextBox ID="changxiang" runat="server"  CssClass="form-control" placeholder="请输入朝向"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="zhuangxiuObj_zhuangxiuId">装修：</label>
                <asp:DropDownList ID="zhuangxiuObj" runat="server"  CssClass="form-control" placeholder="请选择装修"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="xiaoqu">小区:</label>
				<asp:TextBox ID="xiaoqu" runat="server"  CssClass="form-control" placeholder="请输入小区"></asp:TextBox>
			</div>
        <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>
  </form>
</div>
<div id="houseEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;房源信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="houseEditForm" id="houseEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="house_houseId_edit" class="col-md-3 text-right">房源id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="house_houseId_edit" name="house.houseId" class="form-control" placeholder="请输入房源id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="house_houseName_edit" class="col-md-3 text-right">房源名城:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="house_houseName_edit" name="house.houseName" class="form-control" placeholder="请输入房源名城">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="house_rentMoney_edit" class="col-md-3 text-right">租金(元/月):</label>
		  	 <div class="col-md-9">
			    <input type="text" id="house_rentMoney_edit" name="house.rentMoney" class="form-control" placeholder="请输入租金(元/月)">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="house_housePhoto_edit" class="col-md-3 text-right">房源图片:</label>
		  	 <div class="col-md-9">
			    <img  class="img-responsive" id="house_housePhotoImg" border="0px"/><br/>
			    <input type="hidden" id="house_housePhoto" name="house.housePhoto"/>
			    <input id="housePhotoFile" name="housePhotoFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="house_huxingObj_huxingId_edit" class="col-md-3 text-right">户型:</label>
		  	 <div class="col-md-9">
			    <select id="house_huxingObj_huxingId_edit" name="house.huxingObj.huxingId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="house_mianji_edit" class="col-md-3 text-right">面积:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="house_mianji_edit" name="house.mianji" class="form-control" placeholder="请输入面积">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="house_houseTypeObj_typeId_edit" class="col-md-3 text-right">类型:</label>
		  	 <div class="col-md-9">
			    <select id="house_houseTypeObj_typeId_edit" name="house.houseTypeObj.typeId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="house_changxiang_edit" class="col-md-3 text-right">朝向:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="house_changxiang_edit" name="house.changxiang" class="form-control" placeholder="请输入朝向">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="house_louceng_edit" class="col-md-3 text-right">楼层:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="house_louceng_edit" name="house.louceng" class="form-control" placeholder="请输入楼层">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="house_zhuangxiuObj_zhuangxiuId_edit" class="col-md-3 text-right">装修:</label>
		  	 <div class="col-md-9">
			    <select id="house_zhuangxiuObj_zhuangxiuId_edit" name="house.zhuangxiuObj.zhuangxiuId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="house_yaoqiu_edit" class="col-md-3 text-right">要求:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="house_yaoqiu_edit" name="house.yaoqiu" class="form-control" placeholder="请输入要求">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="house_xiaoqu_edit" class="col-md-3 text-right">小区:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="house_xiaoqu_edit" name="house.xiaoqu" class="form-control" placeholder="请输入小区">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="house_peitao_edit" class="col-md-3 text-right">房屋配套:</label>
		  	 <div class="col-md-9">
			    <textarea id="house_peitao_edit" name="house.peitao" rows="8" class="form-control" placeholder="请输入房屋配套"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="house_gaikuang_edit" class="col-md-3 text-right">房源概况:</label>
		  	 <div class="col-md-9">
			    <textarea id="house_gaikuang_edit" name="house.gaikuang" rows="8" class="form-control" placeholder="请输入房源概况"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="house_telephone_edit" class="col-md-3 text-right">联系电话:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="house_telephone_edit" name="house.telephone" class="form-control" placeholder="请输入联系电话">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="house_lianxiren_edit" class="col-md-3 text-right">联系人:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="house_lianxiren_edit" name="house.lianxiren" class="form-control" placeholder="请输入联系人">
			 </div>
		  </div>
		</form> 
	    <style>#houseEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxHouseModify();">提交</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap-datetimepicker.min.js"></script>
<script src="<%=basePath %>plugins/locales/bootstrap-datetimepicker.zh-CN.js"></script>
<script type="text/javascript" src="<%=basePath %>js/jsdate.js"></script>
<script>
var basePath = "<%=basePath%>";
/*弹出修改房源界面并初始化数据*/
function houseEdit(houseId) {
	$.ajax({
		url :  basePath + "House/HouseController.aspx?action=getHouse&houseId=" + houseId,
		type : "get",
		dataType: "json",
		success : function (house, response, status) {
			if (house) {
				$("#house_houseId_edit").val(house.houseId);
				$("#house_houseName_edit").val(house.houseName);
				$("#house_rentMoney_edit").val(house.rentMoney);
				$("#house_housePhoto").val(house.housePhoto);
				$("#house_housePhotoImg").attr("src", basePath +　house.housePhoto);
				$.ajax({
					url: basePath + "Huxing/HuxingController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(huxings,response,status) { 
						$("#house_huxingObj_huxingId_edit").empty();
						var html="";
		        		$(huxings).each(function(i,huxing){
		        			html += "<option value='" + huxing.huxingId + "'>" + huxing.huxingName + "</option>";
		        		});
		        		$("#house_huxingObj_huxingId_edit").html(html);
		        		$("#house_huxingObj_huxingId_edit").val(house.huxingObjPri);
					}
				});
				$("#house_mianji_edit").val(house.mianji);
				$.ajax({
					url: basePath + "HouseType/HouseTypeController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(houseTypes,response,status) { 
						$("#house_houseTypeObj_typeId_edit").empty();
						var html="";
		        		$(houseTypes).each(function(i,houseType){
		        			html += "<option value='" + houseType.typeId + "'>" + houseType.typeName + "</option>";
		        		});
		        		$("#house_houseTypeObj_typeId_edit").html(html);
		        		$("#house_houseTypeObj_typeId_edit").val(house.houseTypeObjPri);
					}
				});
				$("#house_changxiang_edit").val(house.changxiang);
				$("#house_louceng_edit").val(house.louceng);
				$.ajax({
					url: basePath + "Zhuangxiu/ZhuangxiuController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(zhuangxius,response,status) { 
						$("#house_zhuangxiuObj_zhuangxiuId_edit").empty();
						var html="";
		        		$(zhuangxius).each(function(i,zhuangxiu){
		        			html += "<option value='" + zhuangxiu.zhuangxiuId + "'>" + zhuangxiu.zhuangxiuName + "</option>";
		        		});
		        		$("#house_zhuangxiuObj_zhuangxiuId_edit").html(html);
		        		$("#house_zhuangxiuObj_zhuangxiuId_edit").val(house.zhuangxiuObjPri);
					}
				});
				$("#house_yaoqiu_edit").val(house.yaoqiu);
				$("#house_xiaoqu_edit").val(house.xiaoqu);
				$("#house_peitao_edit").val(house.peitao);
				$("#house_gaikuang_edit").val(house.gaikuang);
				$("#house_telephone_edit").val(house.telephone);
				$("#house_lianxiren_edit").val(house.lianxiren);
				$('#houseEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除房源信息*/
function houseDelete(houseId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "House/HouseController.aspx?action=delete",
			data : {
				houseId : houseId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
                    $("#btnSearch").click();
					//location.href= basePath + "House/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交房源信息表单给服务器端修改*/
function ajaxHouseModify() {
	$.ajax({
		url :  basePath + "House/HouseController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#houseEditForm")[0]),
		success : function (obj, response, status) {
            if(obj.success){
                alert("信息修改成功！");
                $("#btnSearch").click();
            }else{
                alert(obj.message);
            } 
		},
		processData: false,
		contentType: false,
	});
}

$(function(){
	/*小屏幕导航点击关闭菜单*/
    $('.navbar-collapse a').click(function(){
        $('.navbar-collapse').collapse('hide');
    });
    new WOW().init();

})
</script>
</body>
</html>

