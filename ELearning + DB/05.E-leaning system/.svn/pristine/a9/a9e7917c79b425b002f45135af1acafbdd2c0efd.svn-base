using ClosedXML.Excel;
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
    public partial class ControlCourse : System.Web.UI.Page
    {
        public DataTable dtLesson = new DataTable();
        public DataTable dtCourse = new DataTable();

        public string Username = "";
        protected void Page_Load(object sender, EventArgs e)
        {
          
            //CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
            //_FileBrowser.BasePath = "/ckfinder";
            //_FileBrowser.SetupCKEditor(txtNote);
            if (!IsPostBack)
            {
                All_Course();
                BindStatus();
                BindStatus_Add();
                BinDept();
                BindTypeContent();
                BindTypeContentUpdate();
                BinDeptUpdate();
                BindAllLesson();
                BindCourse_Lesstion();
                if(Session["UserName"].ToString().Trim() != "")
                {
                    Username = Session["UserName"].ToString();
                }    
                else
                {
                    Response.Redirect("Login.aspx");
                }    
                
                this.mtvMasterContent.ActiveViewIndex = 0;
                mtvLession.ActiveViewIndex = -1;
            }
        }

        public void All_Course()
        {
            dtCourse = DBConnect.FillStore("SP_Training_ControlCourse_Load", CommandType.StoredProcedure);
        }
        public void BindAllLesson()
        {
            dtLesson = DBConnect.FillStore("SP_Training_DetailLeason", CommandType.StoredProcedure);

        }
        protected void bttTempFile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/FileUpload/Upload_Course.xlsx");
        }
        protected void bttLoadData_Click(object sender, EventArgs e)
        {
            All_Course();
        }
        public void Reset_TextAdd()
        {
            this.txtLangua_Add.Text = "";
            this.txtNameCourse_Add.Text = "";
            txtNameLeason_Add.Text = "";
            txtSkikkVideo_Add.Text = "";
            txtTeacher_Add.Text = "";
            txt_TimeVideo_Add.Text = "";
            
        }
        protected void BindStatus()
        {
            DataTable dt = new DataTable();
            dt = DBConnect.DataTable_Sql("select  ID, Status  from  [dbo].[tbl_Status]");
            if (dt.Rows.Count > 0)
            {
                this.ddlStatus.Items.Clear();
                ddlStatus.DataTextField = "Status";
                ddlStatus.DataValueField = "Status";
                ddlStatus.DataSource = dt;
                ddlStatus.DataBind();
            }
        }

        protected void BindStatus_Add()
        {

            DataTable dt = new DataTable();
            dt = DBConnect.DataTable_Sql("select  ID, Status  from  [dbo].[tbl_Status]");
            if (dt.Rows.Count > 0)
            {
                this.ddlStatus_Add.Items.Clear();
                ddlStatus_Add.DataTextField = "Status";
                ddlStatus_Add.DataValueField = "Status";
                ddlStatus_Add.DataSource = dt;
                ddlStatus_Add.DataBind();
            }
        }

        protected void BindTypeContent()
        {

            DataTable dt = new DataTable();
            dt = DBConnect.FillStore("S_TypeContent", CommandType.StoredProcedure);
            if (dt.Rows.Count > 0)
            {
                this.ddlTypeContetn_Add.Items.Clear();
                ddlTypeContetn_Add.DataTextField = "NameCourse"; 
                ddlTypeContetn_Add.DataValueField = "CourseID";
                ddlTypeContetn_Add.DataSource = dt;
                ddlTypeContetn_Add.DataBind();
            }
        }

        protected void BindTypeContentUpdate()
        {

            DataTable dt = new DataTable();
            dt = DBConnect.FillStore("S_TypeContent", CommandType.StoredProcedure);
            if (dt.Rows.Count > 0)
            {
                this.ddl_TypeContent_Update.Items.Clear();
                ddl_TypeContent_Update.DataTextField = "NameCourse";
                ddl_TypeContent_Update.DataValueField = "CourseID";
                ddl_TypeContent_Update.DataSource = dt;
                ddl_TypeContent_Update.DataBind();
            }
        }
        protected void BindTypeContentAdd()
        {

            DataTable dt = new DataTable();
            dt = DBConnect.FillStore("S_TypeContent", CommandType.StoredProcedure);
            if (dt.Rows.Count > 0)
            {
                this.ddlTypeContetn_Add.Items.Clear();
                ddlTypeContetn_Add.DataTextField = "NameCourse";
                ddlTypeContetn_Add.DataValueField = "CourseID";
                ddlTypeContetn_Add.DataSource = dt;
                ddlTypeContetn_Add.DataBind();
            }
        }
        public void BinDept()
        {
            DataTable dt1 = new DataTable();
            dt1 = DBConnect.FillStore("S_BindDept", CommandType.StoredProcedure);
            if (dt1.Rows.Count > 0)
            {
                ddlDept.Items.Clear();
                ddlDept.DataTextField = "DeptID";
                ddlDept.DataValueField = "DeptID";
                ddlDept.DataSource = dt1;
                ddlDept.DataBind();
            }
        }


        public void BinDeptUpdate()
        {
            DataTable dt1 = new DataTable();
            dt1 = DBConnect.FillStore("S_BindDept", CommandType.StoredProcedure);
            if (dt1.Rows.Count > 0)
            {
                this.ddl_DeptUpdate.Items.Clear();
                ddl_DeptUpdate.DataTextField = "DeptID";
                ddl_DeptUpdate.DataValueField = "DeptID";
                ddl_DeptUpdate.DataSource = dt1;
                ddl_DeptUpdate.DataBind();
            }
        }
        protected void bttAddClick(object sender, EventArgs e)
        {

            //string userupdate = Session["UserName"].ToString();
            //string CourseID = hdfCourse.Value.ToString();
            //string CourseName = txtCoursename.Text.ToString();
            //string Images = txtImage.Text.ToString();
            //string TimeVideo = txtTimeVideo.Text.ToString().Trim();
            //string SkillLevel = txtSkillVideo.Text.ToString().Trim();
            //string Lang = txtLanguge.Text.ToString().Trim();
            //string TotalLesson = txtToatlLesson.Text.ToString().Trim();
            //string Teacher = txtTeacher.Text.ToString().Trim();
            //string DeptTraining = txtDept.Text.ToString().Trim();
            //string Status = drStatus.SelectedValue.ToString();
            //string Content_ = txtContent.Text.ToString();
            //object[] obj = new object[] { CourseID, CourseName, Images, TimeVideo, SkillLevel, Lang, TotalLesson, Teacher, DeptTraining, Status, userupdate, Content_ };
            //int status = DBConnect.ExecuteStore("SP_Training_ControlCourse_Update", CommandType.StoredProcedure, obj);
            //if (status == 0)
            //{
            //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Updated successfully');", true);
            //    All_Course();
            //}
            //else
            //{
            //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Updated failed');", true);
            //    All_Course();
            //}
        }
        protected void bttClose(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterOnSubmitStatement(typeof(Page), "closePage", "window.onunload = CloseWindow();");
        }
        protected void bttDownload_Click(object sender, EventArgs e)
        {
            dtCourse = DBConnect.FillStore("SP_Training_ControlCourse_Load", CommandType.StoredProcedure);
            Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename=Download_ListCourse.xls");
            //Response.Charset = "";
            //Response.ContentType = "application/ms-excel";
            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            context.Response.ClearHeaders();
            String sr = string.Empty;
            sr += "<html><body><table>";
            sr += "<tr style=\"background-color:gray;color:white;\">";

            if (dtCourse.Rows.Count > 0)
            {
                foreach (DataColumn dc in dtCourse.Columns)
                {
                    sr += "<th>";
                    sr +=  dc.ToString().Replace("\n", string.Empty).Replace("\t", string.Empty).Replace("\r", string.Empty) + "\t";
                    sr += "</th>";
                }
                sr += "</tr>";
                sr += Environment.NewLine;
                foreach (DataRow dr in dtCourse.Rows)
                {
                    sr += "<tr>";
                    for (int i = 0; i < dtCourse.Columns.Count; i++)
                    {
                        sr += "<td>";
                      sr+=  dr[i].ToString().Replace("\n", string.Empty).Replace("\t", string.Empty).Replace("\r", string.Empty) + "\t";
                        sr += "</td>";
                    }
                    sr += "</tr>";
                    sr += Environment.NewLine;
                }
                sr += "</table></body></html>";
                context.Response.ContentType = "application/vnd.ms-excel";
                context.Response.AddHeader("Content-Disposition", "attachment; filename=Download_ListCourse.xls");
                context.Response.Write(sr);
                context.Response.Flush();
                context.Response.End();
                context.Response.Close();

            }
            Response.End();
        }

        [WebMethod]
        public static void Delete_CourseID(string CourseID)
        {
            try
            {
                object[] obj = new object[] { CourseID };
                int status = DBConnect.ExecuteStore("SP_Training_ControlCourse_Delete", CommandType.StoredProcedure, obj);

            }
            catch (Exception)
            {
                return;
            }
        }

        protected void bttSeachClick(object sender, EventArgs e)
        {
          
          

        }

        protected void bttSave_ServerClick(object sender, EventArgs e)
        {
            //string userupdate = Session["UserName"].ToString();
            //string CourseID = hdfCourse.Value.ToString();
            //string CourseName = txtCoursename.Text.ToString();
            //string Images = txtImage.Text.ToString();
            //string TimeVideo = txtTimeVideo.Text.ToString().Trim();
            //string SkillLevel = txtSkillVideo.Text.ToString().Trim();
            //string Lang = txtLanguge.Text.ToString().Trim();
            //string TotalLesson = txtToatlLesson.Text.ToString().Trim();
            //string Teacher = txtTeacher.Text.ToString().Trim();
            //string DeptTraining = txtDept.Text.ToString().Trim();
            //string Status = drStatus.SelectedValue.ToString();
            //string Decription = txtContent.Text.ToString();

            //// string Decription = txtDecription.Text.ToString().Trim();
            //object[] obj = new object[] { CourseID, CourseName, Images, TimeVideo, SkillLevel, Lang, TotalLesson, Teacher, DeptTraining, Status, userupdate, Decription };
            //int status = DBConnect.ExecuteStore("SP_Training_ControlCourse_Update", CommandType.StoredProcedure, obj);
            //if (status == 0)
            //{
            //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Updated successfully');", true);
            //    All_Course();
            //}
            //else
            //{
            //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Updated failed');", true);
            //    All_Course();
            //}

        }

        //[WebMethod]
        //protected void bttUploadImage_Click1(object sender, EventArgs e)
        //{
        //    if (fptUploadImage.HasFile)
        //    {
        //        HttpFileCollection _HttpFileCollection = Request.Files;
        //        for (int i = 0; i < _HttpFileCollection.Count; i++)
        //        {
        //            HttpPostedFile _HttpPostedFile = _HttpFileCollection[i];
        //            string folderPath = Server.MapPath("/assets/images/resources/");
        //            if (!Directory.Exists(folderPath))
        //            {
        //                Directory.CreateDirectory(folderPath);
        //            }

        //            if (_HttpPostedFile.ContentLength > 0)

        //                _HttpPostedFile.SaveAs(folderPath + Path.GetFileName(_HttpPostedFile.FileName));
        //            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Updated Image suscesfully.');", true);
        //            All_Course();
        //        }
        //    }
        //    else
        //    {
        //        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Please select image.');", true);
        //        fptUploadImage.Focus();
        //        All_Course();
        //    }
        //}

        protected void bttAdd_Click(object sender, EventArgs e)
        {

        }

        protected void bttSave_Add_ServerClick(object sender, EventArgs e)
        {
            //1 Copy file Image
            string ImageLink = "";
            if (Upload_Image_Add.HasFile)
            {
                HttpFileCollection _HttpFileCollection = Request.Files;
                for (int i = 0; i < _HttpFileCollection.Count; i++)
                {
                    HttpPostedFile _HttpPostedFile = _HttpFileCollection[i];
                    string folderPath = Server.MapPath("/assets/images/resources/");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    if (_HttpPostedFile.ContentLength > 0)
                    {
                        _HttpPostedFile.SaveAs(folderPath + Path.GetFileName(_HttpPostedFile.FileName));
                        ImageLink = "/assets/images/resources/" + Path.GetFileName(_HttpPostedFile.FileName);
                    }
                }

                DataTable dtMax = DBConnect.DataTable_Sql("select  IsNull(max(CourseID),0) as CourseID  from [dbo].[tbl_Course_Detail] ");
                int CourseID = int.Parse(dtMax.Rows[0]["CourseID"].ToString());
                if (dtMax.Rows[0][0].ToString() == "0")
                {
                    CourseID = 1;
                }
                else
                {
                    CourseID = CourseID + 1;
                }

                string userupdate = Session["UserName"].ToString();
                string TypeContent = ddlTypeContetn_Add.SelectedValue.ToString();
                string CourseName = txtNameCourse_Add.Text.ToString();
                //string Images = txtImage_Add.Text.ToString();
                string TimeVideo = txt_TimeVideo_Add.Text.ToString().Trim();
                string SkillLevel = txtSkikkVideo_Add.Text.ToString().Trim();
                string Lang = txtLangua_Add.Text.ToString().Trim();
                string TotalLesson = txtTotalLeasson_Add.Text.ToString().Trim();
                string Teacher = txtTeacher_Add.Text.ToString().Trim();
                string DeptTraining = ddlDept.Text.ToString().Trim();
                string Status = ddlStatus_Add.SelectedValue.ToString();
                string Dcript = CK_Editor_Add.Text.ToString();
              

                // string Decription = txtDecription.Text.ToString().Trim();
                object[] obj = new object[] { TypeContent, CourseID, CourseName, ImageLink, TimeVideo, SkillLevel, Lang, TotalLesson, Teacher, DeptTraining, Status, userupdate, Dcript };

                int status = DBConnect.ExecuteStore("S_Training_ControlCourse_Add", CommandType.StoredProcedure, obj);
                if (status == 0)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Thêm mới thành công.');", true);
                    All_Course();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Thêm mới bị lỗi.');", true);
                    All_Course();
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Vui lòng lựa chọn hình ảnh khóa học.');", true);
                Upload_Image_Add.Focus();
              
            }

            // Insert database 
          

        }

        protected void bttUpdate_ServerClick(object sender, EventArgs e)
        {
            string ImageLink_Update = "";
            
            //if (this.UploadImage_Update.HasFile)
            //{
                HttpFileCollection _HttpFileCollection = Request.Files;
                for (int i = 0; i < _HttpFileCollection.Count; i++)
                {
                    HttpPostedFile _HttpPostedFile = _HttpFileCollection[i];
                    string folderPath = Server.MapPath("/assets/images/resources/");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    if (_HttpPostedFile.ContentLength > 0)
                    {
                        _HttpPostedFile.SaveAs(folderPath + Path.GetFileName(_HttpPostedFile.FileName));
                        ImageLink_Update = "/assets/images/resources/" + Path.GetFileName(_HttpPostedFile.FileName);
                    }
                }
                string userupdate = Session["UserName"].ToString();
                string CourseID = hdfCourseID_Update.Value.ToString();
                string CourseName = txtName_Update.Text.ToString();
                string Images = ImageLink_Update;
                string TimeVideo = txtTimeVideo_Update.Text.ToString().Trim();
                string SkillLevel = txtSlill_Update.Text.ToString().Trim();
                string Lang = txtLage_Update.Text.ToString().Trim();
                string TotalLesson = txtTotalLesson_Update.Text.ToString().Trim();
                string Teacher = txtTeacher_Update.Text.ToString().Trim();
                string DeptTraining = ddl_DeptUpdate.SelectedValue.ToString().Trim();
                string StatusCourse = ddlStatus.SelectedValue.ToString();
                string Content_ = CkEditor_Update.Text.ToString();
                string ContenTypeID = ddl_TypeContent_Update.SelectedValue.ToString();
                // string Decription = txtDecription.Text.ToString().Trim();

                object[] obj = new object[] { CourseID, CourseName, Images, TimeVideo, SkillLevel, Lang, TotalLesson, Teacher, DeptTraining, StatusCourse, userupdate, Content_, ContenTypeID };
                object[] objStatus = new object[] { CourseID, StatusCourse };
              if (StatusCourse =="Finish") // Cập nhật mỗi Status
                {
                    int statusStatus = DBConnect.ExecuteStore("SP_Training_ControlCourse_UpdateCourse", CommandType.StoredProcedure, objStatus);
                    if (statusStatus == 0)
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Cập nhật thành công.');", true);
                        All_Course();
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Cập nhật bị lỗi.');", true);
                        All_Course();
                    }

                }
                else // Cập nhật mỗi all Status
                {
                    int status = DBConnect.ExecuteStore("SP_Training_ControlCourse_Update", CommandType.StoredProcedure, obj);
                    if (status == 0)
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Cập nhật thành công.');", true);
                        All_Course();
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Cập nhật bị lỗi.');", true);
                        All_Course();
                    }
                }    
                
            //}
            //else
            //{
            //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Vui lòng chọn hình ảnh đại diện khóa học.');", true);
            //    UploadImage_Update.Focus();
            //    All_Course();

            //}

          




        }

        protected void linkMasterCourse_Click(object sender, EventArgs e)
        {
            mtvMasterContent.ActiveViewIndex = 0;
            mtvLession.ActiveViewIndex = -1;
            All_Course();
        }

        protected void linkVideo_Click(object sender, EventArgs e)
        {
            mtvMasterContent.ActiveViewIndex = -1;
            mtvLession.ActiveViewIndex = 0;
            BindAllLesson();
            BindTypeContentUpdate();
            BindTypeContentAdd();
        }

        [WebMethod]
        public static void DeleteLession(string CourseID, int LessonID)
        {
            try
            {
                object[] obj = new object[] { CourseID, LessonID };
                int status = DBConnect.ExecuteStore("S_Training_ControlLesson_Delete", CommandType.StoredProcedure, obj);
                
            }
            catch (Exception)
            {
                return;
            }
        }
        public void BindCourse_Lesstion()
        {
            DataTable dt1 = new DataTable();
            dt1 = DBConnect.FillStore("S_BindCourse_Master", CommandType.StoredProcedure);
            if (dt1.Rows.Count > 0)
            {
                this.ddl_TypeCourse_Lession_Add.Items.Clear();
                ddl_TypeCourse_Lession_Add.DataTextField = "NameCourse";
                ddl_TypeCourse_Lession_Add.DataValueField = "CourseID";
                ddl_TypeCourse_Lession_Add.DataSource = dt1;
                ddl_TypeCourse_Lession_Add.DataBind();
            }
        }

        protected void bttDowloadLesstion_ServerClick(object sender, EventArgs e)
        {
            dtLesson = DBConnect.FillStore("SP_Training_ControlLeason_Search", CommandType.StoredProcedure);


            if (dtLesson.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dtLesson, "Training");

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Download_ListLesson.xlsx");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }

            }
        }

      protected void bttSave_Lession_ServerClick(object sender, EventArgs e)
        {
            string LinkVideo = "";
            if (Upload_Video_Lesstion_Add.HasFile)
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
                    {
                        _HttpPostedFile.SaveAs(folderPath + Path.GetFileName(_HttpPostedFile.FileName));
                        LinkVideo = "Video/" + Path.GetFileName(_HttpPostedFile.FileName);
                    }

                }

                    string CourseID = ddl_TypeCourse_Lession_Add.SelectedValue.ToString();
                    string NameVideo = txtNameLeason_Add.Text.ToString();
                string VideoContent = CKEditor_LessonContent.Text.ToString();
                    string User = Session["UserName"].ToString();
                if (NameVideo.ToString() == "")
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Điền tên khóa học.');", true);
                    Upload_Video_Lesstion_Add.Focus();

                }
                else
                {
                     DataTable dtTotalPlant  = DBConnect.FillStore("[SP_Traing_ControlLesson_Master]", CommandType.StoredProcedure,ddl_TypeCourse_Lession_Add.SelectedValue.ToString());
                     int TotalPlantLesson = int.Parse(dtTotalPlant.Rows[0]["TotalLesson"].ToString());
                        
                     DataTable dtTotalActual = DBConnect.FillStore("[S_Training_DetailLeason_Add_CheckAlreadyInsert]", CommandType.StoredProcedure, ddl_TypeCourse_Lession_Add.SelectedValue.ToString());
                    int TotalPlantActual = int.Parse( dtTotalActual.Rows[0]["TotalInset"].ToString());
                    if (TotalPlantActual < TotalPlantLesson)
                    {


                        object[] obj = new object[] { CourseID, NameVideo, LinkVideo, User , VideoContent };
                        int status = DBConnect.ExecuteStore("S_Training_DetailLeason_Add", CommandType.StoredProcedure, obj);
                        if (status == 0)
                        {
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Thêm mới thành công.');", true);
                            BindAllLesson();
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Thêm mới bị lỗi.');", true);
                            BindAllLesson();
                        }
                        BindAllLesson();
                    }
                    if (TotalPlantActual <= TotalPlantLesson)
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Tổng số khóa học thêm video đã đủ.');", true);
                        BindAllLesson();
                    }
                }
                
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Vui lòng chọn video.');", true);
                Upload_Video_Lesstion_Add.Focus();
                BindAllLesson();
            }

        }

       

        protected void bttUpdate_Lesson_ServerClick(object sender, EventArgs e)
        {
            string LinkVideo = "";
            if (hdf_Update_Video_Update.HasFile)
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
                    {
                        _HttpPostedFile.SaveAs(folderPath + Path.GetFileName(_HttpPostedFile.FileName));
                        LinkVideo = "Video/" + Path.GetFileName(_HttpPostedFile.FileName);
                    }

                }

                string LessonID = hdfLessonUpdate_ID.Value.ToString();
                string CourseID = hdfCourseID_LessonUpdate.Value.ToString();
                string NameVideo = txtName_Lesson_Update.Text.ToString();
                string ContentUpdate = CKEditorLesson_Update.Text.ToString();
                string User = Session["UserName"].ToString();
                object[] obj = new object[] { CourseID, NameVideo, LinkVideo, User , LessonID , ContentUpdate };
                int status = DBConnect.ExecuteStore("S_Training_DetailLeason_Update", CommandType.StoredProcedure, obj);
                if (status == 0)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Cập nhật thành công.');", true);
                    BindAllLesson();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Cập nhật bị lỗi');", true);
                    BindAllLesson();
                }
                BindAllLesson();

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Chọn video cần cập nhật.');", true);
                hdf_Update_Video_Update.Focus();
                BindAllLesson();
            }
        }

        protected void bttDownloadVideo_ServerClick(object sender, EventArgs e)
        {

        }
    }
}