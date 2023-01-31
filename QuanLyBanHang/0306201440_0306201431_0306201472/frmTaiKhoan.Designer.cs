
namespace _0306201440_0306201431_0306201472
{
    partial class frmTaiKhoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaiKhoan));
            this.pnlTaiKhoan = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.cboTaiKhoan = new System.Windows.Forms.ComboBox();
            this.lblMatKhau = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTenTK = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.colTaiKhoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlTaiKhoan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTaiKhoan
            // 
            this.pnlTaiKhoan.Controls.Add(this.btnThem);
            this.pnlTaiKhoan.Controls.Add(this.btnSua);
            this.pnlTaiKhoan.Controls.Add(this.txtMatKhau);
            this.pnlTaiKhoan.Controls.Add(this.cboTaiKhoan);
            this.pnlTaiKhoan.Controls.Add(this.lblMatKhau);
            this.pnlTaiKhoan.Controls.Add(this.lblTenTK);
            this.pnlTaiKhoan.Controls.Add(this.dgvDanhSach);
            this.pnlTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTaiKhoan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlTaiKhoan.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlTaiKhoan.Location = new System.Drawing.Point(0, 0);
            this.pnlTaiKhoan.Name = "pnlTaiKhoan";
            this.pnlTaiKhoan.ShadowDecoration.Parent = this.pnlTaiKhoan;
            this.pnlTaiKhoan.Size = new System.Drawing.Size(735, 247);
            this.pnlTaiKhoan.TabIndex = 0;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Transparent;
            this.btnThem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(169)))), ((int)(((byte)(184)))));
            this.btnThem.BorderRadius = 24;
            this.btnThem.BorderThickness = 1;
            this.btnThem.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnThem.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.CheckedState.Image")));
            this.btnThem.CheckedState.Parent = this.btnThem;
            this.btnThem.CustomImages.Parent = this.btnThem;
            this.btnThem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(169)))), ((int)(((byte)(184)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.HoverState.Parent = this.btnThem;
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.Location = new System.Drawing.Point(444, 186);
            this.btnThem.Name = "btnThem";
            this.btnThem.ShadowDecoration.Parent = this.btnThem;
            this.btnThem.Size = new System.Drawing.Size(72, 45);
            this.btnThem.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btnThem, "Thêm");
            this.btnThem.UseTransparentBackground = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.Transparent;
            this.btnSua.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(169)))), ((int)(((byte)(184)))));
            this.btnSua.BorderRadius = 15;
            this.btnSua.BorderThickness = 1;
            this.btnSua.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnSua.CheckedState.BorderColor = System.Drawing.Color.Violet;
            this.btnSua.CheckedState.FillColor = System.Drawing.Color.Aqua;
            this.btnSua.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.CheckedState.Image")));
            this.btnSua.CheckedState.Parent = this.btnSua;
            this.btnSua.CustomImages.Parent = this.btnSua;
            this.btnSua.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(169)))), ((int)(((byte)(184)))));
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.HoverState.Parent = this.btnSua;
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.Location = new System.Drawing.Point(688, 3);
            this.btnSua.Name = "btnSua";
            this.btnSua.ShadowDecoration.Parent = this.btnSua;
            this.btnSua.Size = new System.Drawing.Size(36, 34);
            this.btnSua.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btnSua, "Thoát");
            this.btnSua.UseTransparentBackground = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(525, 138);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(199, 27);
            this.txtMatKhau.TabIndex = 3;
            // 
            // cboTaiKhoan
            // 
            this.cboTaiKhoan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTaiKhoan.FormattingEnabled = true;
            this.cboTaiKhoan.Location = new System.Drawing.Point(525, 86);
            this.cboTaiKhoan.Name = "cboTaiKhoan";
            this.cboTaiKhoan.Size = new System.Drawing.Size(199, 27);
            this.cboTaiKhoan.TabIndex = 2;
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.BackColor = System.Drawing.Color.Transparent;
            this.lblMatKhau.Location = new System.Drawing.Point(444, 144);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(57, 18);
            this.lblMatKhau.TabIndex = 1;
            this.lblMatKhau.Text = "Mật khẩu";
            // 
            // lblTenTK
            // 
            this.lblTenTK.BackColor = System.Drawing.Color.Transparent;
            this.lblTenTK.Location = new System.Drawing.Point(444, 92);
            this.lblTenTK.Name = "lblTenTK";
            this.lblTenTK.Size = new System.Drawing.Size(63, 18);
            this.lblTenTK.TabIndex = 1;
            this.lblTenTK.Text = "Tài khoản";
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTaiKhoan});
            this.dgvDanhSach.Location = new System.Drawing.Point(3, 3);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.RowHeadersWidth = 51;
            this.dgvDanhSach.RowTemplate.Height = 24;
            this.dgvDanhSach.Size = new System.Drawing.Size(426, 228);
            this.dgvDanhSach.TabIndex = 0;
            // 
            // colTaiKhoan
            // 
            this.colTaiKhoan.DataPropertyName = "MaNV";
            this.colTaiKhoan.HeaderText = "Tài khoản";
            this.colTaiKhoan.MinimumWidth = 6;
            this.colTaiKhoan.Name = "colTaiKhoan";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this;
            // 
            // frmTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 247);
            this.Controls.Add(this.pnlTaiKhoan);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTaiKhoan";
            this.pnlTaiKhoan.ResumeLayout(false);
            this.pnlTaiKhoan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel pnlTaiKhoan;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.ComboBox cboTaiKhoan;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMatKhau;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTenTK;
        public Guna.UI2.WinForms.Guna2Button btnThem;
        public Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTaiKhoan;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}