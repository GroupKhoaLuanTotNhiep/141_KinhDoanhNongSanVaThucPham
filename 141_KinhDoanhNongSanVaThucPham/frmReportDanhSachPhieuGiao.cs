using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class frmReportDanhSachPhieuGiao : Form
    {
        public frmReportDanhSachPhieuGiao()
        {
            InitializeComponent();

            rptCacPhieuGiaoHang phieuGiao = new rptCacPhieuGiaoHang();

            crystalReportViewer1.ReportSource = phieuGiao;
            //crystalReportViewer1.DisplayStatusBar = false;
            //crystalReportViewer1.DisplayToolbar = true;
            crystalReportViewer1.Refresh();
        }
    }
}
