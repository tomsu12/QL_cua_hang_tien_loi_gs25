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
    public partial class Bao_cao_theo_thang : Form
    {
        public Bao_cao_theo_thang()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
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
}
