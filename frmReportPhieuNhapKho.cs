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
    public partial class frmReportPhieuNhapKho : Form
    {
        string SoPhieu;
        public frmReportPhieuNhapKho(string SoPhieuNhap)
        {
            InitializeComponent();
            this.SoPhieu = SoPhieuNhap;
        }

        private void frmReportPhieuNhapKho_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLyCuaHangGS25DataSet.HoaDonNhapHang' table. You can move, or remove it, as needed.
            this.HoaDonNhapHangTableAdapter.Fill(this.QuanLyCuaHangGS25DataSet.HoaDonNhapHang, SoPhieu);

            this.reportViewer1.RefreshReport();
        }
    }
}
