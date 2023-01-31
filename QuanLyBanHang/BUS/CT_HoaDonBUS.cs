using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CT_HoaDonBUS
    {
        CT_HoaDonDAO ct_hd = new CT_HoaDonDAO();
        public List<CT_HoaDonDTO> DSCTHD()
        {
            return ct_hd.DSCTHD();
        }
        public List<CT_HoaDonDTO> InHoaDon(int mahd)
        {
            return ct_hd.InHoaDon(mahd);
        }
        public List<CT_HoaDonDTO> TheoNgay(DateTime date)
        {
            return ct_hd.TheoNgay(date);
        }
        public List<CT_HoaDonDTO> TheoTen(NhanVienDTO nv)
        {
            return ct_hd.TheoTen(nv);
        }

        public List<CT_HoaDonDTO> TheoSP(SanPhamDTO sp)
        {
            return ct_hd.TheoSP(sp);
        }
        public List<CT_HoaDonDTO> TimKiem(string keyword)
        {
            return ct_hd.DSCTHD().Where(u => u.TenSP.ToLower().Contains(keyword.ToLower()) || u.MaSP.ToString().ToLower().Contains(keyword.ToLower()) || u.MaNV.ToString().ToLower().Contains(keyword.ToLower())).ToList();
        }
    }
}
