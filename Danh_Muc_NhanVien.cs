using QL_cua_hang_tien_loi.BusinessLayer;
using QL_cua_hang_tien_loi.DataLayer;
using QL_cua_hang_tien_loi.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QL_cua_hang_tien_loi
{
    public partial class Danh_Muc_NhanVien : Form
    {
        public Danh_Muc_NhanVien()
        {
            InitializeComponent();
        }

        DataAccess da = new DataAccess();
        BoPhanBLL bllBoPhan = new BoPhanBLL();
        ChucVuBLL bllChucVu = new ChucVuBLL();
        NhanVienBLL bllNhanVien = new NhanVienBLL();

        BoPhan pb = new BoPhan();
        ChucVu cv;
        NhanVien nv;

        private void GetDataBoPhan()
        {
            BoPhan bp = new BoPhan();
            bp.MaBoPhan = txtMaBoPhan.Text;
            bp.TenBoPhan = txtTenBoPhan.Text;
        }

        private void GetDataChucVu()
        {
            cv = new ChucVu();
            cv.MaCV = txtMaCV.Text;
            cv.TenCV = txtTenCV.Text;
            cv.MaBoPhan = comboBoPhan.SelectedValue.ToString();
        }
        
        private void GetDataNhanVien()
        {
            nv = new NhanVien();
            nv.MaNV = txtMaNV.Text;
            nv.MaCV = comboChucVu.SelectedValue.ToString();
            nv.TenNV = txtTenNV.Text;
            nv.DiaChi = txtDiaChi.Text;
            nv.SDT = txtSDT.Text;
            nv.SoCMND = txtSoCMND.Text;
            nv.SoTaiKhoan = txtSoTaiKhoan.Text;
            nv.NgaySinh = dtp_NgaySinh.Value;
            nv.GioiTinh = comboGioiTinh.Text;
            nv.TrangThai = comboTrangThai.Text;
        }

        private void dgv_BoPhan_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            txtMaBoPhan.Text = dgv_BoPhan.Rows[row].Cells["MaBoPhan"].Value.ToString();
            txtTenBoPhan.Text = dgv_BoPhan.Rows[row].Cells["TenBoPhan"].Value.ToString();
        }

        private void dgv_ChucVu_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            txtMaCV.Text = dgv_ChucVu.Rows[row].Cells["MaCV"].Value.ToString();
            txtTenCV.Text = dgv_ChucVu.Rows[row].Cells["TenCV"].Value.ToString();
            comboBoPhan.Text = dgv_ChucVu.Rows[row].Cells["TenBoPhan1"].Value.ToString();
        }

        private void dgv_NhanVien_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            txtMaNV.Text = dgv_NhanVien.Rows[row].Cells["MaNV"].Value.ToString();
            txtTenNV.Text = dgv_NhanVien.Rows[row].Cells["TenNV"].Value.ToString();
            txtDiaChi.Text = dgv_NhanVien.Rows[row].Cells["DiaChi"].Value.ToString();
            txtSDT.Text = dgv_NhanVien.Rows[row].Cells["SDT"].Value.ToString();
            txtSoCMND.Text = dgv_NhanVien.Rows[row].Cells["SoCMND"].Value.ToString();
            txtSoTaiKhoan.Text = dgv_NhanVien.Rows[row].Cells["SoTaiKhoan"].Value.ToString();
            comboChucVu.Text = dgv_NhanVien.Rows[row].Cells["TenCV1"].Value.ToString();
            dtp_NgaySinh.Text = dgv_NhanVien.Rows[row].Cells["NgaySinh"].Value.ToString();
            comboGioiTinh.Text = dgv_NhanVien.Rows[row].Cells["GioiTinh"].Value.ToString();
            comboTrangThai.Text = dgv_NhanVien.Rows[row].Cells["TrangThai"].Value.ToString();
        }

        public void AutoIdNhanVien()
        {
            NhanVienBLL nvBll = new NhanVienBLL();
            string manv = nvBll.GetMaxNhanVienID();
            int dem;
            int.TryParse(manv, out dem);
            dem = dem + 1;
            txtMaNV.Text = string.Format("{0:00000}", dem);
        }

        private void comboChucVu_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboChucVu.SelectedValue != null)
            {
                if (bllChucVu.GetChucVuById(comboChucVu.SelectedValue.ToString()).Rows.Count > 0)
                {
                    txtBoPhan.Text = bllChucVu.GetChucVuById(comboChucVu.SelectedValue.ToString()).Rows[0]["TenBoPhan"].ToString();
                }
            }
        }

        private void Danh_Muc_NhanVien_Load(object sender, EventArgs e)
        {
            //Bo Phan
            dgv_BoPhan.DataSource = bllBoPhan.GetListBoPhan();
            
            //ChucVu
            dgv_ChucVu.DataSource = bllChucVu.GetListChucVu();
            comboBoPhan.DataSource = bllBoPhan.GetListBoPhan();
            comboBoPhan.DisplayMember = "TenBoPhan";
            comboBoPhan.ValueMember = "MaBoPhan";

            //NhanVien
            dgv_NhanVien.DataSource = bllNhanVien.GetListNhanVien();
            comboChucVu.DataSource = bllChucVu.GetListChucVu();
            comboChucVu.DisplayMember = "TenCV";
            comboChucVu.ValueMember = "MaCV";
            comboGioiTinh.Text = "Nam";
            comboTrangThai.Text = "Sẵn sàng";
            AutoIdNhanVien();
        }

        //BoPhan
        private void btnOK_BoPhan_Click(object sender, EventArgs e)
        {
            if (rdoThem.Checked == true)
            {
                BoPhan bp = new BoPhan(txtMaBoPhan.Text, txtTenBoPhan.Text);
                bllBoPhan.Insert(bp);
                dgv_BoPhan.DataSource = bllBoPhan.GetListBoPhan();
            }
            if (rdoXoa.Checked == true)
            {
                BoPhan bp = new BoPhan(txtMaBoPhan.Text, txtTenBoPhan.Text);
                bllBoPhan.Delete(bp);
                dgv_BoPhan.DataSource = bllBoPhan.GetListBoPhan();
            }
            if (rdoSua.Checked == true)
            {
                BoPhan bp = new BoPhan(txtMaBoPhan.Text, txtTenBoPhan.Text);
                bllBoPhan.Update(bp);
                dgv_BoPhan.DataSource = bllBoPhan.GetListBoPhan();
            }
            if (rdoTimKiem.Checked == true)
            {
                if (ckbMaBoPhan.Checked == true || ckbTenBoPhan.Checked == true)
                {
                    BoPhan bp = new BoPhan(txtMaBoPhan.Text, txtTenBoPhan.Text);
                    dgv_BoPhan.DataSource = bllBoPhan.Search(bp, ckbMaBoPhan.Checked, ckbTenBoPhan.Checked);
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn tiêu chí tìm kiếm", "Thông báo");
                }
            }

            btnCLR_BoPhan_Click(sender, e);
        }

        private void btnCLR_BoPhan_Click(object sender, EventArgs e)
        {
            txtMaBoPhan.Text = "";
            txtTenBoPhan.Text = "";
            txtMaBoPhan.Focus();
        }

        //ChucVu
        private void btnOK_ChucVu_Click(object sender, EventArgs e)
        {
            GetDataChucVu();
            if (rdInsertCV.Checked == true)
            {
                bllChucVu.Insert(cv);
                dgv_ChucVu.DataSource = bllChucVu.GetListChucVu();
            }
            if (rdDeleteCV.Checked == true)
            {
                bllChucVu.Delete(cv);
                dgv_ChucVu.DataSource = bllChucVu.GetListChucVu();
            }
            if (rdUpdateCV.Checked == true)
            {
                bllChucVu.Update(cv);
                dgv_ChucVu.DataSource = bllChucVu.GetListChucVu();
            }
            if (rdSearchCV.Checked == true)
            {
                dgv_ChucVu.DataSource = bllChucVu.Search(cv);
            }
            btnCLR_ChucVu_Click(sender, e);
        }

        private void btnCLR_ChucVu_Click(object sender, EventArgs e)
        {
            txtMaCV.Text = "";
            txtTenCV.Text = "";
            txtMaCV.Focus();
        }

        //NhanVien
        private void rdSearchNV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdSearchNV.Checked == true)
            {
                txtMaNV.ReadOnly = false;
            }
            else
            {
                txtMaNV.ReadOnly = true;
            }
        }

        private void btnOK_NhanVien_Click(object sender, EventArgs e)
        {
            GetDataNhanVien();

            if (rdInsertNV.Checked == true)
            {
                bllNhanVien.Insert(nv);
                dgv_NhanVien.DataSource = bllNhanVien.GetListNhanVien();
            }
            if (rdUpdateNV.Checked == true)
            {
                bllNhanVien.Update(nv);
                dgv_NhanVien.DataSource = bllNhanVien.GetListNhanVien();
            }
            if (rdDeleteNV.Checked == true)
            {
                bllNhanVien.Delete(nv);
                dgv_NhanVien.DataSource = bllNhanVien.GetListNhanVien();
            }
            if (rdSearchNV.Checked == true)
            {
                if (searchChucVu.Checked == true)
                {
                    nv.MaCV = comboChucVu.SelectedValue.ToString();
                }
                else
                    nv.MaCV = "";
                if (searchGioiTinh.Checked == true)
                {
                    nv.GioiTinh = comboGioiTinh.Text;
                }
                else nv.GioiTinh = "";
                if (searchTrangThai.Checked == true)
                {
                    nv.TrangThai = comboTrangThai.Text;
                }
                else
                    nv.TrangThai = "";
                if (searchNgaySinh.Checked == false)
                {
                    dgv_NhanVien.DataSource = bllNhanVien.Search(nv);
                }
                else
                    dgv_NhanVien.DataSource = bllNhanVien.SearchByDate(nv);
            }
            btnCLR_NhanVien_Click(sender, e);
        }

        private void btnCLR_NhanVien_Click(object sender, EventArgs e)
        {
            txtTenNV.Text = "";
            AutoIdNhanVien();
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtSoCMND.Text = "";
            txtSoTaiKhoan.Text = "";
            txtTenNV.Focus();
        }

        private void btnXuatEcxel_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int i = 0;
            int j = 0;
            for (int k = 1; k < dgv_NhanVien.Columns.Count + 1; k++)
            {

                xlWorkSheet.Cells[1, k] = dgv_NhanVien.Columns[k - 1].HeaderText;

            }
            for (i = 0; i <= dgv_NhanVien.RowCount - 1; i++)
            {
                for (j = 0; j <= dgv_NhanVien.ColumnCount - 1; j++)
                {
                    DataGridViewCell cell = dgv_NhanVien[j, i];
                    xlWorkSheet.Cells[i + 2, j + 1] = cell.Value;
                }
            }

            SaveFileDialog sdlg = new SaveFileDialog();
            sdlg.Filter = "Excel Files (*.xls)|*.xls;";
            if (sdlg.ShowDialog() == DialogResult.OK)
            {
                string filename = sdlg.FileName;

                xlWorkBook.SaveAs(filename, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                MessageBox.Show("You saved success!");
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
            }
        }






        private void danhMụcChứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void page_BoPhan_Click(object sender, EventArgs e)
        {

        }
    }
}
