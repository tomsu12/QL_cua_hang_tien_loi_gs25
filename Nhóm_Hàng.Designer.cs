
namespace QL_cua_hang_tien_loi
{
    partial class Nhóm_Hàng
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
            this.comboNganhHang = new System.Windows.Forms.ComboBox();
            this.MaNhomH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoSua = new System.Windows.Forms.RadioButton();
            this.rdoTimKiem = new System.Windows.Forms.RadioButton();
            this.rdoXoa = new System.Windows.Forms.RadioButton();
            this.rdoThem = new System.Windows.Forms.RadioButton();
            this.txtTenNhomH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCLR = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TenNhomH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMaNhomH = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboNganhHang
            // 
            this.comboNganhHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboNganhHang.FormattingEnabled = true;
            this.comboNganhHang.Location = new System.Drawing.Point(428, 108);
            this.comboNganhHang.Margin = new System.Windows.Forms.Padding(4);
            this.comboNganhHang.Name = "comboNganhHang";
            this.comboNganhHang.Size = new System.Drawing.Size(203, 21);
            this.comboNganhHang.TabIndex = 46;
            // 
            // MaNhomH
            // 
            this.MaNhomH.DataPropertyName = "MaNhomH";
            this.MaNhomH.HeaderText = "Mã nhóm hàng";
            this.MaNhomH.Name = "MaNhomH";
            this.MaNhomH.ReadOnly = true;
            this.MaNhomH.Width = 150;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.rdoSua);
            this.panel1.Controls.Add(this.rdoTimKiem);
            this.panel1.Controls.Add(this.rdoXoa);
            this.panel1.Controls.Add(this.rdoThem);
            this.panel1.Location = new System.Drawing.Point(2, 457);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 31);
            this.panel1.TabIndex = 45;
            // 
            // rdoSua
            // 
            this.rdoSua.AutoSize = true;
            this.rdoSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSua.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rdoSua.Location = new System.Drawing.Point(243, 6);
            this.rdoSua.Margin = new System.Windows.Forms.Padding(4);
            this.rdoSua.Name = "rdoSua";
            this.rdoSua.Size = new System.Drawing.Size(50, 20);
            this.rdoSua.TabIndex = 17;
            this.rdoSua.TabStop = true;
            this.rdoSua.Text = "Sửa";
            this.rdoSua.UseVisualStyleBackColor = true;
            // 
            // rdoTimKiem
            // 
            this.rdoTimKiem.AutoSize = true;
            this.rdoTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoTimKiem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rdoTimKiem.Location = new System.Drawing.Point(607, 4);
            this.rdoTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.rdoTimKiem.Name = "rdoTimKiem";
            this.rdoTimKiem.Size = new System.Drawing.Size(82, 21);
            this.rdoTimKiem.TabIndex = 19;
            this.rdoTimKiem.TabStop = true;
            this.rdoTimKiem.Text = "Tìm kiếm";
            this.rdoTimKiem.UseVisualStyleBackColor = true;
            // 
            // rdoXoa
            // 
            this.rdoXoa.AutoSize = true;
            this.rdoXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoXoa.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rdoXoa.Location = new System.Drawing.Point(424, 4);
            this.rdoXoa.Margin = new System.Windows.Forms.Padding(4);
            this.rdoXoa.Name = "rdoXoa";
            this.rdoXoa.Size = new System.Drawing.Size(51, 21);
            this.rdoXoa.TabIndex = 18;
            this.rdoXoa.TabStop = true;
            this.rdoXoa.Text = "Xóa";
            this.rdoXoa.UseVisualStyleBackColor = true;
            // 
            // rdoThem
            // 
            this.rdoThem.AutoSize = true;
            this.rdoThem.Checked = true;
            this.rdoThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoThem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rdoThem.Location = new System.Drawing.Point(45, 4);
            this.rdoThem.Margin = new System.Windows.Forms.Padding(4);
            this.rdoThem.Name = "rdoThem";
            this.rdoThem.Size = new System.Drawing.Size(62, 21);
            this.rdoThem.TabIndex = 16;
            this.rdoThem.TabStop = true;
            this.rdoThem.Text = "Thêm";
            this.rdoThem.UseVisualStyleBackColor = true;
            // 
            // txtTenNhomH
            // 
            this.txtTenNhomH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNhomH.Location = new System.Drawing.Point(156, 108);
            this.txtTenNhomH.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenNhomH.Name = "txtTenNhomH";
            this.txtTenNhomH.Size = new System.Drawing.Size(261, 20);
            this.txtTenNhomH.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(230, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 26);
            this.label1.TabIndex = 38;
            this.label1.Text = "DANH MỤC NHÓM HÀNG";
            // 
            // btnCLR
            // 
            this.btnCLR.Location = new System.Drawing.Point(688, 108);
            this.btnCLR.Margin = new System.Windows.Forms.Padding(4);
            this.btnCLR.Name = "btnCLR";
            this.btnCLR.Size = new System.Drawing.Size(56, 28);
            this.btnCLR.TabIndex = 43;
            this.btnCLR.Text = "CLR";
            this.btnCLR.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNhomH,
            this.TenNhomH});
            this.dataGridView1.Location = new System.Drawing.Point(2, 138);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(743, 315);
            this.dataGridView1.TabIndex = 44;
            // 
            // TenNhomH
            // 
            this.TenNhomH.DataPropertyName = "TenNhomH";
            this.TenNhomH.HeaderText = "Tên nhóm hàng";
            this.TenNhomH.Name = "TenNhomH";
            this.TenNhomH.ReadOnly = true;
            this.TenNhomH.Width = 200;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(640, 108);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(40, 28);
            this.btnOK.TabIndex = 42;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(477, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ngành hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(16, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã nhóm hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(216, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên nhóm hàng";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(2, 75);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(743, 30);
            this.panel2.TabIndex = 39;
            // 
            // txtMaNhomH
            // 
            this.txtMaNhomH.Location = new System.Drawing.Point(2, 108);
            this.txtMaNhomH.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaNhomH.Name = "txtMaNhomH";
            this.txtMaNhomH.Size = new System.Drawing.Size(151, 20);
            this.txtMaNhomH.TabIndex = 40;
            // 
            // Nhóm_Hàng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 522);
            this.Controls.Add(this.comboNganhHang);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtTenNhomH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCLR);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtMaNhomH);
            this.Name = "Nhóm_Hàng";
            this.Text = "Nhóm_Hàng";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboNganhHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhomH;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdoSua;
        private System.Windows.Forms.RadioButton rdoTimKiem;
        private System.Windows.Forms.RadioButton rdoXoa;
        private System.Windows.Forms.RadioButton rdoThem;
        private System.Windows.Forms.TextBox txtTenNhomH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCLR;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhomH;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtMaNhomH;
    }
}