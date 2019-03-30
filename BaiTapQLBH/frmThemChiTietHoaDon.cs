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
    public partial class frmThemChiTietHoaDon : Form
    {
        KhachBUS khachBUS = new KhachBUS();
        NhanVienBUS nhanvien = new NhanVienBUS();
        HangBUS hangBus = new HangBUS();
        HoaDonBUS hoadonBus = new HoaDonBUS();
        HangBUS hangBUS = new HangBUS();
        string tonkho; int conlai;
        public frmThemChiTietHoaDon()
        {
            InitializeComponent();
            cboHang.DataSource = hangBus.data();
            cboHang.DisplayMember = "MaHang";
        }

        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        private void cboHang_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedValue != null)
            {
                DMHangDTO hang = cb.SelectedValue as DMHangDTO;
                txtTenhang.Text = hang.TenHang.ToString();
                txtDongiaban.Text = hang.DonGiaBan.ToString();
                tonkho = hang.SoLuong.ToString();
            }
        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int dongia = int.Parse(txtDongiaban.Text);
                string soluong = txtSoluong.Text;

                if (string.IsNullOrEmpty(soluong))
                {

                    int sl = 1;
                    txtThanhtien.Text = (dongia * sl).ToString();
                }
                else
                {
                    if (IsNumber(soluong) && IsNumber(tonkho))
                    {
                        int sl = int.Parse(txtSoluong.Text);
                        int ton = int.Parse(tonkho);
                        if (sl > ton)
                        {
                            MessageBox.Show("Không đủ hàng");
                            txtSoluong.Text = "";
                        }
                        else
                        {
                            txtThanhtien.Text = (dongia * sl).ToString();
                            conlai = ton - sl;
                            
                        }
                    }
                }

            }
            catch (Exception )
            {
                
                MessageBox.Show("bạn phải nhập số");
            }
        }

        private void btThemmoi_Click(object sender, EventArgs e)
        {
            try
            {
                string MaHD = frmHoaDon.MaHD.MaHDon;
                string MaHang = cboHang.Text;
                float SoLuong = float.Parse(txtSoluong.Text);
                float ThanhTien = float.Parse(txtThanhtien.Text);
                //int addrow = hangBUS.suasoluong(conlai, cboHang.Text);

                if (String.IsNullOrEmpty(MaHang))
                {
                    MessageBox.Show("Bạn chưa nhập mã hàng");
                }
                else
                {
                    HoaDonDTO user = new HoaDonDTO(MaHD, MaHang, SoLuong, ThanhTien);
                    try
                    {
                        int rl = hoadonBus.them(user);
                        int addrow = hangBUS.suasoluong(conlai, cboHang.Text);
                        if (rl > 0)
                        {
                            MessageBox.Show("Thêm Chi Tiết Hóa Đơn Thành Công");
                            frmHoaDonBan fr = new frmHoaDonBan();
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
                
               MessageBox.Show("Bạn chưa nhập mã hàng");
            }
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            frmHoaDonBan fr = new frmHoaDonBan();
            fr.Show();
            this.Hide();
        }

       
    }
}
