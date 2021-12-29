using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DBConnect;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class frmReportHoaDonBanHang : Form
    {
        Connection conn = new Connection();

        public frmReportHoaDonBanHang(string mahd)
        {
            InitializeComponent();

            rptHDBanHang rpt = new rptHDBanHang();
            //Dùng quyền Windows
            //rpt.SetDatabaseLogon("", "", db.strServerName, db.strDBName);

            //Dùng quyền SQL Server
            rpt.SetDatabaseLogon(conn.strUserID, conn.strPassword, conn.strServerName, conn.strDBName);

            ParameterFieldDefinitions pfds = rpt.DataDefinition.ParameterFields;
            ParameterFieldDefinition pfdMaHD = pfds["pMaHoaDon"];
            ParameterDiscreteValue pfdv = new ParameterDiscreteValue();
            pfdv.Value = mahd;
            pfdMaHD.CurrentValues.Clear();
            pfdMaHD.CurrentValues.Add(pfdv);
            pfdMaHD.ApplyCurrentValues(pfdMaHD.CurrentValues);

            crystalReportViewer1.ReportSource = rpt;
            //crystalReportViewer1.DisplayStatusBar = false;
            //crystalReportViewer1.DisplayToolbar = true;
            crystalReportViewer1.Refresh();
        }
    }
}
