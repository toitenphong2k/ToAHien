namespace Trace_Projector
{
    partial class frmAdjust
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
            this.lblfrmName = new System.Windows.Forms.Label();
            this.txtTempSerial = new System.Windows.Forms.TextBox();
            this.lbTempID = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDMDQty = new System.Windows.Forms.TextBox();
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbQtyToday = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSerialNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNameLabel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCautionLabel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbCheckAgain = new System.Windows.Forms.CheckBox();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblfrmName
            // 
            this.lblfrmName.AutoSize = true;
            this.lblfrmName.Font = new System.Drawing.Font("Courier New", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblfrmName.ForeColor = System.Drawing.Color.Blue;
            this.lblfrmName.Location = new System.Drawing.Point(186, 14);
            this.lblfrmName.Name = "lblfrmName";
            this.lblfrmName.Size = new System.Drawing.Size(697, 52);
            this.lblfrmName.TabIndex = 48;
            this.lblfrmName.Text = "Traceability - Projector ";
            // 
            // txtTempSerial
            // 
            this.txtTempSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTempSerial.Location = new System.Drawing.Point(253, 86);
            this.txtTempSerial.Name = "txtTempSerial";
            this.txtTempSerial.Size = new System.Drawing.Size(599, 38);
            this.txtTempSerial.TabIndex = 50;
            this.txtTempSerial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTempSerial_KeyPress);
            // 
            // lbTempID
            // 
            this.lbTempID.AutoSize = true;
            this.lbTempID.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTempID.Location = new System.Drawing.Point(84, 88);
            this.lbTempID.Name = "lbTempID";
            this.lbTempID.Size = new System.Drawing.Size(159, 26);
            this.lbTempID.TabIndex = 49;
            this.lbTempID.Text = "Tempory Serial";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtDMDQty);
            this.groupBox3.Controls.Add(this.txtOpticalQty);
            this.groupBox3.Controls.Add(this.txtModelName);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtPCBQty);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtModelCode);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(101, 294);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(755, 177);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Model info";
            // 
            // txtDMDQty
            // 
            this.txtDMDQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDMDQty.Location = new System.Drawing.Point(152, 129);
            this.txtDMDQty.Name = "txtDMDQty";
            this.txtDMDQty.ReadOnly = true;
            this.txtDMDQty.Size = new System.Drawing.Size(192, 38);
            this.txtDMDQty.TabIndex = 40;
            this.txtDMDQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.label8.Size = new System.Drawing.Size(102, 26);
            this.label8.TabIndex = 39;
            this.label8.Text = "DMD Qty";
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
            this.lbThongbao.Location = new System.Drawing.Point(2, 477);
            this.lbThongbao.Name = "lbThongbao";
            this.lbThongbao.Size = new System.Drawing.Size(227, 40);
            this.lbThongbao.TabIndex = 52;
            this.lbThongbao.Text = "lbThongbao";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(101, 517);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(751, 242);
            this.dataGridView1.TabIndex = 53;
            // 
            // lbQtyToday
            // 
            this.lbQtyToday.AutoSize = true;
            this.lbQtyToday.Font = new System.Drawing.Font("Courier New", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbQtyToday.ForeColor = System.Drawing.Color.Blue;
            this.lbQtyToday.Location = new System.Drawing.Point(137, 759);
            this.lbQtyToday.Name = "lbQtyToday";
            this.lbQtyToday.Size = new System.Drawing.Size(38, 40);
            this.lbQtyToday.TabIndex = 59;
            this.lbQtyToday.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 762);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 26);
            this.label9.TabIndex = 58;
            this.label9.Text = "Today\'s Qty:";
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialNo.Location = new System.Drawing.Point(253, 139);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(599, 38);
            this.txtSerialNo.TabIndex = 61;
            this.txtSerialNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerialNo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 26);
            this.label1.TabIndex = 60;
            this.label1.Text = "Serial No";
            // 
            // txtNameLabel
            // 
            this.txtNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameLabel.Location = new System.Drawing.Point(253, 196);
            this.txtNameLabel.Name = "txtNameLabel";
            this.txtNameLabel.Size = new System.Drawing.Size(599, 38);
            this.txtNameLabel.TabIndex = 63;
            this.txtNameLabel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNameLabel_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 26);
            this.label2.TabIndex = 62;
            this.label2.Text = "Name Label";
            // 
            // txtCautionLabel
            // 
            this.txtCautionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCautionLabel.Location = new System.Drawing.Point(251, 254);
            this.txtCautionLabel.Name = "txtCautionLabel";
            this.txtCautionLabel.Size = new System.Drawing.Size(599, 38);
            this.txtCautionLabel.TabIndex = 65;
            this.txtCautionLabel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCautionLabel_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(82, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 26);
            this.label7.TabIndex = 64;
            this.label7.Text = "Caution Label";
            // 
            // cbCheckAgain
            // 
            this.cbCheckAgain.AutoSize = true;
            this.cbCheckAgain.Location = new System.Drawing.Point(26, 40);
            this.cbCheckAgain.Name = "cbCheckAgain";
            this.cbCheckAgain.Size = new System.Drawing.Size(86, 17);
            this.cbCheckAgain.TabIndex = 73;
            this.cbCheckAgain.Text = "Check again";
            this.cbCheckAgain.UseVisualStyleBackColor = true;
            this.cbCheckAgain.CheckedChanged += new System.EventHandler(this.cbCheckAgain_CheckedChanged);
            // 
            // frmAdjust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 800);
            this.Controls.Add(this.cbCheckAgain);
            this.Controls.Add(this.txtCautionLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNameLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSerialNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbQtyToday);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lbThongbao);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblfrmName);
            this.Controls.Add(this.txtTempSerial);
            this.Controls.Add(this.lbTempID);
            this.Name = "frmAdjust";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FA Trace-Projector Adjust";
            this.Load += new System.EventHandler(this.frmAdjust_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblfrmName;
        private System.Windows.Forms.TextBox txtTempSerial;
        private System.Windows.Forms.Label lbTempID;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtDMDQty;
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbQtyToday;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSerialNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCautionLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbCheckAgain;
    }
}