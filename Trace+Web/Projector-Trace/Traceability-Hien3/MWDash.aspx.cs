using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Traceability_Hien3.App_Code;
namespace Traceability_Hien3
{
    public partial class MWDash : System.Web.UI.Page
    {
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
        public float total_Daily;
        public string total_Daily_str;
        public float totalbymonth;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var monday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
                var sunday = monday.AddDays(+7);
                //TOTAL PROD QTY
                var dt_total = DataConnect_MW.DataTable_Sql("exec SP_REPORT_AllTotal");
                total_problems = float.Parse(dt_total.Rows[0][0].ToString());
                total_problems_str = total_problems.ToString("#,##0");
                //THIS YEAR
                var dt_year = DataConnect_MW.DataTable_Sql("exec SP_REPORT_AllTotal_Year ");
                total_year = float.Parse(dt_year.Rows[0][0].ToString());
                total_year_str = total_year.ToString("#,##0");
                ////THIS MONTH
                var dt_month = DataConnect_MW.DataTable_Sql(" exec SP_REPORT_AllTotal_Month ");
                total_month = float.Parse(dt_month.Rows[0][0].ToString());
                total_month_str = total_month.ToString("#,##0");

                //THIS 
                var dt_Daily = DataConnect_MW.StoreFillDS("SP_REPORT_AllTotal_Daily", System.Data.CommandType.StoredProcedure);
                total_Daily = float.Parse(dt_Daily.Rows[0][0].ToString());
                total_Daily_str = total_Daily.ToString("#,##0");
            }

        }
        protected string rederPie()
        {
            string category = "";
            var dtCategory = DataConnect_MW.DataTable_Sql("SELECT top(15) * FROM  V_REPORT_TOTALQTY_BYMODEl order by PROD_QTY desc ");
            if (dtCategory.Rows.Count > 0)
            {
                for (int i = 0; i < dtCategory.Rows.Count; i++)
                {
                    category += '"' + dtCategory.Rows[i][0].ToString() + '"' + ",";
                }
            }
            return category.Substring(0, category.Length - 1);
            //return category;
        }
        protected string rederDataPie()
        {
            string category = "";
            var dtCategory = DataConnect_MW.DataTable_Sql("SELECT top(15) * FROM  V_REPORT_TOTALQTY_BYMODEl order by PROD_QTY desc ");
            if (dtCategory.Rows.Count > 0)
            {
                for (int i = 0; i < dtCategory.Rows.Count; i++)
                {
                    category += dtCategory.Rows[i][1].ToString() + ","; // "aaa"

                }
            }
            return category.Substring(0, category.Length - 1);
            //return category;
        }

        protected string renderdataMonth()
        {
            var dtthang = DataConnect_MW.StoreFillDS("SP_REPORT_Total_DailyMothly", System.Data.CommandType.StoredProcedure);
            string kk = "";
            if (dtthang.Rows.Count > 0)
            {
                kk += dtthang.Rows[0][0].ToString() + "," + dtthang.Rows[0][1].ToString() + "," + dtthang.Rows[0][2].ToString() + "," + dtthang.Rows[0][3].ToString() + "," + dtthang.Rows[0][4].ToString() + ",";
                kk += dtthang.Rows[0][5].ToString() + "," + dtthang.Rows[0][6].ToString() + "," + dtthang.Rows[0][7].ToString() + "," + dtthang.Rows[0][8].ToString() + "," + dtthang.Rows[0][9].ToString() + ",";
                kk += dtthang.Rows[0][10].ToString() + ",";
                kk += dtthang.Rows[0][11].ToString() + ",";
                return kk.Substring(0, kk.Length - 1);
            }
            else return kk;
        }
    }
}