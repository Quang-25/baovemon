using Baibaovemon.GUI;
using GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baibaovemon
{
    public partial class form1 : Form
    {
        string quyen;
        public form1(string q)
        {
            InitializeComponent(); 
            quyen= q;

        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }  

        private void form1_Load(object sender, EventArgs e)
        {
            lbl_hienthi.Text = "Xin chào: " + CurrentUser.TenDangNhap;

        }

        private void btnKhachhang_Click(object sender, EventArgs e)
        {
            FormKhachhang f = new FormKhachhang(quyen);
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            frmNhanVien f = new frmNhanVien();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            frmHopDong f = new frmHopDong();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
            


        }

        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Ban co muon dang xuat","Thong bao",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FormDangNhap f = new FormDangNhap();
                f.Show();
                this.Hide();

            }
        }

        private void đổiMậtKhẩuToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void btn_doimatkhau_Click(object sender, EventArgs e)
        {
            FormDoimatkhau f = new FormDoimatkhau();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        private void lbl_hienthi_Click(object sender, EventArgs e)
        {
            
        }
    }
}
