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
using System.Net.Mail;

namespace E_Learning
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        public string UserName;
        public string Password;
        public string EmailSent;
        public string Username;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              //  Session["Username"] = null;
                //if (Session["UserName"].ToString().Trim() == "")
                //{
                //    Response.Redirect("Login.aspx");
                //}
                //else
                //{
                  

                //}
                
            }
        }


        protected void bttRecover_ServerClick(object sender, EventArgs e)
        {
            

            if (txtEmailReset.Text.ToString().Trim() == "")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Điền thông tin email.');", true);
            }
            else if (txtUserName.Text.ToString().Trim() == "")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Điền thông tin user đăng nhập.');", true);
            }
            else if ((txtEmailReset.Text != ""))
            {
                DataTable dt = DBConnect.StoreFillDS("S_Employee_Recoder", CommandType.StoredProcedure, txtEmailReset.Text, txtUserName.Text.ToString());
                string CheckAcount = dt.Rows[0]["TotalAccount"].ToString();
                try
                {
                    if (CheckAcount == "0")
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Thông tin user đăng nhập hoặc email không tồn tại hệ thống.');", true);

                    }
                    else
                    {
                        DataTable dtUser = DBConnect.StoreFillDS("S_Employee_GetInformation", CommandType.StoredProcedure, txtEmailReset.Text.ToString(), txtUserName.Text.ToString());
                        UserName = dtUser.Rows[0]["UserName"].ToString();
                        Password = dtUser.Rows[0]["Password"].ToString();
                        EmailSent = dtUser.Rows[0]["EmailAddress"].ToString();
                        string Subject = "Cấp lại mật khẩu cho user:" + UserName;
                        SendEmail(UserName, EmailSent, Subject, Password);
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Gửi mail cấp lại mật khẩu thành công');", true);
                        txtEmailReset.Text = "";
                    }
                }
                catch (Exception)
                {

                }
            }


        }

        public static string CreateRandomPassword(int PasswordLength)
        {
            string _allowedChars = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ";
            Random randNum = new Random();
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }


        public void SendEmail(string userName,string Email,string subject,string Pass)
            {
            string header_;
            System.Net.Mail.SmtpClient objClient = new System.Net.Mail.SmtpClient("157.8.1.131");
            subject = subject.Replace('\r', ' ').Replace('\n', ' ');
            System.Net.Mail.MailAddress mail = new System.Net.Mail.MailAddress("psnv.isg@vn.panasonic.com","E-leaning system") ;
            System.Net.Mail.MailMessage objMessage = new System.Net.Mail.MailMessage
            {
                Priority = MailPriority.High,
                IsBodyHtml = true,
                From = mail,
                Subject = subject
            };
            objMessage.IsBodyHtml = true;
            //Get data Header Images to Content of Email
            string Header_Email = "";
            Header_Email += "";
            using (StreamReader reader2 = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/Email_html/ResetEmail.html")))
            {
                header_ = reader2.ReadToEnd();

            }

            
            header_ = header_.Replace("UserName", userName);
            header_ = header_.Replace("Password", Pass);
            objMessage.Body = header_;
            objMessage.To.Add(new MailAddress(Email));
            objClient.Send(objMessage);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Gửi mail cấp lại mật khẩu thành công.');", true);
        }

        protected void bttCancel_ServerClick(object sender, EventArgs e)
        {

        }

        protected void bttCancel_ServerClick1(object sender, EventArgs e)
        {
            txtEmailReset.Text = "";
            txtUserName.Text = "";

        }

        protected void bttLOGIN_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }
    }
}