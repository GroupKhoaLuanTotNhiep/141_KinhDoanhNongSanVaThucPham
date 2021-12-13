namespace _141_KinhDoanhNongSanVaThucPham
{
    partial class UC_DanhMucQuyenNV
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblQuyen = new System.Windows.Forms.Label();
            this.groupBoxTTQuyen = new System.Windows.Forms.GroupBox();
            this.btnSuaQuyen = new System.Windows.Forms.Button();
            this.btnXoaQuyen = new System.Windows.Forms.Button();
            this.btnInDanhSach = new System.Windows.Forms.Button();
            this.txtTenQuyen = new System.Windows.Forms.TextBox();
            this.lblTenQuyen = new System.Windows.Forms.Label();
            this.txtMaQuyen = new System.Windows.Forms.TextBox();
            this.lblMaQuyen = new System.Windows.Forms.Label();
            this.groupBoxQuyen = new System.Windows.Forms.GroupBox();
            this.dataGV_DMQuyen = new System.Windows.Forms.DataGridView();
            this.MaQuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenQuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxNhanVien = new System.Windows.Forms.GroupBox();
            this.dataGV_DSNhanVien = new System.Windows.Forms.DataGridView();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tennv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatKhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxTTQuyen.SuspendLayout();
            this.groupBoxQuyen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_DMQuyen)).BeginInit();
            this.groupBoxNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_DSNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblQuyen, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxTTQuyen, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxQuyen, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxNhanVien, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1060, 750);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // lblQuyen
            // 
            this.lblQuyen.AutoSize = true;
            this.lblQuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuyen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblQuyen.Location = new System.Drawing.Point(3, 0);
            this.lblQuyen.Name = "lblQuyen";
            this.lblQuyen.Size = new System.Drawing.Size(1054, 75);
            this.lblQuyen.TabIndex = 0;
            this.lblQuyen.Text = "DANH MỤC QUYỀN";
            this.lblQuyen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxTTQuyen
            // 
            this.groupBoxTTQuyen.Controls.Add(this.btnSuaQuyen);
            this.groupBoxTTQuyen.Controls.Add(this.btnXoaQuyen);
            this.groupBoxTTQuyen.Controls.Add(this.btnInDanhSach);
            this.groupBoxTTQuyen.Controls.Add(this.txtTenQuyen);
            this.groupBoxTTQuyen.Controls.Add(this.lblTenQuyen);
            this.groupBoxTTQuyen.Controls.Add(this.txtMaQuyen);
            this.groupBoxTTQuyen.Controls.Add(this.lblMaQuyen);
            this.groupBoxTTQuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTTQuyen.Location = new System.Drawing.Point(3, 78);
            this.groupBoxTTQuyen.Name = "groupBoxTTQuyen";
            this.groupBoxTTQuyen.Size = new System.Drawing.Size(1054, 144);
            this.groupBoxTTQuyen.TabIndex = 1;
            this.groupBoxTTQuyen.TabStop = false;
            this.groupBoxTTQuyen.Text = "Thông tin quyền";
            // 
            // btnSuaQuyen
            // 
            this.btnSuaQuyen.Location = new System.Drawing.Point(618, 53);
            this.btnSuaQuyen.Name = "btnSuaQuyen";
            this.btnSuaQuyen.Size = new System.Drawing.Size(110, 40);
            this.btnSuaQuyen.TabIndex = 10;
            this.btnSuaQuyen.Text = "Sửa quyền";
            this.btnSuaQuyen.UseVisualStyleBackColor = true;
            this.btnSuaQuyen.Click += new System.EventHandler(this.btnSuaQuyen_Click);
            // 
            // btnXoaQuyen
            // 
            this.btnXoaQuyen.Location = new System.Drawing.Point(754, 53);
            this.btnXoaQuyen.Name = "btnXoaQuyen";
            this.btnXoaQuyen.Size = new System.Drawing.Size(110, 40);
            this.btnXoaQuyen.TabIndex = 9;
            this.btnXoaQuyen.Text = "Xóa quyền";
            this.btnXoaQuyen.UseVisualStyleBackColor = true;
            this.btnXoaQuyen.Click += new System.EventHandler(this.btnXoaQuyen_Click);
            // 
            // btnInDanhSach
            // 
            this.btnInDanhSach.Location = new System.Drawing.Point(889, 53);
            this.btnInDanhSach.Name = "btnInDanhSach";
            this.btnInDanhSach.Size = new System.Drawing.Size(110, 40);
            this.btnInDanhSach.TabIndex = 11;
            this.btnInDanhSach.Text = "In danh sách";
            this.btnInDanhSach.UseVisualStyleBackColor = true;
            // 
            // txtTenQuyen
            // 
            this.txtTenQuyen.Location = new System.Drawing.Point(299, 62);
            this.txtTenQuyen.Name = "txtTenQuyen";
            this.txtTenQuyen.Size = new System.Drawing.Size(200, 22);
            this.txtTenQuyen.TabIndex = 3;
            // 
            // lblTenQuyen
            // 
            this.lblTenQuyen.AutoSize = true;
            this.lblTenQuyen.Location = new System.Drawing.Point(296, 42);
            this.lblTenQuyen.Name = "lblTenQuyen";
            this.lblTenQuyen.Size = new System.Drawing.Size(76, 17);
            this.lblTenQuyen.TabIndex = 2;
            this.lblTenQuyen.Text = "Tên quyền";
            // 
            // txtMaQuyen
            // 
            this.txtMaQuyen.Location = new System.Drawing.Point(114, 62);
            this.txtMaQuyen.Name = "txtMaQuyen";
            this.txtMaQuyen.Size = new System.Drawing.Size(100, 22);
            this.txtMaQuyen.TabIndex = 1;
            // 
            // lblMaQuyen
            // 
            this.lblMaQuyen.AutoSize = true;
            this.lblMaQuyen.Location = new System.Drawing.Point(111, 42);
            this.lblMaQuyen.Name = "lblMaQuyen";
            this.lblMaQuyen.Size = new System.Drawing.Size(70, 17);
            this.lblMaQuyen.TabIndex = 0;
            this.lblMaQuyen.Text = "Mã quyền";
            // 
            // groupBoxQuyen
            // 
            this.groupBoxQuyen.Controls.Add(this.dataGV_DMQuyen);
            this.groupBoxQuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxQuyen.Location = new System.Drawing.Point(3, 228);
            this.groupBoxQuyen.Name = "groupBoxQuyen";
            this.groupBoxQuyen.Size = new System.Drawing.Size(1054, 256);
            this.groupBoxQuyen.TabIndex = 2;
            this.groupBoxQuyen.TabStop = false;
            this.groupBoxQuyen.Text = "Các quyền";
            // 
            // dataGV_DMQuyen
            // 
            this.dataGV_DMQuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV_DMQuyen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaQuyen,
            this.TenQuyen});
            this.dataGV_DMQuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGV_DMQuyen.Location = new System.Drawing.Point(3, 18);
            this.dataGV_DMQuyen.Name = "dataGV_DMQuyen";
            this.dataGV_DMQuyen.RowTemplate.Height = 24;
            this.dataGV_DMQuyen.Size = new System.Drawing.Size(1048, 235);
            this.dataGV_DMQuyen.TabIndex = 3;
            this.dataGV_DMQuyen.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGV_DMQuyen_CellClick);
            // 
            // MaQuyen
            // 
            this.MaQuyen.DataPropertyName = "MaQuyen";
            this.MaQuyen.HeaderText = "Mã quyền";
            this.MaQuyen.Name = "MaQuyen";
            this.MaQuyen.Width = 150;
            // 
            // TenQuyen
            // 
            this.TenQuyen.DataPropertyName = "TenQuyen";
            this.TenQuyen.HeaderText = "Tên quyền";
            this.TenQuyen.Name = "TenQuyen";
            this.TenQuyen.Width = 200;
            // 
            // groupBoxNhanVien
            // 
            this.groupBoxNhanVien.Controls.Add(this.dataGV_DSNhanVien);
            this.groupBoxNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxNhanVien.Location = new System.Drawing.Point(3, 490);
            this.groupBoxNhanVien.Name = "groupBoxNhanVien";
            this.groupBoxNhanVien.Size = new System.Drawing.Size(1054, 257);
            this.groupBoxNhanVien.TabIndex = 3;
            this.groupBoxNhanVien.TabStop = false;
            this.groupBoxNhanVien.Text = "Danh sách nhân viên";
            // 
            // dataGV_DSNhanVien
            // 
            this.dataGV_DSNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV_DSNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNV,
            this.tennv,
            this.GioiTinh,
            this.NgaySinh,
            this.DiaChi,
            this.DienThoai,
            this.email,
            this.Quyen,
            this.TenDN,
            this.MatKhau});
            this.dataGV_DSNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGV_DSNhanVien.Location = new System.Drawing.Point(3, 18);
            this.dataGV_DSNhanVien.Name = "dataGV_DSNhanVien";
            this.dataGV_DSNhanVien.RowTemplate.Height = 24;
            this.dataGV_DSNhanVien.Size = new System.Drawing.Size(1048, 236);
            this.dataGV_DSNhanVien.TabIndex = 3;
            // 
            // MaNV
            // 
            this.MaNV.DataPropertyName = "MaNV";
            this.MaNV.HeaderText = "Mã nhân viên";
            this.MaNV.Name = "MaNV";
            this.MaNV.Width = 120;
            // 
            // tennv
            // 
            this.tennv.DataPropertyName = "TenNV";
            this.tennv.HeaderText = "Tên nhân viên";
            this.tennv.Name = "tennv";
            this.tennv.Width = 200;
            // 
            // GioiTinh
            // 
            this.GioiTinh.DataPropertyName = "GioiTinh";
            this.GioiTinh.HeaderText = "Giới tính";
            this.GioiTinh.Name = "GioiTinh";
            // 
            // NgaySinh
            // 
            this.NgaySinh.DataPropertyName = "NgaySinh";
            this.NgaySinh.HeaderText = "Ngày sinh";
            this.NgaySinh.Name = "NgaySinh";
            this.NgaySinh.Width = 120;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 200;
            // 
            // DienThoai
            // 
            this.DienThoai.DataPropertyName = "DienThoai";
            this.DienThoai.HeaderText = "Điện thoại";
            this.DienThoai.Name = "DienThoai";
            this.DienThoai.Width = 120;
            // 
            // email
            // 
            this.email.DataPropertyName = "Email";
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.Width = 150;
            // 
            // Quyen
            // 
            this.Quyen.DataPropertyName = "MaQuyen";
            this.Quyen.HeaderText = "Quyền";
            this.Quyen.Name = "Quyen";
            // 
            // TenDN
            // 
            this.TenDN.DataPropertyName = "TenDN";
            this.TenDN.HeaderText = "Tên đăng nhập";
            this.TenDN.Name = "TenDN";
            this.TenDN.Width = 120;
            // 
            // MatKhau
            // 
            this.MatKhau.DataPropertyName = "MatKhau";
            this.MatKhau.HeaderText = "Mật khẩu";
            this.MatKhau.Name = "MatKhau";
            this.MatKhau.Width = 120;
            // 
            // UC_DanhMucQuyenNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_DanhMucQuyenNV";
            this.Size = new System.Drawing.Size(1060, 750);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBoxTTQuyen.ResumeLayout(false);
            this.groupBoxTTQuyen.PerformLayout();
            this.groupBoxQuyen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_DMQuyen)).EndInit();
            this.groupBoxNhanVien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_DSNhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblQuyen;
        private System.Windows.Forms.GroupBox groupBoxTTQuyen;
        private System.Windows.Forms.Button btnSuaQuyen;
        private System.Windows.Forms.Button btnXoaQuyen;
        private System.Windows.Forms.Button btnInDanhSach;
        private System.Windows.Forms.TextBox txtTenQuyen;
        private System.Windows.Forms.Label lblTenQuyen;
        private System.Windows.Forms.TextBox txtMaQuyen;
        private System.Windows.Forms.Label lblMaQuyen;
        private System.Windows.Forms.GroupBox groupBoxQuyen;
        private System.Windows.Forms.DataGridView dataGV_DMQuyen;
        private System.Windows.Forms.GroupBox groupBoxNhanVien;
        private System.Windows.Forms.DataGridView dataGV_DSNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaQuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenQuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn tennv;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn DienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatKhau;
    }
}
