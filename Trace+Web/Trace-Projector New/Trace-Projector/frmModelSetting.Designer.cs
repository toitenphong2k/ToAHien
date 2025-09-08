namespace Trace_Projector
{
    partial class frmModelSetting
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
            this.lbThongbao = new System.Windows.Forms.Label();
            this.lblfrmName = new System.Windows.Forms.Label();
            this.cbModelName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPCBQty = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbOpticalQty = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbModelName = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbModelCode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbOther = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbOptical2Qty = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbLenQty = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbThongbao
            // 
            this.lbThongbao.AutoSize = true;
            this.lbThongbao.Font = new System.Drawing.Font("Courier New", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbThongbao.ForeColor = System.Drawing.Color.Blue;
            this.lbThongbao.Location = new System.Drawing.Point(10, 244);
            this.lbThongbao.Name = "lbThongbao";
            this.lbThongbao.Size = new System.Drawing.Size(227, 40);
            this.lbThongbao.TabIndex = 54;
            this.lbThongbao.Text = "lbThongbao";
            // 
            // lblfrmName
            // 
            this.lblfrmName.AutoSize = true;
            this.lblfrmName.Font = new System.Drawing.Font("Courier New", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblfrmName.ForeColor = System.Drawing.Color.Blue;
            this.lblfrmName.Location = new System.Drawing.Point(280, -5);
            this.lblfrmName.Name = "lblfrmName";
            this.lblfrmName.Size = new System.Drawing.Size(374, 52);
            this.lblfrmName.TabIndex = 53;
            this.lblfrmName.Text = "Model setting";
            // 
            // cbModelName
            // 
            this.cbModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbModelName.FormattingEnabled = true;
            this.cbModelName.Location = new System.Drawing.Point(196, 68);
            this.cbModelName.Name = "cbModelName";
            this.cbModelName.Size = new System.Drawing.Size(230, 33);
            this.cbModelName.TabIndex = 56;
            this.cbModelName.SelectedIndexChanged += new System.EventHandler(this.cbModelName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(486, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 26);
            this.label1.TabIndex = 55;
            this.label1.Text = "Model Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(486, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 26);
            this.label2.TabIndex = 55;
            this.label2.Text = "PCB Qy";
            // 
            // cbPCBQty
            // 
            this.cbPCBQty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPCBQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPCBQty.FormattingEnabled = true;
            this.cbPCBQty.Location = new System.Drawing.Point(670, 113);
            this.cbPCBQty.Name = "cbPCBQty";
            this.cbPCBQty.Size = new System.Drawing.Size(230, 33);
            this.cbPCBQty.TabIndex = 56;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 26);
            this.label3.TabIndex = 55;
            this.label3.Text = "Optical Qty";
            // 
            // cbOpticalQty
            // 
            this.cbOpticalQty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOpticalQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOpticalQty.FormattingEnabled = true;
            this.cbOpticalQty.Location = new System.Drawing.Point(196, 113);
            this.cbOpticalQty.Name = "cbOpticalQty";
            this.cbOpticalQty.Size = new System.Drawing.Size(230, 33);
            this.cbOpticalQty.TabIndex = 56;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(133, 287);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(158, 44);
            this.btnAdd.TabIndex = 57;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(398, 287);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(158, 44);
            this.btnUpdate.TabIndex = 57;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(660, 287);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(158, 44);
            this.btnClose.TabIndex = 57;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbModelName
            // 
            this.lbModelName.AutoSize = true;
            this.lbModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbModelName.Location = new System.Drawing.Point(12, 68);
            this.lbModelName.Name = "lbModelName";
            this.lbModelName.Size = new System.Drawing.Size(136, 26);
            this.lbModelName.TabIndex = 55;
            this.lbModelName.Text = "Model Name";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 364);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(883, 223);
            this.dataGridView1.TabIndex = 58;
            // 
            // cbModelCode
            // 
            this.cbModelCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cbModelCode.Enabled = false;
            this.cbModelCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbModelCode.FormattingEnabled = true;
            this.cbModelCode.Location = new System.Drawing.Point(670, 65);
            this.cbModelCode.Name = "cbModelCode";
            this.cbModelCode.Size = new System.Drawing.Size(230, 33);
            this.cbModelCode.TabIndex = 56;
            this.cbModelCode.SelectedIndexChanged += new System.EventHandler(this.cbModelName_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 59;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 26);
            this.label5.TabIndex = 55;
            this.label5.Text = "Others";
            // 
            // cbOther
            // 
            this.cbOther.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOther.FormattingEnabled = true;
            this.cbOther.Location = new System.Drawing.Point(196, 204);
            this.cbOther.Name = "cbOther";
            this.cbOther.Size = new System.Drawing.Size(230, 33);
            this.cbOther.TabIndex = 56;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 26);
            this.label6.TabIndex = 55;
            this.label6.Text = "Optical 2 Qty";
            // 
            // cbOptical2Qty
            // 
            this.cbOptical2Qty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOptical2Qty.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOptical2Qty.FormattingEnabled = true;
            this.cbOptical2Qty.Location = new System.Drawing.Point(196, 157);
            this.cbOptical2Qty.Name = "cbOptical2Qty";
            this.cbOptical2Qty.Size = new System.Drawing.Size(230, 33);
            this.cbOptical2Qty.TabIndex = 56;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(486, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 26);
            this.label7.TabIndex = 55;
            this.label7.Text = "Len Qty";
            // 
            // cbLenQty
            // 
            this.cbLenQty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLenQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLenQty.FormattingEnabled = true;
            this.cbLenQty.Location = new System.Drawing.Point(670, 154);
            this.cbLenQty.Name = "cbLenQty";
            this.cbLenQty.Size = new System.Drawing.Size(230, 33);
            this.cbLenQty.TabIndex = 56;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(111, 334);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 55;
            this.label8.Text = "Sử dụng khi";
            // 
            // frmModelSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 599);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbOther);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbOptical2Qty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbOpticalQty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbModelName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbLenQty);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbPCBQty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbModelCode);
            this.Controls.Add(this.cbModelName);
            this.Controls.Add(this.lbThongbao);
            this.Controls.Add(this.lblfrmName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModelSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Model Setting";
            this.Load += new System.EventHandler(this.frmModelSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbThongbao;
        private System.Windows.Forms.Label lblfrmName;
        private System.Windows.Forms.ComboBox cbModelName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPCBQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbOpticalQty;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbModelName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbModelCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbOther;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbOptical2Qty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbLenQty;
        private System.Windows.Forms.Label label8;
    }
}