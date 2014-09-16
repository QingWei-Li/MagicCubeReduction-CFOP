using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CFOP魔方还原
{
    public partial class about : Form
    {
        public about()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject("我是傻逼");
            MessageBox.Show("复制成功");
        }

        private void lbl_author_Click(object sender, EventArgs e)
        {
            MessageBox.Show("点");
            MessageBox.Show("你");
            MessageBox.Show("大");
            MessageBox.Show("爷");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
                MessageBox.Show("让你手贱");
        }
        private void pnl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                pnl1.BackColor = Color.Red;
            }
            else if (e.Button == MouseButtons.Left)
            {
                pnl1.BackColor = Color.RoyalBlue;
            }
        }
        private void pnl2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                pnl2.BackColor = Color.Red;
            }
            else if (e.Button == MouseButtons.Left)
            {
                pnl2.BackColor = Color.RoyalBlue;
            }
        }

        private void pnl3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                pnl3.BackColor = Color.Red;
            }
            else if (e.Button == MouseButtons.Left)
            {
                pnl3.BackColor = Color.RoyalBlue;
            }
        }

        private void pnl4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                pnl4.BackColor = Color.Red;
            }
            else if (e.Button == MouseButtons.Left)
            {
                pnl4.BackColor = Color.RoyalBlue;
            }
        }

        private void pnl5_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                pnl5.BackColor = Color.Red;
            }
            else if (e.Button == MouseButtons.Left)
            {
                pnl5.BackColor = Color.RoyalBlue;
            }
        }

        private void pnl6_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                pnl6.BackColor = Color.Red;
            }
            else if (e.Button == MouseButtons.Left)
            {
                pnl6.BackColor = Color.RoyalBlue;
            }
        }

        private void pnl7_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                pnl7.BackColor = Color.Red;
            }
            else if (e.Button == MouseButtons.Left)
            {
                pnl7.BackColor = Color.RoyalBlue;
            }
        }

        private void pnl8_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                pnl8.BackColor = Color.Red;
            }
            else if (e.Button == MouseButtons.Left)
            {
                pnl8.BackColor = Color.RoyalBlue;
            }
        }

        private void pnl9_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                pnl9.BackColor = Color.Red;
            }
            else if (e.Button == MouseButtons.Left)
            {
                pnl9.BackColor = Color.RoyalBlue;
            }
        }  
    }
}
