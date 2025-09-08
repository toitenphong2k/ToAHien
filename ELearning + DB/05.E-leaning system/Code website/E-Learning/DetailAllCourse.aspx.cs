using E_Learning.Connect;
using System;
using System.Data;
using System.Web.Services;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace E_Learning
{
    public partial class DetailAllCourse : System.Web.UI.Page
    {
        public DataTable dtDetailCourse = new DataTable();
        public DataTable dtUserLesson = new DataTable();
        public DataTable dtResultTraing = new DataTable();

        public DataTable dtExam = new DataTable();
        public DataTable dtCourse = new DataTable();
        public DataTable dtCourseuser = new DataTable();

        public DataTable dtVideo = new DataTable();
        public string CourseID = null;
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
                CourseID = Request.QueryString["CourseID_"].ToString();
                Session["CourseID"] = CourseID.ToString();
                hdfCourseID.Value = Session["CourseID"].ToString().Trim();
                hdfUserTraing.Value = Session["Username"].ToString().Trim();
                BindCouse_Detail(hdfCourseID.Value.ToString());
               
            }            
        }
        public void LoadCourse(string CourseID)
        {
            dtDetailCourse = DBConnect.FillStore("SP_Training_DetailCourse", CommandType.StoredProcedure, CourseID);
        }
       
        public void BindCouse_Detail(string CourseID)
        {
            dtCourse  = DBConnect.FillStore("SP_Training_BindCourse", CommandType.StoredProcedure, CourseID);
            lblNameCouse.Text = dtCourse.Rows[0]["NameCourse"].ToString();
            lblgioithieu.Text = dtCourse.Rows[0]["introduce"].ToString();
            lblnoidung.Text = dtCourse.Rows[0]["Decription"].ToString(); 
        }
      
    }
} 