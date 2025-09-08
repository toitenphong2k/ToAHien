namespace Trace_Projector
{
    partial class frmModelAccessories
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
            this.lbModelName = new System.Windows.Forms.Label();
            this.txtModelCode = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbThongbao = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblfrmName
            // 
            this.lblfrmName.AutoSize = true;
            this.lblfrmName.Font = new System.Drawing.Font("Courier New", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblfrmName.ForeColor = System.Drawing.Color.Blue;
            this.lblfrmName.Location = new System.Drawing.Point(148, 14);
            this.lblfrmName.Name = "lblfrmName";
            this.lblfrmName.Size = new System.Drawing.Size(374, 52);
            this.lblfrmName.TabIndex = 54;
            this.lblfrmName.Text = "Model setting";
            // 
            // lbModelName
            // 
            this.lbModelName.AutoSize = true;
            this.lbModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbModelName.Location = new System.Drawing.Point(56, 102);
            this.lbModelName.Name = "lbModelName";
            this.lbModelName.Size = new System.Drawing.Size(129, 26);
            this.lbModelName.TabIndex = 57;
            this.lbModelName.Text = "Model Code";
            // 
            // txtModelCode
            // 
            this.txtModelCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.txtModelCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelCode.FormattingEnabled = true;
            this.txtModelCode.Location = new System.Drawing.Point(191, 95);
            this.txtModelCode.Name = "txtModelCode";
            this.txtModelCode.Size = new System.Drawing.Size(419, 33);
            this.txtModelCode.TabIndex = 58;
            this.txtModelCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tctModelCode_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(61, 191);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(549, 221);
            this.dataGridView1.TabIndex = 59;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(201, 423);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 53);
            this.btnSave.TabIndex = 60;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(378, 423);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 53);
            this.btnClose.TabIndex = 60;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbThongbao
            // 
            this.lbThongbao.AutoSize = true;
            this.lbThongbao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThongbao.ForeColor = System.Drawing.Color.Blue;
            this.lbThongbao.Location = new System.Drawing.Point(61, 157);
            this.lbThongbao.Name = "lbThongbao";
            this.lbThongbao.Size = new System.Drawing.Size(21, 18);
            this.lbThongbao.TabIndex = 61;
            this.lbThongbao.Text = "lb";
            // 
            // frmModelAccessories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 483);
            this.Controls.Add(this.lbThongbao);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lbModelName);
            this.Controls.Add(this.txtModelCode);
            this.Controls.Add(this.lblfrmName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModelAccessories";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Accessories Model setting";
            this.Load += new System.EventHandler(this.frmModelAccessories_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblfrmName;
        private System.Windows.Forms.Label lbModelName;
        private System.Windows.Forms.ComboBox txtModelCode;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbThongbao;
    }
}