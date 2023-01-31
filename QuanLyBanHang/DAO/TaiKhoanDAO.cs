using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TaiKhoanDAO
    {
        QUAN_LY_BAN_HANGEntities _qltk_ = new QUAN_LY_BAN_HANGEntities();
        Constant Constant = new Constant();
        public List<TaiKhoanDTO> DSTK()
        {
            return _qltk_.TAI_KHOAN.Where(u => u.TrangThai == Constant._STATUS_TRUE).Select(u => new TaiKhoanDTO { MaNV = u.MaNV, MatKhau = u.MatKhau}).ToList();
        }

        public bool them(TaiKhoanDTO tk)
        {
            try
            {
                TAI_KHOAN add = new TAI_KHOAN()
                {
                    MaNV = tk.MaNV,
                    MatKhau = tk.MatKhau,
                    TrangThai = Constant._STATUS_TRUE,

                };
                _qltk_.TAI_KHOAN.Add(add);
                _qltk_.SaveChanges();
                return true;
            }
            catch (Exception  e)
            {
                return false;
                throw;
            } 
        }

    }
}
