using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
    public class DoimatkhauDal:DBConnect
    {
        public bool checkmatkhau(DoimatkhauDTO nv)
        {
            nv.TenDangNhap = nv.TenDangNhap.Trim();
            nv.MatKhau = nv.MatKhau.Trim();

            using (SqlConnection conn = new SqlConnection(ketnoi))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM NhanVien WHERE TenDangNhap=@user AND MatKhau=@pass";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@user", nv.TenDangNhap);
                cmd.Parameters.AddWithValue("@pass", nv.MatKhau);

                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
        }
        public bool Doimatkhau(DoimatkhauDTO nv)
        {
            nv.TenDangNhap = nv.TenDangNhap.Trim();
            nv.Matkhaumoi = nv.Matkhaumoi.Trim();
            using (SqlConnection con = new SqlConnection(ketnoi))
            { 
                con.Open();
                string sql = "UPDATE NhanVien SET MatKhau=@newpass WHERE TenDangNhap=@user ";
                SqlCommand cmd = new SqlCommand (sql, con);
                cmd.Parameters.AddWithValue("@user", nv.TenDangNhap);
                cmd.Parameters.AddWithValue("@newpass", nv.Matkhaumoi);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

    }
}
