using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
    public class XetrongkhoDal : DBConnect
    {
       
        public DataTable GetDanhSachXe()
        {
            string sql = @"
        SELECT 
            x.MaDongXe, 
            d.TenXe, 
            d.NamSanXuat, 
            d.GiaNiemYet, 
            d.SoChoNgoi, 
            x.MauSac, 
            x.SoKhung, 
            x.SoMay, 
            d.XuatXu, 
            d.LoaiNhienLieu,
            x.TrangThai
        FROM XeTrongKho x
        INNER JOIN DongXe d ON x.MaDongXe = d.MaDongXe";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        
        public bool ThemXe(XetrongkhoDTO xe)
        {
            try
            {
                _conn.Open();
                string sql = "INSERT INTO XeTrongKho (MaDongXe, TenXe, NamSanXuat, GiaNiemYet, SoChoNgoi, MauSac, SoKhung, SoMay, XuatXu, LoaiNhienLieu) " +
                             "VALUES (@ma, @ten, @nam, @gia, @socho, @mau, @sokhung, @somay, @xuatxu, @nhienlieu)";
                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@ma", xe.MaDongXe);
                cmd.Parameters.AddWithValue("@ten", xe.TenXe);
                cmd.Parameters.AddWithValue("@nam", xe.NamSanXuat);

                cmd.Parameters.AddWithValue("@gia", xe.GiaNiemYet);
                cmd.Parameters.AddWithValue("@socho", xe.SoChoNgoi);
                cmd.Parameters.AddWithValue("@mau", xe.MauSac);
                cmd.Parameters.AddWithValue("@sokhung", xe.SoKhung);
                cmd.Parameters.AddWithValue("@somay", xe.SoMay);
                cmd.Parameters.AddWithValue("@xuatxu", xe.XuatXu);
                cmd.Parameters.AddWithValue("@nhienlieu", xe.LoaiNhienLieu);




                if (cmd.ExecuteNonQuery() > 0) return true;
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public DataTable TimKiemXe(string tuKhoa)
        {
          
            string sql = "SELECT * FROM XeTrongKho WHERE SoMay LIKE @tuKhoa OR SoKhung LIKE @tuKhoa OR MauSac LIKE @tuKhoa";
            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);

           
            da.SelectCommand.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public bool SuaXe(XetrongkhoDTO xe)
        {
            try
            {
                _conn.Open();

               
                string sql = "UPDATE DongXe SET GiaNiemYet = @gia WHERE MaDongXe = @madongxe";

                SqlCommand cmd = new SqlCommand(sql, _conn);

               
                cmd.Parameters.AddWithValue("@gia", xe.GiaNiemYet);
                cmd.Parameters.AddWithValue("@madongxe", xe.MaDongXe);

                if (cmd.ExecuteNonQuery() > 0) return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật giá: " + ex.Message);
            }
            finally
            {
                if (_conn.State == ConnectionState.Open) _conn.Close();
            }
            return false;
        }
        public bool XoaXe(string soMay)
        {
            try
            {
                _conn.Open();
                string sql = "DELETE FROM XeTrongKho WHERE SoMay = @somay";
                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@somay", soMay);

                if (cmd.ExecuteNonQuery() > 0) return true;
            }
            catch (Exception ex)
            {
               
                throw new Exception(ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
    }
}
