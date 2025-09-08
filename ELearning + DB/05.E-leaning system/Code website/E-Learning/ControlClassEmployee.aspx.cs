using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using E_Learning.Connect;

namespace E_Learning
{
    public partial class Register_Course_Employee : System.Web.UI.Page
    {
        public DataTable dtRegistionE = new DataTable();
        
        public string Username = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserTraining();
                BindCourse();
                BindCourse_Edit();
                BindClass_Edit();
                Username = Session["UserName"].ToString();
            }
        }

        public void LoadUserTraining()
        {
            dtRegistionE = DBConnect.FillStore("SP_Training_RegistionEmp_LoadData", CommandType.StoredProcedure);
            
        }
        public void LoadData_Upload(string CourseID, string Class , string Datetime)
        {
            dtRegistionE = DBConnect.FillStore("SP_Trainning_RegisterEmp_LoadUpload", CommandType.StoredProcedure, CourseID, Class, Datetime);
            
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
        public void BindClass(string CourseID)
        {
            DataTable dt = new DataTable();
            dt = DBConnect.FillStore("SP_Training_RegisterEmp_BindClass", CommandType.StoredProcedure, CourseID);
            if (dt.Rows.Count > 0)
            {
                ddlClass.DataSource = dt;
                ddlClass.DataTextField = "Class";
                ddlClass.DataValueField = "Class";
                ddlClass.DataBind();
            }
        }
        public void BindCourse_Edit()
        {
            DataTable dt = new DataTable();
            dt = DBConnect.FillStore("SP_Training_RegisterEmp_BindCourse", CommandType.StoredProcedure);
            if (dt.Rows.Count > 0)
            {
                ddlCourse_Edit.DataSource = dt;
                ddlCourse_Edit.DataTextField = "NameCourse";
                ddlCourse_Edit.DataValueField = "CourseID";
                ddlCourse_Edit.DataBind();

            }

        }
        
        public void BindClass_Edit()
        {
            DataTable dt = new DataTable();
            dt = DBConnect.FillStore("SP_Training_RegisterEmp_BindClassbyCourse", CommandType.StoredProcedure, ddlCourse_Edit.SelectedValue);
            if (dt.Rows.Count > 0)
            {

                ddlClass_Edit.DataSource = dt;
                ddlClass_Edit.DataTextField = "Class";
                ddlClass_Edit.DataValueField = "Class";
                ddlClass_Edit.DataBind();

            }
        }

        public void Search(string CourseID, string Class)

        {
            dtRegistionE = DBConnect.FillStore("SP_Trainning_RegisterEmp_Search", CommandType.StoredProcedure, CourseID, Class);
        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            BindClass(ddlCourse.SelectedValue.ToString());
            Search(ddlCourse.SelectedValue.ToString(), ddlClass.SelectedValue.ToString());
            lblCourseID.Text = ddlCourse.SelectedValue.ToString();
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search(ddlCourse.SelectedValue.ToString(), ddlClass.SelectedValue.ToString());
        }

        [WebMethod]
        public static void Delete_CourseID(string CourseID,string Class, string User)
        {
            try
            {
                object[] obj = new object[] { CourseID, Class, User };
                int status = DBConnect.ExecuteStore("SP_Training_RegisterEmp_Delete", CommandType.StoredProcedure, obj);

            }
            catch (Exception)
            {
                return;
            }
        }
        public void CreateResult_HistoryLesstion(string CourseID, string EmployeeID, string Class)// Insert bài học theo từng người vào học
        {
            DataTable dtDetailCourse = new DataTable();
            dtDetailCourse = DBConnect.FillStore("SP_Training_DetailCourse", CommandType.StoredProcedure, CourseID);
            if (dtDetailCourse.Rows.Count > 0)
            {
                for (int i = 0; i < dtDetailCourse.Rows.Count; i++)
                {
                    string Lesson = dtDetailCourse.Rows[i]["Detail_Leason"].ToString();
                    int status = DBConnect.ExecuteStore("SP_Training_InsertCourseForUser", CommandType.StoredProcedure, EmployeeID, CourseID, Lesson, Class);
                }
            }
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
                //if (ftp_Upload.FileName == "Upload_UserForClass.xlsx" || ftp_Upload.FileName == "Upload_UserForClass.xls")
                //{
                ftp_Upload.SaveAs(link_path);
                //Connection String to Excel Workbook            
                if (strFileType.Trim() == ".xls")
                {
                    //connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                    MyConnection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + link_path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"");
                    MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
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
                    MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
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
                        string EmployeeID = ""; string FullName = ""; string Dept = null; string Course; string Class; string Email;



                        if (dt.Rows[i][0].ToString() != "")
                        {
                            EmployeeID = dt.Rows[i][0].ToString();
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Thông tin nhân viên không được bỏ trống :(" + (i + 1).ToString() + ") is null');", true);
                            LoadUserTraining();
                            return;
                        }
                        if (dt.Rows[i][1].ToString() != "")
                        {
                            FullName = dt.Rows[i][1].ToString();
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Thông tin tên nhân viên không được bỏ trống:(" + (i + 1).ToString() + ") is null');", true);
                            LoadUserTraining();
                            return;
                        }
                        if (dt.Rows[i][2].ToString() != "")
                        {
                            Dept = dt.Rows[i][2].ToString();
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Thông tin phòng ban không được bỏ trống :(" + (i + 1).ToString() + ") is null');", true);
                            LoadUserTraining();
                            return;
                        }

                        if (dt.Rows[i][3].ToString() != "")
                        {
                            Course = dt.Rows[i][3].ToString();
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Thông tin khóa học không được bỏ trống :(" + (i + 1).ToString() + ") is null');", true);
                            LoadUserTraining();
                            return;
                        }
                        if (dt.Rows[i][4].ToString() != "")
                        {
                            Class = dt.Rows[i][4].ToString();
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Thông tin lớp Học không được bỏ trống :(" + (i + 1).ToString() + ") is null');", true);
                            LoadUserTraining();
                            return;
                        }
                        if (dt.Rows[i][5].ToString() != "")
                        {
                            Email = dt.Rows[i][5].ToString();
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Thông tin Email không được bỏ trống :(" + (i + 1).ToString() + ") is null');", true);
                            LoadUserTraining();
                            return;
                        }

                        DataTable dtCheck = new DataTable();
                        DataTable dtCheckDept = new DataTable();
                        DataTable dtCheckDept1 = new DataTable();
                        DataTable dtCheckClass = new DataTable();
                        dtCheckDept = DBConnect.FillStore("SP_Training_Register_CheckDept", CommandType.StoredProcedure, Dept);
                        string CheckDeptCorrect = dtCheckDept.Rows[0]["CheckDept"].ToString();
                        dtCheck = DBConnect.FillStore("SP_Training_RegisterEmp_CheckUserExits", CommandType.StoredProcedure, EmployeeID.Trim());
                        if (int.Parse(CheckDeptCorrect) > 0)
                        {
                            if (dtCheck.Rows[0]["CheckUserExit"].ToString() == "0") // Insert into tbl_Employee
                            {
                                sql_ = "";
                                sql_ = sql_ + " INSERT INTO [tbl_Employee] (UserName,Password,FullName, DeptID,User_Insert,Date_Insert,EmailAddress,Role) ";
                                sql_ = sql_ + " VALUES( '" + EmployeeID.Trim() + "', '" + EmployeeID.Trim() + "',N'" + FullName + "',N'" + Dept + "','" + Username + "' ,'" + DateTime.Now.ToShortDateString() + "','" + Email + "','User') ";
                                DBConnect.Execute_NonSQL(sql_);
                            }
                            dtCheckClass = DBConnect.FillStore("S_Training_DetailLeason_Add_Check", CommandType.StoredProcedure, Course, Class);
                            int CheckClass = int.Parse(dtCheckClass.Rows[0]["TotalClass"].ToString());
                            if (CheckClass == 0)
                            {
                                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Thông tin khóa học hoặc lớp học không đúng với master :(" + (i + 1).ToString() + ") ');", true);
                                LoadData_Upload(Course, Class, DateTime.Now.ToShortDateString());
                                return;

                            }
                            else
                            {

                                dtCheckDept1 = DBConnect.FillStore("SP_Training_RegisterEmp_CheckUserClass_Exit", CommandType.StoredProcedure, EmployeeID, Dept, Course, Class);

                                if (int.Parse(dtCheckDept1.Rows[0]["TotalUserClass"].ToString()) == 0) // Insert into tbl_Employee_Plan
                                {
                                    sql_1 = sql_1 + " INSERT INTO TRAINING_UserTraining_Plan (IDCourse,Class,UserName ,DateInsert,UserInsert) ";
                                    sql_1 = sql_1 + " VALUES( '" + Course + "',N'" + Class + "','" + EmployeeID + "','" + DateTime.Now.ToShortDateString() + "','" + Username + "') ";
                                    CreateResult_HistoryLesstion(Course, EmployeeID, Class);
                                }
                                else
                                {
                                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('User khóa học tại lớp đã tồn tại :(" + (i + 1).ToString() + ") ');", true);
                                    LoadData_Upload(Course, Class, DateTime.Now.ToShortDateString());
                                    return;
                                }
                            }

                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Thông tin phòng của user sau :(" + (EmployeeID).ToString() + ") không tồn tại bảng master ');", true);
                            return;
                        }
                    }


                    if (sql_1 != "")
                    {
                        DBConnect.Execute_NonSQL(sql_1);
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Upload successful....');", true);
                        LoadUserTraining();
                    }
                    // Delete file upload
                    if (System.IO.File.Exists(link_path))
                    {
                        System.IO.File.Delete(link_path);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Chưa có file upload.');", true);
                }
            }
        }
        protected void bttDownload_Click(object sender, EventArgs e)
        {
            //dtRegistionE = DBConnect.FillStore("SP_Training_RegistionEmp_LoadData", CommandType.StoredProcedure);

            dtRegistionE = DBConnect.FillStore("SP_Training_RegistionEmp_LoadData", CommandType.StoredProcedure);
            if (dtRegistionE.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dtRegistionE, "Training");

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Download_Usertraining.xlsx");
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
        protected void bttTempFile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/FileUpload/Upload_UserForClass.xlsx");
        }
        protected void bttSaveClick(object sender, EventArgs e)
        {
            string userupdate = Session["Username"].ToString();
            string CourseID = ddlCourse_Edit.SelectedValue.ToString();
            string Class = this.ddlClass_Edit.Text.ToString();
            string Employee = txtEmpID.Text.ToString();
            int ID = int.Parse(hdfID.Value.ToString());
            // string Decription = txtDecription.Text.ToString().Trim();
            object[] obj = new object[] { userupdate, CourseID, Class, Employee, ID};
            int status = DBConnect.ExecuteStore("SP_Training_RegisterEmp_Update", CommandType.StoredProcedure, obj);
            if (status == 0)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Updated successfully');", true);
                LoadUserTraining(); 
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Updated failed');", true);
                LoadUserTraining();
            }
        }
        protected void bttSeachClick(object sender, EventArgs e)
        {
            string CourseID = txtCourseID_Search.Text.ToString();
            string Dept = txtDept_Seach.Text.ToString();
            string Employee = txtEmp_Search.Text.ToString();
            string Class = txtClass_Search.Text.ToString();
            dtRegistionE = DBConnect.FillStore("SP_Trainning_RegisterEmp_Search", CommandType.StoredProcedure, CourseID, Class, Employee, Dept);
            

        }
        protected void bttLoadData_Click(object sender, EventArgs e)
        {

            LoadUserTraining();
        }

        protected void ddlCourse_Edit_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindClass_Edit();
        }
    }
    
}