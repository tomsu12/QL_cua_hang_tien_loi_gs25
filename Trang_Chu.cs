using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_cua_hang_tien_loi.DataLayer;
using QL_cua_hang_tien_loi.Entities;
using QL_cua_hang_tien_loi.BusinessLayer;


namespace QL_cua_hang_tien_loi
{
    public partial class Trang_Chu : Form
    {
        public Label GetName { get { return this.label2; } }
        public Label GetCareer { get { return this.label4; } }
        public Bunifu.UI.WinForms.BunifuPictureBox GetImage { get { return this.bunifuPictureBox1; } }
        public Label GetID { get { return this.label5; } }
        public Trang_Chu()
        {
            InitializeComponent();
            label5.Visible = false;

            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
        }
        frmDoiMatKhau formDoiMatKhau;
        frmAccount formAccount;
        Danh_Muc_NhanVien formdanh_Muc_NhanVien;
        frmDMKhachHang formDMKhachHang;
        frmDMNCC formDMNCC;
        frmMatHang formDMMH;
        frmPhieuNhapHang formPhieuNhap;
        frmDMHDBH formHoaDonBanHang;
        frmTimKiem formTimKiem;
        frmBaocaobanhang formBaocaobanhang;
        frmPhieuQuaTang formPhieuQuaTang;
        frmCongNoNCC formCongNoNCC;

