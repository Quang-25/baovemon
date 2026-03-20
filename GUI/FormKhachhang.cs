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
namespace GUI
{
    public partial class FormKhachhang : Form
    {   
        string quyen;
        KhachhangBus bus = new KhachhangBus();
        public FormKhachhang(string q)
        {
            InitializeComponent();
            quyen = q;
        }

        private void FormKhachhang_Load(object sender, EventArgs e)
        {
            Load_Data();
            textBox1.Enabled = false;
            if ( quyen != "Admin")
            {
             
                btn_Xoa.Enabled = false;
            }
            if (quyen !="Admin")
            {
                btn_Sua.Enabled = false;
            }
        }
        void Load_Data()
        {
            dgv_Khachhang.DataSource = bus.GetKhachhang();

        }

        void ClearText ()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            txt_loc.Clear();
        }
       private void dgv_Khachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_Khachhang.Rows[e.RowIndex];

                if (row.Cells[0].Value != null)
                {
                    textBox1.Text = row.Cells[0].Value.ToString();
                    textBox2.Text = row.Cells[1].Value.ToString();
                    textBox4.Text = row.Cells[2].Value.ToString();
                    textBox3.Text = row.Cells[3].Value.ToString();
                    textBox5.Text = row.Cells[4].Value.ToString();
                }
                else
                {
                    ClearText();
                }
            }
        }

        

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                KhachhangDTO dto = new KhachhangDTO();
                dto.Hoten = textBox2.Text;
                dto.Sodienthoai = textBox4.Text;
                dto.Diachi = textBox5.Text;
                dto.Email = textBox3.Text;
                if (bus.Themkhachhang(dto))
                {
                    MessageBox.Show("Da them thanh cong");
                    Load_Data();
                }
                else
                {
                    MessageBox.Show("ko them duoc");
                    Load_Data();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Lỗi", MessageBoxButtons.OK);
            }
            
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                KhachhangDTO dto = new KhachhangDTO();
                dto.MaKhachHang = int.Parse(textBox1.Text);
                dto.Hoten = textBox2.Text;
                dto.Sodienthoai = textBox4.Text;
                dto.Diachi = textBox5.Text;
                dto.Email = textBox3.Text;
                if (bus.suakhach(dto))
                {
                    MessageBox.Show("Da sua thanh cong");
                    Load_Data();
                }
                else
                {
                    MessageBox.Show("ko sua duoc");

                }
            }
            catch (Exception ex)
            { 
               MessageBox.Show(ex.Message,"Loi",MessageBoxButtons.OK);
            }

        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                KhachhangDTO dto = new KhachhangDTO();
                dto.MaKhachHang = int.Parse(textBox1.Text);
                if (bus.xoakhach(dto))
                {
                    MessageBox.Show("Da xoa thanh cong");
                    Load_Data();
                }
                else
                {
                    MessageBox.Show("ko xoa duoc");
                }
            }
            catch (Exception ex)
            { 
               MessageBox.Show(ex.Message, "Loi", MessageBoxButtons.OK);
            }
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            try
            {
                KhachhangDTO dto = new KhachhangDTO();
                dto.Hoten = textBox6.Text;
                int id;
                if (int.TryParse(textBox6.Text, out id))
                    dto.MaKhachHang = id;
                else
                    dto.MaKhachHang = 0; 
                    dgv_Khachhang.DataSource = bus.Timkiemkhachhang(dto);
                    dgv_Khachhang.DataSource = dto;
                if (dgv_Khachhang.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy khách hàng.");
                    Load_Data();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Loi",MessageBoxButtons.OK);
            }
        }

        private void btn_Huybo_Click(object sender, EventArgs e)
        {
            ClearText();

            dgv_Khachhang.ClearSelection();
            btn_Them.Enabled = true;
            btn_Sua.Enabled = true;
            btn_Xoa.Enabled = true;
            Load_Data();
        }

        private void btn_loc_Click(object sender, EventArgs e)
        {
            try
            {
                KhachhangDTO dto = new KhachhangDTO();
                dto.Diachi = txt_loc.Text;
                dgv_Khachhang.DataSource = bus.lockhachhang(dto);
                if (dgv_Khachhang.Rows.Count == 0)
                {
                    MessageBox.Show("Không loc duoc tên khách hàng.");
                    Load_Data();
                }
            }
            catch (Exception ex)
            { 
               MessageBox.Show(ex.Message, "loi", MessageBoxButtons.OK);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
