using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Traceability_Hien3.App_Code;
using System.Data;
using System.Web.Services;
using System.Globalization;

namespace Traceability_Hien3
{
    public partial class MW_DetailHistory : System.Web.UI.Page
    {
        public DataTable dk;
        public DataTable dtAS4;
        string model_ = "";
        string DateTime_ = "";
        string Serial_ = "";
        string SannerSeial_ = "";
        public string Click_process = "";
        string line = "";
        public DataTable ds;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // txtDateInput.Value = "2020-11-11";
                txtDateInput.Value = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                DateTime_ = txtDateInput.Value.ToString();
                load_model();
                load_line();
                if (cbModel.Text != "--Select Model--")
                {
                    model_ = cbModel.Text;
                }

                if (cbLine.Text != "--Select Line--")
                {
                    line = cbLine.Text.ToString();
                }

                if (this.txtScanSerial.ToString() != "")
                {
                    SannerSeial_ = txtScanSerial.Value.ToString();
                }
                //var dk = new DataTable();
                dk = DataConnect_MW.StoreFillDS("SP_REPORT_Search", CommandType.StoredProcedure, model_, line, SannerSeial_, DateTime_);
                loadsanpham();
            }

        }

        [WebMethod]
        public static string GetManetron(string a1, string a2, string a3, string a4)
        {
            List<string> docResult = new List<string>();
            try
            {
                DataTable ds = DataConnect_MW.StoreFillDS("SP_REPORT_Manetron_PO", CommandType.StoredProcedure, a1, a2, a3, a4);
                if (ds.Rows.Count > 0)
                {
                    docResult.Add(ds.Rows[0][0].ToString());

                }
                return docResult[0];
            }
            catch (Exception)
            {
                docResult.Add("Không tìm thấy thông tin PO của Magenetron");
                return docResult[0];
            }
        }

        [WebMethod]
        public static List<string> GetFiltterPCB(string a1, string a2)
        {

            List<string> docResult = new List<string>();
            try
            {
                DataTable ds = DataConnect_MW.StoreFillDS("SP_REPORT_PCB_PO", CommandType.StoredProcedure, a1, a2);
                if (ds.Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Columns.Count; i++)
                    {
                        docResult.Add(ds.Rows[0][i].ToString());
                    }
                }
                return docResult;
            }
            catch (Exception)
            {
                docResult.Add("Không tìm thấy thông tin PO của Filter");
                return docResult;
            }

        }

        protected void loadsanpham()
        {
            string html = "";
            if (dk.Rows.Count > 0)
            {
                int m = 1;
                for (int i = 0; i < dk.Rows.Count; i++)
                {

                    html +=
                   "<tr>  " +
                   "<td>" + m + " </td>    " +
                   "<td>" + dk.Rows[i]["ModeName"].ToString() + "</td>  " +
                   "<td>" + dk.Rows[i]["LineName"].ToString() + "</td> " +
                   "<td>" + dk.Rows[i]["SerialNo"].ToString() + "</td>   " +
                   "<td><a data-toggle=\"tooltip\" data-placement=\"top\" title=\"Click here to show\" href=\"javascript:void(0);\" OnClick= \"return ShowPopup('" + dk.Rows[i]["Magenetron"].ToString().Trim() + "','" + dk.Rows[i]["Date_FA"].ToString().Trim() + "','" + dk.Rows[i]["ModeName"].ToString().Trim() + "','" + dk.Rows[i]["Date_FA"].ToString().Trim() + "')\" > " + dk.Rows[i]["Magenetron"].ToString() + " </a></td> " +
                   "<td><a data-toggle=\"tooltip\" data-placement=\"top\" title=\"Click here to show\" href=\"javascript:void(0);\" OnClick= \"return ShowPopupPCB('" + dk.Rows[i]["Filter_PCB"].ToString().Trim() + "','" + dk.Rows[i]["Date_FA"].ToString().Trim() + "')\" > " + dk.Rows[i]["Filter_PCB"].ToString() + " </a></td> " +
                   "<td><a data-toggle=\"tooltip\" data-placement=\"top\" title=\"Click here to show\" href=\"javascript:void(0);\" OnClick= \"return ShowPopupPCB('" + dk.Rows[i]["Pannal_PCB"].ToString().Trim() + "','" + dk.Rows[i]["Date_FA"].ToString().Trim() + "')\" > " + dk.Rows[i]["Pannal_PCB"].ToString() + " </a></td> " +
                    " <td>" + dk.Rows[i]["Date_FA"].ToString() + " </td>    " +
                    " <td>" + dk.Rows[i]["Date_Weight"].ToString() + " </td>    " +
                     " <td>" + dk.Rows[i]["Date_Shink"].ToString() + " </td>    " +
                   " </tr>  ";
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

        private void load_model()
        {
            var dt = DataConnect_MW.StoreFillDS("[SP_REPORT_LoadModel]", System.Data.CommandType.StoredProcedure);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr[0] = "--Select Model--";
                dt.Rows.InsertAt(dr, 0);
                cbModel.DataSource = dt;
                cbModel.DataTextField = "ModelName";
                cbModel.DataValueField = "ModelName";
                cbModel.DataBind();
            }
        }

        private void load_line()
        {
            var dt = DataConnect_MW.StoreFillDS("SP_REPORT_LoadLINE", System.Data.CommandType.StoredProcedure);
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
        //[WebMethod]
        public void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbModel.Text != "--Select Model--")
            {
                model_ = cbModel.Text;
            }

            if (cbLine.Text != "--Select Line--")
            {
                line = cbLine.Text.ToString();
            }

            if (this.txtDateInput.ToString() != "")
            {
                DateTime_ = txtDateInput.Value.ToString();
            }
            if (this.txtScanSerial.ToString() != "")
            {
                SannerSeial_ = txtScanSerial.Value.ToString();
            }

            //var dk = new DataTable();
            dk = DataConnect_MW.StoreFillDS("SP_REPORT_Search", CommandType.StoredProcedure, model_, line, SannerSeial_, DateTime_);
            loadsanpham();
            //GridView1.DataSource = dk;
            //GridView1.DataBind();

        }


    }
}