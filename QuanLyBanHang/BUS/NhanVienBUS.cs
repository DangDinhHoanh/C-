using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NhanVienBUS
    {
        public NhanVienDAO nv = new NhanVienDAO();
        public List<NhanVienDTO> DSNV()
        {
            return nv.DSNV();
        }

        public List<NhanVienDTO> DSTheoChucVu(string name)
        {
            return nv.DSTheoChucVu(name);
        }

        public bool Them (NhanVienDTO nhanVien)
        {
            NhanVienDTO sinhViens = nv.DSNV().SingleOrDefault(u => u.MaNV == nhanVien.MaNV);
            if (sinhViens != null)
                return false;

            return nv.them(nhanVien);
        }
        public bool Sua(NhanVienDTO nhanVien)
        {
            return nv.Sua(nhanVien);
        }
        public bool Xoa(int manv)
        {
            return nv.Xoa(manv);
        }
        public List<NhanVienDTO> DSNVOTK()
        {
            List<NhanVienDTO> list = nv.DSNV();
            List<NhanVienDTO> lay = new List<NhanVienDTO>();

            foreach (var nVien in list)
            {
                if (KT(nVien.MaNV))
                    lay.Add(nVien);
            }
            return lay;
        }
        bool KT(int manv)
        {
            return new TaiKhoanDAO().DSTK().SingleOrDefault(u => u.MaNV == manv) == null;
        }
        public List<NhanVienDTO> TimKiem(string keyword)
        {
            return nv.DSNV().Where(u =>
                u.HoTenNV.ToLower().Contains(keyword.ToLower()) || 
                u.MaNV.ToString().ToLower().Contains(keyword.ToLower())).ToList();
        }
    }
}
