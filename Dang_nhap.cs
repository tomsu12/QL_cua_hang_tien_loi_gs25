using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_cua_hang_tien_loi.DAO;

namespace QL_cua_hang_tien_loi
{
    public partial class Dang_nhap : Form
    {
        public Dang_nhap()
        {
            InitializeComponent();
            this.carousel1.TransitionSpeed = 0.9f;
        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Do you want to exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                Environment.Exit(-1);
            }
            else
            {
            }
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pass_TextChanged(object sender, EventArgs e)
        {
            if (pass.PlaceholderText != "Password" || pass.Text != null)
            {
                pass.PasswordChar = '●';
            }
            else if (string.IsNullOrEmpty(pass.Text) || string.IsNullOrWhiteSpace(pass.Text))
            {
                pass.PasswordChar = default(char);
            }
        }

        #region Move Form Not Need Border
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private void Dang_nhap_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void Dang_nhap_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Dang_nhap_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }
        #endregion

        private void carousel1_Click(object sender, EventArgs e)
        {
            carousel1.RotateAlways = false;
        }

        private void carousel1_DoubleClick(object sender, EventArgs e)
        {
            carousel1.RotateAlways = true;
        }
        #region Methoddddddddddddddddddddddddddddd
        public string GETID(string username)
        {
            return AccountDAO.Instance.GETID(username);
        }
        public bool Login(string username, string password)
        {
            return AccountDAO.Instance.Login(username, password);

        }
        public bool GetPhone(string Phone) // Get out the phone of user
        {
            return AccountDAO.Instance.GetPhone(Phone);
        }
        public string Getame(string username)
        {
            return AccountDAO.Instance.Getame(username);
        }
        public string GetCareer(string username)
        {
            return AccountDAO.Instance.GetCareer(username);
        }
        public Image GetImage(string username)
        {
            return AccountDAO.Instance.Images(username);
        }
        public string GetName(string username)
        {
            return AccountDAO.Instance.GetName(username);
        }
        public string getICM(string username)
        {
            return AccountDAO.Instance.GetICM(username);
        }
        bool ChecKICM(string ICM)
        {
            return AccountDAO.Instance.ICMCheck(ICM);
        }
        #endregion

        private void Dang_nhap_KeyPress(object sender, KeyPressEventArgs e) // Event when user press Enter button it will go to next if the information which user just fill in correct
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buttonsignin_Click(sender, e);
            }
        }

        private void buttonsignin_Click(object sender, EventArgs e)
        {
            string name = username.Text;
            string password = pass.Text;
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("We discovered that you have not entered emails in the box", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("We discovered that you have not entered password in the box", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (Login(name, password))
            {
                Trang_Chu main = new Trang_Chu();
                this.Hide();
                main.GetName.Text = GetName(name).ToString();
                main.GetCareer.Text = GetCareer(name).ToString();
                main.GetImage.Image = GetImage(name);
                main.GetID.Text = GETID(name).ToString();
                main.ShowDialog();

            }
            else
            {
                MessageBox.Show("The username or password was incorrect, please check again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
