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
    public partial class frmMaterFCT : Form
    {
        public frmMaterFCT()
        {
            InitializeComponent();
        }

        private void frmMaterFCT_Load(object sender, EventArgs e)
        {
            loadgrid();
        }

        private void loadgrid()
        {
            var dt = DataConn.StoreFillDS("GET_MASTER_FCT", CommandType.StoredProcedure);
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
                // thuc thi cau lenh
                try
                {
                    for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                    {
                        //them moi
                        string MODEL_CODE = dataGridView2.Rows[i].Cells[0].Value.ToString();
                        string MODEL_NAME = dataGridView2.Rows[i].Cells[1].Value.ToString();
                        string PROCESS_CODE = dataGridView2.Rows[i].Cells[2].Value.ToString();
                        DataConn.ExecuteStore("SAVE_Mater_FCT", CommandType.StoredProcedure, MODEL_CODE, MODEL_NAME, PROCESS_CODE);
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
