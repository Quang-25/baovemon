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
    public class PhukienphutungDal:DBConnect
    {
       
        public DataTable GetPhuKien()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM PhuKien", _conn);
            DataTable dtPhuKien = new DataTable();
            da.Fill(dtPhuKien);
            return dtPhuKien;
        }

       
        public bool ThemPhuKien(PhukiemphutungDTO pk)
        {
            try
            {
                _conn.Open();
                string sql = "INSERT INTO PhuKien(TenPhuKien, DonGia, NamSanXuat, SoLuongTon, Hang) " +
                             "VALUES (@ten, @gia, @nam, @sl, @hang)";
                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@ten", pk.TenPhuKien);
                cmd.Parameters.AddWithValue("@gia", pk.DonGia);
                cmd.Parameters.AddWithValue("@nam", pk.NamSanXuat);
                cmd.Parameters.AddWithValue("@sl", pk.SoLuongTon);
                cmd.Parameters.AddWithValue("@hang", pk.Hang);

                if (cmd.ExecuteNonQuery() > 0) return true;
            }
            catch (Exception) { return false; }
            finally { _conn.Close(); }
            return false;
        }

       
        public bool SuaPhuKien(PhukiemphutungDTO pk)
        {
            try
            {
                _conn.Open();
                string sql = "UPDATE PhuKien SET TenPhuKien=@ten, DonGia=@gia, " +
                             "NamSanXuat=@nam, SoLuongTon=@sl, Hang=@hang WHERE MaPhuKien=@ma";
                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@ma", pk.MaPhuKien);
                cmd.Parameters.AddWithValue("@ten", pk.TenPhuKien);
                cmd.Parameters.AddWithValue("@gia", pk.DonGia);
                cmd.Parameters.AddWithValue("@nam", pk.NamSanXuat);
                cmd.Parameters.AddWithValue("@sl", pk.SoLuongTon);
                cmd.Parameters.AddWithValue("@hang", pk.Hang);

                if (cmd.ExecuteNonQuery() > 0) return true;
            }
            catch (Exception) { return false; }
            finally { _conn.Close(); }
            return false;
        }

        public bool XoaPhuKien(int maPhuKien)
        {
            try
            {
                _conn.Open();
                string sql = "DELETE FROM PhuKien WHERE MaPhuKien = @ma";
                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@ma", maPhuKien);

                if (cmd.ExecuteNonQuery() > 0) return true;
            }
            catch (Exception) { return false; }
            finally { _conn.Close(); }
            return false;
        }

        
        public DataTable TimKiemPhuKien(string keyword)
        {
            string sql = "SELECT * FROM PhuKien WHERE TenPhuKien LIKE @key OR Hang LIKE @key";
            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            da.SelectCommand.Parameters.AddWithValue("@key", "%" + keyword + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
