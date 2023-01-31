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
    public partial class frmNhaCungCap : Form
    {
        int mancc;
        NhaCCBUS NhaCC_BUS = new NhaCCBUS();
        SanPhamBUS sp_BUS = new SanPhamBUS();
        Constant Constant = new Constant();
        int flat = 0;
        public frmNhaCungCap()
        {
            InitializeComponent();
            dgvDanhSach.DataSource = null;
            dgvDanhSach.DataSource = NhaCC_BUS.DSNCC();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            flat = 2;
            txtTenNCC.Enabled = txtDiaChi.Enabled = txtDienThoai.Enabled = txtEmail.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            flat = 1;
            txtTenNCC.Enabled = txtEmail.Enabled = txtDienThoai.Enabled = txtDiaChi.Enabled = true;
            btnLuu.Enabled = true;
        }
        private bool check()
        {
            if(string.IsNullOrEmpty(txtTenNCC.Text))
            {
                MessageBox.Show(Constant._TXT_TENNCC, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show(Constant._TXT_EMAIL, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtDienThoai.Text))
            {
                MessageBox.Show(Constant._TXT_SDT, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show(Constant._TXT_DIACHI, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!txtEmail.Text.Contains((Constant._EMAIL_FULL)))
            {
                MessageBox.Show(Constant._EMAIL, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtDienThoai.Text.Length > 10 || txtDienThoai.Text.Length < 10)
            {
                MessageBox.Show(Constant._CHECK_SDT, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            NhaCCDTO nhacc = new NhaCCDTO()
                            {
                                TenNCC = txtTenNCC.Text,
                                DiaChi = txtDiaChi.Text,
                                Email = txtEmail.Text,
                                DienThoai = txtDienThoai.Text
                            };
                            if (NhaCC_BUS.Them(nhacc))
                            {
                                dgvDanhSach.DataSource = null;
                                dgvDanhSach.DataSource = NhaCC_BUS.DSNCC();

                                MessageBox.Show(Constant._ADD_MESS_SUCCESS, Constant._ADD_MESS_SUCCESS_, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show(Constant._ADD_MESS_FAIL, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }    

                    }
                    break;
                case 2:
                    {
                        if(check())
                        {
                            NhaCCDTO nhacc = new NhaCCDTO()
                            {
                                MaNCC = mancc,
                                TenNCC = txtTenNCC.Text,
                                DiaChi = txtDiaChi.Text,
                                DienThoai = txtDienThoai.Text,
                                Email = txtEmail.Text,
                            };
                            if (NhaCC_BUS.Sua(nhacc))
                            {
                                dgvDanhSach.DataSource = NhaCC_BUS.DSNCC();
                                MessageBox.Show(Constant._FIX_MESS_SUCCESS, Constant._FIX_MESS_SUCCESS_, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show(Constant._FIX_MESS_FAIL, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }    

                    }
                    break;

            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDanhSach.Columns.Count!=0)
            {
                mancc = int.Parse(dgvDanhSach.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtTenNCC.Text = dgvDanhSach.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDiaChi.Text = dgvDanhSach.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDienThoai.Text = dgvDanhSach.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtEmail.Text = dgvDanhSach.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            btnSua.Enabled = btnXoa.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count != 0)
            {

                if(sp_BUS.KTRANCC(mancc).Count != 0)
                {
                    MessageBox.Show(Constant._CHECK_NHANCC, Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
                else
                {
                    if(NhaCC_BUS.Xoa(mancc))
                    {
                        dgvDanhSach.DataSource = NhaCC_BUS.DSNCC();

                        MessageBox.Show(Constant._DELETE_MESS, Constant._DETELE_MESS_, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }    

            }
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = NhaCC_BUS.TimKiem(txtTimKiem.Text);
        }

        private void btnXoaTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = string.Empty;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            txtDiaChi.Text = txtDienThoai.Text = txtEmail.Text = txtTenNCC.Text = string.Empty;
            txtTenNCC.Enabled = txtEmail.Enabled = txtDienThoai.Enabled = txtDiaChi.Enabled = false;

            btnSua.Enabled = btnXoa.Enabled = false;

        }
    }
}
