using E_Learning.Connect;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace E_Learning
{
    public partial class TheExam : System.Web.UI.Page
    {
        public DataTable dtQuestion = new DataTable();
        public DataTable dtQuestionStatus = new DataTable();
        public string Username;
        public string CourseID;
        
        int CheckBoxIndex;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"].ToString().Trim() == "")
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Username = Session["UserName"].ToString();
                }
                Session["User"] = Session["Username"].ToString().Trim();
                //CourseID = "12";
                Session["Course"] = CourseID;

                BindAns(CourseID);
                BindLesson(CourseID);
              //  CheckStatuButton();

            }
        }
        public void BindQuestion(string CourseID)
        {
            //  dtQuestion = DBConnect.FillStore("S_TheExam_BindQuestion", CommandType.StoredProcedure, CourseID);
        }


     

        public void BindAns(string CourseID)
        {
            // dtQuestion = DBConnect.FillStore("S_TheExam_BindAnswer", CommandType.StoredProcedure, CourseID);
            listQuestAnser.DataSource = DBConnect.FillStore("S_TheExam_BindAnswer", CommandType.StoredProcedure, CourseID);
            listQuestAnser.DataBind();
        }

        public void BindLesson(string CourseID)
        {

            dtListQuestion.DataSource = DBConnect.FillStore("S_TheExam_BindQuestion", CommandType.StoredProcedure, CourseID);
            dtListQuestion.DataBind();
        }

    }
}