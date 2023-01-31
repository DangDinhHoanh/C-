using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class HoaDonDAO
    {
        QUAN_LY_BAN_HANGEntities _qlhd_ = new QUAN_LY_BAN_HANGEntities();
        Constant Constant = new Constant();
        public List<HoaDonDTO> DSHD()
        {
            return _qlhd_.HOA_DON.Select(u => new HoaDonDTO { MaHD = u.MaHD, MaNV = u.MaNV.Value, NgayLapHD = u.NgayLapHD.Value }).ToList();
        }
        public List<HoaDonDTO> DSMAHD()
        {
            return _qlhd_.HOA_DON.Select(u => new HoaDonDTO { MaHD = u.MaHD}).ToList();
        }
        public bool ThemHD(HoaDonDTO hd)
        {
            try
            {
                HOA_DON hoadon = new HOA_DON
                {
                    MaNV = hd.MaNV,
                    NgayLapHD = hd.NgayLapHD,
                    TrangThai = Constant._STATUS_TRUE
                };

                _qlhd_.HOA_DON.Add(hoadon);
                _qlhd_.SaveChanges();


                foreach (var ct in hd.CT_HoaDon)
                {
                    CT_HOA_DON ct_hoadon = new CT_HOA_DON
                    {
                        MaHD = _qlhd_.HOA_DON.Select(u => u.MaHD).Max(),
                        MaSP = ct.MaSP,
                        TenSP = ct.TenSP,
                        SoLuong = ct.SoLuong,
                        DonGia = ct.DonGia,
                        ThanhTien = ct.ThanhTien,
                        MaNV = ct.MaNV,
                        NgayLap = ct.NgayLapHD,
                        TrangThai = Constant._STATUS_TRUE,
                        ChietKhau = 1
                    };
                    _qlhd_.CT_HOA_DON.Add(ct_hoadon);
                    _qlhd_.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
