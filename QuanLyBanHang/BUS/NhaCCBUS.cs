using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NhaCCBUS
    {
        NhaCCDAO ncc = new NhaCCDAO();
        public List<NhaCCDTO> DSNCC()
        {
            return ncc.DSNCC();
        }
        public bool Them(NhaCCDTO nhacc)
        {

            NhaCCDTO nha = ncc.DSNCC().SingleOrDefault(u => u.TenNCC == nhacc.TenNCC);
            if (nha!=null)
            {
                return false;  
            }
            return ncc.Them(nhacc);
        }
        public bool Sua(NhaCCDTO nha)
        {
            return ncc.Sua(nha);
        }
        public bool Xoa(int mancc)
        {
            return ncc.Xoa(mancc);
        }
        public List<NhaCCDTO> TimKiem(string keyword)
        {
            return ncc.DSNCC().Where(u => u.TenNCC.ToLower().Contains(keyword.ToLower()) || u.MaNCC.ToString().ToLower().Contains(keyword.ToLower())).ToList();
        }
    }
}
