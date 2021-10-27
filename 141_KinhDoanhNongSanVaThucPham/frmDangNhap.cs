using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

<<<<<<< HEAD
=======
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmDangNhap_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(151, 202, 219), 1);
            Rectangle area = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush lgb = new LinearGradientBrush(area, Color.FromArgb(151, 202, 219), Color.FromArgb(214, 232, 238), LinearGradientMode.ForwardDiagonal);
            graphics.FillRectangle(lgb, area);
            graphics.DrawRectangle(pen, area);
        }
>>>>>>> 647650fb822a68f58dbef12db88b8f76788537b3
    }
}
