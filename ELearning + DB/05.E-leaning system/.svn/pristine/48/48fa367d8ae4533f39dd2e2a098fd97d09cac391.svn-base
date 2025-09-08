using System;
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
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Net.Mail;
using ClosedXML.Excel;

namespace E_Learning
{
    public partial class SendEmail_Remider : System.Web.UI.Page
    {
        public string Username = "";
        
        public OleDbConnection MyConnection { get; private set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllData();
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
        public void LoadAllData()
        {
           DataTable dtReportCourse = DBConnect.FillStore("S_Report_Traing_Learning_LisEmail_SendRemider_Load", CommandType.StoredProcedure);
            rptData.DataSource = dtReportCourse;
            rptData.DataBind();
        }
      
        public void BindSearch(string CourseID )
        {
            DataTable dtReportCourse = DBConnect.FillStore("[S_Report_Traing_Learning_LisEmail_SendRemider]", CommandType.StoredProcedure, CourseID);
            rptData.DataSource = dtReportCourse;
            rptData.DataBind();
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

        protected void bttDownload_ServerClick(object sender, EventArgs e)
        {
           
                DataTable dtSerch = new DataTable();
                string Course = ddlCourse.SelectedValue.ToString();
                if (ddlCourse.SelectedItem.ToString() != "---Select Course---")
                {
                    dtSerch = DBConnect.StoreFillDS("S_Report_Traing_Learning_LisEmail_SendRemider", System.Data.CommandType.StoredProcedure, Course);
                }
                else
                {
                    dtSerch = DBConnect.StoreFillDS("S_Report_Traing_Learning_LisEmail_SendRemider_Load", System.Data.CommandType.StoredProcedure);

                }

            if (dtSerch.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dtSerch, "Training");

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Download_ListLesson.xlsx");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }

            }

        }
        protected void bttSendEmail_ServerClick(object sender, EventArgs e)
        {

            DataTable dtListEmail = new DataTable();
            DataTable dtListEmailCC = new DataTable();
            dtListEmail = DBConnect.FillStore("[S_Report_Traing_Learning_LisEmail_SendRemider]", CommandType.StoredProcedure, ddlCourse.SelectedValue.ToString());

            if (dtListEmail.Rows.Count > 0)
            {

                 for(int i = 0; i < dtListEmail.Rows.Count; i++)
                    {
                    string UserName = dtListEmail.Rows[i]["UserName"].ToString();
                    string FullName = dtListEmail.Rows[i]["FullName"].ToString();
                    string EmailAddress = dtListEmail.Rows[i]["EmailAddress"].ToString();
                    string Subject = "E-LEARNING] NHẮC LỊCH HOÀN THÀNH KHÓA HỌC";
                    string CouseName = dtListEmail.Rows[i]["NameCourse"].ToString();
                    string Dates = dtListEmail.Rows[i]["SubDate"].ToString();
                    SendEmail(Subject, EmailAddress, UserName, FullName, CouseName, Dates);
                 }    
                

            }
        }
        public void SendEmail(string subject, string Email, string UserName_, string FullName_,string NameCourse,string Dates)
        {
            if (ddlCourse.SelectedValue.ToString() != "---Select Course---")
            {
                
                            string header_;
                            System.Net.Mail.SmtpClient objClient = new System.Net.Mail.SmtpClient("157.8.1.131");
                            subject = subject.Replace('\r', ' ').Replace('\n', ' ');
                            System.Net.Mail.MailAddress mail = new System.Net.Mail.MailAddress("psnv.isg@vn.panasonic.com");
                            System.Net.Mail.MailMessage objMessage = new System.Net.Mail.MailMessage
                            {
                                Priority = MailPriority.High,
                                IsBodyHtml = true,
                                From = mail,
                                Subject = subject,

                            };
                            objMessage.IsBodyHtml = true;
                            //Get data Header Images to Content of Email
                            string Header_Email = "";
                            Header_Email += "";
                            using (StreamReader reader2 = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/Email_html/SendEmailRemider.html")))
                            {
                                header_ = reader2.ReadToEnd();
                            }

                            header_ = header_.Replace("FullName", FullName_);
                            header_ = header_.Replace("UserName", UserName_);
                            header_ = header_.Replace("CourseName", NameCourse);
                            header_ = header_.Replace("RemiderDate", Dates);
                            objMessage.Body = header_;

                            objMessage.To.Add(new MailAddress(Email));
                            objClient.Send(objMessage);
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Send Email successfully');", true);

                //        }
                //    }
                //}
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Lựa chọn khóa học cần gửi nhắc nhở.');", true);

            }
        }
    }
}