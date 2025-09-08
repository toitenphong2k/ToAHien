using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.IO;

namespace Trace_Projector
{
    public partial class frmModelAccessories : Form
    {
        string model_code = "", modelname = "";
        string strerror = "";
        StreamWriter writer;
        int Check_OK = 0;
        public frmModelAccessories()
        {
            InitializeComponent();
        }
       
        private void tctModelCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                modelname = txtModelCode.Text.Trim();
                var dt = DataConn.StoreFillDS("CheckModelSettingAcc", CommandType.StoredProcedure, modelname);
                if (dt.Rows.Count>0)
                {
                    dataGridView1.DataSource = dt;
                    lbThongbao.Text = dt.Rows.Count.ToString() + " - tài liệu, phụ kiện được cài đặt trong model này...";
                    Check_OK = 1;
                    model_code = dt.Rows[0]["MODEL_CODE"].ToString();
                }
                else
                {
                    strerror = "Không tìm thấy Model này";
                    lbThongbao.Text = strerror;
                    lbThongbao.ForeColor = Color.Yellow;
                    lbThongbao.BackColor = Color.Red;
                    txtModelCode.SelectAll();
                    frmConfrim _frmconfrim = new frmConfrim(strerror);
                    _frmconfrim.ShowDialog();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Check_OK == 1)
            {
                // Save File
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn lưu dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (File.Exists(Directory.GetCurrentDirectory() + @"\ModelACC.ini") == false)
                    {
                        writer = File.CreateText(Directory.GetCurrentDirectory() + @"\ModelACC.ini");
                        writer.Close();
                    }
                    writer = File.CreateText(Directory.GetCurrentDirectory() + @"\ModelACC.ini");
                    writer.WriteLine(modelname + "," + model_code);
                    writer.Close();
                    MessageBox.Show("Lưu dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lbThongbao.Text = "Lưu dữ liệu thành công...";
                    txtModelCode.SelectAll();
                }              
            }
            else
            {
                strerror = "Lỗi....";
                lbThongbao.Text = strerror;
                lbThongbao.ForeColor = Color.Yellow;
                lbThongbao.BackColor = Color.Red;
                txtModelCode.SelectAll();
                frmConfrim _frmconfrim = new frmConfrim(strerror);
                _frmconfrim.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                
            }
        }

        private void frmModelAccessories_Load(object sender, EventArgs e)
        {
            lbThongbao.Text = "";
            txtModelCode.SelectAll();

            //if (File.Exists(Directory.GetCurrentDirectory() + @"\ModelACC.ini") == true)
            //{
            //    using (StreamReader rd = new StreamReader(Directory.GetCurrentDirectory() + @"\ModelACC.ini"))
            //    {
            //        string aa = rd.ReadLine();
            //        string[] _values = aa.Trim().Split(',');
            //        modelname = _values[0];
            //        model_code = _values[1];
            //    }
            //}
            //else
            //{
            //    strerror = "Không tìm thấy file Cài đặt Model";
            //    lbThongbao.Text = strerror;
            //    lbThongbao.ForeColor = Color.Yellow;
            //    lbThongbao.BackColor = Color.Red;
            //    frmConfrim _frmconfrim = new frmConfrim(strerror);
            //    _frmconfrim.ShowDialog();
            //}
        }
    }
}
