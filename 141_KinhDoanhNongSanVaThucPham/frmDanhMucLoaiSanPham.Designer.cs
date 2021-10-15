namespace _141_KinhDoanhNongSanVaThucPham
{
    partial class frmDanhMucLoaiSanPham
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
            this.groupBoxChucNang = new System.Windows.Forms.GroupBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnSuaLoai = new System.Windows.Forms.Button();
            this.btnXoaLoai = new System.Windows.Forms.Button();
            this.btnThemLoai = new System.Windows.Forms.Button();
            this.txtTenLoai = new System.Windows.Forms.TextBox();
            this.lblLoaiSP = new System.Windows.Forms.Label();
            this.dataGV_LoaiSanPham = new System.Windows.Forms.DataGridView();
            this.MaLoaiSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoaiSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxChucNang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_LoaiSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBoxChucNang, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblLoaiSP, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGV_LoaiSanPham, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(794, 727);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBoxChucNang
            // 
            this.groupBoxChucNang.Controls.Add(this.btnDong);
            this.groupBoxChucNang.Controls.Add(this.btnSuaLoai);
            this.groupBoxChucNang.Controls.Add(this.btnXoaLoai);
            this.groupBoxChucNang.Controls.Add(this.btnThemLoai);
            this.groupBoxChucNang.Controls.Add(this.txtTenLoai);
            this.groupBoxChucNang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxChucNang.Location = new System.Drawing.Point(5, 77);
            this.groupBoxChucNang.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBoxChucNang.Name = "groupBoxChucNang";
            this.groupBoxChucNang.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBoxChucNang.Size = new System.Drawing.Size(784, 208);
            this.groupBoxChucNang.TabIndex = 2;
            this.groupBoxChucNang.TabStop = false;
            this.groupBoxChucNang.Text = "Chức năng";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(616, 109);
            this.btnDong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(125, 50);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // btnSuaLoai
            // 
            this.btnSuaLoai.Location = new System.Drawing.Point(424, 109);
            this.btnSuaLoai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSuaLoai.Name = "btnSuaLoai";
            this.btnSuaLoai.Size = new System.Drawing.Size(150, 50);
            this.btnSuaLoai.TabIndex = 3;
            this.btnSuaLoai.Text = "Sửa loại";
            this.btnSuaLoai.UseVisualStyleBackColor = true;
            // 
            // btnXoaLoai
            // 
            this.btnXoaLoai.Location = new System.Drawing.Point(231, 109);
            this.btnXoaLoai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnXoaLoai.Name = "btnXoaLoai";
            this.btnXoaLoai.Size = new System.Drawing.Size(150, 50);
            this.btnXoaLoai.TabIndex = 2;
            this.btnXoaLoai.Text = "Xóa loại";
            this.btnXoaLoai.UseVisualStyleBackColor = true;
            // 
            // btnThemLoai
            // 
            this.btnThemLoai.Location = new System.Drawing.Point(39, 109);
            this.btnThemLoai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThemLoai.Name = "btnThemLoai";
            this.btnThemLoai.Size = new System.Drawing.Size(150, 50);
            this.btnThemLoai.TabIndex = 1;
            this.btnThemLoai.Text = "Thêm loại";
            this.btnThemLoai.UseVisualStyleBackColor = true;
            // 
            // txtTenLoai
            // 
            this.txtTenLoai.Location = new System.Drawing.Point(268, 50);
            this.txtTenLoai.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtTenLoai.Name = "txtTenLoai";
            this.txtTenLoai.Size = new System.Drawing.Size(249, 27);
            this.txtTenLoai.TabIndex = 0;
            // 
            // lblLoaiSP
            // 
            this.lblLoaiSP.AutoSize = true;
            this.lblLoaiSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoaiSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiSP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblLoaiSP.Location = new System.Drawing.Point(5, 0);
            this.lblLoaiSP.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLoaiSP.Name = "lblLoaiSP";
            this.lblLoaiSP.Size = new System.Drawing.Size(784, 72);
            this.lblLoaiSP.TabIndex = 0;
            this.lblLoaiSP.Text = "DANH MỤC LOẠI SẢN PHẨM";
            this.lblLoaiSP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGV_LoaiSanPham
            // 
            this.dataGV_LoaiSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV_LoaiSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLoaiSP,
            this.TenLoaiSP});
            this.dataGV_LoaiSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGV_LoaiSanPham.Location = new System.Drawing.Point(4, 294);
            this.dataGV_LoaiSanPham.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGV_LoaiSanPham.Name = "dataGV_LoaiSanPham";
            this.dataGV_LoaiSanPham.RowTemplate.Height = 24;
            this.dataGV_LoaiSanPham.Size = new System.Drawing.Size(786, 429);
            this.dataGV_LoaiSanPham.TabIndex = 3;
            // 
            // MaLoaiSP
            // 
            this.MaLoaiSP.HeaderText = "Mã loại sản phẩm";
            this.MaLoaiSP.Name = "MaLoaiSP";
            this.MaLoaiSP.Width = 200;
            // 
            // TenLoaiSP
            // 
            this.TenLoaiSP.HeaderText = "Tên loại sản phẩm";
            this.TenLoaiSP.Name = "TenLoaiSP";
            this.TenLoaiSP.Width = 250;
            // 
            // frmDanhMucLoaiSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 727);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmDanhMucLoaiSanPham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục loại sản phẩm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBoxChucNang.ResumeLayout(false);
            this.groupBoxChucNang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_LoaiSanPham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBoxChucNang;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnSuaLoai;
        private System.Windows.Forms.Button btnXoaLoai;
        private System.Windows.Forms.Button btnThemLoai;
        private System.Windows.Forms.TextBox txtTenLoai;
        private System.Windows.Forms.Label lblLoaiSP;
        private System.Windows.Forms.DataGridView dataGV_LoaiSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLoaiSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoaiSP;
    }
}