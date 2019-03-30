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
using DAO;
using DTO;

namespace BaiTapQLBH
{
    public partial class frmDoiMatKhau : Form
    {
        LoginBUS loginBUS = new LoginBUS();
        public frmDoiMatKhau()
        {
            InitializeComponent();
            txtTenDangNhap.Focus();
            txtMatKhauCu.UseSystemPasswordChar = true;
            txtMatKhauMoi.UseSystemPasswordChar = true;
            txtNhapLaiMatKhau.UseSystemPasswordChar = true;
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            frmMain fr = new frmMain();
            fr.Show();
            this.Hide();
        }

        private void btDongY_Click(object sender, EventArgs e)
        {
            string user, pass, passNew,passNewRepeat;
            user = txtTenDangNhap.Text;
            pass = txtMatKhauCu.Text;
            passNew = txtMatKhauMoi.Text;
            passNewRepeat = txtNhapLaiMatKhau.Text;
            LoginDTO login = new LoginDTO(user, pass);
            
            if (passNew != passNewRepeat)
            {
                label5.Text = "Mật khẩu mới nhập nhập lại không đúng!";
            }
            else 
            {
                try
                {
                    int rl = loginBUS.UpdateAccount(login, passNew);
                    if (rl > 0)
                    {
                        MessageBox.Show("Thay đổi tài khoản thành công");
                        frmMain fr = new frmMain();
                        fr.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không hợp lệ! \n");
                        txtTenDangNhap.Text = "";
                        txtMatKhauCu.Text = "";
                        txtMatKhauMoi.Text = "";
                        txtNhapLaiMatKhau.Text = "";
                        txtTenDangNhap.Focus();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Không thể thêm dữ liệu .\n" + ex.Message);
                }
            
            }
        }


    }
}
