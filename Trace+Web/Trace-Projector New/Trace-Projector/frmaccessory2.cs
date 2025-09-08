using System;
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
    public partial class frmaccessory2 : Form
    {
        StreamWriter writer;
        string modelcode = "", strAccessories_list = "", _status = "OK";
        int scanagain = 0, BaudRate, checkComPort = 0;
        int check_OK = 0;
        string today_ = DataConn.chiaca().ToString("yyyy-MM-dd");
        string linename = "";
        string strerror = "";
        DataTable dtActual = new DataTable();
        DataTable dtStd;
        int AccessQty = 0;
        int AccessQtyActual = 0;
        int CountAccess = 0;
        string ComNo;
        double STDup = 0, STDdw = 0, STD=0;
        public frmaccessory2()
        {
            InitializeComponent();
        }
        private void load_data()
        {
                var dt = DataConn.StoreFillDS("List_serial_accessories", CommandType.StoredProcedure, linename, today_, "2");
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
            var dt = DataConn.StoreFillDS("ProductionQtyACC", CommandType.StoredProcedure, today_, linename, "2");
            count_vs = int.Parse(dt.Rows[0][0].ToString());
            //}
            return count_vs;
        }
        private void Load_model(string model)
        {
            var dt = DataConn.StoreFillDS("Check_WeightSTD", CommandType.StoredProcedure, model);
            if (dt.Rows.Count > 0)
            {
                txtModelCode.Text = dt.Rows[0]["MODEL_CODE"].ToString();
                txtModelName.Text = dt.Rows[0]["MODEL_NAME"].ToString();
                txtWeight.Text = dt.Rows[0]["WEIGHT_STD"].ToString() + "(g)";
                STDup = double.Parse(dt.Rows[0]["WEIGHT_STD_UP"].ToString());
                STDdw = double.Parse(dt.Rows[0]["WEIGHT_STD_DW"].ToString());
                STD = double.Parse(dt.Rows[0]["WEIGHT_STD"].ToString());
                lbThongbao.Text = "";
            }
            else
            {
                strerror = "Không tìm thấy model, Hãy kiểm tra lại...";
                lbThongbao.Text = strerror;
                lbThongbao.ForeColor = Color.Yellow;
                lbThongbao.BackColor = Color.Red;
                txtTempSerial.SelectAll();
                frmConfrim _frmconfrim = new frmConfrim(strerror);
                _frmconfrim.ShowDialog();
            }
            var dt1 = DataConn.StoreFillDS("Check_WeightPart2", CommandType.StoredProcedure, model);
            if (dt1.Rows.Count>0)
            {
                Gridstd.DataSource = dt1;
                txtaccessQty.Text = dt1.Rows.Count.ToString();
                Gridstd.Columns[0].Width = 30;
                Gridstd.Columns[1].Width = 280;
                dtStd = dt1;
                AccessQty = dt1.Rows.Count;
            }
            else
            {
                Gridstd.DataSource = "";
                txtTempSerial.SelectAll();
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
                writer.WriteLine("TEMP_SERIAL,MODEL_CODE, MODEL_NAME, ACCESSORIES_LIST, INSERT_DT");
                writer.Close();
            }
            writer = File.AppendText(Directory.GetCurrentDirectory() + @"\DATA\AC_" + today_ + ".csv");
            writer.WriteLine(txtTempSerial.Text.ToUpper() + "," + modelcode + "," + txtModelName.Text + "," +strAccessories_list+ "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss" + ","));
            writer.Close();
            // Save SQL
            DataConn.ExecuteStore("Save_Accessories2", CommandType.StoredProcedure, linename, txtTempSerial.Text.ToUpper(), txtModelCode.Text.ToUpper(), txtModelName.Text.ToUpper(), strAccessories_list, scanagain, txtWeightCheck.Text.Trim());
            // Thong bao
            lbThongbao.Text = "Lưu dữ liệu thành công...!";
            lbThongbao.ForeColor = Color.White;
            lbThongbao.BackColor = Color.Blue;
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
            var dt = DataConn.StoreFillDS("Check_TempSerial_ACC", CommandType.StoredProcedure, txtTempSerial.Text);
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
                if (txtTempSerial.Text.Length == 15)
                {
                    GridActual.DataSource = "";
                    Gridstd.DataSource = "";
                    dtActual = null;
                    CountAccess = 0;
                    txtItemCode.Text = "";
                    if (Check_Exits_Temp() == 1 && cbCheckAgain.Checked == false)
                    {
                        lbThongbao.Text = "Serial đã tồn tại";
                        lbThongbao.ForeColor = Color.Yellow;
                        lbThongbao.BackColor = Color.Red;
                        txtTempSerial.SelectAll();
                    }
                    else if (Check_Exits_Temp() == 0 && cbCheckAgain.Checked == true)
                    {
                        lbThongbao.Text = "Serial chưa tồn tại và đang chọn Scan lại";
                        lbThongbao.ForeColor = Color.Yellow;
                        lbThongbao.BackColor = Color.Red;
                        txtTempSerial.SelectAll();
                    }
                    else if ((Check_Exits_Temp() == 1 && cbCheckAgain.Checked == true) || (Check_Exits_Temp() == 0 && cbCheckAgain.Checked == false))
                    {
                        string TempSerial = txtTempSerial.Text;
                        string values = TempSerial.Substring(6, 3);
                        modelcode = values;
                        Load_model(modelcode);
                        txtItemCode.Focus();
                        if (cbCheckAgain.Checked ==true)
                        {
                            scanagain = 1;
                        }
                    }
                    else
                    {
                        lbThongbao.Text = "Error...";
                        lbThongbao.ForeColor = Color.Yellow;
                        lbThongbao.BackColor = Color.Red;
                        txtTempSerial.SelectAll();
                    }
                }
                else
                {
                    strerror = "Serial không đúng định dạng...";
                    lbThongbao.Text = strerror;
                    lbThongbao.ForeColor = Color.Yellow;
                    lbThongbao.BackColor = Color.Red;
                    txtTempSerial.SelectAll();
                    check_OK = 0;
                    frmConfrim _frmconfrim = new frmConfrim(strerror);
                    _frmconfrim.ShowDialog();
                }
            }
        }
        private void Clear_data()
        {
            txtTempSerial.Text = "";
            txtModelCode.Text = "";
            txtModelName.Text = "";
            txtWeight.Text = "";
            txtaccessQty.Text = "";
            txtItemCode.Text = "";
            txtWeightCheck.Text = "";
            txtConfirm.Text = "";
            txtItemCode.Enabled = true;
        }
        private void frmaccessory_Load(object sender, EventArgs e)
        {
            txtTempSerial.Focus();
            
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
                txtTempSerial.SelectAll();
                frmConfrim _frmconfrim = new frmConfrim(strerror);
                _frmconfrim.ShowDialog();
            }
            if (File.Exists(Directory.GetCurrentDirectory() + @"\Setting.ini") == true)
            {
                using (StreamReader rd = new StreamReader(Directory.GetCurrentDirectory() + @"\Setting.ini"))
                {
                    string aa = rd.ReadLine();
                    string[] _values = aa.Trim().Split(',');
                    ComNo = _values[0];
                    BaudRate = int.Parse(_values[1]);                    
                }
            }
            else
            {
                strerror = "Không tìm thấy Cài đặt cổng COM...";
                lbThongbao.Text = strerror;
                lbThongbao.ForeColor = Color.Yellow;
                lbThongbao.BackColor = Color.Red;
                txtTempSerial.SelectAll();
                frmConfrim _frmconfrim = new frmConfrim(strerror);
                _frmconfrim.ShowDialog();
            }
            // check exits COM port
            string[] ports = SerialPort.GetPortNames();
            // Display each port name to the console.
            foreach (string port in ports)
            {
                if (port.Trim() == ComNo)
                {
                    checkComPort = 1;
                }
            }
            if (checkComPort != 1)
            {
                strerror = "Không thể kết nối máy cân ...";
                lbThongbao.Text = strerror;
                lbThongbao.ForeColor = Color.Yellow;
                lbThongbao.BackColor = Color.Red;
                txtTempSerial.SelectAll();
                frmConfrim _frmconfrim = new frmConfrim(strerror);
                _frmconfrim.ShowDialog();
            }
            load_data();
            lbQtyToday.Text = Count_Total_VS().ToString();
        }
        private void Save_Temp_Table()
        {
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            PingToServer();
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
            if (checkComPort == 1)
            {
                timer1.Enabled = false;
                
                try
                {
                    //serialPort1.ReadExisting();
                    if (serialPort1 != null && serialPort1.IsOpen)
                        serialPort1.Close();
                    if (serialPort1 != null)
                        serialPort1.Dispose();
                    serialPort1 = new SerialPort(ComNo, BaudRate, Parity.None, 8, StopBits.One);
                    serialPort1.Open();
                //string kk = serialPort1.ReadExisting();
                    txtWeightCheck.Text = serialPort1.ReadLine();
                    //txtWeightCheck.Text = txtWeightCheck.Text.Replace("ST,+", "").Trim();
                    
                    //  286.8 g
                    //286.8 g
                    //0.2869 kg
                    //txtWeightCheck.Text = txtWeightCheck.Text.Trim();
                    //ST,+   286.8 g
                    //0.6625
                    //662.5
                    //0.1190 kg\r
                    string trongluongcan = "0";
                    string chuoican = "0";
                    string donvi = "";
                    if (txtWeightCheck.Text == "")
                    {
                        txtWeightCheck.Text = "0"; //label1.Text.Trim().ToString();
                    }
                    else
                    {
                        if (txtWeightCheck.Text.Contains("kg"))
                        {
                            donvi = "kg";
                        }
                        else
                        {
                            donvi = "g";
                        }
                        chuoican = txtWeightCheck.Text;
                        if (donvi == "kg")
                        {
                            //int dodaichuoi = txtWeightCheck.Text.Length;
                            //chuoican = txtWeightCheck.Text.Substring(0, dodaichuoi - 3);                            
                            chuoican = chuoican.Replace("kg", "");
                            chuoican = chuoican.Replace("g","");
                            chuoican = chuoican.Replace(" ", "");
                            chuoican = chuoican.Replace("ST", "");                          
                            chuoican = chuoican.Replace("+", "");
                            chuoican = chuoican.Replace("r", "");
                            chuoican = chuoican.Replace(",", "");
                            trongluongcan = (double.Parse(chuoican) * 1000).ToString();
                            txtWeightCheck.Text = trongluongcan;
                        }
                        else
                        {
                            //int dodaichuoi = txtWeightCheck.Text.Length;
                            //chuoican = txtWeightCheck.Text.Substring(0, dodaichuoi - 2);
                            chuoican = chuoican.Replace("kg", "");
                            chuoican = chuoican.Replace("g", "");
                            chuoican = chuoican.Replace(" ", "");
                            chuoican = chuoican.Replace("ST", "");                           
                            chuoican = chuoican.Replace("+", "");
                            chuoican = chuoican.Replace("r", "");
                            chuoican = chuoican.Replace(",", "");
                            trongluongcan = chuoican;
                            txtWeightCheck.Text = trongluongcan;
                        }
                    }
                    serialPort1.Close();
                   
                }
                catch (Exception )
                {
                    //timer1.Enabled = false;
                    //MessageBox.Show("Lỗi.... \n Không thể đọc dữ liệu từ cổng COM \n Hãy kiểm tra cổng COM \n Hãy tắt chương trình và bật lại \n" + ex);
                    //this.Close();
                }

                timer1.Enabled = true;
            }
            else
            {
                strerror = "Không thể kết nối cổng COM...";
                lbThongbao.Text = strerror;
                lbThongbao.ForeColor = Color.Yellow;
                lbThongbao.BackColor = Color.Red;
                txtTempSerial.SelectAll();
                frmConfrim _frmconfrim = new frmConfrim(strerror);
                _frmconfrim.ShowDialog();
                //timer1.Enabled = false;
            }
        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            serialPort1.ReadExisting();
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
                        //if (txtItemCode.Text.Trim().Length > 30)
                        //{
                        //    string[] arr = txtItemCode.Text.Split(';');
                        //    string kk = arr[1];
                        //    txtItemCode.Text = kk;
                        //}
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
                    if (CountAccess == AccessQty)
                    {
                        lbThongbao.Text = "Đã đủ tài liệu, phụ kiện...";
                        lbThongbao.ForeColor = Color.Yellow;
                        lbThongbao.BackColor = Color.Red;
                        txtTempSerial.SelectAll();
                        CountAccess = 0;
                        txtItemCode.Enabled = false;
                        txtConfirm.Focus();
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
        private void txtConfirm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==13)
            {
                if (txtConfirm.Text.Trim() == txtTempSerial.Text.Trim())
                {
                    if (checkComPort == 1)
                    {
                        //try
                        //{
                        string ss = txtWeightCheck.Text.Replace("g", "");
                        ss = ss.Replace("kg", "");
                        ss = ss.Replace(" ","");

                        float slcan = float.Parse(ss);

                            //double actual_weight = slcan;
                            //if (actual_weight > STD + STDup || actual_weight < STD - STDdw)
                            if (slcan > STD + STDup || slcan < STD - STDdw)
                            {
                                strerror = "Trọng lượng cân sai, hãy ktra...";
                                lbThongbao.Text = strerror;
                                lbThongbao.ForeColor = Color.Yellow;
                                lbThongbao.BackColor = Color.Red;
                                txtTempSerial.SelectAll();
                                check_OK = 0;
                                frmConfrim _frmconfrim = new frmConfrim(strerror);
                                _frmconfrim.ShowDialog();
                            }
                            else
                            {
                                SaveData();
                                GridActual.DataSource = "";
                                Gridstd.DataSource = "";
                                Clear_data();
                                txtTempSerial.Focus();
                                txtTempSerial.SelectAll();
                                lbThongbao.Text = "Lưu dữ liệu thành công...";
                                lbThongbao.ForeColor = Color.White;
                                lbThongbao.BackColor = Color.Blue;
                                strAccessories_list = "";
                                lbQtyToday.Text = Count_Total_VS().ToString();
                            }
                        //}
                        //catch (Exception ex)
                        //{
                        //    throw ex;
                        //}
                    }
                    else
                    {
                        strerror = "Không thể kết nối tới cân...";
                        lbThongbao.Text = strerror;
                        lbThongbao.ForeColor = Color.Yellow;
                        lbThongbao.BackColor = Color.Red;
                        txtItemCode.SelectAll();
                        check_OK = 0;
                        frmConfrim _frmconfrim = new frmConfrim(strerror);
                        _frmconfrim.ShowDialog();
                    }
                }
            }
        }
    }
}
