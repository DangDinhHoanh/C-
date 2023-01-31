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
    public partial class frmLapHoaDon : Form
    {
        int GiuSL;
        SanPhamBUS SanPham_BUS = new SanPhamBUS();
        HoaDonBUS HoaDon_BUS = new HoaDonBUS();
        Constant Constant = new Constant();
        public frmLapHoaDon()
        {
            InitializeComponent();
            LoadSP();
        }
        private void LoadSP()
        {
            List<SanPhamDTO> list = SanPham_BUS.DSSP();
            
            foreach (var sp in list)
            {
                ilsSanPham.Images.Add(sp.MaSP.ToString(), Image.FromFile(sp.HinhAnh));
                ListViewItem item = new ListViewItem(sp.TenSP, sp.MaSP.ToString());
                item.SubItems.Add(sp.MaSP.ToString());
                item.SubItems.Add(sp.SoLuong.ToString());
                item.SubItems.Add(sp.DonViTinh.ToString());
                item.SubItems.Add(sp.DonGia.ToString());

                lvwDanhSachSP.Items.Add(item);
            }
        }
        private void lvwDanhSachSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvwDanhSachSP.SelectedItems.Count != 0)
            {
                SanPhamDTO sp = new SanPhamDTO()
                {
                    MaSP = int.Parse(lvwDanhSachSP.SelectedItems[0].SubItems[1].Text),
                    TenSP = lvwDanhSachSP.SelectedItems[0].Text,
                    SoLuong = int.Parse(lvwDanhSachSP.SelectedItems[0].SubItems[2].Text),
                    DonViTinh = lvwDanhSachSP.SelectedItems[0].SubItems[3].Text,
                    DonGia = int.Parse(lvwDanhSachSP.SelectedItems[0].SubItems[4].Text)
                };

                foreach (DataGridViewRow r in dgvDanhSachHD.Rows)
                {
                    if (r.Cells[0].Value.ToString() == sp.MaSP.ToString())
                    {
                       
                        int count = int.Parse(dgvDanhSachHD.Rows[r.Index].Cells[4].Value.ToString());
                        dgvDanhSachHD.Rows[r.Index].Cells[4].Value = count + Constant._VALUE;
                        //dgvDanhSachHD.Rows[r.Index].Cells[7].Value = int.Parse(dgvDanhSachHD.Rows[r.Index].Cells[7].Value;
                        lvwDanhSachSP.SelectedItems.Clear();
                        return;
                    }

                }

                Object[] row = new Object[]
                {
                sp.MaSP,
                sp.TenSP,
                Image.FromFile(Constant._BUTTON_PLUS),
                Image.FromFile(Constant._BUTTON_MINUS),
                1,
                sp.DonViTinh,
                sp.DonGia,
                sp.DonGia
                };

                dgvDanhSachHD.Rows.Add(row);
                lvwDanhSachSP.SelectedItems.Clear();

            }    
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            CT_HoaDonDTO[] chitiet = new CT_HoaDonDTO[dgvDanhSachHD.Rows.Count];
            int i = 0;

            
            foreach(DataGridViewRow row in dgvDanhSachHD.Rows)
            {
                GiuSL = int.Parse(SanPham_BUS.LAYSLSP(int.Parse(row.Cells[0].Value.ToString()))[0].SoLuong.ToString());
                if(int.Parse(row.Cells[4].Value.ToString()) > GiuSL)
                {
                    MessageBox.Show(string.Format(Constant._MESS, row.Index + 1),Constant._CHECK_MESS_ERROR, MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }    
                SanPhamDTO sl = new SanPhamDTO()
                {
                    MaSP = int.Parse(row.Cells[0].Value.ToString()),
                    SoLuong = int.Parse(SanPham_BUS.LAYSLSP(int.Parse(row.Cells[0].Value.ToString()))[0].SoLuong.ToString()) - int.Parse(row.Cells[4].Value.ToString()),
                };

                SanPham_BUS.SuaSL(sl);
  
                chitiet[i] = new CT_HoaDonDTO
                {
                    MaSP = int.Parse(row.Cells[0].Value.ToString()),
                    TenSP = row.Cells[1].Value.ToString(),
                    SoLuong = int.Parse(row.Cells[4].Value.ToString()),
                    DonGia = int.Parse(row.Cells[6].Value.ToString()),
                    ThanhTien = (int.Parse(row.Cells[4].Value.ToString()) * int.Parse(row.Cells[6].Value.ToString())).ToString(),
                    MaNV = frmMain.tenTK,
                    NgayLapHD = DateTime.Now

                };
                i++;
            }

            HoaDonDTO HoaDon = new HoaDonDTO
            {
                MaNV = frmMain.tenTK,
                CT_HoaDon = chitiet,
                NgayLapHD = DateTime.Now
            };
            if(HoaDon_BUS.ThemHD(HoaDon))
            {
                    MessageBox.Show(string.Format(Constant._ADD_MESS_BILL_SUCCESS, Constant._ADD_MESS_SUCCESS_, MessageBoxButtons.OK,MessageBoxIcon.Information));

            }
            dgvDanhSachHD.Rows.Clear();
            
        }

        private void dgvDanhSachHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int dem = int.Parse(dgvDanhSachHD.Rows[e.RowIndex].Cells[4].Value.ToString());
            if (e.ColumnIndex == 2)
            {
                dgvDanhSachHD.Rows[e.RowIndex].Cells[4].Value = ++dem;
            }

            if (e.ColumnIndex == 3)
            {
                if (dem == Constant._VALUE)
                    dgvDanhSachHD.Rows.Remove(dgvDanhSachHD.Rows[e.RowIndex]);
                else
                    dgvDanhSachHD.Rows[e.RowIndex].Cells[4].Value = --dem;
            }

        }

        private void dgvDanhSachHD_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(KeyPress);
            if( dgvDanhSachHD.CurrentCell.ColumnIndex == 4 )
            {
                TextBox tb = e.Control as TextBox;
                if(tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(KeyPress);
                }    
            }    
        }
        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }    
        }

        private void dgvDanhSachHD_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dgvDanhSachHD.Rows[e.RowIndex].Cells[4].Value == null || int.Parse(dgvDanhSachHD.Rows[e.RowIndex].Cells[4].Value.ToString()) < 1)
                dgvDanhSachHD.Rows[e.RowIndex].Cells[4].Value = Constant._VALUE;
   
            dgvDanhSachHD.Rows[e.RowIndex].Cells[7].Value = int.Parse(dgvDanhSachHD.Rows[e.RowIndex].Cells[4].Value.ToString()) * int.Parse(dgvDanhSachHD.Rows[e.RowIndex].Cells[6].Value.ToString());



            double sum = 0;

            foreach (DataGridViewRow r in dgvDanhSachHD.Rows)
                sum += int.Parse(dgvDanhSachHD.Rows[e.RowIndex].Cells[7].Value.ToString());

            sum = sum +  0.01 * sum;

            txtTongTien.Text = sum.ToString();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            lvwDanhSachSP.Items.Clear();
            List<SanPhamDTO> list = SanPham_BUS.TimKiemDSSP(txtTimKiem.Text);

            foreach (var sp in list)
            {
                ilsSanPham.Images.Add(sp.MaSP.ToString(), Image.FromFile(sp.HinhAnh));
                ListViewItem item = new ListViewItem(sp.TenSP, sp.MaSP.ToString());
                item.SubItems.Add(sp.MaSP.ToString());
                item.SubItems.Add(sp.SoLuong.ToString());
                item.SubItems.Add(sp.DonViTinh.ToString());
                item.SubItems.Add(sp.DonGia.ToString());

                lvwDanhSachSP.Items.Add(item);
            }
        }
    }
}
