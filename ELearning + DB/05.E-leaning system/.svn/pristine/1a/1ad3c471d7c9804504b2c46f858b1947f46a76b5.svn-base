using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using E_Learning.Connect;

namespace E_Learning
{
    public partial class ControlQuestionAnser : System.Web.UI.Page
    {
        public DataTable dtQuestion = new DataTable();
        public string Username = "";
        public OleDbConnection MyConnection { get; private set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindCourse();
                AllQuestionAnser();
                 
                if (Session["username"] == null)
                {
                    Response.Redirect("Login.aspx", true);
                }
                else
                {
                    Username = Session["UserName"].ToString();
                }
            }
        }

        public void AllQuestionAnser()
        {
            dtQuestion = DBConnect.FillStore("S_Training_QuestionAns_Master", CommandType.StoredProcedure);
        }

        protected void bttTempFile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/FileUpload/Upload_QuestionAnser.xlsx");
        }
        public void BindCourse()
        {
            DataTable dt = new DataTable();
            dt = DBConnect.FillStore("SP_Training_RegisterEmp_BindCourse", CommandType.StoredProcedure);
            if (dt.Rows.Count > 0)
            {

                DataRow dr = dt.NewRow();
                dr[1] = "-- Select Course  --";
                dt.Rows.InsertAt(dr, 0);
                ddlCourse.DataSource = dt;
                ddlCourse.DataTextField = "NameCourse";
                ddlCourse.DataValueField = "CourseID";
                ddlCourse.DataBind();

            }

        }
        protected void bttDownload_Click(object sender, EventArgs e)
        {

            dtQuestion = DBConnect.FillStore("S_Training_QuestionAns_Master", CommandType.StoredProcedure);
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Download_QuestionAnswer.xls");
            Response.Charset = "";
            Response.ContentType = "application/ms-excel";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());


            if (dtQuestion.Rows.Count > 0)
            {
                foreach (DataColumn dc in dtQuestion.Columns)
                {
                    Response.Write(dc.ToString().Replace("\n", string.Empty).Replace("\t", string.Empty).Replace("\r", string.Empty) + "\t");
                }
                Response.Write(System.Environment.NewLine);
                foreach (DataRow dr in dtQuestion.Rows)
                {
                    for (int i = 0; i < dtQuestion.Columns.Count; i++)
                    {
                        Response.Write(dr[i].ToString().Replace("\n", string.Empty).Replace("\t", string.Empty).Replace("\r", string.Empty) + "\t");
                    }
                    Response.Write("\n");
                }

            }
            Response.End();
        }
        [WebMethod]
        public static void Delete_CourseIDQuestion(string CourseID,string QuestionID,string AnserID)
        {
            try
            {
                object[] obj = new object[] { CourseID , QuestionID , AnserID };
                int status = DBConnect.ExecuteStore("S_Training_QuestionAns_Delete", CommandType.StoredProcedure, obj);

            }
            catch (Exception)
            {
                return;
            }
        }
        protected void bttUpload_Click(object sender, EventArgs e)
        {
            System.Data.DataSet DtSet;
            System.Data.OleDb.OleDbDataAdapter MyCommand;
            DataTable dt = new DataTable();
            dt = null;
            if (this.ftp_Upload.HasFile)
            {
                string strFileType = Path.GetExtension(this.ftp_Upload.FileName).ToLower();
                string path = ftp_Upload.PostedFile.FileName;
                string link_path = Server.MapPath("~/Upload_File/" + DateTime.Now.ToString("yyyyMMdd") + "_" + ftp_Upload.FileName);
                if (ftp_Upload.FileName == "Upload_QuestionAnser.xlsx" || ftp_Upload.FileName == "Upload_QuestionAnser.xls")
                {
                    ftp_Upload.SaveAs(link_path);
                    //Connection String to Excel Workbook            
                    if (strFileType.Trim() == ".xls")
                    {
                        System.Data.OleDb.OleDbConnection
                                                MyConnection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + link_path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"");
                        MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]  where CourseID is not null", MyConnection);
                        MyCommand.TableMappings.Add("Table", "TestTable");
                        DtSet = new System.Data.DataSet();
                        MyCommand.Fill(DtSet);
                        dt = DtSet.Tables[0];
                        MyConnection.Close();
                    }
                    else if (strFileType.Trim() == ".xlsx")
                    {
                        //connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                        MyConnection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + link_path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"");
                        MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$] where CourseID is not null", MyConnection);
                        MyCommand.TableMappings.Add("Table", "TestTable");
                        DtSet = new System.Data.DataSet();
                        MyCommand.Fill(DtSet);
                        dt = DtSet.Tables[0];
                        MyConnection.Close();
                    }

                    string sql_ = ""; string sql_1 = "";

                    if (dt.Rows.Count > 0)
                    {
                        DataTable dtCourse = new DataTable();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //RequestNo,PartNo,MOQ,LeadTime,CustomerCode, Deadline,Remask,Peson_Incharge,Date_Incharge,Insert_user,Update_Date
                            string CourseID = ""; string NoQuestion = ""; string ContentQuestion = null; string NoAnser = null; string TextAnser = null;
                            string AnserCorrect = null; string Decription = null;

                            if (dt.Rows[i][0].ToString() != "")
                            {
                                CourseID = dt.Rows[i][0].ToString();
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('This data CourseID  at row :(" + (i + 1).ToString() + ") is null');", true);
                                AllQuestionAnser();
                                return;
                            }
                            if (dt.Rows[i][1].ToString() != "")
                            {
                                NoQuestion = dt.Rows[i][1].ToString();
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('This data NoQuestion  at row :(" + (i + 1).ToString() + ") is null');", true);
                                AllQuestionAnser();
                                return;
                            }
                            
                            if (dt.Rows[i][2].ToString() != "")
                            {
                                ContentQuestion = dt.Rows[i][2].ToString();
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('This data ContentQuestion  at row :(" + (i + 1).ToString() + ") is null');", true);
                                AllQuestionAnser();
                                return;
                            }


                            if (dt.Rows[i][3].ToString() != "")
                            {
                                NoAnser = dt.Rows[i][3].ToString();
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('This data NoAnser at row :(" + (i + 1).ToString() + ") is null');", true);
                                AllQuestionAnser();
                                return;
                            }
                            if (dt.Rows[i][4].ToString() != "")
                            {
                                TextAnser = dt.Rows[i][4].ToString();
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('This data TextAnser at row :(" + (i + 1).ToString() + ") is null');", true);
                                AllQuestionAnser();
                                return;
                            }

                            
                                Decription = dt.Rows[i][5].ToString();
                           
                            if (dt.Rows[i][6].ToString() != "")
                            {
                                AnserCorrect = dt.Rows[i][6].ToString();
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('This data AnserCorrect at row :(" + (i + 1).ToString() + ") is null');", true);
                                AllQuestionAnser();
                                return;
                            }

                            DataTable dtCheck = new DataTable();
                            DataTable dtCheckDept = new DataTable();
                            DataTable dtCheckDept1 = new DataTable();

                            dtCheck = DBConnect.FillStore("[S_Training_Question_Check]", CommandType.StoredProcedure, CourseID, NoQuestion);
                            if (dtCheck.Rows[0]["TotalQuestion"].ToString() == "0") // Insert into tbl_Employee
                            {
                                    sql_ = sql_ + " INSERT INTO tbl_MasterQuestion (CourseID,QuestionID,Content, UserInsert,DateInsert) ";
                                    sql_ = sql_ + " VALUES( '" + CourseID + "','" + NoQuestion + "',N'" + ContentQuestion + "', '" +Session["Username"].ToString() + "' ,'" + DateTime.Now.ToShortDateString() + "') ";

                                if (sql_ != "")
                                {
                                    DBConnect.Execute_NonSQL(sql_);
                                }

                            }
                            
                            dtCheckDept1 = DBConnect.FillStore("S_Training_Anser_Check", CommandType.StoredProcedure, CourseID, NoQuestion, NoAnser);
                            if (int.Parse(dtCheckDept1.Rows[0]["TotalAnser"].ToString()) == 0) // Insert into tbl_Employee_Plan
                            {
                                sql_1 = sql_1 + " INSERT INTO tbl_MasterAnswer (CourseID,AnserID,QuestionID,TextAnser,AnserID_Correct,Decription ,DateInsert,UserInsert) ";
                                sql_1 = sql_1 + " VALUES( '" + CourseID + "','" + NoAnser + "','" + NoQuestion + "',N'" + TextAnser + "','" + AnserCorrect + "', N'" + Decription + "','" + DateTime.Now.ToShortDateString() + "','" + Session["Username"].ToString() + "' ) ";
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('NoAnser's Course already in class at row :(" + (i + 1).ToString() + ") ');", true);
                                AllQuestionAnser();
                                return;
                            }
                        }

                    }
                    // Insert to list employee
                   
                    if (sql_1 != "")
                    {
                        DBConnect.Execute_NonSQL(sql_1);
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Upload successful....');", true);
                        AllQuestionAnser();
                    }
                }
                // Delete file upload
                if (System.IO.File.Exists(link_path))
                {
                    System.IO.File.Delete(link_path);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning(Please check data excel file !!!');", true);
            }
        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {

            dtQuestion = DBConnect.FillStore("S_Training_QuestionAns_Search", CommandType.StoredProcedure, ddlCourse.SelectedValue.ToString());
        }
    }
}