namespace Trace_Projector
{
    partial class frmAddNewModel
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.MODEL_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODEL_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PCB_QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OPTICAL_QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OPTICAL2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LEN_QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DMD_QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OTHER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(979, 426);
            this.dataGridView1.TabIndex = 86;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(895, 498);
            this.button2.Margin = new System.Windows.Forms.Padding(10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 41);
            this.button2.TabIndex = 85;
            this.button2.Text = "Copy Data";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(895, 559);
            this.button1.Margin = new System.Windows.Forms.Padding(10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 41);
            this.button1.TabIndex = 84;
            this.button1.Text = "Input";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MODEL_CODE,
            this.MODEL_NAME,
            this.PCB_QTY,
            this.OPTICAL_QTY,
            this.OPTICAL2,
            this.LEN_QTY,
            this.DMD_QTY,
            this.OTHER});
            this.dataGridView2.Location = new System.Drawing.Point(21, 498);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(819, 275);
            this.dataGridView2.TabIndex = 83;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(360, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 33);
            this.label1.TabIndex = 82;
            this.label1.Text = "Master Model";
            // 
            // MODEL_CODE
            // 
            this.MODEL_CODE.HeaderText = "MODEL_CODE";
            this.MODEL_CODE.Name = "MODEL_CODE";
            // 
            // MODEL_NAME
            // 
            this.MODEL_NAME.HeaderText = "MODEL_NAME";
            this.MODEL_NAME.Name = "MODEL_NAME";
            // 
            // PCB_QTY
            // 
            this.PCB_QTY.HeaderText = "PCB_QTY";
            this.PCB_QTY.Name = "PCB_QTY";
            // 
            // OPTICAL_QTY
            // 
            this.OPTICAL_QTY.HeaderText = "OPTICAL_QTY";
            this.OPTICAL_QTY.Name = "OPTICAL_QTY";
            // 
            // OPTICAL2
            // 
            this.OPTICAL2.HeaderText = "OPTICAL2";
            this.OPTICAL2.Name = "OPTICAL2";
            // 
            // LEN_QTY
            // 
            this.LEN_QTY.HeaderText = "LEN_QTY";
            this.LEN_QTY.Name = "LEN_QTY";
            // 
            // DMD_QTY
            // 
            this.DMD_QTY.HeaderText = "DMD_QTY";
            this.DMD_QTY.Name = "DMD_QTY";
            // 
            // OTHER
            // 
            this.OTHER.HeaderText = "OTHER";
            this.OTHER.Name = "OTHER";
            // 
            // frmAddNewModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 803);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label1);
            this.Name = "frmAddNewModel";
            this.Text = "frmAddNewModel";
            this.Load += new System.EventHandler(this.frmAddNewModel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODEL_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODEL_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PCB_QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn OPTICAL_QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn OPTICAL2;
        private System.Windows.Forms.DataGridViewTextBoxColumn LEN_QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn DMD_QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn OTHER;
    }
}