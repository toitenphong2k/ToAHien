using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;


namespace E_Learning.App_Start
{
    public abstract class BasePage : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }
    }
}