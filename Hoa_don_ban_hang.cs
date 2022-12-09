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
using System.Configuration;

namespace QL_cua_hang_tien_loi
{
    public partial class frmDMHDBH : Form
    {
        public frmDMHDBH()
        {
            InitializeComponent();
        }
        LoaiHoaDon LoaiCT = new LoaiHoaDon();
        HoaDonBanHang DonHang = new HoaDonBanHang();
        HoaDonBanHangBLL bll = new HoaDonBanHangBLL();
        List<ChiTietHoaDonBH> listDetailDonHang = new List<ChiTietHoaDonBH>();
        KhachHangBLL bllKhachHang = new KhachHangBLL();
        NhanVienBLL bllNhanVien = new NhanVienBLL();
        MatHangBLL bllMatHang = new MatHangBLL();
        DataTable DTChiTietDonHang = new DataTable();
        PhieuQuaTangBLL bllPhieuQT = new PhieuQuaTangBLL();
        double soluong, chietkhau, thanhtien;
        
        public void GetTTDonHang()
        {
            DonHang = new HoaDonBanHang();
            listDetailDonHang = new List<ChiTietHoaDonBH>();
            DonHang.MaLoaiHoaDon = "HDB";
            if (txtGiaTriPhieu.Text == "0")
            {
                DonHang.MaPhieuQuaTang = "null";
            }
            else
                DonHang.MaPhieuQuaTang = "'" + txtSoPhieuQT.Text + "'";
            if (txtMaKh.Text == "")
            {
                DonHang.MaKhach = "null";
            }
            else
            {
                DonHang.MaKhach = "'" + txtMaKh.Text + "'";
            }
            DonHang.TriGiaPQT = double.Parse(txtGiaTriPhieu.Text);
            DonHang.SoHoaDon = lblSoHoaDon.Text;
            DonHang.MaNV = comboNhanVien.SelectedValue.ToString();
            DonHang.TenKhachHang = txtTenKh.Text;
            DonHang.DiaChi = txtDiaChi.Text;
            DonHang.SDT = txtSDT.Text;
            DonHang.DiaChiGiaoHang = txtDiaChiGiaoHang.Text;
            DonHang.NgayThang = DateTime.Parse(lblNgayThang.Text);
            DonHang.ListChiTietHoaDon = listDetailDonHang;
            double dathanhtoan, chietkhauhd;
            double.TryParse(txtThanhToan.Text, out dathanhtoan);
            DonHang.DaThanhToan = dathanhtoan;
            double.TryParse(txtChietkhauHD.Text, out chietkhauhd);
            DonHang.ChietKhauHoaDon = chietkhauhd;
            foreach (DataRow row in DTChiTietDonHang.Rows)
            {
                ChiTietHoaDonBH ct = new ChiTietHoaDonBH();
                ct.SoHoaDon = lblSoHoaDon.Text;
                ct.MaHang = row["MaHang"].ToString();
                ct.SoLo = double.Parse(row["SoLo"].ToString());
                ct.SoLuong = double.Parse(row["SoLuong"].ToString());
                ct.GiaBan = double.Parse(row["GiaBan"].ToString());
                ct.ChietKhauMatHang = double.Parse(row["ChietKhauMatHang"].ToString());
                ct.ThanhTien = double.Parse(row["ThanhTien"].ToString());
                listDetailDonHang.Add(ct);
            }

            DonHang.ListChiTietHoaDon = listDetailDonHang;
        }

        public void GetIDAuto()
        {
            HoaDonBanHangBLL bllHDBH = new HoaDonBanHangBLL();
            string soHD = bllHDBH.GetMaxID(LoaiCT);
            int dem;
            int.TryParse(soHD, out dem);
            dem = dem + 1;
            lblSoHoaDon.Text = string.Format("{0:HDB00000}", dem);
        }

