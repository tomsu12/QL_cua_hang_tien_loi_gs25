using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QL_cua_hang_tien_loi.Entities;
using QL_cua_hang_tien_loi.BusinessLayer;

namespace QL_cua_hang_tien_loi
{
    public partial class frmCapNhatPhieuNhap : Form
    {
        string SoHoaDon;
        double dongia, soluong, chietkhau;
        HoaDonNhapHang CTMuaHang = new HoaDonNhapHang();
        HoaDonNhapHangBLL bllCTMuaHang = new HoaDonNhapHangBLL();
        ChiTietHoaDonNHBLL bllDetailHoaDonMH = new ChiTietHoaDonNHBLL();
        NhaCungCapBLL bllNCC = new NhaCungCapBLL();
        NhanVienBLL bllNhanVien = new NhanVienBLL();
        MatHangBLL bllMatHang = new MatHangBLL();
        ChiTietHoaDonNH DetailHoaDon = new ChiTietHoaDonNH();

        public frmCapNhatPhieuNhap(string SoHoaDon)
        {
            InitializeComponent();
            this.SoHoaDon = SoHoaDon;
        }
        public void TinhTienHang()
        {
            if (bllCTMuaHang.GetListHoaDonByID(SoHoaDon).Rows.Count > 0)
            {
                object sum = bllDetailHoaDonMH.GetListDetailHoaDonNHBySoCT(SoHoaDon).Compute("Sum(ThanhTien)", string.Empty);
                txtTienHang.Text = sum.ToString();
            }
            else
                txtTienHang.Text = "0";
        }
        public void AutoSTTDatagrid()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["STT"].Value = i + 1;
            }
        }
        public void ShowDataGrid()
        {
            dataGridView1.DataSource = bllDetailHoaDonMH.GetListDetailHoaDonNHBySoCT(SoHoaDon);
            AutoSTTDatagrid();
            TinhTienHang();
        }
        private void frmCapNhatPhieuNhap_Load(object sender, EventArgs e)
        {
            comboMaHang.DataSource = bllMatHang.GetListMatHang();
            comboMaHang.ValueMember = "MaHang";
            comboMaHang.DisplayMember = "MaHang";
            comboNhanVien.DataSource = bllNhanVien.GetListNhanVien();
            comboNhanVien.ValueMember = "MaNV";
            comboNhanVien.DisplayMember = "MaNV";
            comboMaHang.Text = "";
            comboNhanVien.Text = "";
            if (bllCTMuaHang.GetListHoaDonByID(SoHoaDon).Rows.Count > 0)
            {
                txtPhieuGiaoNhan.Text = bllCTMuaHang.GetListHoaDonByID(SoHoaDon).Rows[0]["SoHoaDonLienQuan"].ToString();
                lblSoHoaDon.Text = bllCTMuaHang.GetListHoaDonByID(SoHoaDon).Rows[0]["SoHoaDon"].ToString();
                lblNgayThang.Text = bllCTMuaHang.GetListHoaDonByID(SoHoaDon).Rows[0]["NgayThang"].ToString();
                lblNgayThang.Text = DateTime.Parse(lblNgayThang.Text).ToShortDateString();
                lblUser.Text = UserLogin.MaNV.ToString();
                txtMaNCC.Text = bllCTMuaHang.GetListHoaDonByID(SoHoaDon).Rows[0]["MaNCC"].ToString();
                comboNhanVien.Text = bllCTMuaHang.GetListHoaDonByID(SoHoaDon).Rows[0]["MaNV"].ToString();
                txtChietkhauHD.Text = bllCTMuaHang.GetListHoaDonByID(SoHoaDon).Rows[0]["ChietKhauHoaDon"].ToString();
                txtThanhToan.Text = bllCTMuaHang.GetListHoaDonByID(SoHoaDon).Rows[0]["DaThanhToan"].ToString();
                ShowDataGrid();


            }
        }

        private void txtTienHang_TextChanged(object sender, EventArgs e)
        {
            double tienhang;
            double chietKhauHD;
            double.TryParse(txtTienHang.Text, out tienhang);
            double.TryParse(txtChietkhauHD.Text, out chietKhauHD);
            double tongphaitra = tienhang - chietKhauHD;
            txtTongPhaiTra.Text = string.Format("{0:0,0}", tongphaitra);

        }

        private void txtChietkhauHD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double tongphaitra = double.Parse(txtTienHang.Text) - double.Parse(txtChietkhauHD.Text);
                txtTongPhaiTra.Text = string.Format("{0:0,0}", tongphaitra);
            }
            catch
            {
                MessageBox.Show("Ban phai nhap vao mot so");
                txtChietkhauHD.Text = "0";
                txtChietkhauHD.Focus();
            }
        }

        private void txtThanhToan_TextChanged(object sender, EventArgs e)
        {
            double thanhtoan;
            double.TryParse(txtThanhToan.Text, out thanhtoan);
            double conlai = double.Parse(txtTongPhaiTra.Text.Replace(",", "")) - thanhtoan;
            lblconlai.Text = conlai.ToString();
        }

        private void txtMaNCC_TextChanged(object sender, EventArgs e)
        {
            if (bllNCC.GetNhaccById(txtMaNCC.Text).Rows.Count > 0)
            {
                txtTenNCC.Text = bllNCC.GetNhaccById(txtMaNCC.Text).Rows[0]["TenNCC"].ToString();
                txtDiaChi.Text = bllNCC.GetNhaccById(txtMaNCC.Text).Rows[0]["DiaChi"].ToString();
                txtSDT.Text = bllNCC.GetNhaccById(txtMaNCC.Text).Rows[0]["SDT"].ToString();
                txtMaSoThue.Text = bllNCC.GetNhaccById(txtMaNCC.Text).Rows[0]["MaSoThue"].ToString();
            }
            else
            {
                txtTenNCC.Text = "";
                txtDiaChi.Text = "";
                txtSDT.Text = "";
                txtMaSoThue.Text = "";
            }
        }

        private void txtTongPhaiTra_TextChanged(object sender, EventArgs e)
        {
            double thanhtoan;
            double.TryParse(txtThanhToan.Text, out thanhtoan);
            double conlai = double.Parse(txtTongPhaiTra.Text.Replace(",", "")) - thanhtoan;
            lblconlai.Text = conlai.ToString();

        }

        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            comboMaHang.Text = dataGridView1.Rows[row].Cells["MaHang"].Value.ToString();
            txtSoLuong.Text = dataGridView1.Rows[row].Cells["SoLuong"].Value.ToString();
            txtDVT.Text = dataGridView1.Rows[row].Cells["DonViTinh"].Value.ToString();
            txtDonGia.Text = string.Format("{0:0,0}", dataGridView1.Rows[row].Cells["GiaNhap"].Value.ToString());
            txtChietKhau.Text = dataGridView1.Rows[row].Cells["ChietKhauMatHang"].Value.ToString();
        }

        private void btnCLR_Click(object sender, EventArgs e)
        {
            comboMaHang.Text = "";

            txtSoLuong.Text = "0";
            txtDonGia.Text = "0";
            txtDVT.Text = "";
            txtChietKhau.Text = "0";
        }

        private void txtDonGia_Leave(object sender, EventArgs e)
        {

            try
            {
                txtDonGia.Text = string.Format("{0:0,0}", double.Parse(txtDonGia.Text.Replace(",", "")));
                dongia = double.Parse(txtDonGia.Text.Replace(",", ""));
            }
            catch
            {
                MessageBox.Show("Ban phai nhap vao mot so");
                txtDonGia.Text = "0";
                txtDonGia.Focus();
            }
        }

        private void txtSoLuong_Leave(object sender, EventArgs e)
        {
            try
            {
                soluong = double.Parse(txtSoLuong.Text);
            }
            catch
            {
                MessageBox.Show("Ban phai nhap vao mot so");
                txtSoLuong.Text = "0";
                txtSoLuong.Focus();
            }
        }

        private void txtChietKhau_TextChanged(object sender, EventArgs e)
        {
            try
            {
                chietkhau = double.Parse(txtChietKhau.Text);
            }
            catch
            {
                MessageBox.Show("Ban phai nhap vao mot so");
                txtChietKhau.Focus();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muôn xóa số chứng từ " + lblSoHoaDon.Text, "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                bllCTMuaHang.Delete(lblSoHoaDon.Text);
                MessageBox.Show("Bạn đã xóa thành công.");
                this.Close();


            }
        }
        public void GetDetailHoaDon()
        {
            txtDonGia.Text = string.Format("{0:0,0}", double.Parse(txtDonGia.Text.Replace(",", "")));
            dongia = double.Parse(txtDonGia.Text.Replace(",", ""));
            double chietkhaumh;
            double.TryParse(txtChietKhau.Text, out chietkhaumh);
            DetailHoaDon.ChietKhauMatHang = chietkhaumh;
            DetailHoaDon.SoHoaDon = lblSoHoaDon.Text;
            double solo = bllCTMuaHang.GetSoLoHangNhapByIdMatHang(comboMaHang.SelectedValue.ToString()) + 1;
            DetailHoaDon.SoLo = solo;
            DetailHoaDon.GiaNhap = dongia;
            DetailHoaDon.MaHang = comboMaHang.SelectedValue.ToString();
            DetailHoaDon.SoLuong = double.Parse(txtSoLuong.Text);
            double thanhtien = dongia * double.Parse(txtSoLuong.Text) * (100 - chietkhaumh) / 100;
            DetailHoaDon.ThanhTien = thanhtien;
        }

        private void btnInsertTB_Click(object sender, EventArgs e)
        {
            if (comboMaHang.Text == "")
            {
                MessageBox.Show("Ban chua nhap thông tin mặt hàng", "Thong bao");

            }
            else
                if (txtDonGia.Text == "0" || txtDonGia.Text == "")
            {
                MessageBox.Show("Ban chu nhap don gia", "Thong bao");
                txtDonGia.Focus();
            }
            else
                    if (txtSoLuong.Text == "0" || txtSoLuong.Text == "")
            {
                MessageBox.Show("Ban chua nhap so luong", "Thong bao");
                txtSoLuong.Focus();
            }
            else

                        if (bllDetailHoaDonMH.GetListDetailHoaDonNHBySoCTandMaHang(lblSoHoaDon.Text, comboMaHang.SelectedValue.ToString()).Rows.Count > 0)
            {
                if (MessageBox.Show("Mat hang " + comboMaHang.SelectedValue.ToString() +
                    " da co trong don hang.\n Ban co muon cap nhat lai khong?", "Thong bao", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnUpdateTB_Click(sender, e);
                }
            }
            else
            {
                GetDetailHoaDon();
                bllDetailHoaDonMH.Insert(DetailHoaDon);
                bllCTMuaHang.UpdateNguoiLapPhieu(lblSoHoaDon.Text, lblUser.Text);
                ShowDataGrid();
                btnCLR_Click(sender, e);

            }
        }

        private void btnDeleteTB_Click(object sender, EventArgs e)
        {
            GetDetailHoaDon();
            bllDetailHoaDonMH.Delete(DetailHoaDon);
            bllCTMuaHang.UpdateNguoiLapPhieu(lblSoHoaDon.Text, lblUser.Text);
            ShowDataGrid();
            btnCLR_Click(sender, e);
        }

        private void btnUpdateTB_Click(object sender, EventArgs e)
        {
            GetDetailHoaDon();
            bllDetailHoaDonMH.Update(DetailHoaDon);
            bllCTMuaHang.UpdateNguoiLapPhieu(lblSoHoaDon.Text, lblUser.Text);
            ShowDataGrid();
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật \n số chứng từ " + lblSoHoaDon.Text + " không.", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                bllCTMuaHang.Update(lblSoHoaDon.Text, lblUser.Text, txtChietkhauHD.Text, txtThanhToan.Text);
                MessageBox.Show("Bạn đã cập nhật thành công.");
                this.Close();
                frmReportPhieuNhapKho frm = new frmReportPhieuNhapKho(SoHoaDon);
                frm.Show();

            }
        }

        private void comboMaHang_TextChanged(object sender, EventArgs e)
        {
            if (comboMaHang.SelectedValue != null || comboMaHang.Text != "")
            {
                if (bllMatHang.GetMatHangById(comboMaHang.Text).Rows.Count > 0)
                {

                    txtTenHang.Text = bllMatHang.GetMatHangById(comboMaHang.Text).Rows[0]["TenHang"].ToString();
                    txtDVT.Text = bllMatHang.GetMatHangById(comboMaHang.Text).Rows[0]["DonViTinh"].ToString();
                }
            }
            else
            {
                txtTenHang.Text = "";
                txtDVT.Text = "";
            }

        }

        private void comboNhanVien_TextChanged(object sender, EventArgs e)
        {
            if (comboNhanVien.SelectedValue != null)
            {
                if (bllNhanVien.GetNhanVienById(comboNhanVien.Text).Rows.Count > 0)
                {
                    txtTenNV.Text = bllNhanVien.GetNhanVienById(comboNhanVien.Text).Rows[0]["TenNV"].ToString();
                }
            }
            else
                txtTenNV.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboNhanVien.SelectedValue != null)
            {
                if (bllNhanVien.GetNhanVienById(comboNhanVien.SelectedValue.ToString()).Rows.Count > 0)
                {
                    txtTenNV.Text = bllNhanVien.GetNhanVienById(comboNhanVien.SelectedValue.ToString()).Rows[0]["TenNV"].ToString();
                }
            }
            else
                txtTenNV.Text = "";
        }
    }
}
