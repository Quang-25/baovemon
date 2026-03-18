using System;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmHopDong : Form
    {
        HopDongBUS bus = new HopDongBUS();

        public frmHopDong()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            dgvHopDong.DataSource = bus.GetHopDong();
        }

        void ClearText()
        {
            txtMaHD.Clear();
            txtSoHD.Clear();
            txtMaDongXe.Clear();
            txtMaKhachHang.Clear();
            txtMaNhanVien.Clear();

            txtGia.Clear();
            txtVAT.Clear();
            txtPhi.Clear();
            txtVay.Clear();
            txtTong.Clear();
            txtDatCoc.Clear();
            txtGhiChu.Clear();
        }

        void TinhTong()
        {
            decimal gia = 0, vat = 0, phi = 0, vay = 0;

            decimal.TryParse(txtGia.Text, out gia);
            decimal.TryParse(txtVAT.Text, out vat);
            decimal.TryParse(txtPhi.Text, out phi);
            decimal.TryParse(txtVay.Text, out vay);

            txtTong.Text = (gia + vat + phi - vay).ToString();
        }

        private void frmHopDong_Load(object sender, EventArgs e)
        {
            LoadData();
            cmbTrangThai.Items.Clear();
            cmbTrangThai.Items.Add("Mới lập");
            cmbTrangThai.Items.Add("Đã duyệt");
            cmbTrangThai.Items.Add("Đã thu tiền");
            cmbTrangThai.Items.Add("Đã hoàn thành");
            cmbTrangThai.Items.Add("Đã hủy");
        }

        // ================= THÊM =================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoHD.Text) ||
        string.IsNullOrWhiteSpace(txtMaDongXe.Text) ||
        string.IsNullOrWhiteSpace(txtMaKhachHang.Text) ||
        string.IsNullOrWhiteSpace(txtMaNhanVien.Text) ||
        string.IsNullOrWhiteSpace(txtGia.Text) ||
        string.IsNullOrWhiteSpace(txtVAT.Text) ||
        string.IsNullOrWhiteSpace(txtPhi.Text) ||
        string.IsNullOrWhiteSpace(txtTong.Text))
            {
                MessageBox.Show("⚠ Vui lòng nhập đầy đủ thông tin!",
                                "Thiếu dữ liệu",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            try
            {
                HopDongDTO hd = new HopDongDTO();

                hd.SoHopDong = txtSoHD.Text;
                hd.MaDongXe = Convert.ToInt32(txtMaDongXe.Text);
                hd.MaKhachHang = Convert.ToInt32(txtMaKhachHang.Text);
                hd.MaNhanVien = Convert.ToInt32(txtMaNhanVien.Text);

                hd.NgayKy = dtNgayKy.Value;

                hd.GiaBanThoaThuan = decimal.Parse(txtGia.Text);
                hd.ThueVAT = decimal.Parse(txtVAT.Text);
                hd.PhiTruocBa = decimal.Parse(txtPhi.Text);
                hd.TienNganHangChoVay = decimal.Parse(txtVay.Text);

                hd.TongGiaTriHopDong = decimal.Parse(txtTong.Text);
                hd.SoTienDaDatCoc = decimal.Parse(txtDatCoc.Text);

                hd.GhiChu = txtGhiChu.Text;

                string trangThai = cmbTrangThai.Text.Trim();

                if (trangThai != "Mới lập" &&
                    trangThai != "Đã duyệt" &&
                    trangThai != "Đã thu tiền" &&
                    trangThai != "Đã hoàn thành" &&
                    trangThai != "Đã hủy")
                {
                    MessageBox.Show("Trạng thái không hợp lệ!");
                    return;
                }

                hd.Trangthai = trangThai;

                bus.Insert(hd);

                MessageBox.Show("✅ Thêm thành công!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                LoadData();
                ClearText();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi: " + ex.Message);
            }
        }

        // ================= CLICK GRID =================
        private void dgvHopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvHopDong.CurrentRow.Index;

            txtMaHD.Text = dgvHopDong.Rows[i].Cells[0].Value.ToString();
            txtSoHD.Text = dgvHopDong.Rows[i].Cells[1].Value.ToString();

            txtMaDongXe.Text = dgvHopDong.Rows[i].Cells[2].Value.ToString();
            txtMaKhachHang.Text = dgvHopDong.Rows[i].Cells[3].Value.ToString();
            txtMaNhanVien.Text = dgvHopDong.Rows[i].Cells[4].Value.ToString();

            txtGia.Text = dgvHopDong.Rows[i].Cells[6].Value.ToString();
            txtVAT.Text = dgvHopDong.Rows[i].Cells[7].Value.ToString();
            txtPhi.Text = dgvHopDong.Rows[i].Cells[8].Value.ToString();
            txtVay.Text = dgvHopDong.Rows[i].Cells[9].Value.ToString();
            txtTong.Text = dgvHopDong.Rows[i].Cells[10].Value.ToString();
            txtDatCoc.Text = dgvHopDong.Rows[i].Cells[11].Value.ToString();
            txtGhiChu.Text = dgvHopDong.Rows[i].Cells[12].Value.ToString();

            cmbTrangThai.Text = dgvHopDong.Rows[i].Cells[13].Value.ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát?",
                 "Thông báo",
                 MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtTim.Clear();
            ClearText();
            LoadData();
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTim.Text))
            {
                LoadData(); // rỗng thì load lại full
            }
            else
            {
                try
                {
                    dgvHopDong.DataSource = bus.Search(txtTim.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
                }
            }
        }

        private void txtGia_TextChanged(object sender, EventArgs e)
        {
            TinhTong();
        }

        private void txtVAT_TextChanged(object sender, EventArgs e)
        {
            TinhTong();
        }

        private void txtPhi_TextChanged(object sender, EventArgs e)
        {
            TinhTong();
        }

        private void txtVay_TextChanged(object sender, EventArgs e)
        {
            TinhTong();
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHD.Text))
            {
                MessageBox.Show("⚠ Vui lòng chọn hợp đồng cần sửa!",
                                "Chưa chọn",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // 🔴 Thiếu dữ liệu
            if (string.IsNullOrWhiteSpace(txtSoHD.Text) ||
                string.IsNullOrWhiteSpace(txtMaDongXe.Text) ||
                string.IsNullOrWhiteSpace(txtMaKhachHang.Text) ||
                string.IsNullOrWhiteSpace(txtMaNhanVien.Text) ||
                string.IsNullOrWhiteSpace(txtGia.Text) ||
                string.IsNullOrWhiteSpace(txtVAT.Text) ||
                string.IsNullOrWhiteSpace(txtPhi.Text) ||
                string.IsNullOrWhiteSpace(txtTong.Text))
            {
                MessageBox.Show("⚠ Vui lòng nhập đầy đủ thông tin trước khi sửa!",
                                "Thiếu dữ liệu",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            try
            {
                HopDongDTO hd = new HopDongDTO();

                hd.MaHopDong = int.Parse(txtMaHD.Text);
                hd.SoHopDong = txtSoHD.Text;

                hd.MaDongXe = Convert.ToInt32(txtMaDongXe.Text);
                hd.MaKhachHang = Convert.ToInt32(txtMaKhachHang.Text);
                hd.MaNhanVien = Convert.ToInt32(txtMaNhanVien.Text);

                hd.NgayKy = dtNgayKy.Value;

                hd.GiaBanThoaThuan = decimal.Parse(txtGia.Text);
                hd.ThueVAT = decimal.Parse(txtVAT.Text);
                hd.PhiTruocBa = decimal.Parse(txtPhi.Text);
                hd.TienNganHangChoVay = decimal.Parse(txtVay.Text);

                hd.TongGiaTriHopDong = decimal.Parse(txtTong.Text);
                hd.SoTienDaDatCoc = decimal.Parse(txtDatCoc.Text);

                hd.GhiChu = txtGhiChu.Text;
                hd.Trangthai = cmbTrangThai.Text;

                bus.Update(hd);

                MessageBox.Show("✅ Sửa thành công!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi: " + ex.Message);
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            int id = int.Parse(txtMaHD.Text);

            if (MessageBox.Show("Bạn chắc chắn xóa?",
                "Thông báo",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bus.Delete(id);

                MessageBox.Show("Xóa thành công");

                LoadData();
                ClearText();
            }
        }
    }
}