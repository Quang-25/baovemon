using Bus;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class FormDoimatkhau : Form
    {
        public FormDoimatkhau()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            { 
                string mkCu = txtMatKhauCu.Text;
                string mkMoi = txtMatKhauMoi.Text;
                if (string.IsNullOrEmpty(mkCu) || string.IsNullOrEmpty(mkMoi))
                {
                    MessageBox.Show("Không được để trống!");
                    return;
                }

                DoimatkhauDTO dto = new DoimatkhauDTO();
                dto.TenDangNhap = CurrentUser.TenDangNhap; 
                dto.MatKhau = mkCu;
                dto.Matkhaumoi = mkMoi;
                DoimatkhauBus bus = new DoimatkhauBus();

                if (bus.Doimatkhau(dto))
                {
                    MessageBox.Show("Đổi mật khẩu thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không đúng!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormDoimatkhau_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = CurrentUser.TenDangNhap;
        }

       
        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {

        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMatKhauMoi.Clear();
            txtMatKhauCu.Clear();
        }
    }
}

