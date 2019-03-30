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
    public partial class frmThemHang : Form
    {
        HangBUS hangBUS = new HangBUS();
        DMChatLieuBUS dmcl = new DMChatLieuBUS();
        public frmThemHang()
        {
            InitializeComponent();
            cboMachatlieu.DataSource = dmcl.data();
            cboMachatlieu.DisplayMember = "MaChatLieu";
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            frmDMHang fr = new frmDMHang();
            fr.Show();
            this.Hide();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                string MaHang = txtMahang.Text.Trim();
                string TenHang = txtTenhang.Text.Trim();
                string MaChatLieu = cboMachatlieu.Text.Trim();
                float SoLuong = float.Parse(txtSoluong.Text);
                float GiaNhap = float.Parse(txtDongianhap.Text);
                float GiaBan = float.Parse(txtDongiaban.Text);
                string Anh = txtAnh.Text;
                string GhiChu = txtGhichu.Text;
                DateTime date = (DateTime.Parse(mskNgayXuat.Text)).Date;
                if (String.IsNullOrEmpty(MaHang) || String.IsNullOrEmpty(TenHang) || String.IsNullOrEmpty(MaChatLieu))
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ dữ liệu");
                }
                else
                {
                    DMHangDTO user = new DMHangDTO(MaHang, TenHang, MaChatLieu, SoLuong, GiaNhap, GiaBan, Anh, GhiChu, date);
                    try
                    {
                        int addrow = hangBUS.them(user);
                        if (addrow > 0)
                        {
                            MessageBox.Show("Thêm Hàng Hóa Thành Công");
                            frmDMHang fr = new frmDMHang();
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
                
                MessageBox.Show("Bạn chưa nhập đầy đủ dữ liệu");
            }
        }
    }
}
