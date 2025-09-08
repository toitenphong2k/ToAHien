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
    public partial class FrmVisualCheck2 : Form
    {
        public FrmVisualCheck2()
        {
            InitializeComponent();
        }
        StreamWriter writer;
        int saveOK = 0;
        string modelcode ="";
        int scanagain = 0;
        int check_OK = 0;
        string today_ = DataConn.chiaca().ToString("yyyy-MM-dd");
        string linename = "";
        private void load_data()
        {
            //try
            //{
                var dt = DataConn.StoreFillDS("List_serial_visual", CommandType.StoredProcedure, linename, today_ );
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].Width = 125;
                    dataGridView1.Columns[1].Width = 90;
                    dataGridView1.Columns[2].Width = 90;
                    dataGridView1.Columns[3].Width = 90;
                    //dataGridView1.Columns[4].Width = 70;
                }
            //}
            //catch (Exception)
            //{
            //}
        }
        private int Count_Total_VS()
        {
            int count_vs = 0;
            //if (modelcode != "" && modelcode != null)
            //{
                var dt = DataConn.StoreFillDS("ProductionQty", CommandType.StoredProcedure, today_, modelcode, linename);
                count_vs = int.Parse(dt.Rows[0][0].ToString());
            //}
            
            return count_vs;
        }
        private void Load_model(string model)
        {
            var dt = DataConn.StoreFillDS("Load_model", CommandType.StoredProcedure, model);
            if (dt.Rows.Count > 0)
            {
                txtModelCode.Text = dt.Rows[0]["MODEL_CODE"].ToString();
                txtModelName.Text = dt.Rows[0]["MODEL_NM"].ToString();
                txtPCBQty.Text = dt.Rows[0]["PCB_QTY"].ToString();
                txtOtherQty.Text = dt.Rows[0]["DMD_QTY"].ToString();
                txtOpticalQty.Text = dt.Rows[0]["OPTICAL_QTY"].ToString();
                lbThongbao.Text = "";
            }
            else
            {
                lbThongbao.Text = "Không tìm thấy model, Hãy kiểm tra lại...";
                lbThongbao.ForeColor = Color.Yellow;
                lbThongbao.BackColor = Color.Red;
                //Clear_data();
            }
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
        private void txtTempSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                if (txtTempSerial.Text.Length == 15)
                {
                    if (Check_Exits_Temp() == 1 && cbCheckAgain.Checked == false)
                    {
                        lbThongbao.Text = "Serial đã tồn tại";
                        lbThongbao.ForeColor = Color.Yellow;
                        lbThongbao.BackColor = Color.Red;
                        txtTempSerial.SelectAll();
                        check_OK = 0;
                    }
                    else if (Check_Exits_Temp() == 0 && cbCheckAgain.Checked == true)
                    {
                        lbThongbao.Text = "Serial chưa tồn tại và đang chọn Scan lại";
                        lbThongbao.ForeColor = Color.Yellow;
                        lbThongbao.BackColor = Color.Red;
                        txtTempSerial.SelectAll();
                        check_OK = 0;
                    }
                    else if ((Check_Exits_Temp() == 1 && cbCheckAgain.Checked == true) || (Check_Exits_Temp() == 0 && cbCheckAgain.Checked == false))
                    {
                        string TempSerial = txtTempSerial.Text;
                        string values = TempSerial.Substring(6, 3);
                        modelcode = values;
                        Load_model(modelcode);
                        txtProductSerial.Focus();
                        check_OK = 1;
                    }                                    
                    else
                    {
                        lbThongbao.Text = "Error...";
                        lbThongbao.ForeColor = Color.Yellow;
                        lbThongbao.BackColor = Color.Red;
                        txtTempSerial.SelectAll();
                        check_OK = 0;
                    }
                }
                else
                {
                    lbThongbao.Text = "Serial không đúng định dạng...";
                    lbThongbao.ForeColor = Color.Yellow;
                    lbThongbao.BackColor = Color.Red;
                    txtTempSerial.SelectAll();
                    check_OK = 0;
                    //MessageBox.Show("Serial không đúng định dạng...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           // PingToServer();
        }

        private void txtModelCode2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                if (txtModelCode2.Text.Trim() != "")
                {
                    if (txtModelName.Text.Trim() == txtModelCode2.Text.Trim())
                    {
                        txtCartonSerial.Focus();
                        lbThongbao.Text = "";
                        check_OK = 1;
                    }
                    else
                    {
                        lbThongbao.Text = "Sai model...";
                        lbThongbao.ForeColor = Color.Yellow;
                        lbThongbao.BackColor = Color.Red;
                        txtModelCode2.SelectAll();
                        check_OK = 0;
                    }
                    
                }
                else
                {
                    lbThongbao.Text = "Hãy scan Model Code trên tem sản phẩm...";
                    lbThongbao.ForeColor = Color.Yellow;
                    lbThongbao.BackColor = Color.Red;
                    txtModelCode2.SelectAll();
                    check_OK = 0;
                }
            }
        }

        private void txtProductSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtProductSerial.Text.Trim() != "")
                {
                    txtModelCode2.Focus();
                    lbThongbao.Text = "";
                    check_OK = 1;
                }
                else
                {
                    lbThongbao.Text = "Hãy scan Serial trên  sản phẩm...";
                    lbThongbao.ForeColor = Color.Yellow;
                    lbThongbao.BackColor = Color.Red;
                    txtModelCode2.SelectAll();
                    check_OK = 0;
                }
            }
        }

        private void txtCartonSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)   //4 so cuoi cua temp tam = 4 so cuoi tem serial
            {
                if (txtCartonSerial.Text.Trim() != "" && txtCartonSerial.Text.Trim().Length == 10 && txtProductSerial.Text.Trim().Length == 9)
                {
                    string cut_temp = txtTempSerial.Text.Trim().Substring(11, 4);
                    string cut_cartonSerial  = txtCartonSerial.Text.Trim().Substring(6, 4);
                    string cut_serial = txtProductSerial.Text.Trim().Substring(5, 4);
                    if (cut_temp == cut_serial && cut_cartonSerial == cut_serial)
                    {
                        txtUPC.Focus();
                        lbThongbao.Text = "";
                        check_OK = 1;
                    }
                    else
                    {
                        lbThongbao.Text = "Sai serial...";
                        lbThongbao.ForeColor = Color.Yellow;
                        lbThongbao.BackColor = Color.Red;
                        txtCartonSerial.SelectAll();
                        check_OK = 0;
                    }
                    
                }
                else
                {
                    lbThongbao.Text = "Hãy scan Serial dán trên Carton...";
                    lbThongbao.ForeColor = Color.Yellow;
                    lbThongbao.BackColor = Color.Red;
                    txtCartonSerial.SelectAll();
                    check_OK = 0;
                }
            }
        }

        private void txtUPC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtUPC.Text.Trim() != "" && txtUPC.Text.Length >5 && txtUPC.Text.Substring(0,1) != "%" )
                {
                    txtModelCode22.Focus();                               
                }
                else
                {
                    lbThongbao.Text = "Hãy scan UPC Serial...";
                    lbThongbao.ForeColor = Color.Yellow;
                    lbThongbao.BackColor = Color.Red;
                    txtUPC.SelectAll();
                    check_OK = 0;
                }
            }
        }
        private void Clear_data()
        {
            txtTempSerial.Text = "";
            txtModelCode.Text = "";
            txtModelName.Text = "";
            txtOpticalQty.Text = "";
            txtPCBQty.Text = "";
            txtOtherQty.Text = "";
            txtProductSerial.Text = "";
            txtModelCode2.Text = "";
            txtCartonSerial.Text = "";
            txtUPC.Text = "";
            txtModelCode22.Text = "";
            txtCarton2.Text = "";
            txtupc2.Text = "";
        }
        private int Check_Exits_Temp()
        {
            var dt = DataConn.StoreFillDS("Check_TempSerial_Visual", CommandType.StoredProcedure, txtTempSerial.Text);
            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        private void Save_Visual_Check()
        {
            if (cbCheckAgain.Checked==true)
            {
                scanagain = 1;
            }
            if (txtModelName.Text.Trim() == txtModelCode2.Text.Trim())
            {               
                DataConn.ExecuteStore("SaveTraceVisualCheck", CommandType.StoredProcedure, txtModelCode.Text, txtTempSerial.Text.ToUpper(), txtProductSerial.Text.ToUpper(), txtModelCode2.Text.ToUpper(), txtCartonSerial.Text.ToUpper(), txtUPC.Text.ToUpper(), scanagain, linename);
                saveOK = 1;
            }
            else
            {
                check_OK = 0;
                saveOK = 0;
                return;
            }
            check_OK = 0;
        }
        private void SaveData_Offline()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + @"\DATA\VS_" + today_ + ".csv") == false)
            {
                writer = File.CreateText(Directory.GetCurrentDirectory() + @"\DATA\VS_" + today_ + ".csv");
                writer.WriteLine("TEMP_SERIAL,MODEL_CODE, MODEL_NAME, PRODUCT_SERIAL, CARTON_SERIAL, UPC_SERIAL,CARTON_SERIAL2, UPC_SERIAL2, INSERT_DT");
                writer.Close();
            }
            writer = File.AppendText(Directory.GetCurrentDirectory() + @"\DATA\VS_" + today_ + ".csv");
            writer.WriteLine(txtTempSerial.Text.ToUpper() + "," + modelcode + "," + txtModelName.Text + "," + txtProductSerial.Text + "," + txtCartonSerial.Text + "," + txtUPC.Text + "," + txtCarton2.Text+ "," + txtupc2.Text+ ","  + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss" + ","));
            writer.Close();
            lbThongbao.Text = "Lưu dữ liệu thành công...!";
            lbThongbao.ForeColor = Color.White;
            lbThongbao.BackColor = Color.Blue;
            //}
        }
        private void FrmVisualCheck_Load(object sender, EventArgs e)
        {
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
                //strerror = "Không tìm thấy Cài đặt tên Line...";
                lbThongbao.Text = "Không tìm thấy Cài đặt tên Line...";
                lbThongbao.ForeColor = Color.Yellow;
                lbThongbao.BackColor = Color.Red;
                txtTempSerial.SelectAll();
            }

            load_data();
            lbLine.Visible = false;
            lbThongbao.Text = "";
            lbQtyToday.Text = Count_Total_VS().ToString();
        }

        private void txtModelCode22_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtModelCode22.Text.Trim() != "")
                {
                    if (txtModelName.Text.Trim() == txtModelCode22.Text.Trim() && txtModelName.Text.Trim() == txtModelCode2.Text.Trim())
                    {
                        txtCarton2.Focus();
                        lbThongbao.Text = "";
                        check_OK = 1;
                    }
                    else
                    {
                        lbThongbao.Text = "Sai model...";
                        lbThongbao.ForeColor = Color.Yellow;
                        lbThongbao.BackColor = Color.Red;
                        txtModelCode22.SelectAll();
                        check_OK = 0;
                    }

                }
                else
                {
                    lbThongbao.Text = "Hãy scan Model Code trên tem sản phẩm...";
                    lbThongbao.ForeColor = Color.Yellow;
                    lbThongbao.BackColor = Color.Red;
                    txtModelCode2.SelectAll();
                    check_OK = 0;
                }
            }
        }

        private void txtCarton2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtCartonSerial.Text.Trim() != "" && txtCartonSerial.Text.Trim().Length == 10 && txtProductSerial.Text.Trim().Length == 9 && txtCarton2.Text.Trim() != "" && txtCarton2.Text.Trim() == txtCartonSerial.Text.Trim())
                {
                    string cut_temp = txtTempSerial.Text.Trim().Substring(11, 4);
                    string cut_cartonSerial = txtCartonSerial.Text.Trim().Substring(6, 4);
                    string cut_serial = txtProductSerial.Text.Trim().Substring(5, 4);
                    if (cut_temp == cut_serial && cut_cartonSerial == cut_serial)
                    {
                        txtupc2.Focus();
                        lbThongbao.Text = "";
                        check_OK = 1;
                    }
                    else
                    {
                        lbThongbao.Text = "Sai serial...";
                        lbThongbao.ForeColor = Color.Yellow;
                        lbThongbao.BackColor = Color.Red;
                        txtCarton2.SelectAll();
                        check_OK = 0;
                    }

                }
                else
                {
                    lbThongbao.Text = "Hãy scan Serial dán trên Carton...";
                    lbThongbao.ForeColor = Color.Yellow;
                    lbThongbao.BackColor = Color.Red;
                    txtCarton2.SelectAll();
                    check_OK = 0;
                }
            }
        }

        private void txtupc2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtupc2.Text.Trim() != "" && txtupc2.Text.Length > 5 && txtupc2.Text.Substring(0, 1) != "%" && txtUPC.Text.Trim() == txtupc2.Text.Trim())
                {
                    check_OK = 1;
                    if (check_OK == 1)
                    {
                        //minh edit 08-2020  for check visualize compare Assy
                        //check cong doan nap rap
                        var dt_check = DataConn.StoreFillDS("Check_Visual_Assy", CommandType.StoredProcedure, txtModelCode.Text, txtTempSerial.Text.ToUpper());
                        if (dt_check.Rows[0][0].ToString() == "0")
                        {
                            //MessageBox.Show("San pham chua duoc check cong doan nap rap!"); 
                            lbThongbao.Text = "Sản phẩm chưa được check công đoạn lắp ráp!";
                            lbThongbao.ForeColor = Color.Yellow;
                            lbThongbao.BackColor = Color.Red;
                            txtCartonSerial.SelectAll();
                            check_OK = 0;
                        }
                        else
                        {
                            //old
                            Save_Visual_Check();
                            SaveData_Offline();
                            if (saveOK == 1)
                            {
                                lbThongbao.Text = "Lưu dữ liệu thành công...";
                                lbThongbao.ForeColor = Color.White;
                                lbThongbao.BackColor = Color.Blue;
                                Clear_data();
                                load_data();
                                txtTempSerial.Focus();
                                lbQtyToday.Text = Count_Total_VS().ToString();
                            }
                            else
                            {
                                lbThongbao.Text = "Sai model, Hãy kiểm tra model";
                                lbThongbao.ForeColor = Color.Yellow;
                                lbThongbao.BackColor = Color.Red;
                                txtCartonSerial.SelectAll();
                                check_OK = 0;
                            }
                        }
                       
                    }
                    else
                    {
                        lbThongbao.Text = "Error  txtUPC_KeyPress ...";
                        lbThongbao.ForeColor = Color.Yellow;
                        lbThongbao.BackColor = Color.Red;
                        txtupc2.SelectAll();
                    }
                }
                else
                {
                    lbThongbao.Text = "Hãy scan UPC Serial...";
                    lbThongbao.ForeColor = Color.Yellow;
                    lbThongbao.BackColor = Color.Red;
                    txtupc2.SelectAll();
                    check_OK = 0;
                }
            }
        }

        private void btlClear_Click(object sender, EventArgs e)
        {
            Clear_data();
            txtTempSerial.Focus();
            lbThongbao.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
