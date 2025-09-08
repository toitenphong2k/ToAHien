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
    public partial class frmLogin : Form
    {
        public frmLogin(string _type)
        {
            InitializeComponent();
            lbltype.Text = _type;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void btSave_Click(object sender, EventArgs e)
        {
            string userid = txtUser.Text.ToString();
            string pass = txtPass.Text.ToString();

            var dt = DataConn.StoreFillDS("Check_Login", CommandType.StoredProcedure, userid, pass);
            if (int.Parse(dt.Rows[0][0].ToString()) > 0)
            {
                //MessageBox.Show("dang nhap thanh cong:  " );

               
                this.Visible = false;
                this.Hide();                

                if (lbltype.Text== "NOTLEN")
                {
                    frmMaterCheckNotLen frmckLen = new frmMaterCheckNotLen();
                    frmckLen.ShowDialog();
                }
                else if(lbltype.Text == "NOTOP2")
                {
                    frmMaterCheckNotOptical2 op2 = new frmMaterCheckNotOptical2();
                    op2.ShowDialog();
                }
                else if (lbltype.Text == "accessories")
                {
                    frmMaterAccessories assecc = new frmMaterAccessories();
                    assecc.ShowDialog();
                }
                else if (lbltype.Text == "PCBID")
                {
                    frmMaterPCBID pcbid = new frmMaterPCBID();
                    pcbid.ShowDialog();
                }
                else if (lbltype.Text == "optical")
                {
                    frmMaterOptical otical = new frmMaterOptical();
                    otical.ShowDialog();
                }
                else if (lbltype.Text == "LEN")
                {
                    frmMaterLen len = new frmMaterLen();
                    len.ShowDialog();
                }

                if (lbltype.Text == "FCT")
                {
                    frmMaterFCT frmFCT = new frmMaterFCT();
                    frmFCT.ShowDialog();
                }

                if (lbltype.Text == "newmodel")
                {
                    frmAddNewModel admodel = new frmAddNewModel();
                    admodel.ShowDialog();
                }





                //Control[] controls = this.MdiParent.Controls.Find("menuStrip1", true);
                //foreach (Control ctrl in controls)
                //{
                //    if (ctrl.Name == "menuStrip1")
                //    {
                //        MenuStrip strip = ctrl as MenuStrip;
                //        strip.Items["materCheckLenToolStripMenuItem"].Enabled = true;
                //        strip.Items["materCheckOptical2ToolStripMenuItem"].Enabled = true;
                //    }
                //}




            }
            else
            {
                MessageBox.Show("Bạn không có quyền !:  ");
            }

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            txtUser.Text = "";
            txtUser.Focus();


            //Control[] controls = this.MdiParent.Controls.Find("menuStrip1", true);
           
            //foreach (Control ctrl in controls)
            //{
            //    if (ctrl.Name == "menuStrip1")
            //    {
            //        MenuStrip strip = ctrl as MenuStrip;
            //        strip.Items["materCheckLenToolStripMenuItem"].Enabled = false;
            //        strip.Items["materCheckOptical2ToolStripMenuItem"].Enabled = false;
            //    }
            //}
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            txtPass.Text = "";
            txtUser.Text = "";
            txtUser.Focus();
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btSave_Click(sender, e);
            }
        }
    }
}
