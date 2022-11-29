
namespace QL_cua_hang_tien_loi
{
    partial class frmAccount
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
            this.btnCLR = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.rdoTimKiem = new System.Windows.Forms.RadioButton();
            this.rdoThem = new System.Windows.Forms.RadioButton();
            this.rdoSua = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoXoa = new System.Windows.Forms.RadioButton();
            this.Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatKhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDangNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboRole = new System.Windows.Forms.ComboBox();
            this.comboMaNV = new System.Windows.Forms.ComboBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCLR
            // 
            this.btnCLR.Location = new System.Drawing.Point(601, 2);
            this.btnCLR.Margin = new System.Windows.Forms.Padding(4);
            this.btnCLR.Name = "btnCLR";
            this.btnCLR.Size = new System.Drawing.Size(84, 28);
            this.btnCLR.TabIndex = 18;
            this.btnCLR.Text = "CLR";
            this.btnCLR.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(483, 2);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(83, 28);
            this.btnOK.TabIndex = 17;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // rdoTimKiem
            // 
            this.rdoTimKiem.AutoSize = true;
            this.rdoTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoTimKiem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rdoTimKiem.Location = new System.Drawing.Point(368, 6);
            this.rdoTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.rdoTimKiem.Name = "rdoTimKiem";
            this.rdoTimKiem.Size = new System.Drawing.Size(82, 21);
            this.rdoTimKiem.TabIndex = 9;
            this.rdoTimKiem.TabStop = true;
            this.rdoTimKiem.Text = "Tìm kiếm";
            this.rdoTimKiem.UseVisualStyleBackColor = true;
            // 
            // rdoThem
            // 
            this.rdoThem.AutoSize = true;
            this.rdoThem.Checked = true;
            this.rdoThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoThem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rdoThem.Location = new System.Drawing.Point(60, 6);
            this.rdoThem.Margin = new System.Windows.Forms.Padding(4);
            this.rdoThem.Name = "rdoThem";
            this.rdoThem.Size = new System.Drawing.Size(62, 21);
            this.rdoThem.TabIndex = 6;
            this.rdoThem.TabStop = true;
            this.rdoThem.Text = "Thêm";
            this.rdoThem.UseVisualStyleBackColor = true;
            // 
            // rdoSua
            // 
            this.rdoSua.AutoSize = true;
            this.rdoSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSua.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rdoSua.Location = new System.Drawing.Point(173, 6);
            this.rdoSua.Margin = new System.Windows.Forms.Padding(4);
            this.rdoSua.Name = "rdoSua";
            this.rdoSua.Size = new System.Drawing.Size(51, 21);
            this.rdoSua.TabIndex = 7;
            this.rdoSua.TabStop = true;
            this.rdoSua.Text = "Sửa";
            this.rdoSua.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.btnCLR);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.rdoTimKiem);
            this.panel1.Controls.Add(this.rdoThem);
            this.panel1.Controls.Add(this.rdoXoa);
            this.panel1.Controls.Add(this.rdoSua);
            this.panel1.Location = new System.Drawing.Point(20, 410);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(749, 37);
            this.panel1.TabIndex = 16;
            // 
            // rdoXoa
            // 
            this.rdoXoa.AutoSize = true;
            this.rdoXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoXoa.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rdoXoa.Location = new System.Drawing.Point(267, 6);
            this.rdoXoa.Margin = new System.Windows.Forms.Padding(4);
            this.rdoXoa.Name = "rdoXoa";
            this.rdoXoa.Size = new System.Drawing.Size(51, 21);
            this.rdoXoa.TabIndex = 8;
            this.rdoXoa.TabStop = true;
            this.rdoXoa.Text = "Xóa";
            this.rdoXoa.UseVisualStyleBackColor = true;
            // 
            // Role
            // 
            this.Role.DataPropertyName = "Role";
            this.Role.HeaderText = "Role";
            this.Role.Name = "Role";
            this.Role.ReadOnly = true;
            // 
            // MaNV
            // 
            this.MaNV.DataPropertyName = "MaNV";
            this.MaNV.HeaderText = "Mã nhân viên";
            this.MaNV.Name = "MaNV";
            this.MaNV.ReadOnly = true;
            // 
            // MatKhau
            // 
            this.MatKhau.DataPropertyName = "MatKhau";
            this.MatKhau.HeaderText = "Mật khẩu";
            this.MatKhau.Name = "MatKhau";
            this.MatKhau.ReadOnly = true;
            // 
            // TenDangNhap
            // 
            this.TenDangNhap.DataPropertyName = "TenDangNhap";
            this.TenDangNhap.HeaderText = "Tên đăng nhập";
            this.TenDangNhap.Name = "TenDangNhap";
            this.TenDangNhap.ReadOnly = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TenDangNhap,
            this.MatKhau,
            this.MaNV,
            this.Role});
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(750, 208);
            this.dataGridView1.TabIndex = 0;
            // 
            // comboRole
            // 
            this.comboRole.AutoCompleteCustomSource.AddRange(new string[] {
            "Admin",
            "Quản lý cập nhật",
            "Quản lý bán hàng",
            "Quản lý xuất nhập"});
            this.comboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRole.FormattingEnabled = true;
            this.comboRole.Items.AddRange(new object[] {
            "Admin",
            "Bán hàng",
            "Nhập hàng",
            "Quản lý TT nhân viên",
            "Quản lý TT khách hàng"});
            this.comboRole.Location = new System.Drawing.Point(543, 66);
            this.comboRole.Margin = new System.Windows.Forms.Padding(4);
            this.comboRole.Name = "comboRole";
            this.comboRole.Size = new System.Drawing.Size(160, 21);
            this.comboRole.TabIndex = 9;
            // 
            // comboMaNV
            // 
            this.comboMaNV.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboMaNV.FormattingEnabled = true;
            this.comboMaNV.Location = new System.Drawing.Point(543, 31);
            this.comboMaNV.Margin = new System.Windows.Forms.Padding(4);
            this.comboMaNV.Name = "comboMaNV";
            this.comboMaNV.Size = new System.Drawing.Size(129, 21);
            this.comboMaNV.TabIndex = 8;
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(177, 70);
            this.txtpassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(193, 20);
            this.txtpassword.TabIndex = 3;
            // 
            // txtuser
            // 
            this.txtuser.Location = new System.Drawing.Point(177, 32);
            this.txtuser.Margin = new System.Windows.Forms.Padding(4);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(193, 20);
            this.txtuser.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(475, 72);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Role:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 36);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mã nhân viên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mật khẩu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên tài khoản:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Location = new System.Drawing.Point(20, 175);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(749, 233);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách tài khoản";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboRole);
            this.groupBox1.Controls.Add(this.comboMaNV);
            this.groupBox1.Controls.Add(this.txtpassword);
            this.groupBox1.Controls.Add(this.txtuser);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(19, 61);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(751, 106);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập thông tin:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(211, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "QUẢN LÝ TÀI KHOẢN ĐĂNG NHẬP";
            // 
            // frmAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 471);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmAccount";
            this.Text = "Quản lý account";
            this.Load += new System.EventHandler(this.frmAccount_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCLR;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RadioButton rdoTimKiem;
        private System.Windows.Forms.RadioButton rdoThem;
        private System.Windows.Forms.RadioButton rdoSua;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdoXoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Role;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatKhau;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDangNhap;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboRole;
        private System.Windows.Forms.ComboBox comboMaNV;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
    }
}