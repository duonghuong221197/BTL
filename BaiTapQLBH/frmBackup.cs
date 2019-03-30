using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS;
using System.Data.SqlClient;

namespace BaiTapQLBH
{
    public partial class frmBackup : Form
    {
        BackupAndRestoreBUS backupandrestore = new BackupAndRestoreBUS();
        public frmBackup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dlg.SelectedPath;
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                int addrow = backupandrestore.backup(textBox1.Text);

                MessageBox.Show("Sao Lưu Dữ Liệu Thành Công");
                this.Close();
               
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Sao Lưu Dữ Liệu thất bại! \n\n" + ex.ToString());
            }
           
        }
    }
}
