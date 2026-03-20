using DATA;
using DTO;
using System.Data;

public class NhanVienBUS
{
    NhanVienDATA data = new NhanVienDATA();

    public DataTable GetNhanVien()
    {
        return data.GetNhanVien();
    }

    public void Insert(NhanVienDTO nv)
    {
        data.Insert(nv);
    }

    public void Update(NhanVienDTO nv)
    {
        data.Update(nv);
    }

    public void Delete(int id)
    {
        data.Delete(id);
    }

    public DataTable Search(string ten)
    {
        return data.Search(ten);
    }

    public bool TrungTenDangNhap(string tenDangNhap)
    {
        DataTable dt = data.GetNhanVien();

        foreach (DataRow row in dt.Rows)
        {
            if (row["TenDangNhap"].ToString().Trim().ToLower()
                == tenDangNhap.Trim().ToLower())
            {
                return true;
            }
        }
        return false;
    }

    
    public bool TrungTenDangNhapKhiSua(int maNV, string tenDangNhap)
    {
        DataTable dt = data.GetNhanVien();

        foreach (DataRow row in dt.Rows)
        {
            if (row["MaNhanVien"].ToString() != maNV.ToString() &&
                row["TenDangNhap"].ToString().Trim().ToLower()
                == tenDangNhap.Trim().ToLower())
            {
                return true;
            }
        }
        return false;
    }
}