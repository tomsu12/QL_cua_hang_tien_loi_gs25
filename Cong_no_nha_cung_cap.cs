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
    public partial class frmCongNoNCC : Form
    {
        public frmCongNoNCC()
        {
            InitializeComponent();
        }
        NhaCungCapBLL bllNhaCC = new NhaCungCapBLL();
        string maNCC2;
        private void frmCongNoNCC_Load(object sender, EventArgs e)
        {

            comboNhaCC.DataSource = bllNhaCC.GetListNhaCC();
            comboNhaCC.ValueMember = "MaNCC";
            comboNhaCC.DisplayMember = "TenNCC";
            dataGridView1.DataSource = bllNhaCC.GetListNhaCC();

            for (int i = 0; i < dataGridView2.RowCount; i++)
                dataGridView2.Rows[i].Cells["STT1"].Value = (i + 1).ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.Text != "")
            {
                dataGridView1.DataSource = bllNhaCC.GetNhaccById(txtMaNCC.Text);
                if (ckbDate.Checked == true)
                {
                    dataGridView2.DataSource = bllNhaCC.GetCongNoNCC(txtMaNCC.Text, dateTimeTuNgay.Text, dateTimeDenNgay.Text);
                }
                else
                    dataGridView2.DataSource = bllNhaCC.GetCongNoNCC(txtMaNCC.Text);

            }
            else
            {
                dataGridView1.DataSource = bllNhaCC.GetListNhaCC();
            }

            for (int i = 0; i < dataGridView2.RowCount; i++)
                dataGridView2.Rows[i].Cells["STT1"].Value = (i + 1).ToString();


        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //frmReportCongNoNCC frm;
            //if (ckbDate.Checked == true)
            //{
            //    frm = new frmReportCongNoNCC(maNCC2, dateTimeTuNgay.Value, dateTimeDenNgay.Value);

            //}
            //else
            //{
            //    frm = new frmReportCongNoNCC(maNCC2, DateTime.Parse("01/01/1900"), DateTime.Now.Date);

            //}

            //frm.Show();

        }

        private void dateTimeTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (ckbDate.Checked == true)
            {
                dataGridView2.DataSource = bllNhaCC.GetCongNoNCC(maNCC2, dateTimeTuNgay.Text, dateTimeDenNgay.Text);
            }
            else
                dataGridView2.DataSource = bllNhaCC.GetCongNoNCC(maNCC2);


        }

        private void dateTimeDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (ckbDate.Checked == true)
            {
                dataGridView2.DataSource = bllNhaCC.GetCongNoNCC(maNCC2, dateTimeTuNgay.Text, dateTimeDenNgay.Text);
            }
            else
                dataGridView2.DataSource = bllNhaCC.GetCongNoNCC(maNCC2);


        }
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            maNCC2 = dataGridView1.Rows[row].Cells["MaNCC"].Value.ToString();
            lblNo.Text = dataGridView1.Rows[row].Cells["No"].Value.ToString();
            lblCo.Text = dataGridView1.Rows[row].Cells["Co"].Value.ToString();
            lblNoPhaiTra.Text = (double.Parse(lblCo.Text) - double.Parse(lblNo.Text)).ToString();
            if (ckbDate.Checked == true)
            {
                dataGridView2.DataSource = bllNhaCC.GetCongNoNCC(maNCC2, dateTimeTuNgay.Text, dateTimeDenNgay.Text);
            }
            else
                dataGridView2.DataSource = bllNhaCC.GetCongNoNCC(maNCC2);

            for (int i = 0; i < dataGridView2.RowCount; i++)
                dataGridView2.Rows[i].Cells["STT1"].Value = (i + 1).ToString();

        }

        private void comboNhaCC_TextChanged(object sender, EventArgs e)
        {
            if (comboNhaCC.SelectedValue != null)
            {
                txtMaNCC.Text = comboNhaCC.SelectedValue.ToString();
            }
            else
            {
                txtMaNCC.Text = "";
            }
        }

        private void ckbDate_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbDate.Checked == true)
            {
                dataGridView2.DataSource = bllNhaCC.GetCongNoNCC(maNCC2, dateTimeTuNgay.Text, dateTimeDenNgay.Text);
            }
            else
                dataGridView2.DataSource = bllNhaCC.GetCongNoNCC(maNCC2);
        }
    }
}
