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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.pnl_up1.Click += new EventHandler(pnl_up1_Click);
            this.pnl_up2.Click += new EventHandler(pnl_up2_Click);
            this.pnl_up3.Click += new EventHandler(pnl_up3_Click);
            this.pnl_up4.Click += new EventHandler(pnl_up4_Click);
            this.pnl_up5.Click += new EventHandler(pnl_up5_Click);
            this.pnl_up6.Click += new EventHandler(pnl_up6_Click);
            this.pnl_up7.Click += new EventHandler(pnl_up7_Click);
            this.pnl_up8.Click += new EventHandler(pnl_up8_Click);

            this.pnl_down1.Click += new EventHandler(pnl_down1_Click);
            this.pnl_down2.Click += new EventHandler(pnl_down2_Click);
            this.pnl_down3.Click += new EventHandler(pnl_down3_Click);
            this.pnl_down4.Click += new EventHandler(pnl_down4_Click);
            this.pnl_down5.Click += new EventHandler(pnl_down5_Click);
            this.pnl_down6.Click += new EventHandler(pnl_down6_Click);
            this.pnl_down7.Click += new EventHandler(pnl_down7_Click);
            this.pnl_down8.Click += new EventHandler(pnl_down8_Click);

           this.pnl_right1.Click += new EventHandler(pnl_right1_Click);
           this.pnl_right2.Click += new EventHandler(pnl_right2_Click);
           this.pnl_right3.Click += new EventHandler(pnl_right3_Click);
           this.pnl_right4.Click += new EventHandler(pnl_right4_Click);
           this.pnl_right5.Click += new EventHandler(pnl_right5_Click);
           this.pnl_right6.Click += new EventHandler(pnl_right6_Click);
           this.pnl_right7.Click += new EventHandler(pnl_right7_Click);
           this.pnl_right8.Click += new EventHandler(pnl_right8_Click);

           this.pnl_left1.Click += new EventHandler(pnl_left1_Click);
           this.pnl_left2.Click += new EventHandler(pnl_left2_Click);
           this.pnl_left3.Click += new EventHandler(pnl_left3_Click);
           this.pnl_left4.Click += new EventHandler(pnl_left4_Click);
           this.pnl_left5.Click += new EventHandler(pnl_left5_Click);
           this.pnl_left6.Click += new EventHandler(pnl_left6_Click);
           this.pnl_left7.Click += new EventHandler(pnl_left7_Click);
           this.pnl_left8.Click += new EventHandler(pnl_left8_Click);

           this.pnl_back1.Click += new EventHandler(pnl_back1_Click);
           this.pnl_back2.Click += new EventHandler(pnl_back2_Click);
           this.pnl_back3.Click += new EventHandler(pnl_back3_Click);
           this.pnl_back4.Click += new EventHandler(pnl_back4_Click);
           this.pnl_back5.Click += new EventHandler(pnl_back5_Click);
           this.pnl_back6.Click += new EventHandler(pnl_back6_Click);
           this.pnl_back7.Click += new EventHandler(pnl_back7_Click);
           this.pnl_back8.Click += new EventHandler(pnl_back8_Click);

           this.pnl_front1.Click += new EventHandler(pnl_front1_Click);
           this.pnl_front2.Click += new EventHandler(pnl_front2_Click);
           this.pnl_front3.Click += new EventHandler(pnl_front3_Click);
           this.pnl_front4.Click += new EventHandler(pnl_front4_Click);
           this.pnl_front5.Click += new EventHandler(pnl_front5_Click);
           this.pnl_front6.Click += new EventHandler(pnl_front6_Click);
           this.pnl_front7.Click += new EventHandler(pnl_front7_Click);
           this.pnl_front8.Click += new EventHandler(pnl_front8_Click);
        }
        //将颜色转换成字符存入魔方
        public char change(Panel pnl)
        {
            if (pnl.BackColor == Color.Red)
                return 'r';
            else if (pnl.BackColor == Color.OrangeRed)
                return 'o';
            else if (pnl.BackColor == Color.Green)
                return 'g';
            else if (pnl.BackColor == Color.White)
                return 'w';
            else if (pnl.BackColor == Color.Blue)
                return 'b';
            else
                return 'y';
        }

        Color color;

        private void btn_red_Click(object sender, EventArgs e)
        {
            color = Color.Red;
        }

        private void btn_orange_Click(object sender, EventArgs e)
        {
            color = Color.OrangeRed;
        }

        private void btn_green_Click(object sender, EventArgs e)
        {
            color = Color.Green;
        }

        private void btn_white_Click(object sender, EventArgs e)
        {
            color = Color.White;
        }

        private void btn_blue_Click(object sender, EventArgs e)
        {
            color = Color.Blue;
        }

        private void btn_yellow_Click(object sender, EventArgs e)
        {
            color = Color.Yellow;
        }

        private void pnl_front1_Click(object sender, EventArgs e)
        {
            pnl_front1.BackColor = color;
        }
        private void pnl_front2_Click(object sender, EventArgs e)
        {
            pnl_front2.BackColor = color;
        }
        private void pnl_front3_Click(object sender, EventArgs e)
        {
            pnl_front3.BackColor = color;
        }
        private void pnl_front4_Click(object sender, EventArgs e)
        {
            pnl_front4.BackColor = color;
        }
        private void pnl_front5_Click(object sender, EventArgs e)
        {
            pnl_front5.BackColor = color;
        }
        private void pnl_front6_Click(object sender, EventArgs e)
        {
            pnl_front6.BackColor = color;
        }
        private void pnl_front7_Click(object sender, EventArgs e)
        {
            pnl_front7.BackColor = color;
        }
        private void pnl_front8_Click(object sender, EventArgs e)
        {
            pnl_front8.BackColor = color;
        }

        private void pnl_back1_Click(object sender, EventArgs e)
        {
            pnl_back1.BackColor = color;
        }
        private void pnl_back2_Click(object sender, EventArgs e)
        {
            pnl_back2.BackColor = color;
        }
        private void pnl_back3_Click(object sender, EventArgs e)
        {
            pnl_back3.BackColor = color;
        }
        private void pnl_back4_Click(object sender, EventArgs e)
        {
            pnl_back4.BackColor = color;
        }
        private void pnl_back5_Click(object sender, EventArgs e)
        {
            pnl_back5.BackColor = color;
        }
        private void pnl_back6_Click(object sender, EventArgs e)
        {
            pnl_back6.BackColor = color;
        }
        private void pnl_back7_Click(object sender, EventArgs e)
        {
            pnl_back7.BackColor = color;
        }
        private void pnl_back8_Click(object sender, EventArgs e)
        {
            pnl_back8.BackColor = color;
        }

        private void pnl_right1_Click(object sender, EventArgs e)
        {
            pnl_right1.BackColor = color;
        }
        private void pnl_right2_Click(object sender, EventArgs e)
        {
            pnl_right2.BackColor = color;
        }
        private void pnl_right3_Click(object sender, EventArgs e)
        {
            pnl_right3.BackColor = color;
        }
        private void pnl_right4_Click(object sender, EventArgs e)
        {
            pnl_right4.BackColor = color;
        }
        private void pnl_right5_Click(object sender, EventArgs e)
        {
            pnl_right5.BackColor = color;
        }
        private void pnl_right6_Click(object sender, EventArgs e)
        {
            pnl_right6.BackColor = color;
        }
        private void pnl_right7_Click(object sender, EventArgs e)
        {
            pnl_right7.BackColor = color;
        }
        private void pnl_right8_Click(object sender, EventArgs e)
        {
            pnl_right8.BackColor = color;
        }

        private void pnl_left1_Click(object sender, EventArgs e)
        {
            pnl_left1.BackColor = color;
        }
        private void pnl_left2_Click(object sender, EventArgs e)
        {
            pnl_left2.BackColor = color;
        }
        private void pnl_left3_Click(object sender, EventArgs e)
        {
            pnl_left3.BackColor = color;
        }
        private void pnl_left4_Click(object sender, EventArgs e)
        {
            pnl_left4.BackColor = color;
        }
        private void pnl_left5_Click(object sender, EventArgs e)
        {
            pnl_left5.BackColor = color;
        }
        private void pnl_left6_Click(object sender, EventArgs e)
        {
            pnl_left6.BackColor = color;
        }
        private void pnl_left7_Click(object sender, EventArgs e)
        {
            pnl_left7.BackColor = color;
        }
        private void pnl_left8_Click(object sender, EventArgs e)
        {
            pnl_left8.BackColor = color;
        }

        private void pnl_up1_Click(object sender, EventArgs e)
        {
            pnl_up1.BackColor = color;
        }
        private void pnl_up2_Click(object sender, EventArgs e)
        {
            pnl_up2.BackColor = color;
        }
        private void pnl_up3_Click(object sender, EventArgs e)
        {
            pnl_up3.BackColor = color;
        }
        private void pnl_up4_Click(object sender, EventArgs e)
        {
            pnl_up4.BackColor = color;
        }
        private void pnl_up5_Click(object sender, EventArgs e)
        {
            pnl_up5.BackColor = color;
        }
        private void pnl_up6_Click(object sender, EventArgs e)
        {
            pnl_up6.BackColor = color;
        }
        private void pnl_up7_Click(object sender, EventArgs e)
        {
            pnl_up7.BackColor = color;
        }
        private void pnl_up8_Click(object sender, EventArgs e)
        {
            pnl_up8.BackColor = color;
        }

        private void pnl_down1_Click(object sender, EventArgs e)
        {
            pnl_down1.BackColor = color;
        }
        private void pnl_down2_Click(object sender, EventArgs e)
        {
            pnl_down2.BackColor = color;
        }
        private void pnl_down3_Click(object sender, EventArgs e)
        {
            pnl_down3.BackColor = color;
        }
        private void pnl_down4_Click(object sender, EventArgs e)
        {
            pnl_down4.BackColor = color;
        }
        private void pnl_down5_Click(object sender, EventArgs e)
        {
            pnl_down5.BackColor = color;
        }
        private void pnl_down6_Click(object sender, EventArgs e)
        {
            pnl_down6.BackColor = color;
        }
        private void pnl_down7_Click(object sender, EventArgs e)
        {
            pnl_down7.BackColor = color;
        }
        private void pnl_down8_Click(object sender, EventArgs e)
        {
            pnl_down8.BackColor = color;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            Cube mycube = new Cube();
            mycube.front[0, 0] = change(pnl_front1);
            mycube.front[0, 1] = change(pnl_front2);
            mycube.front[0, 2] = change(pnl_front3);
            mycube.front[1, 0] = change(pnl_front4);
            mycube.front[1, 1] = 'r';
            mycube.front[1, 2] = change(pnl_front5);
            mycube.front[2, 0] = change(pnl_front6);
            mycube.front[2, 1] = change(pnl_front7);
            mycube.front[2, 2] = change(pnl_front8);

            mycube.back[0, 0] = change(pnl_back1);
            mycube.back[0, 1] = change(pnl_back2);
            mycube.back[0, 2] = change(pnl_back3);
            mycube.back[1, 0] = change(pnl_back4);
            mycube.back[1, 1] = 'o';
            mycube.back[1, 2] = change(pnl_back5);
            mycube.back[2, 0] = change(pnl_back6);
            mycube.back[2, 1] = change(pnl_back7);
            mycube.back[2, 2] = change(pnl_back8);

            mycube.left[0, 0] = change(pnl_left1);
            mycube.left[0, 1] = change(pnl_left2);
            mycube.left[0, 2] = change(pnl_left3);
            mycube.left[1, 0] = change(pnl_left4);
            mycube.left[1, 1] = 'b';
            mycube.left[1, 2] = change(pnl_left5);
            mycube.left[2, 0] = change(pnl_left6);
            mycube.left[2, 1] = change(pnl_left7);
            mycube.left[2, 2] = change(pnl_left8);

            mycube.right[0, 0] = change(pnl_right1);
            mycube.right[0, 1] = change(pnl_right2);
            mycube.right[0, 2] = change(pnl_right3);
            mycube.right[1, 0] = change(pnl_right4);
            mycube.right[1, 1] = 'g';
            mycube.right[1, 2] = change(pnl_right5);
            mycube.right[2, 0] = change(pnl_right6);
            mycube.right[2, 1] = change(pnl_right7);
            mycube.right[2, 2] = change(pnl_right8);

            mycube.up[0, 0] = change(pnl_up1);
            mycube.up[0, 1] = change(pnl_up2);
            mycube.up[0, 2] = change(pnl_up3);
            mycube.up[1, 0] = change(pnl_up4);
            mycube.up[1, 1] = 'y';
            mycube.up[1, 2] = change(pnl_up5);
            mycube.up[2, 0] = change(pnl_up6);
            mycube.up[2, 1] = change(pnl_up7);
            mycube.up[2, 2] = change(pnl_up8);

            mycube.down[0, 0] = change(pnl_down1);
            mycube.down[0, 1] = change(pnl_down2);
            mycube.down[0, 2] = change(pnl_down3);
            mycube.down[1, 0] = change(pnl_down4);
            mycube.down[1, 1] = 'w';
            mycube.down[1, 2] = change(pnl_down5);
            mycube.down[2, 0] = change(pnl_down6);
            mycube.down[2, 1] = change(pnl_down7);
            mycube.down[2, 2] = change(pnl_down8);
            //还原魔方
            listview.Items.Clear();
            mycube.count = 0;
            mycube.sequence[0] = '\0';
            try
            {                
                mycube.Cross(mycube);
                mycube.F2L(mycube);
                mycube.OLL(mycube);
                mycube.PLL(mycube);
                mycube.cut(mycube);

                for (int i = 0;  mycube.str[i] != null; i++)
                {
                    listview.Items.Add((i + 1).ToString());
                    listview.Items[i].SubItems.Add(mycube.str[i]);
                    listview.Items[i].SubItems.Add(mycube.sign[i]);
                }
            }
            catch
            {
                MessageBox.Show("请检查颜色是否填充正确!");
            }         
        }

        private void lbl_about_Click(object sender, EventArgs e)
        {
            about f2 = new about();
            f2.ShowDialog();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            listview.Items.Clear();
            pnl_front1.BackColor = SystemColors.ActiveBorder;
            pnl_front2.BackColor = SystemColors.ActiveBorder;
            pnl_front3.BackColor = SystemColors.ActiveBorder;
            pnl_front4.BackColor = SystemColors.ActiveBorder;
            pnl_front5.BackColor = SystemColors.ActiveBorder;
            pnl_front6.BackColor = SystemColors.ActiveBorder;
            pnl_front7.BackColor = SystemColors.ActiveBorder;
            pnl_front8.BackColor = SystemColors.ActiveBorder;
            pnl_up1.BackColor = SystemColors.ActiveBorder;
            pnl_up2.BackColor = SystemColors.ActiveBorder;
            pnl_up3.BackColor = SystemColors.ActiveBorder;
            pnl_up4.BackColor = SystemColors.ActiveBorder;
            pnl_up5.BackColor = SystemColors.ActiveBorder;
            pnl_up6.BackColor = SystemColors.ActiveBorder;
            pnl_up7.BackColor = SystemColors.ActiveBorder;
            pnl_up8.BackColor = SystemColors.ActiveBorder;
            pnl_down1.BackColor = SystemColors.ActiveBorder;
            pnl_down2.BackColor = SystemColors.ActiveBorder;
            pnl_down3.BackColor = SystemColors.ActiveBorder;
            pnl_down4.BackColor = SystemColors.ActiveBorder;
            pnl_down5.BackColor = SystemColors.ActiveBorder;
            pnl_down6.BackColor = SystemColors.ActiveBorder;
            pnl_down7.BackColor = SystemColors.ActiveBorder;
            pnl_down8.BackColor = SystemColors.ActiveBorder;
            pnl_back1.BackColor = SystemColors.ActiveBorder;
            pnl_back2.BackColor = SystemColors.ActiveBorder;
            pnl_back3.BackColor = SystemColors.ActiveBorder;
            pnl_back4.BackColor = SystemColors.ActiveBorder;
            pnl_back5.BackColor = SystemColors.ActiveBorder;
            pnl_back6.BackColor = SystemColors.ActiveBorder;
            pnl_back7.BackColor = SystemColors.ActiveBorder;
            pnl_back8.BackColor = SystemColors.ActiveBorder;
            pnl_left1.BackColor = SystemColors.ActiveBorder;
            pnl_left2.BackColor = SystemColors.ActiveBorder;
            pnl_left3.BackColor = SystemColors.ActiveBorder;
            pnl_left4.BackColor = SystemColors.ActiveBorder;
            pnl_left5.BackColor = SystemColors.ActiveBorder;
            pnl_left6.BackColor = SystemColors.ActiveBorder;
            pnl_left7.BackColor = SystemColors.ActiveBorder;
            pnl_left8.BackColor = SystemColors.ActiveBorder;
            pnl_right1.BackColor = SystemColors.ActiveBorder;
            pnl_right2.BackColor = SystemColors.ActiveBorder;
            pnl_right3.BackColor = SystemColors.ActiveBorder;
            pnl_right4.BackColor = SystemColors.ActiveBorder;
            pnl_right5.BackColor = SystemColors.ActiveBorder;
            pnl_right6.BackColor = SystemColors.ActiveBorder;
            pnl_right7.BackColor = SystemColors.ActiveBorder;
            pnl_right8.BackColor = SystemColors.ActiveBorder;
        }

        private void lbl_about_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            about f = new about();
            f.ShowDialog();
        }

        private void lbl_help_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string chmPath = System.IO.Path.Combine(Application.StartupPath, "帮助.chm");
                System.Diagnostics.Process.Start(chmPath);
            }
            catch
            {
                MessageBox.Show("帮助文档遗失！");          
            }
        }

        private void btn_upset_Click(object sender, EventArgs e)
        {
            upset f1 = new upset();
            f1.ShowDialog();

            if (f1.backcolor[0] != Color.Black)
            {
                pnl_up1.BackColor = f1.backcolor[0];
                pnl_up2.BackColor = f1.backcolor[1];
                pnl_up3.BackColor = f1.backcolor[2];
                pnl_up4.BackColor = f1.backcolor[3];
                pnl_up5.BackColor = f1.backcolor[5];
                pnl_up6.BackColor = f1.backcolor[6];
                pnl_up7.BackColor = f1.backcolor[7];
                pnl_up8.BackColor = f1.backcolor[8];
                pnl_down1.BackColor = f1.backcolor[9];
                pnl_down2.BackColor = f1.backcolor[10];
                pnl_down3.BackColor = f1.backcolor[11];
                pnl_down4.BackColor = f1.backcolor[12];
                pnl_down5.BackColor = f1.backcolor[14];
                pnl_down6.BackColor = f1.backcolor[15];
                pnl_down7.BackColor = f1.backcolor[16];
                pnl_down8.BackColor = f1.backcolor[17];
                pnl_left1.BackColor = f1.backcolor[18];
                pnl_left2.BackColor = f1.backcolor[19];
                pnl_left3.BackColor = f1.backcolor[20];
                pnl_left4.BackColor = f1.backcolor[21];
                pnl_left5.BackColor = f1.backcolor[23];
                pnl_left6.BackColor = f1.backcolor[24];
                pnl_left7.BackColor = f1.backcolor[25];
                pnl_left8.BackColor = f1.backcolor[26];
                pnl_right1.BackColor = f1.backcolor[27];
                pnl_right2.BackColor = f1.backcolor[28];
                pnl_right3.BackColor = f1.backcolor[29];
                pnl_right4.BackColor = f1.backcolor[30];
                pnl_right5.BackColor = f1.backcolor[32];
                pnl_right6.BackColor = f1.backcolor[33];
                pnl_right7.BackColor = f1.backcolor[34];
                pnl_right8.BackColor = f1.backcolor[35];
                pnl_front1.BackColor = f1.backcolor[36];
                pnl_front2.BackColor = f1.backcolor[37];
                pnl_front3.BackColor = f1.backcolor[38];
                pnl_front4.BackColor = f1.backcolor[39];
                pnl_front5.BackColor = f1.backcolor[41];
                pnl_front6.BackColor = f1.backcolor[42];
                pnl_front7.BackColor = f1.backcolor[43];
                pnl_front8.BackColor = f1.backcolor[44];
                pnl_back1.BackColor = f1.backcolor[45];
                pnl_back2.BackColor = f1.backcolor[46];
                pnl_back3.BackColor = f1.backcolor[47];
                pnl_back4.BackColor = f1.backcolor[48];
                pnl_back5.BackColor = f1.backcolor[50];
                pnl_back6.BackColor = f1.backcolor[51];
                pnl_back7.BackColor = f1.backcolor[52];
                pnl_back8.BackColor = f1.backcolor[53];
            }
        }
    }
}
