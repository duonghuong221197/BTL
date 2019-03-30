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
    public partial class frmRestore : Form
    {
        BackupAndRestoreBUS backupandrestore = new BackupAndRestoreBUS();
        public frmRestore()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SQL SERVER database backup files|*.bak";
            dlg.Title = "Database restore";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dlg.FileName;
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                backupandrestore.restore(textBox1.Text);

                MessageBox.Show("Phục Hồi Dữ Liệu Thành Công");
                this.Close();

            }
            catch (SqlException ex)
            {

                MessageBox.Show("Phục Hồi Dữ Liệu thất bại! \n\n" + ex.ToString());
            }
        }
    }
}
