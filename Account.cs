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
    public partial class frmAccount : Form
    {
        public frmAccount()
        {
            InitializeComponent();
        }
        UserBLL bll = new UserBLL();
        User user = new User();
        NhanVienBLL bllNhanVien = new NhanVienBLL();
        private void GetDaTa()
        {
            user.TenDangNhap = txtuser.Text;
            user.MatKhau = txtpassword.Text;
            user.MaNV = comboMaNV.SelectedValue.ToString();
            user.Role = Convert.ToInt32(comboRole.Text);

        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            comboMaNV.DataSource = bllNhanVien.GetListNhanVien();
            comboMaNV.DisplayMember = "MaNV";
            comboMaNV.ValueMember = "MaNV";
            comboMaNV.AutoCompleteSource = AutoCompleteSource.ListItems;
            //Load gridview
            GetUser();
        }
        private void GetUser()
        {
            dataGridView1.DataSource = bll.GetListUser();
        }

        private void comboMaNV_Leave(object sender, EventArgs e)
        {
            if (bllNhanVien.GetNhanVienById(comboMaNV.Text).Rows.Count == 0)
            {
                MessageBox.Show(" Không tôn tại nhân viên có mã:  " + comboMaNV.Text + " trong csdl", "Thông báo");
                comboMaNV.Text = "";
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row;
            row = e.RowIndex;
            txtuser.Text = dataGridView1.Rows[row].Cells["TenDangNhap"].Value.ToString();
            txtpassword.Text = dataGridView1.Rows[row].Cells["MatKhau"].Value.ToString();
            comboMaNV.Text = dataGridView1.Rows[row].Cells["MaNV"].Value.ToString();
            comboRole.Text = dataGridView1.Rows[row].Cells["Role"].Value.ToString();

        }

        private void btnCLR_Click(object sender, EventArgs e)
        {
            txtuser.Text = "";
            txtpassword.Text = "";
            comboMaNV.Text = "";
            comboRole.Text = "";
            txtuser.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rdoThem.Checked == true)
            {
                if (txtuser.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên tài khoản.", "Thông báo");
                    txtuser.Focus();
                }
                else
                    if (bll.ExistUser(txtuser.Text) == true)
                {
                    MessageBox.Show("Tài khoản: " + txtuser.Text + " đã được sử dụng.\nBạn phải chọn tên đăng nhập khác", "Thông báo");
                    txtuser.Text = "";
                    txtuser.Focus();
                }
                else
                        if (txtpassword.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập password.", "Thông báo");
                    txtpassword.Focus();
                }
                else
                            if (comboMaNV.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã nhân viên.", "Thông báo");
                    comboMaNV.Focus();
                }
                else
                                if (comboRole.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn role cho tài khoản.", "Thông báo");
                    comboRole.Focus();
                }
                else
                {
                    GetDaTa();
                    bll.Insert(user);
                    GetUser();
                }
            }
            if (rdoSua.Checked == true)
            {
                if (txtuser.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên đăng nhập cần sửa.", "Thông báo");
                    txtuser.Focus();
                }
                else
                {
                    GetDaTa();
                    bll.Update(user);
                    GetUser();
                }

            }
            if (rdoXoa.Checked == true)
            {
                if (txtuser.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên đăng nhập cần xóa.", "Thông báo");
                    txtuser.Focus();
                }
                else
                {
                    GetDaTa();
                    bll.Delete(user);
                    GetUser();
                }
            }
            if (rdoTimKiem.Checked == true)
            {
                GetDaTa();
                dataGridView1.DataSource = bll.Search(user);
            }
        }
    }
}
