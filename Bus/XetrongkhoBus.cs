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
    public class XetrongkhoBus
    {
        XetrongkhoDal dalXe = new XetrongkhoDal();

        public DataTable GetDanhSachXe()
        {
            return dalXe.GetDanhSachXe();
        }

        public bool ThemXe(XetrongkhoDTO xe)
        {
            
            return dalXe.ThemXe(xe);
        }
        public bool SuaXe(XetrongkhoDTO xe)
        {
            return dalXe.SuaXe(xe);
        }
        public DataTable TimKiemXe(string tuKhoa)
        {
            return dalXe.TimKiemXe(tuKhoa);
        }
        public bool XoaXe(string soMay)
        {
            return dalXe.XoaXe(soMay);
        }
    }
}
