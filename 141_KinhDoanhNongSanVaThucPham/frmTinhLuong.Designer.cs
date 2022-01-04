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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNgayTinhLuong = new System.Windows.Forms.Label();
            this.txtNgayTinhLuong = new System.Windows.Forms.DateTimePicker();
            this.btnXem = new System.Windows.Forms.Button();
            this.lblNgayCuoi = new System.Windows.Forms.Label();
            this.txtDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblNgayDau = new System.Windows.Forms.Label();
            this.txtTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDVTien = new System.Windows.Forms.Label();
            this.txtTienPhat = new System.Windows.Forms.TextBox();
            this.lblTienPhat = new System.Windows.Forms.Label();
            this.txtTienThuong = new System.Windows.Forms.TextBox();
            this.lblTienThuong = new System.Windows.Forms.Label();
            this.txtPhuCap = new System.Windows.Forms.TextBox();
            this.lblPhuCap = new System.Windows.Forms.Label();
            this.txtSoNgayLam = new System.Windows.Forms.TextBox();
            this.lblSoNgayLam = new System.Windows.Forms.Label();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.lblTenNV = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnXoaThongTin = new System.Windows.Forms.Button();
            this.btnSuaThongTin = new System.Windows.Forms.Button();
            this.btnInExcel = new System.Windows.Forms.Button();
            this.btnCapNhatLNV = new System.Windows.Forms.Button();
            this.btnChamCong = new System.Windows.Forms.Button();
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
            this.NgayTinhLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_LuongNhanVien)).BeginInit();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1402, 753);
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
            this.lblTinhLuong.Size = new System.Drawing.Size(1396, 75);
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 78);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 219F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1396, 219);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblNgayTinhLuong);
            this.panel1.Controls.Add(this.txtNgayTinhLuong);
            this.panel1.Controls.Add(this.btnXem);
            this.panel1.Controls.Add(this.lblNgayCuoi);
            this.panel1.Controls.Add(this.txtDenNgay);
            this.panel1.Controls.Add(this.lblNgayDau);
            this.panel1.Controls.Add(this.txtTuNgay);
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
            this.panel1.Size = new System.Drawing.Size(971, 213);
            this.panel1.TabIndex = 0;
            // 
            // lblNgayTinhLuong
            // 
            this.lblNgayTinhLuong.AutoSize = true;
            this.lblNgayTinhLuong.Location = new System.Drawing.Point(65, 143);
            this.lblNgayTinhLuong.Name = "lblNgayTinhLuong";
            this.lblNgayTinhLuong.Size = new System.Drawing.Size(107, 17);
            this.lblNgayTinhLuong.TabIndex = 23;
            this.lblNgayTinhLuong.Text = "Ngày tính lương";
            // 
            // txtNgayTinhLuong
            // 
            this.txtNgayTinhLuong.CustomFormat = "dd/MM/yyyy";
            this.txtNgayTinhLuong.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtNgayTinhLuong.Location = new System.Drawing.Point(178, 141);
            this.txtNgayTinhLuong.Name = "txtNgayTinhLuong";
            this.txtNgayTinhLuong.Size = new System.Drawing.Size(150, 22);
            this.txtNgayTinhLuong.TabIndex = 22;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(806, 137);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 30);
            this.btnXem.TabIndex = 21;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // lblNgayCuoi
            // 
            this.lblNgayCuoi.AutoSize = true;
            this.lblNgayCuoi.Location = new System.Drawing.Point(610, 144);
            this.lblNgayCuoi.Name = "lblNgayCuoi";
            this.lblNgayCuoi.Size = new System.Drawing.Size(34, 17);
            this.lblNgayCuoi.TabIndex = 20;
            this.lblNgayCuoi.Text = "Đến";
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.CustomFormat = "dd/MM/yyyy";
            this.txtDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDenNgay.Location = new System.Drawing.Point(650, 141);
            this.txtDenNgay.Name = "txtDenNgay";
            this.txtDenNgay.Size = new System.Drawing.Size(150, 22);
            this.txtDenNgay.TabIndex = 19;
            // 
            // lblNgayDau
            // 
            this.lblNgayDau.AutoSize = true;
            this.lblNgayDau.Location = new System.Drawing.Point(419, 144);
            this.lblNgayDau.Name = "lblNgayDau";
            this.lblNgayDau.Size = new System.Drawing.Size(25, 17);
            this.lblNgayDau.TabIndex = 18;
            this.lblNgayDau.Text = "Từ";
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.CustomFormat = "dd/MM/yyyy";
            this.txtTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTuNgay.Location = new System.Drawing.Point(450, 141);
            this.txtTuNgay.Name = "txtTuNgay";
            this.txtTuNgay.Size = new System.Drawing.Size(150, 22);
            this.txtTuNgay.TabIndex = 17;
            // 
            // lblDVTien
            // 
            this.lblDVTien.AutoSize = true;
            this.lblDVTien.Location = new System.Drawing.Point(754, 174);
            this.lblDVTien.Name = "lblDVTien";
            this.lblDVTien.Size = new System.Drawing.Size(127, 17);
            this.lblDVTien.TabIndex = 16;
            this.lblDVTien.Text = "(*) Đơn vị tiền VNĐ";
            // 
            // txtTienPhat
            // 
            this.txtTienPhat.Location = new System.Drawing.Point(731, 86);
            this.txtTienPhat.Name = "txtTienPhat";
            this.txtTienPhat.Size = new System.Drawing.Size(150, 22);
            this.txtTienPhat.TabIndex = 15;
            // 
            // lblTienPhat
            // 
            this.lblTienPhat.AutoSize = true;
            this.lblTienPhat.Location = new System.Drawing.Point(657, 89);
            this.lblTienPhat.Name = "lblTienPhat";
            this.lblTienPhat.Size = new System.Drawing.Size(68, 17);
            this.lblTienPhat.TabIndex = 14;
            this.lblTienPhat.Text = "Tiền phạt";
            // 
            // txtTienThuong
            // 
            this.txtTienThuong.Location = new System.Drawing.Point(427, 86);
            this.txtTienThuong.Name = "txtTienThuong";
            this.txtTienThuong.Size = new System.Drawing.Size(150, 22);
            this.txtTienThuong.TabIndex = 13;
            // 
            // lblTienThuong
            // 
            this.lblTienThuong.AutoSize = true;
            this.lblTienThuong.Location = new System.Drawing.Point(337, 89);
            this.lblTienThuong.Name = "lblTienThuong";
            this.lblTienThuong.Size = new System.Drawing.Size(84, 17);
            this.lblTienThuong.TabIndex = 12;
            this.lblTienThuong.Text = "Tiền thưởng";
            // 
            // txtPhuCap
            // 
            this.txtPhuCap.Location = new System.Drawing.Point(131, 86);
            this.txtPhuCap.Name = "txtPhuCap";
            this.txtPhuCap.Size = new System.Drawing.Size(150, 22);
            this.txtPhuCap.TabIndex = 11;
            // 
            // lblPhuCap
            // 
            this.lblPhuCap.AutoSize = true;
            this.lblPhuCap.Location = new System.Drawing.Point(65, 89);
            this.lblPhuCap.Name = "lblPhuCap";
            this.lblPhuCap.Size = new System.Drawing.Size(60, 17);
            this.lblPhuCap.TabIndex = 10;
            this.lblPhuCap.Text = "Phụ cấp";
            // 
            // txtSoNgayLam
            // 
            this.txtSoNgayLam.Location = new System.Drawing.Point(781, 39);
            this.txtSoNgayLam.Name = "txtSoNgayLam";
            this.txtSoNgayLam.Size = new System.Drawing.Size(100, 22);
            this.txtSoNgayLam.TabIndex = 9;
            // 
            // lblSoNgayLam
            // 
            this.lblSoNgayLam.AutoSize = true;
            this.lblSoNgayLam.Location = new System.Drawing.Point(689, 42);
            this.lblSoNgayLam.Name = "lblSoNgayLam";
            this.lblSoNgayLam.Size = new System.Drawing.Size(86, 17);
            this.lblSoNgayLam.TabIndex = 8;
            this.lblSoNgayLam.Text = "Số ngày làm";
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(427, 39);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(200, 22);
            this.txtTenNV.TabIndex = 7;
            // 
            // lblTenNV
            // 
            this.lblTenNV.AutoSize = true;
            this.lblTenNV.Location = new System.Drawing.Point(322, 42);
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Size = new System.Drawing.Size(99, 17);
            this.lblTenNV.TabIndex = 6;
            this.lblTenNV.Text = "Tên nhân viên";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(164, 39);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(100, 22);
            this.txtMaNV.TabIndex = 5;
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Location = new System.Drawing.Point(65, 42);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(93, 17);
            this.lblMaNV.TabIndex = 4;
            this.lblMaNV.Text = "Mã nhân viên";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnXoaThongTin);
            this.panel2.Controls.Add(this.btnSuaThongTin);
            this.panel2.Controls.Add(this.btnInExcel);
            this.panel2.Controls.Add(this.btnCapNhatLNV);
            this.panel2.Controls.Add(this.btnChamCong);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(980, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(413, 213);
            this.panel2.TabIndex = 1;
            // 
            // btnXoaThongTin
            // 
            this.btnXoaThongTin.Location = new System.Drawing.Point(222, 161);
            this.btnXoaThongTin.Name = "btnXoaThongTin";
            this.btnXoaThongTin.Size = new System.Drawing.Size(90, 30);
            this.btnXoaThongTin.TabIndex = 4;
            this.btnXoaThongTin.Text = "Xóa";
            this.btnXoaThongTin.UseVisualStyleBackColor = true;
            this.btnXoaThongTin.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSuaThongTin
            // 
            this.btnSuaThongTin.Location = new System.Drawing.Point(112, 161);
            this.btnSuaThongTin.Name = "btnSuaThongTin";
            this.btnSuaThongTin.Size = new System.Drawing.Size(90, 30);
            this.btnSuaThongTin.TabIndex = 3;
            this.btnSuaThongTin.Text = "Sửa";
            this.btnSuaThongTin.UseVisualStyleBackColor = true;
            this.btnSuaThongTin.Click += new System.EventHandler(this.btnSuaThongTin_Click);
            // 
            // btnInExcel
            // 
            this.btnInExcel.Location = new System.Drawing.Point(112, 114);
            this.btnInExcel.Name = "btnInExcel";
            this.btnInExcel.Size = new System.Drawing.Size(200, 30);
            this.btnInExcel.TabIndex = 2;
            this.btnInExcel.Text = "In Excel";
            this.btnInExcel.UseVisualStyleBackColor = true;
            this.btnInExcel.Click += new System.EventHandler(this.btnInExcel_Click);
            // 
            // btnCapNhatLNV
            // 
            this.btnCapNhatLNV.Location = new System.Drawing.Point(112, 67);
            this.btnCapNhatLNV.Name = "btnCapNhatLNV";
            this.btnCapNhatLNV.Size = new System.Drawing.Size(200, 30);
            this.btnCapNhatLNV.TabIndex = 1;
            this.btnCapNhatLNV.Text = "Cập nhật";
            this.btnCapNhatLNV.UseVisualStyleBackColor = true;
            this.btnCapNhatLNV.Click += new System.EventHandler(this.btnCapNhatLNV_Click);
            // 
            // btnChamCong
            // 
            this.btnChamCong.Location = new System.Drawing.Point(112, 20);
            this.btnChamCong.Name = "btnChamCong";
            this.btnChamCong.Size = new System.Drawing.Size(200, 30);
            this.btnChamCong.TabIndex = 0;
            this.btnChamCong.Text = "Chấm công";
            this.btnChamCong.UseVisualStyleBackColor = true;
            this.btnChamCong.Click += new System.EventHandler(this.btnChamCong_Click);
            // 
            // dataGV_LuongNhanVien
            // 
            this.dataGV_LuongNhanVien.AllowUserToAddRows = false;
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
            this.TongLuong,
            this.NgayTinhLuong});
            this.dataGV_LuongNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGV_LuongNhanVien.Location = new System.Drawing.Point(3, 303);
            this.dataGV_LuongNhanVien.Name = "dataGV_LuongNhanVien";
            this.dataGV_LuongNhanVien.RowTemplate.Height = 24;
            this.dataGV_LuongNhanVien.Size = new System.Drawing.Size(1396, 447);
            this.dataGV_LuongNhanVien.TabIndex = 2;
            this.dataGV_LuongNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGV_LuongNhanVien_CellClick);
            // 
            // MaNV
            // 
            this.MaNV.DataPropertyName = "MaNV";
            this.MaNV.HeaderText = "Mã NV";
            this.MaNV.Name = "MaNV";
            this.MaNV.Width = 130;
            // 
            // TenNV
            // 
            this.TenNV.DataPropertyName = "TenNV";
            this.TenNV.HeaderText = "Tên NV";
            this.TenNV.Name = "TenNV";
            this.TenNV.Width = 200;
            // 
            // HeSoLuong
            // 
            this.HeSoLuong.DataPropertyName = "HeSoLuong";
            this.HeSoLuong.HeaderText = "Hệ số lương";
            this.HeSoLuong.Name = "HeSoLuong";
            this.HeSoLuong.Width = 120;
            // 
            // LuongCoBan
            // 
            this.LuongCoBan.DataPropertyName = "LuongCoBan";
            this.LuongCoBan.HeaderText = "Lương CB";
            this.LuongCoBan.Name = "LuongCoBan";
            this.LuongCoBan.Width = 130;
            // 
            // SoNgayLam
            // 
            this.SoNgayLam.DataPropertyName = "SoNgayLam";
            this.SoNgayLam.HeaderText = "Số ngày làm";
            this.SoNgayLam.Name = "SoNgayLam";
            this.SoNgayLam.Width = 120;
            // 
            // PhuCap
            // 
            this.PhuCap.DataPropertyName = "PhuCap";
            this.PhuCap.HeaderText = "Phụ cấp";
            this.PhuCap.Name = "PhuCap";
            this.PhuCap.Width = 120;
            // 
            // Thuong
            // 
            this.Thuong.DataPropertyName = "TienThuong";
            this.Thuong.HeaderText = "Tiền thưởng";
            this.Thuong.Name = "Thuong";
            this.Thuong.Width = 120;
            // 
            // Phat
            // 
            this.Phat.DataPropertyName = "TienPhat";
            this.Phat.HeaderText = "Tiền phạt";
            this.Phat.Name = "Phat";
            this.Phat.Width = 120;
            // 
            // TongLuong
            // 
            this.TongLuong.DataPropertyName = "TongLuong";
            this.TongLuong.HeaderText = "Tổng lương";
            this.TongLuong.Name = "TongLuong";
            this.TongLuong.Width = 150;
            // 
            // NgayTinhLuong
            // 
            this.NgayTinhLuong.DataPropertyName = "NgayTinhLuong";
            this.NgayTinhLuong.HeaderText = "Ngày tính lương";
            this.NgayTinhLuong.Name = "NgayTinhLuong";
            this.NgayTinhLuong.Width = 140;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Excel 2007|.xlsx|Excel 2010|*.xlsx";
            // 
            // frmTinhLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1402, 753);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmTinhLuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tính lương nhân viên";
            this.Load += new System.EventHandler(this.frmTinhLuong_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_LuongNhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTinhLuong;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dataGV_LuongNhanVien;
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
        private System.Windows.Forms.Label lblNgayDau;
        private System.Windows.Forms.DateTimePicker txtTuNgay;
        private System.Windows.Forms.Label lblNgayCuoi;
        private System.Windows.Forms.DateTimePicker txtDenNgay;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnSuaThongTin;
        private System.Windows.Forms.Label lblNgayTinhLuong;
        private System.Windows.Forms.DateTimePicker txtNgayTinhLuong;
        private System.Windows.Forms.Button btnXoaThongTin;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn LuongCoBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoNgayLam;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhuCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phat;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayTinhLuong;
    }
}