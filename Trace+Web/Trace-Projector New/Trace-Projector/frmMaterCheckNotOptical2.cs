using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace Trace_Projector
{
    public partial class frmMaterCheckNotOptical2 : Form
    {
        public frmMaterCheckNotOptical2()
        {
            InitializeComponent();
        }

        private void loadgrid()
        {
            var dt = DataConn.StoreFillDS("GET_CHECK_OPTICAL2_MASTER", CommandType.StoredProcedure);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                //dataGridView2.Refresh();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string s = Clipboard.GetText();

            string[] lines = s.Replace("\n", "").Split('\r');

            dataGridView2.Rows.Add(lines.Length - 1);
            string[] fields;
            int row = 0;
            int col = 0;

            foreach (string item in lines)
            {
                fields = item.Split('\t');
                foreach (string f in fields)
                {
                    Console.WriteLine(f);
                    dataGridView2[col, row].Value = f;
                    col++;
                }
                row++;
                col = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count <= 0)
            {
                MessageBox.Show("No Data.");
            }
            else
            {
                try
                {
                    // thuc thi cau lenh
                    for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                    {
                        string checkmodelcode = dataGridView2.Rows[i].Cells[1].Value.ToString();  //model code
                        var dt = DataConn.StoreFillDS("Check_NOT_optical2", CommandType.StoredProcedure, checkmodelcode);
                        if (int.Parse(dt.Rows[0][0].ToString()) > 0)
                        {
                            MessageBox.Show("Model da ton tai:  " + checkmodelcode);
                        }
                        else
                        {
                            //them moi
                            string MODEL_CODE = dataGridView2.Rows[i].Cells[1].Value.ToString();
                            string MODEL_NAME = dataGridView2.Rows[i].Cells[2].Value.ToString();
                            string userid = "";
                            DataConn.ExecuteStore("SAVE_NOT_CHECK_Optical2", CommandType.StoredProcedure, MODEL_CODE, MODEL_NAME, userid);                            
                        }
                    }
                    MessageBox.Show("Lưu dữ liệu thành công!");
                    loadgrid();
                }
                catch (Exception)
                {
                    throw;
                }
                
            }
        }
    }
}
