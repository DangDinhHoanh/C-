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
using BUS;
using Microsoft.Reporting.WinForms;

namespace _0306201440_0306201431_0306201472
{
    public partial class frmXemBaoCao : Form
    {
        SanPhamBUS sp = new SanPhamBUS();
        CT_HoaDonBUS cthd = new CT_HoaDonBUS();
        NhanVienBUS nhanVien = new NhanVienBUS();
        public frmXemBaoCao()
        {
            InitializeComponent();
        }

        private void frmXemBaoCao_Load(object sender, EventArgs e)
        {

            this.rptXemBaoCao.RefreshReport();
        }

        public void TatCaHD()
        {
            List<CT_HoaDonDTO> lst = cthd.DSCTHD();

            rptXemBaoCao.LocalReport.ReportEmbeddedResource = "_0306201440_0306201431_0306201472.rptTatCaHoaDon.rdlc";
            rptXemBaoCao.LocalReport.DataSources.Add(new ReportDataSource("DataSetHoaDon", lst));

            this.rptXemBaoCao.RefreshReport();
        }


        public void InHoaDon(int maHD)
        {
            List<CT_HoaDonDTO> lst = cthd.InHoaDon(maHD);

            rptXemBaoCao.LocalReport.ReportEmbeddedResource = "_0306201440_0306201431_0306201472.rptInHoaDon.rdlc";
            rptXemBaoCao.LocalReport.DataSources.Add(new ReportDataSource("DataSetInHoaDon", lst));

            this.rptXemBaoCao.RefreshReport();
        }

        public void TheoNgay(DateTime date)
        {
            List<CT_HoaDonDTO> lst = cthd.TheoNgay(date);
            rptXemBaoCao.LocalReport.ReportEmbeddedResource = "_0306201440_0306201431_0306201472.rptTheoNgay.rdlc";
            rptXemBaoCao.LocalReport.DataSources.Add(new ReportDataSource("DataSetTheoNgay", lst));
            rptXemBaoCao.LocalReport.SetParameters(new ReportParameter("paTheoNgay",date.ToString()));

            this.rptXemBaoCao.RefreshReport();
        }

        public void TheoNhanVien(NhanVienDTO nv)
        {
            List<CT_HoaDonDTO> lst = cthd.TheoTen(nv);
            rptXemBaoCao.LocalReport.ReportEmbeddedResource = "_0306201440_0306201431_0306201472.rptTheoTen.rdlc";
            rptXemBaoCao.LocalReport.DataSources.Add(new ReportDataSource("DataSetTheoTen", lst));
            rptXemBaoCao.LocalReport.SetParameters(new ReportParameter("paNhanVien", nv.HoTenNV.ToString()));

            this.rptXemBaoCao.RefreshReport();
        }

        public void TheoSP(SanPhamDTO sp)
        {
            List<CT_HoaDonDTO> lst = cthd.TheoSP(sp);
            rptXemBaoCao.LocalReport.ReportEmbeddedResource = "_0306201440_0306201431_0306201472.rptTheoSanPham.rdlc";
            rptXemBaoCao.LocalReport.DataSources.Add(new ReportDataSource("DataSetTheoSP", lst));
            rptXemBaoCao.LocalReport.SetParameters(new ReportParameter("paSanPham", sp.TenSP.ToString()));

            this.rptXemBaoCao.RefreshReport();
        }

        public void DsNhanVien(string nv)
        {
            List<NhanVienDTO> lst = nhanVien.DSTheoChucVu(nv);
            rptXemBaoCao.LocalReport.ReportEmbeddedResource = "_0306201440_0306201431_0306201472.rptDSTaiKhoan.rdlc";
            rptXemBaoCao.LocalReport.DataSources.Add(new ReportDataSource("DataSetNhanVien", lst));
            rptXemBaoCao.LocalReport.SetParameters(new ReportParameter("paChucVu",nv));

            this.rptXemBaoCao.RefreshReport();
        }

        public void tatca()
        {
            List<NhanVienDTO> lst = nhanVien.DSNV();
            rptXemBaoCao.LocalReport.ReportEmbeddedResource = "_0306201440_0306201431_0306201472.rptTatCaNhanVien.rdlc";
            rptXemBaoCao.LocalReport.DataSources.Add(new ReportDataSource("DataSetTatCaNV", lst));

            this.rptXemBaoCao.RefreshReport();
        }
        public void DsSanPham()
        {
            List<SanPhamDTO> lst = sp.DSSP();
            rptXemBaoCao.LocalReport.ReportEmbeddedResource = "_0306201440_0306201431_0306201472.rptSanPham.rdlc";
            rptXemBaoCao.LocalReport.DataSources.Add(new ReportDataSource("DataSetSanPham", lst));

            this.rptXemBaoCao.RefreshReport();
        }
    }
}
