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
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Xetrongkho f = new Xetrongkho(quyen);
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Phukienphutung f = new Phukienphutung();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }
    }
}
