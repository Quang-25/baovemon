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
        public string MahoaMatKhau(string pass)
        {
            
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
    
}

