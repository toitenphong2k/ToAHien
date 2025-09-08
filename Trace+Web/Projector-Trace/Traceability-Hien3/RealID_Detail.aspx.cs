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
    public partial class RealID_Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var realid = Request.QueryString["realid"].ToString();
            loaddata(realid);
        }


        protected void loaddata(string realid)
        {
            string _realid = realid;
            var dt = DataConn.StoreFillDS("Get_Info_Panancim", System.Data.CommandType.StoredProcedure, _realid);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
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

                //string lineName = Server.HtmlDecode(row.Cells[1].Text);
                //string Model = row.Cells[5].Text;
                //string starttime = row.Cells[8].Text;
                //GridViewRow last_row = GridView1.Rows[GridView1.Rows.Count - 1];
                //string endtime = last_row.Cells[8].Text;

                string sRealID = row.Cells[0].Text;
                string PartNumber = row.Cells[1].Text;
                string sPlant = row.Cells[4].Text;
                string sCate = row.Cells[5].Text;
                string barcodeId= row.Cells[10].Text;
                string PstgDate = row.Cells[11].Text;

                //get data
                var dt = DataConn.StoreFillDS("Get_Info_PO_POitem", System.Data.CommandType.StoredProcedure, sRealID, PartNumber, sPlant, sCate, barcodeId, PstgDate);
                if (dt.Rows.Count > 0)
                {
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                }
            }
        }


    }
}