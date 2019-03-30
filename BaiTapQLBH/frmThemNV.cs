using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS;
using DTO;
using System.Data.SqlClient;

namespace BaiTapQLBH
{
    public partial class frmThemNV : Form
    {
        NhanVienBUS nv = new NhanVienBUS();
        public frmThemNV()
        {
            InitializeComponent();
            chkGioitinh.Items.Add("Nam");
            chkGioitinh.Items.Add("Nữ");
            chkGioitinh.SelectedIndex = 1;
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            frmNhanVien fr = new frmNhanVien();
            fr.Show();
            this.Hide();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                string MaNhanVien = txtManhanvien.Text;
                string TenNhanVien = txtTennhanvien.Text;
                string GioiTinh = chkGioitinh.Text;
                string DiaChi = txtDiachi.Text;
                string DienThoai = mskDienthoai.Text;
                DateTime date = (DateTime.Parse(mskNgaysinh.Text)).Date;
                if (string.IsNullOrEmpty(MaNhanVien))
                {
                    return;
                }
                else
                {
                    NhanVienDTO user = new NhanVienDTO(MaNhanVien, TenNhanVien, GioiTinh, DiaChi, DienThoai, date);
                    try
                    {
                        int rl = nv.them(user);
                        if (rl > 0)
                        {
                            MessageBox.Show("Thêm Nhân Viên Thành Công");
                            frmNhanVien fr = new frmNhanVien();
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
                
                MessageBox.Show("Bạn chư nhập đủ dữ liệu");
            }
        }
    }
}
