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
    public partial class frmDangKyTK : Form
    {
        LoginBUS loginBUS = new LoginBUS();
        public frmDangKyTK()
        {
            InitializeComponent();
            txtMatkhau.UseSystemPasswordChar = true;
            txtNhapLaiMatKhau.UseSystemPasswordChar = true;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            string user, pass, passNewRepeat;
            user = txtTaikhoan.Text;
            pass = txtMatkhau.Text;          
            passNewRepeat = txtNhapLaiMatKhau.Text;
            LoginDTO login = new LoginDTO(user, pass);

            if (pass != passNewRepeat)
            {
                label7.Text = "Mật khẩu mới nhập nhập lại không đúng!";
            }
            else
            {
                try
                {
                    int rl = loginBUS.InsertAccount(login);
                    if (rl > 0)
                    {
                        MessageBox.Show("Đăng ký tài khoản thành công");
                        this.Visible = false;
                        frmDangNhap fr = new frmDangNhap();
                        fr.Show();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không hợp lệ! \n");
                        txtTaikhoan.Text = "";
                        txtMatkhau.Text = "";
                      
                        txtNhapLaiMatKhau.Text = "";
                        txtTaikhoan.Focus();
                    }
                }
                catch (SqlException )
                {
                    MessageBox.Show("Tài Khoản này đã tồn tại! \n" );
                }

            }
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmDangNhap fr = new frmDangNhap();
            fr.Show();
        }
    }
}
