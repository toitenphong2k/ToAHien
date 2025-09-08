using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using E_Learning.Connect;

namespace E_Learning
{
    public partial class HomeLogin : System.Web.UI.Page
    {
        public string UserName ;
        public string PassWord ;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Session["Username"] = null;
            }

        }
        protected void bttLogin_Click(object sender, EventArgs e)
        {
            
            UserName = txtUserName.Text.ToString().Trim();
            PassWord = txtPass.Text.ToString().Trim();
            if (UserName.ToString().Trim() == "")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Điền thông tin tài khoản.');", true);
            }
            else if ((UserName != "")  && (PassWord == ""))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Điền thông tin mật khẩu.');", true);
            }
            else if ((UserName != "") && PassWord != "")
            {
                DataTable dt = DBConnect.StoreFillDS("SP_Login", CommandType.StoredProcedure, UserName, PassWord);
                try
                {
                    if (dt.Rows.Count == 0)
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Tài khoản đăng nhập hoặc mật khẩu bị sai.');", true);
                        
                    }
                    else
                    {
                        Session["Username"] = dt.Rows[0]["UserName"].ToString();
                        Session["RoleFun"] = dt.Rows[0]["Role"].ToString();
                        Response.Redirect("Course_All.aspx", false);
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Đăng nhập thành công.');", true);
                    }
                }
                catch(Exception )
                {

                }
            }
        
        }

        protected void bttExit_Click(object sender, EventArgs e)
        {

        }

        protected void bttReset_ServerClick(object sender, EventArgs e)
        {

        }

        protected void bttSendEmail_ServerClick(object sender, EventArgs e)
        {

        }

        protected void bttResetPWD_ServerClick(object sender, EventArgs e)
        {

        }

        protected void bttCancel_ServerClick(object sender, EventArgs e)
        {

        }
    }
}