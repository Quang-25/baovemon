using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using  Bus;
using DATA;
using DTO;

namespace Baibaovemon.GUI
{
    public partial class FormDangNhap : Form
    {
        string quyen = "";


        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            NhanVienBus bus = new NhanVienBus();
            

            bool kq = bus.CheckLogin(txtTenDangNhap.Text, txtMatKhau.Text);

            if (kq)
            {
                if (bus.CheckQuyen(txtTenDangNhap.Text, txtMatKhau.Text))
                {
                    quyen = "Admin";
                }
                else
                {
                    quyen = "NhanVien";
                }

                MessageBox.Show("Đăng nhập thành công");

                form1 f = new form1(quyen);
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu");
            }

        }
    }
}    

 
 

