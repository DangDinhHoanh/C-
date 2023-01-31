using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CT_HoaDonDTO
    {
        public int MaHD { get; set; }

        public int MaSP { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public string PhanTram { get; set; }
        public string ThanhTien { get; set; }
        public int MaNV { get; set; }
        public string TenSP { get; set; }
        public DateTime NgayLapHD { get; set; }
    }
}
