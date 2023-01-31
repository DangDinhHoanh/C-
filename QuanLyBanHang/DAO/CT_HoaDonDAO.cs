using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CT_HoaDonDAO
    {
        QUAN_LY_BAN_HANGEntities _qlct_hd_ = new QUAN_LY_BAN_HANGEntities();
        Constant Constant = new Constant();
        public List<CT_HoaDonDTO> DSCTHD()
        {
            return _qlct_hd_.CT_HOA_DON.Select(u => new CT_HoaDonDTO { MaHD = u.MaHD, DonGia = u.DonGia.Value, MaSP = u.MaSP.Value, SoLuong = u.SoLuong.Value, PhanTram = u.ChietKhau.Value + "%", ThanhTien = u.ThanhTien, MaNV = u.MaNV.Value, NgayLapHD = u.NgayLap.Value, TenSP = u.TenSP }).ToList();
        }

        public List<CT_HoaDonDTO> InHoaDon(int mahd)
        {
            return _qlct_hd_.CT_HOA_DON.Select(u => new CT_HoaDonDTO
            {
                TenSP = u.TenSP,
                MaHD = u.MaHD,
                DonGia = u.DonGia.Value,
                MaSP = u.MaSP.Value,
                SoLuong = u.SoLuong.Value,
                PhanTram = u.ChietKhau.Value + "%",
                ThanhTien = u.ThanhTien,
                MaNV = u.MaNV.Value,
                NgayLapHD = u.NgayLap.Value
            }).Where(u => u.MaHD == mahd).ToList();
        }


        public List<CT_HoaDonDTO> TheoNgay(DateTime date)
        {
            DateTime fromDate = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
            DateTime toDate = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);

            return _qlct_hd_.CT_HOA_DON.Where(u => u.NgayLap >= fromDate && u.NgayLap <= toDate).Select(u => new CT_HoaDonDTO
            {
                TenSP = u.TenSP,
                MaHD = u.MaHD,
                DonGia = u.DonGia.Value,
                MaSP = u.MaSP.Value,
                SoLuong = u.SoLuong.Value,
                PhanTram = u.ChietKhau.Value + Constant.VAR_PERCENT,
                ThanhTien = u.ThanhTien,
                MaNV = u.MaNV.Value,
                NgayLapHD = u.NgayLap.Value
            }).ToList();

        }

        public List<CT_HoaDonDTO> TheoTen(NhanVienDTO nv)
        {
            return _qlct_hd_.CT_HOA_DON.Select(u => new CT_HoaDonDTO
            {
                TenSP = u.TenSP,
                MaHD = u.MaHD,
                DonGia = u.DonGia.Value,
                MaSP = u.MaSP.Value,
                SoLuong = u.SoLuong.Value,
                PhanTram = u.ChietKhau.Value + Constant.VAR_PERCENT,
                ThanhTien = u.ThanhTien,
                MaNV = u.MaNV.Value,
                NgayLapHD = u.NgayLap.Value
            }).Where(u => u.MaNV == nv.MaNV).ToList();
        }

        public List<CT_HoaDonDTO> TheoSP(SanPhamDTO sp)
        {
            return _qlct_hd_.CT_HOA_DON.Select(u => new CT_HoaDonDTO
            {
                TenSP = u.TenSP,
                MaHD = u.MaHD,
                DonGia = u.DonGia.Value,
                MaSP = u.MaSP.Value,
                SoLuong = u.SoLuong.Value,
                PhanTram = u.ChietKhau.Value + Constant.VAR_PERCENT,
                ThanhTien = u.ThanhTien,
                MaNV = u.MaNV.Value,
                NgayLapHD = u.NgayLap.Value
            }).Where(u => u.MaSP == sp.MaSP).ToList();
        }

    }
}
