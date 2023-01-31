using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class NhaCCDAO
    {
        QUAN_LY_BAN_HANGEntities _qlncc_ = new QUAN_LY_BAN_HANGEntities();
        Constant Constant = new Constant();
        public List<NhaCCDTO> DSNCC()
        {
            return _qlncc_.NHA_CUNG_CAP.Where(u => u.TrangThai == Constant._STATUS_TRUE).Select(u => new NhaCCDTO { MaNCC = u.MaNCC, TenNCC = u.TenNCC, DiaChi = u.DiaChi, DienThoai = u.SDT, Email = u.Email }).ToList();

        }
        public bool Them(NhaCCDTO nhacungcap)
        {
            try
            {
                NHA_CUNG_CAP add = new NHA_CUNG_CAP()
                {
                    MaNCC = nhacungcap.MaNCC,
                    DiaChi = nhacungcap.DiaChi,
                    SDT = nhacungcap.DienThoai,
                    Email = nhacungcap.Email,
                    TenNCC = nhacungcap.TenNCC,
                    TrangThai = Constant._STATUS_TRUE
                };
                _qlncc_.NHA_CUNG_CAP.Add(add);
                _qlncc_.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(NhaCCDTO nhacungcap)
        {
            NHA_CUNG_CAP nhacc = _qlncc_.NHA_CUNG_CAP.SingleOrDefault(u => u.MaNCC == nhacungcap.MaNCC);
            if ( nhacc == null)
                return false;

            nhacc.DiaChi = nhacungcap.DiaChi;
            nhacc.Email = nhacungcap.Email;
            nhacc.MaNCC = nhacungcap.MaNCC;
            nhacc.TenNCC = nhacungcap.TenNCC;
            nhacc.SDT = nhacungcap.DienThoai;
            _qlncc_.SaveChanges();

            return true;
        }
        public bool Xoa(int mancc)
        {
            NHA_CUNG_CAP ncc = _qlncc_.NHA_CUNG_CAP.SingleOrDefault(u => u.MaNCC == mancc);


            if (ncc == null)
                return false;

            ncc.TrangThai = Constant._STATUS_FALSE;

            _qlncc_.SaveChanges();

            return true;
        }
    }

}
