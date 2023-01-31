using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TaiKhoanBUS
    {
        TaiKhoanDAO tk = new TaiKhoanDAO();
        
        public List<TaiKhoanDTO> DSTK()
        {
            return tk.DSTK();
        }
        public bool KTRA_DN(TaiKhoanDTO taiKhoan)
        {
            TaiKhoanDTO user = tk.DSTK().SingleOrDefault(u => u.MaNV == taiKhoan.MaNV && u.MatKhau == taiKhoan.MatKhau);
            return user != null;
        }
        public bool Them(TaiKhoanDTO taiKhoan)
        {
            return tk.them(taiKhoan);
        }
    }
}
