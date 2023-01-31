using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0306201440_0306201431_0306201472
{
    public partial class frmTaiKhoan : Form
    {
        TaiKhoanBUS tk_BUS = new TaiKhoanBUS();
        NhanVienBUS nv_BUS = new NhanVienBUS();
        Constant Constant = new Constant();
        public frmTaiKhoan()
        {
            InitializeComponent();
            dgvDanhSach.AutoGenerateColumns = false;

            cboTaiKhoan.DataSource = nv_BUS.DSNVOTK();
            cboTaiKhoan.DisplayMember = Constant.TAIKHOAN_CBO_DISPLAYMEMBER;
            cboTaiKhoan.ValueMember = Constant.TAIKHOAN_CBO_VALUEMEMBER;

            dgvDanhSach.DataSource = tk_BUS.DSTK();

        }

        private bool check()
        {
            if(string.IsNullOrEmpty(cboTaiKhoan.Text))
            {
                MessageBox.Show(Constant.TAIKHOAN_CHECK_MESS_USER, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show(Constant.TAIKHOAN_CHECK_MESS_PASSWORD, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {

            if (check())
            {
                TaiKhoanDTO tk = new TaiKhoanDTO()
                {
                    MaNV = int.Parse(cboTaiKhoan.Text),
                    MatKhau = MaHoaMatKhau.Encrypt(txtMatKhau.Text)
                };
                if (tk_BUS.Them(tk))
                {
                    dgvDanhSach.DataSource = null;
                    dgvDanhSach.DataSource = tk_BUS.DSTK();

                    MessageBox.Show(Constant._ADD_MESS_SUCCESS, Constant._ADD_MESS_SUCCESS_, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Constant._ADD_MESS_FAIL,Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
