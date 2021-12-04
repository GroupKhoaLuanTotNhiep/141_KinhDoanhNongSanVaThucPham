namespace _141_KinhDoanhNongSanVaThucPham
{
    partial class frmLuuNoNhaCungCap
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
            this.btnLuu = new System.Windows.Forms.Button();
            this.lblTienNhapThem = new System.Windows.Forms.Label();
            this.txtTienTraThem = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(154, 84);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 30);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // lblTienNhapThem
            // 
            this.lblTienNhapThem.AutoSize = true;
            this.lblTienNhapThem.Location = new System.Drawing.Point(92, 35);
            this.lblTienNhapThem.Name = "lblTienNhapThem";
            this.lblTienNhapThem.Size = new System.Drawing.Size(92, 17);
            this.lblTienNhapThem.TabIndex = 5;
            this.lblTienNhapThem.Text = "Tiền trả thêm";
            // 
            // txtTienTraThem
            // 
            this.txtTienTraThem.Location = new System.Drawing.Point(205, 32);
            this.txtTienTraThem.Name = "txtTienTraThem";
            this.txtTienTraThem.Size = new System.Drawing.Size(100, 22);
            this.txtTienTraThem.TabIndex = 4;
            // 
            // frmLuuNoNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 148);
            this.Controls.Add(this.lblTienNhapThem);
            this.Controls.Add(this.txtTienTraThem);
            this.Controls.Add(this.btnLuu);
            this.Name = "frmLuuNoNhaCungCap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "From Xác nhận lưu nợ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label lblTienNhapThem;
        private System.Windows.Forms.TextBox txtTienTraThem;
    }
}