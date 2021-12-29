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
            this.btnDong = new System.Windows.Forms.Button();
            this.dataGV_TichDiem = new System.Windows.Forms.DataGridView();
            this.MaYeuCau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayThayDoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GTHoaDonBT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TichLuyBT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GTHoaDonLon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TichLuyLon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_TichDiem)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hóa đơn mua hàng của khách hàng phải từ";
            // 
            // txtTongTienHDNho
            // 
            this.txtTongTienHDNho.Location = new System.Drawing.Point(499, 31);
            this.txtTongTienHDNho.Name = "txtTongTienHDNho";
            this.txtTongTienHDNho.Size = new System.Drawing.Size(100, 27);
            this.txtTongTienHDNho.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "sẽ được cộng điểm tích lũy lên thêm";
            // 
            // txtDiemCong
            // 
            this.txtDiemCong.Location = new System.Drawing.Point(451, 69);
            this.txtDiemCong.Name = "txtDiemCong";
            this.txtDiemCong.Size = new System.Drawing.Size(100, 27);
            this.txtDiemCong.TabIndex = 3;
            // 
            // txtDiemCongHD
            // 
            this.txtDiemCongHD.Location = new System.Drawing.Point(451, 150);
            this.txtDiemCongHD.Name = "txtDiemCongHD";
            this.txtDiemCongHD.Size = new System.Drawing.Size(100, 27);
            this.txtDiemCongHD.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(277, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "sẽ được cộng điểm tích lũy lên thêm";
            // 
            // txtTongTienHDLon
            // 
            this.txtTongTienHDLon.Location = new System.Drawing.Point(469, 112);
            this.txtTongTienHDLon.Name = "txtTongTienHDLon";
            this.txtTongTienHDLon.Size = new System.Drawing.Size(130, 27);
            this.txtTongTienHDLon.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 115);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(291, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Hóa đơn mua hàng của khách hàng từ";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(269, 431);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 40);
            this.btnLuu.TabIndex = 8;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(497, 431);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 40);
            this.btnDong.TabIndex = 9;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // dataGV_TichDiem
            // 
            this.dataGV_TichDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV_TichDiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaYeuCau,
            this.NgayThayDoi,
            this.GTHoaDonBT,
            this.TichLuyBT,
            this.GTHoaDonLon,
            this.TichLuyLon});
            this.dataGV_TichDiem.Location = new System.Drawing.Point(12, 204);
            this.dataGV_TichDiem.Name = "dataGV_TichDiem";
            this.dataGV_TichDiem.RowTemplate.Height = 24;
            this.dataGV_TichDiem.Size = new System.Drawing.Size(805, 199);
            this.dataGV_TichDiem.TabIndex = 10;
            this.dataGV_TichDiem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGV_TichDiem_CellClick);
            // 
            // MaYeuCau
            // 
            this.MaYeuCau.DataPropertyName = "MaYeuCau";
            this.MaYeuCau.HeaderText = "Mã YC";
            this.MaYeuCau.Name = "MaYeuCau";
            // 
            // NgayThayDoi
            // 
            this.NgayThayDoi.DataPropertyName = "NgayThayDoi";
            this.NgayThayDoi.HeaderText = "Ngày đổi";
            this.NgayThayDoi.Name = "NgayThayDoi";
            this.NgayThayDoi.Width = 120;
            // 
            // GTHoaDonBT
            // 
            this.GTHoaDonBT.DataPropertyName = "GTHoaDonBT";
            this.GTHoaDonBT.HeaderText = "Giá trị HĐ nhỏ";
            this.GTHoaDonBT.Name = "GTHoaDonBT";
            this.GTHoaDonBT.Width = 150;
            // 
            // TichLuyBT
            // 
            this.TichLuyBT.DataPropertyName = "TichLuyBT";
            this.TichLuyBT.HeaderText = "Điểm TL";
            this.TichLuyBT.Name = "TichLuyBT";
            this.TichLuyBT.Width = 120;
            // 
            // GTHoaDonLon
            // 
            this.GTHoaDonLon.DataPropertyName = "GTHoaDonLon";
            this.GTHoaDonLon.HeaderText = "Giá trị HĐ lớn";
            this.GTHoaDonLon.Name = "GTHoaDonLon";
            this.GTHoaDonLon.Width = 150;
            // 
            // TichLuyLon
            // 
            this.TichLuyLon.DataPropertyName = "TichLuyLon";
            this.TichLuyLon.HeaderText = "Điểm TL";
            this.TichLuyLon.Name = "TichLuyLon";
            this.TichLuyLon.Width = 120;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(569, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "(cho HĐ nhỏ)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(569, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "(cho HĐ lớn)";
            // 
            // frmYeuCauTichDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 503);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGV_TichDiem);
            this.Controls.Add(this.btnDong);
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
            this.Load += new System.EventHandler(this.frmYeuCauTichDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_TichDiem)).EndInit();
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
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridView dataGV_TichDiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaYeuCau;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayThayDoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn GTHoaDonBT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TichLuyBT;
        private System.Windows.Forms.DataGridViewTextBoxColumn GTHoaDonLon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TichLuyLon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}