using DATA;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus
{
    public class PhukienphutungBus
    {
        PhukienphutungDal dal = new PhukienphutungDal();

        
       
        public DataTable GetPhuKien()
        {
            return dal.GetPhuKien();
        }

      
        public bool ThemPhuKien(PhukiemphutungDTO pk)
        {
            
            if (string.IsNullOrEmpty(pk.TenPhuKien))
            {
                return false;
            }
            return dal.ThemPhuKien(pk);
        }

      
        public bool SuaPhuKien(PhukiemphutungDTO pk)
        {
          
            if (pk.MaPhuKien <= 0) return false;

            return dal.SuaPhuKien(pk);
        }

     
        public bool XoaPhuKien(int ma)
        {
            if (ma <= 0) return false;

            return dal.XoaPhuKien(ma);
        }

        public DataTable TimKiemPhuKien(string keyword)
        {
            
            if (string.IsNullOrEmpty(keyword))
            {
                return dal.GetPhuKien();
            }
            return dal.TimKiemPhuKien(keyword);
        }
    }
}
