using Bus;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class Xetrongkho : Form
    {
       
        bool isThem = false;

        private void ResetValues()
        {
            txtMadongxe.Text = "";
            txtTenxe.Text = "";
            txtNamsanxuat.Text = "";
            txtGianiemyet.Text = "";
            txtMausac.Text = "";
            txtSokhung.Text = "";
            txtSomay.Text = "";
            txtXuatsu.Text = "";
            txtLoainhienlieu.Text = "";
            numericUpDown1.Value = 0;

            txtSomay.Enabled = true;
            txtMadongxe.Enabled = true;
            txtTenxe.Enabled = true;
            txtNamsanxuat.Enabled = true;
            numericUpDown1.Enabled = true;
            txtXuatsu.Enabled = true;
            txtLoainhienlieu.Enabled = true;
            txtMausac.Enabled = true;
            txtSokhung.Enabled = true;
            txtGianiemyet.Enabled = true;
        }

        private void SetControlState(bool editing)
        {
           
            btn_Them.Enabled = !editing;
            btn_Sua.Enabled = !editing;
            btn_Xoa.Enabled = !editing;
            btnLuu.Enabled = editing;
            btnHuy.Enabled = editing;
            
        }
        string quyen;
        KhachhangBus bus = new KhachhangBus();
        public Xetrongkho(string q)
        {
            InitializeComponent();
            quyen = q;
        }

        private void Xetrongkho_Load(object sender, EventArgs e)
        {
            Load_Data();
            txtMadongxe.Enabled = false;
            if (quyen != "Admin")
            {

                btn_Xoa.Enabled = false;
            }

        }
        void Load_Data()
        {
            dataGridView1.DataSource = bus.GetKhachhang();

        }
        XetrongkhoBus busXe = new XetrongkhoBus();

        public Xetrongkho()
        {
            InitializeComponent();
        }

    
       

        private void LoadDataGrid()
        {
            dataGridView1.DataSource = busXe.GetDanhSachXe();
        }

     

       

        private void Xetrongkho_Load_1(object sender, EventArgs e)
        {
            LoadDataGrid();
            SetControlState(false);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            
            XetrongkhoDTO xe = new XetrongkhoDTO();
            xe.MaDongXe = txtMadongxe.Text;
            xe.TenXe = txtMadongxe.Text;

           
            int namSanXuat;
            if (!int.TryParse(txtNamsanxuat.Text, out namSanXuat))
            {
                MessageBox.Show("Vui lòng nhập Năm sản xuất là một số nguyên hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNamsanxuat.Focus(); 
                return;
            }
            xe.NamSanXuat = namSanXuat; 

          
            decimal giaNiemYet;
            if (!decimal.TryParse(txtGianiemyet.Text, out giaNiemYet))
            {
                MessageBox.Show("Vui lòng nhập Giá niêm yết là một số hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGianiemyet.Focus();
                return;
            }
            xe.GiaNiemYet = giaNiemYet;

           
            xe.SoChoNgoi = (int)numericUpDown1.Value;
            xe.MauSac = txtMausac.Text;
            xe.SoKhung = txtSokhung.Text;
            xe.SoMay = txtSomay.Text;
            xe.XuatXu = txtXuatsu.Text;
            xe.LoaiNhienLieu = txtLoainhienlieu.Text;

           
            if (busXe.ThemXe(xe))
            {
                MessageBox.Show("Thêm xe thành công!");
                LoadDataGrid(); 
            }
            else
            {
                MessageBox.Show("Thêm xe thất bại!");
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
            if (e.RowIndex >= 0)
            {
               
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                
                txtMadongxe.Text = row.Cells["MaDongXe"].Value?.ToString();
                txtTenxe.Text = row.Cells["TenXe"].Value?.ToString();
                txtNamsanxuat.Text = row.Cells["NamSanXuat"].Value?.ToString();

               
                txtGianiemyet.Text = row.Cells["GiaNiemYet"].Value?.ToString();

              
                if (row.Cells["SoChoNgoi"].Value != null && row.Cells["SoChoNgoi"].Value != DBNull.Value)
                {
                    numericUpDown1.Value = Convert.ToDecimal(row.Cells["SoChoNgoi"].Value);
                }
                else
                {
                    numericUpDown1.Value = 0;
                }

                txtMausac.Text = row.Cells["MauSac"].Value?.ToString();
                txtSokhung.Text = row.Cells["SoKhung"].Value?.ToString();
                txtSomay.Text = row.Cells["SoMay"].Value?.ToString();
                txtXuatsu.Text = row.Cells["XuatXu"].Value?.ToString();
                txtLoainhienlieu.Text = row.Cells["LoaiNhienLieu"].Value?.ToString();
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSomay.Text))
            {
                MessageBox.Show("Vui lòng click chọn một chiếc xe dưới danh sách để sửa giá!");
                return;
            }

            isThem = false;
            SetControlState(true);

          
            txtSomay.Enabled = false;
            txtMadongxe.Enabled = false;
            txtTenxe.Enabled = false;
            txtNamsanxuat.Enabled = false;
            numericUpDown1.Enabled = false;
            txtXuatsu.Enabled = false;
            txtLoainhienlieu.Enabled = false;
            txtMausac.Enabled = false; 
            txtSokhung.Enabled = false; 

           
            txtGianiemyet.Enabled = true;
            txtGianiemyet.Focus(); 
        }
        

        private void btnLuu_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(txtSomay.Text) || string.IsNullOrWhiteSpace(txtSokhung.Text) || string.IsNullOrWhiteSpace(txtMadongxe.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã dòng xe, Số máy và Số khung!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            XetrongkhoDTO xe = new XetrongkhoDTO();
            xe.MaDongXe = txtMadongxe.Text;
            xe.TenXe = txtTenxe.Text;

           
            int namSanXuat;
            if (!int.TryParse(txtNamsanxuat.Text, out namSanXuat))
            {
                MessageBox.Show("Năm sản xuất phải là số nguyên!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNamsanxuat.Focus();
                return;
            }
            xe.NamSanXuat = namSanXuat;

          
            decimal giaNiemYet;
            if (!decimal.TryParse(txtGianiemyet.Text, out giaNiemYet))
            {
                MessageBox.Show("Giá niêm yết phải là số hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGianiemyet.Focus();
                return;
            }
            xe.GiaNiemYet = giaNiemYet;

         
            xe.SoChoNgoi = (int)numericUpDown1.Value;
            xe.MauSac = txtMausac.Text;
            xe.SoKhung = txtSokhung.Text;
            xe.SoMay = txtSomay.Text;
            xe.XuatXu = txtXuatsu.Text;
            xe.LoaiNhienLieu = txtLoainhienlieu.Text;

          
            try
            {
                if (isThem == true)
                {
                   
                    if (busXe.ThemXe(xe))
                    {
                        MessageBox.Show("Thêm xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGrid();          
                        SetControlState(false);  
                        ResetValues();            
                    }
                    else
                    {
                        MessageBox.Show("Thêm xe thất bại! (Kiểm tra lại xem Số máy/Số khung có bị trùng không)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                   
                    if (busXe.SuaXe(xe))
                    {
                        MessageBox.Show("Cập nhật thông tin xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGrid();          
                        SetControlState(false);  
                        ResetValues();
                        txtSomay.Enabled = true;  
                    }
                    else
                    {
                        MessageBox.Show("Sửa xe thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            ResetValues();

          
            LoadDataGrid();

           
            SetControlState(false);

            
            txtSomay.Enabled = true;

            
            isThem = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
          
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn hủy bỏ thao tác đang làm không?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
               
                ResetValues();

              
                SetControlState(false);

               
                txtSomay.Enabled = true;

               
                isThem = false;

                
                dataGridView1.ClearSelection();
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
          
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi màn hình Quản lý xe không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

          
            if (result == DialogResult.Yes)
            {
                this.Close(); 
            }
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
           
            string tuKhoa = txtTimKiem.Text.Trim();

           
            if (string.IsNullOrEmpty(tuKhoa))
            {
                LoadDataGrid();
                return;
            }

           
            DataTable dtKetQua = busXe.TimKiemXe(tuKhoa);

            if (dtKetQua.Rows.Count > 0)
            {
                dataGridView1.DataSource = dtKetQua; 
            }
            else
            {
                MessageBox.Show("Không tìm thấy chiếc xe nào khớp với từ khóa: " + tuKhoa, "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
           
            string soMayCanXoa = txtSomay.Text.Trim();
            if (string.IsNullOrEmpty(soMayCanXoa))
            {
                MessageBox.Show("Vui lòng click chọn một chiếc xe dưới danh sách để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa chiếc xe có Số máy: " + soMayCanXoa + " ra khỏi kho không?\nHành động này không thể hoàn tác!", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

           
            if (dr == DialogResult.Yes)
            {
                try
                {
                    
                    if (busXe.XoaXe(soMayCanXoa))
                    {
                        MessageBox.Show("Đã xóa xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        
                        LoadDataGrid(); 
                        ResetValues(); 
                    }
                    else
                    {
                        MessageBox.Show("Xóa xe thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show("Không thể xóa xe này vì dữ liệu đang bị ràng buộc (Có thể xe đã được lập Hợp đồng).\n\nChi tiết hệ thống: " + ex.Message, "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
