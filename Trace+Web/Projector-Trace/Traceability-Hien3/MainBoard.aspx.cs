using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Traceability_Hien3.App_Code;
using System.Data;
using System.Web.Services;
namespace Traceability_Hien3
{
    public partial class MainBoard : System.Web.UI.Page
    {
        public static DataTable dtReelID = new DataTable();
        public static DataTable dtReelID1 = new DataTable();
        public static string PCBID = "";
        public static string lineName = "";
        public static string Model = "";
        public static string starttime = "";
        public static string endtime = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dtReelID = null;
                dtReelID1 = null;
                var PCBID = Request.QueryString["PCBID"].ToString();
                var lineName = Request.QueryString["linename"].ToString();
                var Model = Request.QueryString["Model"].ToString();
                var starttime = Request.QueryString["starttime"].ToString();
                var endtime = Request.QueryString["endtime"].ToString();
                loaddata(PCBID);
            }
            else
            {
                dtReelID = null;
                dtReelID1 = null;
                loaddata(PCBID);
            }
            
        }
        protected void loaddata(string PCBID)
        {
            dtReelID1 = null;
            string _PCBID = PCBID;
            var dt = DataConn.StoreFillDS("Get_Info_MainBoad", System.Data.CommandType.StoredProcedure,_PCBID);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                dtReelID1 = dt;
                if (true)
                {

                }
            }
            dtReelID = null;
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string pcbid = ((TextBox)e.Row.FindControl("MaterialBarcode")).Text;
                string realid  = ((Label)e.Row.FindControl("MaterialBarcode")).Text;
                //Finding label
                //Label lbl = (Label)e.Row.FindControl("MaterialBarcode");
                //Finding textbox
                //TextBox txt = (TextBox)e.Row.FindControl("txtDescription");
                //Finding dropdown
                //DropDownList ddl = (DropDownList)e.Row.FindControl("ddlItem");
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('RealID_Detail.aspx?realid=" + realid + "','_blank');", true);
                e.Row.Attributes["onclick"] = "window.location.href='RealID_Detail.aspx?realid="+ realid + "','_blank' ";
            }
        }
        protected void ShowReelID_Click(object sender, EventArgs e)
        {
            //get data

                ImageButton btn = (ImageButton)(sender);
            string chuoi = btn.CommandArgument;
            var dt = DataConn.StoreFillDS("Get_Info_Mounting", System.Data.CommandType.StoredProcedure, lineName, Model, starttime, endtime);
            if (dt.Rows.Count > 0)
            if (dt.Rows.Count > 0)
            {              
                dtReelID = dt;
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "test1")
            {
                string thongbao = "test1";
                //show java scritp
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "Message", "alert('" + thongbao + "');", true);
            }
            else if (e.CommandName == "link")
            {
                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);
                // Retrieve the row that contains the button clicked 
                // by the user from the Rows collection.
                GridViewRow row = GridView1.Rows[index];
                //string lineName = Server.HtmlDecode(row.Cells[1].Text);
                string lineName = Server.HtmlDecode(row.Cells[1].Text);
                string Model = row.Cells[5].Text;
                string starttime = row.Cells[7].Text;
                GridViewRow last_row = GridView1.Rows[GridView1.Rows.Count-1];
                string endtime = last_row.Cells[7].Text;
                //get data
                dtReelID = null;
                var dt = DataConn.StoreFillDS("Get_Info_Mounting", System.Data.CommandType.StoredProcedure, lineName, Model, starttime, endtime);
                if (dt.Rows.Count > 0)
                {
                    //GridView2.DataSource = dt;
                    //GridView2.DataBind();
                    dtReelID = dt;
                }
                else
                {
                    dtReelID = null;
                }
                //_Id.Value = row.Cells[0].Text;
                //_mieuta.Value = row.Cells[2].Text;
                //_chuthich.Value = row.Cells[3].Text;
                //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('sua');", true);
            }
            else if (e.CommandName == "test")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('test2');", true);
                //string thongbao = "test2";
                ////show java scritp
                //ScriptManager.RegisterStartupScript(this, this.GetType(),
                //"Message", "alert('" + thongbao + "');", true);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //get data
            Button btn = (Button)(sender);
            string chuoi = btn.CommandArgument;
            var dt = DataConn.StoreFillDS("Get_Info_Mounting", System.Data.CommandType.StoredProcedure, lineName, Model, starttime, endtime);
            if (dt.Rows.Count > 0)
                if (dt.Rows.Count > 0)
                {
                    dtReelID = dt;
                }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Display the company name in italics.
                //if (int.Parse(((TextBox)e.Row.Cells[2].FindCOntrol("TxtdepositDate")).Text) > 500)
                //{
                //    (((TextBox)e.Row.Cells[2].FindCOntrol("TxtAmount")).Enabled = false;
                //}
                //if (e.Row.RowType == DataControlRowType.DataRow)
                //{
                //    if (((Button)e.Row.FindControl("Status")).Text == "OUT")
                //    {
                //        this.GridView1.Columns[10].Visible = false;
                //    }
                //}
            }
        }
    }
}