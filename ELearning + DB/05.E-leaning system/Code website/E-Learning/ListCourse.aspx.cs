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
    public partial class All_Page : System.Web.UI.Page
    {
        public DataTable dtCourse = new DataTable();
        public DataTable dtAllCourse = new DataTable();
        public string Username = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Username = Session["Username"].ToString().Trim();
                LoadCourse(Username);
                All_Course(Username);
            }
        }
        public void LoadCourse(string UserLogin)
        
        {
            dtCourse = DBConnect.FillStore("SP_Training_ListCourse", CommandType.StoredProcedure,UserLogin);
        }

        public void All_Course(string UserTraining)

        {
            dtAllCourse = DBConnect.FillStore("[SP_Training_ListCourse_PSNV]", CommandType.StoredProcedure, UserTraining);
        }


    }
}