namespace _141_KinhDoanhNongSanVaThucPham
{
    partial class frmChamCong
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
            this.lblChamCong = new System.Windows.Forms.Label();
            this.dataGV_ChamCong = new System.Windows.Forms.DataGridView();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayLam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TinhTrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.cbbTinhTrang = new System.Windows.Forms.ComboBox();
            this.btnThemNgayCong = new System.Windows.Forms.Button();
            this.lblTinhTrang = new System.Windows.Forms.Label();
            this.txtNgayLam = new System.Windows.Forms.DateTimePicker();
            this.lblNgayLam = new System.Windows.Forms.Label();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.lblTenNV = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbbThang = new System.Windows.Forms.ComboBox();
            this.lblLocThang = new System.Windows.Forms.Label();
            this.btnInExel = new System.Windows.Forms.Button();
            this.btnXoaToanBo = new System.Windows.Forms.Button();
            this.cbbNhanVien = new System.Windows.Forms.ComboBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.txtChonNgay = new System.Windows.Forms.DateTimePicker();
            this.lblLocNgay = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_ChamCong)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblChamCong, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGV_ChamCong, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1134, 579);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblChamCong
            // 
            this.lblChamCong.AutoSize = true;
            this.lblChamCong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChamCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChamCong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblChamCong.Location = new System.Drawing.Point(3, 0);
            this.lblChamCong.Name = "lblChamCong";
            this.lblChamCong.Size = new System.Drawing.Size(1128, 57);
            this.lblChamCong.TabIndex = 0;
            this.lblChamCong.Text = "CHẤM CÔNG NHÂN VIÊN";
            this.lblChamCong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGV_ChamCong
            // 
            this.dataGV_ChamCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV_ChamCong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNV,
            this.TenNV,
            this.NgayLam,
            this.TinhTrang});
            this.dataGV_ChamCong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGV_ChamCong.Location = new System.Drawing.Point(3, 175);
            this.dataGV_ChamCong.Name = "dataGV_ChamCong";
            this.dataGV_ChamCong.RowTemplate.Height = 24;
            this.dataGV_ChamCong.Size = new System.Drawing.Size(1128, 283);
            this.dataGV_ChamCong.TabIndex = 1;
            // 
            // MaNV
            // 
            this.MaNV.HeaderText = "Mã nhân viên";
            this.MaNV.Name = "MaNV";
            this.MaNV.Width = 120;
            // 
            // TenNV
            // 
            this.TenNV.HeaderText = "Tên nhân viên";
            this.TenNV.Name = "TenNV";
            this.TenNV.Width = 200;
            // 
            // NgayLam
            // 
            this.NgayLam.HeaderText = "Ngày làm";
            this.NgayLam.Name = "NgayLam";
            this.NgayLam.Width = 120;
            // 
            // TinhTrang
            // 
            this.TinhTrang.HeaderText = "Tình trạng";
            this.TinhTrang.Name = "TinhTrang";
            this.TinhTrang.Width = 150;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCapNhat);
            this.panel1.Controls.Add(this.cbbTinhTrang);
            this.panel1.Controls.Add(this.btnThemNgayCong);
            this.panel1.Controls.Add(this.lblTinhTrang);
            this.panel1.Controls.Add(this.txtNgayLam);
            this.panel1.Controls.Add(this.lblNgayLam);
            this.panel1.Controls.Add(this.txtTenNV);
            this.panel1.Controls.Add(this.lblTenNV);
            this.panel1.Controls.Add(this.txtMaNV);
            this.panel1.Controls.Add(this.lblMaNV);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1128, 109);
            this.panel1.TabIndex = 2;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(885, 24);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(200, 30);
            this.btnCapNhat.TabIndex = 8;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            // 
            // cbbTinhTrang
            // 
            this.cbbTinhTrang.FormattingEnabled = true;
            this.cbbTinhTrang.Location = new System.Drawing.Point(675, 49);
            this.cbbTinhTrang.Name = "cbbTinhTrang";
            this.cbbTinhTrang.Size = new System.Drawing.Size(150, 24);
            this.cbbTinhTrang.TabIndex = 7;
            // 
            // btnThemNgayCong
            // 
            this.btnThemNgayCong.Location = new System.Drawing.Point(885, 60);
            this.btnThemNgayCong.Name = "btnThemNgayCong";
            this.btnThemNgayCong.Size = new System.Drawing.Size(200, 30);
            this.btnThemNgayCong.TabIndex = 4;
            this.btnThemNgayCong.Text = "Thêm ngày công";
            this.btnThemNgayCong.UseVisualStyleBackColor = true;
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.AutoSize = true;
            this.lblTinhTrang.Location = new System.Drawing.Point(672, 31);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(73, 17);
            this.lblTinhTrang.TabIndex = 6;
            this.lblTinhTrang.Text = "Tình trạng";
            // 
            // txtNgayLam
            // 
            this.txtNgayLam.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtNgayLam.Location = new System.Drawing.Point(465, 49);
            this.txtNgayLam.Name = "txtNgayLam";
            this.txtNgayLam.Size = new System.Drawing.Size(150, 22);
            this.txtNgayLam.TabIndex = 5;
            // 
            // lblNgayLam
            // 
            this.lblNgayLam.AutoSize = true;
            this.lblNgayLam.Location = new System.Drawing.Point(462, 31);
            this.lblNgayLam.Name = "lblNgayLam";
            this.lblNgayLam.Size = new System.Drawing.Size(67, 17);
            this.lblNgayLam.TabIndex = 4;
            this.lblNgayLam.Text = "Ngày làm";
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(203, 51);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(200, 22);
            this.txtTenNV.TabIndex = 3;
            // 
            // lblTenNV
            // 
            this.lblTenNV.AutoSize = true;
            this.lblTenNV.Location = new System.Drawing.Point(200, 31);
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Size = new System.Drawing.Size(99, 17);
            this.lblTenNV.TabIndex = 2;
            this.lblTenNV.Text = "Tên nhân viên";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(41, 51);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(100, 22);
            this.txtMaNV.TabIndex = 1;
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Location = new System.Drawing.Point(38, 31);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(93, 17);
            this.lblMaNV.TabIndex = 0;
            this.lblMaNV.Text = "Mã nhân viên";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbbThang);
            this.panel2.Controls.Add(this.lblLocThang);
            this.panel2.Controls.Add(this.btnInExel);
            this.panel2.Controls.Add(this.btnXoaToanBo);
            this.panel2.Controls.Add(this.cbbNhanVien);
            this.panel2.Controls.Add(this.lblNhanVien);
            this.panel2.Controls.Add(this.txtChonNgay);
            this.panel2.Controls.Add(this.lblLocNgay);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 464);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1128, 112);
            this.panel2.TabIndex = 3;
            // 
            // cbbThang
            // 
            this.cbbThang.FormattingEnabled = true;
            this.cbbThang.Location = new System.Drawing.Point(465, 48);
            this.cbbThang.Name = "cbbThang";
            this.cbbThang.Size = new System.Drawing.Size(121, 24);
            this.cbbThang.TabIndex = 8;
            // 
            // lblLocThang
            // 
            this.lblLocThang.AutoSize = true;
            this.lblLocThang.Location = new System.Drawing.Point(462, 29);
            this.lblLocThang.Name = "lblLocThang";
            this.lblLocThang.Size = new System.Drawing.Size(103, 17);
            this.lblLocThang.TabIndex = 7;
            this.lblLocThang.Text = "Lọc theo tháng";
            // 
            // btnInExel
            // 
            this.btnInExel.Location = new System.Drawing.Point(985, 44);
            this.btnInExel.Name = "btnInExel";
            this.btnInExel.Size = new System.Drawing.Size(100, 30);
            this.btnInExel.TabIndex = 6;
            this.btnInExel.Text = "In Excel";
            this.btnInExel.UseVisualStyleBackColor = true;
            // 
            // btnXoaToanBo
            // 
            this.btnXoaToanBo.Location = new System.Drawing.Point(799, 44);
            this.btnXoaToanBo.Name = "btnXoaToanBo";
            this.btnXoaToanBo.Size = new System.Drawing.Size(150, 30);
            this.btnXoaToanBo.TabIndex = 5;
            this.btnXoaToanBo.Text = "Xóa toàn bộ";
            this.btnXoaToanBo.UseVisualStyleBackColor = true;
            // 
            // cbbNhanVien
            // 
            this.cbbNhanVien.FormattingEnabled = true;
            this.cbbNhanVien.Location = new System.Drawing.Point(228, 48);
            this.cbbNhanVien.Name = "cbbNhanVien";
            this.cbbNhanVien.Size = new System.Drawing.Size(200, 24);
            this.cbbNhanVien.TabIndex = 3;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Location = new System.Drawing.Point(225, 29);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(97, 17);
            this.lblNhanVien.TabIndex = 2;
            this.lblNhanVien.Text = "Lọc nhân viên";
            // 
            // txtChonNgay
            // 
            this.txtChonNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtChonNgay.Location = new System.Drawing.Point(41, 50);
            this.txtChonNgay.Name = "txtChonNgay";
            this.txtChonNgay.Size = new System.Drawing.Size(150, 22);
            this.txtChonNgay.TabIndex = 1;
            // 
            // lblLocNgay
            // 
            this.lblLocNgay.AutoSize = true;
            this.lblLocNgay.Location = new System.Drawing.Point(38, 29);
            this.lblLocNgay.Name = "lblLocNgay";
            this.lblLocNgay.Size = new System.Drawing.Size(66, 17);
            this.lblLocNgay.TabIndex = 0;
            this.lblLocNgay.Text = "Lọc ngày";
            // 
            // frmChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 579);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmChamCong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "From chấm công nhân viên";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_ChamCong)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblChamCong;
        private System.Windows.Forms.DataGridView dataGV_ChamCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayLam;
        private System.Windows.Forms.DataGridViewTextBoxColumn TinhTrang;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.ComboBox cbbTinhTrang;
        private System.Windows.Forms.Button btnThemNgayCong;
        private System.Windows.Forms.Label lblTinhTrang;
        private System.Windows.Forms.DateTimePicker txtNgayLam;
        private System.Windows.Forms.Label lblNgayLam;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.Label lblTenNV;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbbThang;
        private System.Windows.Forms.Label lblLocThang;
        private System.Windows.Forms.Button btnInExel;
        private System.Windows.Forms.Button btnXoaToanBo;
        private System.Windows.Forms.ComboBox cbbNhanVien;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.DateTimePicker txtChonNgay;
        private System.Windows.Forms.Label lblLocNgay;
    }
}