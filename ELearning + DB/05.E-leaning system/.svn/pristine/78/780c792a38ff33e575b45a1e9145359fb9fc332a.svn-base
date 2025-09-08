using E_Learning.Connect;
using System;
using System.Data;
using System.Web.Services;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace E_Learning
{
    public partial class Detail_Course_Learning : System.Web.UI.Page
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

                if (Session["UserName"].ToString().Trim()  == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Username = Session["UserName"].ToString();
                    
                }
                CourseID = Request.QueryString["CourseID_"].ToString();
                Session["CourseID"] = CourseID.ToString();
                hdfCourseID.Value = Session["CourseID"].ToString().Trim();
                hdfUserTraing.Value = Session["Username"].ToString().Trim();
                //CreateResultTraining(CourseID);
                LoadStatus_Result(Session["CourseID"].ToString(), Session["UserName"].ToString());
                BindLesson(CourseID);
                BindCouse_Detail(hdfCourseID.Value.ToString(), Session["UserName"].ToString());
                BindCouse_user(hdfUserTraing.Value.ToString(),CourseID);
                LoadComment(CourseID);
            }

            if ((Session["UserName"].ToString().Trim() != null) || (Session["CourseID"].ToString().Trim() != null))
            {
               
                LoadStatus_Result(Session["CourseID"].ToString(), Session["UserName"].ToString());
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        public void LoadCourse(string CourseID)
        {
            dtDetailCourse = DBConnect.FillStore("SP_Training_DetailCourse", CommandType.StoredProcedure, CourseID);
        }
        public void LoadComment(string CourseID)
        {
            DataTable dt = new DataTable();
            dt = DBConnect.FillStore("S_CommentCourse", CommandType.StoredProcedure, CourseID);
            rptComment.DataSource = dt;
            rptComment.DataBind();

            DataTable dt1 = new DataTable();
            dt1 = DBConnect.FillStore("S_CommentCourse_Total", CommandType.StoredProcedure, CourseID);
            lblTotalComment.Text = dt1.Rows[0]["TotalCommand"].ToString();

        }
        public void BindLesson(string CourseID) 
        {
            //1. Insert các khóa học theo user.
            //CreateResultTraining(CourseID);
            // 2.Liệt kê các bài học của khóa.            
            prtDetailLeasson.DataSource = DBConnect.FillStore("SP_Traning_HistoryTraining", CommandType.StoredProcedure, CourseID, hdfUserTraing.Value.ToString());
            prtDetailLeasson.DataBind();

            //3.Liệt kê thông tin lịch sử khóa học
            dtUserLesson = DBConnect.FillStore("SP_Traning_HistoryTraining", CommandType.StoredProcedure, CourseID, hdfUserTraing.Value.ToString());
            if(dtUserLesson.Rows.Count > 0)
            {
                lblLanguage.Text = dtUserLesson.Rows[0]["Language"].ToString();
                lbllevelTraing.Text = dtUserLesson.Rows[0]["Skill_Level"].ToString();
            }
            //4.Liệt kê thông tin của kế quả
            dtResultTraing = DBConnect.FillStore("SP_Traning_ShowResult", CommandType.StoredProcedure, CourseID, hdfUserTraing.Value.ToString());
            if(dtResultTraing.Rows.Count > 0 )
            {
                lblStatusCourse.Text = dtResultTraing.Rows[0]["ResultStudy"].ToString();
            }
        }
        public void LoadStatus_Result(string CourseID_, string User)
        {
            dtResultTraing = DBConnect.FillStore("SP_Traning_ShowResult", CommandType.StoredProcedure, CourseID_, User);
        }
        public void BindCouse_Detail(string CourseID,string User)
        {
            dtCourse  = DBConnect.FillStore("SP_Training_BindCourse_New", CommandType.StoredProcedure, CourseID, User);
            lblNameCouse.Text = dtCourse.Rows[0]["NameCourse"].ToString();
            lblgioithieu.Text = dtCourse.Rows[0]["introduce"].ToString();
            lblnoidung.Text = dtCourse.Rows[0]["Decription"].ToString();
            lblFromDate.Text = dtCourse.Rows[0]["FromDate"].ToString();
            lblToDate.Text = dtCourse.Rows[0]["ToDate"].ToString();
            lblDateUpdate.Text = dtCourse.Rows[0]["ToDate"].ToString(); ;
            lblAuthor.Text = dtCourse.Rows[0]["Teacher"].ToString(); 
            lblDateUpdate.Text = dtCourse.Rows[0]["Date_Insert"].ToString();
        }
        public void BindCouse_user(string UserID,string CourseID_)
        {
            dtCourseuser = DBConnect.FillStore("SP_Training_BindCourseuser", CommandType.StoredProcedure, UserID,CourseID_);
            //lbltenkhoahoc.Text = dtCourse.Rows[0]["NameCourse"].ToString();
            //lblgioithieu.Text = dtCourse.Rows[0]["introduce"].ToString();
            //lblnoidung.Text = dtCourse.Rows[0]["Decription"].ToString();

        }


        public void BindExam(string Course)
        {
            dtExam = DBConnect.FillStore("S_TheExam_LoadQuestion_InputHistory", CommandType.StoredProcedure, Course);
            if (dtExam.Rows.Count > 0)
            {
                for (int i = 0; i < dtExam.Rows.Count; i++)
                {
                    int QuestionID = int.Parse(dtExam.Rows[i]["QuestionID"].ToString().Trim());
                    string Employee = hdfUserTraing.Value.ToString().Trim();
                    int TotalQuestion = dtExam.Rows.Count;
                    int LimitTime = int.Parse(dtExam.Rows[i]["TimeExam_Max"].ToString().Trim());
                    int status = DBConnect.ExecuteStore("S_TheExam_InsertExam", CommandType.StoredProcedure, Employee.TrimEnd(), Course, QuestionID, LimitTime, Employee.TrimEnd());
                    
                }
            }

        }
        
        protected void lbtSearchLeason_Click(object sender, EventArgs e)
        {
            lblgioithieu.Text = "";
            lblnoidung.Text = "";
                RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
                LinkButton lb = item.FindControl("lbtSearchLeason") as LinkButton;
                string LessonName = lb.Text.ToString();
                 hdfLessonName.Value = LessonName.ToString().Trim();
                
                string CourseID = hdfCourseID.Value.ToString();
                object[] obj = new object[] { LessonName, CourseID };
                 dtVideo = DBConnect.FillStore("SP_Training_BindVideo", CommandType.StoredProcedure, obj);
                HiddenField lbFlag = item.FindControl("hdfStatusLesson") as HiddenField;
               lblgioithieu.Text = dtVideo.Rows[0]["Detail_Leason"].ToString();
               lblnoidung.Text = dtVideo.Rows[0]["ContentVideo"].ToString();
              string FlagStatus = lbFlag.Value.ToString();
                if (FlagStatus == "Finish")
                {
                 lb.Attributes.Add("style", "background-color:green");
                }

        }
        [WebMethod]
        public static void UpdateStatus(string LessonName, string CourseID, string UserTraing)
        {
            try
            {
                object[] obj = new object[] {  CourseID , LessonName, UserTraing  };

                int status = DBConnect.ExecuteStore("SP_Training_UpdateVideoLesson", CommandType.StoredProcedure,obj);
              
            }
            catch (Exception)
            {
                return;
            }
        }
        protected void prtDetailLeasson_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
               // HtmlTableRow row = (HtmlTableRow)e.Item.FindControl("Tr_ID");
                DataRowView drv = e.Item.DataItem as DataRowView;
                HiddenField lbFlag = e.Item.FindControl("hdfStatusLesson") as HiddenField;
                LinkButton linkBai = e.Item.FindControl("lbtSearchLeason") as LinkButton;
                string FlagStatus = lbFlag.Value.ToString();
                if (FlagStatus == "Finish")
                {
                    linkBai.Attributes.Add("style", "background-color:green");
                }
            }
        }


        protected void lbkTest_Click(object sender, EventArgs e)
        {
            LoadStatus_Result(Session["CourseID"].ToString(), Session["UserName"].ToString());
            BindExam(Session["CourseID"].ToString());
            Response.Redirect("MiniTest.aspx?CourseID_="+ Session["CourseID"].ToString().Trim() + "&EmployeeID_="+ hdfUserTraing.Value .ToString()+ "", false);
        }

        
        protected void bttSendComment_Click(object sender, EventArgs e)
        {
            int status = DBConnect.ExecuteStore("S_CommentCourse_Insert", CommandType.StoredProcedure, Session["Username"].ToString().Trim(), hdfCourseID.Value.ToString().Trim(), txtComment.Value.Trim());
            if (status == 0)
            {
               
                LoadComment(hdfCourseID.Value.ToString());
                txtComment.Value = "";
            }
        }
    }
} 