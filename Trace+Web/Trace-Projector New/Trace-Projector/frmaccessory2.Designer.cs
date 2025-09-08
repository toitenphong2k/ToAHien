namespace Trace_Projector
{
    partial class frmaccessory2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbCheckAgain = new System.Windows.Forms.CheckBox();
            this.lbServer = new System.Windows.Forms.Label();
            this.lbQtyToday = new System.Windows.Forms.Label();
            this.lbThongbao = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblfrmName = new System.Windows.Forms.Label();
            this.lbLine = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.txtaccessQty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtModelCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTempSerial = new System.Windows.Forms.TextBox();
            this.lbTempID = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GridActual = new System.Windows.Forms.DataGridView();
            this.Gridstd = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.txtWeightCheck = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
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
            this.lblfrmName.Text = "ACCESSORIES 2 CHECK";
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
            this.groupBox3.Controls.Add(this.txtWeight);
            this.groupBox3.Controls.Add(this.txtModelName);
            this.groupBox3.Controls.Add(this.txtaccessQty);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtModelCode);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(6, 126);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(764, 121);
            this.groupBox3.TabIndex = 74;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Model info";
            // 
            // txtWeight
            // 
            this.txtWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeight.Location = new System.Drawing.Point(504, 72);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.ReadOnly = true;
            this.txtWeight.Size = new System.Drawing.Size(247, 38);
            this.txtWeight.TabIndex = 40;
            this.txtWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(361, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 26);
            this.label6.TabIndex = 39;
            this.label6.Text = "Weight STD";
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
            // txtTempSerial
            // 
            this.txtTempSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTempSerial.Location = new System.Drawing.Point(162, 83);
            this.txtTempSerial.Name = "txtTempSerial";
            this.txtTempSerial.Size = new System.Drawing.Size(608, 38);
            this.txtTempSerial.TabIndex = 0;
            this.txtTempSerial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTempSerial_KeyPress);
            // 
            // lbTempID
            // 
            this.lbTempID.AutoSize = true;
            this.lbTempID.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTempID.Location = new System.Drawing.Point(3, 85);
            this.lbTempID.Name = "lbTempID";
            this.lbTempID.Size = new System.Drawing.Size(159, 26);
            this.lbTempID.TabIndex = 72;
            this.lbTempID.Text = "Tempory Serial";
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
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridActual.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
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
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Gridstd.RowHeadersDefaultCellStyle = dataGridViewCellStyle22;
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
            this.label7.Location = new System.Drawing.Point(4, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 26);
            this.label7.TabIndex = 72;
            this.label7.Text = "Items Code";
            // 
            // txtItemCode
            // 
            this.txtItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCode.Location = new System.Drawing.Point(163, 255);
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 307);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 26);
            this.label8.TabIndex = 72;
            this.label8.Text = "Weight Check";
            // 
            // txtWeightCheck
            // 
            this.txtWeightCheck.Enabled = false;
            this.txtWeightCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeightCheck.Location = new System.Drawing.Point(162, 302);
            this.txtWeightCheck.Name = "txtWeightCheck";
            this.txtWeightCheck.Size = new System.Drawing.Size(608, 38);
            this.txtWeightCheck.TabIndex = 73;
            this.txtWeightCheck.Text = "0.0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 354);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 26);
            this.label10.TabIndex = 72;
            this.label10.Text = "Confirm";
            // 
            // txtConfirm
            // 
            this.txtConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirm.Location = new System.Drawing.Point(162, 349);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.Size = new System.Drawing.Size(608, 38);
            this.txtConfirm.TabIndex = 2;
            this.txtConfirm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConfirm_KeyPress);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // frmaccessory2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 719);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtWeightCheck);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtItemCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTempSerial);
            this.Controls.Add(this.lbTempID);
            this.Controls.Add(this.cbCheckAgain);
            this.Controls.Add(this.lbServer);
            this.Controls.Add(this.lbQtyToday);
            this.Controls.Add(this.lbThongbao);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblfrmName);
            this.Controls.Add(this.lbLine);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmaccessory2";
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
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.TextBox txtaccessQty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtModelCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTempSerial;
        private System.Windows.Forms.Label lbTempID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView Gridstd;
        private System.Windows.Forms.DataGridView GridActual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtWeightCheck;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}