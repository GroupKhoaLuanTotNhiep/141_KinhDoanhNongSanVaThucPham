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
    public partial class frmReportPhieuGiaoHang : Form
    {
        Connection conn = new Connection();

        public frmReportPhieuGiaoHang(string mapg)
        {
            InitializeComponent();

            rptPhieuGiaoHang rpt = new rptPhieuGiaoHang();
            //Dùng quyền Windows
            //rpt.SetDatabaseLogon("", "", db.strServerName, db.strDBName);

            //Dùng quyền SQL Server
            rpt.SetDatabaseLogon(conn.strUserID, conn.strPassword, conn.strServerName, conn.strDBName);

            ParameterFieldDefinitions pfds = rpt.DataDefinition.ParameterFields;
            ParameterFieldDefinition pfdMaPGH = pfds["pMaPGH"];
            ParameterDiscreteValue pfdv = new ParameterDiscreteValue();
            pfdv.Value = mapg;
            pfdMaPGH.CurrentValues.Clear();
            pfdMaPGH.CurrentValues.Add(pfdv);
            pfdMaPGH.ApplyCurrentValues(pfdMaPGH.CurrentValues);

            crystalReportViewer1.ReportSource = rpt;
            //crystalReportViewer1.DisplayStatusBar = false;
            //crystalReportViewer1.DisplayToolbar = true;
            crystalReportViewer1.Refresh();
        }
    }
}
