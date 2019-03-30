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
    public partial class frmDangNhap : Form
    {
        LoginBUS login = new LoginBUS();
        public frmDangNhap()
        {
            InitializeComponent();
            txtMatkhau.UseSystemPasswordChar = true;
        }

       
        private void btOk_Click(object sender, EventArgs e)
        {
            string user, pass;
            user = txtTaikhoan.Text;
            pass = txtMatkhau.Text;
            bool rls = false;
            try
            {
                LoginDTO acc = new LoginDTO(user, pass);
                rls = login.Login(acc);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            if (rls == true)
            {
                
                frmMain fr = new frmMain();
                fr.Show();              
                Visible = false;
            }
            else
            {
                lbDangNhap.Text = "Tên đăng nhập hoặc mật khẩu không đúng";
                txtTaikhoan.Text = "";
                txtMatkhau.Text = "";
                txtTaikhoan.Focus();
            }
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkHienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienThiMatKhau.Checked)
            {
                txtMatkhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatkhau.UseSystemPasswordChar = true;
            }
        }

        private void lklDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDangKyTK fr = new frmDangKyTK();
            fr.Show();
            this.Hide();
        }
    }
}
