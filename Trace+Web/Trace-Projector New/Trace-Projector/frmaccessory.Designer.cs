namespace Trace_Projector
{
    partial class frmaccessory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbCheckAgain = new System.Windows.Forms.CheckBox();
            this.lbServer = new System.Windows.Forms.Label();
            this.lbQtyToday = new System.Windows.Forms.Label();
            this.lbThongbao = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblfrmName = new System.Windows.Forms.Label();
            this.lbLine = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.txtaccessQty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtModelCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtModelCodeScan = new System.Windows.Forms.TextBox();
            this.lbModelCodeScan = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GridActual = new System.Windows.Forms.DataGridView();
            this.Gridstd = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.btModelSetting = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gridstd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCheckAgain
            // 
            this.cbCheckAgain.AutoSize = true;
            this.cbCheckAgain.Location = new System.Drawing.Point(2, 22);
            this.cbCheckAgain.Name = "cbCheckAgain";
            this.cbCheckAgain.Size = new System.Drawing.Size(86, 17);
            this.cbCheckAgain.TabIndex = 71;
            this.cbCheckAgain.Text = "Check again";
            this.cbCheckAgain.UseVisualStyleBackColor = true;
            this.cbCheckAgain.Visible = false;
            // 
            // lbServer
            // 
            this.lbServer.AutoSize = true;
            this.lbServer.BackColor = System.Drawing.Color.Blue;
            this.lbServer.Font = new System.Drawing.Font("Courier New", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbServer.ForeColor = System.Drawing.Color.White;
            this.lbServer.Location = new System.Drawing.Point(772, 678);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(353, 40);
            this.lbServer.TabIndex = 70;
            this.lbServer.Text = "SERVER CONNECTED";
            this.lbServer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbQtyToday
            // 
            this.lbQtyToday.AutoSize = true;
            this.lbQtyToday.Font = new System.Drawing.Font("Courier New", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbQtyToday.ForeColor = System.Drawing.Color.Blue;
            this.lbQtyToday.Location = new System.Drawing.Point(133, 679);
            this.lbQtyToday.Name = "lbQtyToday";
            this.lbQtyToday.Size = new System.Drawing.Size(38, 40);
            this.lbQtyToday.TabIndex = 68;
            this.lbQtyToday.Text = "0";
            // 
            // lbThongbao
            // 
            this.lbThongbao.AutoSize = true;
            this.lbThongbao.Font = new System.Drawing.Font("Courier New", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbThongbao.ForeColor = System.Drawing.Color.Blue;
            this.lbThongbao.Location = new System.Drawing.Point(-5, 639);
            this.lbThongbao.Name = "lbThongbao";
            this.lbThongbao.Size = new System.Drawing.Size(227, 40);
            this.lbThongbao.TabIndex = 69;
            this.lbThongbao.Text = "lbThongbao";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 684);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 26);
            this.label9.TabIndex = 65;
            this.label9.Text = "Today\'s Qty:";
            // 
            // lblfrmName
            // 
            this.lblfrmName.AutoSize = true;
            this.lblfrmName.Font = new System.Drawing.Font("Courier New", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblfrmName.ForeColor = System.Drawing.Color.Blue;
            this.lblfrmName.Location = new System.Drawing.Point(199, 3);
            this.lblfrmName.Name = "lblfrmName";
            this.lblfrmName.Size = new System.Drawing.Size(536, 52);
            this.lblfrmName.TabIndex = 66;
            this.lblfrmName.Text = "ACCESSORIES 1 CHECK";
            // 
            // lbLine
            // 
            this.lbLine.AutoSize = true;
            this.lbLine.BackColor = System.Drawing.Color.Aqua;
            this.lbLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbLine.Location = new System.Drawing.Point(993, 2);
            this.lbLine.Name = "lbLine";
            this.lbLine.Size = new System.Drawing.Size(131, 54);
            this.lbLine.TabIndex = 67;
            this.lbLine.Text = "LINE";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.txtModelName);
            this.groupBox3.Controls.Add(this.txtaccessQty);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtModelCode);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(6, 160);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(764, 121);
            this.groupBox3.TabIndex = 74;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Model info";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(544, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 41;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtModelName
            // 
            this.txtModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelName.Location = new System.Drawing.Point(504, 15);
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.ReadOnly = true;
            this.txtModelName.Size = new System.Drawing.Size(247, 38);
            this.txtModelName.TabIndex = 40;
            this.txtModelName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtaccessQty
            // 
            this.txtaccessQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtaccessQty.Location = new System.Drawing.Point(156, 72);
            this.txtaccessQty.Name = "txtaccessQty";
            this.txtaccessQty.ReadOnly = true;
            this.txtaccessQty.Size = new System.Drawing.Size(192, 38);
            this.txtaccessQty.TabIndex = 40;
            this.txtaccessQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(361, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 26);
            this.label5.TabIndex = 39;
            this.label5.Text = "Model Name";
            // 
            // txtModelCode
            // 
            this.txtModelCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelCode.Location = new System.Drawing.Point(156, 15);
            this.txtModelCode.Name = "txtModelCode";
            this.txtModelCode.ReadOnly = true;
            this.txtModelCode.Size = new System.Drawing.Size(192, 38);
            this.txtModelCode.TabIndex = 40;
            this.txtModelCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 26);
            this.label4.TabIndex = 39;
            this.label4.Text = "Quantity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 26);
            this.label3.TabIndex = 39;
            this.label3.Text = "Model Code";
            // 
            // txtModelCodeScan
            // 
            this.txtModelCodeScan.Enabled = false;
            this.txtModelCodeScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelCodeScan.Location = new System.Drawing.Point(162, 83);
            this.txtModelCodeScan.Name = "txtModelCodeScan";
            this.txtModelCodeScan.Size = new System.Drawing.Size(608, 38);
            this.txtModelCodeScan.TabIndex = 0;
            this.txtModelCodeScan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtModelCodeScan_KeyPress);
            // 
            // lbModelCodeScan
            // 
            this.lbModelCodeScan.AutoSize = true;
            this.lbModelCodeScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbModelCodeScan.Location = new System.Drawing.Point(3, 85);
            this.lbModelCodeScan.Name = "lbModelCodeScan";
            this.lbModelCodeScan.Size = new System.Drawing.Size(129, 26);
            this.lbModelCodeScan.TabIndex = 72;
            this.lbModelCodeScan.Text = "Model Code";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GridActual);
            this.groupBox1.Controls.Add(this.Gridstd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(803, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 619);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Accessories List";
            // 
            // GridActual
            // 
            this.GridActual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridActual.GridColor = System.Drawing.Color.Salmon;
            this.GridActual.Location = new System.Drawing.Point(6, 351);
            this.GridActual.Name = "GridActual";
            this.GridActual.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridActual.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridActual.Size = new System.Drawing.Size(309, 262);
            this.GridActual.TabIndex = 0;
            // 
            // Gridstd
            // 
            this.Gridstd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Gridstd.GridColor = System.Drawing.Color.Salmon;
            this.Gridstd.Location = new System.Drawing.Point(6, 49);
            this.Gridstd.Name = "Gridstd";
            this.Gridstd.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Gridstd.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Gridstd.Size = new System.Drawing.Size(309, 258);
            this.Gridstd.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(81, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 29);
            this.label2.TabIndex = 69;
            this.label2.Text = "STANDARD";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(94, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 29);
            this.label1.TabIndex = 69;
            this.label1.Text = "ACTUAL";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 314);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 26);
            this.label7.TabIndex = 72;
            this.label7.Text = "Items Code";
            // 
            // txtItemCode
            // 
            this.txtItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCode.Location = new System.Drawing.Point(163, 309);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(607, 38);
            this.txtItemCode.TabIndex = 1;
            this.txtItemCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemCode_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Salmon;
            this.dataGridView1.Location = new System.Drawing.Point(9, 407);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(761, 228);
            this.dataGridView1.TabIndex = 0;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // btModelSetting
            // 
            this.btModelSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btModelSetting.Location = new System.Drawing.Point(652, 674);
            this.btModelSetting.Name = "btModelSetting";
            this.btModelSetting.Size = new System.Drawing.Size(107, 40);
            this.btModelSetting.TabIndex = 76;
            this.btModelSetting.Text = "Model Setting";
            this.btModelSetting.UseVisualStyleBackColor = true;
            this.btModelSetting.Click += new System.EventHandler(this.btModelSetting_Click);
            // 
            // frmaccessory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 719);
            this.Controls.Add(this.btModelSetting);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtItemCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtModelCodeScan);
            this.Controls.Add(this.lbModelCodeScan);
            this.Controls.Add(this.cbCheckAgain);
            this.Controls.Add(this.lbServer);
            this.Controls.Add(this.lbQtyToday);
            this.Controls.Add(this.lbThongbao);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblfrmName);
            this.Controls.Add(this.lbLine);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmaccessory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accessories Projector";
            this.Load += new System.EventHandler(this.frmaccessory_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gridstd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbCheckAgain;
        private System.Windows.Forms.Label lbServer;
        private System.Windows.Forms.Label lbQtyToday;
        private System.Windows.Forms.Label lbThongbao;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblfrmName;
        private System.Windows.Forms.Label lbLine;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.TextBox txtaccessQty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtModelCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtModelCodeScan;
        private System.Windows.Forms.Label lbModelCodeScan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView Gridstd;
        private System.Windows.Forms.DataGridView GridActual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btModelSetting;
    }
}