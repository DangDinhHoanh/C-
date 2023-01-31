using BUS;
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
    public partial class frmHoaDon : Form
    {
        int temp;

        SanPhamBUS sanpham_BUS = new SanPhamBUS();
        CT_HoaDonBUS CT_HoaDon_BUS = new CT_HoaDonBUS();

        public frmHoaDon()
        {
            InitializeComponent();
            dgvDanhSach.AutoGenerateColumns = false;

            dgvDanhSach.DataSource = null;

            //cboTenSP.DataSource = sanpham_BUS.DSSP();
            //cboTenSP.DisplayMember = "TenSP";
            //cboTenSP.ValueMember = "MaSP";

            //colMaSP.DataSource = sanpham_BUS.DSSP();
            //colMaSP.DisplayMember = "TenSP";
            //colMaSP.ValueMember = "MaSP";

            dgvDanhSach.DataSource = CT_HoaDon_BUS.DSCTHD();

        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDanhSach.Columns.Count!=0)
            {
                temp = int.Parse(dgvDanhSach.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtTen.Text = dgvDanhSach.Rows[e.RowIndex].Cells[1].Value.ToString();
                dtpNgayLapHD.Text = dgvDanhSach.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                txtTenSP.Text = dgvDanhSach.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtSoLuong.Text = dgvDanhSach.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtDonGia.Text = dgvDanhSach.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtChietKhau.Text = dgvDanhSach.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtThanhTien.Text = dgvDanhSach.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {      
            frmXemBaoCao frm = new frmXemBaoCao();
            frm.InHoaDon(temp);
            frm.ShowDialog();    
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = CT_HoaDon_BUS.TimKiem(txtTimKiem.Text);
        }

        private void btnXoaTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = string.Empty;
        }
    }
}
