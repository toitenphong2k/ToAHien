using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Trace_Projector
{
    public partial class frmAdjust : Form
    {
        StreamWriter writer;
        string today_ = DataConn.chiaca().ToString("yyyy-MM-dd");
        string today = DateTime.Now.ToString("yyyyMMdd");
        string modelcode = "", PCBID_Temp, Optical_Temp, linename = "";
        int PCBQty, OpticalQty, DMDQty, CountPCBQty, CountOptical = 0;
        bool checklabel = false;
        bool checkagain = false;
        private int Count_Total_VS()
        {
            int count_vs = 0;
            //if (modelcode != "" && modelcode != null)
            //{
            var dt = DataConn.StoreFillDS("ProductionQtyAs4", CommandType.StoredProcedure, today_, modelcode, linename);
            count_vs = int.Parse(dt.Rows[0][0].ToString());
            //}
            lbQtyToday.Text = count_vs.ToString();
            return count_vs;
        }

        private void txtSerialNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            lbThongbao.Text = "";
            if (e.KeyChar == 13)
            {
                if (txtSerialNo.Text.Trim() != "")
                {

                    if (txtSerialNo.Text.Trim().Length >= 4)
                    {
                        if (txtSerialNo.Text.Trim().Length == 9)
                        {
                            string lastFourCharsSerialNo = txtSerialNo.Text.Trim().Substring(txtSerialNo.Text.Trim().Length - 4);
                            string lastFourCharsTemp = txtTempSerial.Text.Trim().Substring(txtTempSerial.Text.Trim().Length - 4);
                            if (lastFourCharsSerialNo == lastFourCharsTemp)
                            {
                                if (checklabel == true)
                                {
                                    txtNameLabel.Enabled = true;
                                    txtNameLabel.Focus();
                                    txtNameLabel.SelectAll();
                                }
                                else
                                {
                                    SaveData();
                                    SaveData_Offline();
                                    Load_Gird();
                                    txtTempSerial.Focus();
                                    txtTempSerial.SelectAll();
                                    txtSerialNo.Text = "";
                                    txtNameLabel.Text = "";
                                    txtCautionLabel.Text = "";
                                }
                            }
                            else
                            {
                                lbThongbao.Text = "SerialNo không khớp với TempSerial ...";
                                lbThongbao.ForeColor = Color.Yellow;
                                lbThongbao.BackColor = Color.Red;
                                MessageBox.Show("SerialNo không khớp với TempSerial ...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //txtSerialNo.Text = "";
                                txtSerialNo.Focus();
                                txtSerialNo.SelectAll();
                            }

                        }
                        else
                        {

                            lbThongbao.Text = "Serial No không đúng định dạng....";
                            lbThongbao.ForeColor = Color.Yellow;
                            lbThongbao.BackColor = Color.Red;
                            MessageBox.Show("Serial No không đúng định dạng....", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtSerialNo.Focus();
                            txtSerialNo.SelectAll();
                        }
                        //Console.WriteLine("4 ký tự cuối cùng là: " + lastFourChars);
                    }
                    else
                    {
                        lbThongbao.Text = "Chuỗi quá ngắn, không đủ 4 ký tự....";
                        lbThongbao.ForeColor = Color.Yellow;
                        lbThongbao.BackColor = Color.Red;
                        MessageBox.Show("Chuỗi quá ngắn, không đủ 4 ký tự....", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSerialNo.Focus();
                        txtSerialNo.SelectAll();

                    }

                }
                else
                {
                    lbThongbao.Text = "Hãy Scan Serial No...";
                    lbThongbao.ForeColor = Color.Yellow;
                    lbThongbao.BackColor = Color.Red;
                    MessageBox.Show("Hãy Scan Serial No...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSerialNo.Focus();
                    txtSerialNo.SelectAll();
                }
            }
        }

        private void txtNameLabel_KeyPress(object sender, KeyPressEventArgs e)
        {
            lbThongbao.Text = "";
            if (e.KeyChar == 13)
            {
                if (txtNameLabel.Text.Trim() != "")
                {

                    var dtlabel = DataConn.DataTable_Sql("SELECT * FROM [PROJECTOR_TRACE].[dbo].[TBL_CHECK_LABEL_MASTER] where MODELCODE='" + txtModelCode.Text + "' and STEPINSCREEN=1");
                    if (dtlabel.Rows.Count > 0)
                    {
                        if (txtNameLabel.Text.Trim() == dtlabel.Rows[0]["PARTNO"].ToString())
                        {
                            txtCautionLabel.Enabled = true;
                            txtCautionLabel.Focus();
                            txtCautionLabel.SelectAll();
                        }
                        else
                        {
                            lbThongbao.Text = "Thông tin scan không khớp với master...";
                            lbThongbao.ForeColor = Color.Yellow;
                            lbThongbao.BackColor = Color.Red;
                            MessageBox.Show("Thông tin scan không khớp với master...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtNameLabel.Focus();
                            txtNameLabel.SelectAll();
                        }
                    }
                    else
                    {
                        lbThongbao.Text = "Master Name Label không tồn tại...";
                        lbThongbao.ForeColor = Color.Yellow;
                        lbThongbao.BackColor = Color.Red;
                        MessageBox.Show("Master Name Label không tồn tại...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNameLabel.Focus();
                        txtNameLabel.SelectAll();
                    }

                }
                else
                {
                    lbThongbao.Text = "Hãy Scan Name Label...";
                    lbThongbao.ForeColor = Color.Yellow;
                    lbThongbao.BackColor = Color.Red;
                    MessageBox.Show("Hãy Scan Name Label...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNameLabel.Focus();
                    txtNameLabel.SelectAll();
                }
            }
        }

        private void txtCautionLabel_KeyPress(object sender, KeyPressEventArgs e)
        {
            lbThongbao.Text = "";
            if (e.KeyChar == 13)
            {
                if (txtCautionLabel.Text.Trim() != "")
                {

                    var dtlabel = DataConn.DataTable_Sql("SELECT * FROM [PROJECTOR_TRACE].[dbo].[TBL_CHECK_LABEL_MASTER] where MODELCODE='" + txtModelCode.Text + "' and STEPINSCREEN=2");
                    if (dtlabel.Rows.Count > 0)
                    {
                        if (txtCautionLabel.Text.Trim() == dtlabel.Rows[0]["PARTNO"].ToString())
                        {
                            SaveData1();
                            SaveData_Offline();
                            Load_Gird();
                            txtTempSerial.Focus();
                            txtTempSerial.SelectAll();
                            txtSerialNo.Text = "";
                            txtNameLabel.Text = "";
                            txtCautionLabel.Text = "";
                        }
                        else
                        {
                            lbThongbao.Text = "Thông tin scan không khớp với master...";
                            lbThongbao.ForeColor = Color.Yellow;
                            lbThongbao.BackColor = Color.Red;
                            MessageBox.Show("Thông tin scan không khớp với master...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtCautionLabel.Focus();
                            txtCautionLabel.SelectAll();
                        }
                    }
                    else
                    {
                        lbThongbao.Text = "Master Name Label không tồn tại...";
                        lbThongbao.ForeColor = Color.Yellow;
                        lbThongbao.BackColor = Color.Red;
                        MessageBox.Show("Master Name Label không tồn tại...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCautionLabel.Focus();
                        txtCautionLabel.SelectAll();
                    }


                }
                else
                {
                    lbThongbao.Text = "Hãy Scan Caution Label...";
                    lbThongbao.ForeColor = Color.Yellow;
                    lbThongbao.BackColor = Color.Red;
                    MessageBox.Show("Hãy Scan Caution Label...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCautionLabel.Focus();
                    txtCautionLabel.SelectAll();
                }
            }
        }

        private void frmAdjust_Load(object sender, EventArgs e)
        {
            Count_Total_VS();
            lbThongbao.Text = "";
            txtSerialNo.Enabled = false;
            txtNameLabel.Enabled = false;
            txtCautionLabel.Enabled = false;
            Load_Gird();
        }

        private void cbCheckAgain_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCheckAgain.Checked == true)
            {
                checkagain = true;
            }
            else
            {
                checkagain = false;
            }

        }

        public frmAdjust()
        {
            InitializeComponent();
        }
        private void Load_model(string model)
        {
            var dt = DataConn.StoreFillDS("Load_model", CommandType.StoredProcedure, model);
            if (dt.Rows.Count > 0)
            {
                PCBQty = int.Parse(dt.Rows[0]["PCB_QTY"].ToString());
                OpticalQty = int.Parse(dt.Rows[0]["OPTICAL_QTY"].ToString());
                DMDQty = int.Parse(dt.Rows[0]["DMD_QTY"].ToString());


                txtModelCode.Text = dt.Rows[0]["MODEL_CODE"].ToString();

                //check mode have to check label

                var dtlabel = DataConn.DataTable_Sql("SELECT * FROM [PROJECTOR_TRACE].[dbo].[TBL_CHECK_LABEL_MASTER] where MODELCODE='" + txtModelCode.Text + "'");
                if (dtlabel.Rows.Count > 0)
                {
                    checklabel = true;
                    //txtNameLabel.Enabled = true;
                    //txtCautionLabel.Enabled = true;
                }
                else
                {
                    checklabel = false;
                    txtNameLabel.Enabled = false;
                    txtCautionLabel.Enabled = false;
                }
                //
                txtModelName.Text = dt.Rows[0]["MODEL_NM"].ToString();
                txtPCBQty.Text = dt.Rows[0]["PCB_QTY"].ToString();
                txtDMDQty.Text = dt.Rows[0]["DMD_QTY"].ToString();
                txtOpticalQty.Text = dt.Rows[0]["OPTICAL_QTY"].ToString();
                // Kiem tra Scan PCB bao nhieu lan
                //ScanPCB();
                lbThongbao.Text = "";
                //MessageBox.Show(Directory.GetCurrentDirectory() + @"\DATA\PJ_" + today + ".csv");
            }
            else
            {
                lbThongbao.Text = "Không tìm thấy model, Hãy kiểm tra lại...";
                lbThongbao.ForeColor = Color.Yellow;
                lbThongbao.BackColor = Color.Red;
            }
        }
        private void Load_Gird()
        {
            var dt = DataConn.StoreFillDS("List_serial_scan_AJ", CommandType.StoredProcedure, today);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 140;
                dataGridView1.Columns[1].Width = 230;
                dataGridView1.Columns[2].Width = 230;
                //dataGridView1.Columns[3].Width = 170;
                //dataGridView1.Columns[4].Width = 70;
            }
        }
        private void SaveData()
        {
            var dt = DataConn.StoreFillDS("Check_TempSerial_Adjust", CommandType.StoredProcedure, txtTempSerial.Text);



            //if (dt.Rows.Count > 0)
            //{
            //    lbThongbao.Text = "Serial đã tồn tại";
            //    lbThongbao.ForeColor = Color.Yellow;
            //    lbThongbao.BackColor = Color.Red;
            //}
            //else
            //{
            DataConn.ExecuteStore("SaveTraceFA_Adjust", CommandType.StoredProcedure, txtTempSerial.Text.ToUpper(),txtSerialNo.Text.Trim());
            //SaveData_Offline();
            lbThongbao.Text = "Lưu dữ liệu thành công...!";
            lbThongbao.ForeColor = Color.White;
            lbThongbao.BackColor = Color.Blue;
            txtSerialNo.Enabled = false;
            txtNameLabel.Enabled = false;
            txtCautionLabel.Enabled = false;
            //}

        }
        private void SaveData1()
        {
            var dt = DataConn.StoreFillDS("Check_TempSerial_Adjust", CommandType.StoredProcedure, txtTempSerial.Text);



            //if (dt.Rows.Count > 0)
            //{
            //    lbThongbao.Text = "Serial đã tồn tại";
            //    lbThongbao.ForeColor = Color.Yellow;
            //    lbThongbao.BackColor = Color.Red;
            //}
            //else
            //{
            DataConn.ExecuteStore("SaveTraceFA_Adjust_New", CommandType.StoredProcedure, txtTempSerial.Text.ToUpper(), txtSerialNo.Text.Trim(), txtNameLabel.Text.Trim(), txtCautionLabel.Text.Trim());
            //SaveData_Offline();
            lbThongbao.Text = "Lưu dữ liệu thành công...!";
            lbThongbao.ForeColor = Color.White;
            lbThongbao.BackColor = Color.Blue;
            txtSerialNo.Enabled = false;
            txtNameLabel.Enabled = false;
            txtCautionLabel.Enabled = false;
            //}

        }
        private void SaveData_Offline()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + @"\DATA\PJAJ_" + today + ".csv") == false)
            {
                writer = File.CreateText(Directory.GetCurrentDirectory() + @"\DATA\PJAJ_" + today + ".csv");
                writer.WriteLine("TEMP_SERIAL,INSERT_DT");
                writer.Close();
            }
            writer = File.AppendText(Directory.GetCurrentDirectory() + @"\DATA\PJAJ_" + today + ".csv");
            writer.WriteLine(txtTempSerial.Text.ToUpper() + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss" + ","));
            writer.Close();
            lbThongbao.Text = "Lưu dữ liệu thành công...!";
            lbThongbao.ForeColor = Color.White;
            lbThongbao.BackColor = Color.Blue;
            //}
        }
        private void txtTempSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            lbThongbao.Text = "";
            if (e.KeyChar == 13)
            {
                if (txtTempSerial.Text.Trim() != "")
                {
                    if (txtTempSerial.Text.Length == 15)
                    {
                        // Online mode                     
                        var dt = DataConn.StoreFillDS("Check_TempSerial_Adjust", CommandType.StoredProcedure, txtTempSerial.Text);


                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            if (checkagain == true)
                            {

                                // ver 1.1
                                //string TempSerial = txtTempSerial.Text;
                                //string[] values = TempSerial.Split(' ');
                                //modelcode = values[1];
                                //textBox5.Text = modelcode;
                                //ver 1.2
                                string TempSerial = txtTempSerial.Text;
                                string values = TempSerial.Substring(6, 3);
                                modelcode = values;
                                Load_model(modelcode);
                                var dt1 = DataConn.StoreFillDS("Check_Assy", CommandType.StoredProcedure, txtTempSerial.Text);
                                if (dt1.Rows.Count > 0)
                                {
                                    txtSerialNo.Enabled = true;
                                    txtSerialNo.Focus();
                                    txtSerialNo.SelectAll();
                                }
                                else
                                {
                                    lbThongbao.Text = "Không tìm thấy Serial tại công đoạn lắp ráp...";
                                    lbThongbao.ForeColor = Color.Yellow;
                                    lbThongbao.BackColor = Color.Red;
                                    txtTempSerial.SelectAll();
                                }
                            }
                            else
                            {
                                lbThongbao.Text = "Serial đã tồn tại";
                                lbThongbao.ForeColor = Color.Yellow;
                                lbThongbao.BackColor = Color.Red;
                                txtTempSerial.SelectAll();
                                txtSerialNo.Enabled = false;
                                txtNameLabel.Enabled = false;
                                txtCautionLabel.Enabled = false;
                            }
                        }
                        //else if (dt.Rows[0][0].ToString() == "2")
                        //{
                        //    DataConn.ExecuteStore("SaveTraceFA_Adjust", CommandType.StoredProcedure, txtTempSerial.Text.ToUpper());
                        //    //SaveData_Offline();
                        //    lbThongbao.Text = "Lưu dữ liệu thành công...!";
                        //    lbThongbao.ForeColor = Color.White;
                        //    lbThongbao.BackColor = Color.Blue;
                        //}
                        else if (dt.Rows[0][0].ToString() == "0")
                        {
                            lbThongbao.Text = "Hãy kiểm tra lại Optical, PCBID, LENID ...";
                            lbThongbao.ForeColor = Color.Yellow;
                            lbThongbao.BackColor = Color.Red;
                        }



                        else
                        {
                            // ver 1.1
                            //string TempSerial = txtTempSerial.Text;
                            //string[] values = TempSerial.Split(' ');
                            //modelcode = values[1];
                            //textBox5.Text = modelcode;
                            //ver 1.2
                            string TempSerial = txtTempSerial.Text;
                            string values = TempSerial.Substring(6, 3);
                            modelcode = values;
                            Load_model(modelcode);
                            var dt1 = DataConn.StoreFillDS("Check_Assy", CommandType.StoredProcedure, txtTempSerial.Text);
                            if (dt1.Rows.Count > 0)
                            {
                                txtSerialNo.Enabled = true;
                                txtSerialNo.Focus();
                                txtSerialNo.SelectAll();
                            }
                            else
                            {
                                lbThongbao.Text = "Không tìm thấy Serial tại công đoạn lắp ráp...";
                                lbThongbao.ForeColor = Color.Yellow;
                                lbThongbao.BackColor = Color.Red;
                                txtTempSerial.SelectAll();
                            }
                        }

                    }
                    else
                    {

                        lbThongbao.Text = "Serial không đúng định dạng...";
                        lbThongbao.ForeColor = Color.Yellow;
                        lbThongbao.BackColor = Color.Red;
                        txtTempSerial.SelectAll();
                        MessageBox.Show("Serial không đúng định dạng...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    lbThongbao.Text = "Hãy Scan Tempory Serial trên bản mạch...";
                    lbThongbao.ForeColor = Color.Yellow;
                    lbThongbao.BackColor = Color.Red;
                    MessageBox.Show("Hãy Scan Tempory Serial trên bản mạch...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Count_Total_VS();
            }
        }
    }
}
