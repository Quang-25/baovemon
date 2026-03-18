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
    public class KhachhangDal
    {
        string ketnoi = @"Data Source=LAPTOP-VN022S39\SQLEXPRESS;Initial Catalog= QuanLyBanXe;Integrated Security=True";
        public DataTable Getkhachhang()
        {
            SqlConnection conn = new SqlConnection(ketnoi);
            string sql = "select * from Khachhang";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public bool Themkhachhang(KhachhangDTO dto)
        {
            SqlConnection con = new SqlConnection(ketnoi);
            string sql = "Insert into Khachhang (Hoten, Sodienthoai, Email, Diachi) Values(@HoTen,@Sodienthoai,@Email,@Diachi)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@HoTen", dto.Hoten);
            cmd.Parameters.AddWithValue("@Sodienthoai", dto.Sodienthoai);
            cmd.Parameters.AddWithValue("@Email", dto.Email);
            cmd.Parameters.AddWithValue("@Diachi", dto.Diachi);

            con.Open();
            int ketqua = cmd.ExecuteNonQuery();
            con.Close();
            return ketqua > 0;

        }

        public bool suakhach(KhachhangDTO dto)
        {
            SqlConnection con = new SqlConnection(ketnoi);
            string sql = "Update Khachhang set Hoten=@HoTen, Sodienthoai=@Sodienthoai, Email=@Email, Diachi=@Diachi where Makhachhang=@Makhachhang";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Hoten", dto.Hoten);
            cmd.Parameters.AddWithValue("@Sodienthoai", dto.Sodienthoai);
            cmd.Parameters.AddWithValue("@Email", dto.Email);
            cmd.Parameters.AddWithValue("@Diachi", dto.Diachi);
            cmd.Parameters.AddWithValue("@Makhachhang", dto.MaKhachHang);
            con.Open();
            int ketqua = cmd.ExecuteNonQuery();
            con.Close();
            return ketqua > 0;

        }
        public bool xoakhach(KhachhangDTO dto)
        {
            SqlConnection con = new SqlConnection(ketnoi);
            string sql = "Delete from Khachhang where Makhachhang=@Makhachhang";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Makhachhang", dto.MaKhachHang);
            con.Open();
            int ketqua = cmd.ExecuteNonQuery();
            con.Close();
            return ketqua > 0;

        }

        public DataTable timkiemkhachhang(KhachhangDTO dto)
        {
            SqlConnection con = new SqlConnection(ketnoi);

            string sql = "SELECT * FROM Khachhang WHERE HoTen LIKE @Hoten OR MaKhachHang = @Makhachhang";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@Hoten", "%" + dto.Hoten + "%");
            cmd.Parameters.AddWithValue("@Makhachhang", dto.MaKhachHang);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;

        }
        public DataTable lockhachhang(KhachhangDTO dto)
        {
            SqlConnection con = new SqlConnection(ketnoi);
            string sql = "SELECT * FROM KhachHang WHERE DiaChi LIKE @DiaChi";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@DiaChi", "%" + dto.Diachi + "%");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

    }
}
