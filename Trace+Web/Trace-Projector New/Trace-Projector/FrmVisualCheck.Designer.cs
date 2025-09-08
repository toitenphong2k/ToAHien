namespace Trace_Projector
{
    partial class FrmVisualCheck
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
            this.lblfrmName = new System.Windows.Forms.Label();
            this.lbLine = new System.Windows.Forms.Label();
            this.lbServer = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtOtherQty = new System.Windows.Forms.TextBox();
            this.txtOpticalQty = new System.Windows.Forms.TextBox();
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPCBQty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtModelCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbThongbao = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtTempSerial = new System.Windows.Forms.TextBox();
            this.lbTempID = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtOptical = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtModelCode2 = new System.Windows.Forms.TextBox();
            this.txtUPC = new System.Windows.Forms.TextBox();
            this.txtCartonSerial = new System.Windows.Forms.TextBox();
            this.txtProductSerial = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cbCheckAgain = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lbQtyToday = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btlClear = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblfrmName
            // 
            this.lblfrmName.AutoSize = true;
            this.lblfrmName.Font = new System.Drawing.Font("Courier New", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblfrmName.ForeColor = System.Drawing.Color.Blue;
            this.lblfrmName.Location = new System.Drawing.Point(237, 2);
            this.lblfrmName.Name = "lblfrmName";
            this.lblfrmName.Size = new System.Drawing.Size(562, 52);
            this.lblfrmName.TabIndex = 49;
            this.lblfrmName.Text = "VISUAL CHECK 1 LABEL";
            // 
            // lbLine
            // 
            this.lbLine.AutoSize = true;
            this.lbLine.BackColor = System.Drawing.Color.Aqua;
            this.lbLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbLine.Location = new System.Drawing.Point(1005, 4);
            this.lbLine.Name = "lbLine";
            this.lbLine.Size = new System.Drawing.Size(131, 54);
            this.lbLine.TabIndex = 50;
            this.lbLine.Text = "LINE";
            // 
            // lbServer
            // 
            this.lbServer.AutoSize = true;
            this.lbServer.BackColor = System.Drawing.Color.Blue;
            this.lbServer.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbServer.ForeColor = System.Drawing.Color.White;
            this.lbServer.Location = new System.Drawing.Point(893, 597);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(236, 27);
            this.lbServer.TabIndex = 63;
            this.lbServer.Text = "SERVER CONNECTED";
            this.lbServer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtOtherQty);
            this.groupBox3.Controls.Add(this.txtOpticalQty);
            this.groupBox3.Controls.Add(this.txtModelName);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtPCBQty);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtModelCode);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(10, 107);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(755, 177);
            this.groupBox3.TabIndex = 61;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Model info";
            // 
            // txtOtherQty
            // 
            this.txtOtherQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtherQty.Location = new System.Drawing.Point(152, 129);
            this.txtOtherQty.Name = "txtOtherQty";
            this.txtOtherQty.ReadOnly = true;
            this.txtOtherQty.Size = new System.Drawing.Size(192, 38);
            this.txtOtherQty.TabIndex = 40;
            this.txtOtherQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtOpticalQty
            // 
            this.txtOpticalQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOpticalQty.Location = new System.Drawing.Point(502, 74);
            this.txtOpticalQty.Name = "txtOpticalQty";
            this.txtOpticalQty.ReadOnly = true;
            this.txtOpticalQty.Size = new System.Drawing.Size(247, 38);
            this.txtOpticalQty.TabIndex = 40;
            this.txtOpticalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtModelName
            // 
            this.txtModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelName.Location = new System.Drawing.Point(502, 15);
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.ReadOnly = true;
            this.txtModelName.Size = new System.Drawing.Size(247, 38);
            this.txtModelName.TabIndex = 40;
            this.txtModelName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 26);
            this.label8.TabIndex = 39;
            this.label8.Text = "Other Qty";
            // 
            // txtPCBQty
            // 
            this.txtPCBQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPCBQty.Location = new System.Drawing.Point(152, 74);
            this.txtPCBQty.Name = "txtPCBQty";
            this.txtPCBQty.ReadOnly = true;
            this.txtPCBQty.Size = new System.Drawing.Size(192, 38);
            this.txtPCBQty.TabIndex = 40;
            this.txtPCBQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(359, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 26);
            this.label6.TabIndex = 39;
            this.label6.Text = "Optical Qty";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(359, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 26);
            this.label5.TabIndex = 39;
            this.label5.Text = "Model Name";
            // 
            // txtModelCode
            // 
            this.txtModelCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelCode.Location = new System.Drawing.Point(152, 15);
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
            this.label4.Location = new System.Drawing.Point(10, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 26);
            this.label4.TabIndex = 39;
            this.label4.Text = "PCB Qty";
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
            // lbThongbao
            // 
            this.lbThongbao.AutoSize = true;
            this.lbThongbao.Font = new System.Drawing.Font("Courier New", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbThongbao.ForeColor = System.Drawing.Color.Blue;
            this.lbThongbao.Location = new System.Drawing.Point(9, 548);
            this.lbThongbao.Name = "lbThongbao";
            this.lbThongbao.Size = new System.Drawing.Size(227, 40);
            this.lbThongbao.TabIndex = 57;
            this.lbThongbao.Text = "lbThongbao";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(774, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 477);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item List";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(351, 442);
            this.dataGridView1.TabIndex = 0;
            // 
            // txtTempSerial
            // 
            this.txtTempSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTempSerial.Location = new System.Drawing.Point(162, 66);
            this.txtTempSerial.Name = "txtTempSerial";
            this.txtTempSerial.Size = new System.Drawing.Size(599, 38);
            this.txtTempSerial.TabIndex = 59;
            this.txtTempSerial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTempSerial_KeyPress);
            // 
            // lbTempID
            // 
            this.lbTempID.AutoSize = true;
            this.lbTempID.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTempID.Location = new System.Drawing.Point(3, 68);
            this.lbTempID.Name = "lbTempID";
            this.lbTempID.Size = new System.Drawing.Size(159, 26);
            this.lbTempID.TabIndex = 58;
            this.lbTempID.Text = "Tempory Serial";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtOptical);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtModelCode2);
            this.groupBox2.Controls.Add(this.txtUPC);
            this.groupBox2.Controls.Add(this.txtCartonSerial);
            this.groupBox2.Controls.Add(this.txtProductSerial);
            this.groupBox2.Location = new System.Drawing.Point(11, 287);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(755, 248);
            this.groupBox2.TabIndex = 62;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Module";
            // 
            // txtOptical
            // 
            this.txtOptical.AutoSize = true;
            this.txtOptical.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOptical.Location = new System.Drawing.Point(0, 70);
            this.txtOptical.Name = "txtOptical";
            this.txtOptical.Size = new System.Drawing.Size(129, 26);
            this.txtOptical.TabIndex = 38;
            this.txtOptical.Text = "Model Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 26);
            this.label1.TabIndex = 38;
            this.label1.Text = "UPC Serial";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(2, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 26);
            this.label7.TabIndex = 38;
            this.label7.Text = "Carton Serial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-1, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 26);
            this.label2.TabIndex = 38;
            this.label2.Text = "Product Serial";
            // 
            // txtModelCode2
            // 
            this.txtModelCode2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelCode2.Location = new System.Drawing.Point(150, 64);
            this.txtModelCode2.Name = "txtModelCode2";
            this.txtModelCode2.Size = new System.Drawing.Size(599, 38);
            this.txtModelCode2.TabIndex = 39;
            this.txtModelCode2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtModelCode2_KeyPress);
            // 
            // txtUPC
            // 
            this.txtUPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUPC.Location = new System.Drawing.Point(149, 156);
            this.txtUPC.Name = "txtUPC";
            this.txtUPC.Size = new System.Drawing.Size(599, 38);
            this.txtUPC.TabIndex = 39;
            this.txtUPC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUPC_KeyPress);
            // 
            // txtCartonSerial
            // 
            this.txtCartonSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCartonSerial.Location = new System.Drawing.Point(149, 110);
            this.txtCartonSerial.Name = "txtCartonSerial";
            this.txtCartonSerial.Size = new System.Drawing.Size(599, 38);
            this.txtCartonSerial.TabIndex = 39;
            this.txtCartonSerial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCartonSerial_KeyPress);
            // 
            // txtProductSerial
            // 
            this.txtProductSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductSerial.Location = new System.Drawing.Point(151, 19);
            this.txtProductSerial.Name = "txtProductSerial";
            this.txtProductSerial.Size = new System.Drawing.Size(599, 38);
            this.txtProductSerial.TabIndex = 39;
            this.txtProductSerial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProductSerial_KeyPress);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cbCheckAgain
            // 
            this.cbCheckAgain.AutoSize = true;
            this.cbCheckAgain.Location = new System.Drawing.Point(11, 36);
            this.cbCheckAgain.Name = "cbCheckAgain";
            this.cbCheckAgain.Size = new System.Drawing.Size(86, 17);
            this.cbCheckAgain.TabIndex = 64;
            this.cbCheckAgain.Text = "Check again";
            this.cbCheckAgain.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 598);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 26);
            this.label9.TabIndex = 39;
            this.label9.Text = "Today\'s Qty:";
            // 
            // lbQtyToday
            // 
            this.lbQtyToday.AutoSize = true;
            this.lbQtyToday.Font = new System.Drawing.Font("Courier New", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbQtyToday.ForeColor = System.Drawing.Color.Blue;
            this.lbQtyToday.Location = new System.Drawing.Point(134, 593);
            this.lbQtyToday.Name = "lbQtyToday";
            this.lbQtyToday.Size = new System.Drawing.Size(38, 40);
            this.lbQtyToday.TabIndex = 57;
            this.lbQtyToday.Text = "0";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(452, 650);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 36);
            this.btnExit.TabIndex = 68;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btlClear
            // 
            this.btlClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btlClear.Location = new System.Drawing.Point(288, 650);
            this.btlClear.Name = "btlClear";
            this.btlClear.Size = new System.Drawing.Size(94, 36);
            this.btlClear.TabIndex = 67;
            this.btlClear.Text = "Clear";
            this.btlClear.UseVisualStyleBackColor = true;
            this.btlClear.Click += new System.EventHandler(this.btlClear_Click);
            // 
            // FrmVisualCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 694);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btlClear);
            this.Controls.Add(this.cbCheckAgain);
            this.Controls.Add(this.lbServer);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lbQtyToday);
            this.Controls.Add(this.lbThongbao);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTempSerial);
            this.Controls.Add(this.lbTempID);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblfrmName);
            this.Controls.Add(this.lbLine);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVisualCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visual Check";
            this.Load += new System.EventHandler(this.FrmVisualCheck_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblfrmName;
        private System.Windows.Forms.Label lbLine;
        private System.Windows.Forms.Label lbServer;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtOtherQty;
        private System.Windows.Forms.TextBox txtOpticalQty;
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPCBQty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtModelCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbThongbao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtTempSerial;
        private System.Windows.Forms.Label lbTempID;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label txtOptical;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtModelCode2;
        private System.Windows.Forms.TextBox txtCartonSerial;
        private System.Windows.Forms.TextBox txtProductSerial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUPC;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox cbCheckAgain;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbQtyToday;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btlClear;
    }
}