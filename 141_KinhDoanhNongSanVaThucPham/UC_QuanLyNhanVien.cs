using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using NongSanThucPham;
using DBConnect;
using System.IO;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class UC_QuanLyNhanVien : UserControl
    {
        Connection conn = new Connection();
        NhanVien nhanVien = new NhanVien();
        string paths = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);
        //SqlDataAdapter da_NhanVien;
        //DataSet ds_NhanVien;

        public UC_QuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void btnThemTK_Click(object sender, EventArgs e)
        {
            frmThemTaiKhoanNhanVien themTaiKhoan = new frmThemTaiKhoanNhanVien();
            themTaiKhoan.ShowDialog();
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            frmChamCong chamCong = new frmChamCong();
            chamCong.ShowDialog();
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            frmTinhLuong tinhLuong = new frmTinhLuong();
            tinhLuong.ShowDialog();
        }

        void createTable_NhanVien()
        {
            //da_NhanVien = new SqlDataAdapter("Select * From NhanVien", conn.conn);
            //ds_NhanVien = new DataSet();
            //da_NhanVien.Fill(ds_NhanVien, "NhanVien");
            //DataColumn[] key = new DataColumn[1];
            //key[0] = ds_NhanVien.Tables["NhanVien"].Columns[0];
            //ds_NhanVien.Tables["NhanVien"].PrimaryKey = key;
            //dataGV_NhanVien.DataSource = ds_NhanVien.Tables["NhanVien"];
            //dataGV_NhanVien.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGV_NhanVien.DataSource = nhanVien.loadDataGV_NhanVien();
            dataGV_NhanVien.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        void loadComboBoxChucVu()
        {
            cboChucVu.DataSource = nhanVien.loadChucVu();
            cboChucVu.DisplayMember = "TenChucVu";
            cboChucVu.ValueMember = "MaChucVu";
        }

        private void loadLaiData()
        {
            string loadLaiDuLieu = "Select * From NhanVien";
            dataGV_NhanVien.DataSource = conn.LoadData(loadLaiDuLieu);
        }

        private void dataGV_NhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaNV.Text = dataGV_NhanVien.Rows[index].Cells[0].Value.ToString();
            txtTenNV.Text = dataGV_NhanVien.Rows[index].Cells[1].Value.ToString();
            if (dataGV_NhanVien.Rows[index].Cells[2].Value.ToString() == "Nam")
            {
                radNam.Checked = true;
                radNu.Checked = false;
            }
            else
            {
                radNam.Checked = false;
                radNu.Checked = true;
            }
            txtNgaySinh.Text = dataGV_NhanVien.CurrentRow.Cells[3].Value.ToString();
            txtDiaChi.Text = dataGV_NhanVien.Rows[index].Cells[4].Value.ToString();
            txtDienThoai.Text = dataGV_NhanVien.Rows[index].Cells[5].Value.ToString();
            txtEmail.Text = dataGV_NhanVien.Rows[index].Cells[6].Value.ToString();
            cboChucVu.Text = dataGV_NhanVien.Rows[index].Cells[7].Value.ToString();
            txtHinhNV.Text = dataGV_NhanVien.Rows[index].Cells[8].Value.ToString();
            try
            {
                if (txtHinhNV.Text != " " && txtHinhNV.Text != "" && txtHinhNV.Text != null)
                {
                    string url = paths + "\\image\\" + txtHinhNV.Text;
                    pictureBoxNhanVien.Image = System.Drawing.Image.FromFile(url);
                    FileStream fs = new FileStream(url, FileMode.Open, FileAccess.Read);
                    pictureBoxNhanVien.Image = System.Drawing.Image.FromStream(fs);
                    fs.Close();
                }
                else
                {
                    pictureBoxNhanVien.Image = System.Drawing.Image.FromFile(paths + "\\image\\anhavatar.png");
                }
            }
            catch
            {
                pictureBoxNhanVien.Image = System.Drawing.Image.FromFile(paths + "\\image\\anhavatar.png");
            }
            txtMaNV.Enabled = true;
            btnSuaNV.Enabled = btnXoaNV.Enabled = true;
        }

        private void UC_QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            createTable_NhanVien();
            loadComboBoxChucVu();
            txtMaNV.Enabled = false;
            radNam.Checked = true;
            btnLuuNV.Enabled = btnSuaNV.Enabled = btnXoaNV.Enabled = false;
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtMaNV.Enabled = true;
            txtMaNV.Clear();
            txtTenNV.Clear();
            cboChucVu.Text = "";
            radNam.Checked = true;
            txtNgaySinh.Text = "";
            txtDiaChi.Clear();
            txtDienThoai.Clear();
            txtEmail.Clear();
            txtHinhNV.Clear();
            pictureBoxNhanVien.Image = System.Drawing.Image.FromFile(paths + "\\image\\anhavatar.png");
            btnLuuNV.Enabled = true;
            btnSuaNV.Enabled = btnXoaNV.Enabled = false;
        }

        private void btnLuuNV_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaNV = txtMaNV.Text.Trim();
                string strTenNV = txtTenNV.Text.Trim();
                string strChucVu = cboChucVu.SelectedValue.ToString().Trim();
                string strNgaySinh = DateTime.ParseExact(txtNgaySinh.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
                string strDiaChi = txtDiaChi.Text.Trim();
                string strDienThoai = txtDienThoai.Text.Trim();
                string strEmail = txtEmail.Text.Trim();
                string strHinhNV = txtHinhNV.Text.Trim();
                if (strTenNV != string.Empty && strChucVu != string.Empty && strNgaySinh != string.Empty && strDiaChi != string.Empty && strDienThoai != string.Empty)
                {
                    if (conn.checkExist("NhanVien", "MaNV", strMaNV))
                    {
                        MessageBox.Show("Mã nhân viên " + strMaNV + " này đã tồn tại!");
                        return;
                    }
                    if (!conn.checkExist("ChucVu", "MaChucVu", strChucVu))
                    {
                        MessageBox.Show("Chức vụ này chưa tồn tại, nên không thể thêm được!");
                        return;
                    }
                    if ((DateTime.Now.Year - DateTime.Parse(strNgaySinh).Year) < 18)
                    {
                        MessageBox.Show("Bạn chưa đủ tuổi hoặc dữ liệu nhập không đúng!");
                        return;
                    }
                    if(strEmail != string.Empty)
                    {
                        if (!conn.isEmail(strEmail))
                        {
                            MessageBox.Show("Email " + strEmail + " này không hợp lệ!");
                            return;
                        }
                    }
                    string strSQL = "INSERT NhanVien VALUES(N'" + null;
                    if (strTenNV != "")
                        strSQL = "INSERT NhanVien VALUES(N'" + strTenNV + "'";
                    if (radNam.Checked)
                        strSQL += ", N'" + radNam.Text + "'";
                    else
                        strSQL += ", N'" + radNu.Text + "'";
                    if (strNgaySinh != "")
                        strSQL += ", '" + strNgaySinh + "'";
                    if (strDiaChi != "")
                        strSQL += ", N'" + strDiaChi + "'";
                    if (strDienThoai != "")
                        strSQL += ", '" + strDienThoai + "'";
                    if (strEmail != "" || strEmail == "")
                        strSQL += ", '" + strEmail + "'";
                    if (strChucVu != "")
                        strSQL += ", '" + strChucVu + "'";
                    if (strHinhNV != "" || strHinhNV == "")
                        strSQL += ", '" + strHinhNV + "')";
                    conn.updateToDatabase(strSQL);
                    loadLaiData();
                    MessageBox.Show("Lưu nhân viên thành công!");
                    txtMaNV.Enabled = false;
                }
                else
                    MessageBox.Show("Bạn chưa nhập đủ thông tin yêu cầu");
            }
            catch
            {
                MessageBox.Show("Lưu nhân viên thất bại!");
            }
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaNV = txtMaNV.Text.Trim();
                string strTenNV = txtTenNV.Text.Trim();
                string strChucVu = cboChucVu.SelectedValue.ToString().Trim();
                string strNgaySinh = DateTime.ParseExact(txtNgaySinh.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
                string strDiaChi = txtDiaChi.Text.Trim();
                string strDienThoai = txtDienThoai.Text.Trim();
                string strEmail = txtEmail.Text.Trim();
                string strHinhNV = txtHinhNV.Text.Trim();
                if (strMaNV != string.Empty && strTenNV != string.Empty && strChucVu != string.Empty && strDienThoai != string.Empty)
                {
                    if (!conn.checkExist("NhanVien", "MaNV", strMaNV))
                    {
                        MessageBox.Show("Mã nhân viên '" + strMaNV + "' này chưa tồn tại, nên không thể sửa!");
                        return;
                    }
                    if (!conn.checkExist("ChucVu", "MaChucVu", strChucVu))
                    {
                        MessageBox.Show("Chức vụ này chưa tồn tại, nên không thể sửa được!");
                        return;
                    }
                    if ((DateTime.Now.Year - DateTime.Parse(strNgaySinh).Year) < 18)
                    {
                        MessageBox.Show("Bạn chưa đủ tuổi hoặc dữ liệu nhập không đúng!");
                        return;
                    }
                    if (strEmail != string.Empty)
                    {
                        if (!conn.isEmail(strEmail))
                        {
                            MessageBox.Show("Email " + strEmail + " này không hợp lệ!");
                            return;
                        }
                    }
                    string strSQL = "UPDATE NhanVien SET TenNV=N'" + null;
                    if (strTenNV != "")
                        strSQL = "UPDATE NhanVien SET TenNV=N'" + strTenNV + "'";
                    if (radNam.Checked)
                        strSQL += ", GioiTinh=N'" + radNam.Text + "'";
                    else
                        strSQL += ", GioiTinh=N'" + radNu.Text + "'";
                    if (strNgaySinh != "")
                        strSQL += ", NgaySinh='" + strNgaySinh + "'";
                    if (strDiaChi != "")
                        strSQL += ", DiaChi=N'" + strDiaChi + "'";
                    if (strDienThoai != "")
                        strSQL += ", DienThoai='" + strDienThoai + "'";
                    if (strEmail != "" || strEmail == "")
                        strSQL += ", Email='" + strEmail + "'";
                    if (strChucVu != "")
                        strSQL += ", MaChucVu='" + strChucVu + "'";
                    if (strHinhNV != "" || strHinhNV == "")
                        strSQL += ", HinhNV='" + strHinhNV + "'";
                    strSQL += " WHERE MaNV='" + strMaNV + "'";
                    conn.updateToDatabase(strSQL);
                    loadLaiData();
                    MessageBox.Show("Cập nhật nhân viên thành công!");
                }
                else
                    MessageBox.Show("Bạn chưa nhập đủ thông tin yêu cầu");
            }
            catch
            {
                MessageBox.Show("Cập nhật nhân viên thất bại!");
            }
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaNV = txtMaNV.Text.Trim();
                if (strMaNV != string.Empty)
                {
                    if (!conn.checkExist("NhanVien", "MaNV", strMaNV))
                    {
                        MessageBox.Show("Không có mã '" + strMaNV + "' này để xóa!");
                        return;
                    }
                    if (MessageBox.Show("Bạn có thật sự muốn xóa nhân viên này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        return;
                    string strSQL = "DELETE NhanVien WHERE MaNV ='" + strMaNV + "'";
                    conn.updateToDatabase(strSQL);
                    MessageBox.Show("Xóa nhân viên thành công!");
                    loadLaiData();
                }
                else
                    MessageBox.Show("Bạn chưa nhập mã nhân viên cần xóa");
            }
            catch
            {
                MessageBox.Show("Xóa nhân viên thất bại (Có thể nhân viên này đang tồn tại ở bảng khác)!");
            }
        }

        private void pictureBoxNhanVien_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "D:\\";
            open.Filter = "Image File (*.jpg)|*.jpg|All File (*.*)|*.*";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string name = System.IO.Path.GetFileName(open.FileName);
                string luu = paths + "\\image\\" + name;
                try
                {
                    FileStream fs = new FileStream(open.FileName, FileMode.Open, FileAccess.Read);
                    System.IO.File.Copy(open.FileName, luu);
                    MessageBox.Show("Upload file ảnh thành công", "Thông báo");
                    txtHinhNV.Text = name;
                    //pictureBoxSanPham.Image = Image.FromFile(luu);
                    pictureBoxNhanVien.Image = System.Drawing.Image.FromStream(fs);
                    //pictureBoxSanPham.ImageLocation = open.FileName;
                    fs.Close();
                }
                catch
                {
                    MessageBox.Show("Hình ảnh đã tồn tại hoặc trùng tên, vui lòng kiểm tra lại");
                }
            }
        }
    }
}
