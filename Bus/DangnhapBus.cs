using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA;
using DTO;
namespace Bus { 

    public class DangnhapBus
    {
        DangnhapDal dal = new DangnhapDal();

        public bool CheckLogin(string user, string pass)
        {
            DangnhapDTO nv = new DangnhapDTO();

            nv.TenDangNhap = user;
            nv.MatKhau =  pass;

            return dal.CheckLogin(nv);
        }
        public bool CheckQuyen(string user, string pass)
        {
            DangnhapDTO nv = new DangnhapDTO();
            nv.TenDangNhap = user;
            nv.MatKhau = pass;
            return dal.CheckQuyen(nv);
        }
    }
    
}

