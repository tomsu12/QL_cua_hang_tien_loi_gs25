using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_cua_hang_tien_loi.Entities;
using QL_cua_hang_tien_loi.BusinessLayer;

namespace QL_cua_hang_tien_loi
{
    public partial class Dang_nhap : Form
    {
        public static string name = "";
        public Dang_nhap()
        {
            InitializeComponent();
            this.carousel1.TransitionSpeed = 0.9f;
        }

        UserBLL bllUser = new UserBLL();

        private void buttonsignin_Click(object sender, EventArgs e)
        {
            name = username.Text;
            User us = new User();
            us.TenDangNhap = username.Text;
            us.MatKhau = pass.Text;
            if(bllUser.ExistUser(us) == true)
            {
                MessageBox.Show("Đăng nhập thành công!");
                Trang_Chu frm = new Trang_Chu();
                this.Hide();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Bạn đã nhập sai tên đăng nhập hoặc mật khẩu!\n Mời bạn đăng nhập lại");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
