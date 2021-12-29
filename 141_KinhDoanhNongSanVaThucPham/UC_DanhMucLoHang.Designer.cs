namespace _141_KinhDoanhNongSanVaThucPham
{
    partial class UC_DanhMucLoHang
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
            this.dataGV_LoHang = new System.Windows.Forms.DataGridView();
            this.MaLo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySanXuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanSuDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPNH = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.MaSP = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.MaGia = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.lblLoHang = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.gbChucNang = new System.Windows.Forms.GroupBox();
            this.btnSuaLo = new System.Windows.Forms.Button();
            this.btnXoaLo = new System.Windows.Forms.Button();
            this.btnInExc = new System.Windows.Forms.Button();
            this.gbTKLoHang = new System.Windows.Forms.GroupBox();
            this.cbbPhieuNhap = new System.Windows.Forms.ComboBox();
            this.lblPhieuNhap = new System.Windows.Forms.Label();
            this.btnTKLoHang = new System.Windows.Forms.Button();
            this.txtTKLoHang = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_LoHang)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.gbChucNang.SuspendLayout();
            this.gbTKLoHang.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGV_LoHang, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLoHang, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1220, 720);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dataGV_LoHang
            // 
            this.dataGV_LoHang.AllowUserToAddRows = false;
            this.dataGV_LoHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV_LoHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLo,
            this.TenLo,
            this.NgaySanXuat,
            this.HanSuDung,
            this.SoLuong,
            this.MaPNH,
            this.MaSP,
            this.MaGia});
            this.dataGV_LoHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGV_LoHang.Location = new System.Drawing.Point(3, 219);
            this.dataGV_LoHang.Name = "dataGV_LoHang";
            this.dataGV_LoHang.RowHeadersWidth = 51;
            this.dataGV_LoHang.RowTemplate.Height = 24;
            this.dataGV_LoHang.Size = new System.Drawing.Size(1214, 498);
            this.dataGV_LoHang.TabIndex = 3;
            this.dataGV_LoHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGV_LoHang_CellClick);
            // 
            // MaLo
            // 
            this.MaLo.DataPropertyName = "MaLo";
            this.MaLo.HeaderText = "Mã lô";
            this.MaLo.MinimumWidth = 6;
            this.MaLo.Name = "MaLo";
            this.MaLo.Width = 125;
            // 
            // TenLo
            // 
            this.TenLo.DataPropertyName = "TenLo";
            this.TenLo.HeaderText = "Tên lô";
            this.TenLo.MinimumWidth = 6;
            this.TenLo.Name = "TenLo";
            this.TenLo.Width = 120;
            // 
            // NgaySanXuat
            // 
            this.NgaySanXuat.DataPropertyName = "NgaySanXuat";
            this.NgaySanXuat.HeaderText = "Ngày sản xuất";
            this.NgaySanXuat.MinimumWidth = 6;
            this.NgaySanXuat.Name = "NgaySanXuat";
            this.NgaySanXuat.Width = 130;
            // 
            // HanSuDung
            // 
            this.HanSuDung.DataPropertyName = "HanSuDung";
            this.HanSuDung.HeaderText = "Hạn sử dụng";
            this.HanSuDung.MinimumWidth = 6;
            this.HanSuDung.Name = "HanSuDung";
            this.HanSuDung.Width = 120;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.MinimumWidth = 6;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Width = 125;
            // 
            // MaPNH
            // 
            this.MaPNH.DataPropertyName = "MaPNH";
            this.MaPNH.HeaderText = "Phiếu nhập";
            this.MaPNH.MinimumWidth = 6;
            this.MaPNH.Name = "MaPNH";
            this.MaPNH.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MaPNH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MaPNH.Width = 120;
            // 
            // MaSP
            // 
            this.MaSP.DataPropertyName = "MaSP";
            this.MaSP.HeaderText = "Sản phẩm";
            this.MaSP.MinimumWidth = 6;
            this.MaSP.Name = "MaSP";
            this.MaSP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MaSP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MaSP.Width = 300;
            // 
            // MaGia
            // 
            this.MaGia.DataPropertyName = "MaGia";
            this.MaGia.HeaderText = "Giá bán";
            this.MaGia.Name = "MaGia";
            this.MaGia.Width = 120;
            // 
            // lblLoHang
            // 
            this.lblLoHang.AutoSize = true;
            this.lblLoHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblLoHang.Location = new System.Drawing.Point(3, 0);
            this.lblLoHang.Name = "lblLoHang";
            this.lblLoHang.Size = new System.Drawing.Size(1214, 72);
            this.lblLoHang.TabIndex = 0;
            this.lblLoHang.Text = "DANH MỤC LÔ HÀNG";
            this.lblLoHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.Controls.Add(this.gbChucNang, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.gbTKLoHang, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 75);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1214, 138);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // gbChucNang
            // 
            this.gbChucNang.Controls.Add(this.btnSuaLo);
            this.gbChucNang.Controls.Add(this.btnXoaLo);
            this.gbChucNang.Controls.Add(this.btnInExc);
            this.gbChucNang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbChucNang.Location = new System.Drawing.Point(488, 3);
            this.gbChucNang.Name = "gbChucNang";
            this.gbChucNang.Size = new System.Drawing.Size(723, 132);
            this.gbChucNang.TabIndex = 2;
            this.gbChucNang.TabStop = false;
            this.gbChucNang.Text = "Chức năng";
            // 
            // btnSuaLo
            // 
            this.btnSuaLo.Location = new System.Drawing.Point(301, 54);
            this.btnSuaLo.Name = "btnSuaLo";
            this.btnSuaLo.Size = new System.Drawing.Size(120, 40);
            this.btnSuaLo.TabIndex = 2;
            this.btnSuaLo.Text = "Sửa lô";
            this.btnSuaLo.UseVisualStyleBackColor = true;
            this.btnSuaLo.Click += new System.EventHandler(this.btnSuaLo_Click);
            // 
            // btnXoaLo
            // 
            this.btnXoaLo.Location = new System.Drawing.Point(147, 54);
            this.btnXoaLo.Name = "btnXoaLo";
            this.btnXoaLo.Size = new System.Drawing.Size(120, 40);
            this.btnXoaLo.TabIndex = 1;
            this.btnXoaLo.Text = "Xóa lô";
            this.btnXoaLo.UseVisualStyleBackColor = true;
            this.btnXoaLo.Click += new System.EventHandler(this.btnXoaLo_Click);
            // 
            // btnInExc
            // 
            this.btnInExc.Location = new System.Drawing.Point(455, 54);
            this.btnInExc.Name = "btnInExc";
            this.btnInExc.Size = new System.Drawing.Size(100, 40);
            this.btnInExc.TabIndex = 3;
            this.btnInExc.Text = "In Excel";
            this.btnInExc.UseVisualStyleBackColor = true;
            this.btnInExc.Click += new System.EventHandler(this.btnInExc_Click);
            // 
            // gbTKLoHang
            // 
            this.gbTKLoHang.Controls.Add(this.cbbPhieuNhap);
            this.gbTKLoHang.Controls.Add(this.lblPhieuNhap);
            this.gbTKLoHang.Controls.Add(this.btnTKLoHang);
            this.gbTKLoHang.Controls.Add(this.txtTKLoHang);
            this.gbTKLoHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTKLoHang.Location = new System.Drawing.Point(3, 3);
            this.gbTKLoHang.Name = "gbTKLoHang";
            this.gbTKLoHang.Size = new System.Drawing.Size(479, 132);
            this.gbTKLoHang.TabIndex = 1;
            this.gbTKLoHang.TabStop = false;
            this.gbTKLoHang.Text = "Tìm kiếm lô hàng";
            // 
            // cbbPhieuNhap
            // 
            this.cbbPhieuNhap.FormattingEnabled = true;
            this.cbbPhieuNhap.Location = new System.Drawing.Point(143, 33);
            this.cbbPhieuNhap.Name = "cbbPhieuNhap";
            this.cbbPhieuNhap.Size = new System.Drawing.Size(200, 24);
            this.cbbPhieuNhap.TabIndex = 3;
            this.cbbPhieuNhap.SelectionChangeCommitted += new System.EventHandler(this.cbbPhieuNhap_SelectionChangeCommitted);
            // 
            // lblPhieuNhap
            // 
            this.lblPhieuNhap.AutoSize = true;
            this.lblPhieuNhap.Location = new System.Drawing.Point(58, 36);
            this.lblPhieuNhap.Name = "lblPhieuNhap";
            this.lblPhieuNhap.Size = new System.Drawing.Size(80, 17);
            this.lblPhieuNhap.TabIndex = 2;
            this.lblPhieuNhap.Text = "Phiếu nhập";
            // 
            // btnTKLoHang
            // 
            this.btnTKLoHang.Location = new System.Drawing.Point(316, 63);
            this.btnTKLoHang.Name = "btnTKLoHang";
            this.btnTKLoHang.Size = new System.Drawing.Size(100, 40);
            this.btnTKLoHang.TabIndex = 1;
            this.btnTKLoHang.Text = "Tìm kiếm";
            this.btnTKLoHang.UseVisualStyleBackColor = true;
            this.btnTKLoHang.Click += new System.EventHandler(this.btnTKLoHang_Click);
            // 
            // txtTKLoHang
            // 
            this.txtTKLoHang.Location = new System.Drawing.Point(60, 72);
            this.txtTKLoHang.Name = "txtTKLoHang";
            this.txtTKLoHang.Size = new System.Drawing.Size(250, 22);
            this.txtTKLoHang.TabIndex = 0;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Excel 2007|.xlsx|Excel 2010|*.xlsx";
            // 
            // UC_DanhMucLoHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_DanhMucLoHang";
            this.Size = new System.Drawing.Size(1220, 720);
            this.Load += new System.EventHandler(this.UC_DanhMucLoHang_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_LoHang)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.gbChucNang.ResumeLayout(false);
            this.gbTKLoHang.ResumeLayout(false);
            this.gbTKLoHang.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGV_LoHang;
        private System.Windows.Forms.Label lblLoHang;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox gbChucNang;
        private System.Windows.Forms.Button btnSuaLo;
        private System.Windows.Forms.Button btnXoaLo;
        private System.Windows.Forms.Button btnInExc;
        private System.Windows.Forms.GroupBox gbTKLoHang;
        private System.Windows.Forms.ComboBox cbbPhieuNhap;
        private System.Windows.Forms.Label lblPhieuNhap;
        private System.Windows.Forms.Button btnTKLoHang;
        private System.Windows.Forms.TextBox txtTKLoHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySanXuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanSuDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewComboBoxColumn MaPNH;
        private System.Windows.Forms.DataGridViewComboBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewComboBoxColumn MaGia;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
