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
    public partial class upset : Form
    {
        public upset()
        {
            InitializeComponent();
            txt_upset.Select();

            //相当于做一个标记，如果用户是直接关闭窗口，则下面代码不执行，而后打乱公式按钮就不会执行之后的改变控件背景色的代码。哥是天才。
            backcolor[0] = Color.Black;
        }

        //将字符转换成颜色显示
        public Color rechange(char c)
        {
            if (c == 'r')
                return Color.Red;
            else if (c == 'y')
                return Color.Yellow;
            else if (c == 'g')
                return Color.Green;
            else if (c == 'w')
                return Color.White;
            else if (c == 'o')
                return Color.OrangeRed;
            else
                return Color.Blue;
        }
        //存储颜色数据
        public Color[] backcolor = new Color[54];

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_upset.Clear();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            Cube mycube = new Cube();
            mycube.front[0, 0] = 'r';
            mycube.front[0, 1] = 'r';
            mycube.front[0, 2] = 'r';
            mycube.front[1, 0] = 'r';
            mycube.front[1, 1] = 'r';
            mycube.front[1, 2] = 'r';
            mycube.front[2, 0] = 'r';
            mycube.front[2, 1] = 'r';
            mycube.front[2, 2] = 'r';

            mycube.back[0, 0] = 'o';
            mycube.back[0, 1] = 'o';
            mycube.back[0, 2] = 'o';
            mycube.back[1, 0] = 'o';
            mycube.back[1, 1] = 'o';
            mycube.back[1, 2] = 'o';
            mycube.back[2, 0] = 'o';
            mycube.back[2, 1] = 'o';
            mycube.back[2, 2] = 'o';

            mycube.left[0, 0] = 'b';
            mycube.left[0, 1] = 'b';
            mycube.left[0, 2] = 'b';
            mycube.left[1, 0] = 'b';
            mycube.left[1, 1] = 'b';
            mycube.left[1, 2] = 'b';
            mycube.left[2, 0] = 'b';
            mycube.left[2, 1] = 'b';
            mycube.left[2, 2] = 'b';

            mycube.right[0, 0] = 'g';
            mycube.right[0, 1] = 'g';
            mycube.right[0, 2] = 'g';
            mycube.right[1, 0] = 'g';
            mycube.right[1, 1] = 'g';
            mycube.right[1, 2] = 'g';
            mycube.right[2, 0] = 'g';
            mycube.right[2, 1] = 'g';
            mycube.right[2, 2] = 'g';

            mycube.up[0, 0] = 'y';
            mycube.up[0, 1] = 'y';
            mycube.up[0, 2] = 'y';
            mycube.up[1, 0] = 'y';
            mycube.up[1, 1] = 'y';
            mycube.up[1, 2] = 'y';
            mycube.up[2, 0] = 'y';
            mycube.up[2, 1] = 'y';
            mycube.up[2, 2] = 'y';

            mycube.down[0, 0] = 'w';
            mycube.down[0, 1] = 'w';
            mycube.down[0, 2] = 'w';
            mycube.down[1, 0] = 'w';
            mycube.down[1, 1] = 'w';
            mycube.down[1, 2] = 'w';
            mycube.down[2, 0] = 'w';
            mycube.down[2, 1] = 'w';
            mycube.down[2, 2] = 'w';

            //按空格分隔公式，并删除多余空格
            string[] exp = txt_upset.Text.Trim().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < exp.Length; i++)
            {
                if (exp[i] == "F")
                    mycube.F(mycube, 1);
                else if (exp[i] == "F2")
                    mycube.F(mycube, 2);
                else if (exp[i] == "F'")
                    mycube.f(mycube, 1);
                else if (exp[i] == "F2'")
                    mycube.f(mycube, 2);

                else if (exp[i] == "B")
                    mycube.B(mycube, 1);
                else if (exp[i] == "B2")
                    mycube.B(mycube, 2);
                else if (exp[i] == "B'")
                    mycube.b(mycube, 1);
                else if (exp[i] == "B2'")
                    mycube.b(mycube, 2);

                else if (exp[i] == "L")
                    mycube.L(mycube, 1);
                else if (exp[i] == "L2")
                    mycube.L(mycube, 2);
                else if (exp[i] == "L'")
                    mycube.l(mycube, 1);
                else if (exp[i] == "L2'")
                    mycube.l(mycube, 2);

                else if (exp[i] == "R")
                    mycube.R(mycube, 1);
                else if (exp[i] == "R2")
                    mycube.R(mycube, 2);
                else if (exp[i] == "R'")
                    mycube.r(mycube, 1);
                else if (exp[i] == "R2'")
                    mycube.r(mycube, 2);

                else if (exp[i] == "U")
                    mycube.U(mycube, 1);
                else if (exp[i] == "U2")
                    mycube.U(mycube, 2);
                else if (exp[i] == "U'")
                    mycube.u(mycube, 1);
                else if (exp[i] == "U2'")
                    mycube.u(mycube, 2);

                else if (exp[i] == "D")
                    mycube.D(mycube, 1);
                else if (exp[i] == "D2")
                    mycube.D(mycube, 2);
                else if (exp[i] == "D'")
                    mycube.d(mycube, 1);
                else if (exp[i] == "D2'")
                    mycube.d(mycube, 2);
            }
            for (int i = 0; i < backcolor.Length; )
            {
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                        backcolor[i++] = rechange(mycube.up[j, k]);
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                        backcolor[i++] = rechange(mycube.down[j, k]);
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                        backcolor[i++] = rechange(mycube.left[j, k]);
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                        backcolor[i++] = rechange(mycube.right[j, k]);
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                        backcolor[i++] = rechange(mycube.front[j, k]);
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                        backcolor[i++] = rechange(mycube.back[j, k]);
            }
            this.Close();
        }
    }
}
