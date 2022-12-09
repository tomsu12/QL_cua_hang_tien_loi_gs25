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
using System.Configuration;
namespace QL_cua_hang_tien_loi
{
    public partial class frmPhieuNhapHang : Form
    {
        public frmPhieuNhapHang()
        {
            InitializeComponent();
        }
        HoaDonNhapHang PhieuNhap = new HoaDonNhapHang();
        HoaDonNhapHangBLL bll = new HoaDonNhapHangBLL();
        List<ChiTietHoaDonNH> listCTPhieuNhap = new List<ChiTietHoaDonNH>();
        LoaiHoaDon LoaiCT = new LoaiHoaDon();
        NhaCungCapBLL bllNCC = new NhaCungCapBLL();
        NhanVienBLL bllNhanVien = new NhanVienBLL();
        MatHangBLL bllMatHang = new MatHangBLL();
        DataTable DTChiTietPhieuNhap = new DataTable();
        double dongia, soluong, chietkhau, thanhtien;

        public void GetIDAuto()
        {
            HoaDonNhapHangBLL bllHDNH = new HoaDonNhapHangBLL();
            string soPN = bllHDNH.GetMaxID(LoaiCT);
            int dem;
            int.TryParse(soPN, out dem);
            dem = dem + 1;
            lblSoHoaDon.Text = string.Format("{0:PNH00000}", dem);
        }

        public void GetTTPhieuNhap()
        {
            PhieuNhap = new HoaDonNhapHang();
            listCTPhieuNhap = new List<ChiTietHoaDonNH>();
            PhieuNhap.MaLoaiHoaDon = "PNH";
            PhieuNhap.MaNCC = comboMaNCC.SelectedValue.ToString();
            PhieuNhap.SoHoaDon = lblSoHoaDon.Text;
            PhieuNhap.NguoiLapPhieu = lblUser.Text;
            PhieuNhap.MaNV = comboNhanVien.SelectedValue.ToString();
            PhieuNhap.NgayThang = DateTime.Parse(lblNgayThang.Text);
            PhieuNhap.SoHoaDonLienQuan = txtPhieuGiaoNhan.Text;
            PhieuNhap.ListChiTietHoaDon = listCTPhieuNhap;
            double dathanhtoan, chietkhauhd;
            double.TryParse(txtThanhToan.Text, out dathanhtoan);
            PhieuNhap.DaThanhToan = dathanhtoan;
            double.TryParse(txtChietkhauHD.Text, out chietkhauhd);
            PhieuNhap.ChietKhauHoaDon = chietkhauhd;
            foreach (DataRow row in DTChiTietPhieuNhap.Rows)
            {
                ChiTietHoaDonNH ct = new ChiTietHoaDonNH();
                ct.SoHoaDon = lblSoHoaDon.Text;
                ct.MaHang = row["MaHang"].ToString();
                ct.SoLo = double.Parse(row["SoLo"].ToString());
                ct.SoLuong = double.Parse(row["SoLuong"].ToString());
                ct.GiaNhap = double.Parse(row["GiaNhap"].ToString());
                ct.ChietKhauMatHang = double.Parse(row["ChietKhauMatHang"].ToString());
                ct.ThanhTien = double.Parse(row["ThanhTien"].ToString());
                listCTPhieuNhap.Add(ct);
            }
            PhieuNhap.ListChiTietHoaDon = listCTPhieuNhap;
        }


        private void frmPhieuNhapHang_Load(object sender, EventArgs e)
        {
            LoaiCT.MaLoaiHoaDon = "PNH";
            LoaiCT.TenLoaiHoaDon = "Phiếu nhập hàng";

            //SoHoaDonPhieuNhap
            GetIDAuto();
            comboMaHang.DataSource = bllMatHang.GetListMatHang();
            comboMaHang.DisplayMember = "MaHang";
            comboMaHang.ValueMember = "MaHang";
            comboMaHang.Text = "";
            DateTime date = DateTime.Today;
            lblNgayThang.Text = date.ToString(@"dd\/MM\/yyyy");
            lblUser.Text = UserLogin.MaNV.ToString();
            comboMaNCC.DataSource = bllNCC.GetListNhaCC();
            comboMaNCC.ValueMember = "MaNCC";
            comboMaNCC.DisplayMember = "TenNCC";
            comboNhanVien.DataSource = bllNhanVien.GetListNhanVien();
            comboNhanVien.ValueMember = "MaNV";
            comboNhanVien.DisplayMember = "TenNV";
            //
            DTChiTietPhieuNhap.Columns.Add("STT");
            DTChiTietPhieuNhap.Columns.Add("MaHang");
            DTChiTietPhieuNhap.Columns.Add("TenHang");
            DTChiTietPhieuNhap.Columns.Add("DonViTinh");
            DTChiTietPhieuNhap.Columns.Add("SoLo", typeof(double));
            DTChiTietPhieuNhap.Columns.Add("GiaNhap", typeof(double));
            DTChiTietPhieuNhap.Columns.Add("SoLuong", typeof(double));
            DTChiTietPhieuNhap.Columns.Add("ChietKhauMatHang", typeof(double));
            DTChiTietPhieuNhap.Columns.Add("ThanhTien", typeof(double));
            //

        }

