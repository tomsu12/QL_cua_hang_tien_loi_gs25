using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_cua_hang_tien_loi.BusinessLayer;
using QL_cua_hang_tien_loi.Entities;
using Excel = Microsoft.Office.Interop.Excel;

namespace QL_cua_hang_tien_loi
{
    public partial class frmDMKhachHang : Form
    {
        public frmDMKhachHang()
        {
            InitializeComponent();
        }
        KhachHang kh;
        KhachHangBLL bll = new KhachHangBLL();

        private void frmDMKhachHang_Load(object sender, EventArgs e)
        {
            GetAutoID();
            dataGridView1.DataSource = bll.GetListKhachHang();
            comboGioiTinh.Text = "Nam";
        }
        public void GetAutoID()
        {
            // NhaCCBLL  nccBll = new NhaCCBLL();
            string manKh = bll.GetMaxKhachHangID();
            int id;
            int.TryParse(manKh, out id);
            id = id + 1;
            txtMaKh.Text = string.Format("{0:00000}", id);
        }
        public void GetDataKhach()
        {
            kh = new KhachHang();
            kh.MaKhach = txtMaKh.Text;
            kh.TenKhach = txtTenKh.Text;
            kh.DiaChi = txtDiaChi.Text;
            kh.SoCMND = txtSoCMND.Text;
            kh.SoTaiKhoan = txtSoTaiKhoan.Text;
            kh.SDT = txtSDT.Text;
            kh.GioiTinh = comboGioiTinh.Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            GetDataKhach();
            if (rdoThem.Checked == true)
            {
                if (txtMaKh.Text != "")
                {
                    bll.Insert(kh);
                    dataGridView1.DataSource = bll.GetListKhachHang();
                    btnCLR_Click(sender, e);
                }
                else
                {
                    if (MessageBox.Show("Chưa nhập mã khách hàng.", "Thông báo", MessageBoxButtons.OK) == DialogResult.OK)
                        GetAutoID();
                }

            }
            if (rdoSua.Checked == true)
            {
                bll.Update(kh);
                dataGridView1.DataSource = bll.GetListKhachHang();
                btnCLR_Click(sender, e);
            }
            if (rdoXoa.Checked == true)
            {
                bll.Delete(kh);
                dataGridView1.DataSource = bll.GetListKhachHang();
                btnCLR_Click(sender, e);
            }
            if (rdoTimKiem.Checked == true)
            {
                dataGridView1.DataSource = bll.Search(kh);
            }

        }

        private void btnCLR_Click(object sender, EventArgs e)
        {
            GetAutoID();
            txtTenKh.Text = "";
            txtDiaChi.Text = "";
            txtDiemThuong.Text = "";
            txtSDT.Text = "";
            txtSoCMND.Text = "";
            txtSoTaiKhoan.Text = "";
            txtTenKh.Focus();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            txtDiaChi.Text = dataGridView1.Rows[row].Cells["DiaChi"].Value.ToString();
            txtDiemThuong.Text = dataGridView1.Rows[row].Cells["SoDiemThuong"].Value.ToString();
            txtMaKh.Text = dataGridView1.Rows[row].Cells["MaKhach"].Value.ToString();
            txtSDT.Text = dataGridView1.Rows[row].Cells["SDT"].Value.ToString();
            txtSoCMND.Text = dataGridView1.Rows[row].Cells["SoCMND"].Value.ToString();
            txtSoTaiKhoan.Text = dataGridView1.Rows[row].Cells["SoTaiKhoan"].Value.ToString();
            txtTenKh.Text = dataGridView1.Rows[row].Cells["TenKhach"].Value.ToString();
            comboGioiTinh.Text = dataGridView1.Rows[row].Cells["GioiTinh"].Value.ToString();
        }

        private void rdoTimKiem_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTimKiem.Checked == true)
            {
                txtMaKh.ReadOnly = false;
                txtMaKh.Text = "";
            }
            else
                txtMaKh.ReadOnly = true;
        }

        private void btnExportToEcxel_Click(object sender, EventArgs e)
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
            for (int k = 1; k < dataGridView1.Columns.Count + 1; k++)
            {

                xlWorkSheet.Cells[1, k] = dataGridView1.Columns[k - 1].HeaderText;

            }
            for (i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                {
                    DataGridViewCell cell = dataGridView1[j, i];
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
    }
}
