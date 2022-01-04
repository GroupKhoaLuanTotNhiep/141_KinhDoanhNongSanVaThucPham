using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class frmBieuDoDoanhThu : Form
    {
        public frmBieuDoDoanhThu()
        {
            InitializeComponent();
        }

        internal class DoanhThu
        {
            public DateTime NgayLap { get; set; }
            public decimal TongTien { get; set; }
        }

        public DataTable dt { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        private List<DoanhThu> dsDoanhThu = new List<DoanhThu>();

        private void LoadDoanhThu()
        {
            dsDoanhThu.Clear();
            foreach (DataRow item in dt.Rows)
            {
                var ngayLap = (DateTime)item["NgayLap"];
                if (ngayLap == null) continue;
                var y = item["TienHang_tt"];
                var x = ngayLap;
                dsDoanhThu.Add(new DoanhThu
                {
                    NgayLap = ngayLap,
                    TongTien = decimal.Parse(y.ToString())
                });
            }
        }

        private void radNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (radNgay.Checked == false) return;
            LoadChartByDaily();
        }

        private void radThang_CheckedChanged(object sender, EventArgs e)
        {
            if (radThang.Checked == false) return;
            LoadChartByMonthly();
        }

        private void radNam_CheckedChanged(object sender, EventArgs e)
        {
            if (radNam.Checked == false) return;
            LoadChartByYearly();
        }

        private void frmBieuDoDoanhThu_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDoanhThu();
                LoadChartByDaily();
            }
            catch { }
        }

        private void LoadChartByDaily()
        {
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();
            cartesianChart1.Series.Clear();
            var dateNow = DateTime.Now;
            var numberDay = DateTime.DaysInMonth(dateNow.Year, dateNow.Month);
            var days = new List<int>();
            for (int i = 1; i <= numberDay; i++)
            {
                days.Add(i);
            }

            var labels = days.Select(i => i + "/" + dateNow.Month + "/" + dateNow.Year).ToArray();
            cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Day",
                Labels = labels,
                Separator = new LiveCharts.Wpf.Separator()
                {
                    Step = 1.0,
                    IsEnabled = false
                },
                LabelsRotation = 45,
                Margin = new Thickness(0, 0, 0, 20)
            });
            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Revenue",
                LabelFormatter = value => value.ToString("C"),
                Separator = new LiveCharts.Wpf.Separator()
                {
                    Step = 5000000,
                    IsEnabled = false
                },
                MinValue = 0
            });
            cartesianChart1.LegendLocation = LegendLocation.Right;

            SeriesCollection series = new SeriesCollection();
            var values = new List<decimal>();
            foreach (var day in days)
            {
                var x = (from o in dsDoanhThu
                         where o.NgayLap.Day.Equals(day) && o.NgayLap.Month.Equals(dateNow.Month) && o.NgayLap.Year.Equals(dateNow.Year)
                         select o.TongTien).ToList();
                values.Add(x.Sum(o => o));
            }
            series.Add(new LineSeries() { Title = "Doanh thu", Values = new ChartValues<decimal>(values) });
            cartesianChart1.Series = series;
        }

        private void LoadChartByMonthly()
        {
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();
            cartesianChart1.Series.Clear();
            cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Month",
                Separator = new LiveCharts.Wpf.Separator()
                {
                    Step = 1.0,
                    IsEnabled = false
                },
                Labels = new[] { "Jan", "Feb", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }
            });
            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Revenue",
                LabelFormatter = value => value.ToString("C"),
                Separator = new LiveCharts.Wpf.Separator()
                {
                    Step = 5000000,
                    IsEnabled = false
                },
                MinValue = 0
            });
            cartesianChart1.LegendLocation = LegendLocation.Right;

            SeriesCollection series = new SeriesCollection();
            var years = (from o in dsDoanhThu
                         select new { Year = o.NgayLap.Year }).Distinct();
            foreach (var year in years)
            {
                List<decimal> values = new List<decimal>();
                for (int month = 1; month <= 12; month++)
                {
                    decimal value = 0;
                    var data = from o in dsDoanhThu
                               where o.NgayLap.Year.Equals(year.Year) && o.NgayLap.Month.Equals(month)
                               orderby o.NgayLap.Month ascending
                               select new { o.TongTien };
                    value = data.Sum(x => x.TongTien);
                    values.Add(value);
                }
                series.Add(new LineSeries() { Title = year.Year.ToString(), Values = new ChartValues<decimal>(values) });
            }

            cartesianChart1.Series = series;
        }

        private void LoadChartByYearly()
        {
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();
            cartesianChart1.Series.Clear();


            SeriesCollection series = new SeriesCollection();
            var years = (from o in dsDoanhThu
                         select new { Year = o.NgayLap.Year }).Distinct();
            if (!years.Any()) return;
            cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Year",
                Labels = years.Select(x => x.Year.ToString()).ToArray(),
                Separator = new LiveCharts.Wpf.Separator()
                {
                    Step = 1.0,
                    IsEnabled = false
                },
            });
            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Revenue",
                LabelFormatter = value => value.ToString("C"),
                Separator = new LiveCharts.Wpf.Separator()
                {
                    Step = 5000000,
                    IsEnabled = false
                },
                MinValue = 0
            });
            cartesianChart1.LegendLocation = LegendLocation.Right;
            List<decimal> values = new List<decimal>();
            foreach (var year in years)
            {

                decimal value = 0;
                var data = from o in dsDoanhThu
                           where o.NgayLap.Year.Equals(year.Year)
                           orderby o.NgayLap.Month ascending
                           select new { o.TongTien };
                value = data.Sum(x => x.TongTien);
                values.Add(value);

            }
            series.Add(new LineSeries() { Title = "Doanh thu", Values = new ChartValues<decimal>(values) });
            cartesianChart1.Series = series;
        }
    }
}