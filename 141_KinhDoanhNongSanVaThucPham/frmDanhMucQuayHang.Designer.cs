namespace _141_KinhDoanhNongSanVaThucPham
{
    partial class frmDanhMucQuayHang
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
            this.lblQuay = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.gbTKQuay = new System.Windows.Forms.GroupBox();
            this.btnTKQuay = new System.Windows.Forms.Button();
            this.txtTKQuay = new System.Windows.Forms.TextBox();
            this.gbChucnang = new System.Windows.Forms.GroupBox();
            this.btnXoaQuay = new System.Windows.Forms.Button();
            this.btnSuaQuay = new System.Windows.Forms.Button();
            this.btnInExc = new System.Windows.Forms.Button();
            this.btnTaoQuay = new System.Windows.Forms.Button();
            this.dataGV_QuayHang = new System.Windows.Forms.DataGridView();
            this.MaQuay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenQuay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gbTKQuay.SuspendLayout();
            this.gbChucnang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_QuayHang)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblQuay, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGV_QuayHang, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(846, 670);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblQuay
            // 
            this.lblQuay.AutoSize = true;
            this.lblQuay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQuay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblQuay.Location = new System.Drawing.Point(3, 0);
            this.lblQuay.Name = "lblQuay";
            this.lblQuay.Size = new System.Drawing.Size(840, 67);
            this.lblQuay.TabIndex = 0;
            this.lblQuay.Text = "DANH MỤC QUẦY HÀNG";
            this.lblQuay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.tableLayoutPanel2.Controls.Add(this.gbTKQuay, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.gbChucnang, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 70);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(840, 161);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // gbTKQuay
            // 
            this.gbTKQuay.Controls.Add(this.btnTKQuay);
            this.gbTKQuay.Controls.Add(this.txtTKQuay);
            this.gbTKQuay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTKQuay.Location = new System.Drawing.Point(3, 3);
            this.gbTKQuay.Name = "gbTKQuay";
            this.gbTKQuay.Size = new System.Drawing.Size(367, 155);
            this.gbTKQuay.TabIndex = 0;
            this.gbTKQuay.TabStop = false;
            this.gbTKQuay.Text = "Tìm kiếm quầy hàng";
            // 
            // btnTKQuay
            // 
            this.btnTKQuay.Location = new System.Drawing.Point(240, 62);
            this.btnTKQuay.Name = "btnTKQuay";
            this.btnTKQuay.Size = new System.Drawing.Size(93, 34);
            this.btnTKQuay.TabIndex = 1;
            this.btnTKQuay.Text = "Tìm kiếm";
            this.btnTKQuay.UseVisualStyleBackColor = true;
            // 
            // txtTKQuay
            // 
            this.txtTKQuay.Location = new System.Drawing.Point(34, 68);
            this.txtTKQuay.Name = "txtTKQuay";
            this.txtTKQuay.Size = new System.Drawing.Size(200, 22);
            this.txtTKQuay.TabIndex = 0;
            // 
            // gbChucnang
            // 
            this.gbChucnang.Controls.Add(this.btnXoaQuay);
            this.gbChucnang.Controls.Add(this.btnSuaQuay);
            this.gbChucnang.Controls.Add(this.btnInExc);
            this.gbChucnang.Controls.Add(this.btnTaoQuay);
            this.gbChucnang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbChucnang.Location = new System.Drawing.Point(376, 3);
            this.gbChucnang.Name = "gbChucnang";
            this.gbChucnang.Size = new System.Drawing.Size(461, 155);
            this.gbChucnang.TabIndex = 1;
            this.gbChucnang.TabStop = false;
            this.gbChucnang.Text = "Chức năng";
            // 
            // btnXoaQuay
            // 
            this.btnXoaQuay.Location = new System.Drawing.Point(44, 89);
            this.btnXoaQuay.Name = "btnXoaQuay";
            this.btnXoaQuay.Size = new System.Drawing.Size(110, 40);
            this.btnXoaQuay.TabIndex = 2;
            this.btnXoaQuay.Text = "Xóa quầy";
            this.btnXoaQuay.UseVisualStyleBackColor = true;
            // 
            // btnSuaQuay
            // 
            this.btnSuaQuay.Location = new System.Drawing.Point(207, 31);
            this.btnSuaQuay.Name = "btnSuaQuay";
            this.btnSuaQuay.Size = new System.Drawing.Size(110, 40);
            this.btnSuaQuay.TabIndex = 1;
            this.btnSuaQuay.Text = "Sửa quầy";
            this.btnSuaQuay.UseVisualStyleBackColor = true;
            // 
            // btnInExc
            // 
            this.btnInExc.Location = new System.Drawing.Point(227, 89);
            this.btnInExc.Name = "btnInExc";
            this.btnInExc.Size = new System.Drawing.Size(90, 40);
            this.btnInExc.TabIndex = 3;
            this.btnInExc.Text = "In Excel";
            this.btnInExc.UseVisualStyleBackColor = true;
            // 
            // btnTaoQuay
            // 
            this.btnTaoQuay.Location = new System.Drawing.Point(44, 31);
            this.btnTaoQuay.Name = "btnTaoQuay";
            this.btnTaoQuay.Size = new System.Drawing.Size(110, 40);
            this.btnTaoQuay.TabIndex = 0;
            this.btnTaoQuay.Text = "Tạo quầy";
            this.btnTaoQuay.UseVisualStyleBackColor = true;
            // 
            // dataGV_QuayHang
            // 
            this.dataGV_QuayHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV_QuayHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaQuay,
            this.TenQuay});
            this.dataGV_QuayHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGV_QuayHang.Location = new System.Drawing.Point(3, 237);
            this.dataGV_QuayHang.Name = "dataGV_QuayHang";
            this.dataGV_QuayHang.RowTemplate.Height = 24;
            this.dataGV_QuayHang.Size = new System.Drawing.Size(840, 430);
            this.dataGV_QuayHang.TabIndex = 2;
            // 
            // MaQuay
            // 
            this.MaQuay.HeaderText = "Mã quầy hàng";
            this.MaQuay.Name = "MaQuay";
            // 
            // TenQuay
            // 
            this.TenQuay.HeaderText = "Tên quầy hàng";
            this.TenQuay.Name = "TenQuay";
            this.TenQuay.Width = 150;
            // 
            // frmDoanhMucQuayHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 670);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmDoanhMucQuayHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doanh mục quầy hàng";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.gbTKQuay.ResumeLayout(false);
            this.gbTKQuay.PerformLayout();
            this.gbChucnang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_QuayHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblQuay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox gbTKQuay;
        private System.Windows.Forms.Button btnTKQuay;
        private System.Windows.Forms.TextBox txtTKQuay;
        private System.Windows.Forms.GroupBox gbChucnang;
        private System.Windows.Forms.Button btnInExc;
        private System.Windows.Forms.Button btnTaoQuay;
        private System.Windows.Forms.DataGridView dataGV_QuayHang;
        private System.Windows.Forms.Button btnXoaQuay;
        private System.Windows.Forms.Button btnSuaQuay;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaQuay;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenQuay;
    }
}