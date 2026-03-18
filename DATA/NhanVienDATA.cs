using System;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DATA
{
    public class NhanVienDATA
    {
        string ketnoi = @"Data Source=PHAMVANTRUONG\VANTRUONG;Initial Catalog=QuanLyBanXe;Integrated Security=True";

        public DataTable GetNhanVien()
        {
            using (SqlConnection conn = new SqlConnection(ketnoi))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM NhanVien", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void Insert(NhanVienDTO nv)
        {
            using (SqlConnection conn = new SqlConnection(ketnoi))
            {
                string sql = "INSERT INTO NhanVien(HoTen,TenDangNhap,MatKhau,Quyen) VALUES(@HoTen,@TenDN,@MK,@Quyen)";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@HoTen", nv.HoTen);
                cmd.Parameters.AddWithValue("@TenDN", nv.TenDangNhap);
                cmd.Parameters.AddWithValue("@MK", nv.MatKhau);
                cmd.Parameters.AddWithValue("@Quyen", nv.Quyen);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(NhanVienDTO nv)
        {
            using (SqlConnection conn = new SqlConnection(ketnoi))
            {
                string sql = @"UPDATE NhanVien SET 
                            HoTen=@HoTen,
                            TenDangNhap=@TenDN,
                            MatKhau=@MK,
                            Quyen=@Quyen
                            WHERE MaNhanVien=@Ma";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Ma", nv.MaNhanVien);
                cmd.Parameters.AddWithValue("@HoTen", nv.HoTen);
                cmd.Parameters.AddWithValue("@TenDN", nv.TenDangNhap);
                cmd.Parameters.AddWithValue("@MK", nv.MatKhau);
                cmd.Parameters.AddWithValue("@Quyen", nv.Quyen);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(ketnoi))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM NhanVien WHERE MaNhanVien=@id", conn);

                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable Search(string ten)
        {
            using (SqlConnection conn = new SqlConnection(ketnoi))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM NhanVien WHERE HoTen LIKE N'%' + @ten + '%'", conn);

                da.SelectCommand.Parameters.AddWithValue("@ten", ten);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}