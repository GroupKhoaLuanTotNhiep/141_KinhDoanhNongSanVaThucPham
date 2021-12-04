namespace _141_KinhDoanhNongSanVaThucPham
{
    partial class frmYeuCauTichDiem
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTongTienHDNho = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDiemCong = new System.Windows.Forms.TextBox();
            this.txtDiemCongHD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTongTienHDLon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hóa đơn mua hàng của khách hàng phải từ";
           
            // 
            // txtTongTienHDNho
            // 
            this.txtTongTienHDNho.Location = new System.Drawing.Point(389, 26);
            this.txtTongTienHDNho.Name = "txtTongTienHDNho";
            this.txtTongTienHDNho.Size = new System.Drawing.Size(100, 27);
            this.txtTongTienHDNho.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "sẽ được cộng điểm tích lũy lên thêm";
            // 
            // txtDiemCong
            // 
            this.txtDiemCong.Location = new System.Drawing.Point(341, 64);
            this.txtDiemCong.Name = "txtDiemCong";
            this.txtDiemCong.Size = new System.Drawing.Size(100, 27);
            this.txtDiemCong.TabIndex = 3;
            // 
            // txtDiemCongHD
            // 
            this.txtDiemCongHD.Location = new System.Drawing.Point(341, 145);
            this.txtDiemCongHD.Name = "txtDiemCongHD";
            this.txtDiemCongHD.Size = new System.Drawing.Size(100, 27);
            this.txtDiemCongHD.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(277, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "sẽ được cộng điểm tích lũy lên thêm";
            // 
            // txtTongTienHDLon
            // 
            this.txtTongTienHDLon.Location = new System.Drawing.Point(359, 107);
            this.txtTongTienHDLon.Name = "txtTongTienHDLon";
            this.txtTongTienHDLon.Size = new System.Drawing.Size(130, 27);
            this.txtTongTienHDLon.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 110);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(291, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Hóa đơn mua hàng của khách hàng từ";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(188, 192);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 40);
            this.btnLuu.TabIndex = 8;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(296, 192);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 40);
            this.btnSua.TabIndex = 9;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // frmYeuCauTichDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 263);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtDiemCongHD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTongTienHDLon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDiemCong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTongTienHDNho);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmYeuCauTichDiem";
            this.Text = "Yêu cầu tích điểm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTongTienHDNho;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDiemCong;
        private System.Windows.Forms.TextBox txtDiemCongHD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTongTienHDLon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
    }
}