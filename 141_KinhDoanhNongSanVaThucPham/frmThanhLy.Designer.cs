namespace _141_KinhDoanhNongSanVaThucPham
{
    partial class frmThanhLy
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
            this.uC_ThanhLy = new _141_KinhDoanhNongSanVaThucPham.UC_ThanhLy();
            this.SuspendLayout();
            // 
            // uC_ThanhLy
            // 
            this.uC_ThanhLy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_ThanhLy.Location = new System.Drawing.Point(0, 0);
            this.uC_ThanhLy.Name = "uC_ThanhLy";
            this.uC_ThanhLy.Size = new System.Drawing.Size(1365, 727);
            this.uC_ThanhLy.TabIndex = 0;
            // 
            // frmThanhLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 727);
            this.Controls.Add(this.uC_ThanhLy);
            this.Name = "frmThanhLy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh lý sản phẩm";
            this.ResumeLayout(false);

        }

        #endregion

        private UC_ThanhLy uC_ThanhLy;

    }
}