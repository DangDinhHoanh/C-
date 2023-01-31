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
using System.Drawing.Imaging;
using System.IO;
using DTO;

namespace _0306201440_0306201431_0306201472
{
    public partial class frmNhanVien : Form
    {
        string linkanh, luuha;
        int flat = 0;
        NhanVienBUS NhanVien_BUS = new NhanVienBUS();
        Constant Constant = new Constant();

        public frmNhanVien()
        {
            InitializeComponent();

            dgvDanhSach.AutoGenerateColumns = false;

            dgvDanhSach.DataSource = NhanVien_BUS.DSNV();
            btnIn.Enabled = true;
        }
        string manv_;

            private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvDanhSach.SelectedRows.Count != 0)
            {
                manv_ = txtMaNV.Text = dgvDanhSach.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTen.Text = dgvDanhSach.Rows[e.RowIndex].Cells[1].Value.ToString();
                cboGioiTinh.Text = dgvDanhSach.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtCMND.Text = dgvDanhSach.Rows[e.RowIndex].Cells[3].Value.ToString();
                dtpNgaySinh.Value = DateTime.Parse(dgvDanhSach.Rows[e.RowIndex].Cells[4].Value.ToString());
                txtDiaChi.Text = dgvDanhSach.Rows[e.RowIndex].Cells[5].Value.ToString(); 
                txtDT.Text = dgvDanhSach.Rows[e.RowIndex].Cells[6].Value.ToString(); 
                txtLuong.Text = dgvDanhSach.Rows[e.RowIndex].Cells[7].Value.ToString();
                cboChucVu.Text = dgvDanhSach.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtEmail.Text = dgvDanhSach.Rows[e.RowIndex].Cells[9].Value.ToString();
                picHinhAnh.Image = Image.FromFile(dgvDanhSach.Rows[e.RowIndex].Cells[10].Value.ToString());
                luuha = dgvDanhSach.Rows[e.RowIndex].Cells[10].Value.ToString();
                btnSua.Enabled = true;
                btnXoa.Enabled = true;

            }
        }
        public void Reset()
        {
            txtMaNV.Text = txtTen.Text = txtLuong.Text = txtEmail.Text = txtDT.Text = txtDiaChi.Text = txtCMND.Text = string.Empty;
            dtpNgaySinh.Value = DateTime.Now;
            cboGioiTinh.SelectedIndex = 1;
            cboChucVu.Text = null;
            picHinhAnh.Image = null;
        }
        private void btnChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = Constant._HINHANH_TITELE;
            open.Filter = Constant._HINHANH_FILTER;
            if(open.ShowDialog() == DialogResult.OK)
            {
                picHinhAnh.ImageLocation = open.FileName;
                linkanh = open.FileName.ToString();
            }    
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            flat = Constant._FLAT_1;
            btnChonFile.Enabled = btnLuu.Enabled = btnThem.Enabled = txtLuong.Enabled = txtCMND.Enabled = txtDT.Enabled = txtDiaChi.Enabled = txtEmail.Enabled = txtTen.Enabled = cboChucVu.Enabled = cboGioiTinh.Enabled = dtpNgaySinh.Enabled = true;

            btnXoa.Enabled = btnSua.Enabled = false;

            linkanh = luuha;

            cboGioiTinh.SelectedIndex =Constant._VALUE;

            picHinhAnh.Image = null;

            Reset();

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            flat = Constant._FLAT_2;
            btnLuu.Enabled = btnChonFile.Enabled = txtLuong.Enabled = txtCMND.Enabled = txtDT.Enabled = txtDiaChi.Enabled = txtEmail.Enabled = txtTen.Enabled = cboGioiTinh.Enabled = dtpNgaySinh.Enabled = true;

            cboChucVu.Enabled = btnXoa.Enabled = btnThem.Enabled = false;

            linkanh = luuha;
            
        }
        public bool Check()
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show(Constant._TXT_MANV, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(string.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show(Constant._TXT_TENNV, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtCMND.Text))
            {
                MessageBox.Show(Constant._TXT_CMND, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtDT.Text))
            {
                MessageBox.Show(Constant._TXT_SDT, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (DateTime.Now.Year - dtpNgaySinh.Value.Year < 18)
            {
                MessageBox.Show(Constant._TXT_TUOI, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show(Constant._TXT_DIACHI, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show(Constant._TXT_EMAIL, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtLuong.Text))
            {
                MessageBox.Show(Constant._TXT_LUONG, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(cboChucVu.SelectedValue != null)
            {
                MessageBox.Show(Constant._CBO_CHUCVU, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }   
            if(picHinhAnh.Image == null)
            {
                MessageBox.Show(Constant._PIC_HINHANH, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!txtEmail.Text.Contains(Constant._EMAIL_FULL))
            {
                MessageBox.Show(Constant._EMAIL, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtDT.Text.Length > 10 || txtDT.Text.Length < 10)
            {
                MessageBox.Show(Constant._CHECK_SDT, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtCMND.Text.Length != 12 )
            {
                MessageBox.Show(Constant._CHECK_CMND, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch (flat)
            {
                case 1:
                    {
                        if(Check())
                        {
                            NhanVienDTO nv = new NhanVienDTO()
                            {
                                MaNV = int.Parse(txtMaNV.Text),
                                HoTenNV = txtTen.Text,
                                GioiTinh = cboGioiTinh.Text,
                                CCCD = txtCMND.Text,
                                NgaySinh = dtpNgaySinh.Value,
                                DiaChi = txtDiaChi.Text,
                                DienThoai = txtDT.Text,
                                ChucVu = cboChucVu.Text,
                                HinhAnh = linkanh,
                                Email = txtEmail.Text,
                                Luong = txtLuong.Text

                            };
                            if (NhanVien_BUS.Them(nv))
                            {
                                dgvDanhSach.DataSource = null;
                                dgvDanhSach.DataSource = NhanVien_BUS.DSNV();

                                MessageBox.Show(Constant._ADD_MESS_SUCCESS, Constant._ADD_MESS_SUCCESS_, MessageBoxButtons.OK, MessageBoxIcon.Information);


                            }
                            else
                                MessageBox.Show(Constant._ADD_MESS_FAIL, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnThem.Enabled = true;
                            btnSua.Enabled = false;
                        }

                    }
                    break;
                case 2:
                    {
                        picHinhAnh.Image = Image.FromFile(linkanh);
                        if(Check())
                        {
                            NhanVienDTO nv = new NhanVienDTO()
                            {
                                MaNV = int.Parse(txtMaNV.Text),
                                HoTenNV = txtTen.Text,
                                GioiTinh = cboGioiTinh.Text,
                                CCCD = txtCMND.Text,
                                NgaySinh = dtpNgaySinh.Value,
                                DiaChi = txtDiaChi.Text,
                                DienThoai = txtDT.Text,
                                ChucVu = cboChucVu.Text,
                                HinhAnh = linkanh,
                                Email = txtEmail.Text,
                                Luong = txtLuong.Text

                            };
                            if (NhanVien_BUS.Sua(nv))
                            {
                                dgvDanhSach.DataSource = NhanVien_BUS.DSNV();
                                MessageBox.Show(Constant._FIX_MESS_SUCCESS, Constant._FIX_MESS_SUCCESS_, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            else

                                MessageBox.Show(Constant._FIX_MESS_FAIL, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                    }
                    break;
            }

        }

        private void txtMaNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void cboChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                if (cboChucVu.SelectedIndex == 0)
                {
                    txtMaNV.Text = string.Format("1001{0}", (NhanVien_BUS.DSNV().Count + 1).ToString(Constant._MANV));
                }
                else
                {
                    txtMaNV.Text = string.Format("2001{0}", (NhanVien_BUS.DSNV().Count + 1).ToString(Constant._MANV));
                }
               

            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count != 0)
            {
                if(frmMain.tenTK == int.Parse(txtMaNV.Text))
                {
                    MessageBox.Show(Constant._DENY, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
                else
                {
                    NhanVien_BUS.Xoa(int.Parse(txtMaNV.Text));
                    dgvDanhSach.DataSource = NhanVien_BUS.DSNV();

                    MessageBox.Show(Constant._DELETE_MESS, Constant._DETELE_MESS_, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }    

            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            
            dgvDanhSach.DataSource = NhanVien_BUS.TimKiem(txtTimKiem.Text);
        }

        private void txtDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            frmTaiKhoan taiKhoan = new frmTaiKhoan();

            taiKhoan.Show();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmChon frm = new frmChon();
            frm.ShowDialog();
        }

        private void txtLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void btnXoaTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = string.Empty;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Reset();
            btnThem.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled = btnLuu.Enabled = false;
            btnChonFile.Enabled = btnLuu.Enabled = txtLuong.Enabled = txtCMND.Enabled = txtDT.Enabled = txtDiaChi.Enabled = txtEmail.Enabled = txtTen.Enabled = cboChucVu.Enabled = cboGioiTinh.Enabled = dtpNgaySinh.Enabled = false;
        }
    }
}
