using E_Learning.Connect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Learning
{
    public partial class CreateExam : System.Web.UI.Page
    {
        public DataTable dtListQAns = new DataTable();
        public string Username;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCourse();
                LoadExam();
                ViewAllQuestion();
                BindMasterExamID();
                //bttLuu.Visible = false;
                //bttLuu_Q.Visible = false;
                //bttLuu_A.Visible = false;
                if (Session["UserName"].ToString().Trim() != "")
                {
                    Username = Session["UserName"].ToString();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
        public void LoadExam()
        {
            dtListQAns = DBConnect.FillStore("S_BindQuesttionAns_List", CommandType.StoredProcedure);
            prt_Exam_Master.DataSource = dtListQAns;
            prt_Exam_Master.DataBind();
        }

        protected void LoadCourse()
        {
            ddlCourse.DataSource = DBConnect.FillStore("SP_Training_ControlCourse_Load", CommandType.StoredProcedure);
            ddlCourse.DataValueField = "CourseID";
            ddlCourse.DataTextField = "NameCourse";
            ddlCourse.DataBind();
            ddlCourse.Items.Insert(0, new ListItem("-- Choose Course --", ""));
        }
        protected void LoadQuestion(string ExamID)
        {
            ddlQuestion.DataSource = DBConnect.DataTable_Sql("SELECT * FROM tblQuestion where ExamID =" + ExamID);
            ddlQuestion.DataValueField = "QuestionID";
            ddlQuestion.DataTextField = "Name";
            ddlQuestion.DataBind();
            ddlQuestion.Items.Insert(0, new ListItem("-- Choose Question --", ""));
        }
        protected void LoadQuestion_Update()
        {
            ddlQuestion.DataSource = DBConnect.DataTable_Sql("SELECT * FROM tblQuestion where ExamID =" + hdfExamID_View.Value);
            ddlQuestion.DataValueField = "QuestionID";
            ddlQuestion.DataTextField = "Name";
            ddlQuestion.DataBind();
            ddlQuestion.Items.Insert(0, new ListItem("-- Choose Question --", ""));
        }
        protected void LoadQuestion_UpdateAns()
        {
            ddlQuestion.DataSource = DBConnect.DataTable_Sql("SELECT * FROM tblQuestion");
            ddlQuestion.DataValueField = "QuestionID";
            ddlQuestion.DataTextField = "Name";
            ddlQuestion.DataBind();
            ddlQuestion.Items.Insert(0, new ListItem("-- Choose Question --", ""));
        }

        protected void ViewQuestion(string ExamID)
        {
            if (ExamID != "")
            {
                rptQuestion.DataSource = DBConnect.DataTable_Sql("SELECT ROW_NUMBER() OVER(ORDER BY name ASC) AS Row,* FROM tblQuestion where ExamID =" + ExamID);
                rptQuestion.DataBind();
            }
        }

        public void BindMasterExamID()
        {
            ddlMasterExamID.DataSource = DBConnect.DataTable_Sql("SELECT * FROM tblExam order by ExamID asc ");
            ddlMasterExamID.DataValueField = "ExamID";
            ddlMasterExamID.DataTextField = "ExamID";
            ddlMasterExamID.DataBind();
            ddlMasterExamID.Items.Insert(0, new ListItem("-- Choose ExamID --", ""));

        }

        protected void ViewQuestion_Update()
        {
            if (hdfExamID_View.Value != "")
            {
                rptQuestion.DataSource = DBConnect.DataTable_Sql("SELECT ROW_NUMBER() OVER(ORDER BY name ASC) AS Row,* FROM tblQuestion where ExamID =" + hdfExamID_View.Value);
                rptQuestion.DataBind();
            }
        }

        protected void ViewAns_Update()
        {
            rptQuestion.DataSource = DBConnect.DataTable_Sql("SELECT ROW_NUMBER() OVER(ORDER BY name ASC) AS Row,* FROM tblQuestion where ExamID =" + hdfExamID_View.Value);
            rptQuestion.DataBind();
        }



        protected void ViewAllQuestion()
        {
            rptQuestion.DataSource = DBConnect.DataTable_Sql("SELECT ROW_NUMBER() OVER(ORDER BY name ASC) AS Row,* FROM tblQuestion ");
            rptQuestion.DataBind();
        }
        protected void btnSaveE_Click(object sender, EventArgs e)
        {
            try
            {
                //1 Kiêm tra bài test của khóa học đã tồn tại chưa
                DataTable dt_Exits = DBConnect.DataTable_Sql("select  count(*) as Total from  tblExam   where CourseID =" + ddlCourse.SelectedValue.ToString());

                if (int.Parse(dt_Exits.Rows[0]["Total"].ToString()) == 0)
                {
                    int Tongdiem = int.Parse(txtPoint.Text.ToString());
                    int DiemPass = int.Parse(txtPointPass.Text.ToString());
                    if (DiemPass > Tongdiem)
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Điểm pass không được lớn hơn tổng điểm.');", true);
                    }
                    else
                    {

                        DataTable dt = DBConnect.FillStore("Exam_Add", CommandType.StoredProcedure, Convert.ToInt32(ddlCourse.SelectedValue), Convert.ToInt32(txtTime.Text), Convert.ToInt32(txtPoint.Text), Convert.ToInt32(txtPointPass.Text));
                        if (dt.Rows[0]["sp"].ToString() == "1")
                        {
                            hdfExamID.Value = dt.Rows[0]["id"].ToString();
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Thêm bài kiểm tra thành công.');", true);
                            //questionanswer.Visible = true;
                            //btnAddE.Visible = false;
                            LoadExam();
                        }
                    }

                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Khóa học đã tạo bài kiểm tra.');", true);
                    LoadSeach(ddlCourse.SelectedValue.ToString());
                }

            }
            catch (Exception ex)
            {

                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Liên hệ IT để hỗ trợ!');", true);
            }
        }

        public void LoadSeach(string CourseID)
        {
            dtListQAns = DBConnect.FillStore("[S_BindQuesttionAns_List_Search]", CommandType.StoredProcedure, CourseID);
        }
        protected void btnSaveQ_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtTotalScore = DBConnect.FillStore("S_Question_CheckMasterQuestion", CommandType.StoredProcedure, ddlMasterExamID.SelectedValue.ToString());
                int TotalScore = int.Parse(dtTotalScore.Rows[0]["PointLadder"].ToString());
                DataTable dtTotalActal = DBConnect.FillStore("S_Question_CheckTotalScoreAnser", CommandType.StoredProcedure, ddlMasterExamID.SelectedValue.ToString());
                int TotalActual;
                TotalActual = int.Parse(dtTotalActal.Rows[0]["SumScore"].ToString());
                if (TotalActual > TotalScore)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Tổng điểm vượt quá điểm quy chuẩn của bài thi .');", true);
                }
                else
                {

                    DataTable dt = DBConnect.FillStore("Question_Add", CommandType.StoredProcedure, txtQuestion.Text, Convert.ToInt32(ddlMasterExamID.SelectedValue.ToString()), Convert.ToInt32(txtPointQuestion.Text), Convert.ToInt32(txtSort.Text));
                    if (dt.Rows[0]["sp"].ToString() == "1")
                    {
                        hdfQuestionID.Value = dt.Rows[0]["id"].ToString();
                        LoadQuestion(ddlMasterExamID.SelectedValue.ToString());
                        ViewQuestion(ddlMasterExamID.SelectedValue.ToString());
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Thêm câu hỏi thành công.');", true);
                        //btnSave_A.Visible = true;
                        //bttLuu_A.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {

                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Thêm câu hỏi bị lỗi.');", true);
            }

        }
        protected void btnSaveA_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = DBConnect.FillStore("Answer_Add", CommandType.StoredProcedure, Convert.ToInt32(ddlQuestion.SelectedValue), txtAnswer.Text, Convert.ToInt32(ckcorrect.Checked ? 1 : 0));
                if (dt.Rows[0]["sp"].ToString() == "1")
                {
                    ViewQuestion(ddlMasterExamID.SelectedValue.ToString());
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Thêm câu trả lời thành công.');", true);
                }
            }
            catch (Exception ex)
            {

                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Thêm câu trả lời bị lỗi.');", true);
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
        protected void prt_Exam_Master_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "cmd")
            {
                string ExamID = e.CommandArgument.ToString();
                rptQuestion.DataSource = DBConnect.DataTable_Sql("SELECT ROW_NUMBER() OVER(ORDER BY name ASC) AS Row,* FROM tblQuestion where ExamID =" + e.CommandArgument);
                rptQuestion.DataBind();

                ddlMasterExamID.SelectedValue = ExamID;
                LoadQuestion(ExamID);
            }

            if (e.CommandName == "Update")
            {
                //bttLuu.Visible = true;
                //btnAddE.Visible = false;
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Repeater rptPage = e.Item.FindControl("prt_Exam_Master") as Repeater;

                    HiddenField hdfID = e.Item.FindControl("hdfCourseID") as HiddenField;
                    // ddlCourse.SelectedValue = Couseid.Text.ToString();
                    //Label lblNameCourse = e.Item.FindControl("lblNameCourse") as Label;
                    // txtNameExam.Text = 
                    ddlCourse.SelectedValue = hdfID.Value;
                    Label Time = e.Item.FindControl("lblTime") as Label;
                    txtTime.Text = Time.Text.ToString();
                    Label PointLadder = e.Item.FindControl("lblPointLadder") as Label;
                    txtPoint.Text = PointLadder.Text.ToString();
                    Label PointPass = e.Item.FindControl("lblPointPass") as Label;
                    txtPointPass.Text = PointPass.Text.ToString();
                }
            }

        }

        protected void bttLuu_Click(object sender, EventArgs e)
        {
            try
            {
                //1 Kiêm tra bài test của khóa học đã tồn tại chưa
                DataTable dt_Exits = DBConnect.DataTable_Sql("select  count(*) as Total from  tblExam   where CourseID =" + ddlCourse.SelectedValue.ToString());

                if (int.Parse(dt_Exits.Rows[0]["Total"].ToString()) > 0)
                {
                    int Tongdiem = int.Parse(txtPoint.Text.ToString());
                    int DiemPass = int.Parse(txtPointPass.Text.ToString());
                    if (DiemPass > Tongdiem)
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Điểm pass không được lớn hơn tổng điểm.');", true);
                    }
                    else
                    {


                        DataTable dt = DBConnect.FillStore("Exam_Update", CommandType.StoredProcedure, Convert.ToInt32(ddlCourse.SelectedValue), Convert.ToInt32(txtTime.Text), Convert.ToInt32(txtPoint.Text), Convert.ToInt32(txtPointPass.Text));
                        if (dt.Rows[0]["sp"].ToString() == "1")
                        {
                            hdfExamID.Value = dt.Rows[0]["id"].ToString();
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Lưu bài kiểm tra thành công.');", true);
                            questionanswer.Visible = true;
                            //btnAddE.Visible = true;
                            //bttLuu.Visible = true;
                            LoadExam();
                            txtPoint.Text = "";
                            txtPointPass.Text = "";
                            txtTime.Text = "";

                        }
                    }


                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Không tồn tại khóa học này.');", true);
                    LoadSeach(ddlCourse.SelectedValue.ToString());
                }

            }
            catch (Exception ex)
            {

                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Liên hệ IT để hỗ trợ!');", true);
            }

        }
        protected void bttLuu_Q_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPointQuestion.Text == "")
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Điền điểm cho câu hỏi.');", true);

                }
                else if (txtQuestion.Text.ToString() == "")
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Điền thông tin câu hỏi.');", true);
                }
                else if (txtSort.Text.ToString() == "")
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Điền thứ tự câu hỏi.');", true);
                }
                else
                {

                    DataTable dtTotalScore = DBConnect.FillStore("S_Question_CheckMasterQuestion", CommandType.StoredProcedure, hdfExamID_View.Value.ToString());
                    int TotalScore = int.Parse(dtTotalScore.Rows[0]["PointLadder"].ToString());
                    DataTable dtTotalActal = DBConnect.FillStore("S_Question_CheckTotalScoreAnser", CommandType.StoredProcedure, hdfExamID_View.Value.ToString());
                    int TotalActual = int.Parse(dtTotalActal.Rows[0]["SumScore"].ToString());
                    if (TotalActual > TotalScore)
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Tổng điểm vượt quá điểm quy chuẩn của bài thi .');", true);
                    }
                    else
                    {
                        DataTable dt = DBConnect.FillStore("Question_Update", CommandType.StoredProcedure, txtQuestion.Text, Convert.ToInt32(txtPointQuestion.Text), Convert.ToInt32(txtSort.Text), Convert.ToInt32(hdfQuestion_View.Value));
                        if (dt.Rows[0]["sp"].ToString() == "1")
                        {
                            hdfQuestionID.Value = dt.Rows[0]["id"].ToString();
                            LoadQuestion_Update();
                            ViewQuestion_Update();
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Cập nhật câu hỏi thành công.');", true);
                            txtQuestion.Text = "";
                            txtPointQuestion.Text = "";
                            txtSort.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Cập thành câu hỏi bị lỗi.');", true);
            }

        }
        protected void bttLuu_A_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAnswer.Text == "")
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Điền thông tin câu trả lời.');", true);
                }
                else if (ddlQuestion.SelectedItem.ToString() == "-- Choose Question --")
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Hãy chọn thông tin câu hỏi.');", true);
                }
                else
                {
                    DataTable dt = DBConnect.FillStore("AnS_Update", CommandType.StoredProcedure, txtAnswer.Text, Convert.ToInt32(ckcorrect.Checked ? 1 : 0), hdfAnsID_Update_View.Value.ToString(), hdfQuestion_Ans_View.Value.ToString());
                    if (dt.Rows[0]["sp"].ToString() == "1")
                    {
                        ViewQuestion(ddlMasterExamID.SelectedValue.ToString());
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Cập nhật câu trả lời thành công.');", true);


                    }
                }
            }
            catch (Exception ex)
            {

                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Cập nhật câu trả lời bị lỗi.');", true);
            }

        }
        protected void rptQuestion_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            DataTable dtLoadQuestion = new DataTable();
            
            if (e.CommandName == "Update_Q")
            {
                //btnAddE.Visible = false;
                //bttLuu_Q.Visible = true;
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField QuestionID = e.Item.FindControl("hdfQuestionID_Update") as HiddenField;
                    Label ContentQ = e.Item.FindControl("lblContent") as Label;
                    Label ScoreQ = e.Item.FindControl("lblScore") as Label;
                    Label STT = e.Item.FindControl("Label1") as Label;
                    HiddenField ExamID = e.Item.FindControl("hdfExamID_Update") as HiddenField;
                    txtPointQuestion.Text = ScoreQ.Text.ToString();
                    txtQuestion.Text = ContentQ.Text.ToString();
                    txtSort.Text = STT.Text.ToString();
                    // Load QuestionList 
                    dtLoadQuestion = DBConnect.FillStore("S_LoadExamID_BaseQuestionID", CommandType.StoredProcedure, QuestionID.Value.ToString());
                    if(ExamID.Value != "")
                    {
                        hdfExamID_View.Value = ExamID.Value.ToString();
                    }
                    else
                    {

                        hdfExamID_View.Value = dtLoadQuestion.Rows[0]["ExamID"].ToString();
                    }
                    //hdfExamID_View.Value = ExamID.Value.ToString();
                    ddlMasterExamID.SelectedValue = ExamID.Value.ToString();
                    hdfQuestion_View.Value = QuestionID.Value.ToString();
                }

            }
            if (e.CommandName == "Delete_Q")
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    try
                    {
                        HiddenField QuestionID = e.Item.FindControl("hdfQuestionID_Update") as HiddenField;
                        HiddenField ExamID = e.Item.FindControl("hdfExamID_Update") as HiddenField;
                        hdfQuestion_View.Value = QuestionID.Value.ToString();
                        dtLoadQuestion = DBConnect.FillStore("S_LoadExamID_BaseQuestionID", CommandType.StoredProcedure, QuestionID.Value.ToString());
                        if (ExamID.Value != "")
                        {
                            hdfExamID_View.Value = ExamID.Value.ToString();
                        }
                        else
                        {

                            hdfExamID_View.Value = dtLoadQuestion.Rows[0]["ExamID"].ToString();
                        }

                        //hdfExamID_View.Value = ExamID.Value.ToString();
                        ddlMasterExamID.SelectedValue = ExamID.Value.ToString();
                        DataTable dt = DBConnect.FillStore("Question_Delete", CommandType.StoredProcedure, Convert.ToInt32(hdfExamID_View.Value), Convert.ToInt32(hdfQuestion_View.Value));
                        if (dt.Rows[0]["sp"].ToString() == "1")
                        {
                            LoadQuestion_Update();
                            ViewQuestion_Update();
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Xóa câu hỏi thành công.');", true);
                        }
                    }
                    catch
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Xóa câu hỏi bị lỗi.');", true);
                    }

                }

            }

        }
        protected void rptPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
           // btnSave_A.Visible = false;
            DataTable dtLoadQuestion = new DataTable();
            if (e.CommandName == "Update_Ans")
            {
                LoadQuestion_UpdateAns();
                //btnAddE.Visible = false;
                //bttLuu_Q.Visible = false;
                //bttLuu_A.Visible = true;
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField CheckAns = e.Item.FindControl("hdfCheckAns") as HiddenField;
                    HiddenField QuestionID = e.Item.FindControl("hdfQuestionID_AnsUpdate") as HiddenField;
                    HiddenField AnserID = e.Item.FindControl("hdfAnserID_Update") as HiddenField;
                    //HiddenField ExamID = e.Item.FindControl("hdfExamID_UpdateAns") as HiddenField;
                    Label name = e.Item.FindControl("lblContenAns") as Label;
                    txtAnswer.Text = name.Text;
                    ddlQuestion.SelectedValue = QuestionID.Value.ToString();
                    hdfAnsID_Update_View.Value = AnserID.Value.ToString();

                    hdfQuestion_Ans_View.Value = QuestionID.Value.ToString();

                    dtLoadQuestion = DBConnect.FillStore("S_LoadExamID_BaseAnseID", CommandType.StoredProcedure, AnserID.Value.ToString());
                    if (dtLoadQuestion.Rows.Count> 0)
                    {
                        hdfExamID_View.Value = dtLoadQuestion.Rows[0]["ExamID"].ToString();
                        ddlQuestion.SelectedValue = dtLoadQuestion.Rows[0]["QuestionID"].ToString();
                    }
                    if (int.Parse(CheckAns.Value) == 1)
                    {
                        ckcorrect.Checked = true;
                    }
                    else
                    {
                        ckcorrect.Checked = false;
                    }
                }

            }
            if (e.CommandName == "Delete_Ans")
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    try
                    {

                        HiddenField QuestionID = e.Item.FindControl("hdfQuestionID_AnsUpdate") as HiddenField;
                        HiddenField AnserID = e.Item.FindControl("hdfAnserID_Update") as HiddenField;

                        hdfAnsID_Update_View.Value = AnserID.Value.ToString();
                        hdfQuestion_Ans_View.Value = QuestionID.Value.ToString();
                        DataTable dt = DBConnect.FillStore("[AnS_Delete]", CommandType.StoredProcedure, Convert.ToInt32(hdfAnsID_Update_View.Value), Convert.ToInt32(hdfQuestion_Ans_View.Value));
                        if (dt.Rows[0]["sp"].ToString() == "1")
                        {
                            LoadQuestion_Update();
                            ViewQuestion_Update();
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Xóa câu trả lời thành công.');", true);
                        }
                    }
                    catch
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Xóa câu trả lời bị lỗi.');", true);
                    }
                }

            }
        }
        protected void rptPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                // ViewQuestion_Update(); //hdfExamID_View

                //  ViewAllQuestion();
            }
        }
        protected void ddlMasterExamID_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadQuestion(ddlMasterExamID.SelectedValue.ToString());
        }
    }
}