        private void btnInsertTB_Click(object sender, EventArgs e)
        {
            if (comboMaHang.Text == "")
            {
                MessageBox.Show("Ban chua nhap ma hang", "Thong bao");
                comboMaHang.Focus();
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
                        if (DTChiTietPhieuNhap.Select("MaHang='" + comboMaHang.Text + "'").Length > 0)
            {
                if (MessageBox.Show("Mat hang " + comboMaHang.Text +
                    " da co trong don hang.\n Ban co muon cap nhat lai khong?", "Thong bao", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnUpdateTB_Click(sender, e);
                }
            }
            else
            {
                DataRow row = DTChiTietPhieuNhap.NewRow();
                double solo = bll.GetSoLoHangNhapByIdMatHang(comboMaHang.Text) + 1;
                row["MaHang"] = comboMaHang.Text;
                row["TenHang"] = txtTenHang.Text;
                row["DonViTinh"] = txtDVT.Text;
                row["GiaNhap"] = double.Parse(txtDonGia.Text.Replace(",", ""));
                double chietkhau;
                double.TryParse(txtChietKhau.Text, out chietkhau);
                row["ChietKhauMatHang"] = chietkhau;
                row["SoLuong"] = txtSoLuong.Text;
                row["SoLo"] = solo;
                thanhtien = dongia * soluong * (100 - chietkhau) / 100;
                row["ThanhTien"] = thanhtien.ToString();
                DTChiTietPhieuNhap.Rows.Add(row);
                dataGridView1.DataSource = DTChiTietPhieuNhap;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells["STT"].Value = i + 1;
                }
                //Tinh tien hang
                TinhTienHang();
                btnCLR_Click(sender, e);

            }
        }

        private void btnUpdateTB_Click(object sender, EventArgs e)
        {
            DataRow[] drr = DTChiTietPhieuNhap.Select("MaHang='" + comboMaHang.Text + "'");
            if (drr.Length > 0)
            {
                drr[0]["GiaNhap"] = double.Parse(txtDonGia.Text.Replace("'", ""));
                drr[0]["SoLuong"] = txtSoLuong.Text;
                drr[0]["ChietKhauMatHang"] = txtChietKhau.Text;
                thanhtien = dongia * soluong * (100 - chietkhau) / 100;
                drr[0]["ThanhTien"] = thanhtien;
            }
            dataGridView1.DataSource = DTChiTietPhieuNhap;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["STT"].Value = (i + 1).ToString();
            }
            TinhTienHang();
            btnCLR_Click(sender, e);
        }

        private void btnDeleteTB_Click(object sender, EventArgs e)
        {
            DataRow[] drr = DTChiTietPhieuNhap.Select("MaHang='" + comboMaHang.Text + "'");
            for (int i = 0; i < drr.Length; i++)
            {
                DTChiTietPhieuNhap.Rows.Remove(drr[i]);
                DTChiTietPhieuNhap.AcceptChanges();
            }
            TinhTienHang();
            dataGridView1.DataSource = DTChiTietPhieuNhap;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["STT"].Value = i + 1;
            }
            btnCLR_Click(sender, e);

        }



