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
    public partial class frmMatHang : Form
    {
        public frmMatHang()
        {
            InitializeComponent();
        }

        //Loai san pham
        LoaiSanPhamBLL bllLSP = new LoaiSanPhamBLL();
        private void btnCLR_LSP_Click(object sender, EventArgs e)
        {
            txtMaLSP.Text = "";
            txtTenLSP.Text = "";
            txtMaLSP.Focus();
        }

        private void btnOK_LSP_Click(object sender, EventArgs e)
        {
            LoaiSanPham ngh = new LoaiSanPham(txtMaLSP.Text, txtTenLSP.Text);
            if (rdoThemLSP.Checked == true)
            {
                bllLSP.Insert(ngh);
                dataGridView1.DataSource = bllLSP.GetListLoaiSanPham();
                btnCLR_LSP_Click(sender, e);
            }
            if (rdoSuaLSP.Checked == true)
            {
                bllLSP.Update(ngh);
                dataGridView1.DataSource = bllLSP.GetListLoaiSanPham();
                btnCLR_LSP_Click(sender, e);
            }
            if (rdoXoaLSP.Checked == true)
            {
                bllLSP.Delete(ngh);
                dataGridView1.DataSource = bllLSP.GetListLoaiSanPham();
                btnCLR_LSP_Click(sender, e);
            }
            if (rdoTimKiemLSP.Checked == true)
            {
                dataGridView1.DataSource = bllLSP.Search(ngh);
                btnCLR_LSP_Click(sender, e);
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            txtMaLSP.Text = dataGridView1.Rows[row].Cells["MaLoaiSanPham"].Value.ToString();
            txtTenLSP.Text = dataGridView1.Rows[row].Cells["TenLoaiSanPham"].Value.ToString();
        }

        //Nhom hang
        NhomHangBLL bllNhomH = new NhomHangBLL();
        private void btnCLR_NH_Click(object sender, EventArgs e)
        {
            txtMaNhomH.Text = "";
            txtTenNhomH.Text = "";
            txtMaNhomH.Focus();
        }

        private void btnOK_NH_Click(object sender, EventArgs e)
        {
            NhomHang nh = new NhomHang(txtMaNhomH.Text, txtTenNhomH.Text, comboNganhHang.SelectedValue.ToString());
            if (rdoThemNH.Checked == true)
            {
                bllNhomH.Insert(nh);
                dataGridView2.DataSource = bllNhomH.GetListNhomHang();
                btnCLR_NH_Click(sender, e);
            }
            if (rdoSuaNH.Checked == true)
            {
                bllNhomH.Update(nh);
                dataGridView2.DataSource = bllNhomH.GetListNhomHang();
                btnCLR_NH_Click(sender, e);
            }
            if (rdoXoaNH.Checked == true)
            {
                bllNhomH.Delete(nh);
                dataGridView2.DataSource = bllNhomH.GetListNhomHang();
                btnCLR_NH_Click(sender, e);
            }
            if (rdoTimKiemNH.Checked == true)
            {
                dataGridView2.DataSource = bllNhomH.Search(nh);
                btnCLR_NH_Click(sender, e);
            }
        }
        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            txtMaNhomH.Text = dataGridView2.Rows[row].Cells["MaNhomHang"].Value.ToString();
            txtTenNhomH.Text = dataGridView2.Rows[row].Cells["TenNhomH"].Value.ToString();
            comboNganhHang.Text = dataGridView2.Rows[row].Cells["TenLoaiSanPham1"].Value.ToString();
        }

        //Hang san xuat
        HangSXBLL bllHSX = new HangSXBLL();
        private void btnOK_HSX_Click(object sender, EventArgs e)
        {
            HangSX hsx = new HangSX(txtMaHangSX.Text, txtTenHangSX.Text);
            if (rdoThemHSX.Checked == true)
            {
                if (txtMaHangSX.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã hãng sản xuất.", "Thông báo");
                    txtMaHangSX.Focus();
                }
                else
                {
                    bllHSX.Insert(hsx);
                    dataGridView5.DataSource = bllHSX.GetListHangSX();
                }
                btnCLR_HSX_Click(sender, e);
            }
            if (rdoSuaHSX.Checked == true)
            {
                bllHSX.Update(hsx);
                dataGridView5.DataSource = bllHSX.GetListHangSX();
                btnCLR_HSX_Click(sender, e);
            }
            if (rdoXoaHSX.Checked == true)
            {
                bllHSX.Delete(hsx);
                dataGridView5.DataSource = bllHSX.GetListHangSX();
                btnCLR_HSX_Click(sender, e);
            }
            if (rdoTimKiemHSX.Checked == true)
            {
                dataGridView5.DataSource = bllHSX.Search(hsx);
                btnCLR_HSX_Click(sender, e);
            }

        }

        private void btnCLR_HSX_Click(object sender, EventArgs e)
        {
            txtMaHangSX.Text = "";
            txtTenHangSX.Text = "";
            txtMaHangSX.Focus();
        }

        private void dataGridView5_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            txtMaHangSX.Text = dataGridView1.Rows[row].Cells["MaHangSX"].Value.ToString();
            txtTenHangSX.Text = dataGridView1.Rows[row].Cells["TenHangSX"].Value.ToString();
        }

        //Mat hang
        MatHang mh;
        MatHangBLL bllMH = new MatHangBLL();
        private void GetDataMatHang()
        {
            int _TonK;
            int _TonQ;
            int _Vat;
            int _GiaBan;
            mh = new MatHang();
            mh.MaHang = txtMaHang.Text;
            mh.MaHangSX = comboHangSX.SelectedValue.ToString();
            mh.MaNhomHang = comboNhomHang.SelectedValue.ToString();
            mh.TenHang = txtTenHang.Text;
            int.TryParse(txtTQTT.Text, out _TonQ);
            mh.TonQuayToiThieu = _TonQ;
            int.TryParse(txtVat.Text, out _Vat);
            mh.VAT = _Vat;
            int.TryParse(txtTKTT.Text, out _TonK);
            mh.TonKhoToiThieu = _TonK;
            int.TryParse(txtGiaBan.Text, out _GiaBan);
            mh.GiaBan = _GiaBan;
            mh.DonViTinh = comboDVT.Text;
        }

        private void dataGridView3_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            comboNhomHang.DataSource = bllNhomH.GetListNhomHang();
            int row = e.RowIndex;

            txtGiaBan.Text = dataGridView3.Rows[row].Cells["GiaBan"].Value.ToString();
            txtMaHang.Text = dataGridView3.Rows[row].Cells["MaHang"].Value.ToString();
            txtTenHang.Text = dataGridView3.Rows[row].Cells["TenHang"].Value.ToString();
            txtTonKho.Text = dataGridView3.Rows[row].Cells["TonKho"].Value.ToString();
            txtTKTT.Text = dataGridView3.Rows[row].Cells["TonKhoToiThieu"].Value.ToString();
            txtTQTT.Text = dataGridView3.Rows[row].Cells["TonQuayToiThieu"].Value.ToString();
            txtTonQuay.Text = dataGridView3.Rows[row].Cells["TonQuay"].Value.ToString();
            txtVat.Text = dataGridView3.Rows[row].Cells["VAT"].Value.ToString();
            comboDVT.Text = dataGridView3.Rows[row].Cells["DonViTinh"].Value.ToString();
            comboHangSX.Text = dataGridView3.Rows[row].Cells["TenHangSX"].Value.ToString();
            comboNhomHang.Text = dataGridView3.Rows[row].Cells["TenNhomHang"].Value.ToString();
            dataGridView4.DataSource = bllMH.GetListNCCMatHang(txtMaHang.Text);
        }

        private void btnOK_MH_Click(object sender, EventArgs e)
        {
            GetDataMatHang();
            if (rdoThemMH.Checked == true)
            {
                if (txtMaHang.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã hàng.", "Thông báo");
                    txtMaHang.Focus();
                }
                else
                    if (comboNhomHang.Text != "")
                {
                    bllMH.Insert(mh);
                    dataGridView3.DataSource = bllMH.GetListMatHang();
                    btnCLR_MH_Click(sender, e);
                }
                else
                    MessageBox.Show("Chưa có thông tin nhóm hàng.", "Thông báo");
            }
            if (rdoSuaMH.Checked == true)
            {
                bllMH.Update(mh);
                dataGridView3.DataSource = bllMH.GetListMatHang();
                btnCLR_MH_Click(sender, e);
            }
            if (rdoXoaMH.Checked == true)
            {
                bllMH.Delete(mh);
                dataGridView3.DataSource = bllMH.GetListMatHang();
                btnCLR_MH_Click(sender, e);
            }
            if (rdoTimKiemMH.Checked == true)
            {
                if (ckDVT.Checked == false)
                    mh.DonViTinh = "";
                if (ckHangSX.Checked == false)
                    mh.MaHangSX = "";
                if (ckNhomH.Checked == false)
                    mh.MaNhomHang = "";
                dataGridView3.DataSource = bllMH.Search(mh);
                dataGridView3.Refresh();
            }

        }

        private void comboNhomHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bllNhomH.GetNhomHangByID(comboNhomHang.SelectedValue.ToString()).Rows.Count > 0)
            {
                txtLoaiSanPham.Text = bllNhomH.GetNhomHangByID(comboNhomHang.SelectedValue.ToString()).Rows[0]["TenLoaiSanPham"].ToString();
            }
        }

        private void btnCLR_MH_Click(object sender, EventArgs e)
        {
            txtMaHang.Text = "";
            txtTenHang.Text = "";
            txtTonKho.Text = "";
            txtTKTT.Text = "";
            txtTQTT.Text = "";
            txtTonQuay.Text = "";
            txtVat.Text = "";
            txtGiaBan.Text = "";
        }

        private void rdoTimKiemMH_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTimKiemMH.Checked == true)
            {
                txtGiaBan.ReadOnly = true;
                txtTKTT.ReadOnly = true;
                txtTQTT.ReadOnly = true;
                txtVat.ReadOnly = true;

            }
            else
            {
                txtGiaBan.ReadOnly = false;
                txtTKTT.ReadOnly = false;
                txtTQTT.ReadOnly = false;
                txtVat.ReadOnly = false;
            }
        }

        private void btnXuatRaEcxel_Click(object sender, EventArgs e)
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
            for (int k = 1; k < dataGridView3.Columns.Count + 1; k++)
            {

                xlWorkSheet.Cells[1, k] = dataGridView3.Columns[k - 1].HeaderText;

            }
            for (i = 0; i <= dataGridView3.RowCount - 1; i++)
            {
                for (j = 0; j <= dataGridView3.ColumnCount - 1; j++)
                {
                    DataGridViewCell cell = dataGridView3[j, i];
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
        private void ckbNCC_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbNCC.Checked == true)
            {
                dataGridView4.Visible = true;
            }
            else
                dataGridView4.Visible = false;
        }

        private void frmMatHang_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bllLSP.GetListLoaiSanPham();

            dataGridView2.DataSource = bllNhomH.GetListNhomHang();
            comboNganhHang.DataSource = bllLSP.GetListLoaiSanPham();
            comboNganhHang.DisplayMember = "TenLoaiSanPham";
            comboNganhHang.ValueMember = "MaLoaiSanPham";

            dataGridView5.DataSource = bllHSX.GetListHangSX();

            comboDVT.Text = "Chiếc";
            comboHangSX.DataSource = bllHSX.GetListHangSX();
            comboHangSX.ValueMember = "MaHangSX";
            comboHangSX.DisplayMember = "TenHangSX";
            comboNhomHang.DataSource = bllNhomH.GetListNhomHang();
            comboNhomHang.ValueMember = "MaNhomHang";
            comboNhomHang.DisplayMember = "TenNhomHang";
            dataGridView3.DataSource = bllMH.GetListMatHang();
        }
    }
}
