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
    public partial class frmModelSetting : Form
    {
        public frmModelSetting()
        {
            InitializeComponent();
        }
        private void load_model()
        {
            var dt = DataConn.DataTable_Sql("SELECT MODEL_CODE, MODEL_NM, PCB_QTY, OPTICAL_QTY, OPTICAL2, LEN_QTY FROM TBL_MODEL WHERE DELETE_FLAG = 'N' ORDER BY ID");
            if (dt.Rows.Count>0)
            {
                cbModelName.DataSource = dt;
                cbModelName.DisplayMember = "MODEL_NM";
                cbModelName.ValueMember = "MODEL_CODE";
                dataGridView1.DataSource = dt;
            }
        }

        private void frmModelSetting_Load(object sender, EventArgs e)
        {
            frmConfrimLD _frmLeader = new frmConfrimLD("Leader password setting");
            _frmLeader.ShowDialog();
            load_model();
            label4.Visible = false;
            lbThongbao.Text = "";
            btnAdd.Visible = false;
        }

        private void cbModelName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbOpticalQty.SelectedIndex = -1;
            cbPCBQty.SelectedIndex = -1;
            cbPCBQty.Items.Remove(cbPCBQty.SelectedItem);
            var dt = DataConn.DataTable_Sql("SELECT ID,MODEL_CODE, MODEL_NM, PCB_QTY, OPTICAL_QTY, OTHER, OPTICAL2, LEN_QTY FROM TBL_MODEL WHERE DELETE_FLAG = 'N' AND MODEL_CODE = '"+cbModelName.SelectedValue.ToString()+"'");
            if (dt.Rows.Count > 0)
            {
                label4.Text = dt.Rows[0]["ID"].ToString();
                cbModelCode.Text = dt.Rows[0]["MODEL_CODE"].ToString();
                cbOpticalQty.Items.Add("0");
                cbOpticalQty.Items.Add("1");
                cbOpticalQty.Items.Add("2");
                cbOpticalQty.Items.Add("3");
                cbOpticalQty.Items.Add("4");
                cbOpticalQty.Items.Add("5");
                cbOpticalQty.Items.Add("6");
                cbOpticalQty.Items.Add("7");
                cbOpticalQty.Items.Add("8");
                cbPCBQty.Items.Add("0");
                cbPCBQty.Items.Add("1");
                cbPCBQty.Items.Add("2");
                cbPCBQty.Items.Add("3");
                cbPCBQty.Items.Add("4");
                cbPCBQty.Items.Add("5");
                cbPCBQty.Items.Add("6");
                cbPCBQty.Items.Add("7");
                cbPCBQty.Items.Add("8");
                cbOther.Items.Add("0");
                cbOther.Items.Add("1");
                cbOther.Items.Add("2");
                cbOther.Items.Add("3");
                cbOther.Items.Add("4");
                cbOther.Items.Add("5");
                cbOther.Items.Add("6");
                cbOther.Items.Add("7");
                cbOther.Items.Add("8");
                cbOptical2Qty.Items.Add("0");
                cbOptical2Qty.Items.Add("1");
                cbOptical2Qty.Items.Add("2");
                cbOptical2Qty.Items.Add("3");
                cbLenQty.Items.Add("0");
                cbLenQty.Items.Add("1");
                cbLenQty.Items.Add("2");
                cbLenQty.Items.Add("3");
                cbPCBQty.SelectedItem = dt.Rows[0]["PCB_QTY"].ToString();
                cbOpticalQty.SelectedItem = dt.Rows[0]["OPTICAL_QTY"].ToString();
                cbOther.SelectedItem = dt.Rows[0]["OTHER"].ToString();
                cbOptical2Qty.SelectedItem = dt.Rows[0]["OPTICAL2"].ToString(); 
                cbLenQty.SelectedItem = dt.Rows[0]["LEN_QTY"].ToString();
                label8.Text = "";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn sửa model này?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (label4.Text != "" )
                {
                    DataConn.ExecuteStore("UpDateModelSetting", CommandType.StoredProcedure, label4.Text, cbPCBQty.SelectedItem.ToString(), cbOpticalQty.SelectedItem.ToString(), cbOther.SelectedItem.ToString(), cbLenQty.SelectedItem.ToString(), cbOptical2Qty.SelectedItem.ToString());
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
