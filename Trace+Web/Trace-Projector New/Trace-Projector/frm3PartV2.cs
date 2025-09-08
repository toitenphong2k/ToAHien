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
    public partial class frm3PartV2 : Form
    {
        StreamWriter writer;
        string today_ = DataConn.chiaca().ToString("yyyy-MM-dd");
        string today = DateTime.Now.ToString("yyyyMMdd");
        string modelcode = "", PCBID_Temp, Optical_Temp, OtherTemp, LEN_Temp, linename = "";
        int PCBQty, OpticalQty, DMDQty, Optical2Qty, LenQty, CountPCBQty, OtherQty, CountOther, CountOptical, CountOptical2Qty, CountLenQty = 0;
        int scanagain = 0;

        public frm3PartV2()
        {
            InitializeComponent();
        }

        private void txtTempSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            lbThongbao.Text = "";
            //Clear_data();
            if (cbCheckAgain.Checked == true)
            {
                scanagain = 1;
            }
            if (e.KeyChar == 13)
            {
                if (txtTempSerial.Text.Trim() != "")
                {
                    if (txtTempSerial.Text.Length == 15)
                    {

                        DataTable dtcheckcb = DataConn.StoreFillDS("Check_TempSerial_Trace", CommandType.StoredProcedure, txtTempSerial.Text);
                        if (dtcheckcb.Rows.Count == 0)
                        {
                            lbThongbao.Text = "Temp chưa qua công đoạn chuẩn bị";
                            MessageBox.Show("Temp chưa qua công đoạn chuẩn bị");
                            txtTempSerial.SelectAll();
                            //txtTempSerial.Focus();
                            return;
                        }
                        txtOptic.Enabled = true;
                        // Online mode
                        if (cbCheckAgain.Checked == true)
                        {
                            var dt = DataConn.StoreFillDS("Check_TempSerial", CommandType.StoredProcedure, txtTempSerial.Text);
                            if (dt.Rows.Count > 0)
                            {
                                var dt1 = DataConn.StoreFillDS("Check_TempSerial_NOT", CommandType.StoredProcedure, txtTempSerial.Text);
                                if (dt1.Rows.Count > 0)
                                {
                                    txtOptic.Text = dt1.Rows[0]["OPTICALID"].ToString();
                                    txtPCBID.Text = dt1.Rows[0]["PCBID"].ToString();
                                    txtOther.Text = dt1.Rows[0]["OTHER"].ToString();
                                    txtOptical2.Text = dt1.Rows[0]["OPTICALID2"].ToString();
                                    txtLen.Text = dt1.Rows[0]["LENID"].ToString();
                                }

                                string TempSerial = txtTempSerial.Text;
                                string values = TempSerial.Substring(6, 3);
                                modelcode = values;
                                Load_model(modelcode);

                                if (rbPCBID.Checked == true)
                                {
                                    lblbuoc.Text = "PCBID";
                                    lbThongbao.Text = "Hay scan lai step PCBID!";
                                }
                                else if (rbOptical1.Checked == true)
                                {
                                    lblbuoc.Text = "Optical1";
                                    lbThongbao.Text = "Hay scan lai step Optical1!";
                                }
                                else if (rbLEN.Checked == true)
                                {
                                    lblbuoc.Text = "LEN";
                                    lbThongbao.Text = "Hay scan lai step LEN!";
                                }
                                else if (rbOptical2.Checked == true)
                                {
                                    lblbuoc.Text = "Optical2";
                                    lbThongbao.Text = "Hay scan lai step Optical2!";
                                }

                                //edit truong hop scan again
                                txtStep.Focus();
                                lbTBID.Text = "";  //reset lai thong bao!   

                            }
                            else
                            {
                                MessageBox.Show("TEM nay chua duoc scan -> Hay scan moi!");
                                txtTempSerial.Text = "";
                                txtTempSerial.Focus();
                            }

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
                                        txtOptical2.Text = dt1.Rows[0]["OPTICALID2"].ToString();
                                        txtLen.Text = dt1.Rows[0]["LENID"].ToString();

                                        lbThongbao.Text = "Hãy tiếp tục scan...";
                                        lbTBID.Text = "";
                                        lbThongbao.ForeColor = Color.White;
                                        lbThongbao.BackColor = Color.Blue;

                                        //doi thu tu ****
                                        if (dt1.Rows[0]["PCBID"].ToString() == "NOT") //thuc hien step 1
                                        {
                                            txtStep.Focus();
                                            txtStep.SelectAll();
                                            lblbuoc.Text = "PCBID";
                                            lbTBID.Text = "Hãy scan bước tiep theo => PCBID!";
                                        }
                                        else if (dt1.Rows[0]["OPTICALID"].ToString() == "NOT")  //thuc hien step 2
                                        {
                                            txtStep.Focus();
                                            txtStep.SelectAll();
                                            lblbuoc.Text = "Optical1";
                                            lbTBID.Text = "Hãy scan bước tiep theo => Optical1!";
                                        }
                                        else if (dt1.Rows[0]["LENID"].ToString() == "NOT") //thuc hien buoc 3
                                        {
                                            if (cbStep.Text.ToString() == "Optical2")
                                            {
                                                txtStep.Focus();
                                                txtStep.SelectAll();
                                                lblbuoc.Text = "Optical2";
                                                lbTBID.Text = "Hãy scan bước tiep theo => Optical2!";
                                            }
                                            else
                                            {
                                                txtStep.Focus();
                                                txtStep.SelectAll();
                                                lblbuoc.Text = "LEN";
                                                lbTBID.Text = "Hãy scan bước tiep theo => LEN!";
                                            }

                                        }
                                        else if (dt1.Rows[0]["OPTICALID2"].ToString() == "NOT") //thuc hien buoc 4
                                        {
                                            txtStep.Focus();
                                            txtStep.SelectAll();
                                            lblbuoc.Text = "Optical2";
                                            lbTBID.Text = "Hãy scan bước tiep theo => Optical2!";
                                        }
                                        else if (dt1.Rows[0]["OTHER"].ToString() == "NOT")
                                        {
                                            txtStep.Focus();
                                            txtStep.SelectAll();
                                            lblbuoc.Text = "Others";
                                            lbTBID.Text = "Hãy scan bước tiep theo => Others!";
                                        }

                                        //old
                                        //if (dt1.Rows[0]["OPTICALID"].ToString() == "NOT")
                                        //{
                                        //    txtOptic.Focus();
                                        //    txtOptic.SelectAll();
                                        //}
                                        //else if (dt1.Rows[0]["OPTICALID2"].ToString() == "NOT")
                                        //{
                                        //    txtOptical2.Focus();
                                        //    txtOptical2.SelectAll();
                                        //}
                                        //else if (dt1.Rows[0]["PCBID"].ToString() == "NOT")
                                        //{
                                        //    txtPCBID.Focus();
                                        //    txtPCBID.SelectAll();
                                        //}
                                        //else if (dt1.Rows[0]["LENID"].ToString() == "NOT")
                                        //{
                                        //    txtLen.Focus();
                                        //    txtLen.SelectAll();
                                        //}
                                        //else if (dt1.Rows[0]["OTHER"].ToString() == "NOT")
                                        //{
                                        //    txtOther.Focus();
                                        //    txtOther.SelectAll();
                                        //}

                                    }
                                    else
                                    {
                                        if (cbCheckAgain.Checked == true)
                                        {
                                            string TempSerial = txtTempSerial.Text;
                                            string values = TempSerial.Substring(6, 3);
                                            modelcode = values;
                                            Load_model(modelcode);

                                            txtStep.Focus();
                                            txtStep.SelectAll();
                                            lblbuoc.Text = "PCBID";
                                            //txtTempSerial.SelectAll();
                                            lbTBID.Text = "Hãy scan cụm PCBID!";
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
                                    //Case AddNew recode
                                    string TempSerial = txtTempSerial.Text;
                                    string values = TempSerial.Substring(6, 3);
                                    modelcode = values;
                                    Load_model(modelcode);

                                    txtStep.Focus();
                                    txtStep.SelectAll();
                                    lblbuoc.Text = "PCBID";
                                    //txtTempSerial.SelectAll();
                                    lbTBID.Text = "Hãy scan cụm PCBID!";
                                }
                            }
                            else
                            {
                                // offline mode
                                txtPCBID.Focus();
                                lblbuoc.Text = "PCBID";
                                lbTBID.Text = "Hãy scan cụm PCBID!";
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

        private void txtTempSerial_old_KeyPress(object sender, KeyPressEventArgs e)
        {
            lbThongbao.Text = "";
            //Clear_data();
            if (cbCheckAgain.Checked == true)
            {
                scanagain = 1;
            }
            if (e.KeyChar == 13)
            {
                if (txtTempSerial.Text.Trim() != "")
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
                                        txtOptical2.Text = dt1.Rows[0]["OPTICALID2"].ToString();
                                        txtLen.Text = dt1.Rows[0]["LENID"].ToString(); ;

                                        lbThongbao.Text = "Hãy tiếp tục scan...";
                                        lbTBID.Text = "";
                                        lbThongbao.ForeColor = Color.White;
                                        lbThongbao.BackColor = Color.Blue;
                                        if (dt1.Rows[0]["OPTICALID"].ToString() == "NOT")
                                        {
                                            txtOptic.Focus();
                                            txtOptic.SelectAll();
                                        }
                                        else if (dt1.Rows[0]["OPTICALID2"].ToString() == "NOT")
                                        {
                                            txtOptical2.Focus();
                                            txtOptical2.SelectAll();
                                        }
                                        else if (dt1.Rows[0]["PCBID"].ToString() == "NOT")
                                        {
                                            txtPCBID.Focus();
                                            txtPCBID.SelectAll();
                                        }
                                        else if (dt1.Rows[0]["LENID"].ToString() == "NOT")
                                        {
                                            txtLen.Focus();
                                            txtLen.SelectAll();
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
        private void Load_model(string model)
        {
            var dt = DataConn.StoreFillDS("Load_model", CommandType.StoredProcedure, model);
            if (dt.Rows.Count > 0)
            {
                PCBQty = int.Parse(dt.Rows[0]["PCB_QTY"].ToString());
                OpticalQty = int.Parse(dt.Rows[0]["OPTICAL_QTY"].ToString());
                //DMDQty = int.Parse(dt.Rows[0]["DMD_QTY"].ToString());
                OtherQty = int.Parse(dt.Rows[0]["OTHER"].ToString());
                Optical2Qty = int.Parse(dt.Rows[0]["OPTICAL2"].ToString());//LEN_QTY
                LenQty = int.Parse(dt.Rows[0]["LEN_QTY"].ToString());

                txtModelCode.Text = dt.Rows[0]["MODEL_CODE"].ToString();
                txtModelName.Text = dt.Rows[0]["MODEL_NM"].ToString();
                txtPCBQty.Text = dt.Rows[0]["PCB_QTY"].ToString();
                txtOtherQty.Text = dt.Rows[0]["OTHER"].ToString();
                txtOpticalQty.Text = dt.Rows[0]["OPTICAL_QTY"].ToString();
                txtOpticalQty2.Text = dt.Rows[0]["OPTICAL2"].ToString();
                txtLenQty.Text = dt.Rows[0]["LEN_QTY"].ToString();
                //txtOptic.Focus();
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
            txtOpticalQty2.Text = "";
            txtLenQty.Text = "";
            //txtKittingList.Text = "";
            txtOptic.Text = "";
            txtOther.Text = "";
            txtLen.Text = "";
            txtOptical2.Text = "";
            txtLen.Enabled = true;
            txtOptical2.Enabled = true;
            txtPCBID.Enabled = true;
        }
        private void SaveData()
        {
            var dt = DataConn.StoreFillDS("Check_TempSerial", CommandType.StoredProcedure, txtTempSerial.Text);
            if (dt.Rows.Count > 0)
            {
                lbThongbao.Text = "Serial đã tồn tại";
                lbThongbao.ForeColor = Color.Yellow;
                lbThongbao.BackColor = Color.Red;
            }
            else
            {
                DataConn.ExecuteStore("SaveTraceFA_new2", CommandType.StoredProcedure, linename.ToUpper(), txtKittingList.Text.ToUpper(), modelcode.ToUpper(), txtTempSerial.Text.ToUpper(), txtPCBID.Text.ToUpper(), txtOptic.Text.ToUpper(), txtOther.Text.ToUpper(), txtOptical2.Text.ToUpper(), txtLen.Text.ToUpper(), scanagain);
                SaveData_Offline();
                lbThongbao.Text = "Lưu dữ liệu thành công...!";
                lbThongbao.ForeColor = Color.White;
                lbThongbao.BackColor = Color.Blue;
                txtOptic.Enabled = true;
            }

        }
        private void SaveData3()
        {
            DataConn.ExecuteStore("SaveTraceFA_new2", CommandType.StoredProcedure, linename.ToUpper(), txtKittingList.Text.ToUpper(), modelcode.ToUpper(), txtTempSerial.Text.ToUpper(), txtPCBID.Text.ToUpper(), txtOptic.Text.ToUpper(), txtOther.Text.ToUpper(), txtOptical2.Text.ToUpper(), txtLen.Text.ToUpper(), scanagain);
            SaveData_Offline();
            lbThongbao.Text = "Lưu dữ liệu thành công...!";
            lbThongbao.ForeColor = Color.White;
            lbThongbao.BackColor = Color.Blue;
            lbTBID.Text = "To be continue...!";
            txtStep.Text = "";
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
                writer.WriteLine("LINE_NAME,MODEL_CODE,KITTING_LIST, TEMP_SERIAL,PCBID, OPTICAL,OPTICAL2, LENID, INSERT_DT");
                writer.Close();
            }
            writer = File.AppendText(Directory.GetCurrentDirectory() + @"\DATA\PJ_" + today + ".csv");
            writer.WriteLine(linename.ToUpper() + "," + modelcode.ToUpper() + "," + txtKittingList.Text.ToUpper() + "," + txtTempSerial.Text.ToUpper() + "," + txtPCBID.Text.ToUpper() + "," + txtOptic.Text.ToUpper() + "," + txtOptical2.Text.ToUpper() + "," + txtLen.Text.ToUpper() + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss" + ","));
            writer.Close();
            lbThongbao.Text = "Lưu dữ liệu thành công...!";
            lbThongbao.ForeColor = Color.White;
            lbThongbao.BackColor = Color.Blue;
            //}
        }

        private void txtOptical2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Phong edit
            string typeoptical = "2";
            var dtMasterChar = DataConn.StoreFillDS("ChecMasterOpticalChar", System.Data.CommandType.StoredProcedure, txtModelCode.Text);
            if (dtMasterChar.Rows[0][0].ToString() == "Y")
            {
                typeoptical = "3";
            }
            var dtOptic = DataConn.StoreFillDS("ChecMasterOptical", System.Data.CommandType.StoredProcedure, txtModelCode.Text, typeoptical);
            if (dtOptic.Rows.Count > 0)
            {
                gridMaster.DataSource = dtOptic;
            }
            else
            {
                gridMaster.DataSource = dtOptic;
            }
            if (e.KeyChar == 13)
            {
                if (txtStep.Text == "NOT")
                {
                    //check mater Not
                    var checkoptical2 = DataConn.StoreFillDS("Check_NOT_optical2", System.Data.CommandType.StoredProcedure, txtModelCode.Text);
                    if (int.Parse(checkoptical2.Rows[0][0].ToString()) > 0)
                    {
                        //MessageBox.Show("Ban khong duoc phep ban NOT!");
                        txtStep.Text = "";
                        txtStep.Focus();
                        lblbuoc.Text = "Optical2";
                        lbTBID.Text = "Hãy scan Lại bước => Optical2!";
                        lbThongbao.Text = "Model này không được scan NOT!";
                    }
                    else
                    {
                        if (int.Parse(txtOtherQty.Text.ToString()) == 0)
                        {
                            txtOptical2.Text = "NOT";
                            txtOther.Text = "NOT SET";
                            btnFinish_Click(sender, e);
                        }
                        else
                        {
                            txtStep.Focus();
                            txtOptical2.Text = "NOT";
                            lblbuoc.Text = "Others";
                            lbTBID.Text = "Bạn Scan bước Other!";
                        }
                    }
                }
                else
                {
                    ListViewItem itm = new ListViewItem(txtStep.Text.ToString());
                    listView1.Items.Add(itm);

                    if (txtStep.Text.Length >= 5)
                    {

                        if (CountOptical == 0)
                        {
                            Optical_Temp += txtStep.Text.ToUpper();
                        }
                        else
                        {
                            Optical_Temp += ";" + txtStep.Text.ToUpper();
                        }
                        CountOptical += 1;
                        //txtPCBID2.Focus();
                        if (CountOptical == Optical2Qty)
                        {
                            // ========= Kiểm tra Master Optical ===============
                            bool Check_Optical_Master = false;

                            //var dtMaster = DataConn.DataTable_Sql(" SELECT OPTICAL_CODE FROM [PROJECTOR_TRACE].[dbo].[TBL_OPTICAL_MASTER] WHERE MODEL_NAME = '" + txtModelName.Text.Trim() + "'   ");
                            var dtMaster = DataConn.StoreFillDS("ChecMasterOptical", System.Data.CommandType.StoredProcedure, txtModelCode.Text, typeoptical);
                            if (dtMaster.Rows.Count > 0)
                            {
                                string values_master = dtMaster.Rows[0][0].ToString();

                                string[] arrOptical1 = new string[200];
                                string ReadOptical1 = Optical_Temp;
                                string[] values = ReadOptical1.Trim().Split(';');
                                //var count_pt = ReadOptical1.Contains(';');


                                //phong edit 2022 - kiem tra ma optical theo code moi
                                if (dtMaster.Rows[0][2].ToString() == "Y")
                                {
                                    //model co optical khac khong theo rule cu
                                    for (int i = 0; i < CountOptical; i++)
                                    {
                                        //lay phan tu dau tien cua ma optical  //1XY1FRQ50BU7 202112240003
                                        var vals = values[i].Split(' ')[0];
                                        if (vals == values_master)
                                        {
                                            Check_Optical_Master = true;
                                        }
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < CountOptical; i++)
                                    {
                                        if (values[i] == values_master)
                                        {
                                            Check_Optical_Master = true;
                                        }
                                    }
                                }
                                // ========= END Ktra Optical ======================
                                if (Check_Optical_Master == true)
                                {
                                    txtStep.Text = "";
                                    txtOptical2.Text = Optical_Temp;
                                    Optical_Temp = "";
                                    CountOptical = 0;
                                    lbTBID.Text = "";
                                    txtOptical2.Enabled = false;

                                    lbTBID.Text = "Bạn đã kết thúc bước scan Optical: 2";
                                    lbThongbao.Text = "";

                                    if (cbCheckAgain.Checked == false)
                                    {
                                        txtOther.Text = "NOT";
                                    }
                                    else
                                    {
                                        if (txtOther.Text == "")
                                        {
                                            txtOther.Text = "NOT";
                                        }
                                        else
                                        {
                                            txtOther.Text = txtOther.Text.ToString();
                                        }
                                    }
                                    btnFinish_Click(sender, e);

                                    //if (OtherQty == 0)   
                                    //{
                                    //    txtOther.Text = "NOT SET";
                                    //    btnFinish_Click(sender, e);
                                    //}
                                    //else
                                    //{
                                    //    txtStep.Text = "";
                                    //    txtStep.Focus();
                                    //    lblbuoc.Text = "Others";
                                    //}



                                    Optical_Temp = "";
                                    listView1.Clear();
                                }
                                else
                                {
                                    lbThongbao.Text = " Optical2 đã lắp không khớp với Master";
                                    lbThongbao.ForeColor = Color.Yellow;
                                    lbThongbao.BackColor = Color.Red;
                                    txtStep.Text = "";
                                    txtStep.Focus();
                                    CountOptical = 0;
                                    lbTBID.Text = "";
                                    frmConfrim _frmConfirm = new frmConfrim("Optical2 đã lắp không khớp với Master \n Master => " + dtOptic.Rows[0][0].ToString() + " ");
                                    _frmConfirm.ShowDialog();
                                    Optical_Temp = "";
                                    listView1.Clear();

                                }
                            }
                            else
                            {
                                lbThongbao.Text = "Model chưa thiết lập Optical 2 Master...";
                                lbThongbao.ForeColor = Color.Yellow;
                                lbThongbao.BackColor = Color.Red;
                                txtStep.Text = "";
                                txtStep.Focus();
                                CountOptical = 0;
                                lbTBID.Text = "";
                                frmConfrim _frmConfirm = new frmConfrim("Model chưa thiết lập Optical 2 Master...");
                                _frmConfirm.ShowDialog();
                                Optical_Temp = "";
                                listView1.Clear();
                            }
                        }
                        else
                        {
                            txtStep.Text = "";
                            txtStep.SelectAll();
                            lbTBID.Text = "Hãy Scan cụm Optical 2  thứ: " + (CountOptical + 1);
                            lbThongbao.Text = "";
                        }
                    }
                    else
                    {
                        lbThongbao.Text = "Optical 2 ID không đúng định dạng...";
                        lbThongbao.ForeColor = Color.Yellow;
                        lbThongbao.BackColor = Color.Red;
                        txtStep.SelectAll();
                        Optical_Temp = "";

                    }
                }
            }
        }

        private void txtLen_KeyPress(object sender, KeyPressEventArgs e)
        {
            var dtlen = DataConn.StoreFillDS("Check_len", System.Data.CommandType.StoredProcedure, txtModelCode.Text);
            if (dtlen.Rows.Count > 0)
            {
                gridMaster.DataSource = dtlen;
            }
            else
            {
                gridMaster.DataSource = dtlen;
            }
            if (e.KeyChar == 13)
            {
                if (txtStep.Text == "NOT")
                {
                    //****ty phai quay lai doan nay
                    // check trong mater xem Model nay co trong danh sach khong. Neu co khong phep scan Not
                    var checklen = DataConn.StoreFillDS("Check_NOT_len", System.Data.CommandType.StoredProcedure, txtModelCode.Text);
                    if (int.Parse(checklen.Rows[0][0].ToString()) > 0)
                    {
                        //MessageBox.Show("Ban khong duoc phep ban NOT!");
                        txtStep.Text = "";
                        txtStep.Focus();
                        lblbuoc.Text = "LEN";
                        lbTBID.Text = "Hãy scan Lại bước => LEN!";
                        lbThongbao.Text = "Model này không được scan NOT!";
                    }
                    else
                    {
                        txtLen.Text = "NOT";
                        txtStep.Text = "";
                        txtStep.Focus();

                        lblbuoc.Text = "Optical1";  //Neu la NOT quay lai scan tiep san pham moi
                        lbTBID.Text = "Hãy scan tiếp Sản phẩm tiếp theo => Optical 1!";
                        lbThongbao.Text = "";
                        btnFinish_Click(sender, e);
                    }

                    //if (int.Parse(txtOpticalQty2.Text.ToString()) == 0)
                    //{
                    //    //kiem tra truong Other co setting thi check else save data
                    //    if (int.Parse(txtOtherQty.Text.ToString()) == 0)
                    //    {
                    //        txtLen.Text = "NOT";
                    //        txtOptical2.Text = "NOT";
                    //        txtStep.Focus();
                    //        btnFinish_Click(sender, e);
                    //    }
                    //    else
                    //    {
                    //        txtLen.Text = "NOT";
                    //        txtOptical2.Text = "NOT";
                    //        txtStep.Focus();
                    //        lblbuoc.Text = "Others";
                    //        lbTBID.Text = "Hãy scan step tiếp theo => Others!";
                    //        lbThongbao.Text = "";
                    //    }

                    //}
                    //else
                    //{
                    //    txtLen.Text = "NOT";
                    //    txtStep.Text = "";
                    //    txtStep.Focus();
                    //    lblbuoc.Text = "Optical2";
                    //    lbTBID.Text = "Hãy scan step tiếp theo => Optical 2!";
                    //    lbThongbao.Text = "";
                    //}
                }
                else
                {
                    ListViewItem itm = new ListViewItem(txtStep.Text.ToString());
                    listView1.Items.Add(itm);

                    if (txtStep.Text != "" && txtStep.Text.Length >= 10)
                    {
                        if (CountLenQty == 0)
                        {
                            LEN_Temp += txtStep.Text.ToUpper();
                        }
                        else
                        {
                            LEN_Temp += ";" + txtStep.Text.ToUpper();
                        }
                        CountLenQty += 1;
                        //txtPCBID2.Focus();
                        if (CountLenQty == LenQty)
                        {
                            // ========= Kiểm tra LEN Optical ===============
                            bool Check_Optical_Master = false;
                            var dtMaster = DataConn.DataTable_Sql(" SELECT LEN_CODE FROM [PROJECTOR_TRACE].[dbo].[TBL_LEN_MASTER] WHERE MODEL_NAME = '" + txtModelName.Text.Trim() + "'   ");
                            if (dtMaster.Rows.Count > 0)
                            {
                                string values_master = dtMaster.Rows[0][0].ToString();

                                string[] arrOptical1 = new string[200];
                                string ReadOptical1 = LEN_Temp;
                                string[] values = ReadOptical1.Trim().Split(';');
                                //var count_pt = ReadOptical1.Contains(';');
                                for (int i = 0; i < LenQty; i++)
                                {
                                    if (values[i] == values_master)
                                    {
                                        Check_Optical_Master = true;
                                    }
                                }
                                // ========= END Ktra LEN ======================
                                if (Check_Optical_Master == true)
                                {
                                    txtStep.Text = "";
                                    txtLen.Text = LEN_Temp;
                                    LEN_Temp = "";
                                    CountLenQty = 0;
                                    lbTBID.Text = "";
                                    txtStep.Focus();
                                    txtLen.Enabled = false;

                                    lbTBID.Text = "Bạn đã scan xong bước LEN!";
                                    //lbTBID.Text = "Hãy scan step tiếp theo => Optical 2!";
                                    lbThongbao.Text = "";

                                    if (cbCheckAgain.Checked == false)
                                    {
                                        txtOptical2.Text = "NOT";
                                        txtOther.Text = "NOT";
                                    }
                                    else
                                    {
                                        if (txtOptical2.Text == "")
                                        {
                                            txtOptical2.Text = "NOT";
                                        }
                                        else
                                        {
                                            txtOptical2.Text = txtOptical2.Text.ToString();
                                        }
                                        if (txtOther.Text == "")
                                        {
                                            txtOther.Text = "NOT";
                                        }
                                        else
                                        {
                                            txtOther.Text = txtOther.Text.ToString();
                                        }
                                    }

                                    btnFinish_Click(sender, e);

                                    //if (txtOptical2.Text == "NOT" || txtOptical2.Text == "")
                                    //{
                                    //    txtStep.Focus();
                                    //    lblbuoc.Text = "Optical2";
                                    //}
                                    //else
                                    //{
                                    //    lblbuoc.Text = "Optical2";
                                    //}


                                    LEN_Temp = "";
                                    listView1.Clear();
                                }
                                else
                                {
                                    lbThongbao.Text = " Cụm LEN đã lắp không khớp với Master";
                                    lbThongbao.ForeColor = Color.Yellow;
                                    lbThongbao.BackColor = Color.Red;
                                    txtStep.Text = "";
                                    txtStep.Focus();
                                    CountLenQty = 0;
                                    lbTBID.Text = "";
                                    frmConfrim _frmConfirm = new frmConfrim("Cụm LEN đã lắp không khớp với Master \n Master => " + dtlen.Rows[0][1].ToString() + " ");
                                    _frmConfirm.ShowDialog();
                                    LEN_Temp = "";
                                    listView1.Clear();
                                }
                            }
                            else
                            {
                                lbThongbao.Text = "Model chưa thiết lập LEN Master...";
                                lbThongbao.ForeColor = Color.Yellow;
                                lbThongbao.BackColor = Color.Red;
                                txtStep.Text = "";
                                txtStep.Focus();
                                CountLenQty = 0;
                                lbTBID.Text = "";
                                frmConfrim _frmConfirm = new frmConfrim("Model chưa thiết lập LEN Master...");
                                _frmConfirm.ShowDialog();
                                LEN_Temp = "";
                                listView1.Clear();
                            }
                        }
                        else
                        {
                            txtStep.Text = "";
                            txtStep.SelectAll();
                            lbTBID.Text = "Hãy Scan cụm LEN thứ: " + (CountLenQty + 1);
                            lbThongbao.Text = "";
                        }
                    }
                    else
                    {
                        lbThongbao.Text = "LEN ID không đúng định dạng...";
                        lbThongbao.ForeColor = Color.Yellow;
                        lbThongbao.BackColor = Color.Red;
                        txtStep.SelectAll();
                        LEN_Temp = "";
                        //listView1.Clear();
                    }
                }
            }
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
                    PCBID_Temp += ";" + txtPCBID.Text.ToUpper();
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

            var dt = DataConn.StoreFillDS("List_serial_scan", CommandType.StoredProcedure, today_, linename);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 125;
                dataGridView1.Columns[1].Width = 90;
                dataGridView1.Columns[2].Width = 90;
                //dataGridView1.Columns[3].Width = 90;
                //dataGridView1.Columns[4].Width = 70;
            }


            var dt1 = DataConn.StoreFillDS("Get_Step_Assy", CommandType.StoredProcedure);
            if (dt1.Rows.Count > 0)
            {
                cbStep.DataSource = dt1;
                cbStep.DisplayMember = "nameproccess";
                cbStep.ValueMember = "step";
            }

        }

        private void cbCheckAgain_CheckedChanged(object sender, EventArgs e)
        {
            //groupBox4.Visible = true;
            if (cbCheckAgain.Checked == true)
            {
                rbPCBID.Visible = true;
                rbOptical1.Visible = true;
                rbOptical2.Visible = true;
                rbLEN.Visible = true;

                rbPCBID.Checked = true;
            }
            else
            {
                rbPCBID.Visible = false;
                rbOptical1.Visible = false;
                rbOptical2.Visible = false;
                rbLEN.Visible = false;
            }

        }

        private int PingToServer()
        {
            if (DataConn.PingToAddress("192.168.128.1"))
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
            if (ckOffline.Checked == true)
            {
                lbOffline.Visible = true;
            }
            Load_Gird();
            lbQtyToday.Text = Count_Total_VS().ToString();
        }

        private void txtKittingList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
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
            if (e.KeyChar == 13)
            {
                if (txtOther.Text == "NOT SET" || txtOther.Text == "NOT")
                {
                    btnFinish_Click(sender, e);
                }
                else
                {
                    if (int.Parse(txtOtherQty.Text.ToString()) == 0)
                    {
                        btnFinish_Click(sender, e);
                    }
                    else
                    {
                        ListViewItem itm = new ListViewItem(txtStep.Text.ToString());
                        listView1.Items.Add(itm);

                        if (txtStep.Text != "" && txtStep.Text.Length >= 10)
                        {
                            if (CountOther == 0)
                            {
                                OtherTemp += txtStep.Text.ToUpper();
                            }
                            else
                            {
                                OtherTemp += ";" + txtStep.Text.ToUpper();
                            }
                            CountOther += 1;
                            //txtPCBID2.Focus();
                            if (CountOther == OtherQty)
                            {
                                txtStep.Text = "";
                                txtOther.Text = OtherTemp;
                                OtherTemp = "";
                                CountOther = 0;
                                lbTBID.Text = "";
                                btnFinish_Click(sender, e);
                            }
                            else
                            {
                                txtStep.Text = "";
                                txtStep.SelectAll();
                                lbTBID.Text = "Hãy Scan Cụm khác thứ: " + (CountOther + 1);
                                lbThongbao.Text = "";
                            }
                        }
                        else
                        {
                            lbThongbao.Text = "Cụm khác không đúng định dạng...";
                            lbThongbao.ForeColor = Color.Yellow;
                            lbThongbao.BackColor = Color.Red;
                            txtStep.SelectAll();
                        }
                    }

                }
            }

        }
        private void txtStep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtTempSerial.Text.ToString() == "")
                {
                    MessageBox.Show("Bạn chưa Scan Tempory Serial!");
                    txtTempSerial.Focus();
                    txtTempSerial.SelectAll();
                    txtStep.Text = "";
                }
                else
                {
                    if (lblbuoc.Text.ToString() == "PCBID") //thuc hien step 1  "PCBID"
                    {
                        txtPCBID_KeyPress(sender, e);
                    }
                    else if (lblbuoc.Text.ToString() == "Optical1") //thuc hien step 2  "Optical1"
                    {
                        txtOptic_KeyPress(sender, e);
                    }
                    else if (lblbuoc.Text.ToString() == "LEN") //thuc hien buoc 3   "LEN"
                    {
                        txtLen_KeyPress(sender, e);
                    }
                    else if (lblbuoc.Text.ToString() == "Optical2") //thuc hien buoc 4    "Optical2"
                    {
                        txtOptical2_KeyPress(sender, e);
                        cbStep.Text = "Optical2";
                    }
                    else
                    {
                        txtOther_KeyPress(sender, e); //thuc hien buoc 5
                    }


                }
            }
        }

        private void txtPCBID_OLD_KeyPress(object sender, KeyPressEventArgs e)
        {
            var dtpcb = DataConn.StoreFillDS("Check_PCB", System.Data.CommandType.StoredProcedure, txtModelCode.Text);
            string pcb = "";
            if (dtpcb.Rows.Count > 0)
            {
                for (int i = 0; i < dtpcb.Rows.Count; i++)
                {
                    pcb += dtpcb.Rows[i][1].ToString() + " - ";
                }
                gridMaster.DataSource = dtpcb;
            }
            else
            {
                gridMaster.DataSource = dtpcb;
            }
            if (e.KeyChar == 13)
            {
                if (txtPCBID.Text == "NOT")
                {
                    txtPCBID.Focus();
                    if (PCBQty == 0)
                    {
                        txtPCBID.Text = "NOT SET";
                        //btnFinish_Click(sender, e);
                        txtLen.Focus();
                    }
                }
                else
                {
                    ListViewItem itm = new ListViewItem(txtPCBID.Text.ToString());
                    listView1.Items.Add(itm);

                    if (txtPCBID.Text != "" && txtPCBID.Text.Length >= 10)
                    {
                        if (CountPCBQty == 0)
                        {
                            PCBID_Temp = txtPCBID.Text.ToUpper();
                        }
                        else
                        {
                            PCBID_Temp += ";" + txtPCBID.Text.ToUpper();
                        }
                        CountPCBQty += 1;
                        //txtPCBID2.Focus();
                        if (CountPCBQty == PCBQty)
                        {
                            //txtPCBID.Text = "";
                            //txtPCBID.Text = PCBID_Temp;
                            //PCBID_Temp = "";
                            //CountPCBQty = 0;
                            //lbTBID.Text = "";
                            //txtPCBID.Enabled = false;
                            //lbTBID.Text = "Hãy scan cụm LEN thứ: 1";
                            //lbThongbao.Text = "";
                            //if (txtLen.Text == "NOT" || txtLen.Text == "")
                            //{
                            //    txtLen.Focus();
                            //}
                            //else
                            //{
                            //}
                            // ========= Kiểm tra Master Optical ===============
                            bool Check_Optical_Master = false;
                            var dtMaster = DataConn.DataTable_Sql(" SELECT PCB_CODE FROM [PROJECTOR_TRACE].[dbo].[TBL_PCB_MASTER] WHERE MODEL_code = '" + txtModelName.Text.Trim() + "' ");
                            if (dtMaster.Rows.Count > 0)
                            {
                                string values_master = "";

                                string[] arrOptical1 = new string[200];
                                string ReadOptical1 = PCBID_Temp;
                                string[] values = ReadOptical1.Trim().Split(';');
                                //var count_pt = ReadOptical1.Contains(';');
                                for (int i = 0; i < CountPCBQty; i++)
                                {
                                    for (int j = 0; j < dtMaster.Rows.Count; j++)
                                    {
                                        values_master = dtMaster.Rows[j][0].ToString();
                                        if (values[i].Substring(0, 2) == values_master)
                                        {
                                            Check_Optical_Master = true;
                                        }
                                    }

                                }
                                // ========= END Ktra Optical ======================
                                if (Check_Optical_Master == true)
                                {
                                    txtPCBID.Text = "";
                                    txtPCBID.Text = PCBID_Temp;
                                    PCBID_Temp = "";
                                    CountPCBQty = 0;
                                    lbTBID.Text = "";
                                    txtPCBID.Enabled = false;
                                    lbTBID.Text = "Hãy scan cụm LEN thứ: 1";
                                    lbThongbao.Text = "";
                                    if (txtLen.Text == "NOT" || txtLen.Text == "")
                                    {
                                        txtLen.Focus();
                                    }
                                    else
                                    {
                                    }
                                    listView1.Clear();
                                }
                                else
                                {
                                    lbThongbao.Text = " PCB đã lắp không khớp với Master";
                                    lbThongbao.ForeColor = Color.Yellow;
                                    lbThongbao.BackColor = Color.Red;
                                    txtPCBID.Text = "";
                                    txtPCBID.Focus();
                                    CountPCBQty = 0;
                                    lbTBID.Text = "";
                                    frmConfrim _frmConfirm = new frmConfrim("PCB đã lắp không khớp với Master \n Master Code => " + pcb + "");
                                    _frmConfirm.ShowDialog();
                                    PCBID_Temp = "";
                                    listView1.Clear();
                                }
                            }
                            else
                            {
                                lbThongbao.Text = "Model chưa thiết lập PCB Master...";
                                lbThongbao.ForeColor = Color.Yellow;
                                lbThongbao.BackColor = Color.Red;
                                txtPCBID.Text = "";
                                txtPCBID.Focus();
                                CountPCBQty = 0;
                                lbTBID.Text = "";
                                frmConfrim _frmConfirm = new frmConfrim("Model chưa thiết lập PCB Master...");
                                _frmConfirm.ShowDialog();
                                PCBID_Temp = "";
                                listView1.Clear();
                            }
                        }
                        else
                        {
                            txtPCBID.Text = "";
                            txtPCBID.SelectAll();
                            lbTBID.Text = "Hãy Scan cụm PCB thứ: " + (CountPCBQty + 1);
                            lbThongbao.Text = "";
                        }
                    }
                    else
                    {
                        lbThongbao.Text = "Cụm PCB không đúng định dạng...";
                        lbThongbao.ForeColor = Color.Yellow;
                        lbThongbao.BackColor = Color.Red;
                        txtPCBID.SelectAll();
                        //listView1.Clear();
                    }
                }
            }
        }
        private void txtPCBID_KeyPress(object sender, KeyPressEventArgs e)
        {
            var dtpcb = DataConn.StoreFillDS("Check_PCB", System.Data.CommandType.StoredProcedure, txtModelCode.Text);
            string pcb = "";
            if (dtpcb.Rows.Count > 0)
            {
                for (int i = 0; i < dtpcb.Rows.Count; i++)
                {
                    pcb += dtpcb.Rows[i][1].ToString() + " - ";
                }
                gridMaster.DataSource = dtpcb;
            }
            else
            {
                gridMaster.DataSource = dtpcb;
            }


            if (e.KeyChar == 13)
            {
                if (txtStep.Text == "NOTCHECK")  //Khong cho ban NOT
                {
                    if (int.Parse(txtOpticalQty.Text.ToString()) == 0)
                    {
                        txtPCBID.Text = "NOT";
                        txtOptic.Text = "NOT";
                        txtStep.Focus();
                        lblbuoc.Text = "LEN";
                        lbTBID.Text = "Hãy scan step tiếp theo => LEN!";
                    }
                    else
                    {
                        txtPCBID.Text = "NOT";
                        txtStep.Text = "";
                        txtStep.Focus();
                        lblbuoc.Text = "Optical1";
                        lbTBID.Text = "Hãy scan step tiếp theo => Optical 1!";
                    }
                }
                else
                {
                    ListViewItem itm = new ListViewItem(txtStep.Text.ToString());
                    listView1.Items.Add(itm);

                    if (txtStep.Text != "" && txtStep.Text.Length >= 10)
                    {
                        if (CountPCBQty == 0)
                        {
                            PCBID_Temp = txtStep.Text.ToUpper();
                        }
                        else
                        {
                            PCBID_Temp += ";" + txtStep.Text.ToUpper();
                        }
                        CountPCBQty += 1;
                        //txtPCBID2.Focus();
                        if (CountPCBQty == PCBQty)
                        {

                            // ========= Kiểm tra Master Optical ===============
                            bool Check_Optical_Master = false;
                            bool Check_pcb_trace = false;
                            var dtMaster = DataConn.DataTable_Sql(" SELECT PCB_CODE FROM [PROJECTOR_TRACE].[dbo].[TBL_PCB_MASTER] WHERE MODEL_code = '" + txtModelName.Text.Trim() + "' ");
                            if (dtMaster.Rows.Count > 0)
                            {
                                string values_master = "";

                                string[] arrOptical1 = new string[200];
                                string ReadOptical1 = PCBID_Temp;
                                string[] values = ReadOptical1.Trim().Split(';');
                                //var count_pt = ReadOptical1.Contains(';');
                                for (int i = 0; i < CountPCBQty; i++)
                                {
                                    for (int j = 0; j < dtMaster.Rows.Count; j++)
                                    {
                                        values_master = dtMaster.Rows[j][0].ToString();
                                        if (values[i].Substring(0, 2) == values_master)
                                        {
                                            Check_Optical_Master = true;
                                        }
                                    }

                                }


                                for (int i = 0; i < CountPCBQty; i++)
                                {
                                    var dt = DataConn.FillStore("Check_PCB_Trace", CommandType.StoredProcedure, values[i]);
                                    if (dt.Rows.Count > 0)
                                    {
                                        Check_pcb_trace = true;
                                    }
                                }

                                if (!Check_pcb_trace)
                                {

                                    lbThongbao.Text = " PCB đã lắp chưa qua công đoạn FCT";
                                    lbThongbao.ForeColor = Color.Yellow;
                                    lbThongbao.BackColor = Color.Red;
                                    txtStep.Text = "";
                                    txtStep.Focus();
                                    CountPCBQty = 0;
                                    lbTBID.Text = "";
                                    frmConfrim _frmConfirm = new frmConfrim("PCB đã lắp chưa qua công đoạn FCT");
                                    _frmConfirm.ShowDialog();
                                    PCBID_Temp = "";
                                    listView1.Clear();
                                    return;

                                }

                                // ========= END Ktra Optical ======================
                                if (Check_Optical_Master == true)
                                {
                                    txtStep.Text = "";
                                    txtPCBID.Text = PCBID_Temp;
                                    PCBID_Temp = "";
                                    CountPCBQty = 0;
                                    lbTBID.Text = "";
                                    txtPCBID.Enabled = false;
                                    //lbTBID.Text = "Hãy scan bước tiep theo => Optical1!";
                                    lbTBID.Text = "Bạn đã san xong PCBID !";
                                    lbThongbao.Text = "";

                                    //Buoc 1: Optical1

                                    if (cbCheckAgain.Checked == false)
                                    {
                                        txtOptic.Text = "NOT";
                                        txtLen.Text = "NOT";
                                        txtOptical2.Text = "NOT";
                                        txtOther.Text = "NOT";
                                    }
                                    else
                                    {
                                        if (txtOptic.Text == "")
                                        {
                                            txtOptic.Text = "NOT";
                                        }
                                        else
                                        {
                                            txtOptic.Text = txtOptic.Text.ToString();
                                        }
                                        if (txtLen.Text == "")
                                        {
                                            txtLen.Text = "NOT";
                                        }
                                        else
                                        {
                                            txtLen.Text = txtLen.Text.ToString();
                                        }
                                        if (txtOptical2.Text == "")
                                        {
                                            txtOptical2.Text = "NOT";
                                        }
                                        else
                                        {
                                            txtOptical2.Text = txtOptical2.Text.ToString();
                                        }
                                        if (txtOther.Text == "")
                                        {
                                            txtOther.Text = "NOT";
                                        }
                                        else
                                        {
                                            txtOther.Text = txtOther.Text.ToString();
                                        }

                                    }
                                    btnFinish_Click(sender, e);

                                    // edit => buoc nao ghi buoc do
                                    //if (txtOptical.Text == "NOT" || txtOptical.Text == "")
                                    //{                                      
                                    //    txtStep.Focus();
                                    //    lblbuoc.Text = "Optical1";  //chuyen sang Optical1!
                                    //}
                                    //else
                                    //{
                                    //    lblbuoc.Text = "Optical1";  //chuyen sang Optical1!
                                    //}

                                    listView1.Clear();
                                }
                                else
                                {
                                    lbThongbao.Text = " PCB đã lắp không khớp với Master";
                                    lbThongbao.ForeColor = Color.Yellow;
                                    lbThongbao.BackColor = Color.Red;
                                    txtStep.Text = "";
                                    txtStep.Focus();
                                    CountPCBQty = 0;
                                    lbTBID.Text = "";
                                    frmConfrim _frmConfirm = new frmConfrim("PCB đã lắp không khớp với Master \n Master Code => " + pcb + "");
                                    _frmConfirm.ShowDialog();
                                    PCBID_Temp = "";
                                    listView1.Clear();
                                }
                            }
                            else
                            {
                                lbThongbao.Text = "Model chưa thiết lập PCB Master...";
                                lbThongbao.ForeColor = Color.Yellow;
                                lbThongbao.BackColor = Color.Red;
                                txtStep.Text = "";
                                txtStep.Focus();
                                CountPCBQty = 0;
                                lbTBID.Text = "";
                                frmConfrim _frmConfirm = new frmConfrim("Model chưa thiết lập PCB Master...");
                                _frmConfirm.ShowDialog();
                                PCBID_Temp = "";
                                listView1.Clear();
                            }
                        }
                        else
                        {
                            txtStep.Text = "";
                            txtStep.SelectAll();
                            lbTBID.Text = "Hãy Scan cụm PCB thứ: " + (CountPCBQty + 1);
                            lbThongbao.Text = "";
                        }
                    }
                    else
                    {
                        lbThongbao.Text = "Cụm PCB không đúng định dạng...";
                        lbThongbao.ForeColor = Color.Yellow;
                        lbThongbao.BackColor = Color.Red;
                        txtStep.SelectAll();
                        //listView1.Clear();
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
        //protected void loadOptic()
        //{
        //    var dtOptic = DataConn.StoreFillDS("Check_optic", System.Data.CommandType.StoredProcedure, txtModelCode.Text);
        //    if (dtOptic.Rows.Count > 0)
        //    {
        //        gridMaster.DataSource = dtOptic;
        //    }
        //}
        private void txtOptic_OLD_KeyPress(object sender, KeyPressEventArgs e)

        {
            if (e.KeyChar == 13)
            {
                //Optical_Temp = "";
                //load Master
                var dtOptic = DataConn.StoreFillDS("ChecMasterOptical", System.Data.CommandType.StoredProcedure, txtModelCode.Text, "1");
                if (dtOptic.Rows.Count > 0)
                {
                    gridMaster.DataSource = dtOptic;
                }
                else
                {
                    gridMaster.DataSource = dtOptic;
                }
                if (txtOptic.Text == "NOT")
                {
                    txtOptical2.Focus();
                }
                else
                {
                    ListViewItem itm = new ListViewItem(txtOptic.Text.ToString());
                    listView1.Items.Add(itm);

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
                            // ========= Kiểm tra Master Optical ===============
                            bool Check_Optical_Master = false;
                            var dtMaster = DataConn.StoreFillDS("ChecMasterOptical", CommandType.StoredProcedure, txtModelCode.Text, "1");
                            if (dtMaster.Rows.Count > 0)
                            {
                                string values_master = dtMaster.Rows[0][0].ToString();

                                string[] arrOptical1 = new string[200];
                                string ReadOptical1 = Optical_Temp;
                                string[] values = ReadOptical1.Trim().Split(';');
                                //var count_pt = ReadOptical1.Contains(';');
                                for (int i = 0; i < CountOptical; i++)
                                {
                                    if (values[i] == values_master)
                                    {
                                        Check_Optical_Master = true;
                                    }
                                }
                                // ========= END Ktra Optical ======================
                                if (Check_Optical_Master == true)
                                {
                                    txtOptic.Text = "";
                                    txtOptic.Text = Optical_Temp;
                                    Optical_Temp = "";
                                    CountOptical = 0;
                                    lbTBID.Text = "";
                                    txtOptic.Enabled = false;
                                    lbTBID.Text = "Hãy scan Optical ID thứ: 1";
                                    lbThongbao.Text = "";
                                    if (txtOptical2.Text == "NOT" || txtOptical2.Text == "")
                                    {
                                        txtOptical2.Focus();
                                    }
                                    else if (txtPCBID.Text == "NOT" || txtPCBID.Text == "") //minh(1)
                                    {
                                        txtPCBID.Focus();
                                        txtPCBID.SelectAll();
                                    }
                                    else if (txtLen.Text == "NOT" || txtLen.Text == "")
                                    {
                                        txtLen.Focus();
                                        txtLen.SelectAll();
                                    }
                                    else { }
                                    Optical_Temp = "";
                                    listView1.Clear();
                                }
                                else
                                {
                                    lbThongbao.Text = " Optical đã lắp không khớp với Master";
                                    lbThongbao.ForeColor = Color.Yellow;
                                    lbThongbao.BackColor = Color.Red;
                                    txtOptic.Text = "";
                                    txtOptic.Focus();
                                    CountOptical = 0;
                                    lbTBID.Text = "";
                                    frmConfrim _frmConfirm = new frmConfrim("Optical đã lắp không khớp với Master \n Master => " + dtOptic.Rows[0][0].ToString() + " ");
                                    _frmConfirm.ShowDialog();
                                    Optical_Temp = "";

                                    listView1.Clear();  //test
                                }
                            }
                            else
                            {
                                lbThongbao.Text = "Model chưa thiết lập Optical 1 Master...";
                                lbThongbao.ForeColor = Color.Yellow;
                                lbThongbao.BackColor = Color.Red;
                                txtOptic.Text = "";
                                txtOptic.Focus();
                                CountOptical = 0;
                                lbTBID.Text = "";
                                frmConfrim _frmConfirm = new frmConfrim("Model chưa thiết lập Optical 1 Master...");
                                _frmConfirm.ShowDialog();
                                listView1.Clear();
                                Optical_Temp = "";
                            }
                        }
                        else
                        {
                            txtOptic.Text = "";
                            txtOptic.SelectAll();
                            lbTBID.Text = "Hãy Scan cụm Optical thứ: " + (CountOptical + 1);
                            lbThongbao.Text = "";
                        }
                        // kiểm tra các phần tử có nằm trong Master hay không?

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
        private void txtOptic_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Optical_Temp = "";
            //load Master
            var dtOptic = DataConn.StoreFillDS("ChecMasterOptical", System.Data.CommandType.StoredProcedure, txtModelCode.Text, "1");
            if (dtOptic.Rows.Count > 0)
            {
                gridMaster.DataSource = dtOptic;
            }
            else
            {
                gridMaster.DataSource = dtOptic;
            }

            if (e.KeyChar == 13)
            {
                if (txtStep.Text == "NOTCHECK") //Khong cho ban NOT
                {
                    if (int.Parse(txtLenQty.Text.ToString()) == 0)
                    {
                        txtOptic.Text = "NOT";
                        txtLen.Text = "NOT";
                        txtStep.Focus();
                        lblbuoc.Text = "Optical2";
                        lbTBID.Text = "Hãy scan step tiếp theo => Optical2!";
                    }
                    else
                    {
                        txtOptic.Text = "NOT";
                        txtStep.Text = "";
                        txtStep.Focus();
                        lblbuoc.Text = "LEN";
                        lbTBID.Text = "Hãy scan step tiếp theo => LEN!";
                    }
                }
                else
                {
                    ListViewItem itm = new ListViewItem(txtStep.Text.ToString());
                    listView1.Items.Add(itm);

                    if (txtStep.Text.Length >= 5)
                    {
                        if (CountOptical == 0)
                        {
                            Optical_Temp += txtStep.Text.ToUpper();
                        }
                        else
                        {
                            Optical_Temp += ";" + txtStep.Text.ToUpper();
                        }
                        CountOptical += 1;
                        //txtPCBID2.Focus();

                        if (CountOptical == OpticalQty)
                        {
                            // ========= Kiểm tra Master Optical ===============
                            bool Check_Optical_Master = false;
                            bool Check_optical_trace = false;
                            //var dtMaster = DataConn.StoreFillDS("ChecMasterOptical", CommandType.StoredProcedure, txtModelCode.Text, "1");
                            var dtMaster = DataConn.StoreFillDS("ChecMasterOptical_new", CommandType.StoredProcedure, txtModelCode.Text, "1");
                            if (dtMaster.Rows.Count > 0)
                            {
                                string values_master = dtMaster.Rows[0][0].ToString();

                                string[] arrOptical1 = new string[200];
                                string ReadOptical1 = Optical_Temp;
                                string[] values = ReadOptical1.Trim().Split(';');
                                //var count_pt = ReadOptical1.Contains(';');

                                //minh edit 2022 - kiem tra ma optical theo code moi
                                if (dtMaster.Rows[0][2].ToString() == "Y")
                                {
                                    //model co optical khac khong theo rule cu
                                    for (int i = 0; i < CountOptical; i++)
                                    {
                                        //lay phan tu dau tien cua ma optical  //1XY1FRQ50BU7 202112240003
                                        var vals = values[i].Split(' ')[0];
                                        if (vals == values_master)
                                        {
                                            Check_Optical_Master = true;
                                        }
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < CountOptical; i++)
                                    {
                                        if (values[i] == values_master)
                                        {
                                            Check_Optical_Master = true;
                                        }
                                    }
                                }

                                for (int i = 0; i < CountOptical; i++)
                                {
                                    var dt = DataConn.FillStore("CheckFGOpticalExistence", CommandType.StoredProcedure, values[i]);
                                    if (dt.Rows[0][0].ToString() == "1")
                                    {
                                        Check_optical_trace = true;
                                    }
                                }

                                if (!Check_optical_trace)
                                {
                                    lbThongbao.Text = " Optical chưa qua công đoạn Trace Optical";
                                    lbThongbao.ForeColor = Color.Yellow;
                                    lbThongbao.BackColor = Color.Red;
                                    txtStep.Text = "";
                                    txtStep.Focus();
                                    CountOptical = 0;
                                    lbTBID.Text = "";
                                    frmConfrim _frmConfirm = new frmConfrim("Optical chưa qua công đoạn Trace Optical");
                                    _frmConfirm.ShowDialog();
                                    Optical_Temp = "";
                                    listView1.Clear();  //test
                                    return;

                                }




                                // ========= END Ktra Optical ======================
                                if (Check_Optical_Master == true)
                                {
                                    txtStep.Text = "";
                                    txtOptic.Text = Optical_Temp;
                                    Optical_Temp = "";
                                    CountOptical = 0;
                                    lbTBID.Text = "";
                                    txtOptic.Enabled = false;
                                    lbTBID.Text = "Bạn đã scan xong bước txtOptical 1 !";
                                    //lbTBID.Text = "Hãy scan step tiếp theo => LEN!" ;
                                    lbThongbao.Text = "";

                                    if (cbCheckAgain.Checked == false)
                                    {
                                        txtLen.Text = "NOT";
                                        txtOptical2.Text = "NOT";
                                        txtOther.Text = "NOT";
                                    }
                                    else
                                    {
                                        if (txtLen.Text == "")
                                        {
                                            txtLen.Text = "NOT";
                                        }
                                        else
                                        {
                                            txtLen.Text = txtLen.Text.ToString();
                                        }
                                        if (txtOptical2.Text == "")
                                        {
                                            txtOptical2.Text = "NOT";
                                        }
                                        else
                                        {
                                            txtOptical2.Text = txtOptical2.Text.ToString();
                                        }
                                        if (txtOther.Text == "")
                                        {
                                            txtOther.Text = "NOT";
                                        }
                                        else
                                        {
                                            txtOther.Text = txtOther.Text.ToString();
                                        }
                                    }
                                    btnFinish_Click(sender, e);


                                    //if (txtLen.Text == "NOT" || txtLen.Text == "")
                                    //{
                                    //    txtStep.Focus();
                                    //    lblbuoc.Text = "LEN";
                                    //}
                                    //else
                                    //{
                                    //    lblbuoc.Text = "LEN";
                                    //}

                                    Optical_Temp = "";
                                    listView1.Clear();
                                }
                                else
                                {
                                    lbThongbao.Text = " Optical đã lắp không khớp với Master";
                                    lbThongbao.ForeColor = Color.Yellow;
                                    lbThongbao.BackColor = Color.Red;
                                    txtStep.Text = "";
                                    txtStep.Focus();
                                    CountOptical = 0;
                                    lbTBID.Text = "";
                                    frmConfrim _frmConfirm = new frmConfrim("Optical đã lắp không khớp với Master \n Master => " + dtOptic.Rows[0][0].ToString() + " ");
                                    _frmConfirm.ShowDialog();
                                    Optical_Temp = "";

                                    listView1.Clear();  //test
                                }
                            }
                            else
                            {
                                lbThongbao.Text = "Model chưa thiết lập Optical 1 Master...";
                                lbThongbao.ForeColor = Color.Yellow;
                                lbThongbao.BackColor = Color.Red;
                                txtStep.Text = "";
                                txtStep.Focus();
                                CountOptical = 0;
                                lbTBID.Text = "";
                                frmConfrim _frmConfirm = new frmConfrim("Model chưa thiết lập Optical 1 Master...");
                                _frmConfirm.ShowDialog();
                                listView1.Clear();
                                Optical_Temp = "";
                            }
                        }
                        else
                        {
                            txtStep.Text = "";
                            txtStep.SelectAll();
                            lbTBID.Text = "Hãy Scan cụm Optical 1 thứ: " + (CountOptical + 1);
                            lbThongbao.Text = "";
                        }
                        // kiểm tra các phần tử có nằm trong Master hay không?

                    }
                    else
                    {
                        lbThongbao.Text = "Optical ID không đúng định dạng...";
                        lbThongbao.ForeColor = Color.Yellow;
                        lbThongbao.BackColor = Color.Red;
                        txtStep.SelectAll();
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
            if (cbCheckAgain.Checked == true)
            {
                scanagain = 1;
            }
            else
            {
                scanagain = 0;
            }
            if (txtTempSerial.Text == "" || txtPCBID.Text == "" || txtOptic.Text == "" || txtKittingList.Text == "" || txtOther.Text == "")
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
                            if (dt1.Rows.Count > 0)
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
            lbQtyToday.Text = Count_Total_VS().ToString();
        }
    }
}
