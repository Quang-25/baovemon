using System;

namespace DTO
{
    public class HopDongDTO
    {
        public int MaHopDong { get; set; }
        public string SoHopDong { get; set; }

        public int MaDongXe { get; set; }
        public int MaKhachHang { get; set; }
        public int MaNhanVien { get; set; }

        public DateTime NgayKy { get; set; }

        public decimal GiaBanThoaThuan { get; set; }
        public decimal ThueVAT { get; set; }
        public decimal PhiTruocBa { get; set; }
        public decimal TienNganHangChoVay { get; set; }

        public decimal TongGiaTriHopDong { get; set; }
        public decimal SoTienDaDatCoc { get; set; }

        public string GhiChu { get; set; }
        public string Trangthai { get; set; }
    }
}