        User us = new User();
        UserBLL bllUser = new UserBLL();

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Trang_Chu_Load(object sender, EventArgs e)
        {
            label4.Text = Dang_nhap.name;
            if(SqlHelper.Role == 2)
            {
                this.bunifuButton2.Enabled = false;
                this.bttHoadon.Enabled = false;
                this.bttDoimatkhau.Enabled = false;
                this.bttQuanlyacount.Enabled = false;
            }
            if (SqlHelper.Role == 3)
            {
                this.bunifuButton2.Enabled = false;
                this.bttPhieunhaphang.Enabled = false;
                this.bttDoimatkhau.Enabled = false;
                this.bttQuanlyacount.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void ItemDangNhap_Click(object sender, EventArgs e)
        {

        }

        private void ItemDoiMatKhau_Click(object sender, EventArgs e)
        {

        }

        private void ItemQuanLyAccount_Click(object sender, EventArgs e)
        {

        }

        private void ItemThoat_Click(object sender, EventArgs e)
        {

        }

        private void ItemDanhMucBoPhan_Click(object sender, EventArgs e)
        {

        }

        private void ItemDanhMucCV_Click(object sender, EventArgs e)
        {

        }

        private void ItemDMNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void ItemDMKhachHang_Click(object sender, EventArgs e)
        {

        }

        private void ItemDMNCC_Click(object sender, EventArgs e)
        {

        }

        private void ItemDMNganhH_Click(object sender, EventArgs e)
        {

        }

        private void ItemDMNhomH_Click(object sender, EventArgs e)
        {

        }

        private void ItemDMHangSX_Click(object sender, EventArgs e)
        {

        }

        private void ItemDMMatHang_Click(object sender, EventArgs e)
        {

        }

        private void ItemLoaiCT_Click(object sender, EventArgs e)
        {

        }

        private void ItemPhieuNhap_Click(object sender, EventArgs e)
        {

        }

        private void ItemHoaDonBanLe_Click(object sender, EventArgs e)
        {

        }

        private void ItemHoaDonBanBuon_Click(object sender, EventArgs e)
        {

        }

        private void ItemPhieuChuyenKho_Click(object sender, EventArgs e)
        {

        }

        private void ItemQuanLyGN_Click(object sender, EventArgs e)
        {

        }

        private void ItemFintNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void ItemFintKhachHang_Click(object sender, EventArgs e)
        {

        }

        private void ItemFintMatHang_Click(object sender, EventArgs e)
        {

        }

        private void ItemFintNhaCC_Click(object sender, EventArgs e)
        {

        }

        private void ItemTimKiemHoaDonBan_Click(object sender, EventArgs e)
        {

        }

        private void ItemTimKiemPhieuNhap_Click(object sender, EventArgs e)
        {

        }

        private void ItemPhieuThu_Click(object sender, EventArgs e)
        {

        }

        private void ItemDSPhieuT_Click(object sender, EventArgs e)
        {

        }

        private void ItemBaoCaoBanHangTheoNgay_Click(object sender, EventArgs e)
        {

        }

        private void ItemBaoCaoBanHangTheoThang_Click(object sender, EventArgs e)
        {

        }

        private void ItemBCBanHangTheoNV_Click(object sender, EventArgs e)
        {

        }

        private void ItemBaoCaoTheoLoNhap_Click(object sender, EventArgs e)
        {

        }

        private void Report_CongNo_NCC_Click(object sender, EventArgs e)
        {

        }

        private void Report_CongNo_KH_Click(object sender, EventArgs e)
        {

        }

        private void ItemReportKhNoQuaDM_Click(object sender, EventArgs e)
        {

        }

        private void ItemPhieuQuaTang_Click(object sender, EventArgs e)
        {

        }

        private void báoCáoCôngNợToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tpHeThong);
        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tpDanhMuc);
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tpNhapLieu);
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tpTimKiem);
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tpBaoCao);
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Do you want to logout? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                Dang_nhap newLogin = new Dang_nhap();
                this.Hide();
                newLogin.ShowDialog();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            {
                var res = MessageBox.Show("Do you want to logout? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void tabPage7_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage17_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
                formdanh_Muc_NhanVien = new Danh_Muc_NhanVien();
                this.Hide();
                formdanh_Muc_NhanVien.ShowDialog();
                this.Show();
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void bttDoimatkhau_Click(object sender, EventArgs e)
        {
            formDoiMatKhau = new frmDoiMatKhau();
            this.Hide();
            formDoiMatKhau.ShowDialog();
            // We get here when newform's DialogResult gets set
            this.Show();
        }

        private void bttQuanlyacount_Click(object sender, EventArgs e)
        {
            formAccount = new frmAccount();
            this.Hide();
            formAccount.ShowDialog();
            this.Show();
        }

        private void bttThoat_Click(object sender, EventArgs e)
        {
            {
                var res = MessageBox.Show("Do you want to logout? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    Dang_nhap newLogin = new Dang_nhap();
                    this.Hide();
                    newLogin.ShowDialog();
                    this.ShowDialog();
                }
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            
                formDMKhachHang = new frmDMKhachHang();
                this.Hide();
                formDMKhachHang.ShowDialog();
                this.Show();
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
                formDMNCC = new frmDMNCC();
                this.Hide();
                formDMNCC.ShowDialog();
                this.Show();
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
                formDMMH = new frmMatHang();
                this.Hide();
                formDMMH.ShowDialog();
                this.Show();
            
        }

        private void bttPhieunhaphang_Click(object sender, EventArgs e)
        {
            
                formPhieuNhap = new frmPhieuNhapHang();
                this.Hide();
                formPhieuNhap.ShowDialog();
                this.Show();
            
        }
        #region MoveNotNeedTaskbar
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private void Trang_Chu_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void Trang_Chu_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Trang_Chu_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }
        #endregion-

        private void bttHoadon_Click(object sender, EventArgs e)
        {
            formHoaDonBanHang = new frmDMHDBH();
            this.Hide();
            formHoaDonBanHang.ShowDialog();
            this.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            formdanh_Muc_NhanVien = new Danh_Muc_NhanVien();
            this.Hide();
            formdanh_Muc_NhanVien.ShowDialog();
            this.Show();
            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            formDMNCC = new frmDMNCC();
            this.Hide();
            formDMNCC.ShowDialog();
            this.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            formDMKhachHang = new frmDMKhachHang();
            this.Hide();
            formDMKhachHang.ShowDialog();
            this.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            formTimKiem = new frmTimKiem();
            this.Hide();
            formTimKiem.ShowDialog();
            this.Show();


        }

        private void button16_Click(object sender, EventArgs e)
        {
         
        }

        private void button17_Click(object sender, EventArgs e)
        {
        }

        private void button19_Click(object sender, EventArgs e)
        {
        }

        private void button20_Click(object sender, EventArgs e)
        {
            formBaocaobanhang = new frmBaocaobanhang();
            this.Hide();
            formBaocaobanhang.ShowDialog();
            this.Show();
        }

        private void bttTrangtruoc_Click(object sender, EventArgs e)
        {
            //this.tpHeThong();
        }

        private void bunifuButton6_Click_1(object sender, EventArgs e)
        {
            formPhieuQuaTang = new frmPhieuQuaTang();
            this.Hide();
            formPhieuQuaTang.ShowDialog();
            this.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            formCongNoNCC = new frmCongNoNCC();
            this.Hide();
            formCongNoNCC.ShowDialog();
            this.Show();
        }
    }
}
