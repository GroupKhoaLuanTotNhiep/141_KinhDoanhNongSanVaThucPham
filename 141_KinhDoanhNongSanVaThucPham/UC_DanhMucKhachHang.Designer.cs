namespace _141_KinhDoanhNongSanVaThucPham
{
    partial class UC_DanhMucKhachHang
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
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.gbTKKhach = new System.Windows.Forms.GroupBox();
            this.btnTK = new System.Windows.Forms.Button();
            this.txtTKKhach = new System.Windows.Forms.TextBox();
            this.gbChucNang = new System.Windows.Forms.GroupBox();
            this.btnSuaKhachHang = new System.Windows.Forms.Button();
            this.btnXoaKhachHang = new System.Windows.Forms.Button();
            this.btnInExc = new System.Windows.Forms.Button();
            this.btnTaoKhachHang = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MaKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatKhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TichDiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gbTKKhach.SuspendLayout();
            this.gbChucNang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblKhachHang, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1100, 760);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhachHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblKhachHang.Location = new System.Drawing.Point(3, 0);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(1094, 76);
            this.lblKhachHang.TabIndex = 0;
            this.lblKhachHang.Text = "DANH MỤC KHÁCH HÀNG";
            this.lblKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.Controls.Add(this.gbTKKhach, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.gbChucNang, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 79);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1094, 108);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // gbTKKhach
            // 
            this.gbTKKhach.Controls.Add(this.btnTK);
            this.gbTKKhach.Controls.Add(this.txtTKKhach);
            this.gbTKKhach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTKKhach.Location = new System.Drawing.Point(3, 3);
            this.gbTKKhach.Name = "gbTKKhach";
            this.gbTKKhach.Size = new System.Drawing.Size(431, 102);
            this.gbTKKhach.TabIndex = 0;
            this.gbTKKhach.TabStop = false;
            this.gbTKKhach.Text = "Tìm kiếm khách hàng";
            // 
            // btnTK
            // 
            this.btnTK.Location = new System.Drawing.Point(292, 34);
            this.btnTK.Name = "btnTK";
            this.btnTK.Size = new System.Drawing.Size(90, 40);
            this.btnTK.TabIndex = 1;
            this.btnTK.Text = "Tìm kiếm";
            this.btnTK.UseVisualStyleBackColor = true;
            // 
            // txtTKKhach
            // 
            this.txtTKKhach.Location = new System.Drawing.Point(36, 43);
            this.txtTKKhach.Name = "txtTKKhach";
            this.txtTKKhach.Size = new System.Drawing.Size(250, 22);
            this.txtTKKhach.TabIndex = 0;
            // 
            // gbChucNang
            // 
            this.gbChucNang.Controls.Add(this.btnSuaKhachHang);
            this.gbChucNang.Controls.Add(this.btnXoaKhachHang);
            this.gbChucNang.Controls.Add(this.btnInExc);
            this.gbChucNang.Controls.Add(this.btnTaoKhachHang);
            this.gbChucNang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbChucNang.Location = new System.Drawing.Point(440, 3);
            this.gbChucNang.Name = "gbChucNang";
            this.gbChucNang.Size = new System.Drawing.Size(651, 102);
            this.gbChucNang.TabIndex = 1;
            this.gbChucNang.TabStop = false;
            this.gbChucNang.Text = "Chức năng";
            // 
            // btnSuaKhachHang
            // 
            this.btnSuaKhachHang.Location = new System.Drawing.Point(370, 34);
            this.btnSuaKhachHang.Name = "btnSuaKhachHang";
            this.btnSuaKhachHang.Size = new System.Drawing.Size(160, 40);
            this.btnSuaKhachHang.TabIndex = 2;
            this.btnSuaKhachHang.Text = "Sửa khách hàng";
            this.btnSuaKhachHang.UseVisualStyleBackColor = true;
            // 
            // btnXoaKhachHang
            // 
            this.btnXoaKhachHang.Location = new System.Drawing.Point(194, 34);
            this.btnXoaKhachHang.Name = "btnXoaKhachHang";
            this.btnXoaKhachHang.Size = new System.Drawing.Size(160, 40);
            this.btnXoaKhachHang.TabIndex = 1;
            this.btnXoaKhachHang.Text = "Xóa khách hàng";
            this.btnXoaKhachHang.UseVisualStyleBackColor = true;
            // 
            // btnInExc
            // 
            this.btnInExc.Location = new System.Drawing.Point(546, 34);
            this.btnInExc.Name = "btnInExc";
            this.btnInExc.Size = new System.Drawing.Size(80, 40);
            this.btnInExc.TabIndex = 3;
            this.btnInExc.Text = "In Excel";
            this.btnInExc.UseVisualStyleBackColor = true;
            // 
            // btnTaoKhachHang
            // 
            this.btnTaoKhachHang.Location = new System.Drawing.Point(18, 34);
            this.btnTaoKhachHang.Name = "btnTaoKhachHang";
            this.btnTaoKhachHang.Size = new System.Drawing.Size(160, 40);
            this.btnTaoKhachHang.TabIndex = 0;
            this.btnTaoKhachHang.Text = "Tạo khách hàng";
            this.btnTaoKhachHang.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKhachHang,
            this.TenKhachHang,
            this.DiaChi,
            this.SDT,
            this.email,
            this.MatKhau,
            this.TichDiem});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 193);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1094, 564);
            this.dataGridView1.TabIndex = 2;
            // 
            // MaKhachHang
            // 
            this.MaKhachHang.HeaderText = "Mã khách hàng";
            this.MaKhachHang.Name = "MaKhachHang";
            this.MaKhachHang.Width = 140;
            // 
            // TenKhachHang
            // 
            this.TenKhachHang.HeaderText = "Tên khách hàng";
            this.TenKhachHang.Name = "TenKhachHang";
            this.TenKhachHang.Width = 200;
            // 
            // DiaChi
            // 
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 250;
            // 
            // SDT
            // 
            this.SDT.HeaderText = "Điện thoại";
            this.SDT.Name = "SDT";
            this.SDT.Width = 120;
            // 
            // email
            // 
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.Width = 130;
            // 
            // MatKhau
            // 
            this.MatKhau.HeaderText = "Mật khẩu";
            this.MatKhau.Name = "MatKhau";
            // 
            // TichDiem
            // 
            this.TichDiem.HeaderText = "Tích điểm";
            this.TichDiem.Name = "TichDiem";
            // 
            // UC_DanhMucKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_DanhMucKhachHang";
            this.Size = new System.Drawing.Size(1100, 760);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.gbTKKhach.ResumeLayout(false);
            this.gbTKKhach.PerformLayout();
            this.gbChucNang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox gbTKKhach;
        private System.Windows.Forms.Button btnTK;
        private System.Windows.Forms.TextBox txtTKKhach;
        private System.Windows.Forms.GroupBox gbChucNang;
        private System.Windows.Forms.Button btnSuaKhachHang;
        private System.Windows.Forms.Button btnXoaKhachHang;
        private System.Windows.Forms.Button btnInExc;
        private System.Windows.Forms.Button btnTaoKhachHang;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatKhau;
        private System.Windows.Forms.DataGridViewTextBoxColumn TichDiem;
    }
}
