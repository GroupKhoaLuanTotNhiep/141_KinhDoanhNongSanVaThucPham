namespace _141_KinhDoanhNongSanVaThucPham
{
    partial class frmNhapKho
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
            this.uC_NhapKho = new _141_KinhDoanhNongSanVaThucPham.UC_NhapKho();
            this.SuspendLayout();
            // 
            // uC_NhapKho
            // 
            this.uC_NhapKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_NhapKho.Location = new System.Drawing.Point(0, 0);
            this.uC_NhapKho.Name = "uC_NhapKho";
            this.uC_NhapKho.Size = new System.Drawing.Size(1406, 739);
            this.uC_NhapKho.TabIndex = 0;
            // 
            // frmNhapKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1406, 739);
            this.Controls.Add(this.uC_NhapKho);
            this.Name = "frmNhapKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập hàng vào kho";
            this.ResumeLayout(false);

        }

        #endregion

        private UC_NhapKho uC_NhapKho;

    }
}