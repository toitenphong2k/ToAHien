using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Traceability_Hien3.App_Code;

namespace Traceability_Hien3.Projector
{
    public partial class projector_dash : System.Web.UI.Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{

        //}
        public float total_problems = 0;
        public string total_problems_str;
        public float total_year = 0;
        public string total_year_str;
        public float total_month = 0;
        public string total_month_str;
        public float total_pending = 0;
        public string total_pending_str;
        public float total_close = 0;
        public string total_close_str;
        public string week_pc;
        public string month_pc;
        public string year_pc;
        public string pending_pc;
        public string close_pc;
        public float total_week;
        public string total_week_str;
        public float totalbymonth;
        protected void Page_Load(object sender, EventArgs e)
        {
            var monday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
            var sunday = monday.AddDays(+7);
            //TOTAL PROD QTY
            //var dt_total = DataConn.StoreFillDS("SP_ProdQty_ALL", System.Data.CommandType.StoredProcedure);
            var dt_total = DataConn.DataTable_Sql(" exec SP_ProdQty_ALL ");
            total_problems = float.Parse(dt_total.Rows[0][0].ToString());
            total_problems_str = total_problems.ToString("#,##0");
            //THIS YEAR
            //var dt_year = DataConn.StoreFillDS("SP_ProdQty_OF_YEAR", System.Data.CommandType.StoredProcedure);
            var dt_year = DataConn.DataTable_Sql(" exec SP_ProdQty_ALL ");
            total_year = float.Parse(dt_year.Rows[0][0].ToString());
            total_year_str = total_year.ToString("#,##0");
            ////THIS MONTH
            //var dt_month = DataConn.StoreFillDS("SP_ProdQty_OF_MONTH", System.Data.CommandType.StoredProcedure);
            var dt_month = DataConn.DataTable_Sql(" exec SP_ProdQty_OF_MONTH ");
            total_month = float.Parse(dt_month.Rows[0][0].ToString());
            total_month_str = total_month.ToString("#,##0");
            ////PENDING no use
            ////var dt_pending = DataConn.DataTable_Sql("SELECT ISNULL(COUNT(*),0) AS TOTAL FROM GQC_MEETING_CONTENT WHERE [STATUS] = 'O'");
            ////total_pending = float.Parse(dt_pending.Rows[0]["total"].ToString());
            ////total_pending_str = total_pending.ToString("#,##0");
            ////CLOSE no use
            ////var dt_close = DataConn.DataTable_Sql("SELECT ISNULL(COUNT(*),0) AS TOTAL FROM GQC_MEETING_CONTENT WHERE [STATUS] = 'C'");
            ////total_close = float.Parse(dt_close.Rows[0]["total"].ToString());
            ////total_close_str = total_close.ToString("#,##0");
            //THIS WEEK
            var dt_week = DataConn.StoreFillDS("SP_ProdQty_OF_WEEK", System.Data.CommandType.StoredProcedure, monday, sunday);
            total_week = float.Parse(dt_week.Rows[0][0].ToString());
            total_week_str = total_week.ToString("#,##0");

            //PERCENT
            float month_pc1 = (total_month / total_problems);
            month_pc = Math.Round((month_pc1 * 100), 1).ToString();
            year_pc = Math.Round(((total_year / total_problems) * 100), 1).ToString();

            week_pc = Math.Round(((total_week / total_problems) * 100), 1).ToString();
            // SUMMARRY BY CHART






            ////Lay dia chi IP

            //string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            //string machine_name = Dns.GetHostEntry(Request.UserHostAddress).HostName.ToString();
            ////string machine_name = System.Environment.MachineName;
            //DataConn.Execute_NonSQL(" INSERT INTO TBL_LOG_HISTORY(PCName, UserName) VALUES('" + machine_name + "', '" + userName + "') ");

        }
        // BY MONTH

        //// ARE
        protected string renderSeri_MONTH()
        {
            string seri = "";
            var dtSeri = DataConn.StoreFillDS("SP_Dash_ProdQty", System.Data.CommandType.StoredProcedure);
            if (dtSeri.Rows.Count > 0)
            {
                for (int i = 0; i < dtSeri.Rows.Count; i++)
                {
                    seri += dtSeri.Rows[i][1].ToString() + ",";
                }
            }
            return seri;
        }

