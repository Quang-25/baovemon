using Bus;
using DATA;
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
    public partial class Phukienphutung : Form
    {
        
        bool isThem = false;

       
        private void SetControlState(bool editing)
        {
          
            btn_Them.Enabled = !editing;
            btn_Sua.Enabled = !editing;
            button1.Enabled = !editing;

            button8.Enabled = editing;
            btn_Huybo.Enabled = editing;

           
            dataGridView1.Enabled = !editing;
        }
        public Phukienphutung()
        {
            InitializeComponent();
        }

       
        PhukienphutungBus busPK = new PhukienphutungBus();

       
     
        private void LoadData()
        {
            try
            {
                
                DataTable dt = busPK.GetPhuKien();
                dataGridView1.DataSource = dt;

               
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns[0].HeaderText = "Mã phụ kiện";
                    dataGridView1.Columns[1].HeaderText = "Tên phụ kiện";
                    dataGridView1.Columns[2].HeaderText = "Giá niêm yết";
                    dataGridView1.Columns[3].HeaderText = "Năm sản xuất";
                    dataGridView1.Columns[4].HeaderText = "Số lượng tồn";
                    dataGridView1.Columns[5].HeaderText = "Hãng";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối dữ liệu: " + ex.Message);
            }
        }

       
        private void Phukienphutung_Load(object sender, EventArgs e)
        {
            LoadData();
            SetControlState(false);
        }

       
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            isThem = true;         
            SetControlState(true);  

           
            txtMaphukien.Clear();
            txtTenphukien.Clear();
            txtGianiemyet.Text = "0";
            txtSoluongton.Text = "0";
            txtHang.Clear();
            dateTimePicker1.Value = DateTime.Now;

            txtTenphukien.Focus(); 
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtMaphukien.Text))
            {
                MessageBox.Show("Vui lòng click chọn một phụ kiện dưới bảng để sửa!");
                return;
            }

            isThem = false;        
            SetControlState(true); 
            txtTenphukien.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaphukien.Text))
            {
                MessageBox.Show("Vui lòng chọn phụ kiện cần xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int ma = int.Parse(txtMaphukien.Text);
                if (busPK.XoaPhuKien(ma))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
                else MessageBox.Show("Xóa thất bại!");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (string.IsNullOrEmpty(txtTenphukien.Text) || string.IsNullOrEmpty(txtGianiemyet.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Tên và Giá phụ kiện!");
                    return;
                }

              
                PhukiemphutungDTO pk = new PhukiemphutungDTO
                {
                    TenPhuKien = txtTenphukien.Text,
                    DonGia = decimal.Parse(txtGianiemyet.Text),
                    NamSanXuat = dateTimePicker1.Value,
                    SoLuongTon = int.Parse(txtSoluongton.Text),
                    Hang = txtHang.Text
                };

                
                if (isThem == true)
                {
                   
                    if (busPK.ThemPhuKien(pk))
                    {
                        MessageBox.Show("Thêm mới thành công!");
                    }
                    else MessageBox.Show("Thêm mới thất bại!");
                }
                else
                {
                    
                    pk.MaPhuKien = int.Parse(txtMaphukien.Text); 
                    if (busPK.SuaPhuKien(pk))
                    {
                        MessageBox.Show("Cập nhật thành công!");
                    }
                    else MessageBox.Show("Cập nhật thất bại!");
                }

                
                LoadData();
                SetControlState(false);
                button7_Click(sender, e); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtMaphukien.Clear();
            txtTenphukien.Clear();
            txtGianiemyet.Text = "0";
            txtSoluongton.Text = "0";
            txtHang.Clear();
            dateTimePicker1.Value = DateTime.Now;
            txtTenphukien.Focus(); 
        }

        private void btn_Huybo_Click(object sender, EventArgs e)
        {
          
            txtMaphukien.Clear();
            txtTenphukien.Clear();
            txtGianiemyet.Clear();
            txtSoluongton.Clear();
            txtHang.Clear();

           
            dateTimePicker1.Value = DateTime.Now;

          
            dataGridView1.ClearSelection();

          
            SetControlState(false);
            isThem = false;        
            
            txtTenphukien.Focus();

            MessageBox.Show("Đã hủy thao tác và làm mới form!");
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
           
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

          
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = busPK.TimKiemPhuKien(richTextBox1.Text.Trim());
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

               
                txtMaphukien.Text = row.Cells[0].Value?.ToString();
                txtTenphukien.Text = row.Cells[1].Value?.ToString();
                txtGianiemyet.Text = row.Cells[2].Value?.ToString();

               
                if (row.Cells[3].Value != null && row.Cells[3].Value != DBNull.Value)
                {
                    dateTimePicker1.Value = Convert.ToDateTime(row.Cells[3].Value);
                }

                txtSoluongton.Text = row.Cells[4].Value?.ToString();
                txtHang.Text = row.Cells[5].Value?.ToString();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
    
}
