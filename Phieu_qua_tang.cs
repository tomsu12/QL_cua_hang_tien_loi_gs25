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
    public partial class frmPhieuQuaTang : Form
    {
        public frmPhieuQuaTang()
        {
            InitializeComponent();
        }
        string dd, mm, yy, hh, pp, ss;
        string SoPhieu;
        string TuSoP, DenSoP;
        PhieuQuaTangBLL bll = new PhieuQuaTangBLL();

        private void txtTriGiaPhieu_Layout(object sender, LayoutEventArgs e)
        {

        }

        PhieuQuaTang Phieu = new PhieuQuaTang();
        private void frmPhieuQuaTang_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = bll.GetListPhieuQuaTang();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rdoThem.Checked == true)
            {
                if (txtTriGiaPhieu.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập trị giá phiếu cần phát hành", "Thông báo");
                    txtTriGiaPhieu.Focus();
                }
                else
                    if (txtSoPhieu.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập số phiếu cần phát hành", "Thông báo");
                    txtSoPhieu.Focus();
                }
                else
                {

                    for (int i = 1; i <= int.Parse(txtSoPhieu.Text); i++)
                    {
                        dd = DateTime.Now.Date.Day.ToString();
                        mm = DateTime.Now.Date.Month.ToString();
                        yy = DateTime.Now.Date.Year.ToString().Substring(2, 2);
                        hh = DateTime.Now.Hour.ToString();
                        pp = DateTime.Now.Month.ToString();
                        ss = DateTime.Now.Second.ToString();
                        SoPhieu = dd + mm + yy + hh + pp + ss + String.Format("{0:000}", i);
                        Phieu.MaPhieuQuaTang = SoPhieu;
                        Phieu.TriGiaPhieu = double.Parse(txtTriGiaPhieu.Text.Replace(",", ""));
                        Phieu.HanSuDung = datetimeHanSuDung.Value;
                        bll.Insert(Phieu);
                    }
                    //Printer
                    dataGridView1.DataSource = bll.GetListPhieuQuaTang();
                    TuSoP = SoPhieu.Substring(0, 8) + String.Format("{0:000}", 1);
                    DenSoP = SoPhieu;
                    //frmReportPQuaTang frm = new frmReportPQuaTang(TuSoP, DenSoP);
                    //frm.Show();


                }

            }
            if (rdoXoa.Checked == true)
            {
                bll.Delete(txtMaPhieu.Text);
                dataGridView1.DataSource = bll.GetListPhieuQuaTang();
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            txtMaPhieu.Text = dataGridView1.Rows[row].Cells["MaPhieuQuaTang"].Value.ToString();
            txtTriGiaPhieu.Text = dataGridView1.Rows[row].Cells["TriGiaPhieu"].Value.ToString();
            datetimeHanSuDung.Text = dataGridView1.Rows[row].Cells["HanSuDung"].Value.ToString();

        }

        private void txtTriGiaPhieu_Leave(object sender, EventArgs e)
        {
            try
            {
                txtTriGiaPhieu.Text = string.Format("{0:0,0}", double.Parse(txtTriGiaPhieu.Text));
            }
            catch
            {
                MessageBox.Show("Bạn phải nhập vào một số");
                txtTriGiaPhieu.Text = "";
            }
        }

        private void btnCLR_Click(object sender, EventArgs e)
        {
            txtMaPhieu.Text = "";
            txtSoPhieu.Text = "";
            txtTriGiaPhieu.Text = "";

        }
    }
}