        private void frmHoaDonBanHang_Load(object sender, EventArgs e)
        {
            LoaiCT.MaLoaiHoaDon = "HDB";
            LoaiCT.TenLoaiHoaDon = "Hóa đơn bán hàng";

            GetIDAuto();
            DateTime date = DateTime.Today;
            lblNgayThang.Text = date.ToString(@"dd\/MM\/yyyy");
            lblUser.Text = UserLogin.MaNV.ToString();
            DTChiTietDonHang.Columns.Add("STT");
            DTChiTietDonHang.Columns.Add("MaHang");
            DTChiTietDonHang.Columns.Add("TenHang");
            DTChiTietDonHang.Columns.Add("DonViTinh");
            DTChiTietDonHang.Columns.Add("SoLo");
            DTChiTietDonHang.Columns.Add("GiaBan", typeof(double));
            DTChiTietDonHang.Columns.Add("SoLuong", typeof(double));
            DTChiTietDonHang.Columns.Add("ChietKhauMatHang", typeof(double));
            DTChiTietDonHang.Columns.Add("ThanhTien", typeof(double));
            comboMaHang.DataSource = bllMatHang.GetListMatHang();
            comboMaHang.ValueMember = "MaHang";
            comboMaHang.DisplayMember = "MaHang";
            comboMaHang.Text = "";
            comboNhanVien.DataSource = bllNhanVien.GetListNhanVienBanHang();
            comboNhanVien.ValueMember = "MaNV";
            comboNhanVien.DisplayMember = "MaNV";
            comboNhanVien.Text = "";
            txtTenNV.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMaKh_TextChanged(object sender, EventArgs e)
        {
            if (bllKhachHang.GetListKhachHangByID(txtMaKh.Text).Rows.Count > 0)
            {
                txtTenKh.Text = bllKhachHang.GetListKhachHangByID(txtMaKh.Text).Rows[0]["TenKhach"].ToString();
                txtDiaChi.Text = bllKhachHang.GetListKhachHangByID(txtMaKh.Text).Rows[0]["DiaChi"].ToString();
                txtSDT.Text = bllKhachHang.GetListKhachHangByID(txtMaKh.Text).Rows[0]["SDT"].ToString();
                lblSoDiemThuong.Text = bllKhachHang.GetListKhachHangByID(txtMaKh.Text).Rows[0]["SoDiemThuong"].ToString();
                txtTenKh.ReadOnly = true;
                txtDiaChi.ReadOnly = true;
                txtSDT.ReadOnly = true;
            }
            else
            {
                txtTenKh.Text = "";
                txtDiaChi.Text = "";
                txtSDT.Text = "";
                lblSoDiemThuong.Text = "";
                txtTenKh.ReadOnly = false;
                txtDiaChi.ReadOnly = false;
                txtSDT.ReadOnly = false;
            }
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
        private void TinhTienHang()
        {
            object sum = DTChiTietDonHang.Compute("Sum(ThanhTien)", string.Empty);
            double Tong;
            double.TryParse(sum.ToString(), out Tong);
            txtTienHang.Text = Tong.ToString();
        }

        private void btnInsertTB_Click(object sender, EventArgs e)
        {
            if (txtTenHang.Text == "")
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

                        if (DTChiTietDonHang.Select("MaHang='" + comboMaHang.Text + "' and SoLo='" + comboLoHang.Text + "'").Length > 0)
            {
                if (MessageBox.Show("Mat hang " + comboMaHang.Text.Trim() + "_" + comboLoHang.Text +
                    " da co trong don hang.\n Ban co muon cap nhat lai khong?", "Thong bao", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnUpdateTB_Click(sender, e);
                }
            }
            else
            {
                DataRow row = DTChiTietDonHang.NewRow();
                row["MaHang"] = comboMaHang.Text;
                row["TenHang"] = txtTenHang.Text;
                row["DonViTinh"] = txtDVT.Text;
                row["GiaBan"] = int.Parse(txtDonGia.Text.Replace(",", ""));
                double chietkhau;
                double.TryParse(txtChietKhau.Text, out chietkhau);
                row["ChietKhauMatHang"] = chietkhau;
                row["SoLuong"] = txtSoLuong.Text;
                row["SoLo"] = comboLoHang.Text;
                thanhtien = double.Parse(txtDonGia.Text) * soluong * (100 - chietkhau) / 100;
                row["ThanhTien"] = thanhtien.ToString();
                DTChiTietDonHang.Rows.Add(row);
                dataGridView1.DataSource = DTChiTietDonHang;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells["STT"].Value = (i + 1).ToString();
                }
                //Tinh tien hang
                TinhTienHang();
                btnCLR_Click(sender, e);
            }

        }

        private void btnUpdateTB_Click(object sender, EventArgs e)
        {
            DataRow[] drr = DTChiTietDonHang.Select("MaHang='" + comboMaHang.Text + "' and SoLo='" + comboLoHang.Text + "'");

            if (drr.Length > 0)
            {
                drr[0]["GiaBan"] = int.Parse(txtDonGia.Text.Replace("'", ""));
                drr[0]["SoLuong"] = txtSoLuong.Text;
                drr[0]["ChietKhauMatHang"] = txtChietKhau.Text;
                thanhtien = double.Parse(txtDonGia.Text) * soluong * (100 - chietkhau) / 100;
                drr[0]["ThanhTien"] = thanhtien;
            }
            dataGridView1.DataSource = DTChiTietDonHang;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["STT"].Value = (i + 1).ToString();
            }
            TinhTienHang();
            btnCLR_Click(sender, e);
        }

        private void btnDeleteTB_Click(object sender, EventArgs e)
        {
            DataRow[] drr = DTChiTietDonHang.Select("MaHang='" + comboMaHang.Text + "' and SoLo='" + comboLoHang.Text + "'");

            for (int i = 0; i < drr.Length; i++)
            {
                DTChiTietDonHang.Rows.Remove(drr[i]);
                DTChiTietDonHang.AcceptChanges();
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["STT"].Value = (i + 1).ToString();
            }
            TinhTienHang();
            btnCLR_Click(sender, e);
        }

        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            comboMaHang.Text = dataGridView1.Rows[row].Cells["MaHang"].Value.ToString();
            txtTenHang.Text = dataGridView1.Rows[row].Cells["TenHang"].Value.ToString();
            txtSoLuong.Text = dataGridView1.Rows[row].Cells["SoLuong"].Value.ToString();
            comboLoHang.Text = dataGridView1.Rows[row].Cells["SoLo"].Value.ToString();
            txtDonGia.Text = string.Format("{0:0,0}", dataGridView1.Rows[row].Cells["GiaBan"].Value.ToString());
            txtChietKhau.Text = dataGridView1.Rows[row].Cells["ChietKhauMatHang"].Value.ToString();
            txtDVT.Text = dataGridView1.Rows[row].Cells["DonViTinh"].Value.ToString();
        }

