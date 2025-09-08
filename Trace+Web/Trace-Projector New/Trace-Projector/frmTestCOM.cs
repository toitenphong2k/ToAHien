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
    public partial class frmTestCOM : Form
    {
        public frmTestCOM()
        {
            InitializeComponent();
        }
        string ComNo;
        int BaudRate;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1 != null && serialPort1.IsOpen)
                    serialPort1.Close();
                if (serialPort1 != null)
                    serialPort1.Dispose();
                serialPort1 = new SerialPort(ComNo, BaudRate, Parity.None, 8, StopBits.One);
                serialPort1.Open();
                txtWeightCheck.Text = serialPort1.ReadLine();
                txtWeightCheck.Text = txtWeightCheck.Text.Replace("ST,+  ", "");
                //0.6625
                //662.5
                //0.1190 kg\r
                //string trongluongcan = "0";
                //string chuoican = "0";
                //string donvi = "";
                //if (txtWeightCheck.Text == "")
                //{
                //    txtWeightCheck.Text = "0"; //label1.Text.Trim().ToString();
                //}
                //else
                //{
                //    if (txtWeightCheck.Text.Contains("kg"))
                //    {
                //        donvi = "kg";
                //    }
                //    else
                //    {
                //        donvi = "g";
                //    }
                //    if (donvi == "kg")
                //    {
                //        int dodaichuoi = txtWeightCheck.Text.Length;
                //        chuoican = txtWeightCheck.Text.Substring(0, dodaichuoi - 4);
                //        trongluongcan = chuoican.Replace("kg", "");
                //        txtWeightCheck.Text = trongluongcan;
                //    }
                //    else
                //    {
                //        int dodaichuoi = txtWeightCheck.Text.Length;
                //        chuoican = txtWeightCheck.Text.Substring(0, dodaichuoi - 4);
                //        trongluongcan = chuoican.Replace("g", "");
                //        txtWeightCheck.Text = trongluongcan;
                //    }

                //}
                serialPort1.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void frmTestCOM_Load(object sender, EventArgs e)
        {
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
                txtWeightCheck.Text = "Khong tim thay cong COM";
            }
        }
    }
}
