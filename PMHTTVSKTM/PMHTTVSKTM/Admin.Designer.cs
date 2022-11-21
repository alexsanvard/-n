namespace PMHTTVSKTM
{
    partial class fAdmin
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
            this.dtgvAccount = new System.Windows.Forms.DataGridView();
            this.btnDathen = new System.Windows.Forms.Button();
            this.btnChuanDoan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvAccount
            // 
            this.dtgvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvAccount.Location = new System.Drawing.Point(12, 60);
            this.dtgvAccount.Name = "dtgvAccount";
            this.dtgvAccount.RowHeadersWidth = 51;
            this.dtgvAccount.RowTemplate.Height = 24;
            this.dtgvAccount.Size = new System.Drawing.Size(608, 185);
            this.dtgvAccount.TabIndex = 0;
            // 
            // btnDathen
            // 
            this.btnDathen.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDathen.Location = new System.Drawing.Point(12, 9);
            this.btnDathen.Name = "btnDathen";
            this.btnDathen.Size = new System.Drawing.Size(208, 45);
            this.btnDathen.TabIndex = 1;
            this.btnDathen.Text = "Chỉnh sửa đặt hẹn";
            this.btnDathen.UseVisualStyleBackColor = true;
            this.btnDathen.Click += new System.EventHandler(this.btnDathen_Click);
            // 
            // btnChuanDoan
            // 
            this.btnChuanDoan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnChuanDoan.Location = new System.Drawing.Point(240, 9);
            this.btnChuanDoan.Name = "btnChuanDoan";
            this.btnChuanDoan.Size = new System.Drawing.Size(266, 45);
            this.btnChuanDoan.TabIndex = 2;
            this.btnChuanDoan.Text = "Chỉnh sửa chuẩn đoán bệnh";
            this.btnChuanDoan.UseVisualStyleBackColor = true;
            this.btnChuanDoan.Click += new System.EventHandler(this.btnChuanDoan_Click);
            // 
            // fAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 277);
            this.Controls.Add(this.btnChuanDoan);
            this.Controls.Add(this.btnDathen);
            this.Controls.Add(this.dtgvAccount);
            this.Name = "fAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvAccount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvAccount;
        private System.Windows.Forms.Button btnDathen;
        private System.Windows.Forms.Button btnChuanDoan;
    }
}