namespace _141_KinhDoanhNongSanVaThucPham
{
    partial class UC_DanhMucChiNhanh
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
            this.lblChiNhanh = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.gbTKChiNhanh = new System.Windows.Forms.GroupBox();
            this.btnTKChinhNhanh = new System.Windows.Forms.Button();
            this.txtTKChiNhanh = new System.Windows.Forms.TextBox();
            this.gbChucnang = new System.Windows.Forms.GroupBox();
            this.btnSuaChiNhanh = new System.Windows.Forms.Button();
            this.btnXoaChiNhanh = new System.Windows.Forms.Button();
            this.btnXemHoatDong = new System.Windows.Forms.Button();
            this.btnTaoChinhNhanh = new System.Windows.Forms.Button();
            this.dataGV_ChiNhanh = new System.Windows.Forms.DataGridView();
            this.MaChiNhanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenChiNhanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gbTKChiNhanh.SuspendLayout();
            this.gbChucnang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_ChiNhanh)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblChiNhanh, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGV_ChiNhanh, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1200, 750);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // lblChiNhanh
            // 
            this.lblChiNhanh.AutoSize = true;
            this.lblChiNhanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChiNhanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChiNhanh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblChiNhanh.Location = new System.Drawing.Point(3, 0);
            this.lblChiNhanh.Name = "lblChiNhanh";
            this.lblChiNhanh.Size = new System.Drawing.Size(1194, 75);
            this.lblChiNhanh.TabIndex = 0;
            this.lblChiNhanh.Text = "DANH MỤC CHI NHÁNH";
            this.lblChiNhanh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.Controls.Add(this.gbTKChiNhanh, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.gbChucnang, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 78);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1194, 106);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // gbTKChiNhanh
            // 
            this.gbTKChiNhanh.Controls.Add(this.btnTKChinhNhanh);
            this.gbTKChiNhanh.Controls.Add(this.txtTKChiNhanh);
            this.gbTKChiNhanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTKChiNhanh.Location = new System.Drawing.Point(3, 3);
            this.gbTKChiNhanh.Name = "gbTKChiNhanh";
            this.gbTKChiNhanh.Size = new System.Drawing.Size(471, 100);
            this.gbTKChiNhanh.TabIndex = 0;
            this.gbTKChiNhanh.TabStop = false;
            this.gbTKChiNhanh.Text = "Tìm kiếm chi nhánh";
            // 
            // btnTKChinhNhanh
            // 
            this.btnTKChinhNhanh.Location = new System.Drawing.Point(251, 36);
            this.btnTKChinhNhanh.Name = "btnTKChinhNhanh";
            this.btnTKChinhNhanh.Size = new System.Drawing.Size(90, 34);
            this.btnTKChinhNhanh.TabIndex = 1;
            this.btnTKChinhNhanh.Text = "Tìm kiếm";
            this.btnTKChinhNhanh.UseVisualStyleBackColor = true;
            this.btnTKChinhNhanh.Click += new System.EventHandler(this.btnTKChinhNhanh_Click);
            // 
            // txtTKChiNhanh
            // 
            this.txtTKChiNhanh.Location = new System.Drawing.Point(45, 42);
            this.txtTKChiNhanh.Name = "txtTKChiNhanh";
            this.txtTKChiNhanh.Size = new System.Drawing.Size(200, 22);
            this.txtTKChiNhanh.TabIndex = 0;
            // 
            // gbChucnang
            // 
            this.gbChucnang.Controls.Add(this.btnSuaChiNhanh);
            this.gbChucnang.Controls.Add(this.btnXoaChiNhanh);
            this.gbChucnang.Controls.Add(this.btnXemHoatDong);
            this.gbChucnang.Controls.Add(this.btnTaoChinhNhanh);
            this.gbChucnang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbChucnang.Location = new System.Drawing.Point(480, 3);
            this.gbChucnang.Name = "gbChucnang";
            this.gbChucnang.Size = new System.Drawing.Size(711, 100);
            this.gbChucnang.TabIndex = 1;
            this.gbChucnang.TabStop = false;
            this.gbChucnang.Text = "Chức năng";
            // 
            // btnSuaChiNhanh
            // 
            this.btnSuaChiNhanh.Location = new System.Drawing.Point(315, 33);
            this.btnSuaChiNhanh.Name = "btnSuaChiNhanh";
            this.btnSuaChiNhanh.Size = new System.Drawing.Size(100, 40);
            this.btnSuaChiNhanh.TabIndex = 2;
            this.btnSuaChiNhanh.Text = "Sửa";
            this.btnSuaChiNhanh.UseVisualStyleBackColor = true;
            this.btnSuaChiNhanh.Click += new System.EventHandler(this.btnSuaChiNhanh_Click);
            // 
            // btnXoaChiNhanh
            // 
            this.btnXoaChiNhanh.Location = new System.Drawing.Point(196, 33);
            this.btnXoaChiNhanh.Name = "btnXoaChiNhanh";
            this.btnXoaChiNhanh.Size = new System.Drawing.Size(100, 40);
            this.btnXoaChiNhanh.TabIndex = 1;
            this.btnXoaChiNhanh.Text = "Xóa";
            this.btnXoaChiNhanh.UseVisualStyleBackColor = true;
            this.btnXoaChiNhanh.Click += new System.EventHandler(this.btnXoaChiNhanh_Click);
            // 
            // btnXemHoatDong
            // 
            this.btnXemHoatDong.Location = new System.Drawing.Point(434, 33);
            this.btnXemHoatDong.Name = "btnXemHoatDong";
            this.btnXemHoatDong.Size = new System.Drawing.Size(150, 40);
            this.btnXemHoatDong.TabIndex = 3;
            this.btnXemHoatDong.Text = "Xem hoạt động";
            this.btnXemHoatDong.UseVisualStyleBackColor = true;
            this.btnXemHoatDong.Click += new System.EventHandler(this.btnXemHoatDong_Click);
            // 
            // btnTaoChinhNhanh
            // 
            this.btnTaoChinhNhanh.Location = new System.Drawing.Point(77, 33);
            this.btnTaoChinhNhanh.Name = "btnTaoChinhNhanh";
            this.btnTaoChinhNhanh.Size = new System.Drawing.Size(100, 40);
            this.btnTaoChinhNhanh.TabIndex = 0;
            this.btnTaoChinhNhanh.Text = "Thêm";
            this.btnTaoChinhNhanh.UseVisualStyleBackColor = true;
            this.btnTaoChinhNhanh.Click += new System.EventHandler(this.btnTaoChinhNhanh_Click);
            // 
            // dataGV_ChiNhanh
            // 
            this.dataGV_ChiNhanh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGV_ChiNhanh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV_ChiNhanh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaChiNhanh,
            this.TenChiNhanh,
            this.DiaChi,
            this.DienThoai});
            this.dataGV_ChiNhanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGV_ChiNhanh.Location = new System.Drawing.Point(3, 190);
            this.dataGV_ChiNhanh.Name = "dataGV_ChiNhanh";
            this.dataGV_ChiNhanh.RowHeadersWidth = 51;
            this.dataGV_ChiNhanh.RowTemplate.Height = 24;
            this.dataGV_ChiNhanh.Size = new System.Drawing.Size(1194, 557);
            this.dataGV_ChiNhanh.TabIndex = 2;
            this.dataGV_ChiNhanh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGV_ChiNhanh_CellClick);
            // 
            // MaChiNhanh
            // 
            this.MaChiNhanh.DataPropertyName = "MaChiNhanh";
            this.MaChiNhanh.HeaderText = "Mã chi nhánh";
            this.MaChiNhanh.MinimumWidth = 6;
            this.MaChiNhanh.Name = "MaChiNhanh";
            // 
            // TenChiNhanh
            // 
            this.TenChiNhanh.DataPropertyName = "TenChiNhanh";
            this.TenChiNhanh.HeaderText = "Tên chi nhánh";
            this.TenChiNhanh.MinimumWidth = 6;
            this.TenChiNhanh.Name = "TenChiNhanh";
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
            // UC_DanhMucChiNhanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_DanhMucChiNhanh";
            this.Size = new System.Drawing.Size(1200, 750);
            this.Load += new System.EventHandler(this.UC_DanhMucChiNhanh_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.gbTKChiNhanh.ResumeLayout(false);
            this.gbTKChiNhanh.PerformLayout();
            this.gbChucnang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_ChiNhanh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblChiNhanh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox gbTKChiNhanh;
        private System.Windows.Forms.Button btnTKChinhNhanh;
        private System.Windows.Forms.TextBox txtTKChiNhanh;
        private System.Windows.Forms.GroupBox gbChucnang;
        private System.Windows.Forms.Button btnSuaChiNhanh;
        private System.Windows.Forms.Button btnXoaChiNhanh;
        private System.Windows.Forms.Button btnXemHoatDong;
        private System.Windows.Forms.Button btnTaoChinhNhanh;
        private System.Windows.Forms.DataGridView dataGV_ChiNhanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChiNhanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenChiNhanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn DienThoai;
    }
}
