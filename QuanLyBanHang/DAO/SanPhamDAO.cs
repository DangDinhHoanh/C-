using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class SanPhamDAO
    {
        QUAN_LY_BAN_HANGEntities _qlsp_ = new QUAN_LY_BAN_HANGEntities();
        Constant Constant = new Constant();
        public List<SanPhamDTO> DSSP()
        {
            return _qlsp_.SAN_PHAM.Where(u=>u.TrangThai == Constant._STATUS_TRUE).Select(u => new SanPhamDTO { MaSP = u.MaSP, TenSP = u.TenSP, HinhAnh = u.HinhAnh, DonGia = u.DonGia.Value, DonViTinh = u.DonViTinh, HSD = u.HSD.Value, MaNCC = u.MaNCC.Value, NgayNhap = u.NgayNhap.Value, NgaySX = u.NgaySX.Value, SoLuong = u.SoLuong.Value, Mota = u.MoTa }).ToList();
        }
        public List<SanPhamDTO>KtraNCC(int mancc)
        {
            return _qlsp_.SAN_PHAM.Where(u=> u.TrangThai == Constant._STATUS_TRUE && u.MaNCC == mancc).Select(u => new SanPhamDTO { MaSP = u.MaSP, TenSP = u.TenSP, HinhAnh = u.HinhAnh, DonGia = u.DonGia.Value, DonViTinh = u.DonViTinh, HSD = u.HSD.Value, MaNCC = u.MaNCC.Value, NgayNhap = u.NgayNhap.Value, NgaySX = u.NgaySX.Value, SoLuong = u.SoLuong.Value, Mota = u.MoTa }).ToList();
        }
        public List<SanPhamDTO> LaySLSP(int masp)
        {
            return _qlsp_.SAN_PHAM.Where(u => u.TrangThai == Constant._STATUS_TRUE && u.MaSP == masp).Select(u => new SanPhamDTO {SoLuong = u.SoLuong.Value}).ToList();
        }

        public bool Them(SanPhamDTO sanPham)
        {
            try
            {
                SAN_PHAM sp = new SAN_PHAM()
                {
                    
                    TenSP = sanPham.TenSP,
                    SoLuong = sanPham.SoLuong,
                    DonGia = sanPham.DonGia,
                    HinhAnh = sanPham.HinhAnh,
                    DonViTinh = sanPham.DonViTinh,
                    HSD = sanPham.HSD,
                    MaNCC = sanPham.MaNCC,
                    NgayNhap = sanPham.NgayNhap,
                    NgaySX = sanPham.NgaySX,
                    MoTa = sanPham.Mota,
                    TrangThai = Constant._STATUS_TRUE
                };
                _qlsp_.SAN_PHAM.Add(sp);
                _qlsp_.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public bool Sua(SanPhamDTO sanPham)
        {
            SAN_PHAM sp = _qlsp_.SAN_PHAM.SingleOrDefault(u => u.MaSP == sanPham.MaSP);
            if (sp == null)
                return false;
            sp.MaSP = sanPham.MaSP;
            sp.TenSP = sanPham.TenSP;
            sp.SoLuong = sanPham.SoLuong;
            sp.DonGia = sanPham.DonGia;
            sp.HinhAnh = sanPham.HinhAnh;
            sp.DonViTinh = sanPham.DonViTinh;
            sp.HSD = sanPham.HSD;
            sp.MaNCC = sanPham.MaNCC;
            sp.NgayNhap = sanPham.NgayNhap;
            sp.NgaySX = sanPham.NgaySX;
            sp.MoTa = sanPham.Mota;

            _qlsp_.SaveChanges();

            return true;
        }
        public bool SuaSL(SanPhamDTO sanPham)
        {
            SAN_PHAM sp = _qlsp_.SAN_PHAM.SingleOrDefault(u => u.MaSP == sanPham.MaSP);
            if (sp == null)
                return false;

            sp.SoLuong = sanPham.SoLuong;

            _qlsp_.SaveChanges();

            return true;
        }
        public bool Xoa(int masp)
        {
            SAN_PHAM sp = _qlsp_.SAN_PHAM.SingleOrDefault(u => u.MaSP == masp);
            if (sp == null)
                return false;

            sp.TrangThai = Constant._STATUS_FALSE;

            _qlsp_.SaveChanges();

            return true;
        }
        public List<SanPhamDTO> TimKiemDSSP(string tensp)
        {
            return _qlsp_.SAN_PHAM.Where(u => u.TrangThai == Constant._STATUS_TRUE && u.TenSP.Contains(tensp)).Select(u => new SanPhamDTO { MaSP = u.MaSP, TenSP = u.TenSP, HinhAnh = u.HinhAnh, DonGia = u.DonGia.Value, DonViTinh = u.DonViTinh, HSD = u.HSD.Value, MaNCC = u.MaNCC.Value, NgayNhap = u.NgayNhap.Value, NgaySX = u.NgaySX.Value, SoLuong = u.SoLuong.Value, Mota = u.MoTa }).ToList();
        }
    }
}
