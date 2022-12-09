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
    public partial class frmReportHoaDon : Form
    {
        string SoHD;
        public frmReportHoaDon(string SoHoaDon)
        {
            InitializeComponent();
            this.SoHD = SoHoaDon;
        }

        private void frmReportHoaDon_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLyCuaHangGS25DataSet.HoaDonBanHang' table. You can move, or remove it, as needed.
            this.HoaDonBanHangTableAdapter.Fill(this.QuanLyCuaHangGS25DataSet.HoaDonBanHang, SoHD);

            this.reportViewer1.RefreshReport();
        }
    }
}
