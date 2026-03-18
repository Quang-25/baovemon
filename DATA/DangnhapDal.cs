using DTO;
using System.Data.SqlClient;

namespace DATA
{
    public class DangnhapDal : DBConnect
    {
        public bool CheckLogin(DangnhapDTO nv)
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

        public bool CheckQuyen(DangnhapDTO nv)
        {
            using (SqlConnection conn = new SqlConnection(ketnoi)) 
            {
                conn.Open();

                string sql = "SELECT Quyen FROM NhanVien WHERE TenDangNhap=@user AND MatKhau=@pass";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@user", nv.TenDangNhap);
                cmd.Parameters.AddWithValue("@pass", nv.MatKhau);

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    nv.Quyen = result.ToString();
                    return nv.Quyen == "Admin";
                }

                return false;
            }
        }
    }
}