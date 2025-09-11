using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void LogIn(object sender, EventArgs e)
    {
        if (IsValid)
        {
           /* if (txtUser.Text.Trim() == "FE" && txtPassword.Text.Trim() == "Password1")
            {
                Session["login"] = txtUser.Text.Trim();
                Response.Redirect("ListFilesCSFE.aspx");
            }
*/

            if (txtUser.Text.Trim() == "Proc" && txtPassword.Text.Trim() == "Proc@123")
            {
                Session["login"] = txtUser.Text.Trim();
                Response.Redirect("ListFilesCS.aspx");
            }

		
		/*if (txtUser.Text.Trim() == "FA" && txtPassword.Text.Trim() == "Fa123")
            {
                Session["login"] = txtUser.Text.Trim();
                Response.Redirect("ListFilesCSProduction.aspx");
            }

        if (txtUser.Text.Trim() == "OQC" && txtPassword.Text.Trim() == "OQC123")
        {
            Session["login"] = txtUser.Text.Trim();
            Response.Redirect("ListFilesCSOQC.aspx");
        }*/

            else
            {
                lblError.Text = "USER NAME OR PASSWORD IS NOT CORRECT";
            }
        }
    }
}