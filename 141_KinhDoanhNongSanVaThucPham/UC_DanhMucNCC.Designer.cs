namespace _141_KinhDoanhNongSanVaThucPham
{
    partial class UC_DanhMucNCC
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
            this.lblNhaCungCap = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.gbTKNCC = new System.Windows.Forms.GroupBox();
            this.btnTKNCC = new System.Windows.Forms.Button();
            this.txtTKNCC = new System.Windows.Forms.TextBox();
            this.gbChucnang = new System.Windows.Forms.GroupBox();
            this.btnSuaNCC = new System.Windows.Forms.Button();
            this.btnXoaNCC = new System.Windows.Forms.Button();
            this.btnInExc = new System.Windows.Forms.Button();
            this.btnTaoNCC = new System.Windows.Forms.Button();
            this.groupBoxNhaCungCap = new System.Windows.Forms.GroupBox();
            this.dataGV_NhaCungCap = new System.Windows.Forms.DataGridView();
            this.Mancc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tenncc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CongNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTaiKhoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxCacPhieuNhap = new System.Windows.Forms.GroupBox();
            this.dataGV_PhieuNhap = new System.Windows.Forms.DataGridView();
            this.MaPNH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTienNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mncc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaChiNhanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gbTKNCC.SuspendLayout();
            this.gbChucnang.SuspendLayout();
            this.groupBoxNhaCungCap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_NhaCungCap)).BeginInit();
            this.groupBoxCacPhieuNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_PhieuNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblNhaCungCap, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxNhaCungCap, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxCacPhieuNhap, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(960, 760);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lblNhaCungCap
            // 
            this.lblNhaCungCap.AutoSize = true;
            this.lblNhaCungCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNhaCungCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhaCungCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblNhaCungCap.Location = new System.Drawing.Point(3, 0);
            this.lblNhaCungCap.Name = "lblNhaCungCap";
            this.lblNhaCungCap.Size = new System.Drawing.Size(954, 60);
            this.lblNhaCungCap.TabIndex = 0;
            this.lblNhaCungCap.Text = "DANH MỤC NHÀ CUNG CẤP";
            this.lblNhaCungCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.Controls.Add(this.gbTKNCC, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.gbChucnang, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 63);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(954, 108);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // gbTKNCC
            // 
            this.gbTKNCC.Controls.Add(this.btnTKNCC);
            this.gbTKNCC.Controls.Add(this.txtTKNCC);
            this.gbTKNCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTKNCC.Location = new System.Drawing.Point(3, 3);
            this.gbTKNCC.Name = "gbTKNCC";
            this.gbTKNCC.Size = new System.Drawing.Size(375, 102);
            this.gbTKNCC.TabIndex = 0;
            this.gbTKNCC.TabStop = false;
            this.gbTKNCC.Text = "Tìm kiếm nhà cung cấp";
            // 
            // btnTKNCC
            // 
            this.btnTKNCC.Location = new System.Drawing.Point(242, 36);
            this.btnTKNCC.Name = "btnTKNCC";
            this.btnTKNCC.Size = new System.Drawing.Size(90, 34);
            this.btnTKNCC.TabIndex = 1;
            this.btnTKNCC.Text = "Tìm kiếm";
            this.btnTKNCC.UseVisualStyleBackColor = true;
            this.btnTKNCC.Click += new System.EventHandler(this.btnTKNCC_Click);
            // 
            // txtTKNCC
            // 
            this.txtTKNCC.Location = new System.Drawing.Point(36, 42);
            this.txtTKNCC.Name = "txtTKNCC";
            this.txtTKNCC.Size = new System.Drawing.Size(200, 22);
            this.txtTKNCC.TabIndex = 0;
            // 
            // gbChucnang
            // 
            this.gbChucnang.Controls.Add(this.btnSuaNCC);
            this.gbChucnang.Controls.Add(this.btnXoaNCC);
            this.gbChucnang.Controls.Add(this.btnInExc);
            this.gbChucnang.Controls.Add(this.btnTaoNCC);
            this.gbChucnang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbChucnang.Location = new System.Drawing.Point(384, 3);
            this.gbChucnang.Name = "gbChucnang";
            this.gbChucnang.Size = new System.Drawing.Size(567, 102);
            this.gbChucnang.TabIndex = 1;
            this.gbChucnang.TabStop = false;
            this.gbChucnang.Text = "Chức năng";
            // 
            // btnSuaNCC
            // 
            this.btnSuaNCC.Location = new System.Drawing.Point(293, 33);
            this.btnSuaNCC.Name = "btnSuaNCC";
            this.btnSuaNCC.Size = new System.Drawing.Size(100, 40);
            this.btnSuaNCC.TabIndex = 2;
            this.btnSuaNCC.Text = "Sửa NCC";
            this.btnSuaNCC.UseVisualStyleBackColor = true;
            this.btnSuaNCC.Click += new System.EventHandler(this.btnSuaNCC_Click);
            // 
            // btnXoaNCC
            // 
            this.btnXoaNCC.Location = new System.Drawing.Point(174, 33);
            this.btnXoaNCC.Name = "btnXoaNCC";
            this.btnXoaNCC.Size = new System.Drawing.Size(100, 40);
            this.btnXoaNCC.TabIndex = 1;
            this.btnXoaNCC.Text = "Xóa NCC";
            this.btnXoaNCC.UseVisualStyleBackColor = true;
            this.btnXoaNCC.Click += new System.EventHandler(this.btnXoaNCC_Click);
            // 
            // btnInExc
            // 
            this.btnInExc.Location = new System.Drawing.Point(412, 33);
            this.btnInExc.Name = "btnInExc";
            this.btnInExc.Size = new System.Drawing.Size(90, 40);
            this.btnInExc.TabIndex = 3;
            this.btnInExc.Text = "In Excel";
            this.btnInExc.UseVisualStyleBackColor = true;
            this.btnInExc.Click += new System.EventHandler(this.btnInExc_Click);
            // 
            // btnTaoNCC
            // 
            this.btnTaoNCC.Location = new System.Drawing.Point(45, 33);
            this.btnTaoNCC.Name = "btnTaoNCC";
            this.btnTaoNCC.Size = new System.Drawing.Size(110, 40);
            this.btnTaoNCC.TabIndex = 0;
            this.btnTaoNCC.Text = "Tạo NCC";
            this.btnTaoNCC.UseVisualStyleBackColor = true;
            this.btnTaoNCC.Click += new System.EventHandler(this.btnTaoNCC_Click);
            // 
            // groupBoxNhaCungCap
            // 
            this.groupBoxNhaCungCap.Controls.Add(this.dataGV_NhaCungCap);
            this.groupBoxNhaCungCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxNhaCungCap.Location = new System.Drawing.Point(3, 177);
            this.groupBoxNhaCungCap.Name = "groupBoxNhaCungCap";
            this.groupBoxNhaCungCap.Size = new System.Drawing.Size(954, 313);
            this.groupBoxNhaCungCap.TabIndex = 2;
            this.groupBoxNhaCungCap.TabStop = false;
            this.groupBoxNhaCungCap.Text = "Danh mục nhà cung cấp";
            // 
            // dataGV_NhaCungCap
            // 
            this.dataGV_NhaCungCap.AllowUserToAddRows = false;
            this.dataGV_NhaCungCap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGV_NhaCungCap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV_NhaCungCap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Mancc,
            this.Tenncc,
            this.DiaChi,
            this.DienThoai,
            this.email,
            this.CongNo,
            this.SoTaiKhoan});
            this.dataGV_NhaCungCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGV_NhaCungCap.Location = new System.Drawing.Point(3, 18);
            this.dataGV_NhaCungCap.Name = "dataGV_NhaCungCap";
            this.dataGV_NhaCungCap.RowHeadersWidth = 51;
            this.dataGV_NhaCungCap.RowTemplate.Height = 24;
            this.dataGV_NhaCungCap.Size = new System.Drawing.Size(948, 292);
            this.dataGV_NhaCungCap.TabIndex = 3;
            this.dataGV_NhaCungCap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGV_NhaCungCap_CellClick);
            // 
            // Mancc
            // 
            this.Mancc.DataPropertyName = "Mancc";
            this.Mancc.HeaderText = "Mã NCC";
            this.Mancc.MinimumWidth = 6;
            this.Mancc.Name = "Mancc";
            // 
            // Tenncc
            // 
            this.Tenncc.DataPropertyName = "Tenncc";
            this.Tenncc.HeaderText = "Tên NCC";
            this.Tenncc.MinimumWidth = 6;
            this.Tenncc.Name = "Tenncc";
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa chỉ ";
            this.DiaChi.MinimumWidth = 6;
            this.DiaChi.Name = "DiaChi";
            // 
            // DienThoai
            // 
            this.DienThoai.DataPropertyName = "DienThoai";
            this.DienThoai.HeaderText = "Điện thoại";
            this.DienThoai.MinimumWidth = 6;
            this.DienThoai.Name = "DienThoai";
            // 
            // email
            // 
            this.email.DataPropertyName = "email";
            this.email.HeaderText = "Email";
            this.email.MinimumWidth = 6;
            this.email.Name = "email";
            // 
            // CongNo
            // 
            this.CongNo.DataPropertyName = "CongNo";
            this.CongNo.HeaderText = "Công nợ";
            this.CongNo.MinimumWidth = 6;
            this.CongNo.Name = "CongNo";
            // 
            // SoTaiKhoan
            // 
            this.SoTaiKhoan.DataPropertyName = "SoTaiKhoan";
            this.SoTaiKhoan.HeaderText = "Số tài khoản";
            this.SoTaiKhoan.MinimumWidth = 6;
            this.SoTaiKhoan.Name = "SoTaiKhoan";
            // 
            // groupBoxCacPhieuNhap
            // 
            this.groupBoxCacPhieuNhap.Controls.Add(this.dataGV_PhieuNhap);
            this.groupBoxCacPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCacPhieuNhap.Location = new System.Drawing.Point(3, 496);
            this.groupBoxCacPhieuNhap.Name = "groupBoxCacPhieuNhap";
            this.groupBoxCacPhieuNhap.Size = new System.Drawing.Size(954, 261);
            this.groupBoxCacPhieuNhap.TabIndex = 3;
            this.groupBoxCacPhieuNhap.TabStop = false;
            this.groupBoxCacPhieuNhap.Text = "Các phiếu nhập";
            // 
            // dataGV_PhieuNhap
            // 
            this.dataGV_PhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV_PhieuNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPNH,
            this.NgayNhap,
            this.TongTienNhap,
            this.ThanhToan,
            this.ConNo,
            this.MaNV,
            this.mncc,
            this.MaChiNhanh});
            this.dataGV_PhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGV_PhieuNhap.Location = new System.Drawing.Point(3, 18);
            this.dataGV_PhieuNhap.Name = "dataGV_PhieuNhap";
            this.dataGV_PhieuNhap.RowHeadersWidth = 51;
            this.dataGV_PhieuNhap.RowTemplate.Height = 24;
            this.dataGV_PhieuNhap.Size = new System.Drawing.Size(948, 240);
            this.dataGV_PhieuNhap.TabIndex = 2;
            // 
            // MaPNH
            // 
            this.MaPNH.DataPropertyName = "MaPNH";
            this.MaPNH.HeaderText = "Mã phiếu nhập";
            this.MaPNH.MinimumWidth = 6;
            this.MaPNH.Name = "MaPNH";
            this.MaPNH.Width = 120;
            // 
            // NgayNhap
            // 
            this.NgayNhap.DataPropertyName = "NgayNhap";
            this.NgayNhap.HeaderText = "Ngày nhập";
            this.NgayNhap.MinimumWidth = 6;
            this.NgayNhap.Name = "NgayNhap";
            this.NgayNhap.Width = 120;
            // 
            // TongTienNhap
            // 
            this.TongTienNhap.DataPropertyName = "TongTienNhap";
            this.TongTienNhap.HeaderText = "Tổng tiền nhập";
            this.TongTienNhap.MinimumWidth = 6;
            this.TongTienNhap.Name = "TongTienNhap";
            this.TongTienNhap.Width = 150;
            // 
            // ThanhToan
            // 
            this.ThanhToan.DataPropertyName = "ThanhToan";
            this.ThanhToan.HeaderText = "Thanh toán";
            this.ThanhToan.MinimumWidth = 6;
            this.ThanhToan.Name = "ThanhToan";
            this.ThanhToan.Width = 150;
            // 
            // ConNo
            // 
            this.ConNo.DataPropertyName = "ConNo";
            this.ConNo.HeaderText = "Còn nợ";
            this.ConNo.MinimumWidth = 6;
            this.ConNo.Name = "ConNo";
            this.ConNo.Width = 150;
            // 
            // MaNV
            // 
            this.MaNV.DataPropertyName = "MaNV";
            this.MaNV.HeaderText = "Mã nhân viên";
            this.MaNV.MinimumWidth = 6;
            this.MaNV.Name = "MaNV";
            this.MaNV.Width = 125;
            // 
            // mncc
            // 
            this.mncc.DataPropertyName = "MaNCC";
            this.mncc.HeaderText = "Mã nhà cung cấp";
            this.mncc.MinimumWidth = 6;
            this.mncc.Name = "mncc";
            this.mncc.Width = 125;
            // 
            // MaChiNhanh
            // 
            this.MaChiNhanh.DataPropertyName = "MaChiNhanh";
            this.MaChiNhanh.HeaderText = "Mã chi nhánh";
            this.MaChiNhanh.MinimumWidth = 6;
            this.MaChiNhanh.Name = "MaChiNhanh";
            this.MaChiNhanh.Width = 125;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Excel 2007|.xlsx|Excel 2010|*.xlsx";
            // 
            // UC_DanhMucNCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_DanhMucNCC";
            this.Size = new System.Drawing.Size(960, 760);
            this.Load += new System.EventHandler(this.UC_DanhMucNCC_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.gbTKNCC.ResumeLayout(false);
            this.gbTKNCC.PerformLayout();
            this.gbChucnang.ResumeLayout(false);
            this.groupBoxNhaCungCap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_NhaCungCap)).EndInit();
            this.groupBoxCacPhieuNhap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_PhieuNhap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblNhaCungCap;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox gbTKNCC;
        private System.Windows.Forms.Button btnTKNCC;
        private System.Windows.Forms.TextBox txtTKNCC;
        private System.Windows.Forms.GroupBox gbChucnang;
        private System.Windows.Forms.Button btnSuaNCC;
        private System.Windows.Forms.Button btnXoaNCC;
        private System.Windows.Forms.Button btnInExc;
        private System.Windows.Forms.Button btnTaoNCC;
        private System.Windows.Forms.GroupBox groupBoxNhaCungCap;
        private System.Windows.Forms.DataGridView dataGV_NhaCungCap;
        private System.Windows.Forms.GroupBox groupBoxCacPhieuNhap;
        private System.Windows.Forms.DataGridView dataGV_PhieuNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mancc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tenncc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn DienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn CongNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTaiKhoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPNH;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTienNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn mncc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChiNhanh;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
