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
using QL_cua_hang_tien_loi.DataLayer;

namespace QL_cua_hang_tien_loi
{
    public partial class frmTimKiem : Form
    {
        public frmTimKiem()
        {
            InitializeComponent();
        }

        //Tim kiem hoa don nhap hang
        HoaDonNhapHangBLL bll = new HoaDonNhapHangBLL();
        NhaCungCapBLL bllNhaCC = new NhaCungCapBLL();
        NhanVienBLL bllNhanVien = new NhanVienBLL();
        ChiTietHoaDonNHBLL bllDetailHoaDonMH = new ChiTietHoaDonNHBLL();
        string soPN, soHD;
        public void STTDatagrid()
        {
            if (dataGridView3.Rows.Count == 0)
            {
                soPN = "";
                dataGridView4.DataSource = bllDetailHoaDonMH.GetListDetailHoaDonNHBySoCT(soPN);

            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                dataGridView3.Rows[i].Cells["STT2"].Value = (i + 1).ToString();
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
                dataGridView4.Rows[i].Cells["STT3"].Value = (i + 1).ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rdoNgay.Checked == true)
            {
                dataGridView3.DataSource = bll.GetListHoaDonByDate(dtp_From.Text, dtp_To.Text);
            }
            if (rdoSoPN.Checked == true)
            {
                if (txtSoPN.Text != null)
                {
                    dataGridView3.DataSource = bll.GetListHoaDonByID(txtSoPN.Text);
                }
            }
            if (rdoMaNCC.Checked == true)
            {
                if (comboMaNCC.SelectedValue != null)
                {
                    dataGridView3.DataSource = bll.GetListHoaDonByMaNCC(comboMaNCC.SelectedValue.ToString());
                }
            }
            STTDatagrid();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXemIn_Click(object sender, EventArgs e)
        {
            frmReportPhieuNhapKho frm = new frmReportPhieuNhapKho(soPN);
            frm.Show();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            frmCapNhatPhieuNhap frm = new frmCapNhatPhieuNhap(soPN);
            frm.Show();
            this.Close();
        }

        private void dataGridView3_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            soPN = dataGridView3.Rows[row].Cells["SoHoaDon"].Value.ToString();
            dataGridView4.DataSource = bllDetailHoaDonMH.GetListDetailHoaDonNHBySoCT(soPN);
            for (int i = 0; i < dataGridView4.Rows.Count; i++)
                dataGridView4.Rows[i].Cells["STT3"].Value = (i + 1).ToString();
        }



