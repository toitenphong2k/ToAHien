using E_Learning.Connect;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace E_Learning
{
    public partial class ControlLesson : System.Web.UI.Page
    {
      public  DataTable dtLesson = new DataTable();

        public string Username = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAllLesson();
                Username = Session["UserName"].ToString();
            }
        }
        public void BindAllLesson()
        {
            dtLesson = DBConnect.FillStore("SP_Training_DetailLeason", CommandType.StoredProcedure);
            
        }

        public void BindUpload()
        {
            dtLesson = DBConnect.FillStore("[SP_Training_DetailLeason]", CommandType.StoredProcedure);
            lblTotal.Text = "Total Lesson:" + dtLesson.Rows.Count.ToString();
        }

        protected void bttSave_ServerClick(object sender, EventArgs e)
        {

            string CourseID = hdfCourse.Value.ToString();
            string LessonID = hdfLessonID.Value.ToString();
            string NameLesson = txtNameLeasonEdit.Text.ToString();
            string LinkEdit = txtLinkEdit.Text.ToString();
            string User = Session["UserName"].ToString();
            object[] obj = new object[] { CourseID, LessonID, NameLesson, LinkEdit, User };
            int status = DBConnect.ExecuteStore("SP_Training_DetailLeason_Update", CommandType.StoredProcedure, obj);
            if (status == 0)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Updated successfully');", true);
                BindAllLesson();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Updated failed');", true);
                BindAllLesson();
            }
        }

        protected void bttLoadData_Click(object sender, EventArgs e)
        {
            dtLesson = DBConnect.FillStore("SP_Training_ControlLeason_Search", CommandType.StoredProcedure);
            lblTotal.Text = "Total Lesson:" + dtLesson.Rows.Count.ToString();
        }

        protected void bttTempFile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/FileUpload/Upload_Lesson.xlsx");
        }

        protected void bttDownload_Click(object sender, EventArgs e)
        {
            dtLesson = DBConnect.FillStore("SP_Training_ControlLeason_Search", CommandType.StoredProcedure);
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Download_Lesson.xls");
            Response.Charset = "";
            Response.ContentType = "application/ms-excel";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());


            if (dtLesson.Rows.Count > 0)
            {
                foreach (DataColumn dc in dtLesson.Columns)
                {
                    Response.Write(dc.ToString().Replace("\n", string.Empty).Replace("\t", string.Empty).Replace("\r", string.Empty) + "\t");
                }
                Response.Write(System.Environment.NewLine);
                foreach (DataRow dr in dtLesson.Rows)
                {
                    for (int i = 0; i < dtLesson.Columns.Count; i++)
                    {
                        Response.Write(dr[i].ToString().Replace("\n", string.Empty).Replace("\t", string.Empty).Replace("\r", string.Empty) + "\t");
                    }
                    Response.Write("\n");
                }

            }
            Response.End();

        }

        protected void bttUpload_Click(object sender, EventArgs e)
        {
            System.Data.OleDb.OleDbConnection MyConnection;
            System.Data.DataSet DtSet;
            System.Data.OleDb.OleDbDataAdapter MyCommand;
            DataTable dt = new DataTable();
            dt = null;
            if (this.ftp_Upload.HasFile)
            {
                string strFileType = Path.GetExtension(this.ftp_Upload.FileName).ToLower();
                string path = ftp_Upload.PostedFile.FileName;
                string link_path = Server.MapPath("~/Upload_File/" + DateTime.Now.ToString("yyyyMMdd") + "_" + ftp_Upload.FileName);
                if (ftp_Upload.FileName == "Upload_Lesson.xlsx" || ftp_Upload.FileName == "Upload_Lesson.xls")
                {
                    ftp_Upload.SaveAs(link_path);
                    //Connection String to Excel Workbook            
                    if (strFileType.Trim() == ".xls")
                    {
                        //connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
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

                    string sql_ = "";

                    if (dt.Rows.Count > 0)
                    {
                        DataTable dtCourse = new DataTable();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //RequestNo,PartNo,MOQ,LeadTime,CustomerCode, Deadline,Remask,Peson_Incharge,Date_Incharge,Insert_user,Update_Date
                            string CourseID = ""; int LessonID = 1; string NameLesson = ""; string LinkVideo = ""; string NameVideo = "";


                            if (dt.Rows[i][0].ToString() != "")
                            {
                                CourseID = dt.Rows[i][0].ToString();
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('This data CourseID  at row :(" + (i + 1).ToString() + ") is null');", true);
                                BindAllLesson();
                                return;
                            }
                            if (dt.Rows[i][1].ToString() != "")
                            {
                                LessonID = int.Parse(dt.Rows[i][1].ToString());
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('This data LessonID at row :(" + (i + 1).ToString() + ") is null');", true);
                                BindAllLesson();
                                return;
                            }
                            if (dt.Rows[i][2].ToString() != "")
                            {
                                NameLesson = dt.Rows[i][2].ToString();
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('This data NameLesson at row :(" + (i + 1).ToString() + ") is null');", true);
                                BindAllLesson();
                                return;
                            }
                            if (dt.Rows[i][3].ToString() != "")
                            {
                                NameVideo = dt.Rows[i][3].ToString();
                                LinkVideo = "Video/" + NameVideo;
                            }
                            else
                            {

                                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('This data NameVideo at row :(" + (i + 1).ToString() + ") is null');", true);
                                BindAllLesson();
                                return;
                            }



                            DataTable dtCheck = new DataTable();

                            dtCheck = DBConnect.FillStore("SP_Traing_ControlLesson_CheckExists", CommandType.StoredProcedure, CourseID, LessonID);
                            if (int.Parse(dtCheck.Rows[0]["CountLesson"].ToString()) == 0)
                            {
                                sql_ = sql_ + " INSERT INTO tbl_DetailCourse (CourseID,LeasonID,Detail_Leason, LinkVideo,UserInsert) ";
                                sql_ = sql_ + " VALUES( '" + CourseID + "','" + LessonID + "','" + NameLesson + "','" + LinkVideo + "' ,'" + Session["UserName"].ToString() + "');";

                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('NG.CourseID have already upload at row :(" + (i + 1).ToString() + ") ');", true);
                                BindAllLesson();
                                return;

                            }
                        }

                    }
                    if (sql_ != "")
                    {
                        DBConnect.Execute_NonSQL(sql_);
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Upload  Video successful....');", true);

                        BindUpload();
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

        protected void bttSeachClick(object sender, EventArgs e)
        {
            string CourseID = txtCourseIDSearch.Text.ToString();
            string LessonID = txtLeasonIDSeach.Text.ToString();
            string NameLesson = txtNameLessonSearch.Text.ToString();
            string Linkseach = txtNameVideoseach.Text.ToString();

            dtLesson = DBConnect.FillStore("[SP_Training_ControlLeason_Search]", CommandType.StoredProcedure, CourseID, LessonID, NameLesson, Linkseach);
            lblTotal.Text = "Total Course:" + dtLesson.Rows.Count.ToString();

        }
        [WebMethod]
        public static void  Delete (string CourseID, int LessonID)
        {
            try
            {
                object[] obj = new object[] { CourseID, LessonID };
                int status = DBConnect.ExecuteStore("[SP_Training_ControlLesson_Delete]", CommandType.StoredProcedure, obj);

            }
            catch (Exception)
            {
                return;
            }
        }

        protected void bttUploadVideo_Click(object sender, EventArgs e)
        {
            if (fptUploadVideo.HasFile)
            {
                HttpFileCollection _HttpFileCollection = Request.Files;
                for (int i = 0; i < _HttpFileCollection.Count; i++)
                {
                    HttpPostedFile _HttpPostedFile = _HttpFileCollection[i];
                    string folderPath = Server.MapPath("Video/");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    if (_HttpPostedFile.ContentLength > 0)

                        _HttpPostedFile.SaveAs(folderPath + Path.GetFileName(_HttpPostedFile.FileName));
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Copy Video to server suscesfully.');", true);
                    BindAllLesson();
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Please select Video.');", true);
                fptUploadVideo.Focus();
                BindAllLesson();
            }
        }
    }
}