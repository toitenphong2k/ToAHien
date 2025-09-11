using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LogIn(object sender, EventArgs e)
    {
        if (IsValid)
        {
            if (txtUser.Text.Trim() == "FPQC" && txtPassword.Text.Trim() == "Admin123")
            {
                Session["login"] = txtUser.Text.Trim();
                Response.Redirect("ListFilesCS.aspx");
            }
            else 
            {
                lblError.Text = "USER NAME OR PASSWORD IS NOT CORRECT";
            }
        }
    }
}