        private void comboMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboMaNCC.SelectedValue != null)
            {
                if (bllNhaCC.GetNhaccById(comboMaNCC.SelectedValue.ToString()).Rows.Count > 0)
                {
                    //txtTenNCC.Text = bllNCC.GetNhaccById(comboMaNCC.Text).Rows[0]["TenNCC"].ToString();
                    txtDiaChi.Text = bllNhaCC.GetNhaccById(comboMaNCC.SelectedValue.ToString()).Rows[0]["DiaChi"].ToString();
                    txtSDT.Text = bllNhaCC.GetNhaccById(comboMaNCC.SelectedValue.ToString()).Rows[0]["SDT"].ToString();
                    txtMaSoThue.Text = bllNhaCC.GetNhaccById(comboMaNCC.SelectedValue.ToString()).Rows[0]["MaSoThue"].ToString();
                }
            }
            else
            {
                //txtTenNCC.Text = "";
                txtDiaChi.Text = "";
                txtSDT.Text = "";
                txtMaSoThue.Text = "";
            }

        }

        private void comboMaNCC_TextChanged(object sender, EventArgs e)
        {
            if (comboMaNCC.SelectedValue != null)
            {
                if (bllNhaCC.GetNhaccById(comboMaNCC.SelectedValue.ToString()).Rows.Count > 0)
                {
                    //txtTenNCC.Text = bllNCC.GetNhaccById(comboMaNCC.Text).Rows[0]["TenNCC"].ToString();
                    txtDiaChi.Text = bllNhaCC.GetNhaccById(comboMaNCC.SelectedValue.ToString()).Rows[0]["DiaChi"].ToString();
                    txtSDT.Text = bllNhaCC.GetNhaccById(comboMaNCC.SelectedValue.ToString()).Rows[0]["SDT"].ToString();
                    txtMaSoThue.Text = bllNhaCC.GetNhaccById(comboMaNCC.SelectedValue.ToString()).Rows[0]["MaSoThue"].ToString();
                }
            }
            else
            {
                //txtTenNCC.Text = "";
                txtDiaChi.Text = "";
                txtSDT.Text = "";
                txtMaSoThue.Text = "";
            }
        }

        private void comboMaNCC_Leave(object sender, EventArgs e)
        {
            if (comboMaNCC.SelectedValue == null)
                comboMaNCC.Text = "";
        }

        // Tim kiem hoa don ban hang
        KhachHangBLL bllKhachHang = new KhachHangBLL();
        HoaDonBanHangBLL bllBH = new HoaDonBanHangBLL();
        ChiTietHoaDonBHBLL bllDetailHoaDonBH = new ChiTietHoaDonBHBLL();
        public void STTDatagridBH()
        {
            if (dataGridView1.Rows.Count == 0)
            {
                soHD = "";
                dataGridView2.DataSource = bllDetailHoaDonBH.GetListDetailHoaDonBHBySoCT(soHD);
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                dataGridView1.Rows[i].Cells["STT"].Value = (i + 1).ToString();
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
                dataGridView2.Rows[i].Cells["STT1"].Value = (i + 1).ToString();
        }



        private void btnSearch_BH_Click(object sender, EventArgs e)
        {
            if (radioDate.Checked == true)
            {
                dataGridView1.DataSource = bllBH.GetListHoaDonByDate(dateTimeTuNgay.Text, dateTimeDenNgay.Text);
            }
            if (radioSoDonHang.Checked == true)
            {
                if (txtSoDonHang.Text != null)
                {
                    dataGridView1.DataSource = bllBH.GetListHoaDonByID(txtSoDonHang.Text);
                }
            }
            if (radioKhachHang.Checked == true)
            {
                if (cmb_KhachHang.SelectedValue != null)
                {
                    dataGridView1.DataSource = bllBH.GetListHoaDonByMaKhach(cmb_KhachHang.SelectedValue.ToString());
                }
            }
            STTDatagridBH();
        }

        private void btnXemIn_BH_Click(object sender, EventArgs e)
        {
            frmReportHoaDon frm = new frmReportHoaDon(soHD);
            frm.Show();
        }

        private void btnCapNhat_BH_Click(object sender, EventArgs e)
        {
            frmCapNhatDonHang frm = new frmCapNhatDonHang(soHD);
            frm.Show();
            this.Close();
        }

        private void radioSoDonHang_CheckedChanged(object sender, EventArgs e)
        {
            if (radioSoDonHang.Checked == true)
                txtSoDonHang.Enabled = true;
            else
                txtSoDonHang.Enabled = false;
        }

        private void cmb_KhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_KhachHang.SelectedValue != null)
            {
                if (bllKhachHang.GetListKhachHangByID(cmb_KhachHang.SelectedValue.ToString()).Rows.Count > 0)
                {
                    txt_DiaChi.Text = bllKhachHang.GetListKhachHangByID(cmb_KhachHang.SelectedValue.ToString()).Rows[0]["DiaChi"].ToString();
                    txt_SDT.Text = bllKhachHang.GetListKhachHangByID(cmb_KhachHang.SelectedValue.ToString()).Rows[0]["SDT"].ToString();
                }
            }
        }

        private void btnThoat_BH_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            soHD = dataGridView1.Rows[row].Cells["SoChungTu"].Value.ToString();
            dataGridView2.DataSource = bllDetailHoaDonBH.GetListDetailHoaDonBHBySoCT(soHD);
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                dataGridView2.Rows[i].Cells["STT1"].Value = (i + 1).ToString();
            }

        }

        private void frmTimKiem_Load(object sender, EventArgs e)
        {
            rdoNgay.Select();
            txtSoPN.Text = "";
            comboMaNCC.DataSource = bllNhaCC.GetListNhaCC();
            comboMaNCC.DisplayMember = "TenNCC";
            comboMaNCC.ValueMember = "MaNCC";
            comboMaNCC.Text = "";

            radioDate.Select();
            txtSoDonHang.Text = "";
            cmb_KhachHang.DataSource = bllKhachHang.GetListKhachHang();
            cmb_KhachHang.DisplayMember = "TenKhach";
            cmb_KhachHang.ValueMember = "MaKhach";
            cmb_KhachHang.Text = "";
        }
    }
}
