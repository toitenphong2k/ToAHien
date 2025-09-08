﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using E_Learning.Connect;
using System.Globalization;
using System.Xml;
using System.Xml.XPath;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Net;

namespace E_Learning
{
    public partial class ReportCourse : System.Web.UI.Page
    {
        public string Username = "";
        public DataTable dtReportCourse = new DataTable();
        public OleDbConnection MyConnection { get; private set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadReport();
                BindCourse();
                
                if (Session["UserName"].ToString().Trim() == "")
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Username = Session["UserName"].ToString();

                }

            }
        }
        public void LoadReport()
        {
            dtReportCourse = DBConnect.FillStore("S_Report_Traing_Course_Summay", CommandType.StoredProcedure);
        }
       
      
        public void BindSearch(string CourseID )
        {

            dtReportCourse = DBConnect.FillStore("S_Report_Traing_Course_Summay_Search", CommandType.StoredProcedure, CourseID);
        }

       

        public void BindCourse()
        {
            DataTable dt = new DataTable();
            dt = DBConnect.FillStore("S_BindCourse_Master", CommandType.StoredProcedure);
            if (dt.Rows.Count > 0)
            {
                this.ddlCourse.Items.Clear();
                DataRow newRow2 = dt.NewRow();
                newRow2["NameCourse"] = "---Select Course---";
                dt.Rows.InsertAt(newRow2, 0);
                ddlCourse.DataTextField = "NameCourse";
                ddlCourse.DataValueField = "CourseID";
                ddlCourse.DataSource = dt;
                ddlCourse.DataBind();
            }
        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {

            BindSearch(ddlCourse.SelectedValue.ToString());
        }

        protected void bttPrintPDF_ServerClick(object sender, EventArgs e)
        {
            DataTable dtSerch = new DataTable();
            string Course = ddlCourse.SelectedValue.ToString();
            dtSerch = DBConnect.StoreFillDS("S_Report_Traing_Course_Summay_Search", System.Data.CommandType.StoredProcedure, Course);
            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            context.Response.ClearHeaders();
            String sr = string.Empty;
            
            

                sr += "<html ><body><table style =\"border-collapse: collapse;\">";
                sr += "<tr style =\"text-align:center; font-size:20px;\"> <td colspan='3'>PANASONIC SYSTEM NETWORKS VIETNAM</td></tr>";
                sr += "<tr style =\"text-align:center; font-size:20px; \"> <td colspan='3'>HUMAN RESOURCES SECTION </td></tr >";
                sr += "<tr> <td colspan='6'></td></ tr > ";
                sr += "<tr style =\"color:blue;text-align:center; font-size:20px; \"> <td colspan='6'> TRAINING COURSE SUMMARY</td></ tr > ";
                sr += "<tr> <td colspan='6'></td></ tr > ";
                 sr += "<tr style =\"color:black;text-align:center; font-size:20px; \"> " +

                  "<td  colspan='4' style =\"padding:5px;height:30px;font-size:13px;text-align: right\">  Report Date: </td>" +
                  "<td  style =\"padding:5px;height:30px;font-size:13px;text-align: right\">" + DateTime.Now.ToShortDateString().ToString()+ "</td>"+
               "</tr> ";
            sr += "<tr> <td colspan='6'></td></ tr > ";
            sr += "<tr style=\"color:blue; font-size:13px;text-align: center\" > ";
                       

            if (dtSerch.Rows.Count >= 0)
            {
                //foreach (DataColumn dc in DT_TOKHAI.Columns)
                //{
                //sr += "<th  style =\"padding:5px;height:30px;font-size:15px;border:solid;text-align: center\" > ";
                sr += "<th  style =\"padding:5px;height:30px;font-size:15px;border:solid;text-align: center\">";
                sr += "No";
                sr += "</th>";
                sr += "<th  style =\"padding:5px;height:30px;font-size:15px;border:solid;text-align: center\">";
                sr += "Course Name";
                sr += "</th>";
                sr += "<th  style =\"padding:5px;height:30px;font-size:15px;border:solid;text-align: center\">";
                sr += "Q'ty of trainees";
                sr += "</th>";
                sr += "<th  style =\"padding:5px;height:30px;font-size:15px;border:solid;text-align: center\">";
                sr += "Q'ty Trainees Feedback";
                sr += "</th>";
                sr += "<th  style =\"padding:5px;height:30px;font-size:15px;border:solid;text-align: center\">";
                sr += "Avg Trainees Evaluation Score";
                sr += "</th>";

                //sr += dc.ToString().Replace("\n", string.Empty).Replace("\t", string.Empty).Replace("\r", string.Empty) + "\t";
                //sr += "</th>";
                sr += "</tr>";
                sr += Environment.NewLine;
                foreach (DataRow dr in dtSerch.Rows)
                {
                    sr += "<tr style =\"padding:25px;height:30px;font-size:15px;text-align: center;\">";
                    for (int i = 0; i < dtSerch.Columns.Count; i++)
                    {
                        if (i == 0 || i == 2 || i == 3 || i == 4 || i == 5 )
                        {
                            sr += "<td style =\"padding:25px;border:solid;text-align:center;\">";
                            sr += dr[i].ToString().Replace("\n", string.Empty).Replace("\t", string.Empty).Replace("\r", string.Empty) + "\t";
                        }
                        sr += "</td>";
                    }
                    sr += "</tr>";
                    sr += Environment.NewLine;
                }
                //sr += "<tr> <td colspan='13'></td></ tr > ";
                //sr += "<tr style =\"text-align:right; font-size:15px;\"> <td colspan='11'><b>Công ty TNHH Panasonic System Networks Việt Nam</b></td></tr>";
                sr += "</table></body></html>";
                context.Response.ContentType = "application/vnd.ms-excel";
                context.Response.AddHeader("Content-Disposition", "attachment; filename=TRAINING COURSE SUMMARY.xls");
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());

                context.Response.Write(sr.Replace("'", ""));
                context.Response.Flush();
                context.Response.End();
                context.Response.Close();
            }
            Response.End();
        }
    }
}