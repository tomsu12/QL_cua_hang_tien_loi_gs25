using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            
        }

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
            tabControl1.SelectTab(tabPage1);
        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage2);
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage3);
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage4);
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage5);
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage6);
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
    }
}
