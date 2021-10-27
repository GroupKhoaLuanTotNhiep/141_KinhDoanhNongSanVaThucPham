namespace _141_KinhDoanhNongSanVaThucPham
{
    partial class UC_DanhMucKhuyenMai
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
            this.lblKhuyenMai = new System.Windows.Forms.Label();
            this.groupBoxTTKhuyenMai = new System.Windows.Forms.GroupBox();
            this.btnSuaKM = new System.Windows.Forms.Button();
            this.btnXoaKM = new System.Windows.Forms.Button();
            this.btnNgungKM = new System.Windows.Forms.Button();
            this.btnTaoKM = new System.Windows.Forms.Button();
            this.txtNoiDungKM = new System.Windows.Forms.TextBox();
            this.lblNoiDungKM = new System.Windows.Forms.Label();
            this.txtGiaTriKM = new System.Windows.Forms.TextBox();
            this.lblGiaTriKM = new System.Windows.Forms.Label();
            this.txtTenKM = new System.Windows.Forms.TextBox();
            this.lblTenKM = new System.Windows.Forms.Label();
            this.txtMaKM = new System.Windows.Forms.TextBox();
            this.lblMaKM = new System.Windows.Forms.Label();
            this.dataGV_DMKhuyenMai = new System.Windows.Forms.DataGridView();
            this.MaKM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaTriKM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxTTKhuyenMai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_DMKhuyenMai)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblKhuyenMai, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxTTKhuyenMai, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGV_DMKhuyenMai, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1200, 650);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblKhuyenMai
            // 
            this.lblKhuyenMai.AutoSize = true;
            this.lblKhuyenMai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKhuyenMai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhuyenMai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblKhuyenMai.Location = new System.Drawing.Point(3, 0);
            this.lblKhuyenMai.Name = "lblKhuyenMai";
            this.lblKhuyenMai.Size = new System.Drawing.Size(1194, 65);
            this.lblKhuyenMai.TabIndex = 0;
            this.lblKhuyenMai.Text = "DANH MỤC KHUYẾN MÃI";
            this.lblKhuyenMai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxTTKhuyenMai
            // 
            this.groupBoxTTKhuyenMai.Controls.Add(this.btnSuaKM);
            this.groupBoxTTKhuyenMai.Controls.Add(this.btnXoaKM);
            this.groupBoxTTKhuyenMai.Controls.Add(this.btnNgungKM);
            this.groupBoxTTKhuyenMai.Controls.Add(this.btnTaoKM);
            this.groupBoxTTKhuyenMai.Controls.Add(this.txtNoiDungKM);
            this.groupBoxTTKhuyenMai.Controls.Add(this.lblNoiDungKM);
            this.groupBoxTTKhuyenMai.Controls.Add(this.txtGiaTriKM);
            this.groupBoxTTKhuyenMai.Controls.Add(this.lblGiaTriKM);
            this.groupBoxTTKhuyenMai.Controls.Add(this.txtTenKM);
            this.groupBoxTTKhuyenMai.Controls.Add(this.lblTenKM);
            this.groupBoxTTKhuyenMai.Controls.Add(this.txtMaKM);
            this.groupBoxTTKhuyenMai.Controls.Add(this.lblMaKM);
            this.groupBoxTTKhuyenMai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTTKhuyenMai.Location = new System.Drawing.Point(3, 68);
            this.groupBoxTTKhuyenMai.Name = "groupBoxTTKhuyenMai";
            this.groupBoxTTKhuyenMai.Size = new System.Drawing.Size(1194, 189);
            this.groupBoxTTKhuyenMai.TabIndex = 1;
            this.groupBoxTTKhuyenMai.TabStop = false;
            this.groupBoxTTKhuyenMai.Text = "Thông tin khuyến mãi";
            // 
            // btnSuaKM
            // 
            this.btnSuaKM.Location = new System.Drawing.Point(846, 97);
            this.btnSuaKM.Name = "btnSuaKM";
            this.btnSuaKM.Size = new System.Drawing.Size(110, 40);
            this.btnSuaKM.TabIndex = 10;
            this.btnSuaKM.Text = "Sửa KM";
            this.btnSuaKM.UseVisualStyleBackColor = true;
            // 
            // btnXoaKM
            // 
            this.btnXoaKM.Location = new System.Drawing.Point(1006, 44);
            this.btnXoaKM.Name = "btnXoaKM";
            this.btnXoaKM.Size = new System.Drawing.Size(100, 40);
            this.btnXoaKM.TabIndex = 9;
            this.btnXoaKM.Text = "Xóa KM";
            this.btnXoaKM.UseVisualStyleBackColor = true;
            // 
            // btnNgungKM
            // 
            this.btnNgungKM.Location = new System.Drawing.Point(1006, 97);
            this.btnNgungKM.Name = "btnNgungKM";
            this.btnNgungKM.Size = new System.Drawing.Size(100, 40);
            this.btnNgungKM.TabIndex = 11;
            this.btnNgungKM.Text = "Ngưng KM";
            this.btnNgungKM.UseVisualStyleBackColor = true;
            // 
            // btnTaoKM
            // 
            this.btnTaoKM.Location = new System.Drawing.Point(846, 44);
            this.btnTaoKM.Name = "btnTaoKM";
            this.btnTaoKM.Size = new System.Drawing.Size(110, 40);
            this.btnTaoKM.TabIndex = 8;
            this.btnTaoKM.Text = "Tạo KM";
            this.btnTaoKM.UseVisualStyleBackColor = true;
            // 
            // txtNoiDungKM
            // 
            this.txtNoiDungKM.Location = new System.Drawing.Point(228, 106);
            this.txtNoiDungKM.Name = "txtNoiDungKM";
            this.txtNoiDungKM.Size = new System.Drawing.Size(518, 22);
            this.txtNoiDungKM.TabIndex = 7;
            // 
            // lblNoiDungKM
            // 
            this.lblNoiDungKM.AutoSize = true;
            this.lblNoiDungKM.Location = new System.Drawing.Point(72, 109);
            this.lblNoiDungKM.Name = "lblNoiDungKM";
            this.lblNoiDungKM.Size = new System.Drawing.Size(141, 17);
            this.lblNoiDungKM.TabIndex = 6;
            this.lblNoiDungKM.Text = "Nội dung khuyến mãi";
            // 
            // txtGiaTriKM
            // 
            this.txtGiaTriKM.Location = new System.Drawing.Point(546, 53);
            this.txtGiaTriKM.Name = "txtGiaTriKM";
            this.txtGiaTriKM.Size = new System.Drawing.Size(200, 22);
            this.txtGiaTriKM.TabIndex = 5;
            // 
            // lblGiaTriKM
            // 
            this.lblGiaTriKM.AutoSize = true;
            this.lblGiaTriKM.Location = new System.Drawing.Point(543, 33);
            this.lblGiaTriKM.Name = "lblGiaTriKM";
            this.lblGiaTriKM.Size = new System.Drawing.Size(191, 17);
            this.lblGiaTriKM.TabIndex = 4;
            this.lblGiaTriKM.Text = "Giá tri/Phần trăm khuyến mãi";
            // 
            // txtTenKM
            // 
            this.txtTenKM.Location = new System.Drawing.Point(260, 53);
            this.txtTenKM.Name = "txtTenKM";
            this.txtTenKM.Size = new System.Drawing.Size(200, 22);
            this.txtTenKM.TabIndex = 3;
            // 
            // lblTenKM
            // 
            this.lblTenKM.AutoSize = true;
            this.lblTenKM.Location = new System.Drawing.Point(257, 33);
            this.lblTenKM.Name = "lblTenKM";
            this.lblTenKM.Size = new System.Drawing.Size(109, 17);
            this.lblTenKM.TabIndex = 2;
            this.lblTenKM.Text = "Tên khuyến mãi";
            // 
            // txtMaKM
            // 
            this.txtMaKM.Location = new System.Drawing.Point(75, 53);
            this.txtMaKM.Name = "txtMaKM";
            this.txtMaKM.Size = new System.Drawing.Size(100, 22);
            this.txtMaKM.TabIndex = 1;
            // 
            // lblMaKM
            // 
            this.lblMaKM.AutoSize = true;
            this.lblMaKM.Location = new System.Drawing.Point(72, 33);
            this.lblMaKM.Name = "lblMaKM";
            this.lblMaKM.Size = new System.Drawing.Size(103, 17);
            this.lblMaKM.TabIndex = 0;
            this.lblMaKM.Text = "Mã khuyến mãi";
            // 
            // dataGV_DMKhuyenMai
            // 
            this.dataGV_DMKhuyenMai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV_DMKhuyenMai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKM,
            this.TenKM,
            this.GiaTriKM,
            this.NoiDung});
            this.dataGV_DMKhuyenMai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGV_DMKhuyenMai.Location = new System.Drawing.Point(3, 263);
            this.dataGV_DMKhuyenMai.Name = "dataGV_DMKhuyenMai";
            this.dataGV_DMKhuyenMai.RowTemplate.Height = 24;
            this.dataGV_DMKhuyenMai.Size = new System.Drawing.Size(1194, 384);
            this.dataGV_DMKhuyenMai.TabIndex = 2;
            // 
            // MaKM
            // 
            this.MaKM.HeaderText = "Mã khuyến mãi";
            this.MaKM.Name = "MaKM";
            this.MaKM.Width = 150;
            // 
            // TenKM
            // 
            this.TenKM.HeaderText = "Tên khuyến mãi";
            this.TenKM.Name = "TenKM";
            this.TenKM.Width = 180;
            // 
            // GiaTriKM
            // 
            this.GiaTriKM.HeaderText = "Giá trị khuyến mãi";
            this.GiaTriKM.Name = "GiaTriKM";
            this.GiaTriKM.Width = 160;
            // 
            // NoiDung
            // 
            this.NoiDung.HeaderText = "Nội dung khuyến mãi";
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.Width = 300;
            // 
            // UC_DanhMucKhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_DanhMucKhuyenMai";
            this.Size = new System.Drawing.Size(1200, 650);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBoxTTKhuyenMai.ResumeLayout(false);
            this.groupBoxTTKhuyenMai.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_DMKhuyenMai)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblKhuyenMai;
        private System.Windows.Forms.GroupBox groupBoxTTKhuyenMai;
        private System.Windows.Forms.Button btnSuaKM;
        private System.Windows.Forms.Button btnXoaKM;
        private System.Windows.Forms.Button btnNgungKM;
        private System.Windows.Forms.Button btnTaoKM;
        private System.Windows.Forms.TextBox txtNoiDungKM;
        private System.Windows.Forms.Label lblNoiDungKM;
        private System.Windows.Forms.TextBox txtGiaTriKM;
        private System.Windows.Forms.Label lblGiaTriKM;
        private System.Windows.Forms.TextBox txtTenKM;
        private System.Windows.Forms.Label lblTenKM;
        private System.Windows.Forms.TextBox txtMaKM;
        private System.Windows.Forms.Label lblMaKM;
        private System.Windows.Forms.DataGridView dataGV_DMKhuyenMai;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKM;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKM;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaTriKM;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
    }
}
