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
            this.lblLoHang = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.gbChucNang = new System.Windows.Forms.GroupBox();
            this.btnSuaLo = new System.Windows.Forms.Button();
            this.btnXoaLo = new System.Windows.Forms.Button();
            this.btnInExc = new System.Windows.Forms.Button();
            this.btnThemLo = new System.Windows.Forms.Button();
            this.gbTKLoHang = new System.Windows.Forms.GroupBox();
            this.cbbPhieuNhap = new System.Windows.Forms.ComboBox();
            this.lblPhieuNhap = new System.Windows.Forms.Label();
            this.btnTKLoHang = new System.Windows.Forms.Button();
            this.txtTKLoHang = new System.Windows.Forms.TextBox();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1100, 720);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dataGV_LoHang
            // 
            this.dataGV_LoHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV_LoHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLo,
            this.TenLo,
            this.NgaySanXuat,
            this.HanSuDung,
            this.SoLuong,
            this.MaPNH,
            this.MaSP});
            this.dataGV_LoHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGV_LoHang.Location = new System.Drawing.Point(3, 219);
            this.dataGV_LoHang.Name = "dataGV_LoHang";
            this.dataGV_LoHang.RowTemplate.Height = 24;
            this.dataGV_LoHang.Size = new System.Drawing.Size(1094, 498);
            this.dataGV_LoHang.TabIndex = 3;
            // 
            // MaLo
            // 
            this.MaLo.HeaderText = "Mã lô";
            this.MaLo.Name = "MaLo";
            // 
            // TenLo
            // 
            this.TenLo.HeaderText = "Số lô";
            this.TenLo.Name = "TenLo";
            this.TenLo.Width = 120;
            // 
            // NgaySanXuat
            // 
            this.NgaySanXuat.HeaderText = "Ngày sản xuất";
            this.NgaySanXuat.Name = "NgaySanXuat";
            this.NgaySanXuat.Width = 130;
            // 
            // HanSuDung
            // 
            this.HanSuDung.HeaderText = "Hạn sử dụng";
            this.HanSuDung.Name = "HanSuDung";
            this.HanSuDung.Width = 120;
            // 
            // SoLuong
            // 
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.Name = "SoLuong";
            // 
            // MaPNH
            // 
            this.MaPNH.HeaderText = "Phiếu nhập";
            this.MaPNH.Name = "MaPNH";
            this.MaPNH.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MaPNH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MaPNH.Width = 120;
            // 
            // MaSP
            // 
            this.MaSP.HeaderText = "Sản phẩm";
            this.MaSP.Name = "MaSP";
            this.MaSP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MaSP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MaSP.Width = 300;
            // 
            // lblLoHang
            // 
            this.lblLoHang.AutoSize = true;
            this.lblLoHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblLoHang.Location = new System.Drawing.Point(3, 0);
            this.lblLoHang.Name = "lblLoHang";
            this.lblLoHang.Size = new System.Drawing.Size(1094, 72);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1094, 138);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // gbChucNang
            // 
            this.gbChucNang.Controls.Add(this.btnSuaLo);
            this.gbChucNang.Controls.Add(this.btnXoaLo);
            this.gbChucNang.Controls.Add(this.btnInExc);
            this.gbChucNang.Controls.Add(this.btnThemLo);
            this.gbChucNang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbChucNang.Location = new System.Drawing.Point(440, 3);
            this.gbChucNang.Name = "gbChucNang";
            this.gbChucNang.Size = new System.Drawing.Size(651, 132);
            this.gbChucNang.TabIndex = 2;
            this.gbChucNang.TabStop = false;
            this.gbChucNang.Text = "Chức năng";
            // 
            // btnSuaLo
            // 
            this.btnSuaLo.Location = new System.Drawing.Point(352, 49);
            this.btnSuaLo.Name = "btnSuaLo";
            this.btnSuaLo.Size = new System.Drawing.Size(120, 40);
            this.btnSuaLo.TabIndex = 2;
            this.btnSuaLo.Text = "Sửa lô";
            this.btnSuaLo.UseVisualStyleBackColor = true;
            // 
            // btnXoaLo
            // 
            this.btnXoaLo.Location = new System.Drawing.Point(198, 49);
            this.btnXoaLo.Name = "btnXoaLo";
            this.btnXoaLo.Size = new System.Drawing.Size(120, 40);
            this.btnXoaLo.TabIndex = 1;
            this.btnXoaLo.Text = "Xóa lô";
            this.btnXoaLo.UseVisualStyleBackColor = true;
            // 
            // btnInExc
            // 
            this.btnInExc.Location = new System.Drawing.Point(506, 49);
            this.btnInExc.Name = "btnInExc";
            this.btnInExc.Size = new System.Drawing.Size(100, 40);
            this.btnInExc.TabIndex = 3;
            this.btnInExc.Text = "In Excel";
            this.btnInExc.UseVisualStyleBackColor = true;
            // 
            // btnThemLo
            // 
            this.btnThemLo.Location = new System.Drawing.Point(44, 49);
            this.btnThemLo.Name = "btnThemLo";
            this.btnThemLo.Size = new System.Drawing.Size(120, 40);
            this.btnThemLo.TabIndex = 0;
            this.btnThemLo.Text = "Thêm lô";
            this.btnThemLo.UseVisualStyleBackColor = true;
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
            this.gbTKLoHang.Size = new System.Drawing.Size(431, 132);
            this.gbTKLoHang.TabIndex = 1;
            this.gbTKLoHang.TabStop = false;
            this.gbTKLoHang.Text = "Tìm kiếm lô hàng";
            // 
            // cbbPhieuNhap
            // 
            this.cbbPhieuNhap.FormattingEnabled = true;
            this.cbbPhieuNhap.Location = new System.Drawing.Point(120, 33);
            this.cbbPhieuNhap.Name = "cbbPhieuNhap";
            this.cbbPhieuNhap.Size = new System.Drawing.Size(200, 24);
            this.cbbPhieuNhap.TabIndex = 3;
            // 
            // lblPhieuNhap
            // 
            this.lblPhieuNhap.AutoSize = true;
            this.lblPhieuNhap.Location = new System.Drawing.Point(35, 36);
            this.lblPhieuNhap.Name = "lblPhieuNhap";
            this.lblPhieuNhap.Size = new System.Drawing.Size(80, 17);
            this.lblPhieuNhap.TabIndex = 2;
            this.lblPhieuNhap.Text = "Phiếu nhập";
            // 
            // btnTKLoHang
            // 
            this.btnTKLoHang.Location = new System.Drawing.Point(293, 63);
            this.btnTKLoHang.Name = "btnTKLoHang";
            this.btnTKLoHang.Size = new System.Drawing.Size(100, 40);
            this.btnTKLoHang.TabIndex = 1;
            this.btnTKLoHang.Text = "Tìm kiếm";
            this.btnTKLoHang.UseVisualStyleBackColor = true;
            // 
            // txtTKLoHang
            // 
            this.txtTKLoHang.Location = new System.Drawing.Point(37, 72);
            this.txtTKLoHang.Name = "txtTKLoHang";
            this.txtTKLoHang.Size = new System.Drawing.Size(250, 22);
            this.txtTKLoHang.TabIndex = 0;
            // 
            // UC_DanhMucLoHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_DanhMucLoHang";
            this.Size = new System.Drawing.Size(1100, 720);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySanXuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanSuDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewComboBoxColumn MaPNH;
        private System.Windows.Forms.DataGridViewComboBoxColumn MaSP;
        private System.Windows.Forms.Label lblLoHang;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox gbChucNang;
        private System.Windows.Forms.Button btnSuaLo;
        private System.Windows.Forms.Button btnXoaLo;
        private System.Windows.Forms.Button btnInExc;
        private System.Windows.Forms.Button btnThemLo;
        private System.Windows.Forms.GroupBox gbTKLoHang;
        private System.Windows.Forms.ComboBox cbbPhieuNhap;
        private System.Windows.Forms.Label lblPhieuNhap;
        private System.Windows.Forms.Button btnTKLoHang;
        private System.Windows.Forms.TextBox txtTKLoHang;
    }
}
