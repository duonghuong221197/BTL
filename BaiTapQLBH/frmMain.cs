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

namespace BaiTapQLBH
{
    public partial class frmMain : Form
    {
       

        public frmMain()
        {
            InitializeComponent();
            this.Show();
           
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Show();
    
        }

        private void mnuChatlieu_Click(object sender, EventArgs e)
        {
            frmDMChatlieu frmChatlieu = new frmDMChatlieu(); //Khởi tạo đối tượng
            frmChatlieu.Show(); //Hiển thị
            this.Visible = false;
        }

        private void mnuNhanvien_Click(object sender, EventArgs e)
        {
            frmNhanVien frmnhanvien = new frmNhanVien(); //Khởi tạo đối tượng
            frmnhanvien.Show(); //Hiển thị
            Visible=false;
        }

        private void mnuKhachhang_Click(object sender, EventArgs e)
        {
            frmKhachhang frmkhachhang = new frmKhachhang(); //Khởi tạo đối tượng
            frmkhachhang.Show(); //Hiển thị
            Visible=false;
        }

        private void mnuHanghoa_Click(object sender, EventArgs e)
        {
            frmDMHang frmdmhang = new frmDMHang(); //Khởi tạo đối tượng
            frmdmhang.Show(); //Hiển thị
            Visible=false;
        }

        private void mnuHoadonban_Click(object sender, EventArgs e)
        {
            frmHoaDon frmhoadonban = new frmHoaDon(); //Khởi tạo đối tượng
            frmhoadonban.Show(); //Hiển thị
            Visible=false;
        }



        private void mnuDangNhap_Click_1(object sender, EventArgs e)
        {
            frmDangNhap frmlogin = new frmDangNhap();
            frmlogin.Show();
            Visible=false;
        }

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frmdoimatkhau = new frmDoiMatKhau();
            frmdoimatkhau.Show();
            Visible=false;
        }

      
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            frmDangNhap fr = new frmDangNhap();
            fr.Show();
            this.Hide();
        }

        private void saoLưuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackup fr = new frmBackup();
            fr.ShowDialog();

        }

        private void phụcHồiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRestore fr = new frmRestore();
            fr.ShowDialog();
        }

        
     
        
    }
}
