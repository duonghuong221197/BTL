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
    public partial class frmHoaDon : Form
    {
        KhachBUS khachBUS = new KhachBUS();
        NhanVienBUS nhanvien = new NhanVienBUS();
        HangBUS hangBus = new HangBUS();
        HoaDonBanBUS hoadonBus = new HoaDonBanBUS();
        KhachBUS khach = new KhachBUS();
        public frmHoaDon()
        {
            InitializeComponent();
            cboMaKH.DataSource = khachBUS.data();
            cboMaKH.DisplayMember = "MaKhach";

            comboBox2.DataSource = nhanvien.data();
            comboBox2.DisplayMember = "MaNhanVien";
            dgvHoaDon.DataSource = hoadonBus.data();
            this.Size = new Size(687, 475);

            cboSearch.DataSource = hoadonBus.data();
            cboSearch.DisplayMember = "MaHDBan";
            cboSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboSearch.AutoCompleteSource = AutoCompleteSource.ListItems;
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

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dgvHoaDon.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                txtMaHD.Text = row.Cells[0].Value.ToString();
                comboBox2.Text = row.Cells[1].Value.ToString();
                mskNgayBan.Text = row.Cells[2].Value.ToString();
                cboMaKH.Text = row.Cells[3].Value.ToString();
                
                
            }
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            frmMain fr = new frmMain();
            fr.Show();
            this.Hide();
        }

        private void btThemmoi_Click(object sender, EventArgs e)
        {
            frmThemHoaDon fr = new frmThemHoaDon();
            fr.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = txtMaHD.Text;
            if (String.IsNullOrEmpty(user))
            {
                MessageBox.Show("Bạn chưa nhập mã khách ");
            }
            else
            {
                try
                {
                    int addrow = hoadonBus.xoa(user);
                    if (addrow > 0)
                    {
                        MessageBox.Show("Xóa Hóa Đơn Thành Công");
                        txtMaHD.Text = "";
                        cboMaKH.Text = "";
                        comboBox2.Text = "";
                        dgvHoaDon.DataSource = hoadonBus.data();

                    }
                }
                catch (SqlException ex)
                {

                    MessageBox.Show("Thêm thất bại! \n\n" + ex.ToString());
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MaHD.MaHDon = txtMaHD.Text;
            MaHD.MaNV = comboBox2.Text;
            MaHD.MaKhach = cboMaKH.Text;
            frmHoaDonBan fr = new frmHoaDonBan();
            fr.Show();
            this.Hide();

        }

        public class MaHD
        {
            static public string MaHDon;
            static public string MaKhach;
            static public string MaNV;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            cboSearch.Enabled = true;
            button2.Enabled = true;
            btnTim.Visible = false;
            btnHien.Visible = true;
        }

        private void btnHien_Click(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = hoadonBus.data();
            btnHien.Visible = false;
            btnTim.Visible = true;
            cboSearch.Enabled = false;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string search = cboSearch.Text;
            if (String.IsNullOrEmpty(search))
            {
                MessageBox.Show("Bạn chưa nhập mã");
            }
            else
            {
                try
                {
                    dgvHoaDon.DataSource = hoadonBus.dataValue(search);

                }
                catch (SqlException ex)
                {

                    MessageBox.Show("Lỗi! \n\n" + ex.ToString());
                }
            }
        }
    }
}
