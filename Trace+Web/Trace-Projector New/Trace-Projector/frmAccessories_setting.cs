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
    public partial class frmAccessories_setting : Form
    {
        public frmAccessories_setting()
        {
            InitializeComponent();
        }
        private void load_model()
        {
            var dt1 = DataConn.DataTable_Sql("SELECT MODEL_CODE, MODEL_NM FROM TBL_MODEL WHERE MODEL_CODE = '" + cbModelName.SelectedValue.ToString() + "' AND DELETE_FLAG = 'N' ORDER BY ID");
            if (dt1.Rows.Count > 0)
            {
                cbModelCode.Text = dt1.Rows[0]["MODEL_CODE"].ToString();
            }

            var dt = DataConn.DataTable_Sql("SELECT * FROM View_ACCESSORIES_LIST WHERE MODEL_CODE = '"+cbModelName.SelectedValue.ToString()+ "' order by STEP, no ");
            if (dt.Rows.Count > 0)
            {
                cbPartQty.Text = dt.Rows.Count.ToString();
                txtSTD.Text = dt.Rows[0]["WEIGHT_STD"].ToString();
                txtSTDup.Text = dt.Rows[0]["WEIGHT_STD_UP"].ToString();
                txtSTDw.Text = dt.Rows[0]["WEIGHT_STD_DW"].ToString();
                lbThongbao.Text = "";
                dataGridView1.DataSource = dt;

            }
            else
            {
                lbThongbao.Text = "Model chưa được cài đặt...";
                dataGridView1.DataSource = "";
                lbThongbao.ForeColor = Color.Yellow;
                lbThongbao.BackColor = Color.Red;
                txtSTD.Text = "0";
                txtSTDup.Text = "0";
                txtSTDw.Text = "0";
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin model này?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (cbModelCode.Text != "")
                {
                    DataConn.ExecuteStore("UpDateAccessSetting", CommandType.StoredProcedure, cbModelCode.Text.Trim(), txtSTD.Text.Trim(), txtSTDup.Text.Trim(), txtSTDw.Text.Trim());
                    DataConn.ExecuteStore("UpdateAccessPart", CommandType.StoredProcedure, cbModelCode.Text.Trim(), txtItemCode.Text.Trim(), cbStep.Text, cbNo.Text);
                    lbThongbao.Text = "Cập nhật dữ liệu thành công..";
                    load_model();
                }
                else
                {
                    lbThongbao.Text = "Error..........";
                    lbThongbao.ForeColor = Color.Yellow;
                    lbThongbao.BackColor = Color.Red;
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }
        private void load_model_std()
        {
            var dt = DataConn.DataTable_Sql("SELECT MODEL_CODE, MODEL_NM FROM TBL_MODEL WHERE DELETE_FLAG = 'N' ORDER BY ID");
            if (dt.Rows.Count > 0)
            {
                cbModelName.DataSource = dt;
                cbModelName.DisplayMember = "MODEL_NM";
                cbModelName.ValueMember = "MODEL_CODE";
                cbModelCode.DisplayMember = "MODEL_CODE";
                //cbModelCode.Text = dt.Rows[0][].ToString();
            }
        }
        private void frmAccessories_setting_Load(object sender, EventArgs e)
        {
            frmConfrimLD _frmLeader = new frmConfrimLD("Leader password setting");
            _frmLeader.ShowDialog();
            load_model_std();
            lbID.Visible = false;
        }

        private void cbModelName_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_model();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =  dataGridView1.Rows[e.RowIndex];
                txtItemCode.Text = row.Cells[3].Value.ToString();
                cbStep.Text = row.Cells[7].Value.ToString();
                cbNo.Text = row.Cells[2].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn THÊM thông tin model này?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (cbModelCode.Text != "")
                {
                    DataConn.ExecuteStore("InsertAccessPart", CommandType.StoredProcedure, cbModelCode.Text, txtItemCode.Text.Trim(), cbStep.Text);
                    lbThongbao.Text = "Thêm dữ liệu thành công..";
                    load_model();
                }
                else
                {
                    lbThongbao.Text = "Error..........";
                    lbThongbao.ForeColor = Color.Yellow;
                    lbThongbao.BackColor = Color.Red;
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }
    }
}
