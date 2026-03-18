using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DATA
{
    public class HopDongDATA
    {
        string conn = @"Data Source=PHAMVANTRUONG\VANTRUONG;
                        Initial Catalog=QuanLyBanXe;
                        Integrated Security=True";

        public DataTable GetHopDong()
        {
            SqlConnection c = new SqlConnection(conn);

            SqlDataAdapter da = new SqlDataAdapter(
            "SELECT * FROM HopDong", c);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public void Insert(HopDongDTO hd)
        {
            SqlConnection c = new SqlConnection(conn);

            string sql = @"INSERT INTO HopDong
            (SoHopDong,MaDongXe,MaKhachHang,MaNhanVien,NgayKy,
            GiaBanThoaThuan,ThueVAT,PhiTruocBa,
            TienNganHangChoVay,TongGiaTriHopDong,
            SoTienDaDatCoc,GhiChu,Trangthai)

            VALUES(@So,@DongXe,@KH,@NV,@Ngay,
            @Gia,@VAT,@Phi,@Vay,@Tong,@DatCoc,@GhiChu,@TrangThai)";

            SqlCommand cmd = new SqlCommand(sql, c);

            cmd.Parameters.AddWithValue("@So", hd.SoHopDong);
            cmd.Parameters.AddWithValue("@DongXe", hd.MaDongXe);
            cmd.Parameters.AddWithValue("@KH", hd.MaKhachHang);
            cmd.Parameters.AddWithValue("@NV", hd.MaNhanVien);
            cmd.Parameters.AddWithValue("@Ngay", hd.NgayKy);

            cmd.Parameters.AddWithValue("@Gia", hd.GiaBanThoaThuan);
            cmd.Parameters.AddWithValue("@VAT", hd.ThueVAT);
            cmd.Parameters.AddWithValue("@Phi", hd.PhiTruocBa);
            cmd.Parameters.AddWithValue("@Vay", hd.TienNganHangChoVay);

            cmd.Parameters.AddWithValue("@Tong", hd.TongGiaTriHopDong);
            cmd.Parameters.AddWithValue("@DatCoc", hd.SoTienDaDatCoc);

            cmd.Parameters.AddWithValue("@GhiChu", hd.GhiChu);
            cmd.Parameters.AddWithValue("@TrangThai", hd.Trangthai);

            c.Open();
            cmd.ExecuteNonQuery();
            c.Close();
        }

        public void Update(HopDongDTO hd)
        {
            SqlConnection c = new SqlConnection(conn);

            string sql = @"UPDATE HopDong SET
            SoHopDong=@So,
            MaDongXe=@DongXe,
            MaKhachHang=@KH,
            MaNhanVien=@NV,
            NgayKy=@Ngay,
            GiaBanThoaThuan=@Gia,
            ThueVAT=@VAT,
            PhiTruocBa=@Phi,
            TienNganHangChoVay=@Vay,
            TongGiaTriHopDong=@Tong,
            SoTienDaDatCoc=@DatCoc,
            GhiChu=@GhiChu,
            Trangthai=@TrangThai
            WHERE MaHopDong=@Ma";

            SqlCommand cmd = new SqlCommand(sql, c);

            cmd.Parameters.AddWithValue("@Ma", hd.MaHopDong);
            cmd.Parameters.AddWithValue("@So", hd.SoHopDong);
            cmd.Parameters.AddWithValue("@DongXe", hd.MaDongXe);
            cmd.Parameters.AddWithValue("@KH", hd.MaKhachHang);
            cmd.Parameters.AddWithValue("@NV", hd.MaNhanVien);
            cmd.Parameters.AddWithValue("@Ngay", hd.NgayKy);

            cmd.Parameters.AddWithValue("@Gia", hd.GiaBanThoaThuan);
            cmd.Parameters.AddWithValue("@VAT", hd.ThueVAT);
            cmd.Parameters.AddWithValue("@Phi", hd.PhiTruocBa);
            cmd.Parameters.AddWithValue("@Vay", hd.TienNganHangChoVay);

            cmd.Parameters.AddWithValue("@Tong", hd.TongGiaTriHopDong);
            cmd.Parameters.AddWithValue("@DatCoc", hd.SoTienDaDatCoc);

            cmd.Parameters.AddWithValue("@GhiChu", hd.GhiChu);
            cmd.Parameters.AddWithValue("@TrangThai", hd.Trangthai);

            c.Open();
            cmd.ExecuteNonQuery();
            c.Close();
        }

        public void Delete(int id)
        {
            SqlConnection c = new SqlConnection(conn);

            SqlCommand cmd = new SqlCommand(
            "DELETE FROM HopDong WHERE MaHopDong=@id", c);

            cmd.Parameters.AddWithValue("@id", id);

            c.Open();
            cmd.ExecuteNonQuery();
            c.Close();
        }

        public DataTable Search(string so)
        {
            SqlConnection c = new SqlConnection(conn);

            string sql = @"SELECT * FROM HopDong 
                   WHERE SoHopDong LIKE N'%' + @so + '%'
                   OR CAST(MaHopDong AS NVARCHAR) LIKE '%' + @so + '%'
                   OR CAST(MaKhachHang AS NVARCHAR) LIKE '%' + @so + '%'
                   OR CAST(MaNhanVien AS NVARCHAR) LIKE '%' + @so + '%'
                   OR CAST(MaDongXe AS NVARCHAR) LIKE '%' + @so + '%'
                   OR Trangthai LIKE N'%' + @so + '%'
                   OR GhiChu LIKE N'%' + @so + '%'";

            SqlDataAdapter da = new SqlDataAdapter(sql, c);
            da.SelectCommand.Parameters.AddWithValue("@so", so);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
    }
}