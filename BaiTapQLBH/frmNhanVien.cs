using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DAO;
using DTO;
using BUS;
using System.Globalization;

namespace BaiTapQLBH
{
    
    public partial class frmNhanVien : Form
    {
        NhanVienBUS nv = new NhanVienBUS();
        public frmNhanVien()
        {
            InitializeComponent();
            cboSearch.DataSource = nv.data();
            cboSearch.DisplayMember = "MaNhanVien";
            cboSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboSearch.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = nv.data();
            chkGioitinh.Items.Add( "Nam");
            chkGioitinh.Items.Add( "Nữ");
            chkGioitinh.SelectedIndex=1;
        }

        private void btThem_Click(object sender, EventArgs e)
        {

            frmThemNV fr = new frmThemNV();
            fr.Show();
            this.Hide();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectrows = e.RowIndex;
            txtManhanvien.Text = dgvNhanVien.Rows[selectrows].Cells[0].Value.ToString();
            txtTennhanvien.Text = dgvNhanVien.Rows[selectrows].Cells[1].Value.ToString();
            chkGioitinh.Text = dgvNhanVien.Rows[selectrows].Cells[2].Value.ToString();
            txtDiachi.Text = dgvNhanVien.Rows[selectrows].Cells[3].Value.ToString();
            mskDienthoai.Text = dgvNhanVien.Rows[selectrows].Cells[4].Value.ToString();
            mskNgaysinh.Text = dgvNhanVien.Rows[selectrows].Cells[5].Value.ToString();
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain fr = new frmMain();
            fr.Show();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            string user = txtManhanvien.Text;
            if (String.IsNullOrEmpty(user))
            {
                MessageBox.Show("Bạn chưa nhập mã khách ");
            }
            else
            {
                try
                {
                    int addrow = nv.xoa(user);
                    if (addrow > 0)
                    {
                        MessageBox.Show("Xóa Nhân Viên Thành Công");
                        txtManhanvien.Text = "";
                        txtTennhanvien.Text = "";
                        chkGioitinh.SelectedIndex = 1;
                        txtDiachi.Text = "";
                        mskDienthoai.Text = "";
                        dgvNhanVien.DataSource = nv.data();

                    }
                }
                catch (SqlException ex)
                {

                    MessageBox.Show("Xóa thất bại! \n\n" + ex.ToString());
                }
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string MaNhanVien = txtManhanvien.Text;
            string TenNhanVien = txtTennhanvien.Text;
            string GioiTinh = chkGioitinh.Text;
            string DiaChi = txtDiachi.Text;
            string DienThoai = mskDienthoai.Text;
            DateTime date = (DateTime.Parse(mskNgaysinh.Text)).Date;
            if (String.IsNullOrEmpty(MaNhanVien) || String.IsNullOrEmpty(TenNhanVien) || String.IsNullOrEmpty(GioiTinh) || String.IsNullOrEmpty(DiaChi) || String.IsNullOrEmpty(DienThoai))
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin");
            }
            else
            {
                NhanVienDTO user = new NhanVienDTO(MaNhanVien, TenNhanVien, GioiTinh, DiaChi, DienThoai, date);
                try
                {
                    int addrow = nv.sua(user);
                    if (addrow > 0)
                    {
                        MessageBox.Show("Sửa Khách Hàng Thành Công");
                        txtManhanvien.Text = "";
                        txtTennhanvien.Text = "";
                        txtDiachi.Text = "";
                        chkGioitinh.Text = "";
                        mskDienthoai.Text = "";
                        dgvNhanVien.DataSource = nv.data();

                    }
                }
                catch (SqlException ex)
                {

                    MessageBox.Show("Sửa thất bại! \n\n" + ex.ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string search =cboSearch.Text;
            if (String.IsNullOrEmpty(search))
            {
                MessageBox.Show("Bạn chưa nhập mã ");
            }
            else
            {
                try
                {
                    dgvNhanVien.DataSource = nv.getvnValue(search);

                }
                catch (SqlException ex)
                {

                    MessageBox.Show("Lỗi! \n\n" + ex.ToString());
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
            dgvNhanVien.DataSource = nv.data();
            btnHien.Visible = false;
            btnTim.Visible = true;
            cboSearch.Enabled = false;
            button1.Enabled = false;
        }



    }
}
