namespace _141_KinhDoanhNongSanVaThucPham
{
    partial class frmXuatKho
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
            this.uC_XuatKho = new _141_KinhDoanhNongSanVaThucPham.UC_XuatKho();
            this.SuspendLayout();
            // 
            // uC_XuatKho
            // 
            this.uC_XuatKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_XuatKho.Location = new System.Drawing.Point(0, 0);
            this.uC_XuatKho.Name = "uC_XuatKho";
            this.uC_XuatKho.Size = new System.Drawing.Size(1389, 728);
            this.uC_XuatKho.TabIndex = 0;
            // 
            // frmXuatKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1389, 728);
            this.Controls.Add(this.uC_XuatKho);
            this.Name = "frmXuatKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xuất hàng ra quầy";
            this.ResumeLayout(false);

        }

        #endregion

        private UC_XuatKho uC_XuatKho;

    }
}