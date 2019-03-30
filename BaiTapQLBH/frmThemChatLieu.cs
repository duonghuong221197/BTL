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
    public partial class frmThemChatLieu : Form
    {
        DMChatLieuBUS dmcl = new DMChatLieuBUS();
        public frmThemChatLieu()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            frmDMChatlieu fr = new frmDMChatlieu();
            fr.Show();
            this.Hide();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string MaChatLieu = txtMachatlieu.Text;
                string TenChatLieu = txtMachatlieu.Text;
                if (String.IsNullOrEmpty(MaChatLieu) || String.IsNullOrEmpty(TenChatLieu))
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin!");
                }
                else
                {
                    DMChatLieuDTO user = new DMChatLieuDTO(MaChatLieu, TenChatLieu);
                    try
                    {
                        int rl = dmcl.them(user);
                        if (rl > 0)
                        {
                            MessageBox.Show("Thêm Chất Liệu Thành Công");
                            frmDMChatlieu fr = new frmDMChatlieu();
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
                
               MessageBox.Show("Bạn chưa nhập đủ thông tin!");
            }
            
        }
    }
}
