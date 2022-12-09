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
using Excel = Microsoft.Office.Interop.Excel;

namespace QL_cua_hang_tien_loi
{
    public partial class frmBaocaobanhang : Form
    {
        public frmBaocaobanhang()
        {
            InitializeComponent();
        }


        //Bao cao theo ngay
        HoaDonBanHangBLL bll = new HoaDonBanHangBLL();
        MatHangBLL bllMatHang = new MatHangBLL();
        NhanVienBLL bllNhanVien = new NhanVienBLL();
        int indexcombo = 0;

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimeDate_ValueChanged(object sender, EventArgs e)
        {
            if (indexcombo == 0)
            {
                dataGridView1.DataSource = bll.ReportBanHangTheoNgay(dateTimeTuNgay.Text, dateTimeDenNgay.Text);
            }
            if (indexcombo == 1)
            {
                dataGridView1.DataSource = bll.ReportBanHangTheoNgay(dateTimeTuNgay.Text, dateTimeDenNgay.Text, "HDQ");
            }

            if (indexcombo == 2)
            {
                dataGridView1.DataSource = bll.ReportBanHangTheoNgay(dateTimeTuNgay.Text, dateTimeDenNgay.Text, "HDL");
            }

            if (indexcombo == 3)
            {
                dataGridView1.DataSource = bll.ReportBanHangTheoNgay(dateTimeTuNgay.Text, dateTimeDenNgay.Text, "HDB");
            }
            AutoSTT();

        }

