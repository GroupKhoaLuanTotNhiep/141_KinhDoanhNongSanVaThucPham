namespace _141_KinhDoanhNongSanVaThucPham
{
    partial class frmThemQuayHang
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
            this.lblThemQuay = new System.Windows.Forms.Label();
            this.lblMaQuay = new System.Windows.Forms.Label();
            this.lblTenQuay = new System.Windows.Forms.Label();
            this.txtMaQuay = new System.Windows.Forms.TextBox();
            this.txtTenQuay = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.lblThemQuay, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblMaQuay, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTenQuay, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtMaQuay, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTenQuay, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(489, 250);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblThemQuay
            // 
            this.lblThemQuay.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblThemQuay, 3);
            this.lblThemQuay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblThemQuay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThemQuay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblThemQuay.Location = new System.Drawing.Point(51, 0);
            this.lblThemQuay.Name = "lblThemQuay";
            this.lblThemQuay.Size = new System.Drawing.Size(435, 50);
            this.lblThemQuay.TabIndex = 0;
            this.lblThemQuay.Text = "THÊM QUẦY HÀNG MỚI";
            this.lblThemQuay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMaQuay
            // 
            this.lblMaQuay.AutoSize = true;
            this.lblMaQuay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaQuay.Location = new System.Drawing.Point(51, 50);
            this.lblMaQuay.Name = "lblMaQuay";
            this.lblMaQuay.Size = new System.Drawing.Size(140, 62);
            this.lblMaQuay.TabIndex = 1;
            this.lblMaQuay.Text = "Mã quầy";
            this.lblMaQuay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTenQuay
            // 
            this.lblTenQuay.AutoSize = true;
            this.lblTenQuay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenQuay.Location = new System.Drawing.Point(51, 112);
            this.lblTenQuay.Name = "lblTenQuay";
            this.lblTenQuay.Size = new System.Drawing.Size(140, 62);
            this.lblTenQuay.TabIndex = 2;
            this.lblTenQuay.Text = "Tên quầy";
            this.lblTenQuay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMaQuay
            // 
            this.txtMaQuay.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtMaQuay.Location = new System.Drawing.Point(197, 67);
            this.txtMaQuay.Margin = new System.Windows.Forms.Padding(3, 3, 3, 18);
            this.txtMaQuay.Name = "txtMaQuay";
            this.txtMaQuay.Size = new System.Drawing.Size(238, 27);
            this.txtMaQuay.TabIndex = 3;
            // 
            // txtTenQuay
            // 
            this.txtTenQuay.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtTenQuay.Location = new System.Drawing.Point(197, 129);
            this.txtTenQuay.Margin = new System.Windows.Forms.Padding(3, 3, 3, 18);
            this.txtTenQuay.Name = "txtTenQuay";
            this.txtTenQuay.Size = new System.Drawing.Size(238, 27);
            this.txtTenQuay.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Controls.Add(this.btnLuu, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnThemMoi, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDong, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(51, 177);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(384, 70);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // btnLuu
            // 
            this.btnLuu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(3, 3);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(109, 40);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThemMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMoi.Location = new System.Drawing.Point(118, 3);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(147, 40);
            this.btnThemMoi.TabIndex = 1;
            this.btnThemMoi.Text = "Thêm mới";
            this.btnThemMoi.UseVisualStyleBackColor = true;
            // 
            // btnDong
            // 
            this.btnDong.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.Location = new System.Drawing.Point(271, 3);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 40);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // frmThemQuayHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 250);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmThemQuayHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "From Thêm mới quầy hàng";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblThemQuay;
        private System.Windows.Forms.Label lblMaQuay;
        private System.Windows.Forms.Label lblTenQuay;
        private System.Windows.Forms.TextBox txtMaQuay;
        private System.Windows.Forms.TextBox txtTenQuay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.Button btnDong;
    }
}