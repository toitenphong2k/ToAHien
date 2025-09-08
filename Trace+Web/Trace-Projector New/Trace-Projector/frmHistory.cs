using System;
using System.Data;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Trace_Projector
{
    public partial class frmHistory : Form
    {
        public frmHistory()
        {
            InitializeComponent();
        }
        private void load_line()
        {
            var dt = DataConn.StoreFillDS("LoadLineName", CommandType.StoredProcedure);
            if (dt.Rows.Count>0)
            {
                DataRow dr = dt.NewRow();
                dr[0] = "--Select--";
                //dr[1] = "coldata1";
                dt.Rows.InsertAt(dr, 0);
                cbLine.DataSource = dt;
                cbLine.DisplayMember = "LineName";
                cbLine.ValueMember = "LineName";
            }
            //
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            // Assy 2
            if (rdAssy2.Checked == true)
            {
                var dt = DataConn.StoreFillDS("HistoryAssy2", CommandType.StoredProcedure, cbLine.Text, cbDate.Text,cbToDate.Text, txtTempSerial.Text.Trim());
                if (dt.Rows.Count>0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoResizeColumns();
                }
                else
                {
                    dataGridView1.DataSource = "";
                }
                lbThongbao.Text = dt.Rows.Count.ToString() + " record(s) found...! ";
            }
            // Assy 4
            if (rdAssy4.Checked==true)
            {
                var dt = DataConn.StoreFillDS("HistoryAssy4", CommandType.StoredProcedure, cbDate.Text, cbToDate.Text, txtTempSerial.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoResizeColumns();
                }
                else
                {
                    dataGridView1.DataSource = "";
                }
                lbThongbao.Text = dt.Rows.Count.ToString() + " record(s) found...! ";
            }
            // Visual Check
            if (rdvscheck.Checked==true)
            {
                var dt = DataConn.StoreFillDS("HistoryVisual", CommandType.StoredProcedure, cbLine.Text, cbDate.Text, cbToDate.Text, txtTempSerial.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoResizeColumns();
                }
                else
                {
                    dataGridView1.DataSource = "";
                }
                lbThongbao.Text = dt.Rows.Count.ToString() + " record(s) found...! ";
            }
            // Accessories
            if (rdaccess.Checked==true)
            {
                var dt = DataConn.StoreFillDS("HistoryAccess", CommandType.StoredProcedure, cbLine.Text, cbDate.Text, cbToDate.Text, txtTempSerial.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoResizeColumns();
                }
                else
                {
                    dataGridView1.DataSource = "";
                }
                lbThongbao.Text = dt.Rows.Count.ToString() + " record(s) found...! ";
            }
            // Weight 
            if (rdweight.Checked==true)
            {
                var dt = DataConn.StoreFillDS("HistoryWeight", CommandType.StoredProcedure, cbLine.Text, cbDate.Text, cbToDate.Text, txtTempSerial.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoResizeColumns();
                }
                else
                {
                    dataGridView1.DataSource = "";
                }
                lbThongbao.Text = dt.Rows.Count.ToString() + " record(s) found...! ";
            }
            // Shrink 
            if (rdShrink.Checked == true)
            {
                var dt = DataConn.StoreFillDS("HistoryShrink", CommandType.StoredProcedure, cbDate.Text, cbToDate.Text, txtTempSerial.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoResizeColumns();
                }
                else
                {
                    dataGridView1.DataSource = "";
                }
                lbThongbao.Text = dt.Rows.Count.ToString() + " record(s) found...! ";
            }
            if (rdFCT.Checked == true)
            {
                var dt = DataConn.StoreFillDS("HistoryFC", CommandType.StoredProcedure,  cbDate.Text, cbToDate.Text, txtTempSerial.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoResizeColumns();
                }
                else
                {
                    dataGridView1.DataSource = "";
                }
                lbThongbao.Text = dt.Rows.Count.ToString() + " record(s) found...! ";
            }
        }

        private void frmHistory_Load(object sender, EventArgs e)
        {
            load_line();
            lbThongbao.Text = "";
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                //int i = 1;
                //int j = 1;
                string datestr = DateTime.Now.ToShortDateString();
                //string colName = dataGridView1.Columns[j].HeaderText;
                string filename = "BaoCaoSanXuat_" + DateTime.Now.ToString("yyyy-MM-dd") + "_" + ".xls";
                int cr = 1;
                int cc = 1;
                //Loop through each row and read value from each column. 
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cr == 1)
                        {
                            xlWorkSheet.Cells[cr, cc] = dataGridView1.Columns[j].HeaderText;
                        }
                        cc++;
                    }
                    cc = 1;
                    cr++;
                }
                //get data:
                //you can erase this if you dont need data from rows:
                for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        DataGridViewCell cell = dataGridView1[j, i];
                        xlWorkSheet.Cells[i + 2, j + 1] = cell.Value;
                        xlWorkSheet.Columns.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    }
                }
                xlWorkBook.SaveAs(filename, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
                MessageBox.Show("File đã được lưu:  Documents\\BaoCaoSanXuat_***.xls");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void rdFCT_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
