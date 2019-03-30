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
    public partial class frmHoaDonBan : Form
    {
        KhachBUS khachBUS = new KhachBUS();
        NhanVienBUS nhanvien = new NhanVienBUS();
        HangBUS hangBus = new HangBUS();
        HoaDonBUS hoadonBus = new HoaDonBUS();
        string soton;
        public frmHoaDonBan()
        {
            InitializeComponent();
            cboMaKH.DataSource = khachBUS.data();
            cboMaKH.DisplayMember = "MaKhach";

            comboBox2.DataSource = nhanvien.data();
            comboBox2.DisplayMember = "MaNhanVien";

            cboHang.DataSource = hangBus.data();
            cboHang.DisplayMember = "MaHang";

        
            txtMaHDBan.Text = frmHoaDon.MaHD.MaHDon;
            comboBox2.Text = frmHoaDon.MaHD.MaNV;
            cboMaKH.Text = frmHoaDon.MaHD.MaKhach;
            dgvHoaDon.DataSource = hoadonBus.data(txtMaHDBan.Text);
            
           
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            frmHoaDon fr = new frmHoaDon();
            fr.Show();
            this.Hide();
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

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedValue != null)
            {
                NhanVienDTO nv = cb.SelectedValue as NhanVienDTO;
                txtTennhanvien.Text = nv.TenNhanVien.ToString();
            }
        }

        private void cboHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedValue != null)
            {
                DMHangDTO hang = cb.SelectedValue as DMHangDTO;
                txtTenhang.Text = hang.TenHang.ToString();
                txtDongiaban.Text = hang.DonGiaBan.ToString();
                soton = hang.SoLuong.ToString();
            }
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectrows = e.RowIndex;
            txtMaHDBan.Text = dgvHoaDon.Rows[selectrows].Cells[0].Value.ToString();
            cboHang.Text = dgvHoaDon.Rows[selectrows].Cells[1].Value.ToString();
            comboBox2.Text = dgvHoaDon.Rows[selectrows].Cells[2].Value.ToString();
            cboMaKH.Text = dgvHoaDon.Rows[selectrows].Cells[3].Value.ToString();
            txtDongiaban.Text = dgvHoaDon.Rows[selectrows].Cells[5].Value.ToString();
            txtSoluong.Text = dgvHoaDon.Rows[selectrows].Cells[4].Value.ToString();
            
            txtThanhtien.Text = dgvHoaDon.Rows[selectrows].Cells[6].Value.ToString();
            mskNgayBan.Text = dgvHoaDon.Rows[selectrows].Cells[7].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string hdban = txtMaHDBan.Text;
            string hang = cboHang.Text;
            //int soluong = int.Parse(txtSoluong.Text);
            int conlai = (int.Parse(soton) + int.Parse(txtSoluong.Text));
            
            if (String.IsNullOrEmpty(hdban) || String.IsNullOrEmpty(hang))
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu");
            }
            else
            {
                try
                {
                    int addrow = hoadonBus.xoa(hdban, hang);
                    int addrow1 = hangBus.suasoluong(conlai, cboHang.Text);
                    if (addrow > 0)
                    {
                        MessageBox.Show("Xóa Chi Tiết Hóa Đơn Thành Công");
                        dgvHoaDon.DataSource = hoadonBus.data(txtMaHDBan.Text);

                    }
                }
                catch (SqlException ex)
                {

                    MessageBox.Show("Thêm thất bại! \n\n" + ex.ToString());
                }
            }
        }

        private void btThemmoi_Click(object sender, EventArgs e)
        {
            frmThemChiTietHoaDon fr = new frmThemChiTietHoaDon();
            fr.Show();
            this.Hide();
           
        }

      
    }
}
