using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Traceability_Hien3.App_Code;

namespace Traceability_Hien3
{
    public partial class MW_RandomLabel_History1 : System.Web.UI.Page
    {
        public DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            //dateinput.Value = DateTime.Now.ToString("yyyy-MM-dd");
            //ToDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
            if (!IsPostBack)
            {
                dateinput.Value = DateTime.Now.ToString("yyyy-MM-dd");
                ToDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                //load_title();

                btnSearch_Click(sender, e);
            }
        }
        protected void LoadHistory()
        {
            dt = DataConn2.StoreFillDS("MW_RandomLabel_History", CommandType.StoredProcedure, dateinput.Value.ToString(), ToDate.Value.ToString());
            rptData.DataSource = dt;
            rptData.DataBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadHistory();
            // System.Threading.Thread.Sleep(5000);

        }
    }
}