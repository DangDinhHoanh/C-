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
    public partial class frmChon : Form
    {
        public frmChon()
        {
            InitializeComponent();
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            if (radTatCa.Checked)
            {
                frmXemBaoCao frm = new frmXemBaoCao();
                frm.tatca();
                frm.ShowDialog();
            }
            if (radTheoChucVu.Checked)
            {
                frmXemBaoCao frm = new frmXemBaoCao();
                frm.DsNhanVien(cboChucVu.SelectedItem.ToString());
                frm.ShowDialog();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radTheoChucVu_Click(object sender, EventArgs e)
        {
            cboChucVu.SelectedIndex = 0;
        }
    }
}
