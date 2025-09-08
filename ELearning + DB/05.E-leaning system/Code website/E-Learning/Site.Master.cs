using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

namespace E_Learning
{
    public partial class SiteMaster : MasterPage
    {
        public string nones = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Init();
        }
        protected void Init()
        {
            if (Session["RoleFun"].ToString() == "")
            {
                
            }
            else
            {
                if (HttpContext.Current.Session["RoleFun"].ToString() != "Admin")
                {
                    nones = "none !important";
                }
            }
        }
        protected void lbkLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
        protected void lbkChangePass_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("ChangPassword.aspx");
        }
    }
}