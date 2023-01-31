using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace DTO
{
    public class NhanVienDTO
    {
        public int MaNV { get; set; }
        public string HoTenNV { get; set; }
        public string GioiTinh { get; set; }
        public string CCCD { get; set; }
        public string HinhAnh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Luong { get; set; }
        public string ChucVu { get; set; }
        public string Email { get; set; }
        public int TrangThai { get; set; }
    }
}
