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
    
    public partial class frmDangNhap : Form
    {
        frmMain frm = new frmMain();
        TaiKhoanBUS tk_bus = new TaiKhoanBUS();

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtTaiKhoan.Text) || (string.IsNullOrEmpty(txtMatKhau.Text)))
            {
                MessageBox.Show("Nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
            else
            {
                TaiKhoanDTO tk = new TaiKhoanDTO
                {
                    MaNV = int.Parse(txtTaiKhoan.Text),
                    MatKhau = MaHoaMatKhau.Encrypt( txtMatKhau.Text)
                };
                if(tk_bus.KTRA_DN(tk))
                {

                    frm.lblTenNhanVien.Text = txtTaiKhoan.Text;
                    frmMain.tenTK = int.Parse(frm.lblTenNhanVien.Text);
                    if (frm.lblTenNhanVien.Text.Contains("2001"))
                    {
                        frm.btnNhanVien.Enabled = false;
                        frm.btnNCC.Enabled = false;
                        frm.btnThongKe.Enabled = false;
                        frm.btnSanPham.Enabled = false;
                    }
                        
                    frm.ShowDialog();
                    this.Hide();
                }    
                else
                    MessageBox.Show("Tài khoản sai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void txtTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}
