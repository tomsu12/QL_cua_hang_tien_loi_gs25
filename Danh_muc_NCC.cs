using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_cua_hang_tien_loi.BusinessLayer;
using QL_cua_hang_tien_loi.Entities;
using Excel = Microsoft.Office.Interop.Excel;

namespace QL_cua_hang_tien_loi
{
    public partial class frmDMNCC : Form
    {
        public frmDMNCC()
        {
            InitializeComponent();
        }
        NhaCungCapBLL bll = new NhaCungCapBLL();
        NhaCungCap ncc;

        public void GetAutoID()
        {
            string mancc = bll.GetMaxNhaCCID();
            int id;
            if (mancc.Length > 0)
                mancc = mancc.Substring(4, 4);
            int.TryParse(mancc, out id);
            id = id + 1;
            txtMaNCC.Text = string.Format("{0:NCC00000}", id);

        }

        private void frmDMNCC_Load(object sender, EventArgs e)
        {
            GetAutoID();
            dataGridView1.DataSource = bll.GetListNhaCC();

        }
        private void GetDataNhaCC()
        {
            ncc = new NhaCungCap();
            ncc.MaNCC = txtMaNCC.Text;
            ncc.TenNCC = txtTenNCC.Text;
            ncc.DiaChi = txtDiaChi.Text;
            ncc.SDT = txtSDT.Text;
            ncc.SoFax = txtSoFax.Text;
            ncc.SoTaiKhoan = txtTaiKhoan.Text;
            ncc.MaSoThue = txtMaSoThue.Text;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            GetDataNhaCC();
            if (rdoThem.Checked == true)
            {
                if (txtMaNCC.Text != "")
                {
                    bll.Insert(ncc);
                    dataGridView1.DataSource = bll.GetListNhaCC();
                    btnCLR_Click(sender, e);
                }
                else
                {
                    if (MessageBox.Show("Chưa nhập mã nhà cung cấp.", "Thông báo", MessageBoxButtons.OK) == DialogResult.OK)
                        GetAutoID();

                }

            }
            if (rdoSua.Checked == true)
            {
                bll.Update(ncc);
                dataGridView1.DataSource = bll.GetListNhaCC();
                btnCLR_Click(sender, e);
            }
            if (rdoXoa.Checked == true)
            {
                bll.Delete(ncc);
                dataGridView1.DataSource = bll.GetListNhaCC();
                btnCLR_Click(sender, e);
            }
            if (rdoTimKiem.Checked == true)
            {
                dataGridView1.DataSource = bll.Search(ncc);
            }

        }

        private void btnCLR_Click(object sender, EventArgs e)
        {
            GetAutoID();
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtSoFax.Text = "";
            txtTaiKhoan.Text = "";
            txtMaSoThue.Text = "";
            txtTenNCC.Focus();
            txtNo.Text = "0";
            txtCo.Text = "0";
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            txtMaNCC.Text = dataGridView1.Rows[row].Cells["MaNCC"].Value.ToString();
            txtTenNCC.Text = dataGridView1.Rows[row].Cells["TenNCC"].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[row].Cells["DiaChi"].Value.ToString();
            txtSDT.Text = dataGridView1.Rows[row].Cells["SDT"].Value.ToString();
            txtSoFax.Text = dataGridView1.Rows[row].Cells["SoFax"].Value.ToString();
            txtMaSoThue.Text = dataGridView1.Rows[row].Cells["MaSoThue"].Value.ToString();
            txtTaiKhoan.Text = dataGridView1.Rows[row].Cells["SoTaiKhoan"].Value.ToString();
            txtNo.Text = dataGridView1.Rows[row].Cells["No"].Value.ToString();
            txtCo.Text = dataGridView1.Rows[row].Cells["Co"].Value.ToString();
        }

        private void rdoTimKiem_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTimKiem.Checked == true)
            {
                txtMaNCC.ReadOnly = false;
                txtMaNCC.Text = "";
            }
            else
                txtMaNCC.ReadOnly = true;
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
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
            for (int k = 1; k < dataGridView1.Columns.Count + 1; k++)
            {

                xlWorkSheet.Cells[1, k] = dataGridView1.Columns[k - 1].HeaderText;

            }
            for (i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                {
                    DataGridViewCell cell = dataGridView1[j, i];
                    xlWorkSheet.Cells[i + 2, j + 1] = cell.Value;
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
    }
}
