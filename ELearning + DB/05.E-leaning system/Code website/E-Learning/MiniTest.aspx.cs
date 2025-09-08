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
    public partial class MiniTest : System.Web.UI.Page
    {
        public DataTable dtQuestion = new DataTable();
        public DataTable dtQuestionStatus = new DataTable();

        public DataTable dtgetnamecourse = new DataTable();

        public string Username;
        public string CourseID;
        int CheckBoxIndex;
        int totalQuestion = 0;
        int Point = 0;
        int PointPass = 0;
        int TotalQuestionInExam = 0;
        public DataTable dt_suggest = new DataTable();
        public string Username_ = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Username = Request.QueryString["EmployeeID_"].ToString();
                Session["User"] = Username;
                if (Session["UserName"].ToString().Trim() == "" || Session["User"].ToString().Trim() =="")
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Username_ = Session["UserName"].ToString();

                }
                CourseID = Request.QueryString["CourseID_"].ToString();
                dtgetnamecourse = DBConnect.FillStore("S_getnamecourse", CommandType.StoredProcedure, CourseID);
                namecourseid.Text = dtgetnamecourse.Rows[0][0].ToString();

                Session["Course"] = CourseID;

                // BindAns(CourseID);
                ViewQuestion(CourseID);
                //BindLesson(CourseID);
                CheckStatuButton();
                
                // Init();
            }
            Init();
        }
        protected void Init()
        {
            DataTable dt = DBConnect.DataTable_Sql("SELECT * FROM tblExam where CourseID=" + Session["Course"]);
            if (dt.Rows.Count > 0)
            {
                PointPass = Convert.ToInt32(dt.Rows[0]["PointPass"].ToString());
                DataTable dt1 = DBConnect.DataTable_Sql("SELECT COUNT(*) as SL FROM tblQuestion where ExamID=" + dt.Rows[0]["ExamID"].ToString());
                if (dt1.Rows.Count > 0)
                {
                    TotalQuestionInExam = Convert.ToInt32(dt1.Rows[0]["SL"].ToString());
                }
            }

        }
        public void BindQuestion(string CourseID)
        {
            //  dtQuestion = DBConnect.FillStore("S_TheExam_BindQuestion", CommandType.StoredProcedure, CourseID);
        }

        public void BindAns(string CourseID)
        {
            // dtQuestion = DBConnect.FillStore("S_TheExam_BindAnswer", CommandType.StoredProcedure, CourseID);
            //listQuestAnser.DataSource = DBConnect.FillStore("S_TheExam_BindAnswer", CommandType.StoredProcedure, CourseID);
            //listQuestAnser.DataBind();
        }

        public void BindLesson(string CourseID)
        {

            //dtListQuestion.DataSource = DBConnect.FillStore("S_TheExam_BindQuestion", CommandType.StoredProcedure, CourseID);
            //dtListQuestion.DataBind();
        }

        protected void dpQuestAnser_PreRender(object sender, EventArgs e)
        {

            BindAns(CourseID);

        }


        public void CheckStatuButton()
        {
            DataTable dtStatus = new DataTable();
            dtStatus = DBConnect.FillStore("S_TheExam_ShowResult", CommandType.StoredProcedure, Session["Course"].ToString(), Session["User"].ToString());
            string Result = dtStatus.Rows[0]["ResultTest"].ToString();
            if (Result == "FAIL")
            {
                bttSubmit.Visible = true;
            }
            if (Result == "PASS")
            {

                bttSubmit.Visible = false;
            }

        }
        protected void bttSubmit1_Click(object sender, EventArgs e)
        {

            bttSubmit_Click(null, null);
        }
        protected void bttSubmit_Click(object sender, EventArgs e)
        {
            string resulthistory = string.Empty;
            foreach (RepeaterItem item in rptQuestion.Items)
            {

                string gettotal = "";
                int result = 0;
                Literal lblQuestionID = item.FindControl("lblQuestionID") as Literal;
                DataTable dt = DBConnect.FillStore("CheckAnswer", CommandType.StoredProcedure, Convert.ToInt32(lblQuestionID.Text));
                gettotal = dt.Rows[0]["total"].ToString();
                resulthistory += "QuestionID "+lblQuestionID.Text + ":";
                Repeater rptPage = item.FindControl("rptPage") as Repeater;
                foreach (RepeaterItem itemRole in rptPage.Items)
                {
                    Literal AnswerID = itemRole.FindControl("lblAnserID") as Literal;
                    CheckBox ckAnswer = itemRole.FindControl("ck_AnserID") as CheckBox;
                    if (ckAnswer.Checked)
                    {
                        resulthistory += AnswerID.Text + ",";
                        result += Convert.ToInt32(AnswerID.Text);
                        // roleID += lblPageFunction_ID.Text + ",";
                    }
                }
                resulthistory += ";";
                if (Convert.ToInt32(gettotal) == result)
                {
                    totalQuestion++;
                    Point += Convert.ToInt32(dt.Rows[0]["Point"].ToString());
                }
            }
            if (PointPass > Point)
            {
                if (DBConnect.FillStore("HistoryResult_Add", CommandType.StoredProcedure, Session["User"], Session["Course"], Session["Course"], resulthistory, "NG", Point).Rows.Count > 0)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "openM('Bạn đúng " + totalQuestion + " / " + TotalQuestionInExam + " câu </br> Bạn được " + Point + " điểm','error','" + Session["Course"] + "')", true);
                }

            }
            else
            {
                if (DBConnect.FillStore("HistoryResult_Add", CommandType.StoredProcedure, Session["User"], Session["Course"], Session["Course"], resulthistory, "PASS", Point).Rows.Count > 0)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "openM('Bạn đúng " + totalQuestion + " / " + TotalQuestionInExam + " câu </br> Bạn được " + Point + " điểm','success','" + Session["Course"] + "')", true);
                }
            }


            //string listAnser = ""; string Employee = ""; string QuestID_ = "";string AnserCorrect = "";
            //Session["Old_QuestionID"] = "1";
            //DataTable dtCorrect = new DataTable();
            //DataTable dtStatus = new DataTable();

            //foreach (ListViewDataItem item in listQuestAnser.Items)
            //{
            //    if (item.ItemType == ListViewItemType.DataItem)
            //    {
            //        var AnserID = item.FindControl("ck_AnserID") as System.Web.UI.HtmlControls.HtmlInputCheckBox;
            //        Label QuestionID = (Label)item.FindControl("lblQuestionID");
            //        QuestID_ = QuestionID.Text.ToString().Trim();
            //        dtCorrect = DBConnect.FillStore("S_TheExam_LoadAnserCorrect", CommandType.StoredProcedure, Session["Course"].ToString(), QuestID_);
            //        AnserCorrect = dtCorrect.Rows[0]["AnserID_Correct"].ToString();
            //        if (AnserID != null && AnserID.Checked)
            //        {
            //             string AnsID_ = AnserID.Value.Trim();

            //            if (QuestID_ != Session["Old_QuestionID"].ToString())
            //            {
            //                listAnser = "";
            //                listAnser += AnsID_ + ",";
            //            }
            //            else
            //            {
            //                listAnser += AnsID_ + ",";
            //            }
            //             QuestID_ = QuestionID.Text.ToString().Trim();
            //             Employee = Session["User"].ToString();
            //             Session["Old_QuestionID"] = QuestID_;

            //            if (QuestID_!= "" && Employee !="")
            //            {
            //                int CheckExam = DBConnect.ExecuteStore("S_TheExan_UpdateAns", CommandType.StoredProcedure, Employee, Session["Course"].ToString(), QuestID_, listAnser.Substring(0, listAnser.Length - 1), AnserCorrect);
            //            }


            //        }




            //    }
            //}
            ////2. Check the exam PASS OR FAIl
            //int status = DBConnect.ExecuteStore("S_TheExam_CheckTheExam", CommandType.StoredProcedure, Employee, Session["Course"].ToString());

            ////3. Check the status enable
            //dtStatus = DBConnect.FillStore("S_TheExam_ShowResult", CommandType.StoredProcedure, Session["Course"].ToString(), Session["User"].ToString());
            //string Result = dtStatus.Rows[0]["ResultTest"].ToString();
            //if (Result == "FAIL")
            //{
            //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('You have FAILED the Exam.');", true);
            //    //show goi y
            //    dt_suggest = DBConnect.FillStore("S_suggest_ansewer", CommandType.StoredProcedure, Session["Course"].ToString(), Session["User"].ToString());
            //    thongbao.Text = "You have to try again!";
            //}
            //if (Result == "PASS")
            //{
            //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('You have PASSED the Exam.');", true);
            //    bttSubmit.Visible = false;
            //    thongbao.Text = "You pass the exam!";
            //}
        }



        protected void listQuestAnser_PagePropertiesChanged(object sender, EventArgs e)
        {



        }
        protected void ViewQuestion(string courseID)
        {
            if (courseID != "")
            {
                DataTable dt = DBConnect.DataTable_Sql("SELECT * FROM tblExam where CourseID=" + courseID);
                if (dt.Rows.Count > 0)
                {
                    hdftime.Value = dt.Rows[0]["Time"].ToString();
                    rptQuestion.DataSource = DBConnect.DataTable_Sql("SELECT ROW_NUMBER() OVER(ORDER BY name ASC) AS Row,* FROM tblQuestion where ExamID =" + dt.Rows[0]["ExamID"].ToString());
                    rptQuestion.DataBind();
                }
            }
        }
        protected void rptQuestion_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal lblQuestionID = e.Item.FindControl("lblQuestionID") as Literal;
                Repeater rptPage = e.Item.FindControl("rptPage") as Repeater;

                if (lblQuestionID.Text != null)
                {
                    DataTable dt = new DataTable();
                    dt = DBConnect.DataTable_Sql("SELECT * FROM tblAnswer where QuestionID=" + lblQuestionID.Text);
                    if (dt.Rows.Count > 0)
                    {
                        rptPage.DataSource = dt;
                        rptPage.DataBind();
                    }

                }
            }

        }

    }
}