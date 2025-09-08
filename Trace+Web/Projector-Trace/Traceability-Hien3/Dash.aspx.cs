using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Traceability_Hien3.App_Code;

namespace Traceability_Hien3
{
    public partial class Dash : System.Web.UI.Page
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
        public float total_week;
        public string total_week_str;
        public float totalbymonth;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var monday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
                var sunday = monday.AddDays(+7);
                //TOTAL PROD QTY
                //var dt_total = DataConn2.StoreFillDS("SP_ProdQty_ALL", System.Data.CommandType.StoredProcedure);
                var dt_total = DataConn.DataTable_Sql(" exec SP_ProdQty_ALL ");
                total_problems = float.Parse(dt_total.Rows[0][0].ToString());
                total_problems_str = total_problems.ToString("#,##0");
                //THIS YEAR
                //var dt_year = DataConn2.StoreFillDS("SP_ProdQty_OF_YEAR", System.Data.CommandType.StoredProcedure);
                var dt_year = DataConn.DataTable_Sql(" exec SP_ProdQty_ALL ");
                total_year = float.Parse(dt_year.Rows[0][0].ToString());
                total_year_str = total_year.ToString("#,##0");
                ////THIS MONTH
                //var dt_month = DataConn2.StoreFillDS("SP_ProdQty_OF_MONTH", System.Data.CommandType.StoredProcedure);
                var dt_month = DataConn.DataTable_Sql(" exec SP_ProdQty_OF_MONTH ");
                total_month = float.Parse(dt_month.Rows[0][0].ToString());
                total_month_str = total_month.ToString("#,##0");
                ////PENDING no use
                ////var dt_pending = DataConn2.DataTable_Sql("SELECT ISNULL(COUNT(*),0) AS TOTAL FROM GQC_MEETING_CONTENT WHERE [STATUS] = 'O'");
                ////total_pending = float.Parse(dt_pending.Rows[0]["total"].ToString());
                ////total_pending_str = total_pending.ToString("#,##0");
                ////CLOSE no use
                ////var dt_close = DataConn2.DataTable_Sql("SELECT ISNULL(COUNT(*),0) AS TOTAL FROM GQC_MEETING_CONTENT WHERE [STATUS] = 'C'");
                ////total_close = float.Parse(dt_close.Rows[0]["total"].ToString());
                ////total_close_str = total_close.ToString("#,##0");
                //THIS WEEK
                var dt_week = DataConn.StoreFillDS("SP_ProdQty_OF_WEEK", System.Data.CommandType.StoredProcedure, monday.ToString("yyyy-MM-dd"), sunday.ToString("yyyy-MM-dd"));
                total_week = float.Parse(dt_week.Rows[0][0].ToString());
                total_week_str = total_week.ToString("#,##0");
            }
        }
        //Pie
        protected string rederPie()
        {
            string category = "";
            var dtCategory = DataConn.DataTable_Sql("SELECT top(15) * FROM  VIEW_PROD_QTY_BY_MODEL order by PROD_QTY desc ");
            if (dtCategory.Rows.Count > 0)
            {
                for (int i = 0; i < dtCategory.Rows.Count; i++)
                {
                    category += '"' +  dtCategory.Rows[i][0].ToString() + '"' + ",";
                }
            }
            return category.Substring(0, category.Length - 1);
            //return category;
        }
        protected string rederDataPie()
        {
            string category = "";
            var dtCategory = DataConn.DataTable_Sql("SELECT top(15) * FROM  VIEW_PROD_QTY_BY_MODEL order by PROD_QTY desc ");
            if (dtCategory.Rows.Count > 0)
            {
                for (int i = 0; i < dtCategory.Rows.Count; i++)
                {
                    category +=  dtCategory.Rows[i][1].ToString()+ ","; // "aaa"
                    
                }
            }
            return category.Substring(0, category.Length - 1);
            //return category;
        }
        protected string renderMonth()
        {
            var dtthang = DataConn.StoreFillDS("THONGKE_THEOTHANG", System.Data.CommandType.StoredProcedure);
            string kk = "";
            if (dtthang.Rows.Count > 0)
            {
                for (int i = 0; i < dtthang.Rows.Count; i++)
                {
                    kk += '"' + "Tháng" + dtthang.Rows[i][0].ToString() + '"' + ",";
                }
                return kk.Substring(0, kk.Length - 1);
            }
            else return kk;
        }
        protected string renderdataMonth()
        {
            var dtthang = DataConn.StoreFillDS("SP_Dash_ProdQty", System.Data.CommandType.StoredProcedure);
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