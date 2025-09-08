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
    public partial class Course_All : System.Web.UI.Page
    {
        
        public DataTable dtCourseJoin = new DataTable();
        public DataTable dtCourseAllCourse = new DataTable();
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
                // LoadCourse(Username);
                All_Course();
                All_Course_AlreadyJoin(Username);
            }
        }
        //public void LoadCourse(string UserLogin)
        
        //{
        //    dtCourse = DBConnect.FillStore("SP_Training_ListCourse", CommandType.StoredProcedure,UserLogin);
        //}

        public void All_Course()

        {
            dtCourseAllCourse = DBConnect.FillStore("SP_Training_ListCourse_PSNV_All", CommandType.StoredProcedure);
        }

        public void All_Course_AlreadyJoin(string UserTraining)

        {
            dtCourseJoin = DBConnect.FillStore("SP_Training_ListCourse_PSNV_Join", CommandType.StoredProcedure, UserTraining);
        }

        public void Search(string NameCourse)
        {
            string NewNameCourse = 'N'+"'" + NameCourse.Replace('"',' ');
            dtCourseAllCourse = DBConnect.FillStore("SP_Training_ListCourse_PSNV_All_Search", CommandType.StoredProcedure, NewNameCourse);
            dtCourseJoin = DBConnect.FillStore("SP_Training_ListCourse_PSNV_Join_Search", CommandType.StoredProcedure, Session["UserName"].ToString().Trim(), NewNameCourse);

        }
        protected void bttSearch_Click(object sender, EventArgs e)
        {
            Search(txtSeach.Text.ToString().Trim());
        }

        protected void txtSeach_TextChanged(object sender, EventArgs e)
        {
            Search(txtSeach.Text.ToString().Trim());
        }
    }
}