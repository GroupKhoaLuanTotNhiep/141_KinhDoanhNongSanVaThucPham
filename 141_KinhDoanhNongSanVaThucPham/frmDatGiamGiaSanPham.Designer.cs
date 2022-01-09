namespace _141_KinhDoanhNongSanVaThucPham
{
    partial class frmDatGiamGiaSanPham
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
            this.lblMaSP = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.txtPhanTramGiam = new System.Windows.Forms.TextBox();
            this.lblPhanTramGiam = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnApDung = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMaSP
            // 
            this.lblMaSP.AutoSize = true;
            this.lblMaSP.Location = new System.Drawing.Point(35, 37);
            this.lblMaSP.Name = "lblMaSP";
            this.lblMaSP.Size = new System.Drawing.Size(49, 17);
            this.lblMaSP.TabIndex = 0;
            this.lblMaSP.Text = "Mã SP";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(166, 34);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(100, 22);
            this.txtMaSP.TabIndex = 1;
            // 
            // txtPhanTramGiam
            // 
            this.txtPhanTramGiam.Location = new System.Drawing.Point(166, 79);
            this.txtPhanTramGiam.Name = "txtPhanTramGiam";
            this.txtPhanTramGiam.Size = new System.Drawing.Size(100, 22);
            this.txtPhanTramGiam.TabIndex = 3;
            this.txtPhanTramGiam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhanTramGiam_KeyPress);
            // 
            // lblPhanTramGiam
            // 
            this.lblPhanTramGiam.AutoSize = true;
            this.lblPhanTramGiam.Location = new System.Drawing.Point(35, 82);
            this.lblPhanTramGiam.Name = "lblPhanTramGiam";
            this.lblPhanTramGiam.Size = new System.Drawing.Size(107, 17);
            this.lblPhanTramGiam.TabIndex = 2;
            this.lblPhanTramGiam.Text = "Phần trăm giảm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(288, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "(Điền theo dạng 0.0)";
            // 
            // btnApDung
            // 
            this.btnApDung.Location = new System.Drawing.Point(155, 137);
            this.btnApDung.Name = "btnApDung";
            this.btnApDung.Size = new System.Drawing.Size(150, 30);
            this.btnApDung.TabIndex = 5;
            this.btnApDung.Text = "Áp dụng";
            this.btnApDung.UseVisualStyleBackColor = true;
            this.btnApDung.Click += new System.EventHandler(this.btnApDung_Click);
            // 
            // frmDatGiamGiaSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 198);
            this.Controls.Add(this.btnApDung);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPhanTramGiam);
            this.Controls.Add(this.lblPhanTramGiam);
            this.Controls.Add(this.txtMaSP);
            this.Controls.Add(this.lblMaSP);
            this.Name = "frmDatGiamGiaSanPham";
            this.Text = "Thông tin giảm giá sản phẩm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaSP;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.TextBox txtPhanTramGiam;
        private System.Windows.Forms.Label lblPhanTramGiam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApDung;
    }
}