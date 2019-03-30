using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO;
using BUS;
using System.Data.SqlClient;

namespace BaiTapQLBH
{
    public partial class frmThemKH : Form
    {
        KhachBUS khach = new KhachBUS();
        public frmThemKH()
        {
            InitializeComponent();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                string MaKhach = txtMakhach.Text;
                string TenKhach = txtTenkhach.Text;
                string DiaChi = txtDiachi.Text;
                string DienThoai = mskDienthoai.Text;
                if (String.IsNullOrEmpty(MaKhach) || String.IsNullOrEmpty(TenKhach))
                {
                    MessageBox.Show("Bạn chưa nhập mã khách hoặc tên khách");
                }
                else
                {
                    KhachDTO user = new KhachDTO(MaKhach, TenKhach, DiaChi, DienThoai);
                    try
                    {
                        int rl = khach.them(user);
                        if (rl > 0)
                        {
                            MessageBox.Show("Thêm Khách Hàng Thành Công");

                            frmKhachhang fr = new frmKhachhang();
                            fr.Show();
                            this.Hide();

                        }
                    }
                    catch (SqlException ex)
                    {

                        MessageBox.Show("Thêm thất bại! \n\n" + ex.ToString());
                    }
                }
            }
            catch (Exception)
            {
                
                MessageBox.Show("Bạn chưa đủ dữ liệu");
            }
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            frmKhachhang fr = new frmKhachhang();
            fr.Show();
            this.Hide();
        }
    }
}
