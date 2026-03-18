using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA;
using DTO;
namespace Bus
{
    public class KhachhangBus
    {
        KhachhangDal dal = new KhachhangDal();

        public DataTable GetKhachhang()
        {
           return dal.Getkhachhang();
        }

        public bool Themkhachhang(KhachhangDTO kh) 
        {
            return dal.Themkhachhang(kh);
        }

        public bool suakhach(KhachhangDTO kh)
        {
            return dal.suakhach(kh);
        }

        public bool xoakhach(KhachhangDTO xoa)
        {
            return dal.xoakhach(xoa);
        }
        
        public DataTable Timkiemkhachhang(KhachhangDTO ten)
        {
            return dal.timkiemkhachhang(ten);
        }

        public DataTable lockhachhang(KhachhangDTO loc)
        {
            return dal.lockhachhang(loc);
        }
    }
}
