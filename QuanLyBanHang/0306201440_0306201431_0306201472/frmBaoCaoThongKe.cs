using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
namespace _0306201440_0306201431_0306201472
{
    public partial class frmBaoCaoThongKe : Form
    {
        NhanVienBUS bus = new NhanVienBUS();
        SanPhamBUS sp = new SanPhamBUS();
        NhaCCBUS nhacc = new NhaCCBUS();
        public frmBaoCaoThongKe()
        {
            InitializeComponent();
        }
// su kien laod form ha ukm
        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            if (radTatCa.Checked)
            {
                frmXemBaoCao frm = new frmXemBaoCao();
                frm.TatCaHD();
                frm.ShowDialog();
            }
            if (radTheoNgay.Checked)
            {
                frmXemBaoCao frm = new frmXemBaoCao();
                frm.TheoNgay(dtpTheoNgay.Value);
                frm.ShowDialog();
            }
            if (radNhanVien.Checked)
            {
                frmXemBaoCao frm = new frmXemBaoCao();
                frm.TheoNhanVien((NhanVienDTO)cboNhanVien.SelectedItem);
                frm.ShowDialog();
            }
            if (radSanPham.Checked)
            {
                frmXemBaoCao frm = new frmXemBaoCao();
                frm.TheoSP((SanPhamDTO)cboSanPham.SelectedItem);
                frm.ShowDialog();
            }
        }

        private void frmBaoCaoThongKe_Load(object sender, EventArgs e)
        {
            cboNhanVien.DataSource = bus.DSNV();
            cboNhanVien.DisplayMember = "HoTenNV";
            cboNhanVien.ValueMember = "MaNV";

            cboSanPham.DataSource = sp.DSSP();
            cboSanPham.DisplayMember = "TenSP";
            cboSanPham.ValueMember = "MaSP";

            //cboNhaCC.DataSource = nhacc.DSNCC();
            //cboNhaCC.DisplayMember = "TenNCC";
            //cboNhaCC.ValueMember = "MaNCC";
        }

        private void dtpTheoNgay_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
