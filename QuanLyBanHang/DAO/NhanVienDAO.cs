using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class NhanVienDAO
    {
        QUAN_LY_BAN_HANGEntities _qlnv_ = new QUAN_LY_BAN_HANGEntities();
        Constant Constant = new Constant();
        public List<NhanVienDTO> DSNV()
        {
            return _qlnv_.NHAN_VIEN.Where(u => u.TrangThai == Constant._STATUS_TRUE).Select(u => new NhanVienDTO 
            {   MaNV = u.MaNV, HoTenNV = u.HoTenNV, GioiTinh = u.GioiTinh, CCCD = u.CCCD, 
                HinhAnh = u.HinhAnh, NgaySinh = u.NgaySinh.Value, DiaChi = u.DiaChi, DienThoai = u.DienThoai, 
                Luong = u.Luong, ChucVu = u.ChucVu, Email = u.Email 
            }).ToList();
        }
        public List<NhanVienDTO> DSTheoChucVu(string ChucVu)
        {
            return _qlnv_.NHAN_VIEN.Where(u => u.TrangThai == Constant._STATUS_TRUE && u.ChucVu == ChucVu).Select(u => new NhanVienDTO
            {
                MaNV = u.MaNV,
                HoTenNV = u.HoTenNV,
                GioiTinh = u.GioiTinh,
                CCCD = u.CCCD,
                HinhAnh = u.HinhAnh,
                NgaySinh = u.NgaySinh.Value,
                DiaChi = u.DiaChi,
                DienThoai = u.DienThoai,
                Luong = u.Luong,
                ChucVu = u.ChucVu,
                Email = u.Email
            }).ToList();
        }

        public bool them(NhanVienDTO nhanVien)
        {
            try
            {
                NHAN_VIEN nv = new NHAN_VIEN
                {
                    MaNV = nhanVien.MaNV,
                    HoTenNV = nhanVien.HoTenNV,
                    GioiTinh = nhanVien.GioiTinh,
                    CCCD = nhanVien.CCCD,
                    HinhAnh = nhanVien.HinhAnh,
                    NgaySinh = nhanVien.NgaySinh,
                    DiaChi = nhanVien.DiaChi,
                    DienThoai = nhanVien.DienThoai,
                    Luong = nhanVien.Luong,
                    ChucVu = nhanVien.ChucVu,
                    Email = nhanVien.Email,
                    TrangThai = Constant._STATUS_TRUE
                };
                _qlnv_.NHAN_VIEN.Add(nv);
                _qlnv_.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public bool Sua(NhanVienDTO nhanVien)
        {
            NHAN_VIEN nv = _qlnv_.NHAN_VIEN.SingleOrDefault(u => u.MaNV == nhanVien.MaNV);
            if (nv == null)
                return false;

            nv.MaNV = nhanVien.MaNV;
            nv.HoTenNV = nhanVien.HoTenNV;
            nv.GioiTinh = nhanVien.GioiTinh;
            nv.CCCD = nhanVien.CCCD;
            nv.HinhAnh = nhanVien.HinhAnh;
            nv.NgaySinh = nhanVien.NgaySinh;
            nv.DiaChi = nhanVien.DiaChi;
            nv.DienThoai = nhanVien.DienThoai;
            nv.Luong = nhanVien.Luong;
            nv.ChucVu = nhanVien.ChucVu;
            nv.Email = nhanVien.Email;
            nv.TrangThai = Constant._STATUS_TRUE;

            _qlnv_.SaveChanges();

            return true;
        }
        public bool Xoa(int manv)
        {
            NHAN_VIEN sv = _qlnv_.NHAN_VIEN.SingleOrDefault(u => u.MaNV == manv);

            TAI_KHOAN tk = _qlnv_.TAI_KHOAN.SingleOrDefault(u => u.MaNV == manv);

            if (sv == null)
                return false;
            
            sv.TrangThai = Constant._STATUS_FALSE;
            tk.TrangThai = Constant._STATUS_FALSE;

            _qlnv_.SaveChanges();

            return true;
        }

    }
}
