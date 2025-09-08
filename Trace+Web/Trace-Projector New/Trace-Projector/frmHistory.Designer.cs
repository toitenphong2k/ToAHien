namespace Trace_Projector
{
    partial class frmHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdShrink = new System.Windows.Forms.RadioButton();
            this.rdFCT = new System.Windows.Forms.RadioButton();
            this.rdweight = new System.Windows.Forms.RadioButton();
            this.rdaccess = new System.Windows.Forms.RadioButton();
            this.rdvscheck = new System.Windows.Forms.RadioButton();
            this.rdAssy4 = new System.Windows.Forms.RadioButton();
            this.rdAssy2 = new System.Windows.Forms.RadioButton();
            this.txtTempSerial = new System.Windows.Forms.ComboBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.cbToDate = new System.Windows.Forms.DateTimePicker();
            this.cbDate = new System.Windows.Forms.DateTimePicker();
            this.cbLine = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblfrmName = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbThongbao = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdShrink);
            this.groupBox3.Controls.Add(this.rdFCT);
            this.groupBox3.Controls.Add(this.rdweight);
            this.groupBox3.Controls.Add(this.rdaccess);
            this.groupBox3.Controls.Add(this.rdvscheck);
            this.groupBox3.Controls.Add(this.rdAssy4);
            this.groupBox3.Controls.Add(this.rdAssy2);
            this.groupBox3.Controls.Add(this.txtTempSerial);
            this.groupBox3.Controls.Add(this.btnDownload);
            this.groupBox3.Controls.Add(this.btnCheck);
            this.groupBox3.Controls.Add(this.cbToDate);
            this.groupBox3.Controls.Add(this.cbDate);
            this.groupBox3.Controls.Add(this.cbLine);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(3, 53);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1258, 99);
            this.groupBox3.TabIndex = 79;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Info";
            // 
            // rdShrink
            // 
            this.rdShrink.AutoSize = true;
            this.rdShrink.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdShrink.Location = new System.Drawing.Point(584, 64);
            this.rdShrink.Name = "rdShrink";
            this.rdShrink.Size = new System.Drawing.Size(72, 21);
            this.rdShrink.TabIndex = 84;
            this.rdShrink.Text = "Shrink";
            this.rdShrink.UseVisualStyleBackColor = true;
            // 
            // rdFCT
            // 
            this.rdFCT.AutoSize = true;
            this.rdFCT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdFCT.Location = new System.Drawing.Point(395, 64);
            this.rdFCT.Name = "rdFCT";
            this.rdFCT.Size = new System.Drawing.Size(92, 21);
            this.rdFCT.TabIndex = 84;
            this.rdFCT.Text = "FC check";
            this.rdFCT.UseVisualStyleBackColor = true;
            this.rdFCT.CheckedChanged += new System.EventHandler(this.rdFCT_CheckedChanged);
            // 
            // rdweight
            // 
            this.rdweight.AutoSize = true;
            this.rdweight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdweight.Location = new System.Drawing.Point(495, 63);
            this.rdweight.Name = "rdweight";
            this.rdweight.Size = new System.Drawing.Size(76, 21);
            this.rdweight.TabIndex = 84;
            this.rdweight.Text = "Weight";
            this.rdweight.UseVisualStyleBackColor = true;
            // 
            // rdaccess
            // 
            this.rdaccess.AutoSize = true;
            this.rdaccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdaccess.Location = new System.Drawing.Point(268, 63);
            this.rdaccess.Name = "rdaccess";
            this.rdaccess.Size = new System.Drawing.Size(113, 21);
            this.rdaccess.TabIndex = 84;
            this.rdaccess.Text = "Accessories";
            this.rdaccess.UseVisualStyleBackColor = true;
            // 
            // rdvscheck
            // 
            this.rdvscheck.AutoSize = true;
            this.rdvscheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdvscheck.Location = new System.Drawing.Point(146, 63);
            this.rdvscheck.Name = "rdvscheck";
            this.rdvscheck.Size = new System.Drawing.Size(119, 21);
            this.rdvscheck.TabIndex = 84;
            this.rdvscheck.Text = "Visual Check";
            this.rdvscheck.UseVisualStyleBackColor = true;
            // 
            // rdAssy4
            // 
            this.rdAssy4.AutoSize = true;
            this.rdAssy4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdAssy4.Location = new System.Drawing.Point(76, 63);
            this.rdAssy4.Name = "rdAssy4";
            this.rdAssy4.Size = new System.Drawing.Size(69, 21);
            this.rdAssy4.TabIndex = 84;
            this.rdAssy4.Text = "Assy4";
            this.rdAssy4.UseVisualStyleBackColor = true;
            // 
            // rdAssy2
            // 
            this.rdAssy2.AutoSize = true;
            this.rdAssy2.Checked = true;
            this.rdAssy2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdAssy2.Location = new System.Drawing.Point(2, 63);
            this.rdAssy2.Name = "rdAssy2";
            this.rdAssy2.Size = new System.Drawing.Size(69, 21);
            this.rdAssy2.TabIndex = 84;
            this.rdAssy2.TabStop = true;
            this.rdAssy2.Text = "Assy2";
            this.rdAssy2.UseVisualStyleBackColor = true;
            // 
            // txtTempSerial
            // 
            this.txtTempSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.txtTempSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTempSerial.FormattingEnabled = true;
            this.txtTempSerial.Location = new System.Drawing.Point(733, 21);
            this.txtTempSerial.Name = "txtTempSerial";
            this.txtTempSerial.Size = new System.Drawing.Size(230, 33);
            this.txtTempSerial.TabIndex = 83;
            // 
            // btnDownload
            // 
            this.btnDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.Location = new System.Drawing.Point(1080, 51);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(158, 44);
            this.btnDownload.TabIndex = 82;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Location = new System.Drawing.Point(1079, 5);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(158, 45);
            this.btnCheck.TabIndex = 82;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // cbToDate
            // 
            this.cbToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cbToDate.Location = new System.Drawing.Point(476, 21);
            this.cbToDate.Name = "cbToDate";
            this.cbToDate.Size = new System.Drawing.Size(161, 32);
            this.cbToDate.TabIndex = 81;
            // 
            // cbDate
            // 
            this.cbDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cbDate.Location = new System.Drawing.Point(261, 21);
            this.cbDate.Name = "cbDate";
            this.cbDate.Size = new System.Drawing.Size(161, 32);
            this.cbDate.TabIndex = 81;
            // 
            // cbLine
            // 
            this.cbLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLine.FormattingEnabled = true;
            this.cbLine.Location = new System.Drawing.Point(57, 21);
            this.cbLine.Name = "cbLine";
            this.cbLine.Size = new System.Drawing.Size(133, 33);
            this.cbLine.TabIndex = 80;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(435, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 26);
            this.label4.TabIndex = 39;
            this.label4.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(659, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 26);
            this.label2.TabIndex = 39;
            this.label2.Text = "Serial";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(196, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 26);
            this.label1.TabIndex = 39;
            this.label1.Text = "From";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 26);
            this.label3.TabIndex = 39;
            this.label3.Text = "Line";
            // 
            // lblfrmName
            // 
            this.lblfrmName.AutoSize = true;
            this.lblfrmName.Font = new System.Drawing.Font("Courier New", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblfrmName.ForeColor = System.Drawing.Color.Blue;
            this.lblfrmName.Location = new System.Drawing.Point(348, -2);
            this.lblfrmName.Name = "lblfrmName";
            this.lblfrmName.Size = new System.Drawing.Size(535, 52);
            this.lblfrmName.TabIndex = 76;
            this.lblfrmName.Text = "Projector\'s History";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.LightSalmon;
            this.dataGridView1.Location = new System.Drawing.Point(3, 158);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1258, 606);
            this.dataGridView1.TabIndex = 80;
            // 
            // lbThongbao
            // 
            this.lbThongbao.AutoSize = true;
            this.lbThongbao.Font = new System.Drawing.Font("Courier New", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbThongbao.ForeColor = System.Drawing.Color.Blue;
            this.lbThongbao.Location = new System.Drawing.Point(-1, 767);
            this.lbThongbao.Name = "lbThongbao";
            this.lbThongbao.Size = new System.Drawing.Size(130, 23);
            this.lbThongbao.TabIndex = 81;
            this.lbThongbao.Text = "lbThongbao";
            // 
            // frmHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 799);
            this.Controls.Add(this.lbThongbao);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblfrmName);
            this.Name = "frmHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "History";
            this.Load += new System.EventHandler(this.frmHistory_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblfrmName;
        private System.Windows.Forms.DateTimePicker cbDate;
        private System.Windows.Forms.ComboBox cbLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.ComboBox txtTempSerial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdaccess;
        private System.Windows.Forms.RadioButton rdvscheck;
        private System.Windows.Forms.RadioButton rdAssy4;
        private System.Windows.Forms.RadioButton rdAssy2;
        private System.Windows.Forms.RadioButton rdweight;
        private System.Windows.Forms.DateTimePicker cbToDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.RadioButton rdShrink;
        private System.Windows.Forms.Label lbThongbao;
        private System.Windows.Forms.RadioButton rdFCT;
    }
}