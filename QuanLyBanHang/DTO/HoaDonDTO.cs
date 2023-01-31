using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonDTO
    {
        public int MaHD { get; set; }
        public DateTime NgayLapHD { get; set; }

        public CT_HoaDonDTO[] CT_HoaDon { get; set; }
        public int MaNV { get; set; }

    }
}
