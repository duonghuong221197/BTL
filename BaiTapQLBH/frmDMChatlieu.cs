using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DTO;
using BUS;

namespace BaiTapQLBH
{
    public partial class frmDMChatlieu : Form
    {
        DMChatLieuBUS dmcl = new DMChatLieuBUS();
        public frmDMChatlieu()
        {
            InitializeComponent();
            cboMachatlieu.DataSource = dmcl.data();
            cboMachatlieu.DisplayMember = "MaChatLieu";
            cboMachatlieu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboMachatlieu.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void frmDMChatlieu_Load(object sender, EventArgs e)
        {
            dgvChatLieu.DataSource = dmcl.data();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemChatLieu fr = new frmThemChatLieu();
            fr.Show();
            this.Hide();       
        }

        private void dgvChatLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectrows = e.RowIndex;
            txtMachatlieu.Text = dgvChatLieu.Rows[selectrows].Cells[0].Value.ToString();
            txtTenchatlieu.Text = dgvChatLieu.Rows[selectrows].Cells[1].Value.ToString();
            
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain fr = new frmMain();
            fr.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string user = txtMachatlieu.Text;
            if (String.IsNullOrEmpty(user))
            {
                MessageBox.Show("Bạn chưa nhập mã khách ");
            }
            else
            {
                try
                {
                    int addrow = dmcl.xoa(user);
                    if (addrow > 0)
                    {
                        MessageBox.Show("Xóa Chất Liệu Thành Công");
                        txtMachatlieu.Text = "";
                        txtTenchatlieu.Text = "";
                        dgvChatLieu.DataSource = dmcl.data();

                    }
                }
                catch (SqlException ex)
                {

                    MessageBox.Show("Xóa thất bại! \n\n" + ex.ToString());
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string Macl = txtMachatlieu.Text.Trim();
            string Tencl = txtTenchatlieu.Text.Trim();

            if (String.IsNullOrEmpty(Macl) || String.IsNullOrEmpty(Tencl))
            {
                MessageBox.Show("Bạn chưa nhập mã khách hoặc tên khách");
            }
            else
            {
                DMChatLieuDTO user = new DMChatLieuDTO(Macl, Tencl);
                try
                {
                    int addrow = dmcl.sua(user);
                    if (addrow > 0)
                    {
                        MessageBox.Show("Sửa Chất Liệu Thành Công");
                        txtMachatlieu.Text = "";
                        txtTenchatlieu.Text = "";

                        dgvChatLieu.DataSource = dmcl.data();

                    }
                }
                catch (SqlException ex)
                {

                    MessageBox.Show("Sửa thất bại! \n\n" + ex.ToString());
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvChatLieu.DataSource = dmcl.data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string search = cboMachatlieu.Text;
            if (String.IsNullOrEmpty(search))
            {
                MessageBox.Show("Bạn chưa nhập mã");
            }
            else
            {
                try
                {
                   dgvChatLieu.DataSource = dmcl.dataValue(search);
                }
                catch (SqlException ex)
                {

                    MessageBox.Show("Lỗi! \n\n" + ex.ToString());
                }
            }
        }
    }
}
