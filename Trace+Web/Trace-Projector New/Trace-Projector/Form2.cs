using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace Trace_Projector
{
    public partial class Form2 : Form
    {
        StreamWriter writer;
        string today_ = DataConn.chiaca().ToString("yyyy-MM-dd");
        string today = DateTime.Now.ToString("yyyyMMdd");
        string modelcode = "", PCBID_Temp, linename = "";
        int PCBQty, OpticalQty, DMDQty = 0;
        public Form2()
        {
            InitializeComponent();
        }
        private int Check_tempory_serial()
        {
            var dt = DataConn.StoreFillDS("Check_TempSerial", CommandType.StoredProcedure, txtTempSerial.Text);
            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        private void txtTempSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtTempSerial.Text.Trim() != "" )
                {
                    if (txtTempSerial.Text.Length >= 17)
                    {

                        if (Check_tempory_serial() == 1 && cbCheckAgain.Checked == false)
                        {
                            lbThongbao.Text = "Serial đã tồn tại";
                            lbThongbao.ForeColor = Color.Yellow;
                            lbThongbao.BackColor = Color.Red;
                            txtTempSerial.SelectAll();
                        }
                        else if (Check_tempory_serial() == 0 && cbCheckAgain.Checked == true)
                        {
                            lbThongbao.Text = "Serial chưa tồn tại và đang chọn Scan lại";
                            lbThongbao.ForeColor = Color.Yellow;
                            lbThongbao.BackColor = Color.Red;
                            txtTempSerial.SelectAll();
                        }
                        else if ((Check_tempory_serial() == 1 && cbCheckAgain.Checked == true) || (Check_tempory_serial() == 0 && cbCheckAgain.Checked == false))
                        {
                            string TempSerial = txtTempSerial.Text;
                            string[] values = TempSerial.Split(' ');
                            modelcode = values[1];
                            //textBox5.Text = modelcode;
                            Load_model(modelcode);
                            txtTempSerial.SelectAll();
                        }
                            //var dt = DataConn.StoreFillDS("Check_TempSerial", CommandType.StoredProcedure, txtTempSerial.Text);
                            //if (dt.Rows.Count > 0)
                            //{
                            //    lbThongbao.Text = "Serial đã tồn tại";
                            //    lbThongbao.ForeColor = Color.Yellow;
                            //    lbThongbao.BackColor = Color.Red;
                            //    txtTempSerial.SelectAll();
                            //}
                            //else
                            //{
                            //    string TempSerial = txtTempSerial.Text;
                            //    string[] values = TempSerial.Split(' ');
                            //    modelcode = values[1];
                            //    //textBox5.Text = modelcode;
                            //    Load_model(modelcode);
                            //    txtTempSerial.SelectAll();
                            //}
                        //}
                        //else
                        //{
                        //    // offline mode
                        //    txtPCBID.Focus();
                        //}


                    }
                    else
                    {
                         
                         MessageBox.Show("Serial không đúng định dạng...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         txtTempSerial.SelectAll();
                     
                    }
                }
                else
                {
                    MessageBox.Show("Hãy Scan Tempory Serial trên bản mạch...", "Thông báo",MessageBoxButtons.OK , MessageBoxIcon.Error);
                }
            }
            
        }
        private void Load_model( string model)
        {
            var dt = DataConn.StoreFillDS("Load_model", CommandType.StoredProcedure, model);
            if (dt.Rows.Count>0)
            {
                PCBQty = int.Parse(dt.Rows[0]["PCB_QTY"].ToString());
                OpticalQty = int.Parse(dt.Rows[0]["OPTICAL_QTY"].ToString());
                DMDQty = int.Parse(dt.Rows[0]["DMD_QTY"].ToString());

                txtModelCode.Text= dt.Rows[0]["MODEL_CODE"].ToString();
                txtModelName.Text = dt.Rows[0]["MODEL_NM"].ToString();
                txtPCBQty.Text = dt.Rows[0]["PCB_QTY"].ToString();
                txtDMDQty.Text = dt.Rows[0]["DMD_QTY"].ToString();
                txtOpticalQty.Text = dt.Rows[0]["OPTICAL_QTY"].ToString();
                txtPCBID.Focus();
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
                Clear_data();
            }
        }
        private void Clear_data()
        {
            txtTempSerial.Text = "";
            txtModelCode.Text = "";
            txtModelName.Text = "";
            txtOpticalQty.Text = "";
            txtPCBID.Text = "";
            txtPCBQty.Text = "";
            txtDMDQty.Text = "";
            txtPCBID2.Text = "";
            txtOptic.Text = "";
            txtDMD.Text = "";

        }
        private void SaveData()
        {
            var dt = DataConn.StoreFillDS("Check_TempSerial", CommandType.StoredProcedure, txtTempSerial.Text);
            if (dt.Rows.Count>0)
            {
                lbThongbao.Text = "Serial đã tồn tại";
                lbThongbao.ForeColor = Color.Yellow;
                lbThongbao.BackColor = Color.Red;
            }
            else
            {
                DataConn.ExecuteStore("SaveTraceFA", CommandType.StoredProcedure, linename.ToUpper(), modelcode.ToUpper(), txtTempSerial.Text.ToUpper(), txtPCBID.Text.ToUpper(), txtPCBID2.Text.ToUpper(), txtOptic.Text.ToUpper(), txtDMD.Text.ToUpper(), "");
                SaveData_Offline();
                lbThongbao.Text = "Lưu dữ liệu thành công...!";
                lbThongbao.ForeColor = Color.White;
                lbThongbao.BackColor = Color.Blue;
            }
            
        }
        private void SaveData_Offline()
        {
            // kiem tra serial da ton tai trong file hay chua
            //var dt = DataConn.StoreFillDS("Check_TempSerial", CommandType.StoredProcedure, txtTempSerial.Text);
            // if (dt.Rows.Count > 0)
            // {
            //     lbThongbao.Text = "Serial đã tồn tại";
            //     lbThongbao.ForeColor = Color.Yellow;
            //     lbThongbao.BackColor = Color.Red;
            // }
            // else
            // {
                 if (File.Exists(Directory.GetCurrentDirectory() + @"\DATA\PJ_" + today + ".csv") == false)
                 {
                     writer = File.CreateText(Directory.GetCurrentDirectory() + @"\DATA\PJ_" + today + ".csv");
                     writer.WriteLine("LINE_NAME,MODEL_CODE,TEMP_SERIAL,PCBID, PCBID2, OPTICAL, DMD, INSERT_DT");
                     writer.Close();
                 }
                 writer = File.AppendText(Directory.GetCurrentDirectory() + @"\DATA\PJ_" + today + ".csv");
                 writer.WriteLine(linename.ToUpper() + ","+ modelcode.ToUpper() + ","+ txtTempSerial.Text.ToUpper() + "," + txtPCBID.Text.ToUpper() + ","+ txtPCBID2.Text.ToUpper() + "," + txtOptic.Text.ToUpper() + "," + txtDMD.Text.ToUpper() + ","+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss" + ","));
                 writer.Close();
                 lbThongbao.Text = "Lưu dữ liệu thành công...!";
                 lbThongbao.ForeColor = Color.White;
                 lbThongbao.BackColor = Color.Blue;
             //}
        }
        private void ScanPCB()
        {
            //lbThongbao.Text = "Hãy scan lần";
            for (int i = 1; i <= PCBQty; i++)
            {
                PCBID_Temp += txtPCBID.Text.ToUpper() + ";";
                //txtPCBID_temp.Text = PCBID_Temp;
                txtPCBID.Text = "";
                txtPCBID.SelectAll();
                txtPCBID.Focus();
            }
            txtOptic.Focus();

        }
        private void Load_Gird()
        {
            try
            {
                var dt = DataConn.StoreFillDS("List_serial_scan", CommandType.StoredProcedure, today);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].Width = 110;
                    dataGridView1.Columns[1].Width = 70;
                    dataGridView1.Columns[2].Width = 70;
                    dataGridView1.Columns[3].Width = 70;
                    dataGridView1.Columns[4].Width = 70;
                }
            }
            catch (Exception)
            {
            }
            
        }
        private int PingToServer()
        {
            if (DataConn.PingToAddress("192.168.128.116"))
            //if (DataConn.PingToAddress(subip[0]))
            {
                //lbOffline.Visible = true;
                lbServer.Text = "CONNECTED";
                lbServer.ForeColor = Color.Blue;
                lbServer.BackColor = Color.White;
                return 1;
                //lbThongbao.Text = "";
            }
            else
            {
                lbServer.Text = "NOT CONNECT";
                lbServer.ForeColor = Color.Yellow;
                lbServer.BackColor = Color.Red;
                return 0;
                //await Task.Delay(500);
                //label1.BackColor = label1.BackColor == Color.Red ? Color.Green : Color.Red;

            }
        }
        private int Count_Total_VS()
        {
            int count_vs = 0;
            //if (modelcode != "" && modelcode != null)
            //{
            var dt = DataConn.StoreFillDS("ProductionQty2Part", CommandType.StoredProcedure, today_, modelcode, linename);
            count_vs = int.Parse(dt.Rows[0][0].ToString());
            //}

            return count_vs;
            lbQtyToday.Text = count_vs.ToString();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            Count_Total_VS();
            lbThongbao.Text = "";
            lbOffline.Visible = false;
            Load_Gird();
            if (PingToServer() == 0)
            {
                lbThongbao.Text = "KHÔNG CÓ KẾT NỐI ĐẾN SERVER.\n HÃY CHỌN CHẾ ĐỘ OFFLINE!";
                lbThongbao.ForeColor = Color.Yellow;
                lbThongbao.BackColor = Color.Red;
            }
            //PingToServer();
            //check line infor
            if (File.Exists(Directory.GetCurrentDirectory() + @"\LineAD.ini") == true)
            {
                using (StreamReader rd = new StreamReader(Directory.GetCurrentDirectory() + @"\LineAD.ini"))
                {
                    linename = rd.ReadLine();
                    lbLine.Text = linename;
                }
            }
            else
            {
                lbThongbao.Text = "Không tìm thấy cài đặt tên Line";
                lbThongbao.ForeColor = Color.Yellow;
                lbThongbao.BackColor = Color.Red;
            }
            if (ckOffline.Checked ==true)
            {
                lbOffline.Visible = true;
            }
        }

        private void txtPCBID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                //ScanPCB();
                if (txtPCBID.Text != "")
                {
                    txtPCBID2.Focus();
                }
            }
        }

        private void txtPCBID2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //ScanPCB();
                if (txtPCBID2.Text != "")
                {
                    txtDMD.Focus();
                }
            }
        }

        private void txtDMD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //ScanPCB();
                if (txtDMD.Text != "")
                {
                    txtOptic.Focus();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PingToServer();
        }

        private void txtOptic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //ScanPCB();
                if (txtDMD.Text != "")
                {
                    if (ckOffline.Checked ==true)
                    {
                        //SaveData();
                        SaveData_Offline();
                        //Load_Gird();
                        Clear_data();
                        txtTempSerial.Focus();
                    }
                    else
                    {
                        SaveData();
                        SaveData_Offline();
                        Load_Gird();
                        Clear_data();
                        txtTempSerial.Focus();
                    }
                   
                }
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckOffline_CheckedChanged(object sender, EventArgs e)
        {
            if (ckOffline.Checked == true)
            {
                lbOffline.Visible = true;
                lbOnline.Visible = false;
                modelcode = "N";
                //lbOffline.Text = "OFFLINE MODE";
                //lbOffline.ForeColor = Color.Yellow;
                //lbOffline.BackColor = Color.Red;
            }
            else
            {
                lbOnline.Visible = true;
                lbOffline.Visible = false;
                //lbOffline.Text = "ONLINE MODE";
                //lbOffline.ForeColor = Color.Blue;
                //lbOffline.BackColor = Color.White;
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (txtTempSerial.Text=="" || txtPCBID.Text =="" || txtPCBID2.Text == "")
            {
                lbThongbao.Text = "Hãy nhập đầy đủ thông tin";
                lbThongbao.ForeColor = Color.Yellow;
                lbThongbao.BackColor = Color.Red;
                
            }
            else
            {
                SaveData();
                SaveData_Offline();
                Load_Gird();
                Clear_data();
                txtTempSerial.Focus();
            }
        }
    }
}
