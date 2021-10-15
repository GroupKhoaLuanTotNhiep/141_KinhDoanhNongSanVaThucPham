namespace _141_KinhDoanhNongSanVaThucPham
{
    partial class frmDanhMucNCC
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
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaChiNhanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(947, 720);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblNhaCungCap
            // 
            this.lblNhaCungCap.AutoSize = true;
            this.lblNhaCungCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNhaCungCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhaCungCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblNhaCungCap.Location = new System.Drawing.Point(3, 0);
            this.lblNhaCungCap.Name = "lblNhaCungCap";
            this.lblNhaCungCap.Size = new System.Drawing.Size(941, 57);
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 60);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(941, 102);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // gbTKNCC
            // 
            this.gbTKNCC.Controls.Add(this.btnTKNCC);
            this.gbTKNCC.Controls.Add(this.txtTKNCC);
            this.gbTKNCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTKNCC.Location = new System.Drawing.Point(3, 3);
            this.gbTKNCC.Name = "gbTKNCC";
            this.gbTKNCC.Size = new System.Drawing.Size(370, 96);
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
            this.gbChucnang.Location = new System.Drawing.Point(379, 3);
            this.gbChucnang.Name = "gbChucnang";
            this.gbChucnang.Size = new System.Drawing.Size(559, 96);
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
            // 
            // btnXoaNCC
            // 
            this.btnXoaNCC.Location = new System.Drawing.Point(174, 33);
            this.btnXoaNCC.Name = "btnXoaNCC";
            this.btnXoaNCC.Size = new System.Drawing.Size(100, 40);
            this.btnXoaNCC.TabIndex = 1;
            this.btnXoaNCC.Text = "Xóa NCC";
            this.btnXoaNCC.UseVisualStyleBackColor = true;
            // 
            // btnInExc
            // 
            this.btnInExc.Location = new System.Drawing.Point(412, 33);
            this.btnInExc.Name = "btnInExc";
            this.btnInExc.Size = new System.Drawing.Size(90, 40);
            this.btnInExc.TabIndex = 3;
            this.btnInExc.Text = "In Excel";
            this.btnInExc.UseVisualStyleBackColor = true;
            // 
            // btnTaoNCC
            // 
            this.btnTaoNCC.Location = new System.Drawing.Point(45, 33);
            this.btnTaoNCC.Name = "btnTaoNCC";
            this.btnTaoNCC.Size = new System.Drawing.Size(110, 40);
            this.btnTaoNCC.TabIndex = 0;
            this.btnTaoNCC.Text = "Tạo NCC";
            this.btnTaoNCC.UseVisualStyleBackColor = true;
            // 
            // groupBoxNhaCungCap
            // 
            this.groupBoxNhaCungCap.Controls.Add(this.dataGV_NhaCungCap);
            this.groupBoxNhaCungCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxNhaCungCap.Location = new System.Drawing.Point(3, 168);
            this.groupBoxNhaCungCap.Name = "groupBoxNhaCungCap";
            this.groupBoxNhaCungCap.Size = new System.Drawing.Size(941, 296);
            this.groupBoxNhaCungCap.TabIndex = 2;
            this.groupBoxNhaCungCap.TabStop = false;
            this.groupBoxNhaCungCap.Text = "Danh mục nhà cung cấp";
            // 
            // dataGV_NhaCungCap
            // 
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
            this.dataGV_NhaCungCap.RowTemplate.Height = 24;
            this.dataGV_NhaCungCap.Size = new System.Drawing.Size(935, 275);
            this.dataGV_NhaCungCap.TabIndex = 3;
            // 
            // Mancc
            // 
            this.Mancc.HeaderText = "Mã NCC";
            this.Mancc.Name = "Mancc";
            // 
            // Tenncc
            // 
            this.Tenncc.HeaderText = "Tên NCC";
            this.Tenncc.Name = "Tenncc";
            this.Tenncc.Width = 150;
            // 
            // DiaChi
            // 
            this.DiaChi.HeaderText = "Địa chỉ ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 200;
            // 
            // DienThoai
            // 
            this.DienThoai.HeaderText = "Điện thoại";
            this.DienThoai.Name = "DienThoai";
            // 
            // email
            // 
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.Width = 120;
            // 
            // CongNo
            // 
            this.CongNo.HeaderText = "Công nợ";
            this.CongNo.Name = "CongNo";
            // 
            // SoTaiKhoan
            // 
            this.SoTaiKhoan.HeaderText = "Số tài khoản";
            this.SoTaiKhoan.Name = "SoTaiKhoan";
            this.SoTaiKhoan.Width = 120;
            // 
            // groupBoxCacPhieuNhap
            // 
            this.groupBoxCacPhieuNhap.Controls.Add(this.dataGV_PhieuNhap);
            this.groupBoxCacPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCacPhieuNhap.Location = new System.Drawing.Point(3, 470);
            this.groupBoxCacPhieuNhap.Name = "groupBoxCacPhieuNhap";
            this.groupBoxCacPhieuNhap.Size = new System.Drawing.Size(941, 247);
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
            this.dataGridViewTextBoxColumn1,
            this.MaChiNhanh});
            this.dataGV_PhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGV_PhieuNhap.Location = new System.Drawing.Point(3, 18);
            this.dataGV_PhieuNhap.Name = "dataGV_PhieuNhap";
            this.dataGV_PhieuNhap.RowTemplate.Height = 24;
            this.dataGV_PhieuNhap.Size = new System.Drawing.Size(935, 226);
            this.dataGV_PhieuNhap.TabIndex = 2;
            // 
            // MaPNH
            // 
            this.MaPNH.HeaderText = "Mã phiếu nhập";
            this.MaPNH.Name = "MaPNH";
            this.MaPNH.Width = 120;
            // 
            // NgayNhap
            // 
            this.NgayNhap.HeaderText = "Ngày nhập";
            this.NgayNhap.Name = "NgayNhap";
            this.NgayNhap.Width = 120;
            // 
            // TongTienNhap
            // 
            this.TongTienNhap.HeaderText = "Tổng tiền nhập";
            this.TongTienNhap.Name = "TongTienNhap";
            this.TongTienNhap.Width = 150;
            // 
            // ThanhToan
            // 
            this.ThanhToan.HeaderText = "Thanh toán";
            this.ThanhToan.Name = "ThanhToan";
            this.ThanhToan.Width = 150;
            // 
            // ConNo
            // 
            this.ConNo.HeaderText = "Còn nợ";
            this.ConNo.Name = "ConNo";
            this.ConNo.Width = 150;
            // 
            // MaNV
            // 
            this.MaNV.HeaderText = "Mã nhân viên";
            this.MaNV.Name = "MaNV";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã nhà cung cấp";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // MaChiNhanh
            // 
            this.MaChiNhanh.HeaderText = "Mã chi nhánh";
            this.MaChiNhanh.Name = "MaChiNhanh";
            // 
            // frmDanhMucNCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 720);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmDanhMucNCC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục nhà cung cấp";
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
        private System.Windows.Forms.Button btnInExc;
        private System.Windows.Forms.Button btnTaoNCC;
        private System.Windows.Forms.Button btnSuaNCC;
        private System.Windows.Forms.Button btnXoaNCC;
        private System.Windows.Forms.GroupBox groupBoxNhaCungCap;
        private System.Windows.Forms.DataGridView dataGV_NhaCungCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mancc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tenncc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn DienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn CongNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTaiKhoan;
        private System.Windows.Forms.GroupBox groupBoxCacPhieuNhap;
        private System.Windows.Forms.DataGridView dataGV_PhieuNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPNH;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTienNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChiNhanh;
    }
}