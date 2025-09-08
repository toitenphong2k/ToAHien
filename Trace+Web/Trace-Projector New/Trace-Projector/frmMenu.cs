//=================== Version history ===========================//
// v1.0: Form Main for assy2: Fix scan of field
// v1.1: Form Main for assy2: Dynamic scan of field
// v1.2: Add Form for assy4
// v1.3: 
// 2020-01-09: HienIT -Add Form Model Setting
// 20120-01-21: HienIT - Add Count Qty, Add From Visual check 2
// 2020-07-17: HienIT 
// - Add Form 3Parts v2: Check Master:  Optical1,2, PCB, Len
// - Add Check version when loading Main menu
// 2020-07-17: HienIT 
// - aDD list view
// 
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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void assy2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMain frm_Main = new frmMain();
            frm_Main.ShowDialog();
        }

        private void assy4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdjust frm_assy4 = new frmAdjust();
            frm_assy4.ShowDialog();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

           // check version                      
            //frmLogin frm = new frmLogin();
            //MdiParent = this;
            //frm.Activate();
            //frm.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
                Environment.Exit(0);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void đăngKíModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModelSetting frm_model = new frmModelSetting();
            frm_model.ShowDialog();
        }

        //private void assy3PartsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frm3Part frm_3part = new frm3Part();
        //    frm_3part.ShowDialog();
        //}

        private void visualCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVisualCheck frm_visual = new FrmVisualCheck();
            frm_visual.ShowDialog();
        }

        private void accessoriesCheckingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmaccessory _frm_access = new frmaccessory();
            _frm_access.ShowDialog();
        }

        private void accessoriesSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccessories_setting _frm_access_setting = new frmAccessories_setting();
            _frm_access_setting.ShowDialog();
        }

        private void testCOMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestCOM _frmTestCom = new frmTestCOM();
            _frmTestCom.ShowDialog();
        }

        private void accessoriesCheck2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmaccessory2 _frm_access2 = new frmaccessory2();
            _frm_access2.ShowDialog();
        }

        private void accessories1SettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModelAccessories _frm_access_model = new frmModelAccessories();
            _frm_access_model.ShowDialog();
        }

        private void visualCheck2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVisualCheck2 _frmvscheck2 = new FrmVisualCheck2();
            _frmvscheck2.ShowDialog();
        }

        private void assyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHistory _frmHistory = new frmHistory();
            _frmHistory.ShowDialog();
        }

        private void assy3PartsV2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm3PartV2 _frm3PartV2 = new frm3PartV2();
            _frm3PartV2.ShowDialog();
        }

        private void materCheckLenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string type = "NOTLEN";
            frmLogin login = new frmLogin(type);            
            login.ShowDialog();
            
            //frmMaterCheckNotLen frmckLen = new frmMaterCheckNotLen();
            //frmckLen.ShowDialog();
        }

        private void materCheckOptical2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string type = "NOTOP2";
            frmLogin login = new frmLogin(type);
            login.ShowDialog();

            //frmMaterCheckNotOptical2 frmckop2 = new frmMaterCheckNotOptical2();
            //frmckop2.ShowDialog();
        }

        private void materToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string type = "accessories";
            frmLogin login = new frmLogin(type);
            login.ShowDialog();

            //frmMaterAccessories assecc = new frmMaterAccessories();
            //assecc.ShowDialog();
        }
        private void materPCBIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string type = "PCBID";
            frmLogin login = new frmLogin(type);
            login.ShowDialog();

            //frmMaterPCBID pcbid = new frmMaterPCBID();
            //pcbid.ShowDialog();
        }

        private void materOpticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string type = "optical";
            frmLogin login = new frmLogin(type);
            login.ShowDialog();

            //frmMaterOptical otical = new frmMaterOptical();
            //otical.ShowDialog();
        }

        private void materLenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string type = "LEN";
            frmLogin login = new frmLogin(type);
            login.ShowDialog();

            //frmMaterLen len = new frmMaterLen();
            //len.ShowDialog();
        }

        private void masterFCTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string type = "FCT";
            frmLogin login = new frmLogin(type);
            login.ShowDialog();
        }

        private void masterAddNewModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string type = "newmodel";
            frmLogin addmodel = new frmLogin(type);
            addmodel.ShowDialog();
        }


    }
}
