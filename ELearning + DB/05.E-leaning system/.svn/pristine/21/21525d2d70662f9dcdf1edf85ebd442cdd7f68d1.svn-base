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
    public partial class ChangPassword : System.Web.UI.Page
    {
        public string UserName;
        public string OldPassWord;
        public string NewPassWord;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Session["username"] == null)
                {
                    Response.Redirect("Login.aspx", true);
                }
                else
                {
                    Session["Username"] = null;
                }
            }
        }

        protected void bttChange_ServerClick(object sender, EventArgs e)
        {
            NewPassWord = txtNewPassword.Text.ToString().Trim();
            OldPassWord = txtPassword_Old.Text.ToString().Trim();
            UserName = txtUserName.Text.ToString().Trim();

            if (NewPassWord.ToString().Trim() == "" )
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Điền thông tin mật khẩu mới.');", true);
            }

            else if (UserName.ToString().Trim() == "" )
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Điền thông tin user đăng nhập.');", true);
            }
            else  if (txtPassword_Old.ToString().Trim() == "")
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Điền thông tin mật khẩu cũ.');", true);
                }

            else if ((UserName != "" && NewPassWord.ToString().Trim() != "" && UserName.ToString().Trim() != ""))
            {

                if (txtNewPassword.Text.ToString().Trim() == txtPassword_Old.Text.ToString().Trim())
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Mật khẩu mới và mật khẩu cũ giống nhau.');", true);
                }
                else
                {
                    try
                    {
                        string Username = txtUserName.Text.ToString();
                        string Password = txtNewPassword.Text.ToString();
                        DataTable dtCheckupdate = DBConnect.StoreFillDS("S_Employee_ChangePwd", CommandType.StoredProcedure, Username, Password, OldPassWord);
                        string CheckStatus = dtCheckupdate.Rows[0]["CheckUpdate"].ToString();
                        if(CheckStatus == "NG")
                        {
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Thông tin user đăng nhập và mật khẩu hiện tại không đúng.');", true); 
                        }
                        else if(CheckStatus == "OK")
                        {
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Đổi mật khẩu thành công.');", true);
                            txtUserName.Text = "";
                            txtNewPassword.Text = "";
                            txtPassword_Old.Text = "";
                        }    

                       

                    }
                    catch (Exception)
                    {

                    }
                }

              
            }

        }

        protected void bttCancel_ServerClick(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtNewPassword.Text = "";
            txtPassword_Old.Text = "";
        }
    }
}