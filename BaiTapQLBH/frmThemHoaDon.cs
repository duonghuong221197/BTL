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
    public partial class frmThemHoaDon : Form
    {
        KhachBUS khachBUS = new KhachBUS();
        NhanVienBUS nhanvien = new NhanVienBUS();
        HangBUS hangBus = new HangBUS();
        HoaDonBanBUS hoadonBus = new HoaDonBanBUS();
        KhachBUS khach = new KhachBUS();
        public frmThemHoaDon()
        {
            InitializeComponent();
            cboMaKH.DataSource = khachBUS.data();
            cboMaKH.DisplayMember = "MaKhach";

            comboBox2.DataSource = nhanvien.data();
            comboBox2.DisplayMember = "MaNhanVien";

            this.Size = new Size(683, 299);
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedValue != null)
            {
                NhanVienDTO nv = cb.SelectedValue as NhanVienDTO;
                txtTennhanvien.Text = nv.TenNhanVien.ToString();
            }
        }

        private void cboMaKH_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedValue != null)
            {
                KhachDTO khach = cb.SelectedValue as KhachDTO;
                txtTen.Text = khach.TenKhach.ToString();
                txtDiachi.Text = khach.DiaChi.ToString();
                txtDienthoai.Text = khach.DienThoai.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1006, 299);
            groupBox2.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string MaKhach = txtMaKhach2.Text;
                string TenKhach = txtTenKhach2.Text;
                string DiaChi = txtDiaChi2.Text;
                string DienThoai = mskDienThoai2.Text;
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

                            groupBox2.Visible = false;
                            this.Size = new Size(687, 299);
                            MessageBox.Show("Thêm Khách Hàng Thành Công");
                            cboMaKH.DataSource = khachBUS.data();
                            txtMaKhach2.Text = "";
                            txtTenKhach2.Text = "";
                            txtDiaChi2.Text = "";
                            mskDienThoai2.Text = "";

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
                
                 MessageBox.Show("Bạn chưa nhập đủ dữ liệu");
            }
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            this.Close();
            frmHoaDon fr = new frmHoaDon();
            fr.Show();
        }

        private void btThemmoi_Click(object sender, EventArgs e)
        {
            string HoaDon = txtMaHD.Text;
            string MaNV = comboBox2.Text;
            DateTime date = (DateTime.Parse(mskNgayBan.Text)).Date;
            string MaKhach = cboMaKH.Text;

            if (String.IsNullOrEmpty(HoaDon) || String.IsNullOrEmpty(MaNV))
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu");
            }
            else
            {
                HoaDonBanDTO user = new HoaDonBanDTO(HoaDon, MaNV, date, MaKhach);
                try
                {
                    int rl = hoadonBus.them(user);
                    if (rl > 0)
                    {
                        MessageBox.Show("Tạo Mới Hóa Đơn Thành Công");
                        frmHoaDon fr = new frmHoaDon();
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
    }
}
