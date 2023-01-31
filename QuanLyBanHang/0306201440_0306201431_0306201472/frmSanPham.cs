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
    public partial class frmSanPham : Form
    {
        string linkanh, masp, luuanh;
        SanPhamBUS SanPham_BUS = new SanPhamBUS();
        NhaCCBUS NhaCC_BUS = new NhaCCBUS();
        Constant Constant = new Constant();
        int flat = 0;
        

        public frmSanPham()
        {
            InitializeComponent();

            dgvDanhSach.AutoGenerateColumns = false;

            cboTenNCC.DataSource = NhaCC_BUS.DSNCC();
            cboTenNCC.DisplayMember = Constant.SANPHAM_CBOTENNCC_DISPLAYMEMBER;
            cboTenNCC.ValueMember = Constant.SANPHAM_CBOTENNCC_VALUEMEMBER;

            colTenNCC.DataSource = NhaCC_BUS.DSNCC();
            colTenNCC.DisplayMember = Constant.SANPHAM_CBOTENNCC_DISPLAYMEMBER;
            colTenNCC.ValueMember = Constant.SANPHAM_CBOTENNCC_VALUEMEMBER;

            dgvDanhSach.DataSource = null;
            dgvDanhSach.DataSource = SanPham_BUS.DSSP();
            cboDonVi.SelectedIndex = Constant.SANPHAM_CBODONVI_INDEX;

            btnXem.Enabled = true;

            
        }
        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvDanhSach.SelectedRows.Count != 0)
            {
                masp = dgvDanhSach.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenSP.Text = dgvDanhSach.Rows[e.RowIndex].Cells[1].Value.ToString();
                cboTenNCC.SelectedValue = int.Parse(dgvDanhSach.Rows[e.RowIndex].Cells[2].Value.ToString());
                txtDonGia.Text = dgvDanhSach.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtMoTa.Text = dgvDanhSach.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtSoLuong.Text = dgvDanhSach.Rows[e.RowIndex].Cells[5].Value.ToString();
                cboDonVi.Text = dgvDanhSach.Rows[e.RowIndex].Cells[6].Value.ToString();
                dtpNgayNhap.Text = dgvDanhSach.Rows[e.RowIndex].Cells[7].Value.ToString();
                dtpNgaySX.Text = dgvDanhSach.Rows[e.RowIndex].Cells[8].Value.ToString();
                dtpHSD.Text = dgvDanhSach.Rows[e.RowIndex].Cells[9].Value.ToString();
                picHinhAnh.Image = Image.FromFile(dgvDanhSach.Rows[e.RowIndex].Cells[10].Value.ToString());
                luuanh = dgvDanhSach.Rows[e.RowIndex].Cells[10].Value.ToString();
                btnSua.Enabled = true;
                btnXoa.Enabled = true;

            }
        }
        private void Reset()
        {
            cboTenNCC.Enabled = false;
            txtTenSP.Enabled = false;
            txtMoTa.Enabled = false;
            txtDonGia.Enabled = false;
            txtSoLuong.Text = cboTenNCC.Text  = txtTenSP.Text = txtMoTa.Text = txtDonGia.Text = string.Empty;
            cboDonVi.SelectedIndex = 0;
            dtpHSD.Value = dtpNgayNhap.Value = dtpNgaySX.Value = DateTime.Now;
            picHinhAnh.Image = null;
             
        }
        private void btnChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = Constant._HINHANH_TITELE;
            open.Filter = Constant. _HINHANH_FILTER;
            if (open.ShowDialog() == DialogResult.OK)
            {
                picHinhAnh.ImageLocation = open.FileName;
                linkanh = open.FileName.ToString();
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            flat = Constant._FLAT_1;
            txtTenSP.Text  = txtDonGia.Text = txtMoTa.Text = string.Empty;
            txtTenSP.Enabled = txtMoTa.Enabled = cboTenNCC.Enabled = cboDonVi.Enabled =  txtDonGia.Enabled = txtSoLuong.Enabled = dtpHSD.Enabled = dtpNgayNhap.Enabled = dtpNgaySX.Enabled = true;
            dtpHSD.Value = DateTime.Now;
            picHinhAnh.Image = null;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnChonFile.Enabled = true;
            btnLuu.Enabled = true;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flat = Constant._FLAT_2;
            txtTenSP.Enabled = txtMoTa.Enabled = cboTenNCC.Enabled = cboDonVi.Enabled = txtDonGia.Enabled = txtSoLuong.Enabled = dtpHSD.Enabled = dtpNgayNhap.Enabled = dtpNgaySX.Enabled = true;
            btnThem.Enabled = false;
            btnChonFile.Enabled = true;
            linkanh = luuanh;
            
            btnLuu.Enabled = true;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count != 0)
            {
                SanPham_BUS.Xoa(int.Parse(masp));
                dgvDanhSach.DataSource = SanPham_BUS.DSSP();

                MessageBox.Show(Constant._DELETE_MESS, Constant._ADD_MESS_SUCCESS_, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();

            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Reset();
            btnThem.Enabled = true;
            btnLuu.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = SanPham_BUS.TimKiem(txtTimKiem.Text);
        }

        private void btnXoaTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = string.Empty;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            frmXemBaoCao frm = new frmXemBaoCao();
            frm.DsSanPham();
            frm.ShowDialog();
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        public bool check()
        {
            if(string.IsNullOrEmpty(txtTenSP.Text))
            {
                MessageBox.Show(Constant._TXT_TENSP, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtDonGia.Text))
            {
                MessageBox.Show(Constant._TXT_DONGIA, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtMoTa.Text))
            {
                MessageBox.Show(Constant._TXT_MOTA, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(picHinhAnh == null)
            {
                MessageBox.Show(Constant._PIC_HINHANH, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }    
            if(dtpNgaySX.Value > dtpNgayNhap.Value)
            {
                MessageBox.Show(Constant._NGAYNHAP, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dtpNgaySX.Value > dtpHSD.Value)
            {
                MessageBox.Show(Constant._NGAYSX, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dtpNgayNhap.Value > dtpHSD.Value)
            {
                MessageBox.Show(Constant._HANSUDUNG, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (picHinhAnh.Image == null)
            {
                MessageBox.Show(Constant._PIC_HINHANH, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtSoLuong.Text))
            {
                MessageBox.Show(Constant._SOLUONG, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (int.Parse( txtSoLuong.Text)<=0)
            {
                MessageBox.Show(Constant._SOLUONG_CHECK, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch(flat)
            {
                case 1:
                    {
                        if(check())
                        {
                            SanPhamDTO sp = new SanPhamDTO()
                            {
                                TenSP = txtTenSP.Text,
                                SoLuong = int.Parse(txtSoLuong.Text),
                                DonGia = int.Parse(txtDonGia.Text),
                                HinhAnh = linkanh,
                                DonViTinh = cboDonVi.Text,
                                HSD = dtpHSD.Value,
                                MaNCC = int.Parse(cboTenNCC.SelectedValue.ToString()),
                                Mota = txtMoTa.Text,
                                NgayNhap = dtpNgayNhap.Value,
                                NgaySX = dtpNgaySX.Value
                            };
                            if (SanPham_BUS.Them(sp))
                            {
                                dgvDanhSach.DataSource = null;
                                dgvDanhSach.DataSource = SanPham_BUS.DSSP();

                                MessageBox.Show(Constant._ADD_MESS_SUCCESS, Constant._ADD_MESS_SUCCESS_, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            else
                                MessageBox.Show(Constant.MESS_ERROR_MA, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnThem.Enabled = true;
                        }

                    }
                    break;
                case 2:
                    {
                        if(check())
                        {
                            SanPhamDTO sp = new SanPhamDTO()
                            {
                                MaSP = int.Parse(masp),
                                TenSP = txtTenSP.Text,
                                SoLuong = int.Parse(txtSoLuong.Text),
                                DonGia = int.Parse(txtDonGia.Text),
                                HinhAnh = linkanh,
                                DonViTinh = cboDonVi.Text,
                                HSD = dtpHSD.Value,
                                MaNCC = int.Parse(cboTenNCC.SelectedValue.ToString()),
                                Mota = txtMoTa.Text,
                                NgayNhap = dtpNgayNhap.Value,
                                NgaySX = dtpNgaySX.Value
                            };
                            if (SanPham_BUS.Sua(sp))
                            {
                                dgvDanhSach.DataSource = SanPham_BUS.DSSP();

                                MessageBox.Show(Constant._FIX_MESS_SUCCESS, Constant._FIX_MESS_SUCCESS_, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show(Constant._FIX_MESS_FAIL, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                    }
                    break;
            }    
        }
    }
}
