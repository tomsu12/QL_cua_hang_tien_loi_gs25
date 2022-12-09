using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QL_cua_hang_tien_loi.BusinessLayer;
using QL_cua_hang_tien_loi.Entities;

namespace QL_cua_hang_tien_loi
{
    public partial class frmCapNhatDonHang : Form
    {
        public frmCapNhatDonHang(string SoHoaDon)
        {
            InitializeComponent();
            this.SoHoaDon = SoHoaDon;
        }
        HoaDonBanHangBLL bllCTBanHang = new HoaDonBanHangBLL();
        string SoHoaDon;
        double dongia, soluong, chietkhau;
        ChiTietHoaDonBHBLL bllDetailHoaDonBH = new ChiTietHoaDonBHBLL();
        KhachHangBLL bllKhachHang = new KhachHangBLL();
        NhanVienBLL bllNhanVien = new NhanVienBLL();
        MatHangBLL bllMatHang = new MatHangBLL();
        ChiTietHoaDonBH DetailHoaDon = new ChiTietHoaDonBH();
        HoaDonBanHang CTBanHang = new HoaDonBanHang();
        public void TinhTienHang()
        {
            if (bllCTBanHang.GetListHoaDonByID(SoHoaDon).Rows.Count > 0)
            {
                object sum = bllDetailHoaDonBH.GetListDetailHoaDonBHBySoCT(SoHoaDon).Compute("Sum(ThanhTien)", string.Empty);
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
            dataGridView1.DataSource = bllDetailHoaDonBH.GetListDetailHoaDonBHBySoCT(SoHoaDon);
            AutoSTTDatagrid();
            TinhTienHang();
        }

        private void btnInsertTB_Click(object sender, EventArgs e)
        {
            if (comboMaHang.Text == "")
            {
                MessageBox.Show("Ban chua nhap ma hang", "Thong bao");
                comboMaHang.Focus();
            }
            else

                if (txtSoLuong.Text == "0" || txtSoLuong.Text == "")
            {
                MessageBox.Show("Ban chua nhap so luong", "Thong bao");
                txtSoLuong.Focus();
            }
            else

                        if (bllDetailHoaDonBH.GetListDetailHoaDonBH(lblSoHoaDon.Text, comboMaHang.Text, comboLoHang.Text).Rows.Count > 0)
            {
                if (MessageBox.Show("Mat hang " + comboMaHang.Text +
                    " da co trong don hang.\n Ban co muon cap nhat lai khong?", "Thong bao", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnUpdateTB_Click(sender, e);
                }
            }
            else
            {
                GetDetailHoaDon();
                bllDetailHoaDonBH.Insert(DetailHoaDon);
                bllCTBanHang.UpdateMaNV(lblSoHoaDon.Text, lblUser.Text);
                ShowDataGrid();
                btnCLR_Click(sender, e);

            }
        }

        private void btnDeleteTB_Click(object sender, EventArgs e)
        {
            GetDetailHoaDon();
            bllDetailHoaDonBH.Delete(DetailHoaDon);
            bllCTBanHang.UpdateMaNV(lblSoHoaDon.Text, lblUser.Text);
            btnCLR_Click(sender, e);
            ShowDataGrid();
        }
        public void GetDetailHoaDon()
        {
            dongia = double.Parse(txtDonGia.Text.Replace(",", ""));
            double chietkhauMH;
            double.TryParse(txtChietKhau.Text, out chietkhauMH);
            DetailHoaDon.ChietKhauMatHang = chietkhauMH;
            DetailHoaDon.SoHoaDon = lblSoHoaDon.Text;
            DetailHoaDon.SoLo = int.Parse(comboLoHang.Text);
            DetailHoaDon.GiaBan = dongia;
            DetailHoaDon.MaHang = comboMaHang.Text;
            DetailHoaDon.SoLuong = double.Parse(txtSoLuong.Text);
            double thanhtien = dongia * double.Parse(txtSoLuong.Text) * (100 - chietkhauMH) / 100;
            DetailHoaDon.ThanhTien = thanhtien;
        }

        private void frmUpdateHoaDonBH_Load(object sender, EventArgs e)
        {
            if (bllCTBanHang.GetListHoaDonByID(SoHoaDon).Rows.Count > 0)
            {
                comboMaHang.DataSource = bllMatHang.GetListMatHang();
                comboMaHang.DisplayMember = "MaHang";
                comboMaHang.ValueMember = "MaHang";
                comboMaHang.Text = "";
                lblSoHoaDon.Text = bllCTBanHang.GetListHoaDonByID(SoHoaDon).Rows[0]["SoHoaDon"].ToString();
                lblNgayThang.Text = bllCTBanHang.GetListHoaDonByID(SoHoaDon).Rows[0]["NgayThang"].ToString();
                lblNgayThang.Text = DateTime.Parse(lblNgayThang.Text).ToShortDateString();
                lblUser.Text = UserLogin.MaNV.ToString();
                txtMaKhach.Text = bllCTBanHang.GetListHoaDonByID(SoHoaDon).Rows[0]["MaKhach"].ToString();
                txtTenKhach.Text = bllCTBanHang.GetListHoaDonByID(SoHoaDon).Rows[0]["TenKhachHang"].ToString();
                txtDiaChi.Text = bllCTBanHang.GetListHoaDonByID(SoHoaDon).Rows[0]["DiaChi"].ToString();
                txtSDT.Text = bllCTBanHang.GetListHoaDonByID(SoHoaDon).Rows[0]["SDT"].ToString();
                txtNVTH.Text = bllCTBanHang.GetListHoaDonByID(SoHoaDon).Rows[0]["MaNV"].ToString();
                txtChietkhauHD.Text = bllCTBanHang.GetListHoaDonByID(SoHoaDon).Rows[0]["ChietKhauHoaDon"].ToString();
                txtSoPhieuQT.Text = bllCTBanHang.GetListHoaDonByID(SoHoaDon).Rows[0]["MaPhieuQuaTang"].ToString();
                txtGiaTriPhieu.Text = bllCTBanHang.GetListHoaDonByID(SoHoaDon).Rows[0]["TriGiaPQT"].ToString();
                txtThanhToan.Text = bllCTBanHang.GetListHoaDonByID(SoHoaDon).Rows[0]["DaThanhToan"].ToString();
                ShowDataGrid();

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            CTBanHang.SoHoaDon = lblSoHoaDon.Text;
            CTBanHang.MaNV = lblUser.Text;
            CTBanHang.ChietKhauHoaDon = double.Parse(txtChietkhauHD.Text);
            CTBanHang.DaThanhToan = double.Parse(txtThanhToan.Text);
            if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật \n số chứng từ " + lblSoHoaDon.Text + " không.", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                bllCTBanHang.Update(CTBanHang);
                MessageBox.Show("Bạn đã cập nhật thành công.");
                this.Close();
                frmReportHoaDon frm = new frmReportHoaDon(SoHoaDon);
                frm.Show();

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muôn xóa số chứng từ " + lblSoHoaDon.Text, "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                bllCTBanHang.Delete(lblSoHoaDon.Text);
                MessageBox.Show("Bạn đã xóa thành công.");
                this.Close();


            }
        }

        private void btnUpdateTB_Click(object sender, EventArgs e)
        {
            GetDetailHoaDon();
            bllDetailHoaDonBH.Update(DetailHoaDon);
            bllCTBanHang.UpdateMaNV(lblSoHoaDon.Text, lblUser.Text);
            ShowDataGrid();
        }


        private void comboLoHang_SelectedIndexChanged(object sender, EventArgs e)
        {

            int lohang;
            int.TryParse(comboLoHang.Text, out lohang);
            if (bllMatHang.GetSLLoHang(comboMaHang.Text, lohang.ToString()).Rows.Count > 0)
            {
                txtSL.Text = bllMatHang.GetSLLoHang(comboMaHang.Text, lohang.ToString()).Rows[0]["ConLai"].ToString();
            }
            else
                txtSL.Text = "0";
        }

        private void txtSoLuong_Leave(object sender, EventArgs e)
        {
            try
            {
                soluong = double.Parse(txtSoLuong.Text);
                if (soluong < 0)
                {
                    MessageBox.Show("Bạn phải nhập một số lớn hơn 0");
                    txtSoLuong.Text = "";
                    txtSoLuong.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Ban phai nhap vao mot so");
                txtSoLuong.Text = "0";
                txtSoLuong.Focus();
            }
            if (soluong > double.Parse(txtSL.Text))
            {
                MessageBox.Show("Số lượng của lô hàng hiện tại không đủ đáp ứng", "Thông báo");
                txtSoLuong.Text = "0";
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

        private void txtChietkhauHD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double tongphaitra = double.Parse(txtTienHang.Text) - double.Parse(txtChietkhauHD.Text) - double.Parse(txtGiaTriPhieu.Text);
                txtTongPhaiTra.Text = string.Format("{0:0,0}", tongphaitra);
            }
            catch
            {
                MessageBox.Show("Ban phai nhap vao mot so");
                txtChietkhauHD.Text = "0";
                txtChietkhauHD.Focus();
            }
        }

        private void txtTienHang_TextChanged(object sender, EventArgs e)
        {
            double tienhang;
            double chietKhauHD;
            double giaTriphieu;
            double.TryParse(txtTienHang.Text, out tienhang);
            double.TryParse(txtChietkhauHD.Text, out chietKhauHD);
            double.TryParse(txtGiaTriPhieu.Text, out giaTriphieu);
            double tongphaitra = tienhang - chietKhauHD - giaTriphieu;
            txtTongPhaiTra.Text = string.Format("{0:0,0}", tongphaitra);

        }

        private void txtTongPhaiTra_TextChanged(object sender, EventArgs e)
        {
            double thanhtoan;
            double.TryParse(txtThanhToan.Text, out thanhtoan);
            double conlai = double.Parse(txtTongPhaiTra.Text.Replace(",", "")) - thanhtoan;
            lblconlai.Text = conlai.ToString();
        }

        private void txtThanhToan_TextChanged(object sender, EventArgs e)
        {
            double thanhtoan;
            double.TryParse(txtThanhToan.Text, out thanhtoan);
            double conlai = double.Parse(txtTongPhaiTra.Text.Replace(",", "")) - thanhtoan;
            lblconlai.Text = conlai.ToString();
        }



        private void btnCLR_Click(object sender, EventArgs e)
        {
            comboMaHang.Text = "";
            comboLoHang.Text = "";
            txtTenHang.Text = "";
            txtSoLuong.Text = "0";
            txtDonGia.Text = "0";
            txtDVT.Text = "";
            txtChietKhau.Text = "0";
        }



        private void txtGiaTriPhieu_TextChanged(object sender, EventArgs e)
        {
            double tienhang;
            double.TryParse(txtTienHang.Text, out tienhang);
            double tongphaitra = tienhang - double.Parse(txtChietkhauHD.Text) - double.Parse(txtGiaTriPhieu.Text);
            txtTongPhaiTra.Text = string.Format("{0:0,0}", tongphaitra);
        }

        private void comboMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bllMatHang.GetMatHangById(comboMaHang.SelectedValue.ToString()).Rows.Count > 0)
            {
                txtTenHang.Text = bllMatHang.GetMatHangById(comboMaHang.SelectedValue.ToString()).Rows[0]["TenHang"].ToString();
                txtDVT.Text = bllMatHang.GetMatHangById(comboMaHang.SelectedValue.ToString()).Rows[0]["DonViTinh"].ToString();
                txtTonQuay.Text = bllMatHang.GetMatHangById(comboMaHang.SelectedValue.ToString()).Rows[0]["TonQuay"].ToString();
                txtTonKh.Text = bllMatHang.GetMatHangById(comboMaHang.SelectedValue.ToString()).Rows[0]["TonKho"].ToString();
                txtDonGia.Text = bllMatHang.GetMatHangById(comboMaHang.SelectedValue.ToString()).Rows[0]["GiaBan"].ToString();
                //Lay thong tin Lo hang                

                if (bllMatHang.GetLoHang(comboMaHang.SelectedValue.ToString()).Rows.Count > 0)
                {
                    comboLoHang.DataSource = bllMatHang.GetLoHang(comboMaHang.SelectedValue.ToString());
                    comboLoHang.DisplayMember = "SoLo";
                }
                else
                {
                    MessageBox.Show("Không còn mặt hàng " + comboMaHang.SelectedValue.ToString(), "Thông báo");
                    txtTonQuay.Text = "";
                    txtTonKh.Text = "";
                    comboLoHang.Text = "";

                }
            }
            else
            {
                txtTenHang.Text = "";
                txtDVT.Text = "";
                txtDonGia.Text = "";
                txtTonQuay.Text = "";
                txtTonKh.Text = "";
            }
        }

        private void comboMaHang_Leave(object sender, EventArgs e)
        {
            if (bllMatHang.GetMatHangById(comboMaHang.Text).Rows.Count == 0)
            {
                comboLoHang.Text = "";
                comboMaHang.Text = "";
                txtTenHang.Text = "";
                txtDonGia.Text = "";
                txtDVT.Text = "";

            }
        }

        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            comboMaHang.Text = dataGridView1.Rows[row].Cells["MaHang"].Value.ToString();
            txtTenHang.Text = dataGridView1.Rows[row].Cells["TenHang"].Value.ToString();
            txtDVT.Text = dataGridView1.Rows[row].Cells["DonViTinh"].Value.ToString();
            comboLoHang.Text = dataGridView1.Rows[row].Cells["SoLo"].Value.ToString();
            txtSoLuong.Text = dataGridView1.Rows[row].Cells["SoLuong"].Value.ToString();
            txtDonGia.Text = string.Format("{0:0,0}", dataGridView1.Rows[row].Cells["GiaBan"].Value.ToString());
            txtChietKhau.Text = dataGridView1.Rows[row].Cells["ChietKhauMatHang"].Value.ToString();
        }


        private void comboLoHang_TextChanged(object sender, EventArgs e)
        {
            int lohang;
            int.TryParse(comboLoHang.Text, out lohang);
            if (bllMatHang.GetSLLoHang(comboMaHang.Text, lohang.ToString()).Rows.Count > 0)
            {
                txtSL.Text = bllMatHang.GetSLLoHang(comboMaHang.Text, lohang.ToString()).Rows[0]["ConLai"].ToString();
            }
            else
                txtSL.Text = "0";
        }
    }
}
