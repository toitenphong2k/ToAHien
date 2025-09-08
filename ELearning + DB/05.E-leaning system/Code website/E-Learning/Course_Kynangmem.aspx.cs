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
    public partial class Course_Kynangmem : System.Web.UI.Page
    {
        public DataTable dtCourse_NotJoin = new DataTable();
        public DataTable dtAllCourse_Join = new DataTable();
        public DataTable dtAllCourse_Finish = new DataTable();
        public string Username = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"].ToString().Trim() != "")
                {
                    Username = Session["UserName"].ToString();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                All_Course_Join(Username);
                All_Course_NotJoin(Username);
                All_Course_Finish(Username);
            }
        }
        public void All_Course_Join(string UserTraining)

        {
            dtAllCourse_Join = DBConnect.FillStore("SP_Training_ListCourse_QLMem_MustLearning", CommandType.StoredProcedure, UserTraining);
        }

        public void All_Course_NotJoin(string UserTraining)

        {
            dtCourse_NotJoin = DBConnect.FillStore("SP_Training_ListCourse_QLMem_NotJoin", CommandType.StoredProcedure, UserTraining);
        }
        public void All_Course_Finish(string UserTraining)

        {
            dtAllCourse_Finish = DBConnect.FillStore("SP_Training_ListCourse_QLMem_Finish", CommandType.StoredProcedure, UserTraining);
        }


    }
}