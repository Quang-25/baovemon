using System;
using System.Data;
using System.Windows.Forms;
using Bus;
using DTO;
using System.Text.RegularExpressions; // 🔥 thêm dòng này

namespace GUI
{
    public partial class frmNhanVien : Form
    {
        NhanVienBUS bus = new NhanVienBUS();

        public frmNhanVien()
        {
            InitializeComponent();
        }

        void LoadNhanVien()
        {
            dgvNhanVien.DataSource = bus.GetNhanVien();
        }

        void ClearText()
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtDangNhap.Clear();
            txtMatKhau.Clear();
            cmbQuyen.SelectedIndex = -1;
        }

        // 🔥 VALIDATE HỌ TÊN
        bool KiemTraHoTen(string name)
        {
            name = name.Trim();

            if (name.Split(' ').Length < 2)
                return false;

            if (!Regex.IsMatch(name, @"^[A-Za-zÀ-ỹ\s]+$"))
                return false;

            foreach (string w in name.Split(' '))
            {
                if (w.Length < 2)
                    return false;
            }

            return true;
        }

        // 🔥 CHUẨN HÓA TÊN
        string ChuanHoa(string name)
        {
            name = name.Trim().ToLower();
            string[] words = name.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
            }

            return string.Join(" ", words);
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadNhanVien();

            cmbQuyen.Items.Add("Admin");
            cmbQuyen.Items.Add("KeToan");
            cmbQuyen.Items.Add("Sales");

            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.StartPosition = FormStartPosition.CenterScreen;

            this.ControlBox = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtTim.Clear();
            ClearText();
            LoadNhanVien();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text == "" || txtDangNhap.Text == "" || txtMatKhau.Text == "" || cmbQuyen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // 🔥 CHECK HỌ TÊN
            if (!KiemTraHoTen(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không hợp lệ!");
                txtHoTen.Focus();
                return;
            }

            if (bus.TrungTenDangNhap(txtDangNhap.Text))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!");
                txtDangNhap.Focus();
                return;
            }

            try
            {
                NhanVienDTO nv = new NhanVienDTO();

                nv.HoTen = ChuanHoa(txtHoTen.Text); // 🔥 chuẩn hóa
                nv.TenDangNhap = txtDangNhap.Text;
                nv.MatKhau = txtMatKhau.Text;
                nv.Quyen = cmbQuyen.Text;

                bus.Insert(nv);

                MessageBox.Show("Thêm nhân viên thành công");

                LoadNhanVien();
                ClearText();
            }
            catch
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu!");
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                txtMaNV.Text = row.Cells[0].Value.ToString();
                txtHoTen.Text = row.Cells[1].Value.ToString();
                txtDangNhap.Text = row.Cells[2].Value.ToString();
                txtMatKhau.Text = row.Cells[3].Value.ToString();
                cmbQuyen.Text = row.Cells[4].Value.ToString();
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Chọn nhân viên cần sửa");
                return;
            }

            // 🔥 CHECK HỌ TÊN
            if (!KiemTraHoTen(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không hợp lệ!");
                txtHoTen.Focus();
                return;
            }

            if (bus.TrungTenDangNhapKhiSua(Convert.ToInt32(txtMaNV.Text), txtDangNhap.Text))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!");
                return;
            }

            try
            {
                NhanVienDTO nv = new NhanVienDTO();

                nv.MaNhanVien = Convert.ToInt32(txtMaNV.Text);
                nv.HoTen = ChuanHoa(txtHoTen.Text); // 🔥 chuẩn hóa
                nv.TenDangNhap = txtDangNhap.Text;
                nv.MatKhau = txtMatKhau.Text;
                nv.Quyen = cmbQuyen.Text;

                bus.Update(nv);

                MessageBox.Show("Sửa nhân viên thành công");

                LoadNhanVien();
            }
            catch
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu!");
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Chọn nhân viên cần xóa");
                return;
            }

            DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                int id = Convert.ToInt32(txtMaNV.Text);

                bus.Delete(id);

                MessageBox.Show("Xóa thành công");

                LoadNhanVien();
                ClearText();
            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTim.Text))
            {
                LoadNhanVien();
            }
            else
            {
                dgvNhanVien.DataSource = bus.Search(txtTim.Text);
            }
        }

        // 🔥 CHẶN NHẬP BẬY
        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) &&
                !char.IsControl(e.KeyChar) &&
                e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
    }
}