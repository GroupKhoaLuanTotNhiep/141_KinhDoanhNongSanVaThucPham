namespace _141_KinhDoanhNongSanVaThucPham
{
    partial class frmTinhLuong
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTinhLuong = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGV_LuongNhanVien = new System.Windows.Forms.DataGridView();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LuongCoBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoNgayLam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhuCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.lblTenNV = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.txtPhuCap = new System.Windows.Forms.TextBox();
            this.lblPhuCap = new System.Windows.Forms.Label();
            this.txtSoNgayLam = new System.Windows.Forms.TextBox();
            this.lblSoNgayLam = new System.Windows.Forms.Label();
            this.txtTienThuong = new System.Windows.Forms.TextBox();
            this.lblTienThuong = new System.Windows.Forms.Label();
            this.txtTienPhat = new System.Windows.Forms.TextBox();
            this.lblTienPhat = new System.Windows.Forms.Label();
            this.lblDVTien = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnChamCong = new System.Windows.Forms.Button();
            this.btnCapNhatLNV = new System.Windows.Forms.Button();
            this.btnInExcel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_LuongNhanVien)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblTinhLuong, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGV_LuongNhanVien, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1282, 703);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblTinhLuong
            // 
            this.lblTinhLuong.AutoSize = true;
            this.lblTinhLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTinhLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTinhLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTinhLuong.Location = new System.Drawing.Point(3, 0);
            this.lblTinhLuong.Name = "lblTinhLuong";
            this.lblTinhLuong.Size = new System.Drawing.Size(1276, 70);
            this.lblTinhLuong.TabIndex = 0;
            this.lblTinhLuong.Text = "BẢNG TÍNH LƯƠNG NHÂN VIÊN";
            this.lblTinhLuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 73);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1276, 204);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // dataGV_LuongNhanVien
            // 
            this.dataGV_LuongNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV_LuongNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNV,
            this.TenNV,
            this.HeSoLuong,
            this.LuongCoBan,
            this.SoNgayLam,
            this.PhuCap,
            this.Thuong,
            this.Phat,
            this.TongLuong});
            this.dataGV_LuongNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGV_LuongNhanVien.Location = new System.Drawing.Point(3, 283);
            this.dataGV_LuongNhanVien.Name = "dataGV_LuongNhanVien";
            this.dataGV_LuongNhanVien.RowTemplate.Height = 24;
            this.dataGV_LuongNhanVien.Size = new System.Drawing.Size(1276, 417);
            this.dataGV_LuongNhanVien.TabIndex = 2;
            // 
            // MaNV
            // 
            this.MaNV.HeaderText = "Mã nhân viên";
            this.MaNV.Name = "MaNV";
            this.MaNV.Width = 130;
            // 
            // TenNV
            // 
            this.TenNV.HeaderText = "Tên nhân viên";
            this.TenNV.Name = "TenNV";
            this.TenNV.Width = 200;
            // 
            // HeSoLuong
            // 
            this.HeSoLuong.HeaderText = "Hệ số lương";
            this.HeSoLuong.Name = "HeSoLuong";
            this.HeSoLuong.Width = 120;
            // 
            // LuongCoBan
            // 
            this.LuongCoBan.HeaderText = "Lương cơ bản";
            this.LuongCoBan.Name = "LuongCoBan";
            this.LuongCoBan.Width = 130;
            // 
            // SoNgayLam
            // 
            this.SoNgayLam.HeaderText = "Số ngày làm";
            this.SoNgayLam.Name = "SoNgayLam";
            this.SoNgayLam.Width = 120;
            // 
            // PhuCap
            // 
            this.PhuCap.HeaderText = "Phụ cấp";
            this.PhuCap.Name = "PhuCap";
            this.PhuCap.Width = 120;
            // 
            // Thuong
            // 
            this.Thuong.HeaderText = "Tiền thưởng";
            this.Thuong.Name = "Thuong";
            this.Thuong.Width = 120;
            // 
            // Phat
            // 
            this.Phat.HeaderText = "Tiền phạt";
            this.Phat.Name = "Phat";
            this.Phat.Width = 120;
            // 
            // TongLuong
            // 
            this.TongLuong.HeaderText = "Tổng lương";
            this.TongLuong.Name = "TongLuong";
            this.TongLuong.Width = 150;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDVTien);
            this.panel1.Controls.Add(this.txtTienPhat);
            this.panel1.Controls.Add(this.lblTienPhat);
            this.panel1.Controls.Add(this.txtTienThuong);
            this.panel1.Controls.Add(this.lblTienThuong);
            this.panel1.Controls.Add(this.txtPhuCap);
            this.panel1.Controls.Add(this.lblPhuCap);
            this.panel1.Controls.Add(this.txtSoNgayLam);
            this.panel1.Controls.Add(this.lblSoNgayLam);
            this.panel1.Controls.Add(this.txtTenNV);
            this.panel1.Controls.Add(this.lblTenNV);
            this.panel1.Controls.Add(this.txtMaNV);
            this.panel1.Controls.Add(this.lblMaNV);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(887, 198);
            this.panel1.TabIndex = 0;
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(408, 39);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(200, 22);
            this.txtTenNV.TabIndex = 7;
            // 
            // lblTenNV
            // 
            this.lblTenNV.AutoSize = true;
            this.lblTenNV.Location = new System.Drawing.Point(303, 42);
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Size = new System.Drawing.Size(99, 17);
            this.lblTenNV.TabIndex = 6;
            this.lblTenNV.Text = "Tên nhân viên";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(145, 39);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(100, 22);
            this.txtMaNV.TabIndex = 5;
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Location = new System.Drawing.Point(46, 42);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(93, 17);
            this.lblMaNV.TabIndex = 4;
            this.lblMaNV.Text = "Mã nhân viên";
            // 
            // txtPhuCap
            // 
            this.txtPhuCap.Location = new System.Drawing.Point(112, 86);
            this.txtPhuCap.Name = "txtPhuCap";
            this.txtPhuCap.Size = new System.Drawing.Size(150, 22);
            this.txtPhuCap.TabIndex = 11;
            // 
            // lblPhuCap
            // 
            this.lblPhuCap.AutoSize = true;
            this.lblPhuCap.Location = new System.Drawing.Point(46, 89);
            this.lblPhuCap.Name = "lblPhuCap";
            this.lblPhuCap.Size = new System.Drawing.Size(60, 17);
            this.lblPhuCap.TabIndex = 10;
            this.lblPhuCap.Text = "Phụ cấp";
            // 
            // txtSoNgayLam
            // 
            this.txtSoNgayLam.Location = new System.Drawing.Point(762, 39);
            this.txtSoNgayLam.Name = "txtSoNgayLam";
            this.txtSoNgayLam.Size = new System.Drawing.Size(100, 22);
            this.txtSoNgayLam.TabIndex = 9;
            // 
            // lblSoNgayLam
            // 
            this.lblSoNgayLam.AutoSize = true;
            this.lblSoNgayLam.Location = new System.Drawing.Point(670, 42);
            this.lblSoNgayLam.Name = "lblSoNgayLam";
            this.lblSoNgayLam.Size = new System.Drawing.Size(86, 17);
            this.lblSoNgayLam.TabIndex = 8;
            this.lblSoNgayLam.Text = "Số ngày làm";
            // 
            // txtTienThuong
            // 
            this.txtTienThuong.Location = new System.Drawing.Point(408, 86);
            this.txtTienThuong.Name = "txtTienThuong";
            this.txtTienThuong.Size = new System.Drawing.Size(150, 22);
            this.txtTienThuong.TabIndex = 13;
            // 
            // lblTienThuong
            // 
            this.lblTienThuong.AutoSize = true;
            this.lblTienThuong.Location = new System.Drawing.Point(318, 89);
            this.lblTienThuong.Name = "lblTienThuong";
            this.lblTienThuong.Size = new System.Drawing.Size(84, 17);
            this.lblTienThuong.TabIndex = 12;
            this.lblTienThuong.Text = "Tiền thưởng";
            // 
            // txtTienPhat
            // 
            this.txtTienPhat.Location = new System.Drawing.Point(712, 86);
            this.txtTienPhat.Name = "txtTienPhat";
            this.txtTienPhat.Size = new System.Drawing.Size(150, 22);
            this.txtTienPhat.TabIndex = 15;
            // 
            // lblTienPhat
            // 
            this.lblTienPhat.AutoSize = true;
            this.lblTienPhat.Location = new System.Drawing.Point(638, 89);
            this.lblTienPhat.Name = "lblTienPhat";
            this.lblTienPhat.Size = new System.Drawing.Size(68, 17);
            this.lblTienPhat.TabIndex = 14;
            this.lblTienPhat.Text = "Tiền phạt";
            // 
            // lblDVTien
            // 
            this.lblDVTien.AutoSize = true;
            this.lblDVTien.Location = new System.Drawing.Point(735, 165);
            this.lblDVTien.Name = "lblDVTien";
            this.lblDVTien.Size = new System.Drawing.Size(127, 17);
            this.lblDVTien.TabIndex = 16;
            this.lblDVTien.Text = "(*) Đơn vị tiền VNĐ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnInExcel);
            this.panel2.Controls.Add(this.btnCapNhatLNV);
            this.panel2.Controls.Add(this.btnChamCong);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(896, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(377, 198);
            this.panel2.TabIndex = 1;
            // 
            // btnChamCong
            // 
            this.btnChamCong.Location = new System.Drawing.Point(95, 39);
            this.btnChamCong.Name = "btnChamCong";
            this.btnChamCong.Size = new System.Drawing.Size(200, 30);
            this.btnChamCong.TabIndex = 0;
            this.btnChamCong.Text = "Chấm công";
            this.btnChamCong.UseVisualStyleBackColor = true;
            this.btnChamCong.Click += new System.EventHandler(this.btnChamCong_Click);
            // 
            // btnCapNhatLNV
            // 
            this.btnCapNhatLNV.Location = new System.Drawing.Point(95, 87);
            this.btnCapNhatLNV.Name = "btnCapNhatLNV";
            this.btnCapNhatLNV.Size = new System.Drawing.Size(200, 30);
            this.btnCapNhatLNV.TabIndex = 1;
            this.btnCapNhatLNV.Text = "Cập nhật";
            this.btnCapNhatLNV.UseVisualStyleBackColor = true;
            // 
            // btnInExcel
            // 
            this.btnInExcel.Location = new System.Drawing.Point(95, 135);
            this.btnInExcel.Name = "btnInExcel";
            this.btnInExcel.Size = new System.Drawing.Size(200, 30);
            this.btnInExcel.TabIndex = 2;
            this.btnInExcel.Text = "In Excel";
            this.btnInExcel.UseVisualStyleBackColor = true;
            // 
            // frmTinhLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 703);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmTinhLuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tính lương nhân viên";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_LuongNhanVien)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTinhLuong;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dataGV_LuongNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn LuongCoBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoNgayLam;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhuCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phat;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongLuong;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDVTien;
        private System.Windows.Forms.TextBox txtTienPhat;
        private System.Windows.Forms.Label lblTienPhat;
        private System.Windows.Forms.TextBox txtTienThuong;
        private System.Windows.Forms.Label lblTienThuong;
        private System.Windows.Forms.TextBox txtPhuCap;
        private System.Windows.Forms.Label lblPhuCap;
        private System.Windows.Forms.TextBox txtSoNgayLam;
        private System.Windows.Forms.Label lblSoNgayLam;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.Label lblTenNV;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCapNhatLNV;
        private System.Windows.Forms.Button btnChamCong;
        private System.Windows.Forms.Button btnInExcel;
    }
}