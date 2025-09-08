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
    public partial class table : System.Web.UI.Page
    {
        public DataTable dk;
        public DataTable dtAS4;
        string model_ = "";
        string from_ = "";
        string to_ = "";
        string serial_ = "";
        public string Click_process = "";

        protected void loadsanpham()
        {
            string html = "";
            if (dk.Rows.Count > 0)
            {
                int m = 1;
                for (int i = 0; i < dk.Rows.Count; i++)
                {
                    // style=\"display: none\"
                    // Load PCBID
                    string[] pcbid;
                    string kk = "";
                    var pcb_id = "";
                    var partcard = "";
                    string k2 = "";
                    string optical = "";
                    //Get:  select PCBID from TBL_FA_INFOR where TEMPORY_SERIAL = @TempSerial
                    //var d1 = DataConn.StoreFillDS("GetPCBIDfromTempID", CommandType.StoredProcedure, dk.Rows[i]["PROD_SERIAL"].ToString());
                    //var d1 = DataConn.StoreFillDS("GetPCBIDfromTempID", CommandType.StoredProcedure, dk.Rows[i]["TEMPORY_SERIAL"].ToString());
                    var d1 = DataConn.StoreFillDS("GetPCBIDfromTempID", CommandType.StoredProcedure, dk.Rows[i]["TEMPORY_SERIAL"].ToString());
                    if (d1.Rows.Count > 0)
                    {
                        kk = d1.Rows[0][0].ToString();
                        string[] k1 = kk.Split(';');
                        optical = d1.Rows[0][1].ToString();
                    }

                    //Phong Edit
                    string viewOptical;
                    if (dk.Rows[i]["OPTICALID"].ToString() != "NOT")
                    {
                        viewOptical = dk.Rows[i]["OPTICALID"].ToString().Substring(0, 6);
                    }
                    else
                    {
                        viewOptical = dk.Rows[i]["OPTICALID"].ToString();
                    }


                    html +=
                   " <tr>                                                                                                           " +
                   " <td>" + m + " </td>                                                                                              " +
                   " <td>" + dk.Rows[i]["MODEL_NM"].ToString() + "</td>                                                               " +
                   " <td><a data-toggle=\"tooltip\" data-placement=\"top\" title=\"Click here to show\" href=\"javascript:void(0);\" OnClick= \"return ShowPopup('" + kk + "')\" > " + dk.Rows[i]["TEMPORY_SERIAL"].ToString() + " </a></td>           " +
                   " <td>" + dk.Rows[i]["PROD_SERIAL"].ToString() + "</td>                                                            " +
                   " <td><a data-toggle=\"tooltip\" data-placement=\"top\" title=\"Click here to show\" href=\"javascript:void(0);\" OnClick= \"return ShowPopupOptical('" + optical + "')\" > " + viewOptical + "...</a></td>                                                                  " +
                   " <td>" + dk.Rows[i]["ASSY2"].ToString() + "</td>                                                                  " +
                   " <td>" + dk.Rows[i]["ASSY4"].ToString() + "</td>                                                                  " +
                   " <td>" + dk.Rows[i]["VISUAL_CHECK"].ToString() + "</td>                                                           " +
                   " <td>" + dk.Rows[i]["ACCESSORIES_DT"].ToString() + " </td>                                                        " +
                   " <td>" + dk.Rows[i]["WEIGHT_DT"].ToString() + " </td>                                                             " +
                    " <td>" + dk.Rows[i]["SHRINK_DT"].ToString() + " </td>    " +
                    //" <td>" + kk + " </td>    "+
                   " </tr>                                                                                                          ";
                    m = m + 1;
                }
            }
            else
            {
                html +=
           " <tr> " +
           "     <td colspan=\"10\"><p class=\"text-center\"> <b>No records found!</b>  </p> </td> " +
           " </tr> ";
            }
            ltrsanpham.Text = html;
        }

        //protected void ShowPopup1_ServerClick(object sender, EventArgs e)
        //{
        //    //Response.Redirect("default2.aspx", false);
        //    TextBox1.Text = e.ToString();
        //}


        private void load_model()
        {
            var dt = DataConn.StoreFillDS("LoadModelCode", System.Data.CommandType.StoredProcedure);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr[0] = "--Select Model--";
                dt.Rows.InsertAt(dr, 0);
                cbModel.DataSource = dt;
                cbModel.DataTextField = "MODEL_NM";
                cbModel.DataValueField = "MODEL_NM";
                cbModel.DataBind();
            }
        }
        private void load_line()
        {
            var dt = DataConn.StoreFillDS("LoadLineName", System.Data.CommandType.StoredProcedure);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr[0] = "--Select Line--";
                dt.Rows.InsertAt(dr, 0);
                cbLine.DataSource = dt;
                cbLine.DataTextField = "LineName";
                cbLine.DataValueField = "LineName";
                cbLine.DataBind();
            }
            //
        }
        [WebMethod]
        public void Get_Main_board(string tempID)
        {
            string sss = tempID;
            //var dk = DataConn.StoreFillDS("Get_Main_board", CommandType.StoredProcedure);
        }
        public void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbModel.Text != "--Select Model--")
            {
                model_ = cbModel.Text;
            }
            if (txtFrom.Value.ToString() != "")
            {
                from_ = txtFrom.Value.ToString();
            }
            if (txtTo.ToString() != "")
            {
                to_ = txtTo.Value.ToString();
            }
            if (txtSerialNo.ToString() != "")
            {
                serial_ = txtSerialNo.Value.ToString();
            }
            //var dk = new DataTable();
            dk = DataConn.StoreFillDS("LoadDataHistoryPT", CommandType.StoredProcedure, model_, from_, to_, serial_);
            loadsanpham();
            //GridView1.DataSource = dk;
            //GridView1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFrom.Value = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                from_ = txtFrom.Value;
                txtTo.Value = DateTime.Now.ToString("yyyy-MM-dd");
                to_ = txtTo.Value;


                load_model();
                load_line();
                dk = DataConn.StoreFillDS("LoadDataHistoryPT", CommandType.StoredProcedure, model_, from_, to_, serial_);
                // load grid;
                loadsanpham();
            }
        }
        [WebMethod]
        protected void Search_Click(string tempID)
        {
            var dt = DataConn.StoreFillDS("LoadLineName", System.Data.CommandType.StoredProcedure);

            var html = "";
            html += " " +
              "  <div class=\"tile\"> " +
              "  <div class=\"tile-body\">                                                    " +
              "  <div class=\"table-responsive\">                                             " +
              "  <table class=\"table table-hover table-bordered\" id=\"sampleTable1\">         " +
              "  <thead>                                                                    " +
              "  <tr>                                                                       " +
              "  <th>No</th>                                                                " +
              "  <th>Model Name</th>                                                        " +
              "  <th>Tempory Serial</th>                                                    " +
              "  <th>Product Serial</th>                                                    " +
              "  <th>ASSY2</th>                                                             " +
              "  <th>ASSY4</th>                                                             " +
              "  <th>Visual Check</th>                                                      " +
              "  <th>Acessories</th>                                                        " +
              "  <th>Weigh</th>                                                             " +
              "  <th>Shrink</th>                                                            " +
              "  </tr>                                                                      " +
              "  </thead>                                                                   " +
              "  <tbody>                                                                    " +
              "  <tr>                                                                       " +
              "  <td>aaaaaaaaaaaaaa</td>                                                                  " +
              "  </tr>                                                                      " +
              "  </table>                                                                   " +
              "  </div>                                                                     " +
              "  </div>                                                                     " +
              "  </div>                                                                     ";
            Literal2.Text = html;

            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('This is title', 'This is body');", true);
        }

        protected void TempClick(object sender, EventArgs e)
        {
            var dt = DataConn.StoreFillDS("LoadLineName", System.Data.CommandType.StoredProcedure);

            var html = "";
            html += " " +
              "  <div class=\"tile\"> " +
              "  <div class=\"tile-body\">                                                    " +
              "  <div class=\"table-responsive\">                                             " +
              "  <table class=\"table table-hover table-bordered\" id=\"sampleTable1\">         " +
              "  <thead>                                                                    " +
              "  <tr>                                                                       " +
              "  <th>No</th>                                                                " +
              "  <th>Model Name</th>                                                        " +
              "  <th>Tempory Serial</th>                                                    " +
              "  <th>Product Serial</th>                                                    " +
              "  <th>ASSY2</th>                                                             " +
              "  <th>ASSY4</th>                                                             " +
              "  <th>Visual Check</th>                                                      " +
              "  <th>Acessories</th>                                                        " +
              "  <th>Weigh</th>                                                             " +
              "  <th>Shrink</th>                                                            " +
              "  </tr>                                                                      " +
              "  </thead>                                                                   " +
              "  <tbody>                                                                    " +
              "  <tr>                                                                       " +
              "  <td>aaaaaaaaaaaaaa</td>                                                                  " +
              "  </tr>                                                                      " +
              "  </table>                                                                   " +
              "  </div>                                                                     " +
              "  </div>                                                                     " +
              "  </div>                                                                     ";
            Literal2.Text = html;

            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('This is title', 'This is body');", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var dt = DataConn.StoreFillDS("LoadLineName", System.Data.CommandType.StoredProcedure);

            var html = "";
            html += " " +
              "  <div class=\"tile\"> " +
              "  <div class=\"tile-body\">                                                    " +
              "  <div class=\"table-responsive\">                                             " +
              "  <table class=\"table table-hover table-bordered\" id=\"sampleTable1\">         " +
              "  <thead>                                                                    " +
              "  <tr>                                                                       " +
              "  <th>No</th>                                                                " +
              "  <th>Model Name</th>                                                        " +
              "  <th>Tempory Serial</th>                                                    " +
              "  <th>Product Serial</th>                                                    " +
              "  <th>ASSY2</th>                                                             " +
              "  <th>ASSY4</th>                                                             " +
              "  <th>Visual Check</th>                                                      " +
              "  <th>Acessories</th>                                                        " +
              "  <th>Weigh</th>                                                             " +
              "  <th>Shrink</th>                                                            " +
              "  </tr>                                                                      " +
              "  </thead>                                                                   " +
              "  <tbody>                                                                    " +
              "  <tr>                                                                       " +
              "  <td>bbbbbbbbbbbbbbbbbbb</td>                                               " +
              "  </tr>                                                                      " +
              "  </table>                                                                   " +
              "  </div>                                                                     " +
              "  </div>                                                                     " +
              "  </div>                                                                     ";
            Literal2.Text = html;
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('This is title', 'This is body');", true);
        }
    }
}