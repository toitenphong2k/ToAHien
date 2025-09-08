﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
namespace Trace_Projector
{
    public partial class frmaccessory : Form
    {
        StreamWriter writer;
        string modelcode = "", strAccessories_list = "", _status = "OK";
        int scanagain = 0, BaudRate;
        int check_OK = 0;
        string today_ = DataConn.chiaca().ToString("yyyy-MM-dd");
        string linename = "", modelname = "";
        string strerror = "";
        DataTable dtActual = new DataTable();
        DataTable dtStd;
        int AccessQty = 0;
        int AccessQtyActual = 0;
        int CountAccess = 0;
        string ComNo;
        double STDup = 0, STDdw = 0, STD=0;
        public frmaccessory()
        {
            InitializeComponent();
        }
        private void load_data()
        {
                var dt = DataConn.StoreFillDS("List_serial_accessories", CommandType.StoredProcedure, linename, today_, "1");
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].Width = 125;
                    dataGridView1.Columns[1].Width = 90;
                    dataGridView1.Columns[2].Width = 90;
                    dataGridView1.Columns[3].Width = 90;
                    //dataGridView1.Columns[4].Width = 70;
                }
        }
        private int Count_Total_VS()
        {
            int count_vs = 0;
            //if (modelcode != "" && modelcode != null)
            //{
            var dt = DataConn.StoreFillDS("ProductionQtyACC", CommandType.StoredProcedure, today_, linename, "1");
            count_vs = int.Parse(dt.Rows[0][0].ToString());
            //}
            return count_vs;
        }
        private void Load_model(string model)
        {          
            //var dt1 = DataConn.StoreFillDS("Check_WeightPart1", CommandType.StoredProcedure, model );
            var dt1 = DataConn.StoreFillDS("Check_WeightPart2", CommandType.StoredProcedure, model);
            //var dt1 = DataConn.StoreFillDS("Check_WeightPart", CommandType.StoredProcedure, model);
            if (dt1.Rows.Count>0)
            {
                Gridstd.DataSource = dt1;
                txtModelCode.Text = dt1.Rows[0]["MODEL_CODE"].ToString();
                txtModelName.Text = dt1.Rows[0]["MODEL_NAME"].ToString();
                lbThongbao.Text = "";

                txtaccessQty.Text = dt1.Rows.Count.ToString();
                Gridstd.Columns[0].Width = 30;
                Gridstd.Columns[1].Width = 280;
                dtStd = dt1;
                AccessQty = dt1.Rows.Count;
                txtItemCode.Focus();
            }
            else
            {
                Gridstd.DataSource = "";
                txtModelCodeScan.SelectAll();
                lbThongbao.Text = "Model chưa được cài đặt phụ kiện!";
                lbThongbao.ForeColor = Color.Yellow;
                lbThongbao.BackColor = Color.Red;
            }
        }
        private void SaveData()
        {
            // Save File
            if (File.Exists(Directory.GetCurrentDirectory() + @"\DATA\AC_" + today_ + ".csv") == false)
            {
                writer = File.CreateText(Directory.GetCurrentDirectory() + @"\DATA\AC_" + today_ + ".csv");
                writer.WriteLine("TEMP_SERIAL,MODEL_CODE, MODEL_NAME, LINE_NAME, ACCESSORIES_LIST, INSERT_DT");
                writer.Close();
            }
            writer = File.AppendText(Directory.GetCurrentDirectory() + @"\DATA\AC_" + today_ + ".csv");
            writer.WriteLine(txtModelCodeScan.Text.ToUpper() + "," + modelcode + "," + txtModelName.Text + "," + linename + ","  +strAccessories_list+ "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss" + ","));
            writer.Close();
            // Save SQL
            DataConn.ExecuteStore("Save_Accessories", CommandType.StoredProcedure, linename, txtModelCodeScan.Text.ToUpper(), txtModelCode.Text.ToUpper(), txtModelName.Text.ToUpper(), strAccessories_list, scanagain);
            // Thong bao
            lbThongbao.Text = "Lưu dữ liệu thành công...!";
            lbThongbao.ForeColor = Color.White;
            lbThongbao.BackColor = Color.Blue;
            Clear_data();
            lbQtyToday.Text = Count_Total_VS().ToString();
            load_data();

        }
        private int PingToServer()
        {
            if (DataConn.PingToAddress("192.168.128.116"))
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
            }
        }
        private int Check_Exits_Temp()
        {
            var dt = DataConn.StoreFillDS("Check_TempSerial_ACC", CommandType.StoredProcedure, txtModelCodeScan.Text);
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
            
        }
        private void Clear_data()
        {
            txtItemCode.Text = "";
            txtItemCode.Enabled = true;
            txtItemCode.Focus();
            dtActual = new DataTable();
            GridActual.DataSource = "";
        }
        private void frmaccessory_Load(object sender, EventArgs e)
        {
            txtModelCodeScan.Focus();
            button1.Visible = false;
            lbThongbao.Text = "";
            //inif.Write("Human", "Namsinh", "1990");
            //string s = inif.Read("Human", "Ten") + '_' + inif.Read("Human", "Tuoi");
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
                strerror = "Không tìm thấy Cài đặt tên Line...";
                lbThongbao.Text = strerror;
                lbThongbao.ForeColor = Color.Yellow;
                lbThongbao.BackColor = Color.Red;
                txtModelCodeScan.SelectAll();
                frmConfrim _frmconfrim = new frmConfrim(strerror);
                _frmconfrim.ShowDialog();
            }
            // Check Model setting
            if (File.Exists(Directory.GetCurrentDirectory() + @"\ModelACC.ini") == true)
            {
                using (StreamReader rd = new StreamReader(Directory.GetCurrentDirectory() + @"\ModelACC.ini"))
                {
                    string aa = rd.ReadLine();
                    string[] _values = aa.Trim().Split(',');
                    modelname = _values[0];
                    modelcode = _values[1];
                    txtModelCodeScan.Text = modelname;
                    GridActual.DataSource = "";
                    Gridstd.DataSource = "";
                    dtActual = null;
                    CountAccess = 0;
                    txtItemCode.Text = "";
                    Load_model(modelcode);
                }
            }
            else
            {
                CallMessage("Không tìm thấy file Cài đặt Model");              
            }

            lbQtyToday.Text = Count_Total_VS().ToString();
            load_data();
        }
        private void Save_Temp_Table()
        {
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            PingToServer();
        }

        private void txtModelCodeScan_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13)
            //{
            //    if (txtModelCodeScan.Text.Length >= 10)
            //    {
            //        GridActual.DataSource = "";
            //        Gridstd.DataSource = "";
            //        dtActual = null;
            //        CountAccess = 0;
            //        txtItemCode.Text = "";
            //        var dt = DataConn.DataTable_Sql("SELECT TOP(1) MODEL_CODE FROM TBL_MODEL WHERE MODEL_NM = '" + txtModelCodeScan.Text.Trim()+"'");
            //        if (dt.Rows.Count>0)
            //        {
            //            modelcode = dt.Rows[0][0].ToString();
            //        }
            //        Load_model(modelcode);                 
            //    }
            //    else
            //    {
            //        strerror = "Serial không đúng định dạng...";
            //        lbThongbao.Text = strerror;
            //        lbThongbao.ForeColor = Color.Yellow;
            //        lbThongbao.BackColor = Color.Red;
            //        txtModelCodeScan.SelectAll();
            //        check_OK = 0;
            //        frmConfrim _frmconfrim = new frmConfrim(strerror);
            //        _frmconfrim.ShowDialog();
            //    }
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Save_button();
            //txtModelCodeScan.Focus();
        }

        private void btModelSetting_Click(object sender, EventArgs e)
        {

        }

        private void color_Gid()
        {
            foreach (DataGridViewRow row in GridActual.Rows)
            {
                try
                {
                    if (row.Cells[2].Value.ToString() == "Y")
                    {
                        row.DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                    }
                }
                catch (Exception)
                {
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //serialPort1.ReadExisting();
        }
        private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                if (txtItemCode.Text.Trim().Length >5)
                {
                    if (txtItemCode.Text.Trim().Length > 30)
                    {
                        string[] arr = txtItemCode.Text.Split(';');
                        string kk = arr[1];
                        txtItemCode.Text = kk;
                    }
                    if (CountAccess == 0)
                    {
                        
                        if (dtStd.Rows[CountAccess][1].ToString() == txtItemCode.Text || int.Parse(dtStd.Rows[CountAccess][0].ToString()) == CountAccess)
                        {
                            dtActual = new DataTable();
                            dtActual.Columns.Add("No");
                            dtActual.Columns.Add("ItemCode");
                            dtActual.Columns.Add("Flag");
                            DataRow dr = dtActual.NewRow();
                            dr[0] = CountAccess +1;
                            dr[1] = txtItemCode.Text.ToString();
                            dr[2] = "Y";
                            dtActual.Rows.Add(dr);
                            CountAccess += 1;
                            strAccessories_list += txtItemCode.Text.ToString().ToUpper();
                            txtItemCode.SelectAll();
                            color_Gid();
                        }
                        else
                        {
                            strerror = "Sai thứ tự tài liệu...";
                            lbThongbao.Text = strerror;
                            lbThongbao.ForeColor = Color.Yellow;
                            lbThongbao.BackColor = Color.Red;
                            txtItemCode.SelectAll();
                            check_OK = 0;
                            frmConfrim _frmconfrim = new frmConfrim(strerror);
                            _frmconfrim.ShowDialog();
                        }
                    }
                    else
                    {
                        if (dtStd.Rows[CountAccess][1].ToString() == txtItemCode.Text || int.Parse(dtStd.Rows[CountAccess][0].ToString()) == CountAccess)
                        {
                            DataRow dr = dtActual.NewRow();
                            dr[0] = CountAccess + 1;
                            dr[1] = txtItemCode.Text.ToString();
                            dr[2] = "Y";
                            dtActual.Rows.Add(dr);
                            CountAccess += 1;
                            strAccessories_list += ";"+ txtItemCode.Text.ToString().ToUpper();
                            txtItemCode.SelectAll();
                            color_Gid();
                        }
                        else
                        {
                           CallMessage("Sai thứ tự tài liệu...");
                        }
                    }
                    if (CountAccess == AccessQty)
                    {
                        lbThongbao.Text = "Đã đủ tài liệu, phụ kiện...";
                        lbThongbao.ForeColor = Color.Yellow;
                        lbThongbao.BackColor = Color.Red;
                        txtModelCodeScan.SelectAll();
                        CountAccess = 0;
                        txtItemCode.Enabled = false;
                        //txtConfirm.Focus();
                        check_OK = 1;
                        SaveData();
                    }
                    try
                    {
                        GridActual.DataSource = dtActual;
                        GridActual.Columns[0].Width = 50;
                        GridActual.Columns[1].Width = 250;
                        //GridActual.Columns[2].Visible = false;
                    }
                    catch (Exception ex)
                    {
                        //throw;
                    }
                }
            }
        }
        private void CallMessage(string err)
        {          
            strerror = err;
            lbThongbao.Text = strerror;
            lbThongbao.ForeColor = Color.Yellow;
            lbThongbao.BackColor = Color.Red;
            txtItemCode.SelectAll();
            check_OK = 0;
            frmConfrim _frmconfrim = new frmConfrim(strerror);
            _frmconfrim.ShowDialog();
        }
        private void Save_button()
        {
            if (check_OK == 1)
            {
                SaveData();
                GridActual.DataSource = "";
                Gridstd.DataSource = "";
                //Clear_data();
                lbThongbao.Text = "Lưu dữ liệu thành công...";
                lbThongbao.ForeColor = Color.White;
                lbThongbao.BackColor = Color.Blue;
                strAccessories_list = "";
                lbQtyToday.Text = Count_Total_VS().ToString();
                txtModelCodeScan.Focus();
                txtModelCodeScan.SelectAll();
            }
            else
            {
                CallMessage("Error............");
            }
        }
        
    }
}
