namespace _141_KinhDoanhNongSanVaThucPham
{
    partial class UC_DanhMucHT_ThanhToan
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
            this.groupBoxChucNang = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnSuaHinhThuc = new System.Windows.Forms.Button();
            this.btnThemHinhThuc = new System.Windows.Forms.Button();
            this.txtTenHinhThuc = new System.Windows.Forms.TextBox();
            this.lblHinhThucThanhToan = new System.Windows.Forms.Label();
            this.dataGV_HTThanhToan = new System.Windows.Forms.DataGridView();
            this.MaHT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenHT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXoaHinhThuc = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxChucNang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_HTThanhToan)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBoxChucNang, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblHinhThucThanhToan, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGV_HTThanhToan, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // groupBoxChucNang
            // 
            this.groupBoxChucNang.Controls.Add(this.btnLamMoi);
            this.groupBoxChucNang.Controls.Add(this.btnSuaHinhThuc);
            this.groupBoxChucNang.Controls.Add(this.btnXoaHinhThuc);
            this.groupBoxChucNang.Controls.Add(this.btnThemHinhThuc);
            this.groupBoxChucNang.Controls.Add(this.txtTenHinhThuc);
            this.groupBoxChucNang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxChucNang.Location = new System.Drawing.Point(5, 65);
            this.groupBoxChucNang.Margin = new System.Windows.Forms.Padding(5);
            this.groupBoxChucNang.Name = "groupBoxChucNang";
            this.groupBoxChucNang.Padding = new System.Windows.Forms.Padding(5);
            this.groupBoxChucNang.Size = new System.Drawing.Size(790, 170);
            this.groupBoxChucNang.TabIndex = 2;
            this.groupBoxChucNang.TabStop = false;
            this.groupBoxChucNang.Text = "Chức năng";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(606, 83);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(125, 50);
            this.btnLamMoi.TabIndex = 4;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnSuaHinhThuc
            // 
            this.btnSuaHinhThuc.Location = new System.Drawing.Point(417, 83);
            this.btnSuaHinhThuc.Margin = new System.Windows.Forms.Padding(4);
            this.btnSuaHinhThuc.Name = "btnSuaHinhThuc";
            this.btnSuaHinhThuc.Size = new System.Drawing.Size(150, 50);
            this.btnSuaHinhThuc.TabIndex = 3;
            this.btnSuaHinhThuc.Text = "Sửa HTTT";
            this.btnSuaHinhThuc.UseVisualStyleBackColor = true;
            this.btnSuaHinhThuc.Click += new System.EventHandler(this.btnSuaHinhThuc_Click);
            // 
            // btnThemHinhThuc
            // 
            this.btnThemHinhThuc.Location = new System.Drawing.Point(39, 83);
            this.btnThemHinhThuc.Margin = new System.Windows.Forms.Padding(4);
            this.btnThemHinhThuc.Name = "btnThemHinhThuc";
            this.btnThemHinhThuc.Size = new System.Drawing.Size(150, 50);
            this.btnThemHinhThuc.TabIndex = 1;
            this.btnThemHinhThuc.Text = "Thêm HTTT";
            this.btnThemHinhThuc.UseVisualStyleBackColor = true;
            this.btnThemHinhThuc.Click += new System.EventHandler(this.btnThemHinhThuc_Click);
            // 
            // txtTenHinhThuc
            // 
            this.txtTenHinhThuc.Location = new System.Drawing.Point(268, 29);
            this.txtTenHinhThuc.Margin = new System.Windows.Forms.Padding(5);
            this.txtTenHinhThuc.Name = "txtTenHinhThuc";
            this.txtTenHinhThuc.Size = new System.Drawing.Size(250, 22);
            this.txtTenHinhThuc.TabIndex = 0;
            // 
            // lblHinhThucThanhToan
            // 
            this.lblHinhThucThanhToan.AutoSize = true;
            this.lblHinhThucThanhToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHinhThucThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHinhThucThanhToan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblHinhThucThanhToan.Location = new System.Drawing.Point(5, 0);
            this.lblHinhThucThanhToan.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHinhThucThanhToan.Name = "lblHinhThucThanhToan";
            this.lblHinhThucThanhToan.Size = new System.Drawing.Size(790, 60);
            this.lblHinhThucThanhToan.TabIndex = 0;
            this.lblHinhThucThanhToan.Text = "DANH MỤC HÌNH THỨC THANH TOÁN";
            this.lblHinhThucThanhToan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGV_HTThanhToan
            // 
            this.dataGV_HTThanhToan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGV_HTThanhToan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV_HTThanhToan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHT,
            this.TenHT});
            this.dataGV_HTThanhToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGV_HTThanhToan.Location = new System.Drawing.Point(4, 244);
            this.dataGV_HTThanhToan.Margin = new System.Windows.Forms.Padding(4);
            this.dataGV_HTThanhToan.Name = "dataGV_HTThanhToan";
            this.dataGV_HTThanhToan.RowHeadersWidth = 51;
            this.dataGV_HTThanhToan.RowTemplate.Height = 24;
            this.dataGV_HTThanhToan.Size = new System.Drawing.Size(792, 352);
            this.dataGV_HTThanhToan.TabIndex = 3;
            this.dataGV_HTThanhToan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGV_HTThanhToan_CellClick);
            // 
            // MaHT
            // 
            this.MaHT.DataPropertyName = "MaHT";
            this.MaHT.HeaderText = "Mã hình thức";
            this.MaHT.MinimumWidth = 6;
            this.MaHT.Name = "MaHT";
            // 
            // TenHT
            // 
            this.TenHT.DataPropertyName = "TenHT";
            this.TenHT.HeaderText = "Tên hình thức";
            this.TenHT.MinimumWidth = 6;
            this.TenHT.Name = "TenHT";
            // 
            // btnXoaHinhThuc
            // 
            this.btnXoaHinhThuc.Location = new System.Drawing.Point(228, 83);
            this.btnXoaHinhThuc.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoaHinhThuc.Name = "btnXoaHinhThuc";
            this.btnXoaHinhThuc.Size = new System.Drawing.Size(150, 50);
            this.btnXoaHinhThuc.TabIndex = 2;
            this.btnXoaHinhThuc.Text = "Xóa HTTT";
            this.btnXoaHinhThuc.UseVisualStyleBackColor = true;
            this.btnXoaHinhThuc.Click += new System.EventHandler(this.btnXoaHinhThuc_Click);
            // 
            // UC_DanhMucHT_ThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_DanhMucHT_ThanhToan";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.UC_DanhMucHT_ThanhToan_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBoxChucNang.ResumeLayout(false);
            this.groupBoxChucNang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_HTThanhToan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBoxChucNang;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnSuaHinhThuc;
        private System.Windows.Forms.Button btnThemHinhThuc;
        private System.Windows.Forms.TextBox txtTenHinhThuc;
        private System.Windows.Forms.Label lblHinhThucThanhToan;
        private System.Windows.Forms.DataGridView dataGV_HTThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenHT;
        private System.Windows.Forms.Button btnXoaHinhThuc;
    }
}