        private void btnCLR_Click(object sender, EventArgs e)
        {
            comboMaHang.Text = "";
            txtTenHang.Text = "";
            txtSoLuong.Text = "0";
            txtDonGia.Text = "0";
            txtDVT.Text = "";
            txtChietKhau.Text = "0";
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            comboMaHang.Text = dataGridView1.Rows[row].Cells["MaHang"].Value.ToString();
            txtTenHang.Text = dataGridView1.Rows[row].Cells["TenHang"].Value.ToString();
            txtSoLuong.Text = dataGridView1.Rows[row].Cells["SoLuong"].Value.ToString();
            txtDVT.Text = dataGridView1.Rows[row].Cells["DonViTinh"].Value.ToString();
            txtDonGia.Text = string.Format("{0:0,0}", dataGridView1.Rows[row].Cells["GiaNhap"].Value.ToString());
            txtChietKhau.Text = dataGridView1.Rows[row].Cells["ChietKhauMatHang"].Value.ToString();
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
        private void TinhTienHang()
        {
            object sum = DTChiTietPhieuNhap.Compute("Sum(ThanhTien)", string.Empty);
            double Tong;
            double.TryParse(sum.ToString(), out Tong);
            txtTienHang.Text = Tong.ToString();
        }

        private void txtTienHang_TextChanged(object sender, EventArgs e)
        {
            double tongphaitra, chietkhauhd, tienhang;
            double.TryParse(txtTienHang.Text, out tienhang);
            double.TryParse(txtChietkhauHD.Text, out chietkhauhd);
            tongphaitra = tienhang - chietkhauhd;
            txtTongPhaiTra.Text = string.Format("{0:0,0}", tongphaitra);
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

        private void txtThanhToan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double conlai = double.Parse(txtTongPhaiTra.Text.Replace(",", "")) - double.Parse(txtThanhToan.Text);
                lblconlai.Text = conlai.ToString();
            }
            catch
            {
                MessageBox.Show("Ban phai nhap vao mot so");
                txtThanhToan.Focus();
            }
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

        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (txtPhieuGiaoNhan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số chứng từ liên quan");
                txtPhieuGiaoNhan.Focus();
            }
            else
                if (comboMaNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập thông tin nhà cung cấp.");
                comboMaNCC.Focus();
            }
            else
                    if (comboMaNCC.SelectedValue == null)
            {
                MessageBox.Show("Không có nhà cung cấp.");
                comboMaNCC.Focus();
            }
            else
                        if (comboNhanVien.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập thông tin nhân viên.");
                comboNhanVien.Focus();
            }
            else
                            if (comboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Không có nhân viên ." + comboNhanVien.Text);
                comboNhanVien.Focus();
            }
            else
                 if (DTChiTietPhieuNhap.Rows.Count == 0)
            {
                MessageBox.Show("Phiếu nhập này không có hàng, không in được.");
            }
            else
            {
                GetTTPhieuNhap();
                bll.Insert(PhieuNhap);
                frmReportPhieuNhapKho frmreport = new frmReportPhieuNhapKho(lblSoHoaDon.Text);
                frmreport.Show();
                DTChiTietPhieuNhap.Clear();
                txtPhieuGiaoNhan.Text = "";
                txtMaNV.Text = "";
                txtChietkhauHD.Text = "0";
                txtThanhToan.Text = "0";
                lblconlai.Text = "0";

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtPhieuGiaoNhan.Text = "";
            txtMaNV.Text = "";
            txtChietkhauHD.Text = "0";
            txtThanhToan.Text = "0";
            lblconlai.Text = "0";
            DTChiTietPhieuNhap.Clear();
            dataGridView1.DataSource = DTChiTietPhieuNhap;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            frmTimKiem frm = new frmTimKiem();
            frm.Show();
        }

        private void txtTongPhaiTra_TextChanged(object sender, EventArgs e)
        {

            double thanhtoan;
            double.TryParse(txtThanhToan.Text, out thanhtoan);
            double conlai = double.Parse(txtTongPhaiTra.Text.Replace(",", "")) - thanhtoan;
            lblconlai.Text = conlai.ToString();

        }

        private void comboMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bllMatHang.GetMatHangById(comboMaHang.SelectedValue.ToString()).Rows.Count > 0)
            {
                txtTenHang.Text = bllMatHang.GetMatHangById(comboMaHang.SelectedValue.ToString()).Rows[0]["TenHang"].ToString();
                txtDVT.Text = bllMatHang.GetMatHangById(comboMaHang.SelectedValue.ToString()).Rows[0]["DonViTinh"].ToString();
            }
            else
            {
                txtTenHang.Text = "";
                txtDVT.Text = "";
            }
        }

        private void comboMaHang_Leave(object sender, EventArgs e)
        {
            if (bllMatHang.GetMatHangById(comboMaHang.Text).Rows.Count == 0)
            {

                comboMaHang.Text = "";
                txtTenHang.Text = "";
                txtDonGia.Text = "";
                txtDVT.Text = "";

            }

        }

        private void comboMaNCC_TextChanged(object sender, EventArgs e)
        {
            if (comboMaNCC.SelectedValue != null)
            {
                if (bllNCC.GetNhaccById(comboMaNCC.SelectedValue.ToString()).Rows.Count > 0)
                {
                    //txtTenNCC.Text = bllNCC.GetNhaccById(comboMaNCC.Text).Rows[0]["TenNCC"].ToString();
                    txtDiaChi.Text = bllNCC.GetNhaccById(comboMaNCC.SelectedValue.ToString()).Rows[0]["DiaChi"].ToString();
                    txtSDT.Text = bllNCC.GetNhaccById(comboMaNCC.SelectedValue.ToString()).Rows[0]["SDT"].ToString();
                    txtMaSoThue.Text = bllNCC.GetNhaccById(comboMaNCC.SelectedValue.ToString()).Rows[0]["MaSoThue"].ToString();
                }
            }
            else
            {
                //txtTenNCC.Text = "";
                txtDiaChi.Text = "";
                txtSDT.Text = "";
                txtMaSoThue.Text = "";
            }
        }

        private void comboNhanVien_TextChanged(object sender, EventArgs e)
        {
            if (comboNhanVien.SelectedValue != null)
            {
                if (bllNhanVien.GetNhanVienById(comboNhanVien.SelectedValue.ToString()).Rows.Count > 0)
                {
                    txtMaNV.Text = bllNhanVien.GetNhanVienById(comboNhanVien.SelectedValue.ToString()).Rows[0]["MaNV"].ToString();
                }
            }
            else
                txtMaNV.Text = "";
        }

        private void button_Click(object sender, EventArgs e)
        {
            frmDMNCC frm = new frmDMNCC();
            frm.Show();
        }

        private void btnMatHang_Click(object sender, EventArgs e)
        {
            frmMatHang frm = new frmMatHang();
            frm.Show();
        }
    }
}
