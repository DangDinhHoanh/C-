using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
namespace _0306201440_0306201431_0306201472
{
    public partial class frmMain : Form
    {
        Constant Constant = new Constant();
        public static int tenTK;
        public frmMain()
        {
            InitializeComponent();

        }
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = Constant.TRANGCHU_VAR_FALSE;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(childForm);
            pnlMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void addUserControl(UserControl uc)
        {
            pnlTieuDe.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            pnlTieuDe.Controls.Add(uc);
        }
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhanVien());
            uscNhanVien uC_ = new uscNhanVien();
            addUserControl(uC_);

        }
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmSanPham());
            uscSanPham uC_ = new uscSanPham();
            addUserControl(uC_);
        }
        private void btnNCC_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhaCungCap());
            uscNhaCungCap uC_ = new uscNhaCungCap();
            addUserControl(uC_);
        }
        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmHoaDon());
            uscHoaDon uC_ = new uscHoaDon();
            addUserControl(uC_);

        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmDangNhap dangNhap = new frmDangNhap();
            
            dangNhap.Show();
            this.Hide();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmBaoCaoThongKe());
            uscBaoCaoThongKe uC_ = new uscBaoCaoThongKe();
            addUserControl(uC_);
        }

        private void btnLapHoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmLapHoaDon());
            uscLapHoaDon uC_ = new uscLapHoaDon();
            addUserControl(uC_);
        }
    }
}
