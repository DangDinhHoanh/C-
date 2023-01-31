using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class SanPhamBUS
    {
        SanPhamDAO sp = new SanPhamDAO();
        public List<SanPhamDTO> DSSP()
        {
            return sp.DSSP();
        }
        public bool Them(SanPhamDTO sanPham)
        {
            SanPhamDTO sanPhams = sp.DSSP().SingleOrDefault(u => u.MaSP == sanPham.MaSP);
            if (sanPhams != null)
                return false;
            return sp.Them(sanPham);
        }
        public List<SanPhamDTO> KTRANCC(int mancc)
        {
            return sp.KtraNCC(mancc);
        }
        public List<SanPhamDTO> LAYSLSP(int masp)
        {
            return sp.LaySLSP(masp);
        }
        public bool Sua(SanPhamDTO sanPham)
        {
            return sp.Sua(sanPham);
        }
        public bool SuaSL(SanPhamDTO sanPham)
        {
            return sp.SuaSL(sanPham);
        }
        public bool Xoa(int masp)
        {
            return sp.Xoa(masp);
        }
        public List<SanPhamDTO> TimKiem(string keyword)
        {
            return sp.DSSP().Where(u => u.TenSP.ToLower().Contains(keyword.ToLower()) || u.MaSP.ToString().ToLower().Contains(keyword.ToLower()) || u.Mota.ToLower().Contains(keyword.ToLower())).ToList();
        }
        public  List<SanPhamDTO> TimKiemDSSP(string tensp)
        {
            return sp.TimKiemDSSP(tensp);
        }
    }
}
