using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BUS;
using DTO;


namespace BaiTapQLBH
{
    public partial class frmDMHang : Form
    {
        HangBUS hangBUS = new HangBUS();
        public frmDMHang()
        {
            InitializeComponent();
            cboSearch.DataSource = hangBUS.data();
            cboSearch.DisplayMember = "MaHang";
            cboSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboSearch.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void frmDMHang_Load(object sender, EventArgs e)
        {

            dgvDMHang.DataSource = hangBUS.data();
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain fr = new frmMain();
            fr.Show();
        }

        private void dgvDMHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectrows = e.RowIndex;
            txtMahang.Text = dgvDMHang.Rows[selectrows].Cells[0].Value.ToString();
            txtTenhang.Text = dgvDMHang.Rows[selectrows].Cells[1].Value.ToString();
            cboMachatlieu.Text = dgvDMHang.Rows[selectrows].Cells[2].Value.ToString();
            txtSoluong.Text = dgvDMHang.Rows[selectrows].Cells[3].Value.ToString();
            txtDongianhap.Text = dgvDMHang.Rows[selectrows].Cells[4].Value.ToString();
            txtDongiaban.Text = dgvDMHang.Rows[selectrows].Cells[5].Value.ToString();
            txtAnh.Text = dgvDMHang.Rows[selectrows].Cells[6].Value.ToString();
            txtGhichu.Text = dgvDMHang.Rows[selectrows].Cells[7].Value.ToString();
            mskNgayXuat.Text = dgvDMHang.Rows[selectrows].Cells[8].Value.ToString();

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            frmThemHang fr = new frmThemHang();
            fr.Show();
            this.Hide();
        }

       
        private void btSua_Click(object sender, EventArgs e)
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
                    int addrow = hangBUS.sua(user);
                    if (addrow > 0)
                    {
                        MessageBox.Show("Sửa Hàng Hóa Thành Công");
                        txtMahang.Text = "";
                        txtTenhang.Text = "";
                        cboMachatlieu.Text = "";
                        txtSoluong.Text = "";
                        txtDongianhap.Text = "";
                        txtDongiaban.Text = "";
                        txtAnh.Text = "";
                        txtGhichu.Text = "";
                        dgvDMHang.DataSource = hangBUS.data();

                    }
                }
                catch (SqlException ex)
                {

                    MessageBox.Show("Sửa thất bại! \n\n" + ex.ToString());
                }
            }
            
        }

        private void btXoa_Click_1(object sender, EventArgs e)
        {
            string MaHang = txtMahang.Text;
            if (String.IsNullOrEmpty(MaHang))
            {
                MessageBox.Show("Bạn chưa nhập mã hàng ");
            }
            else
            {
                try
                {
                    int addrow = hangBUS.xoa(MaHang);
                    if (addrow > 0)
                    {
                        MessageBox.Show("Xóa Hàng Hóa Thành Công");
                        txtMahang.Text = "";
                        txtTenhang.Text = "";
                        cboMachatlieu.Text = "";
                        txtSoluong.Text = "";
                        txtDongianhap.Text = "";
                        txtDongiaban.Text = "";
                        txtAnh.Text = "";
                        txtGhichu.Text = "";
                        dgvDMHang.DataSource = hangBUS.data();

                    }
                }
                catch (SqlException ex)
                {

                    MessageBox.Show("Xóa thất bại! \n\n" + ex.ToString());
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            cboSearch.Enabled = true;
            button1.Enabled = true;
            btnTim.Visible = false;
            btnHien.Visible = true;
        }

        private void btnHien_Click(object sender, EventArgs e)
        {
            dgvDMHang.DataSource = hangBUS.data();
            btnHien.Visible = false;
            btnTim.Visible = true;
            cboSearch.Enabled = false;
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string search = cboSearch.Text;
            if (String.IsNullOrEmpty(search))
            {
                MessageBox.Show("Bạn chưa nhập mã  ");
            }
            else
            {
                try
                {
                    dgvDMHang.DataSource = hangBUS.getHAValue(search);

                }
                catch (SqlException ex)
                {

                    MessageBox.Show("Lỗi! \n\n" + ex.ToString());
                }
            }
        }

    }
}
