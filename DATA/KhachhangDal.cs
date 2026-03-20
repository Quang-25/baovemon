using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Data;
namespace DATA
{
    public class KhachhangDal:DBConnect
    {
            public DataTable Getkhachhang()
            {
            using (SqlConnection con = new SqlConnection(ketnoi))
            {
                string sql = "SELECT * FROM Khachhang";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }

        }
        public bool Themkhachhang(KhachhangDTO dto)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ketnoi))
                {
                    con.Open();

                    string sql = @"INSERT INTO Khachhang (Hoten, Sodienthoai, Email, Diachi) VALUES(@Hoten,@Sodienthoai,@Email,@Diachi)";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Hoten", dto.Hoten);
                    cmd.Parameters.AddWithValue("@Sodienthoai", dto.Sodienthoai);
                    cmd.Parameters.AddWithValue("@Email", dto.Email);
                    cmd.Parameters.AddWithValue("@Diachi", dto.Diachi);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex) 
            { 
                throw new Exception("Loi khi them khach hang:" + ex.Message);
            }
        }

        public bool suakhach(KhachhangDTO dto)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ketnoi))
                {
                    con.Open();
                    string sql = @"UPDATE Khachhang SET Hoten=@Hoten, Sodienthoai=@Sodienthoai, Email=@Email, Diachi=@Diachi WHERE Makhachhang=@Makhachhang";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Hoten", dto.Hoten);
                    cmd.Parameters.AddWithValue("@Sodienthoai", dto.Sodienthoai);
                    cmd.Parameters.AddWithValue("@Email", dto.Email);
                    cmd.Parameters.AddWithValue("@Diachi", dto.Diachi);
                    cmd.Parameters.AddWithValue("@Makhachhang", dto.MaKhachHang);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi sua khach hang: " + ex.Message);
            }  
            
        }

        public bool xoakhach(KhachhangDTO dto)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ketnoi))
                {
                    con.Open();

                    string sql = "DELETE FROM Khachhang WHERE Makhachhang=@Makhachhang";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Makhachhang", dto.MaKhachHang);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex) 
            {
                throw new Exception("khong xoa dc khach hang:" + ex.Message);
            }
        }

        public DataTable timkiemkhachhang(KhachhangDTO dto)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ketnoi))
                {
                    string sql = @"SELECT * FROM Khachhang WHERE Hoten LIKE @Hoten OR Makhachhang = @Makhachhang";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Hoten", "%" + dto.Hoten + "%");
                    cmd.Parameters.AddWithValue("@Makhachhang", dto.MaKhachHang);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;
                }
            }
            catch (Exception ex) 
            { 
                throw new Exception("Khong tim kiem duoc khach hang" + ex.Message); 
            }
        }

        public DataTable lockhachhang(KhachhangDTO dto)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ketnoi))
                {
                    string sql = "SELECT * FROM KhachHang WHERE DiaChi LIKE @DiaChi";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@DiaChi", "%" + dto.Diachi + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Khong loc duoc khach hang:" + ex.Message);
            }
        }

    }
}