        public void AutoSTT()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["STT"].Value = i + 1;
            }
        }

        private void comboLoaiPX_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexcombo = comboLoaiPX.SelectedIndex;
            if (indexcombo == 0)
            {
                dataGridView1.DataSource = bll.ReportBanHangTheoNgay(dateTimeTuNgay.Text, dateTimeDenNgay.Text);
            }
            if (indexcombo == 1)
            {
                dataGridView1.DataSource = bll.ReportBanHangTheoNgay(dateTimeTuNgay.Text, dateTimeDenNgay.Text, "HDQ");
            }

            if (indexcombo == 2)
            {
                dataGridView1.DataSource = bll.ReportBanHangTheoNgay(dateTimeTuNgay.Text, dateTimeDenNgay.Text, "HDL");
            }

            if (indexcombo == 3)
            {
                dataGridView1.DataSource = bll.ReportBanHangTheoNgay(dateTimeTuNgay.Text, dateTimeDenNgay.Text, "HDB");
            }
            AutoSTT();
        }

        private void BtnLocDK_Click(object sender, EventArgs e)
        {
            if (indexcombo == 0)
            {
                dataGridView1.DataSource = bll.ReportBanHangTheoNgay(dateTimeTuNgay.Text, dateTimeDenNgay.Text, txtMaNV.Text, comboMatHang.Text);
            }
            if (indexcombo == 1)
            {
                dataGridView1.DataSource = bll.ReportBanHangTheoNgay(dateTimeTuNgay.Text, dateTimeDenNgay.Text, "HDQ", txtMaNV.Text, comboMatHang.Text);
            }

            if (indexcombo == 2)
            {
                dataGridView1.DataSource = bll.ReportBanHangTheoNgay(dateTimeTuNgay.Text, dateTimeDenNgay.Text, "HDL", txtMaNV.Text, comboMatHang.Text);
            }

            if (indexcombo == 3)
            {
                dataGridView1.DataSource = bll.ReportBanHangTheoNgay(dateTimeTuNgay.Text, dateTimeDenNgay.Text, "HDB", txtMaNV.Text, comboMatHang.Text);
            }
            AutoSTT();
            //comboMatHang.SelectedText = "";
            //comboNhanVien.SelectedText = "";
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int i = 0;
            int j = 0;
            xlWorkSheet.Cells[1, 2] = "Báo cáo bán hàng theo ngày";
            xlWorkSheet.Cells[2, 2] = "Ngày: " + dateTimeTuNgay.Text;
            xlWorkSheet.Cells[3, 2] = "Loại phiếu xuất: " + comboLoaiPX.Text;
            xlWorkSheet.Cells[4, 2] = "Mã nhân viên: " + txtMaNV.Text;
            xlWorkSheet.Cells[4, 3] = "Mã hàng: " + comboMatHang.SelectedValue.ToString();
            for (int k = 1; k < dataGridView1.Columns.Count + 1; k++)
            {

                xlWorkSheet.Cells[5, k] = dataGridView1.Columns[k - 1].HeaderText;

            }
            for (i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                {
                    DataGridViewCell cell = dataGridView1[j, i];
                    xlWorkSheet.Cells[i + 6, j + 1] = cell.Value;
                }
            }
            SaveFileDialog sdlg = new SaveFileDialog();
            sdlg.Filter = "Excel Files (*.xls)|*.xls;";
            if (sdlg.ShowDialog() == DialogResult.OK)
            {
                string filename = sdlg.FileName;

                xlWorkBook.SaveAs(filename, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                MessageBox.Show("You saved success!");
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
            }

        }

        private void txtMaHang_TextChanged(object sender, EventArgs e)
        {
            BtnLocDK_Click(sender, e);
        }



        private void btnXem_In_Click(object sender, EventArgs e)
        {
            //FrmReportBanHangTheoNgay frm = new FrmReportBanHangTheoNgay(dateTimeTuNgay.Text, dateTimeDenNgay.Text);
            //frm.Show();
        }

        private void comboMatHang_TextChanged(object sender, EventArgs e)
        {
            if (comboMatHang.SelectedValue != null)
            {
                if (bllMatHang.GetMatHangById(comboMatHang.SelectedValue.ToString()).Rows.Count > 0)
                    txttenhang.Text = bllMatHang.GetMatHangById(comboMatHang.SelectedValue.ToString()).Rows[0]["TenHang"].ToString();
            }
            else
                txttenhang.Text = "";
        }

        private void comboNhanVien_TextChanged(object sender, EventArgs e)
        {
            if (comboNhanVien.SelectedValue != null)
            {
                txtMaNV.Text = comboNhanVien.SelectedValue.ToString();
            }
            else
                txtMaNV.Text = "";
        }

        private void dateTimeDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (indexcombo == 0)
            {
                dataGridView1.DataSource = bll.ReportBanHangTheoNgay(dateTimeTuNgay.Text, dateTimeDenNgay.Text);
            }
            if (indexcombo == 1)
            {
                dataGridView1.DataSource = bll.ReportBanHangTheoNgay(dateTimeTuNgay.Text, dateTimeDenNgay.Text, "HDQ");
            }

            if (indexcombo == 2)
            {
                dataGridView1.DataSource = bll.ReportBanHangTheoNgay(dateTimeTuNgay.Text, dateTimeDenNgay.Text, "HDL");
            }

            if (indexcombo == 3)
            {
                dataGridView1.DataSource = bll.ReportBanHangTheoNgay(dateTimeTuNgay.Text, dateTimeDenNgay.Text, "HDB");
            }
            AutoSTT();
        }

        private void comboMatHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboMatHang.SelectedValue != null)
            {
                if (bllMatHang.GetMatHangById(comboMatHang.SelectedValue.ToString()).Rows.Count > 0)
                    txttenhang.Text = bllMatHang.GetMatHangById(comboMatHang.SelectedValue.ToString()).Rows[0]["TenHang"].ToString();
            }
            else
                txttenhang.Text = "";
        }

        private void comboMatHang_Leave(object sender, EventArgs e)
        {
            if (comboMatHang.SelectedValue == null)
                comboMatHang.Text = "";
        }

        private void comboNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboNhanVien.SelectedValue != null)
            {
                txtMaNV.Text = comboNhanVien.SelectedValue.ToString();
            }
            else
                txtMaNV.Text = "";
        }

        //Bao cao theo thang
        HoaDonBanHangBLL bllTheoThang = new HoaDonBanHangBLL();
        int index1 = 0;
        public void AutoSTTTheoThang()
        {
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                dataGridView2.Rows[i].Cells["STT1"].Value = i + 1;
            }
        }

        private void comboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (index1 == 0)
            {
                dataGridView2.DataSource = bll.ReportBanHangTheoThang(comboThang.Text, comboNam.Text);
            }
            if (index1 == 1)
            {
                dataGridView2.DataSource = bll.ReportBanHangTheoThang(comboThang.Text, comboNam.Text, "HDQ");
            }

            if (index1 == 2)
            {
                dataGridView2.DataSource = bll.ReportBanHangTheoThang(comboThang.Text, comboNam.Text, "HDL");
            }

            if (index1 == 3)
            {
                dataGridView2.DataSource = bll.ReportBanHangTheoThang(comboThang.Text, comboNam.Text, "HDB");
            }
            AutoSTTTheoThang();
        }

        private void comboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (index1 == 0)
            {
                dataGridView2.DataSource = bll.ReportBanHangTheoThang(comboThang.Text, comboNam.Text);
            }
            if (index1 == 1)
            {
                dataGridView2.DataSource = bll.ReportBanHangTheoThang(comboThang.Text, comboNam.Text, "HDQ");
            }

            if (index1 == 2)
            {
                dataGridView2.DataSource = bll.ReportBanHangTheoThang(comboThang.Text, comboNam.Text, "HDL");
            }

            if (index1 == 3)
            {
                dataGridView2.DataSource = bll.ReportBanHangTheoThang(comboThang.Text, comboNam.Text, "HDB");
            }
            AutoSTTTheoThang();
        }

        private void BtnLocDK_TT_Click(object sender, EventArgs e)
        {
            if (index1 == 0)
            {
                dataGridView2.DataSource = bll.ReportBanHangTheoThang(comboThang.Text, comboNam.Text, txtMaNV.Text, txtMaHang.Text);
            }
            if (index1 == 1)
            {
                dataGridView2.DataSource = bll.ReportBanHangTheoThang(comboThang.Text, comboNam.Text, "HDQ", txtMaNV.Text, txtMaHang.Text);
            }

            if (index1 == 2)
            {
                dataGridView2.DataSource = bll.ReportBanHangTheoThang(comboThang.Text, comboNam.Text, "HDL", txtMaNV.Text, txtMaHang.Text);
            }

            if (index1 == 3)
            {
                dataGridView2.DataSource = bll.ReportBanHangTheoThang(comboThang.Text, comboNam.Text, "HDB", txtMaNV.Text, txtMaHang.Text);
            }
            AutoSTTTheoThang();
        }

        private void comboLoaiPX_TT_SelectedIndexChanged(object sender, EventArgs e)
        {
            index1 = comboBox1.SelectedIndex;
            if (index1 == 0)
            {
                dataGridView2.DataSource = bll.ReportBanHangTheoThang(comboThang.Text, comboNam.Text);
            }
            if (index1 == 1)
            {
                dataGridView2.DataSource = bll.ReportBanHangTheoThang(comboThang.Text, comboNam.Text, "HDQ");
            }

            if (index1 == 2)
            {
                dataGridView2.DataSource = bll.ReportBanHangTheoThang(comboThang.Text, comboNam.Text, "HDL");
            }

            if (index1 == 3)
            {
                dataGridView1.DataSource = bll.ReportBanHangTheoThang(comboThang.Text, comboNam.Text, "HDB");
            }
            AutoSTTTheoThang();
        }

        private void btnExcel_TT_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int i = 0;
            int j = 0;
            xlWorkSheet.Cells[1, 2] = "Báo cáo bán hàng theo tháng";
            xlWorkSheet.Cells[2, 2] = "Tháng: " + comboThang.Text + " Năm: " + comboNam.Text;
            xlWorkSheet.Cells[3, 2] = "Loại phiếu xuất: " + comboBox1.Text;
            xlWorkSheet.Cells[4, 2] = "Mã nhân viên: " + textBox1.Text;
            xlWorkSheet.Cells[4, 3] = "Mã hàng: " + txtMaHang.Text;
            for (int k = 1; k < dataGridView2.Columns.Count + 1; k++)
            {

                xlWorkSheet.Cells[5, k] = dataGridView2.Columns[k - 1].HeaderText;

            }
            for (i = 0; i <= dataGridView2.RowCount - 1; i++)
            {
                for (j = 0; j <= dataGridView2.ColumnCount - 1; j++)
                {
                    DataGridViewCell cell = dataGridView2[j, i];
                    xlWorkSheet.Cells[i + 6, j + 1] = cell.Value;
                }
            }
            SaveFileDialog sdlg = new SaveFileDialog();
            sdlg.Filter = "Excel Files (*.xls)|*.xls;";
            if (sdlg.ShowDialog() == DialogResult.OK)
            {
                string filename = sdlg.FileName;

                xlWorkBook.SaveAs(filename, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                MessageBox.Show("You saved success!");
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
            }
        }

        private void btnXem_In_TT_Click(object sender, EventArgs e)
        {
            //FrmReportBanHangTheoThang frm = new FrmReportBanHangTheoThang(comboThang.Text, comboNam.Text);
            //frm.Show();
        }

        private void comboMatHang_TT_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue != null)
            {
                txtMaHang.Text = comboBox2.SelectedValue.ToString();
            }
            else
                txtMaHang.Text = "";
        }

        private void comboNhanVien_TT_TextChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedValue != null)
            {
                textBox1.Text = comboBox3.SelectedValue.ToString();
            }
            else
                textBox1.Text = "";
        }

        private void txtMaHang_TT_TextChanged(object sender, EventArgs e)
        {
            BtnLocDK_TT_Click(sender, e);
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            BtnLocDK_TT_Click(sender, e);
        }

        private void comboMatHang_TT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue != null)
            {
                txtMaHang.Text = comboBox2.SelectedValue.ToString();
            }
            else
                txtMaHang.Text = "";
        }

        private void comboNhanVien_TT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedValue != null)
            {
                textBox1.Text = comboBox3.SelectedValue.ToString();
            }
            else
                textBox1.Text = "";
        }

        //Bao cao theo nhan vien
        DataTable dt = new DataTable();
        public void TongDS()
        {
            object sum = dt.Compute("Sum(DoanhSo)", string.Empty);
            double Tong;
            double.TryParse(sum.ToString(), out Tong);
            txtDoanhSo.Text = Tong.ToString();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dt = bll.ReportBanHangTheoNhanVien(dateTimePicker1.Text, dateTimePicker2.Text);
            dataGridView3.DataSource = dt;
            for (int i = 0; i < dataGridView1.RowCount; i++)
                dataGridView3.Rows[i].Cells["STT"].Value = i + 1;
            TongDS();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dt = bll.ReportBanHangTheoNhanVien(dateTimePicker1.Text, dateTimePicker2.Text);
            dataGridView3.DataSource = dt;
            for (int i = 0; i < dataGridView1.RowCount; i++)
                dataGridView3.Rows[i].Cells["STT"].Value = i + 1;
            TongDS();
        }

        private void BtnLocDK_NV_Click(object sender, EventArgs e)
        {
            if (cmb_NhanVien.SelectedValue != null)
            {
                dt = bll.ReportBanHangTheoNhanVien(comboNhanVien.SelectedValue.ToString(), dateTimePicker1.Text, dateTimePicker2.Text);
                dataGridView3.DataSource = dt;
                TongDS();
            }
            else
            {
                dt = bll.ReportBanHangTheoNhanVien(dateTimePicker1.Text, dateTimePicker2.Text);
                dataGridView3.DataSource = dt;
                TongDS();
            }
            cmb_NhanVien.Text = "";

        }

        private void comboNhanVien_Leave(object sender, EventArgs e)
        {
            if (cmb_NhanVien.SelectedValue == null)
            {
                cmb_NhanVien.Text = "";
            }
        }

        private void btnThoat_NV_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcel_NV_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int i = 0;
            int j = 0;
            xlWorkSheet.Cells[1, 2] = "Báo cáo Doanh số bán hàng của nhân viên";
            xlWorkSheet.Cells[2, 2] = "Từ ngày: " + dateTimePicker1.Text + " Đến ngày:" + dateTimePicker2.Text;

            for (int k = 1; k < dataGridView3.Columns.Count + 1; k++)
            {

                xlWorkSheet.Cells[5, k] = dataGridView3.Columns[k - 1].HeaderText;

            }
            for (i = 0; i <= dataGridView3.RowCount - 1; i++)
            {
                for (j = 0; j <= dataGridView3.ColumnCount - 1; j++)
                {
                    DataGridViewCell cell = dataGridView3[j, i];
                    xlWorkSheet.Cells[i + 6, j + 1] = cell.Value;
                }
            }
            SaveFileDialog sdlg = new SaveFileDialog();
            sdlg.Filter = "Excel Files (*.xls)|*.xls;";
            if (sdlg.ShowDialog() == DialogResult.OK)
            {
                string filename = sdlg.FileName;

                xlWorkBook.SaveAs(filename, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                MessageBox.Show("You saved success!");
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
            }
        }

        private void frmBaocaobanhang_Load(object sender, EventArgs e)
        {
            //Bao cao theo ngay
            dataGridView1.DataSource = bll.ReportBanHangTheoNgay(dateTimeTuNgay.Text, dateTimeDenNgay.Text);
            lblUser.Text = UserLogin.MaNV;
            AutoSTT();
            comboMatHang.DataSource = bllMatHang.GetListMatHang();
            comboMatHang.ValueMember = "MaHang";
            comboMatHang.DisplayMember = "MaHang";
            comboMatHang.Text = "";
            comboNhanVien.DataSource = bllNhanVien.GetListNhanVien();
            comboNhanVien.ValueMember = "MaNV";
            comboNhanVien.DisplayMember = "TenNV";
            comboNhanVien.Text = "";
            txttenhang.Text = "";
            txtMaNV.Text = "";

            //Bao cao theo thang
            comboThang.Text = DateTime.Now.Month.ToString();
            comboNam.Text = DateTime.Now.Year.ToString();
            lblUser.Text = UserLogin.MaNV;
            dataGridView2.DataSource = bll.ReportBanHangTheoThang(comboThang.Text, comboNam.Text);
            comboBox2.DataSource = bllMatHang.GetListMatHang();
            comboBox2.ValueMember = "MaHang";
            comboBox2.DisplayMember = "MaHang";
            comboBox2.Text = "";
            comboBox3.DataSource = bllNhanVien.GetListNhanVien();
            comboBox3.ValueMember = "MaNV";
            comboBox3.DisplayMember = "TenNV";
            comboBox3.Text = "";
            AutoSTTTheoThang();

            //Bao cao theo nhan vien
            lblUser.Text = UserLogin.TenDangNhap;
            cmb_NhanVien.DataSource = bllNhanVien.GetListNhanVien();
            cmb_NhanVien.ValueMember = "MaNV";
            cmb_NhanVien.DisplayMember = "TenNV";
            cmb_NhanVien.Text = "";
            dt = bll.ReportBanHangTheoNhanVien(dateTimePicker1.Text, dateTimePicker2.Text);
            dataGridView3.DataSource = dt;
            for (int i = 0; i < dataGridView3.RowCount; i++)
                dataGridView3.Rows[i].Cells["STT2"].Value = i + 1;
            TongDS();
        }
    }
}
