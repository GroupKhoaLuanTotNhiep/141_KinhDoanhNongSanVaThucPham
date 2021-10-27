namespace _141_KinhDoanhNongSanVaThucPham
{
    partial class frmGiaoHang
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
            this.uC_GiaoHang = new _141_KinhDoanhNongSanVaThucPham.UC_GiaoHang();
            this.SuspendLayout();
            // 
            // uC_GiaoHang
            // 
            this.uC_GiaoHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_GiaoHang.Location = new System.Drawing.Point(0, 0);
            this.uC_GiaoHang.Name = "uC_GiaoHang";
            this.uC_GiaoHang.Size = new System.Drawing.Size(1391, 738);
            this.uC_GiaoHang.TabIndex = 0;
            // 
            // frmGiaoHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1391, 738);
            this.Controls.Add(this.uC_GiaoHang);
            this.Name = "frmGiaoHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lập phiếu giao hàng";
            this.ResumeLayout(false);

        }

        #endregion

        private UC_GiaoHang uC_GiaoHang;

    }
}