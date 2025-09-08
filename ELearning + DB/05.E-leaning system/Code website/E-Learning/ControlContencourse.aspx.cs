using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E_Learning.Connect;


namespace E_Learning
{
    public partial class ControlContencourse : System.Web.UI.Page
    {
        public DataTable dtcourse = new DataTable();
        public DataTable dtupdatecourse = new DataTable();

       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dtcourse = DBConnect.StoreFillDS("Get_filter_course", System.Data.CommandType.StoredProcedure);
                DataRow newRow2 = dtcourse.NewRow();
                newRow2["NameCourse"] = "==select==";
                dtcourse.Rows.InsertAt(newRow2, 0);
                dr_filter_course.DataSource = dtcourse;
                dr_filter_course.DataBind();
            }
           

        }
        
        protected void Submit(object sender, EventArgs e)
        {            
            string courserID2 = dr_filter_course.Text;
            string gioithieu = txtintroduce.Text.ToString();
            string noidung = txtcontent.Text.ToString();

            dtupdatecourse = DBConnect.StoreFillDS("Get_filter_course_Updateconten", System.Data.CommandType.StoredProcedure, courserID2, gioithieu, noidung);
            if (dtupdatecourse.Rows[0][0].ToString() == "1")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Success!');", true);
                Response.Redirect("ControlContencourse.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('NG! check again!');", true);
                Response.Redirect("ControlContencourse.aspx");
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            txtintroduce.Text = "";
            txtcontent.Text = "";
            TextBox3.Text = "";
        }

    }
}