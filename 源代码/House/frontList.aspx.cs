using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class House_frontList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindhuxingObj();
            BindhouseTypeObj();
            BindzhuangxiuObj();
            string sqlstr = " where 1=1 ";
            if (Request["houseName"] != null && Request["houseName"].ToString() != "")
            {
                sqlstr += "  and houseName like '%" + Request["houseName"].ToString() + "%'";
                houseName.Text = Request["houseName"].ToString();
            }
            if (Request["huxingObj"] != null && Request["huxingObj"].ToString() != "0")
            {
                    sqlstr += "  and huxingObj=" + Request["huxingObj"].ToString();
                    huxingObj.SelectedValue = Request["huxingObj"].ToString();
            }
            if (Request["houseTypeObj"] != null && Request["houseTypeObj"].ToString() != "0")
            {
                    sqlstr += "  and houseTypeObj=" + Request["houseTypeObj"].ToString();
                    houseTypeObj.SelectedValue = Request["houseTypeObj"].ToString();
            }
            if (Request["changxiang"] != null && Request["changxiang"].ToString() != "")
            {
                sqlstr += "  and changxiang like '%" + Request["changxiang"].ToString() + "%'";
                changxiang.Text = Request["changxiang"].ToString();
            }
            if (Request["zhuangxiuObj"] != null && Request["zhuangxiuObj"].ToString() != "0")
            {
                    sqlstr += "  and zhuangxiuObj=" + Request["zhuangxiuObj"].ToString();
                    zhuangxiuObj.SelectedValue = Request["zhuangxiuObj"].ToString();
            }
            if (Request["xiaoqu"] != null && Request["xiaoqu"].ToString() != "")
            {
                sqlstr += "  and xiaoqu like '%" + Request["xiaoqu"].ToString() + "%'";
                xiaoqu.Text = Request["xiaoqu"].ToString();
            }
            HWhere.Value = sqlstr;
            BindData("");
       }
    }
    private void BindhuxingObj()
    {
        ListItem li = new ListItem("不限制", "0");
        huxingObj.Items.Add(li);
        DataSet huxingObjDs = BLL.bllHuxing.getAllHuxing();
        for (int i = 0; i < huxingObjDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = huxingObjDs.Tables[0].Rows[i];
            li = new ListItem(dr["huxingName"].ToString(),dr["huxingId"].ToString());
            huxingObj.Items.Add(li);
        }
        huxingObj.SelectedValue = "0";
    }

    private void BindhouseTypeObj()
    {
        ListItem li = new ListItem("不限制", "0");
        houseTypeObj.Items.Add(li);
        DataSet houseTypeObjDs = BLL.bllHouseType.getAllHouseType();
        for (int i = 0; i < houseTypeObjDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = houseTypeObjDs.Tables[0].Rows[i];
            li = new ListItem(dr["typeName"].ToString(),dr["typeId"].ToString());
            houseTypeObj.Items.Add(li);
        }
        houseTypeObj.SelectedValue = "0";
    }

    private void BindzhuangxiuObj()
    {
        ListItem li = new ListItem("不限制", "0");
        zhuangxiuObj.Items.Add(li);
        DataSet zhuangxiuObjDs = BLL.bllZhuangxiu.getAllZhuangxiu();
        for (int i = 0; i < zhuangxiuObjDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = zhuangxiuObjDs.Tables[0].Rows[i];
            li = new ListItem(dr["zhuangxiuName"].ToString(),dr["zhuangxiuId"].ToString());
            zhuangxiuObj.Items.Add(li);
        }
        zhuangxiuObj.SelectedValue = "0";
    }

    private void BindData(string strClass)
    {
        int DataCount = 0;
        int NowPage = 1;
        int AllPage = 0;
        int PageSize = Convert.ToInt32(HPageSize.Value);
        switch (strClass)
        {
            case "next":
                NowPage = Convert.ToInt32(HNowPage.Value) + 1;
                break;
            case "up":
                NowPage = Convert.ToInt32(HNowPage.Value) - 1;
                break;
            case "end":
                NowPage = Convert.ToInt32(HAllPage.Value);
                break;
            default:
                break;
        }
        DataTable dsLog = BLL.bllHouse.GetHouse(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
        if (dsLog.Rows.Count == 0 || AllPage == 1)
        {
            LBEnd.Enabled = false;
            LBHome.Enabled = false;
            LBNext.Enabled = false;
            LBUp.Enabled = false;
        }
        else if (NowPage == 1)
        {
            LBHome.Enabled = false;
            LBUp.Enabled = false;
            LBNext.Enabled = true;
            LBEnd.Enabled = true;
        }
        else if (NowPage == AllPage)
        {
            LBHome.Enabled = true;
            LBUp.Enabled = true;
            LBNext.Enabled = false;
            LBEnd.Enabled = false;
        }
        else
        {
            LBEnd.Enabled = true;
            LBHome.Enabled = true;
            LBNext.Enabled = true;
            LBUp.Enabled = true;
        }
        RpHouse.DataSource = dsLog;
        RpHouse.DataBind();
        PageMes.Text = string.Format("[每页<font color=green>{0}</font>条 第<font color=red>{1}</font>页／共<font color=green>{2}</font>页   共<font color=green>{3}</font>条]", PageSize, NowPage, AllPage, DataCount);
        HNowPage.Value = Convert.ToString(NowPage++);
        HAllPage.Value = AllPage.ToString();
    }

    protected void LBHome_Click(object sender, EventArgs e)
    {
        BindData("");
    }
    protected void LBUp_Click(object sender, EventArgs e)
    {
        BindData("up");
    }
    protected void LBNext_Click(object sender, EventArgs e)
    {
        BindData("next");
    }
    protected void LBEnd_Click(object sender, EventArgs e)
    {
        BindData("end");
    }
        public string GetHuxinghuxingObj(string huxingObj)
        {
            return BLL.bllHuxing.getSomeHuxing(int.Parse(huxingObj)).huxingName;
        }

        public string GetHouseTypehouseTypeObj(string houseTypeObj)
        {
            return BLL.bllHouseType.getSomeHouseType(int.Parse(houseTypeObj)).typeName;
        }

        public string GetZhuangxiuzhuangxiuObj(string zhuangxiuObj)
        {
            return BLL.bllZhuangxiu.getSomeZhuangxiu(int.Parse(zhuangxiuObj)).zhuangxiuName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("frontList.aspx?houseName=" + houseName.Text.Trim()  + "&&huxingObj=" + huxingObj.SelectedValue.Trim() + "&&houseTypeObj=" + houseTypeObj.SelectedValue.Trim()+ "&&changxiang=" + changxiang.Text.Trim() + "&&zhuangxiuObj=" + zhuangxiuObj.SelectedValue.Trim()+ "&&xiaoqu=" + xiaoqu.Text.Trim());
        }

}