        private void txtTienHang_TextChanged(object sender, EventArgs e)
        {
            double tienhang;
            double.TryParse(txtTienHang.Text, out tienhang);
            double tongphaitra = tienhang - double.Parse(txtChietkhauHD.Text) - double.Parse(txtGiaTriPhieu.Text) - double.Parse(txtGiaTriPhieu.Text);
            txtTongPhaiTra.Text = string.Format("{0:0,0}", tongphaitra);
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

        private void txtTongPhaiTra_TextChanged(object sender, EventArgs e)
        {
            double thanhtoan;
            double.TryParse(txtThanhToan.Text, out thanhtoan);
            double conlai = double.Parse(txtTongPhaiTra.Text.Replace(",", "")) - thanhtoan;
            lblconlai.Text = conlai.ToString();
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaKh.Text = "";
            comboMaHang.Text = "";
            comboNhanVien.Text = "";
            txtChietkhauHD.Text = "0";
            txtThanhToan.Text = "0";
            lblconlai.Text = "0";
            txtSoPhieuQT.Text = "";
            txtGiaTriPhieu.Text = "0";
            DTChiTietDonHang.Clear();
            dataGridView1.DataSource = DTChiTietDonHang;
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            TinhTienHang();
            GetTTDonHang();
            if (txtTenKh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên khách.");
                txtMaKh.Focus();
            }
            else if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ.");
                txtDiaChi.Focus();
            }
            else if (txtTenNV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập thông tin nhân viên.");
            }
            else if (txtDiaChiGiaoHang.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ giao hàng.");
                txtDiaChiGiaoHang.Focus();
            }
            else if (DTChiTietDonHang.Rows.Count == 0)
            {
                MessageBox.Show("Đơn hàng này không có hàng, không in được.");
            }
            else
            {
                bll.Insert(DonHang);
                if (bll.Exist(DonHang) == true)
                {
                    bllPhieuQT.UpdateState(txtSoPhieuQT.Text, DateTime.Now.Date);
                    //Lay số điểm thưởng của khách hàng, 
                    int SoDT = 0;
                    SoDT = bllKhachHang.GetDiemThuong(DonHang.MaKhach.ToString());
                    if (SoDT > 100)
                    {
                        bll.UpdateNhanPQT(DonHang.SoHoaDon);
                        bllKhachHang.UpdateDiemThuong(DonHang.MaKhach, (SoDT - 100).ToString());
                    }

                    //
                    btnHuy_Click(sender, e);
                    frmReportHoaDon frmreport = new frmReportHoaDon(lblSoHoaDon.Text);
                    frmreport.Show();
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            frmTimKiem frm = new frmTimKiem();
            frm.Show();
        }

        private void txtSoPhieuQT_TextChanged(object sender, EventArgs e)
        {
            if (bllPhieuQT.GetTriGiaPhieuQuaTang(txtSoPhieuQT.Text, DateTime.Now.Date).Rows.Count > 0)
            {
                txtGiaTriPhieu.Text = bllPhieuQT.GetTriGiaPhieuQuaTang(txtSoPhieuQT.Text, DateTime.Now.Date).Rows[0]["TriGiaPhieu"].ToString();
            }
            else
            {
                txtGiaTriPhieu.Text = "0";
            }
        }

        private void txtGiaTriPhieu_TextChanged(object sender, EventArgs e)
        {
            double tienhang;
            double.TryParse(txtTienHang.Text, out tienhang);
            double tongphaitra = tienhang - double.Parse(txtChietkhauHD.Text) - double.Parse(txtGiaTriPhieu.Text);
            txtTongPhaiTra.Text = string.Format("{0:0,0}", tongphaitra);
        }


        private void lblconlai_TextChanged(object sender, EventArgs e)
        {
            lblconlai.Text = string.Format("{0:0,0}", double.Parse(lblconlai.Text));
        }



        private void txtMaKh_Leave(object sender, EventArgs e)
        {
            if (txtTenKh.Text == "")
            {
                txtMaKh.Text = "";
            }
        }


        private void txtSoPhieuQT_Leave(object sender, EventArgs e)
        {
            if (txtGiaTriPhieu.Text == "0")
            {
                txtSoPhieuQT.Text = "";
            }
        }

        private void comboMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bllMatHang.GetMatHangById(comboMaHang.SelectedValue.ToString()).Rows.Count > 0)
            {

                //Lay thong tin Lo hang                

                if (bllMatHang.GetLoHang(comboMaHang.SelectedValue.ToString()).Rows.Count > 0)
                {
                    comboLoHang.DataSource = bllMatHang.GetLoHang(comboMaHang.SelectedValue.ToString());
                    comboLoHang.DisplayMember = "SoLo";
                }
                else
                {
                    comboLoHang.DataSource = bllMatHang.GetLoHang(comboMaHang.SelectedValue.ToString());
                    comboLoHang.DisplayMember = "SoLo";
                    MessageBox.Show("Không còn mặt hàng " + comboMaHang.SelectedValue, "Thông báo");
                    comboLoHang.Text = "";
                }
                txtTenHang.Text = bllMatHang.GetMatHangById(comboMaHang.SelectedValue.ToString()).Rows[0]["TenHang"].ToString();
                txtDVT.Text = bllMatHang.GetMatHangById(comboMaHang.SelectedValue.ToString()).Rows[0]["DonViTinh"].ToString();
                lblTonQ.Text = bllMatHang.GetMatHangById(comboMaHang.SelectedValue.ToString()).Rows[0]["TonQuay"].ToString();
                lblTonK.Text = bllMatHang.GetMatHangById(comboMaHang.SelectedValue.ToString()).Rows[0]["TonKho"].ToString();
                txtDonGia.Text = bllMatHang.GetMatHangById(comboMaHang.SelectedValue.ToString()).Rows[0]["GiaBan"].ToString();
                lblTon.Text = (int.Parse(lblTonQ.Text) + int.Parse(lblTonK.Text)).ToString();
            }

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

        private void comboNhanVien_TextChanged(object sender, EventArgs e)
        {
            if (comboNhanVien.SelectedValue != null || comboNhanVien.Text == "")
            {
                if (bllNhanVien.GetNhanVienById(comboNhanVien.SelectedValue.ToString()).Rows.Count > 0)
                {
                    txtTenNV.Text = bllNhanVien.GetNhanVienById(comboNhanVien.SelectedValue.ToString()).Rows[0]["TenNV"].ToString();
                }
            }
            else
                txtTenNV.Text = "";
        }

        private void comboNhanVien_Leave(object sender, EventArgs e)
        {
            if (comboNhanVien.SelectedValue == null)
                comboNhanVien.Text = "";
        }












        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
