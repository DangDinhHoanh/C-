using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPhamDTO
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string Mota { get; set; }
        public string HinhAnh { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public int MaNCC { get; set; }
        public DateTime NgayNhap { get; set; }
        public DateTime NgaySX { get; set; }
        public DateTime HSD { get; set; }
        public bool TrangThai { get; set; }


    }
}
