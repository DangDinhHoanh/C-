using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class HoaDonBUS
    {
        HoaDonDAO hd = new HoaDonDAO();
        public List<HoaDonDTO> DSHD()
        {
            return hd.DSHD();
        }
        public List<HoaDonDTO> DSMAHD()
        {
            return hd.DSHD();
        }
        public bool ThemHD(HoaDonDTO hoadon)
        {
            return  hd.ThemHD(hoadon);
        }
    }
}
