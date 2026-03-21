using System;
using System.Data.SqlClient;

namespace DATA
{
    public class DBConnect
    {
        // 1. Khai báo chuỗi kết nối (Connection String)
        // LƯU Ý: Bạn PHẢI thay đổi chuỗi này cho khớp với máy của bạn!
        protected string strConnect = @"Data Source=ADMIN-PC\SQLEXPRESS01;Initial Catalog=QuanLyBanXe;Integrated Security=True";

        // 2. Đối tượng kết nối
        protected SqlConnection _conn;

        // 3. Hàm khởi tạo: Tự động tạo mới kết nối mỗi khi lớp này được gọi
        public DBConnect()
        {
            _conn = new SqlConnection(strConnect);
        }
    }
}