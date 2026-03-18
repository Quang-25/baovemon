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

        }

        private void btnKhachhang_Click(object sender, EventArgs e)
        {
            FormKhachhang f = new FormKhachhang(quyen);
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
<<<<<<< HEAD
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();

            frmNhanVien f = new frmNhanVien();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;

            panel2.Controls.Add(f);
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();

            frmHopDong f = new frmHopDong();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;

            panel2.Controls.Add(f);
            f.Show();
=======
>>>>>>> 3b4f7bb32175937fe83f3b329f4aa45a36c85c05
        }
    }
}
