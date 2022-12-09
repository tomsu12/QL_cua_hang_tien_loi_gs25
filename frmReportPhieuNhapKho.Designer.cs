
namespace QL_cua_hang_tien_loi
{
    partial class frmReportPhieuNhapKho
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.QuanLyCuaHangGS25DataSet = new QL_cua_hang_tien_loi.QuanLyCuaHangGS25DataSet();
            this.HoaDonNhapHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HoaDonNhapHangTableAdapter = new QL_cua_hang_tien_loi.QuanLyCuaHangGS25DataSetTableAdapters.HoaDonNhapHangTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyCuaHangGS25DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoaDonNhapHangBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1_HoaDonNhapHang";
            reportDataSource1.Value = this.HoaDonNhapHangBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QL_cua_hang_tien_loi.reportPhieuNhapKho.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // QuanLyCuaHangGS25DataSet
            // 
            this.QuanLyCuaHangGS25DataSet.DataSetName = "QuanLyCuaHangGS25DataSet";
            this.QuanLyCuaHangGS25DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // HoaDonNhapHangBindingSource
            // 
            this.HoaDonNhapHangBindingSource.DataMember = "HoaDonNhapHang";
            this.HoaDonNhapHangBindingSource.DataSource = this.QuanLyCuaHangGS25DataSet;
            // 
            // HoaDonNhapHangTableAdapter
            // 
            this.HoaDonNhapHangTableAdapter.ClearBeforeFill = true;
            // 
            // frmReportPhieuNhapKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReportPhieuNhapKho";
            this.Text = "frmReportPhieuNhapKho";
            this.Load += new System.EventHandler(this.frmReportPhieuNhapKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyCuaHangGS25DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoaDonNhapHangBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource HoaDonNhapHangBindingSource;
        private QuanLyCuaHangGS25DataSet QuanLyCuaHangGS25DataSet;
        private QuanLyCuaHangGS25DataSetTableAdapters.HoaDonNhapHangTableAdapter HoaDonNhapHangTableAdapter;
    }
}