        //Category BY MONTH
        protected string renderCategori_MONTH()
        {
            string category = "";
            var dtCategory = DataConn.StoreFillDS("SP_Dash_ProdQty", System.Data.CommandType.StoredProcedure);
            if (dtCategory.Rows.Count > 0)
            {
                for (int i = 0; i < dtCategory.Rows.Count; i++)
                {
                    category += "'" + dtCategory.Rows[i][0].ToString().Replace("\n", "-") + "'" + ",";
                }
                if (category.Length > 0)
                {
                    category = category.Substring(0, category.Length - 1);
                }

            }
            //category.Replace("\n", "");
            return category;
        }

        //end  ARE

        //Pie
        protected string rederPie()
        {
            string category = "";
            var dtCategory = DataConn.DataTable_Sql("SELECT * FROM  VIEW_PROD_QTY_BY_MODEL");
            if (dtCategory.Rows.Count > 0)
            {
                for (int i = 0; i < dtCategory.Rows.Count; i++)
                {
                    category += "[" + "'" + dtCategory.Rows[i][0].ToString().Replace("\n", "-") + "'" + "," + dtCategory.Rows[i][1].ToString() + "] ,";
                }
                if (category.Length > 0)
                {
                    category = category.Substring(0, category.Length - 1);
                }

            }
            //category.Replace("\n", "");
            return category;
        }
        //renderCategori -> Line Chart
        //Series
        protected string renderSeri()
        {
            string seri = "";
            var dtSeri = DataConn.StoreFillDS("SP_Dash_ProdQty", System.Data.CommandType.StoredProcedure);
            if (dtSeri.Rows.Count > 0)
            {
                for (int i = 0; i < dtSeri.Rows.Count; i++)
                {
                    seri += dtSeri.Rows[i][1].ToString() + ",";
                }
            }
            return seri;
        }
        //Category     
        protected string renderCategori()
        {
            string category = "";
            //var dtCategory = DataConn.DataTable_Sql("SELECT TOP (10) DEPT_NM, COUNT(ID) AS COUNT FROM dbo.GQC_MEETING_CONTENT GROUP BY DEPT_NM ORDER BY COUNT DESC");
            var dtCategory = DataConn.StoreFillDS("SP_Dash_ProdQty", System.Data.CommandType.StoredProcedure);
            if (dtCategory.Rows.Count > 0)
            {
                for (int i = 0; i < dtCategory.Rows.Count; i++)
                {
                    category += "'" + dtCategory.Rows[i][0].ToString().Replace("\n", "-") + "'" + ",";
                }
                if (category.Length > 0)
                {
                    category = category.Substring(0, category.Length - 1);
                }

            }
            //category.Replace("\n", "");
            return category;
        }

        // END renderCategori -> Line Chart

        //Series peding
        protected string renderSeri_pen()
        {
            string seri = "";
            var dtSeri = DataConn.DataTable_Sql("SELECT top(20) * FROM  VIEW_PROD_QTY_BY_MODEL  order by PROD_QTY desc");
            if (dtSeri.Rows.Count > 0)
            {
                for (int i = 0; i < dtSeri.Rows.Count; i++)
                {
                    seri += dtSeri.Rows[i][1].ToString() + ",";
                }
            }
            return seri;
        }
        // COLUMN
        //Category pending
        protected string renderCategori_pen()
        {
            string category = "";
            var dtCategory = DataConn.DataTable_Sql("SELECT top(20) * FROM  VIEW_PROD_QTY_BY_MODEL  order by PROD_QTY desc");
            if (dtCategory.Rows.Count > 0)
            {
                for (int i = 0; i < dtCategory.Rows.Count; i++)
                {
                    category += "'" + dtCategory.Rows[i][0].ToString().Replace("\n", "-") + "'" + ",";
                }
                if (category.Length > 0)
                {
                    category = category.Substring(0, category.Length - 1);
                }

            }
            //category.Replace("\n", "");
            return category;
        }
    }
}