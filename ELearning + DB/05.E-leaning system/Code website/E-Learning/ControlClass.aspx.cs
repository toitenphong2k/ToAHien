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
using ClosedXML.Excel;
using E_Learning.Connect;

namespace E_Learning
{
    public partial class ControlClass : System.Web.UI.Page
    {
        public string Username = "";
        public DataTable dtListClass = new DataTable();

        public OleDbConnection MyConnection { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                LoadClass();
                BindCourse();
                BindTreeCourse();
                BindStatus_Add();
                BindStatus_Update();
                
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
        public void LoadClass()
        {
            dtListClass = DBConnect.FillStore("SP_Training_Classs", CommandType.StoredProcedure);

        }
        public void BindCourse()
        {
            DataTable dt = new DataTable();
            dt = DBConnect.FillStore("S_BindCourse_ListCourse", CommandType.StoredProcedure);
            if (dt.Rows.Count > 0)
            {

                DataRow dr = dt.NewRow();
                dr[1] = "-- Select Course  --";
                dt.Rows.InsertAt(dr, 0);
                ddlNameCourse_Add.DataSource = dt;
                ddlNameCourse_Add.DataTextField = "NameCourse";
                ddlNameCourse_Add.DataValueField = "CourseID";
                ddlNameCourse_Add.DataBind();

            }
        }
        public void BindTreeCourse()
        {
            Tree_Course.Nodes.Clear();
            TreeNode treeNodes = new TreeNode
            {
                Text = "Management Course in PSNV"
                 
            };

            Tree_Course.Nodes.Add(treeNodes);
            Tree_Course.ForeColor = System.Drawing.Color.Blue;
            DataTable table_Tree1 = new DataTable();
          
            string User = Session["UserName"].ToString().Trim();

            table_Tree1 = DBConnect.StoreFillDS("S_BindCourse_Pending", CommandType.StoredProcedure);
            if (table_Tree1.Rows.Count > 0)
            {
                TreeNode treeChild1 = new TreeNode
                {
                    Text = "List Course Active"
                };

                treeNodes.ChildNodes.Add(treeChild1);
                for (int i = 0; i < table_Tree1.Rows.Count; i++)
                {
                    TreeNode treeChild3 = new TreeNode
                    {
                        Text = table_Tree1.Rows[i]["NameCourse"].ToString()
                        
                    };
                    treeChild1.ChildNodes.Add(treeChild3);
                }
            }

            DataTable table_Tree2 = new DataTable();
            table_Tree2 = DBConnect.StoreFillDS("S_BindCourse_Finish", CommandType.StoredProcedure);
            if (table_Tree2.Rows.Count > 0)
            {
                TreeNode treeChild2 = new TreeNode
                {
                    Text = "List Course  Fisnished"
                };

                treeNodes.ChildNodes.Add(treeChild2);
                for (int i = 0; i < table_Tree2.Rows.Count; i++)
                {
                    TreeNode treeChild4 = new TreeNode
                    {
                        Text = table_Tree2.Rows[i]["NameCourse"].ToString()
                    };
                    treeChild2.ChildNodes.Add(treeChild4);
                    // Search(table_Tree2.Rows[i]["RequestNo"].ToString());
                }
            }

        }
        public void BindSearch(string CourseName)
        {
            
            dtListClass = DBConnect.FillStore("SP_Training_Classs_Search", CommandType.StoredProcedure, CourseName);
        }

        protected void bttDownload_Click(object sender, EventArgs e)
        {

            dtListClass = DBConnect.FillStore("SP_Training_Classs", CommandType.StoredProcedure);
            if (dtListClass.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dtListClass, "Class");

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Download_ListClass.xlsx");
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
            Response.Redirect("~/FileUpload/Upload_Class.xlsx");
        }

        protected void bttLoadData_Click(object sender, EventArgs e)
        {
            LoadClass();
        }
        public void LoadData_Upload(string CourseID, string Class, string Datetime)
        {
          //  dtRegistionE = DBConnect.FillStore("SP_Trainning_RegisterEmp_LoadUpload", CommandType.StoredProcedure, CourseID, Class, Datetime);
            //lblTotal.Text = "Total:" + dtRegistionE.Rows.Count.ToString();

        }
        protected void BindStatus_Add()
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

        protected void BindStatus_Update()
        {

            DataTable dt = new DataTable();
            dt = DBConnect.DataTable_Sql("select  ID, Status  from  [dbo].[tbl_Status]");
            if (dt.Rows.Count > 0)
            {
                this.ddlStatus_Update.Items.Clear();
                ddlStatus_Update.DataTextField = "Status";
                ddlStatus_Update.DataValueField = "Status";
                ddlStatus_Update.DataSource = dt;
                ddlStatus_Update.DataBind();
            }
        }

        [WebMethod]
        public static void Delete_CourseIDClass(string CourseID, string Class)
        {
            try
            {
                object[] obj = new object[] { CourseID, Class };
                int status = DBConnect.ExecuteStore("S_Training_DeleteClass", CommandType.StoredProcedure, obj);

            }
            catch (Exception)
            {
                return;
            }
        }

        protected void BindTypeContent()
        {

            DataTable dt = new DataTable();
            dt = DBConnect.FillStore("S_TypeContent", CommandType.StoredProcedure);
            if (dt.Rows.Count > 0)
            {
                this.ddlNameCourse_Add.Items.Clear();
                ddlNameCourse_Add.DataTextField = "NameCourse";
                ddlNameCourse_Add.DataValueField = "CourseID";
                ddlNameCourse_Add.DataSource = dt;
                ddlNameCourse_Add.DataBind();
            }
        }
        protected void bttSave_Click(object sender, EventArgs e)
        {

            
        }
        //protected void bttUpload_Click(object sender, EventArgs e)
        //{
        //    System.Data.DataSet DtSet;
        //    System.Data.OleDb.OleDbDataAdapter MyCommand;
        //    DataTable dt = new DataTable();
        //    dt = null;
        //    if (this.ftp_Upload.HasFile)
        //    {
        //        string strFileType = Path.GetExtension(this.ftp_Upload.FileName).ToLower();
        //        string path = ftp_Upload.PostedFile.FileName;
        //        string link_path = Server.MapPath("~/Upload_File/" + DateTime.Now.ToString("yyyyMMdd") + "_" + ftp_Upload.FileName);
        //        if (ftp_Upload.FileName == "Upload_Class.xlsx" || ftp_Upload.FileName == "Upload_Class.xls")
        //        {
        //            ftp_Upload.SaveAs(link_path);
        //            //Connection String to Excel Workbook            
        //            if (strFileType.Trim() == ".xls")
        //            {
        //                System.Data.OleDb.OleDbConnection
        //                                        MyConnection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + link_path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"");
        //                MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
        //                MyCommand.TableMappings.Add("Table", "TestTable");
        //                DtSet = new System.Data.DataSet();
        //                MyCommand.Fill(DtSet);
        //                dt = DtSet.Tables[0];
        //                MyConnection.Close();
        //            }
        //            else if (strFileType.Trim() == ".xlsx")
        //            {
        //                //connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
        //                MyConnection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + link_path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"");
        //                MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
        //                MyCommand.TableMappings.Add("Table", "TestTable");
        //                DtSet = new System.Data.DataSet();
        //                MyCommand.Fill(DtSet);
        //                dt = DtSet.Tables[0];
        //                MyConnection.Close();
        //            }

        //            string sql_ = ""; string sql_1 = "";

        //            if (dt.Rows.Count > 0)
        //            {
        //                DataTable dtCourse = new DataTable();
        //                for (int i = 0; i < dt.Rows.Count; i++)
        //                {
        //                    //RequestNo,PartNo,MOQ,LeadTime,CustomerCode, Deadline,Remask,Peson_Incharge,Date_Incharge,Insert_user,Update_Date
        //                    string EmployeeID = ""; string FullName = ""; string Dept = null; string Course; string Class;



        //                    if (dt.Rows[i][0].ToString() != "")
        //                    {
        //                        EmployeeID = dt.Rows[i][0].ToString();
        //                    }
        //                    else
        //                    {
        //                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('This data EmployeeID  at row :(" + (i + 1).ToString() + ") is null');", true);
        //                        LoadClass();
        //                        return;
        //                    }
        //                    if (dt.Rows[i][1].ToString() != "")
        //                    {
        //                        FullName = dt.Rows[i][1].ToString();
        //                    }
        //                    else
        //                    {
        //                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('This data Full Name  at row :(" + (i + 1).ToString() + ") is null');", true);
        //                        LoadClass();
        //                        return;
        //                    }
        //                    if (dt.Rows[i][2].ToString() != "")
        //                    {
        //                        Dept = dt.Rows[i][2].ToString();
        //                    }
        //                    else
        //                    {
        //                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('This data DeptName  at row :(" + (i + 1).ToString() + ") is null');", true);
        //                        LoadClass();
        //                        return;
        //                    }


        //                    if (dt.Rows[i][3].ToString() != "")
        //                    {
        //                        Course = dt.Rows[i][3].ToString();
        //                    }
        //                    else
        //                    {
        //                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('This data Course at row :(" + (i + 1).ToString() + ") is null');", true);
        //                        LoadClass();
        //                        return;
        //                    }
        //                    if (dt.Rows[i][4].ToString() != "")
        //                    {
        //                        Class = dt.Rows[i][4].ToString();
        //                    }
        //                    else
        //                    {
        //                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('This data Class at row :(" + (i + 1).ToString() + ") is null');", true);
        //                        LoadClass();
        //                        return;
        //                    }

        //                    DataTable dtCheck = new DataTable();
        //                    DataTable dtCheckDept = new DataTable();
        //                    DataTable dtCheckDept1 = new DataTable();

        //                    dtCheck = DBConnect.FillStore("SP_Training_RegisterEmp_CheckUserExits", CommandType.StoredProcedure, EmployeeID, Dept);
        //                    if (dtCheck.Rows[0]["CheckUserExit"].ToString() == "0") // Insert into tbl_Employee
        //                    {
        //                        dtCheckDept = DBConnect.FillStore("SP_Training_Register_CheckDept", CommandType.StoredProcedure, Dept);
        //                        string CheckDeptCorrect = dtCheckDept.Rows[0]["CheckDept"].ToString();
        //                        if (int.Parse(CheckDeptCorrect) == 0)
        //                        {
        //                            sql_ = sql_ + " INSERT INTO [tbl_Employee] (UserName,Passwrod,FullName, DeptID,User_Insert,Date_Insert) ";
        //                            sql_ = sql_ + " VALUES( '" + EmployeeID + "','" + 123456 + "',N'" + FullName + "',N'" + Dept + "','" + Username + "' ,'" + DateTime.Now.ToShortDateString() + "') ";

        //                        }
        //                    }
        //                    dtCheckDept1 = DBConnect.FillStore("SP_Training_RegisterEmp_CheckUserClass_Exit", CommandType.StoredProcedure, EmployeeID, Dept, Course, Class);
        //                    if (int.Parse(dtCheckDept1.Rows[0]["TotalUserClass"].ToString()) == 0) // Insert into tbl_Employee_Plan
        //                    {
        //                        sql_1 = sql_1 + " INSERT INTO [tbl_UserTraining_Plan] (IDCourse,Class,UserName ,DateInsert,UserInsert) ";
        //                        sql_1 = sql_1 + " VALUES( '" + Course + "',N'" + Class + "','" + EmployeeID + "','" + DateTime.Now.ToShortDateString() + "','" + Username + "') ";


        //                    }
        //                    else
        //                    {
        //                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('UserName already registation in course in class at row :(" + (i + 1).ToString() + ") ');", true);
        //                        LoadData_Upload(Course, Class, DateTime.Now.ToShortDateString());
        //                        return;
        //                    }
        //                }

        //            }
        //            // Insert to list employee
        //            if (sql_ != "")
        //            {
        //                DBConnect.Execute_NonSQL(sql_);
        //            }
        //            if (sql_1 != "")
        //            {
        //                DBConnect.Execute_NonSQL(sql_1);
        //                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Upload successful....');", true);
        //                LoadClass();
        //            }
        //        }
        //        // Delete file upload
        //        if (System.IO.File.Exists(link_path))
        //        {
        //            System.IO.File.Delete(link_path);
        //        }
        //    }
        //    else
        //    {
        //        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning(Please check data excel file !!!');", true);
        //    }
        //}

        protected void Tree_Course_SelectedNodeChanged(object sender, EventArgs e)
        {
            string NameCourse =  Tree_Course.SelectedNode.Value.ToString();
            BindSearch(NameCourse);

        }

        protected void bttDownload_ServerClick(object sender, EventArgs e)
        {
            dtListClass = DBConnect.FillStore("SP_Training_Classs", CommandType.StoredProcedure);
            if (dtListClass.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dtListClass, "Class");

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Download_ListClass.xlsx");
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


            protected void bttUpdate_ServerClick(object sender, EventArgs e)
        {
            string userupdate = Session["UserName"].ToString();
            string Status = ddlStatus_Update.SelectedValue.ToString();
            string CourseID = hdfCourse.Value.ToString();
            string ClassName = txtClass.Text.ToString();
            string FromDate = txtDateForm.Text.ToString();
            string ToDate = txtToDate.Text.ToString().Trim();
            if (FromDate  == "" || ToDate =="" )
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Điền thông tin của lớp học.');", true);
            }
            else if(Status =="")
             {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Điền thông tin trạng thái lớp học.');", true);
            }
            else if(ClassName =="")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Điền tên lớp học.');", true);
            }
            else
            {
                object[] obj = new object[] { CourseID, ClassName, FromDate, ToDate, userupdate, Status };
                int status = DBConnect.ExecuteStore("SP_Training_Classs_Update", CommandType.StoredProcedure, obj);
                if (status == 0)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Cập nhật thành công.');", true);
                    LoadClass();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Cập nhật bị lỗi.');", true);
                    LoadClass();
                }
            }

        }

        protected void bttSAVE_ServerClick(object sender, EventArgs e)
        {
            string userupdate = Session["UserName"].ToString();
            string Status = ddlStatus.SelectedValue.ToString();
            string CourseID = ddlNameCourse_Add.SelectedValue.ToString();
            string ClassName = txtClass_Add.Text.ToString();
            string FromDate = txtFromDate_Add.Text.ToString();
            string ToDate = txtToDate_Add.Text.ToString().Trim();
            if (FromDate == "" || ToDate == "")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Điền thời gian của lớp học.');", true);
            }
            else if (Status == "")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Điền trạng thái của lớp học.');", true);
            }
            else if (ClassName == "")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.error('Điền tên lớp học.');", true);
            }
            else
            {
                object[] obj = new object[] { CourseID, ClassName, FromDate, ToDate, userupdate, Status };
                int status = DBConnect.ExecuteStore("SP_Training_Classs_ADD", CommandType.StoredProcedure, obj);
                if (status == 0)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.success('Thêm mới thành công.');", true);
                    LoadClass();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "toastr.warning('Thêm mới bị lỗi.');", true);
                    LoadClass();
                }
            }

        }
    }
}