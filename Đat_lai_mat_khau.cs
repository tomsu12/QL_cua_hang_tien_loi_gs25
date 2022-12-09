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
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        UserBLL bll = new UserBLL();
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btndongy_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập của bạn.", "Thông báo");
                txtuser.Focus();
            }
            else
                if (txtoldpassword.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu cũ của bạn.", "Thông báo");
                txtoldpassword.Focus();
            }
            else
                    if (txtnewpassword.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu mới của bạn.", "Thông báo");
                txtnewpassword.Focus();
            }
            else
                        if (txtnhaplai.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập lại mật khẩu mới của bạn.", "Thông báo");
                txtnhaplai.Focus();
            }
            else
                            if (txtnhaplai.Text != txtnewpassword.Text)
            {
                MessageBox.Show("Bạn nhập lại không đúng.", "Thông báo");
                txtnhaplai.Text = "";
                txtnhaplai.Focus();
            }
            else
                                if (txtuser.Text != UserLogin.TenDangNhap && txtoldpassword.Text != UserLogin.MatKhau)
            {
                MessageBox.Show("Xin lỗi, Yêu cầu của bạn không được thực thi.\nBạn đã nhập sai tài khoản đăng nhập. ");
                txtuser.Text = "";
                txtoldpassword.Text = "";
                txtnhaplai.Text = "";
                txtnewpassword.Text = "";
                txtuser.Focus();
            }
            else
            {
                bll.ChangePassword(txtnewpassword.Text);
                MessageBox.Show("Bạn đã đổi mật khẩu thành công.", "Thông báo");
                this.Close();
            }
        }

    }
}
