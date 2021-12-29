namespace _141_KinhDoanhNongSanVaThucPham
{
    partial class frmXemChiTietTheoHangHoa
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxCTHoaDon = new System.Windows.Forms.GroupBox();
            this.dataGV_CTHoaDon = new System.Windows.Forms.DataGridView();
            this.MaHDBH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaGiam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxHDBanHang = new System.Windows.Forms.GroupBox();
            this.dataGV_HoaDon = new System.Windows.Forms.DataGridView();
            this.MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGiao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaTH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TienPhaiTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TinhTrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KhauTru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.lblMaSP = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.lblTongTienHang = new System.Windows.Forms.Label();
            this.txtTongTienHang = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxCTHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_CTHoaDon)).BeginInit();
            this.groupBoxHDBanHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_HoaDon)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.groupBoxCTHoaDon, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxHDBanHang, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1432, 753);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // groupBoxCTHoaDon
            // 
            this.groupBoxCTHoaDon.Controls.Add(this.dataGV_CTHoaDon);
            this.groupBoxCTHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCTHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCTHoaDon.Location = new System.Drawing.Point(3, 454);
            this.groupBoxCTHoaDon.Name = "groupBoxCTHoaDon";
            this.groupBoxCTHoaDon.Size = new System.Drawing.Size(1426, 296);
            this.groupBoxCTHoaDon.TabIndex = 3;
            this.groupBoxCTHoaDon.TabStop = false;
            this.groupBoxCTHoaDon.Text = "Chi tiết hóa đơn bán hàng";
            // 
            // dataGV_CTHoaDon
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGV_CTHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGV_CTHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV_CTHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHDBH,
            this.MaSanPham,
            this.TenSanPham,
            this.DVT,
            this.SoLuongSP,
            this.DonGia,
            this.GiaGiam,
            this.TongThanhTien});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGV_CTHoaDon.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGV_CTHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGV_CTHoaDon.Location = new System.Drawing.Point(3, 18);
            this.dataGV_CTHoaDon.Name = "dataGV_CTHoaDon";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGV_CTHoaDon.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGV_CTHoaDon.RowTemplate.Height = 24;
            this.dataGV_CTHoaDon.Size = new System.Drawing.Size(1420, 275);
            this.dataGV_CTHoaDon.TabIndex = 1;
            // 
            // MaHDBH
            // 
            this.MaHDBH.DataPropertyName = "MaHoaDon";
            this.MaHDBH.HeaderText = "Mã hóa đơn";
            this.MaHDBH.Name = "MaHDBH";
            this.MaHDBH.Width = 130;
            // 
            // MaSanPham
            // 
            this.MaSanPham.DataPropertyName = "MaSP";
            this.MaSanPham.HeaderText = "Mã sản phẩm";
            this.MaSanPham.Name = "MaSanPham";
            this.MaSanPham.Width = 130;
            // 
            // TenSanPham
            // 
            this.TenSanPham.DataPropertyName = "TenSP";
            this.TenSanPham.HeaderText = "Tên sản phẩm";
            this.TenSanPham.Name = "TenSanPham";
            this.TenSanPham.Width = 250;
            // 
            // DVT
            // 
            this.DVT.DataPropertyName = "TenDVT";
            this.DVT.HeaderText = "Đơn vị tính";
            this.DVT.Name = "DVT";
            this.DVT.Width = 120;
            // 
            // SoLuongSP
            // 
            this.SoLuongSP.DataPropertyName = "SoLuongBan";
            this.SoLuongSP.HeaderText = "Số lượng bán";
            this.SoLuongSP.Name = "SoLuongSP";
            this.SoLuongSP.Width = 130;
            // 
            // DonGia
            // 
            this.DonGia.DataPropertyName = "GiaBan";
            this.DonGia.HeaderText = "Giá bán";
            this.DonGia.Name = "DonGia";
            this.DonGia.Width = 120;
            // 
            // GiaGiam
            // 
            this.GiaGiam.DataPropertyName = "GiamGia";
            this.GiaGiam.HeaderText = "Giảm giá";
            this.GiaGiam.Name = "GiaGiam";
            this.GiaGiam.Width = 120;
            // 
            // TongThanhTien
            // 
            this.TongThanhTien.DataPropertyName = "ThanhTien";
            this.TongThanhTien.HeaderText = "Thành tiền";
            this.TongThanhTien.Name = "TongThanhTien";
            this.TongThanhTien.Width = 120;
            // 
            // groupBoxHDBanHang
            // 
            this.groupBoxHDBanHang.Controls.Add(this.dataGV_HoaDon);
            this.groupBoxHDBanHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxHDBanHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxHDBanHang.Location = new System.Drawing.Point(3, 153);
            this.groupBoxHDBanHang.Name = "groupBoxHDBanHang";
            this.groupBoxHDBanHang.Size = new System.Drawing.Size(1426, 295);
            this.groupBoxHDBanHang.TabIndex = 2;
            this.groupBoxHDBanHang.TabStop = false;
            this.groupBoxHDBanHang.Text = "Các Hóa đơn bán hàng";
            // 
            // dataGV_HoaDon
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGV_HoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGV_HoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV_HoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHD,
            this.MaNV,
            this.MaKH,
            this.NgayLap,
            this.NgayGiao,
            this.MaKM,
            this.MaTH,
            this.TongTien,
            this.TienPhaiTra,
            this.TinhTrang,
            this.GhiChu,
            this.KhauTru});
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGV_HoaDon.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGV_HoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGV_HoaDon.Location = new System.Drawing.Point(3, 18);
            this.dataGV_HoaDon.Name = "dataGV_HoaDon";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGV_HoaDon.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dataGV_HoaDon.RowTemplate.Height = 24;
            this.dataGV_HoaDon.Size = new System.Drawing.Size(1420, 274);
            this.dataGV_HoaDon.TabIndex = 0;
            this.dataGV_HoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGV_HoaDon_CellClick);
            // 
            // MaHD
            // 
            this.MaHD.DataPropertyName = "MaHoaDon";
            this.MaHD.HeaderText = "Mã hóa đơn";
            this.MaHD.Name = "MaHD";
            this.MaHD.Width = 120;
            // 
            // MaNV
            // 
            this.MaNV.DataPropertyName = "MaNV";
            this.MaNV.HeaderText = "Mã nhân viên";
            this.MaNV.Name = "MaNV";
            // 
            // MaKH
            // 
            this.MaKH.DataPropertyName = "MaKH";
            this.MaKH.HeaderText = "Mã khách hàng";
            this.MaKH.Name = "MaKH";
            // 
            // NgayLap
            // 
            this.NgayLap.DataPropertyName = "NgayLap";
            this.NgayLap.HeaderText = "Ngày lập";
            this.NgayLap.Name = "NgayLap";
            this.NgayLap.Width = 120;
            // 
            // NgayGiao
            // 
            this.NgayGiao.DataPropertyName = "NgayGiao";
            this.NgayGiao.HeaderText = "Ngày giao";
            this.NgayGiao.Name = "NgayGiao";
            this.NgayGiao.Width = 120;
            // 
            // MaKM
            // 
            this.MaKM.DataPropertyName = "MaKM";
            this.MaKM.HeaderText = "Mã khuyến mãi";
            this.MaKM.Name = "MaKM";
            // 
            // MaTH
            // 
            this.MaTH.DataPropertyName = "MaTH";
            this.MaTH.HeaderText = "Mã hình thức";
            this.MaTH.Name = "MaTH";
            // 
            // TongTien
            // 
            this.TongTien.DataPropertyName = "TongTien";
            this.TongTien.HeaderText = "Tổng tiền";
            this.TongTien.Name = "TongTien";
            this.TongTien.Width = 120;
            // 
            // TienPhaiTra
            // 
            this.TienPhaiTra.DataPropertyName = "TienPhaiTra";
            this.TienPhaiTra.HeaderText = "Tiền phải trả";
            this.TienPhaiTra.Name = "TienPhaiTra";
            this.TienPhaiTra.Width = 120;
            // 
            // TinhTrang
            // 
            this.TinhTrang.DataPropertyName = "TinhTrang";
            this.TinhTrang.HeaderText = "Tình trạng";
            this.TinhTrang.Name = "TinhTrang";
            this.TinhTrang.Width = 120;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Width = 300;
            // 
            // KhauTru
            // 
            this.KhauTru.DataPropertyName = "KhauTru";
            this.KhauTru.HeaderText = "Khấu trừ";
            this.KhauTru.Name = "KhauTru";
            this.KhauTru.Width = 120;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTenSP);
            this.panel1.Controls.Add(this.txtTenSP);
            this.panel1.Controls.Add(this.lblMaSP);
            this.panel1.Controls.Add(this.txtMaSP);
            this.panel1.Controls.Add(this.lblTongTienHang);
            this.panel1.Controls.Add(this.txtTongTienHang);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1426, 144);
            this.panel1.TabIndex = 0;
            // 
            // lblTenSP
            // 
            this.lblTenSP.AutoSize = true;
            this.lblTenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenSP.Location = new System.Drawing.Point(391, 58);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(115, 20);
            this.lblTenSP.TabIndex = 7;
            this.lblTenSP.Text = "Tên sản phẩm";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSP.Location = new System.Drawing.Point(523, 55);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(400, 27);
            this.txtTenSP.TabIndex = 6;
            // 
            // lblMaSP
            // 
            this.lblMaSP.AutoSize = true;
            this.lblMaSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaSP.Location = new System.Drawing.Point(55, 58);
            this.lblMaSP.Name = "lblMaSP";
            this.lblMaSP.Size = new System.Drawing.Size(110, 20);
            this.lblMaSP.TabIndex = 5;
            this.lblMaSP.Text = "Mã sản phẩm";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSP.Location = new System.Drawing.Point(181, 55);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(150, 27);
            this.txtMaSP.TabIndex = 4;
            // 
            // lblTongTienHang
            // 
            this.lblTongTienHang.AutoSize = true;
            this.lblTongTienHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienHang.Location = new System.Drawing.Point(996, 58);
            this.lblTongTienHang.Name = "lblTongTienHang";
            this.lblTongTienHang.Size = new System.Drawing.Size(119, 20);
            this.lblTongTienHang.TabIndex = 3;
            this.lblTongTienHang.Text = "Tổng tiền hàng";
            // 
            // txtTongTienHang
            // 
            this.txtTongTienHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTienHang.Location = new System.Drawing.Point(1140, 55);
            this.txtTongTienHang.Name = "txtTongTienHang";
            this.txtTongTienHang.Size = new System.Drawing.Size(200, 27);
            this.txtTongTienHang.TabIndex = 2;
            // 
            // frmXemChiTietTheoHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1432, 753);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmXemChiTietTheoHangHoa";
            this.Text = "Xem chi tiết hóa đơn theo hàng hóa";
            this.Load += new System.EventHandler(this.frmXemChiTietTheoHangHoa_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBoxCTHoaDon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_CTHoaDon)).EndInit();
            this.groupBoxHDBanHang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_HoaDon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBoxCTHoaDon;
        private System.Windows.Forms.DataGridView dataGV_CTHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHDBH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn DVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaGiam;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongThanhTien;
        private System.Windows.Forms.GroupBox groupBoxHDBanHang;
        private System.Windows.Forms.DataGridView dataGV_HoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGiao;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKM;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TienPhaiTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn TinhTrang;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn KhauTru;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label lblMaSP;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label lblTongTienHang;
        private System.Windows.Forms.TextBox txtTongTienHang;
    }
}