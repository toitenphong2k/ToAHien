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
    public partial class frmConfrimLD : Form
    {
        //public frmConfrim()
        //{
        //    InitializeComponent();
        //}
        string str_error;
        string strPass ;


        public frmConfrimLD(string error)
        {
            str_error = error;
            InitializeComponent();
        }
        private void frmConfrim_Load(object sender, EventArgs e)
        {
            if (str_error.Trim() == "" || str_error.Trim() is null)
            {
                label1.Text = "Error, Can not get value.......";
            }
            else
            {
                label1.Text = str_error;
                textBox1.Text = "";
                textBox1.Focus();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                var dt = DataConn.StoreFillDS("GetLeaderCode", CommandType.StoredProcedure, textBox1.Text.Trim());
                if (dt.Rows.Count>0)
                {
                    if (textBox1.Text.Trim() == dt.Rows[0][1].ToString().Trim())
                    {
                        this.Close();
                        
                    }
                    else
                    {
                        textBox1.SelectAll();
                        label1.Text = "Mật khẩu Leader không đúng.......";
                    }
                }
                else
                {
                    textBox1.Text = "";
                    textBox1.Focus();
                    label1.Text = "Mật khẩu Leader không đúng.......";
                }
            }
        }
    }
}
