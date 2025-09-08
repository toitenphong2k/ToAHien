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
    public partial class frm3Part : Form
    {
        StreamWriter writer;
        string today_ = DataConn.chiaca().ToString("yyyy-MM-dd");
        string today = DateTime.Now.ToString("yyyyMMdd");
        string modelcode ="", PCBID_Temp, Optical_Temp, OtherTemp, linename = "";
        int PCBQty, OpticalQty, DMDQty, CountPCBQty, OtherQty, CountOther, CountOptical = 0;
        int scanagain = 0;
        public frm3Part()
        {
            InitializeComponent();
        }
        
        private void txtTempSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            lbThongbao.Text = "";
            //Clear_data();
            if (cbCheckAgain.Checked==true)
            {
                scanagain = 1;
            }
            if (e.KeyChar == 13)
            {
                if (txtTempSerial.Text.Trim() != "" )
                {
                    if (txtTempSerial.Text.Length == 15)
                    {
                        txtOptic.Enabled = true;
                        // Online mode
                        if (cbCheckAgain.Checked == true)
                        {
                            string TempSerial = txtTempSerial.Text;
                            string values = TempSerial.Substring(6, 3);
                            modelcode = values;
                            Load_model(modelcode);
                            txtTempSerial.SelectAll();
                            lbTBID.Text = "Hãy scan cụm Optical số: 1";
                        }
                        else
                        {
                            if (ckOffline.Checked == false)
                            {
                                var dt = DataConn.StoreFillDS("Check_TempSerial", CommandType.StoredProcedure, txtTempSerial.Text);
                                if (dt.Rows.Count > 0)
                                {
                                    var dt1 = DataConn.StoreFillDS("Check_TempSerial_NOT", CommandType.StoredProcedure, txtTempSerial.Text);
                                    if (dt1.Rows.Count > 0)
                                    {
                                        string TempSerial = txtTempSerial.Text;
                                        string values = TempSerial.Substring(6, 3);
                                        modelcode = values;

                                        Load_model(modelcode);
                                        txtOptic.Text = dt1.Rows[0]["OPTICALID"].ToString();
                                        txtPCBID.Text = dt1.Rows[0]["PCBID"].ToString();
                                        txtOther.Text = dt1.Rows[0]["OTHER"].ToString();
                                        lbThongbao.Text = "Hãy tiếp tục scan...";
                                        lbTBID.Text = "";
                                        lbThongbao.ForeColor = Color.White;
                                        lbThongbao.BackColor = Color.Blue;
                                        if (dt1.Rows[0]["OPTICALID"].ToString() == "NOT")
                                        {
                                            txtOptic.Focus();
                                            txtOptic.SelectAll();
                                        }
                                        else if (dt1.Rows[0]["PCBID"].ToString() == "NOT")
                                        {
                                            txtPCBID.Focus();
                                            txtPCBID.SelectAll();
                                        }
                                        else if (dt1.Rows[0]["OTHER"].ToString() == "NOT")
                                        {
                                            txtOther.Focus();
                                            txtOther.SelectAll();
                                        }
                                    }
                                    else
                                    {
                                        if (cbCheckAgain.Checked == true)
                                        {
                                            string TempSerial = txtTempSerial.Text;
                                            string values = TempSerial.Substring(6, 3);
                                            modelcode = values;
                                            Load_model(modelcode);
                                            txtTempSerial.SelectAll();
                                            lbTBID.Text = "Hãy scan cụm Optical số: 1";
                                        }
                                        else
                                        {
                                            lbThongbao.Text = "Serial đã tồn tại và hoàn thành...";
                                            lbTBID.Text = "";
                                            lbThongbao.ForeColor = Color.Yellow;
                                            lbThongbao.BackColor = Color.Red;
                                            txtTempSerial.SelectAll();
                                        }
                                    }
                                }
                                else
                                {
                                    //CaseAddNew:
                                    string TempSerial = txtTempSerial.Text;
                                    string values = TempSerial.Substring(6, 3);
                                    modelcode = values;
                                    Load_model(modelcode);
                                    txtTempSerial.SelectAll();
                                    lbTBID.Text = "Hãy scan cụm Optical số: 1";
                                }
                            }
                            else
                            {
                                // offline mode
                                txtPCBID.Focus();
                                lbTBID.Text = "Hãy scan cụm Optical số: 1";
                            }
                        }
                    }
                    else
                    {
                         
                        lbThongbao.Text = "Serial không đúng định dạng...";
                        lbTBID.Text = "";
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
            }
            
        }
        private void Load_model( string model)
        {
            var dt = DataConn.StoreFillDS("Load_model", CommandType.StoredProcedure, model);
            if (dt.Rows.Count>0)
            {
                PCBQty = int.Parse(dt.Rows[0]["PCB_QTY"].ToString());
                OpticalQty = int.Parse(dt.Rows[0]["OPTICAL_QTY"].ToString());
                //DMDQty = int.Parse(dt.Rows[0]["DMD_QTY"].ToString());
                OtherQty = int.Parse(dt.Rows[0]["OTHER"].ToString());

                txtModelCode.Text= dt.Rows[0]["MODEL_CODE"].ToString();
                txtModelName.Text = dt.Rows[0]["MODEL_NM"].ToString();
                txtPCBQty.Text = dt.Rows[0]["PCB_QTY"].ToString();
                txtOtherQty.Text = dt.Rows[0]["OTHER"].ToString();
                txtOpticalQty.Text = dt.Rows[0]["OPTICAL_QTY"].ToString();
                txtOptic.Focus();
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
            txtOtherQty.Text = "";
            //txtKittingList.Text = "";
            txtOptic.Text = "";
            txtOther.Text = "";

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
                DataConn.ExecuteStore("SaveTraceFA_new1", CommandType.StoredProcedure, linename.ToUpper(),txtKittingList.Text.ToUpper(), modelcode.ToUpper(), txtTempSerial.Text.ToUpper(), txtPCBID.Text.ToUpper(),  txtOptic.Text.ToUpper(), txtOther.Text.ToUpper(), scanagain);
                SaveData_Offline();
                lbThongbao.Text = "Lưu dữ liệu thành công...!";
                lbThongbao.ForeColor = Color.White;
                lbThongbao.BackColor = Color.Blue;
                txtOptic.Enabled = true; 
            }
            
        }
        private void SaveData3()
        {
                DataConn.ExecuteStore("SaveTraceFA_new1", CommandType.StoredProcedure, linename.ToUpper(), txtKittingList.Text.ToUpper(), modelcode.ToUpper(), txtTempSerial.Text.ToUpper(), txtPCBID.Text.ToUpper(), txtOptic.Text.ToUpper(), txtOther.Text.ToUpper(), scanagain);
                SaveData_Offline();
                lbThongbao.Text = "Lưu dữ liệu thành công...!";
                lbThongbao.ForeColor = Color.White;
                lbThongbao.BackColor = Color.Blue;
                txtOptic.Enabled = true;
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
                     writer.WriteLine("LINE_NAME,MODEL_CODE,KITTING_LIST, TEMP_SERIAL,PCBID, OPTICAL, INSERT_DT");
                     writer.Close();
                 }
                 writer = File.AppendText(Directory.GetCurrentDirectory() + @"\DATA\PJ_" + today + ".csv");
                 writer.WriteLine(linename.ToUpper() + ","+ modelcode.ToUpper() + ","+ txtKittingList.Text.ToUpper() + "," +  txtTempSerial.Text.ToUpper() + "," + txtPCBID.Text.ToUpper() + "," + txtOptic.Text.ToUpper() + ","+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss" + ","));
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
                if (CountPCBQty == 0)
                {
                    PCBID_Temp += txtPCBID.Text.ToUpper();
                }
                else
                {
                    PCBID_Temp += ";" + txtPCBID.Text.ToUpper() ;
                }
                //txtPCBID_temp.Text = PCBID_Temp;
                txtPCBID.Text = "";
                txtPCBID.SelectAll();
                txtPCBID.Focus();
            }
            txtOptic.Focus();

        }
        private void Load_Gird()
        {
            //try
            //{
                var dt = DataConn.StoreFillDS("List_serial_scan", CommandType.StoredProcedure, today, linename);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].Width = 125;
                    dataGridView1.Columns[1].Width = 90;
                    dataGridView1.Columns[2].Width = 90;
                    //dataGridView1.Columns[3].Width = 90;
                    //dataGridView1.Columns[4].Width = 70;
                }
            //}
            //catch (Exception)
            //{
            //}
            
        }
        private int PingToServer()
        {
            if (DataConn.PingToAddress("192.168.128.116"))
            //if (DataConn.PingToAddress(subip[0]))
            {
                //lbOffline.Visible = true;
                lbServer.Text = "SERVER CONNECTED";
                lbServer.ForeColor = Color.White;
                lbServer.BackColor = Color.Blue;
                return 1;
                //lbThongbao.Text = "";
            }
            else
            {
                lbServer.Text = "SERVER NOTCONNECT";
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
            var dt = DataConn.StoreFillDS("ProductionQty3Part", CommandType.StoredProcedure, today_, modelcode, linename);
            count_vs = int.Parse(dt.Rows[0][0].ToString());
            //}

            return count_vs;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {

            
            txtKittingList.Text = "KITTING NOT SETTING IN PROCESS";
            txtKittingList.Enabled = false;
            txtTempSerial.Focus();

            lbThongbao.Text = "";
            lbOffline.Visible = false;
            
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
                MessageBox.Show("Không tìm thấy cài đặt tên Line...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (ckOffline.Checked ==true)
            {
                lbOffline.Visible = true;
            }
            Load_Gird();
            lbQtyToday.Text = Count_Total_VS().ToString();
        }

        private void txtKittingList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                if (txtKittingList.Text.Length > 15)
                {
                    txtTempSerial.Focus();
                }
                else
                {
                    lbThongbao.Text = "Hãy scan Kitting list";
                    lbThongbao.ForeColor = Color.Yellow;
                    lbThongbao.BackColor = Color.Red;
                    MessageBox.Show("Hãy scan Kitting list...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtKittingList.SelectAll();
                }
            }
            
        }

        private void txtOther_KeyPress(object sender, KeyPressEventArgs e)
        {
            //btnFinish_Click(sender, e);
            if (e.KeyChar==13)
            {
                if (txtOther.Text == "NOT")
                {
                    btnFinish_Click(sender, e);
                }
                else
                {
                    if (txtOther.Text != "" && txtOther.Text.Length >= 10)
                    {
                        if (CountOther == 0)
                        {
                            OtherTemp += txtOther.Text.ToUpper();
                        }
                        else
                        {
                            OtherTemp += ";" + txtOther.Text.ToUpper();
                        }
                        CountOther += 1;
                        //txtPCBID2.Focus();
                        if (CountOther == OtherQty)
                        {
                            txtOther.Text = "";
                            txtOther.Text = OtherTemp;
                            OtherTemp = "";
                            CountOther = 0;
                            lbTBID.Text = "";
                            btnFinish_Click(sender, e);
                        }
                        else
                        {
                            txtOther.Text = "";
                            txtOther.SelectAll();
                            lbTBID.Text = "Hãy Scan Cụm khác thứ: " + (CountOther + 1);
                            lbThongbao.Text = "";
                        }
                    }
                    else
                    {
                        lbThongbao.Text = "Cụm khác không đúng định dạng...";
                        lbThongbao.ForeColor = Color.Yellow;
                        lbThongbao.BackColor = Color.Red;
                        txtOther.SelectAll();
                    }
                }
            }
            
        }

        private void txtPCBID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                if (txtPCBID.Text == "NOT")
                {
                    txtOther.Focus();
                    if (OtherQty == 0)
                    {
                        txtOther.Text = "NOT SET";
                        btnFinish_Click(sender, e);
                    }
                }
                else
                {
                    if (txtPCBID.Text != "" && txtPCBID.Text.Length >= 10)
                    {
                        if (CountPCBQty == 0)
                        {
                            PCBID_Temp += txtPCBID.Text.ToUpper();
                        }
                        else
                        {
                            PCBID_Temp += ";" + txtPCBID.Text.ToUpper();
                        }
                        CountPCBQty += 1;
                        //txtPCBID2.Focus();
                        if (CountPCBQty == PCBQty)
                        {
                            txtPCBID.Text = "";
                            txtPCBID.Text = PCBID_Temp;
                            PCBID_Temp = "";
                            CountPCBQty = 0;
                            lbTBID.Text = "";
                            txtOther.Focus();
                            //txtOptic.Enabled = true;
                            if (OtherQty == 0)
                            {
                                txtOther.Text = "NOT SET";
                                btnFinish_Click(sender, e);
                            }
                        }
                        else
                        {
                            txtPCBID.Text = "";
                            txtPCBID.SelectAll();
                            lbTBID.Text = "Hãy Scan PCB thứ: " + (CountPCBQty + 1);
                            lbThongbao.Text = "";
                        }
                    }
                    else
                    {
                        lbThongbao.Text = "PCB ID không đúng định dạng...";
                        lbThongbao.ForeColor = Color.Yellow;
                        lbThongbao.BackColor = Color.Red;
                        txtPCBID.SelectAll();
                    }
                }
            }
        }

        private void txtPCBID2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13)
            //{
            //    //ScanPCB();
            //    if (txtPCBID2.Text != "")
            //    {
            //        txtDMD.Focus();
            //    }
            //}
        }

        //private void txtDMD_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 13)
        //    {
        //        //ScanPCB();
        //        if (DMDQty == 0)
        //        {
        //            txtDMD.Text = "NOT";
        //            txtOptic.Focus();
        //        }
        //        else
        //        {
        //            if (txtDMD.Text != "")
        //            {
        //                txtOptic.Focus();
        //                lbTBID.Text = "Hãy scan cụm Optical thứ: 1";
        //            }
        //        }
        //    }
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            PingToServer();
        }

        private void txtOptic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtOptic.Text == "NOT")
                {
                    txtPCBID.Focus();
                }
                else
                {
                    if (txtOptic.Text.Length >= 5)
                    {
                        if (CountOptical == 0)
                        {
                            Optical_Temp += txtOptic.Text.ToUpper();
                        }
                        else
                        {
                            Optical_Temp += ";" + txtOptic.Text.ToUpper();
                        }
                        CountOptical += 1;
                        //txtPCBID2.Focus();
                        if (CountOptical == OpticalQty)
                        {
                            txtOptic.Text = "";
                            txtOptic.Text = Optical_Temp;
                            Optical_Temp = "";
                            CountOptical = 0;
                            lbTBID.Text = "";
                            txtOptic.Enabled = false;
                            lbTBID.Text = "Hãy scan PCB ID thứ: 1";
                            lbThongbao.Text = "";
                            if (txtPCBID.Text == "NOT" || txtPCBID.Text == "")
                            {
                                txtPCBID.Focus();
                            }
                            else
                            {
                            }
                        }
                        else
                        {
                            txtOptic.Text = "";
                            txtOptic.SelectAll();
                            lbTBID.Text = "Hãy Scan cụm Optical thứ: " + (CountOptical + 1);
                            lbThongbao.Text = "";
                        }
                    }
                    else
                    {
                        lbThongbao.Text = "Optical ID không đúng định dạng...";
                        lbThongbao.ForeColor = Color.Yellow;
                        lbThongbao.BackColor = Color.Red;
                        txtOptic.SelectAll();
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
            if (cbCheckAgain.Checked==true)
            {
                scanagain = 1;
            }
            else
            {
                scanagain = 0;
            }
            if (txtTempSerial.Text=="" || txtPCBID.Text =="" || txtOptic.Text == "" || txtKittingList.Text == "" || txtOther.Text =="")
            {
                lbThongbao.Text = "Hãy nhập đầy đủ thông tin";
                lbThongbao.ForeColor = Color.Yellow;
                lbThongbao.BackColor = Color.Red;
                txtTempSerial.SelectAll();
            }
            else
            {
                if (txtTempSerial.Text.Length >= 15)
                {
                    // Online mode
                    if (ckOffline.Checked == false)
                    {
                        
                        var dt = DataConn.StoreFillDS("Check_TempSerial", CommandType.StoredProcedure, txtTempSerial.Text);
                        if (dt.Rows.Count > 0)
                        {
                            var dt1 = DataConn.StoreFillDS("Check_TempSerial_NOT", CommandType.StoredProcedure, txtTempSerial.Text);
                            if (dt1.Rows.Count > 0  )
                            {                              
                                    SaveData3();
                                    SaveData_Offline();
                                    Load_Gird();
                                    Clear_data();
                                    txtTempSerial.Focus();
                            }
                            else
                            {
                                if (scanagain == 1)
                                {
                                    SaveData3();
                                    SaveData_Offline();
                                    Load_Gird();
                                    Clear_data();
                                    txtTempSerial.Focus();
                                }
                                else
                                {
                                    lbThongbao.Text = "Serial đã tồn tại";
                                    lbThongbao.ForeColor = Color.Yellow;
                                    lbThongbao.BackColor = Color.Red;
                                    txtTempSerial.SelectAll();
                                }
                            }
                            
                        }
                        else
                        {
                            //string TempSerial = txtTempSerial.Text;
                            //string[] values = TempSerial.Split(' ');
                            //modelcode = values[1];
                            string TempSerial = txtTempSerial.Text;
                            string values = TempSerial.Substring(6, 3);
                            modelcode = values;

                            Load_model(modelcode);
                            
                            SaveData3();
                            SaveData_Offline();
                            Load_Gird();
                            Clear_data();
                            txtTempSerial.Focus();
                           //txtKittingList.Focus();
                        }
                    }
                    else
                    {
                        // offline mode
                        SaveData_Offline();
                        txtTempSerial.Focus();
                        Clear_data();
                    }
                }
                else
                {
                    lbThongbao.Text = "Serial không đúng định dạng....";
                    lbThongbao.ForeColor = Color.Yellow;
                    lbThongbao.BackColor = Color.Red;
                    MessageBox.Show("Serial không đúng định dạng...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTempSerial.SelectAll();
                }
                
            }
            lbQtyToday.Text =  Count_Total_VS().ToString();
        }
    }
}
