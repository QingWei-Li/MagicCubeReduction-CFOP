using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFOP魔方还原
{
    class Cube
    {
        //用六个二位数组表示魔方的六个面    
        public char[,] up = new char[3, 3];
        public char[,] down = new char[3, 3];
        public char[,] left = new char[3, 3];
        public char[,] right = new char[3, 3];
        public char[,] front = new char[3, 3];
        public char[,] back = new char[3, 3];
    
        public char[] sequence = new char[200];//储存还原步骤
        public int count = 0; //计数器
        public string[] str = new string[200];
        public string[] sign = new string[200];

        #region 旋转魔方Y,F,B,L,R,U,D,f,b,l,r,u,d
        //矩阵顺时针旋转九十度函数
        private void Rotate(char[,] surface)
        {
            char t1, t2;
            t1 = surface[0, 0];
            t2 = surface[0, 1];
            surface[0, 0] = surface[2, 0];
            surface[0, 1] = surface[1, 0];
            surface[2, 0] = surface[2, 2];
            surface[1, 0] = surface[2, 1];
            surface[2, 2] = surface[0, 2];
            surface[2, 1] = surface[1, 2];
            surface[0, 2] = t1;
            surface[1, 2] = t2;
        }
        //矩阵逆时针旋转九十度函数
        private void rotate(char[,] surface)
        {
            char t1, t2;
            t1 = surface[0, 2];
            t2 = surface[0, 1];
            surface[0, 2] = surface[2, 2];
            surface[0, 1] = surface[1, 2];
            surface[2, 2] = surface[2, 0];
            surface[1, 2] = surface[2, 1];
            surface[2, 0] = surface[0, 0];
            surface[2, 1] = surface[1, 0];
            surface[0, 0] = t1;
            surface[1, 0] = t2;
        }
        //x轴顺时针转动魔方
        public void Y(Cube cube, int n)
        {
            char[,] surface = new char[3, 3];
            surface = cube.front;
            Rotate(cube.right);
            cube.front = cube.right;
            Rotate(cube.back);
            cube.right = cube.back;
            Rotate(cube.left);
            cube.back = cube.left;
            Rotate(surface);
            cube.left = surface;
            Rotate(cube.up);
            rotate(cube.down);

            sequence[count] = 'Y';
            count++;
        }
        
        //前面一层顺时针转动
        public void F(Cube cube, int n)
        {
            char t1, t2, t3;
            for (int i = 0; i < n; i++)
            {
                t1 = cube.up[2, 0];
                t2 = cube.up[2, 1];
                t3 = cube.up[2, 2];
                cube.up[2, 0] = cube.left[2, 0];
                cube.up[2, 1] = cube.left[2, 1];
                cube.up[2, 2] = cube.left[2, 2];
                cube.left[2, 0] = cube.down[2, 0];
                cube.left[2, 1] = cube.down[2, 1];
                cube.left[2, 2] = cube.down[2, 2];
                cube.down[2, 0] = cube.right[2, 0];
                cube.down[2, 1] = cube.right[2, 1];
                cube.down[2, 2] = cube.right[2, 2];
                cube.right[2, 0] = t1;
                cube.right[2, 1] = t2;
                cube.right[2, 2] = t3;
                Rotate(cube.front);

                sequence[count] = 'F';
                count++;
            }
        }
        //后面一层顺时针转动
        public void B(Cube cube, int n)
        {
            char t1, t2, t3;
            for (int i = 0; i < n; i++)
            {
                t1 = cube.up[0, 0];
                t2 = cube.up[0, 1];
                t3 = cube.up[0, 2];
                cube.up[0, 0] = cube.right[0, 0];
                cube.up[0, 1] = cube.right[0, 1];
                cube.up[0, 2] = cube.right[0, 2];
                cube.right[0, 0] = cube.down[0, 0];
                cube.right[0, 1] = cube.down[0, 1];
                cube.right[0, 2] = cube.down[0, 2];
                cube.down[0, 0] = cube.left[0, 0];
                cube.down[0, 1] = cube.left[0, 1];
                cube.down[0, 2] = cube.left[0, 2];
                cube.left[0, 0] = t1;
                cube.left[0, 1] = t2;
                cube.left[0, 2] = t3;
                Rotate(cube.back);

                sequence[count] = 'B';
                count++;
            }
        }
        //右面一层顺时针转动
        public void R(Cube cube, int n)
        {
            char t1, t2, t3;
            for (int i = 0; i < n; i++)
            {
                t1 = cube.up[0, 2];
                t2 = cube.up[1, 2];
                t3 = cube.up[2, 2];
                cube.up[0, 2] = cube.front[0, 2];
                cube.up[1, 2] = cube.front[1, 2];
                cube.up[2, 2] = cube.front[2, 2];
                cube.front[2, 2] = cube.down[0, 0];
                cube.front[1, 2] = cube.down[1, 0];
                cube.front[0, 2] = cube.down[2, 0];
                cube.down[0, 0] = cube.back[2, 2];
                cube.down[1, 0] = cube.back[1, 2];
                cube.down[2, 0] = cube.back[0, 2];
                cube.back[0, 2] = t1;
                cube.back[1, 2] = t2;
                cube.back[2, 2] = t3;
                Rotate(cube.right);

                sequence[count] = 'R';
                count++;
            }
        }
        //左面一层顺时针转动
        public void L(Cube cube, int n)
        {
            char t1, t2, t3;
            for (int i = 0; i < n; i++)
            {
                t1 = cube.up[0, 0];
                t2 = cube.up[1, 0];
                t3 = cube.up[2, 0];
                cube.up[0, 0] = cube.back[0, 0];
                cube.up[1, 0] = cube.back[1, 0];
                cube.up[2, 0] = cube.back[2, 0];
                cube.back[0, 0] = cube.down[2, 2];
                cube.back[1, 0] = cube.down[1, 2];
                cube.back[2, 0] = cube.down[0, 2];
                cube.down[2, 2] = cube.front[0, 0];
                cube.down[1, 2] = cube.front[1, 0];
                cube.down[0, 2] = cube.front[2, 0];
                cube.front[0, 0] = t1;
                cube.front[1, 0] = t2;
                cube.front[2, 0] = t3;
                Rotate(cube.left);

                sequence[count] = 'L';
                count++;
            }
        }
        //上面一层顺时针转动
        public void U(Cube cube, int n)
        {
            char t1, t2, t3;
            for (int i = 0; i < n; i++)
            {
                t1 = cube.front[0, 0];
                t2 = cube.front[0, 1];
                t3 = cube.front[0, 2];
                cube.front[0, 2] = cube.right[0, 0];
                cube.front[0, 1] = cube.right[1, 0];
                cube.front[0, 0] = cube.right[2, 0];
                cube.right[0, 0] = cube.back[2, 0];
                cube.right[1, 0] = cube.back[2, 1];
                cube.right[2, 0] = cube.back[2, 2];
                cube.back[2, 0] = cube.left[2, 2];
                cube.back[2, 1] = cube.left[1, 2];
                cube.back[2, 2] = cube.left[0, 2];
                cube.left[0, 2] = t1;
                cube.left[1, 2] = t2;
                cube.left[2, 2] = t3;
                Rotate(cube.up);

                sequence[count] = 'U';
                count++;
            }
        }
        //下面一层顺时针转动
        public void D(Cube cube, int n)
        {
            char t1, t2, t3;
            for (int i = 0; i < n; i++)
            {
                t1 = cube.front[2, 0];
                t2 = cube.front[2, 1];
                t3 = cube.front[2, 2];
                cube.front[2, 0] = cube.left[0, 0];
                cube.front[2, 1] = cube.left[1, 0];
                cube.front[2, 2] = cube.left[2, 0];
                cube.left[0, 0] = cube.back[0, 2];
                cube.left[1, 0] = cube.back[0, 1];
                cube.left[2, 0] = cube.back[0, 0];
                cube.back[0, 0] = cube.right[0, 2];
                cube.back[0, 1] = cube.right[1, 2];
                cube.back[0, 2] = cube.right[2, 2];
                cube.right[2, 2] = t1;
                cube.right[1, 2] = t2;
                cube.right[0, 2] = t3;
                Rotate(cube.down);

                sequence[count] = 'D';
                count++;
            }
        }
        //前面一层逆时针转动
        public void f(Cube cube, int n)
        {
            char t1, t2, t3;
            for (int i = 0; i < n; i++)
            {
                t1 = cube.up[2, 0];
                t2 = cube.up[2, 1];
                t3 = cube.up[2, 2];
                cube.up[2, 0] = cube.right[2, 0];
                cube.up[2, 1] = cube.right[2, 1];
                cube.up[2, 2] = cube.right[2, 2];
                cube.right[2, 0] = cube.down[2, 0];
                cube.right[2, 1] = cube.down[2, 1];
                cube.right[2, 2] = cube.down[2, 2];
                cube.down[2, 0] = cube.left[2, 0];
                cube.down[2, 1] = cube.left[2, 1];
                cube.down[2, 2] = cube.left[2, 2];
                cube.left[2, 0] = t1;
                cube.left[2, 1] = t2;
                cube.left[2, 2] = t3;
                rotate(cube.front);

                sequence[count] = 'f';
                count++;
            }
        }
        //后面一层逆时针转动
        public void b(Cube cube, int n)
        {
            char t1, t2, t3;
            for (int i = 0; i < n; i++)
            {
                t1 = cube.up[0, 0];
                t2 = cube.up[0, 1];
                t3 = cube.up[0, 2];
                cube.up[0, 0] = cube.left[0, 0];
                cube.up[0, 1] = cube.left[0, 1];
                cube.up[0, 2] = cube.left[0, 2];
                cube.left[0, 0] = cube.down[0, 0];
                cube.left[0, 1] = cube.down[0, 1];
                cube.left[0, 2] = cube.down[0, 2];
                cube.down[0, 0] = cube.right[0, 0];
                cube.down[0, 1] = cube.right[0, 1];
                cube.down[0, 2] = cube.right[0, 2];
                cube.right[0, 0] = t1;
                cube.right[0, 1] = t2;
                cube.right[0, 2] = t3;
                rotate(cube.back);

                sequence[count] = 'b';
                count++;
            }
        }
        //右面一层逆时针转动
        public void r(Cube cube, int n)
        {
            char t1, t2, t3;
            for (int i = 0; i < n; i++)
            {
                t1 = cube.up[0, 2];
                t2 = cube.up[1, 2];
                t3 = cube.up[2, 2];
                cube.up[0, 2] = cube.back[0, 2];
                cube.up[1, 2] = cube.back[1, 2];
                cube.up[2, 2] = cube.back[2, 2];
                cube.back[2, 2] = cube.down[0, 0];
                cube.back[1, 2] = cube.down[1, 0];
                cube.back[0, 2] = cube.down[2, 0];
                cube.down[2, 0] = cube.front[0, 2];
                cube.down[1, 0] = cube.front[1, 2];
                cube.down[0, 0] = cube.front[2, 2];
                cube.front[0, 2] = t1;
                cube.front[1, 2] = t2;
                cube.front[2, 2] = t3;
                rotate(cube.right);

                sequence[count] = 'r';
                count++;
            }
        }
        //左面一层逆时针转动
        public void l(Cube cube, int n)
        {
            char t1, t2, t3;
            for (int i = 0; i < n; i++)
            {
                t1 = cube.up[0, 0];
                t2 = cube.up[1, 0];
                t3 = cube.up[2, 0];
                cube.up[0, 0] = cube.front[0, 0];
                cube.up[1, 0] = cube.front[1, 0];
                cube.up[2, 0] = cube.front[2, 0];
                cube.front[0, 0] = cube.down[2, 2];
                cube.front[1, 0] = cube.down[1, 2];
                cube.front[2, 0] = cube.down[0, 2];
                cube.down[2, 2] = cube.back[0, 0];
                cube.down[1, 2] = cube.back[1, 0];
                cube.down[0, 2] = cube.back[2, 0];
                cube.back[0, 0] = t1;
                cube.back[1, 0] = t2;
                cube.back[2, 0] = t3;
                rotate(cube.left);

                sequence[count] = 'l';
                count++;
            }
        }
        //上面一层逆时针转动
        public void u(Cube cube, int n)
        {
            char t1, t2, t3;
            for (int i = 0; i < n; i++)
            {
                t1 = cube.front[0, 0];
                t2 = cube.front[0, 1];
                t3 = cube.front[0, 2];
                cube.front[0, 0] = cube.left[0, 2];
                cube.front[0, 1] = cube.left[1, 2];
                cube.front[0, 2] = cube.left[2, 2];
                cube.left[2, 2] = cube.back[2, 0];
                cube.left[1, 2] = cube.back[2, 1];
                cube.left[0, 2] = cube.back[2, 2];
                cube.back[2, 0] = cube.right[0, 0];
                cube.back[2, 1] = cube.right[1, 0];
                cube.back[2, 2] = cube.right[2, 0];
                cube.right[2, 0] = t1;
                cube.right[1, 0] = t2;
                cube.right[0, 0] = t3;
                rotate(cube.up);

                sequence[count] = 'u';
                count++;
            }
        }
        //下面一层逆时针转动
        public void d(Cube cube, int n)
        {
            char t1, t2, t3;
            for (int i = 0; i < n; i++)
            {
                t1 = cube.front[2, 0];
                t2 = cube.front[2, 1];
                t3 = cube.front[2, 2];
                cube.front[2, 0] = cube.right[2, 2];
                cube.front[2, 1] = cube.right[1, 2];
                cube.front[2, 2] = cube.right[0, 2];
                cube.right[2, 2] = cube.back[0, 2];
                cube.right[1, 2] = cube.back[0, 1];
                cube.right[0, 2] = cube.back[0, 0];
                cube.back[0, 0] = cube.left[2, 0];
                cube.back[0, 1] = cube.left[1, 0];
                cube.back[0, 2] = cube.left[0, 0];
                cube.left[0, 0] = t1;
                cube.left[1, 0] = t2;
                cube.left[2, 0] = t3;
                rotate(cube.down);

                sequence[count] = 'd';
                count++;
            }
        }
        #endregion
        //常用公式整理的函数
        //1.处理底块在第二层侧棱的八种情况
        private void exp1(Cube cube)
        {
            while ((cube.front[1, 0] == cube.down[1, 1]) || (cube.front[1, 2] == cube.down[1, 1]) || (cube.right[0, 1] == cube.down[1, 1]) || (cube.right[2, 1] == cube.down[1, 1]) || (cube.back[1, 0] == cube.down[1, 1]) || (cube.back[1, 2] == cube.down[1, 1]) || (cube.left[0, 1] == cube.down[1, 1]) || (cube.left[2, 1] == cube.down[1, 1]))
            {
                if (cube.front[1, 0] == cube.down[1, 1])
                {
                    while (cube.up[1, 0] == cube.down[1, 1])
                        cube.U(cube, 1);
                    cube.l(cube, 1);
                }
                else if (cube.front[1, 2] == cube.down[1, 1])
                {
                    while (cube.up[1, 2] == cube.down[1, 1])
                        cube.U(cube, 1);
                    cube.R(cube, 1);
                }
                else if (cube.right[2, 1] == cube.down[1, 1])
                {
                    while (cube.up[2, 1] == cube.down[1, 1])
                        cube.U(cube, 1);
                    cube.f(cube, 1);
                }
                else if (cube.right[0, 1] == cube.down[1, 1])
                {
                    while (cube.up[0, 1] == cube.down[1, 1])
                        cube.U(cube, 1);
                    cube.B(cube, 1);
                }
                else if (cube.back[1, 0] == cube.down[1, 1])
                {
                    while (cube.up[1, 0] == cube.down[1, 1])
                        cube.U(cube, 1);
                    cube.L(cube, 1);
                }
                else if (cube.back[1, 2] == cube.down[1, 1])
                {
                    while (cube.up[1, 2] == cube.down[1, 1])
                        cube.U(cube, 1);
                    cube.r(cube, 1);
                }
                else if (cube.left[0, 1] == cube.down[1, 1])
                {
                    while (cube.up[0, 1] == cube.down[1, 1])
                        cube.U(cube, 1);
                    cube.b(cube, 1);
                }
                else
                {
                    while (cube.up[2, 1] == cube.down[1, 1])
                        cube.U(cube, 1);
                    cube.F(cube, 1);
                }
            }
        }
        //2.删减重复的还原步骤
        public void cut(Cube cube)
        {
            int t = 1, k = 0, flag = 0;

            for (int i = 0; cube.sequence[i] != '\0'; i++)
            {
                if (cube.sequence[i] > 'Z')
                    flag--;
                else
                    flag++;

                if (cube.sequence[i] == cube.sequence[i + 1] + 32 || cube.sequence[i] == cube.sequence[i + 1] - 32 || cube.sequence[i] == cube.sequence[i + 1])
                {
                    if (cube.sequence[i] == cube.sequence[i + 1])
                        t++;
                    else
                        t--; 
                }
                else
                {
                    if (t == 0 || t == 4)
                    {
                        t = 1;
                        continue;
                    }
                    else if (t % 3 == 0)
                    {
                        if (cube.sequence[i] > 'Z')
                        {
                            str[k] = tran(cube.sequence[i]).Replace('逆', '顺') + (t - 2) * 90 + "度";
                            sign[k] = cube.sequence[i].ToString().ToUpper();
                        }
                        else
                        {
                            str[k] = tran(cube.sequence[i]).Replace('顺', '逆') + (t - 2) * 90 + "度";
                            sign[k] = cube.sequence[i].ToString().ToUpper() + "'";
                        }
                    }
                    else
                    {
                        str[k] = tran(cube.sequence[i]) + t * 90 + "度";
                        if (flag < 0)
                            if (t == 1)
                                sign[k] = cube.sequence[i].ToString().ToUpper() + "'";
                            else
                                sign[k] = cube.sequence[i].ToString().ToUpper() + t.ToString() + "'";

                        else
                            if (t == 1)
                                sign[k] = cube.sequence[i].ToString().ToUpper();
                            else
                                sign[k] = cube.sequence[i].ToString().ToUpper() + t.ToString();
                    }
                    t = 1;
                    k++;
                    flag = 0;
                }
            }
        }
        //3.翻译
        public string tran(char c)
        {
            if (c == 'R')
                return "顺时针转动 右层 ";
            else if (c == 'r')
                return "逆时针转动 右层 ";
            else if (c == 'L')
                return "顺时针转动 左层 ";
            else if (c == 'l')
                return "逆时针转动 左层 ";
            else if (c == 'B')
                return "顺时针转动 后层 ";
            else if (c == 'b')
                return "逆时针转动 后层 ";
            else if (c == 'F')
                return "顺时针转动 前层 ";
            else if (c == 'f')
                return "逆时针转动 前层 ";
            else if (c == 'U')
                return "顺时针转动 上层 ";
            else if (c == 'u')
                return "逆时针转动 上层 ";
            else if (c == 'D')
                return "顺时针转动 下层 ";
            else if (c == 'd')
                return "逆时针转动 下层 ";
            else
                return "顺时针转动 魔方 ";
        }

        //魔方公式CFOP
        //Cross底面十字(以white为底)
        public void Cross(Cube cube)
        {
            //第一步做成顶部花心形
            while (!(cube.front[1, 1] == cube.front[2, 1] && cube.back[1, 1] == cube.back[0, 1] && cube.left[1, 1] == cube.left[1, 0] && cube.right[1, 1] == cube.right[1, 2] && cube.down[1, 0] == cube.down[1, 1] && cube.down[1, 2] == cube.down[1, 1] && cube.down[0, 1] == cube.down[1, 1] && cube.down[2, 1] == cube.down[1, 1])) 
            {
                //处理底块在第一层侧棱的四种情况
                while ((cube.front[0, 1] == cube.down[1, 1]) || cube.right[1, 0] == cube.down[1, 1] || (cube.back[2, 1] == cube.down[1, 1]) || (cube.left[1, 2] == cube.down[1, 1]))
                {
                    if (cube.front[0, 1] == cube.down[1, 1])
                    {
                        cube.F(cube, 1);
                        cube.exp1(cube);
                    }
                    else if (cube.right[1, 0] == cube.down[1, 1])
                    {
                        cube.R(cube, 1);
                        cube.exp1(cube);
                    }
                    else if (cube.back[2, 1] == cube.down[1, 1])
                    {
                        cube.B(cube, 1);
                        cube.exp1(cube);
                    }
                    else
                    {
                        cube.L(cube, 1);
                        cube.exp1(cube);
                    }
                }
                //处理底块在第二层侧棱的八种情况
                cube.exp1(cube);

                //处理底块在第三层侧棱的四种情况
                while ((cube.front[2, 1] == cube.down[1, 1]) || (cube.right[1, 2] == cube.down[1, 1]) || (cube.back[0, 1] == cube.down[1, 1]) || (cube.left[1, 0] == cube.down[1, 1]))
                {
                    if (cube.front[2, 1] == cube.down[1, 1])
                    {
                        while (cube.up[2, 1] == cube.down[1, 1])
                            cube.U(cube, 1);
                        cube.F(cube, 1);
                        cube.exp1(cube);
                    }
                    else if (cube.right[1, 2] == cube.down[1, 1])
                    {
                        while (cube.up[1, 2] == cube.down[1, 1])
                            cube.U(cube, 1);
                        cube.R(cube, 1);
                        cube.exp1(cube);
                    }
                    else if (cube.back[0, 1] == cube.down[1, 1])
                    {
                        while (cube.up[0, 1] == cube.down[1, 1])
                            cube.U(cube, 1);
                        cube.B(cube, 1);
                        cube.exp1(cube);
                    }
                    else
                    {
                        while (cube.up[1, 0] == cube.down[1, 1])
                            cube.U(cube, 1);
                        cube.L(cube, 1);
                        cube.exp1(cube);
                    }
                }
                //处理底块在第三层底部但位置不对的四种情况
                while ((cube.down[2, 1] == cube.down[1, 1] && cube.front[2, 1] != cube.front[1, 1]) || (cube.down[1, 2] == cube.down[1, 1] && cube.left[1, 0] != cube.left[1, 1]) || (cube.down[0, 1] == cube.down[1, 1] && cube.back[0, 1] != cube.back[1, 1]) || (cube.down[1, 0] == cube.down[1, 1] && cube.right[1, 2] != cube.right[1, 1]))
                {
                    if (cube.down[2, 1] == cube.down[1, 1] && cube.front[2, 1] != cube.front[1, 1])
                    {
                        while (cube.up[2, 1] == cube.down[1, 1])
                            cube.U(cube, 1);
                        cube.F(cube, 1);
                        cube.exp1(cube);
                    }
                    if (cube.down[1, 2] == cube.down[1, 1] && cube.left[1, 0] != cube.left[1, 1])
                    {
                        while (cube.up[1, 0] == cube.down[1, 1])
                            cube.U(cube, 1);
                        cube.L(cube, 1);
                        cube.exp1(cube);
                    }
                    if (cube.down[0, 1] == cube.down[1, 1] && cube.back[0, 1] != cube.back[1, 1])
                    {
                        while (cube.up[0, 1] == cube.down[1, 1])
                            cube.U(cube, 1);
                        cube.B(cube, 1);
                        cube.exp1(cube);
                    }
                    if (cube.down[1, 0] == cube.down[1, 1] && cube.right[1, 2] != cube.right[1, 1])
                    {
                        while (cube.up[1, 2] == cube.down[1, 1])
                            cube.U(cube, 1);
                        cube.R(cube, 1);
                        cube.exp1(cube);
                    }
                }
                //处理中心棱块和十字花的位置
                while (true)
                {
                    if (cube.front[0, 1] == cube.front[1, 1] && cube.up[2, 1] == cube.down[1, 1])
                        cube.F(cube, 2);
                    else if (cube.left[1, 2] == cube.left[1, 1] && cube.up[1, 0] == cube.down[1, 1])
                        cube.L(cube, 2);
                    else if (cube.right[1, 0] == cube.right[1, 1] && cube.up[1, 2] == cube.down[1, 1])
                        cube.R(cube, 2);
                    else if (cube.back[2, 1] == cube.back[1, 1] && cube.up[0, 1] == cube.down[1, 1])
                        cube.B(cube, 2);
                    else if (((cube.front[1, 1] == cube.front[2, 1]) && (cube.back[1, 1] == cube.back[0, 1]) && (cube.left[1, 1] == cube.left[1, 0]) && (cube.right[1, 1] == cube.right[1, 2])) && (cube.down[0, 1] == cube.down[1, 1]) && (cube.down[1, 0] == cube.down[1, 1]) && (cube.down[1, 2] == cube.down[1, 1]) && (cube.down[2, 1] == cube.down[1, 1]))
                        break;
                    else
                        cube.U(cube, 1);
                }
            }
        }
        //F2L底层和中层两层还原
        public void F2L(Cube cube)
        {
            //底层
            while (!(cube.down[0, 0] == cube.down[1, 1] && cube.down[2, 0] == cube.down[1, 1] && cube.down[0, 2] == cube.down[1, 1] && cube.down[2, 2] == cube.down[1, 1] && cube.front[2, 0] == cube.front[1, 1] && cube.right[2, 2] == cube.right[1, 1] && cube.back[0, 2] == cube.back[1, 1] && cube.left[2, 0] == cube.left[1, 1]))
            {
                //底块在上层四角
                //底面向上
                if (cube.up[0, 0] == cube.down[1, 1] || cube.up[0, 2] == cube.down[1, 1] || cube.up[2, 0] == cube.down[1, 1] || cube.up[2, 2] == cube.down[1, 1])
                {
                    if (cube.up[2, 2] == cube.down[1, 1] && cube.front[0, 2] == cube.right[1, 1] && cube.right[2, 0] == cube.front[1, 1])
                    {
                        cube.R(cube, 1);
                        cube.u(cube, 1);
                        cube.r(cube, 1);
                        cube.f(cube, 1);
                        cube.U(cube, 2);
                        cube.F(cube, 1);
                    }
                    else if (cube.up[2, 0] == cube.down[1, 1] && cube.front[0, 0] == cube.left[1, 1] && cube.left[2, 2] == cube.front[1, 1])
                    {
                        cube.l(cube, 1);
                        cube.U(cube, 1);
                        cube.L(cube, 1);
                        cube.F(cube, 1);
                        cube.U(cube, 2);
                        cube.f(cube, 1);
                    }
                    else if (cube.up[0, 2] == cube.down[1, 1] && cube.right[0, 0] == cube.back[1, 1] && cube.back[2, 2] == cube.right[1, 1])
                    {
                        cube.B(cube, 1);
                        cube.u(cube, 1);
                        cube.b(cube, 1);
                        cube.r(cube, 1);
                        cube.U(cube, 2);
                        cube.R(cube, 1);
                    }
                    else if (cube.up[0, 0] == cube.down[1, 1] && cube.left[0, 2] == cube.back[1, 1] && cube.back[2, 0] == cube.left[1, 1])
                    {
                        cube.b(cube, 1);
                        cube.U(cube, 1);
                        cube.B(cube, 1);
                        cube.L(cube, 1);
                        cube.U(cube, 2);
                        cube.l(cube, 1);
                    }
                    else
                        cube.U(cube, 1);
                }
                //底面在侧
                else if (cube.front[0, 0] == cube.down[1, 1] || cube.front[0, 2] == cube.down[1, 1] || cube.back[2, 0] == cube.down[1, 1] || cube.back[2, 2] == cube.down[1, 1] || cube.left[0, 2] == cube.down[1, 1] || cube.left[2, 2] == cube.down[1, 1] || cube.right[0, 0] == cube.down[1, 1] || cube.right[2, 0] == cube.down[1, 1])
                {
                    if (cube.front[0, 0] == cube.down[1, 1] && cube.up[2, 0] == cube.front[1, 1] && cube.left[2, 2] == cube.left[1, 1])
                    {
                        cube.F(cube, 1);
                        cube.U(cube, 1);
                        cube.f(cube, 1);
                    }
                    else if (cube.front[0, 2] == cube.down[1, 1] && cube.up[2, 2] == cube.front[1, 1] && cube.right[2, 0] == cube.right[1, 1])
                    {
                        cube.f(cube, 1);
                        cube.u(cube, 1);
                        cube.F(cube, 1);
                    }
                    else if (cube.back[2, 0] == cube.down[1, 1] && cube.up[0, 0] == cube.back[1, 1] && cube.left[0, 2] == cube.left[1, 1])
                    {
                        cube.b(cube, 1);
                        cube.u(cube, 1);
                        cube.B(cube, 1);
                    }
                    else if (cube.back[2, 2] == cube.down[1, 1] && cube.up[0, 2] == cube.back[1, 1] && cube.right[0, 0] == cube.right[1, 1])
                    {
                        cube.B(cube, 1);
                        cube.U(cube, 1);
                        cube.b(cube, 1);
                    }
                    else if (cube.left[0, 2] == cube.down[1, 1] && cube.up[0, 0] == cube.left[1, 1] && cube.back[2, 0] == cube.back[1, 1])
                    {
                        cube.L(cube, 1);
                        cube.U(cube, 1);
                        cube.l(cube, 1);
                    }
                    else if (cube.left[2, 2] == cube.down[1, 1] && cube.up[2, 0] == cube.left[1, 1] && cube.front[0, 0] == cube.front[1, 1])
                    {
                        cube.l(cube, 1);
                        cube.u(cube, 1);
                        cube.L(cube, 1);
                    }
                    else if (cube.right[0, 0] == cube.down[1, 1] && cube.up[0, 2] == cube.right[1, 1] && cube.back[2, 2] == cube.back[1, 1])
                    {
                        cube.r(cube, 1);
                        cube.u(cube, 1);
                        cube.R(cube, 1);
                    }
                    else if (cube.right[2, 0] == cube.down[1, 1] && cube.up[2, 2] == cube.right[1, 1] && cube.front[0, 2] == cube.front[1, 1])
                    {
                        cube.R(cube, 1);
                        cube.U(cube, 1);
                        cube.r(cube, 1);
                    }
                    else
                        cube.U(cube, 1);
                }
                //底块在底层但是位置不对
                else
                {
                    if (cube.front[2, 2] == cube.down[1, 1] || cube.right[2, 2] == cube.down[1, 1] || (cube.down[2, 0] == cube.down[1, 1] && (cube.front[2, 2] != cube.front[1, 1] || cube.right[2, 2] != cube.right[1, 1])))
                    {
                        cube.R(cube, 1);
                        cube.U(cube, 1);
                        cube.r(cube, 1);
                    }
                    else if (cube.front[2, 0] == cube.down[1, 1] || cube.left[2, 0] == cube.down[1, 1] || (cube.down[2, 2] == cube.down[1, 1] && (cube.front[2, 0] != cube.front[1, 1] || cube.left[2, 0] != cube.left[1, 1])))
                    {
                        cube.l(cube, 1);
                        cube.u(cube, 1);
                        cube.L(cube, 1);
                    }
                    else if (cube.left[0, 0] == cube.down[1, 1] || cube.back[0, 0] == cube.down[1, 1] || (cube.down[0, 2] == cube.down[1, 1] && (cube.left[0, 0] != cube.left[1, 1] || cube.back[0, 0] != cube.back[1, 1])))
                    {
                        cube.b(cube, 1);
                        cube.u(cube, 1);
                        cube.B(cube, 1);
                    }
                    else
                    {
                        cube.B(cube, 1);
                        cube.U(cube, 1);
                        cube.b(cube, 1);
                    }
                }
            }
            //中层
            while (!(cube.front[1, 2] == cube.front[1, 1] && cube.right[2, 1] == cube.right[1, 1] && cube.right[0, 1] == cube.right[1, 1] && cube.back[1, 0] == cube.back[1, 1] && cube.back[1, 2] == cube.back[1, 1] && cube.left[0, 1] == cube.left[1, 1] && cube.left[2, 1] == cube.left[1, 1] && cube.front[1, 0] == cube.front[1, 1]))
            {
                //在上层的情况
                if ((cube.up[0, 1] != cube.up[1, 1] && cube.back[2, 1] != cube.up[1, 1]) || (cube.up[1, 0] != cube.up[1, 1] && cube.left[1, 2] != cube.up[1, 1]) || (cube.up[2, 1] != cube.up[1, 1] && cube.front[0, 1] != cube.up[1, 1]) || (cube.up[1, 2] != cube.up[1, 1] && cube.right[1, 0] != cube.up[1, 1]))
                {
                    if (cube.up[0, 1] != cube.up[1, 1] && cube.back[2, 1] == cube.back[1, 1])
                    {
                        if (cube.up[0, 1] == cube.left[1, 1])
                        {
                            cube.U(cube, 1);
                            cube.L(cube, 1);
                            cube.u(cube, 1);
                            cube.l(cube, 1);
                            cube.u(cube, 1);
                            cube.b(cube, 1);
                            cube.U(cube, 1);
                            cube.B(cube, 1);
                        }
                        else
                        {
                            cube.u(cube, 1);
                            cube.r(cube, 1);
                            cube.U(cube, 1);
                            cube.R(cube, 1);
                            cube.U(cube, 1);
                            cube.B(cube, 1);
                            cube.u(cube, 1);
                            cube.b(cube, 1);
                        }
                    }
                    else if (cube.up[1, 0] != cube.up[1, 1] && cube.left[1, 2] == cube.left[1, 1])
                    {
                        if (cube.up[1, 0] == cube.back[1, 1])
                        {
                            cube.u(cube, 1);
                            cube.b(cube, 1);
                            cube.U(cube, 1);
                            cube.B(cube, 1);
                            cube.U(cube, 1);
                            cube.L(cube, 1);
                            cube.u(cube, 1);
                            cube.l(cube, 1);
                        }
                        else
                        {
                            cube.U(cube, 1);
                            cube.F(cube, 1);
                            cube.u(cube, 1);
                            cube.f(cube, 1);
                            cube.u(cube, 1);
                            cube.l(cube, 1);
                            cube.U(cube, 1);
                            cube.L(cube, 1);
                        }
                    }
                    else if (cube.up[2, 1] != cube.up[1, 1] && cube.front[0, 1] == cube.front[1, 1])
                    {
                        if (cube.up[2, 1] == cube.right[1, 1])
                        {
                            cube.U(cube, 1);
                            cube.R(cube, 1);
                            cube.u(cube, 1);
                            cube.r(cube, 1);
                            cube.u(cube, 1);
                            cube.f(cube, 1);
                            cube.U(cube, 1);
                            cube.F(cube, 1);
                        }
                        else
                        {
                            cube.u(cube, 1);
                            cube.l(cube, 1);
                            cube.U(cube, 1);
                            cube.L(cube, 1);
                            cube.U(cube, 1);
                            cube.F(cube, 1);
                            cube.u(cube, 1);
                            cube.f(cube, 1);
                        }
                    }
                    else if (cube.up[1, 2] != cube.up[1, 1] && cube.right[1, 0] == cube.right[1, 1])
                    {
                        if (cube.up[1, 2] == cube.front[1, 1])
                        {
                            cube.u(cube, 1);
                            cube.f(cube, 1);
                            cube.U(cube, 1);
                            cube.F(cube, 1);
                            cube.U(cube, 1);
                            cube.R(cube, 1);
                            cube.u(cube, 1);
                            cube.r(cube, 1);
                        }
                        else
                        {
                            cube.U(cube, 1);
                            cube.B(cube, 1);
                            cube.u(cube, 1);
                            cube.b(cube, 1);
                            cube.u(cube, 1);
                            cube.r(cube, 1);
                            cube.U(cube, 1);
                            cube.R(cube, 1);
                        }
                    }
                    else
                        cube.U(cube, 1);
                }
                //在中层的情况
                else
                {
                    if (cube.front[1, 2] != cube.front[1, 1])
                    {
                        cube.R(cube, 1);
                        cube.u(cube, 1);
                        cube.r(cube, 1);
                        cube.u(cube, 1);
                        cube.f(cube, 1);
                        cube.U(cube, 1);
                        cube.F(cube, 1);
                    }
                    else if (cube.right[0, 1] != cube.right[1, 1])
                    {
                        cube.B(cube, 1);
                        cube.u(cube, 1);
                        cube.b(cube, 1);
                        cube.u(cube, 1);
                        cube.r(cube, 1);
                        cube.U(cube, 1);
                        cube.R(cube, 1);
                    }
                    else if (cube.back[1, 0] != cube.back[1, 1])
                    {
                        cube.L(cube, 1);
                        cube.u(cube, 1);
                        cube.l(cube, 1);
                        cube.u(cube, 1);
                        cube.b(cube, 1);
                        cube.U(cube, 1);
                        cube.B(cube, 1);
                    }
                    else
                    {
                        cube.F(cube, 1);
                        cube.u(cube, 1);
                        cube.f(cube, 1);
                        cube.u(cube, 1);
                        cube.l(cube, 1);
                        cube.U(cube, 1);
                        cube.L(cube, 1);
                    }
                }
            }
        }
        //OLL顶部朝向调整(57种情况)
        public void OLL(Cube cube)
        {
            while (!(cube.up[0, 0] == cube.up[1, 1] && cube.up[0, 1] == cube.up[1, 1] && cube.up[0, 2] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1] && cube.up[2, 0] == cube.up[1, 1] && cube.up[2, 1] == cube.up[1, 1] && cube.up[2, 2] == cube.up[1, 1]))
            {
                //OLL1
                if (cube.back[2, 1] == cube.up[1, 1] && cube.right[0, 0] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.right[2, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.left[0, 2] == cube.up[1, 1] && cube.left[1, 2] == cube.up[1, 1] && cube.left[2, 2] == cube.up[1, 1])
                {
                    cube.R(cube, 1);
                    cube.U(cube, 2);
                    cube.r(cube, 2);
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.f(cube, 1);
                    cube.U(cube, 2);
                    cube.r(cube, 1);
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.f(cube, 1);
                }
                //OLL2    
                else if (cube.back[2, 1] == cube.up[1, 1] && cube.back[2, 2] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.front[0, 2] == cube.up[1, 1] && cube.left[0, 2] == cube.up[1, 1] && cube.left[1, 2] == cube.up[1, 1] && cube.left[2, 2] == cube.up[1, 1])
                {
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.f(cube, 1);
                    cube.B(cube, 1);
                    cube.U(cube, 1);
                    cube.L(cube, 1);
                    cube.u(cube, 1);
                    cube.l(cube, 1);
                    cube.b(cube, 1);
                }
                //OLL3
                else if (cube.back[2, 0] == cube.up[1, 1] && cube.back[2, 1] == cube.up[1, 1] && cube.right[0, 0] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.left[2, 2] == cube.up[1, 1] && cube.left[1, 2] == cube.up[1, 1] && cube.up[2, 2] == cube.up[1, 1])
                {
                    cube.B(cube, 1);
                    cube.U(cube, 1);
                    cube.L(cube, 1);
                    cube.u(cube, 1);
                    cube.l(cube, 1);
                    cube.b(cube, 1);
                    cube.u(cube, 1);
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.f(cube, 1);
                }
                //OLL4
                else if (cube.back[2, 1] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.right[2, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.front[0, 0] == cube.up[1, 1] && cube.left[0, 2] == cube.up[1, 1] && cube.left[1, 2] == cube.up[1, 1] && cube.up[0, 2] == cube.up[1, 1])
                {
                    cube.B(cube, 1);
                    cube.U(cube, 1);
                    cube.L(cube, 1);
                    cube.u(cube, 1);
                    cube.l(cube, 1);
                    cube.b(cube, 1);
                    cube.R(cube, 1);
                    cube.B(cube, 1);
                    cube.U(cube, 1);
                    cube.b(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                }
                //OLL5
                else if (cube.back[2, 1] == cube.up[1, 1] && cube.right[0, 0] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.front[0, 0] == cube.up[1, 1] && cube.left[1, 2] == cube.up[1, 1] && cube.up[0, 0] == cube.up[1, 1] && cube.up[2, 2] == cube.up[1, 1])
                {
                    cube.F(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.f(cube, 1);
                    cube.U(cube, 1);
                    cube.F(cube, 1);
                    cube.R(cube, 2);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.f(cube, 1);
                }
                //OLL6
                else if (cube.back[2, 0] == cube.up[1, 1] && cube.back[2, 1] == cube.up[1, 1] && cube.back[2, 2] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.left[1, 2] == cube.up[1, 1] && cube.up[2, 0] == cube.up[1, 1] && cube.up[2, 2] == cube.up[1, 1])
                {
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.U(cube, 1);
                    cube.f(cube, 1);
                    cube.U(cube, 2);
                    cube.f(cube, 1);
                    cube.L(cube, 1);
                    cube.F(cube, 1);
                    cube.l(cube, 1);
                }
                //OLL7
                else if (cube.back[2, 1] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.right[2, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.left[2, 2] == cube.up[1, 1] && cube.left[1, 2] == cube.up[1, 1] && cube.up[0, 0] == cube.up[1, 1] && cube.up[0, 2] == cube.up[1, 1])
                {
                    cube.l(cube, 1);
                    cube.R(cube, 1);
                    cube.B(cube, 1);
                    cube.R(cube, 1);
                    cube.B(cube, 1);
                    cube.r(cube, 1);
                    cube.b(cube, 1);
                    cube.L(cube, 1);
                    cube.r(cube, 2);
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.f(cube, 1);
                }
                //OLL8
                else if (cube.back[2, 1] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.left[1, 2] == cube.up[1, 1] && cube.up[0, 0] == cube.up[1, 1] && cube.up[0, 2] == cube.up[1, 1] && cube.up[2, 0] == cube.up[1, 1] && cube.up[2, 2] == cube.up[1, 1])
                {
                    cube.l(cube, 1);
                    cube.R(cube, 1);
                    cube.B(cube, 1);
                    cube.R(cube, 1);
                    cube.B(cube, 1);
                    cube.r(cube, 1);
                    cube.b(cube, 1);
                    cube.L(cube, 2);
                    cube.r(cube, 2);
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.f(cube, 1);
                    cube.l(cube, 1);
                }
                //OLL9
                else if (cube.back[2, 1] == cube.up[1, 1] && cube.right[0, 0] == cube.up[1, 1] && cube.right[2, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.left[0, 2] == cube.up[1, 1] && cube.left[2, 2] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1])
                {
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.f(cube, 1);
                    cube.L(cube, 1);
                    cube.F(cube, 1);
                    cube.r(cube, 1);
                    cube.f(cube, 1);
                    cube.l(cube, 1);
                }
                //OLL10
                else if (cube.right[0, 0] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.right[2, 0] == cube.up[1, 1] && cube.left[0, 2] == cube.up[1, 1] && cube.left[1, 2] == cube.up[1, 1] && cube.left[2, 2] == cube.up[1, 1] && cube.up[0, 1] == cube.up[1, 1] && cube.up[2, 1] == cube.up[1, 1])
                {
                    cube.R(cube, 1);
                    cube.U(cube, 2);
                    cube.r(cube, 2);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.U(cube, 2);
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.f(cube, 1);
                }
                //OLL11
                else if (cube.back[2, 0] == cube.up[1, 1] && cube.back[2, 1] == cube.up[1, 1] && cube.right[0, 0] == cube.up[1, 1] && cube.right[2, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.front[0, 0] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1])
                {
                    cube.F(cube, 1);
                    cube.U(cube, 1);
                    cube.R(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.U(cube, 1);
                    cube.R(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.f(cube, 1);
                }
                //OLL12
                else if (cube.back[2, 0] == cube.up[1, 1] && cube.right[0, 0] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.right[2, 0] == cube.up[1, 1] && cube.front[0, 0] == cube.up[1, 1] && cube.left[1, 2] == cube.up[1, 1] && cube.up[0, 1] == cube.up[1, 1] && cube.up[2, 1] == cube.up[1, 1])
                {
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.U(cube, 1);
                    cube.f(cube, 1);
                    cube.U(cube, 1);
                    cube.F(cube, 1);
                    cube.B(cube, 1);
                }
                //OLL13
                else if (cube.back[2, 0] == cube.up[1, 1] && cube.back[2, 2] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.front[0, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.front[0, 2] == cube.up[1, 1] && cube.up[0, 1] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1])
                {
                    cube.L(cube, 1);
                    cube.F(cube, 2);
                    cube.r(cube, 1);
                    cube.f(cube, 1);
                    cube.R(cube, 1);
                    cube.F(cube, 1);
                    cube.r(cube, 1);
                    cube.f(cube, 1);
                    cube.R(cube, 1);
                    cube.f(cube, 1);
                    cube.l(cube, 1);
                }
                //OLL14
                else if (cube.back[2, 0] == cube.up[1, 1] && cube.back[2, 1] == cube.up[1, 1] && cube.back[2, 2] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.front[0, 0] == cube.up[1, 1] && cube.front[0, 2] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[2, 1] == cube.up[1, 1])
                {
                    cube.l(cube, 1);
                    cube.B(cube, 2);
                    cube.R(cube, 1);
                    cube.B(cube, 1);
                    cube.r(cube, 1);
                    cube.b(cube, 1);
                    cube.R(cube, 1);
                    cube.B(cube, 1);
                    cube.r(cube, 1);
                    cube.B(cube, 1);
                    cube.L(cube, 1);
                }
                //OLL15
                else if (cube.back[2, 0] == cube.up[1, 1] && cube.back[2, 1] == cube.up[1, 1] && cube.right[0, 0] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.right[2, 0] == cube.up[1, 1] && cube.front[0, 0] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[2, 1] == cube.up[1, 1])
                {
                    cube.R(cube, 1);
                    cube.b(cube, 1);
                    cube.R(cube, 2);
                    cube.F(cube, 1);
                    cube.R(cube, 2);
                    cube.B(cube, 1);
                    cube.R(cube, 2);
                    cube.f(cube, 1);
                    cube.R(cube, 1);
                }
                //OLL16
                else if (cube.back[2, 0] == cube.up[1, 1] && cube.right[0, 0] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.right[2, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.front[0, 0] == cube.up[1, 1] && cube.up[0, 1] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1])
                {
                    cube.r(cube, 1);
                    cube.F(cube, 1);
                    cube.R(cube, 2);
                    cube.b(cube, 1);
                    cube.R(cube, 2);
                    cube.f(cube, 1);
                    cube.R(cube, 2);
                    cube.B(cube, 1);
                    cube.r(cube, 1);
                }
                //OLL17
                else if (cube.back[2, 2] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.front[0, 2] == cube.up[1, 1] && cube.left[0, 2] == cube.up[1, 1] && cube.left[2, 2] == cube.up[1, 1] && cube.up[0, 1] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1])
                {
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.f(cube, 1);
                }
                //OLL18
                else if (cube.back[2, 1] == cube.up[1, 1] && cube.back[2, 2] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.front[0, 2] == cube.up[1, 1] && cube.left[0, 2] == cube.up[1, 1] && cube.left[2, 2] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[2, 1] == cube.up[1, 1])
                {
                    cube.b(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.B(cube, 1);
                }
                //OLL19
                else if (cube.back[2, 0] == cube.up[1, 1] && cube.right[0, 0] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.front[0, 2] == cube.up[1, 1] && cube.up[0, 1] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[2, 0] == cube.up[1, 1])
                {
                    cube.L(cube, 1);
                    cube.F(cube, 1);
                    cube.r(cube, 1);
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.F(cube, 2);
                    cube.l(cube, 1);
                }
                //OLL20
                else if (cube.back[2, 1] == cube.up[1, 1] && cube.back[2, 2] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.right[2, 0] == cube.up[1, 1] && cube.front[0, 0] == cube.up[1, 1] && cube.up[0, 0] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[2, 1] == cube.up[1, 1])
                {
                    cube.l(cube, 1);
                    cube.b(cube, 1);
                    cube.R(cube, 1);
                    cube.b(cube, 1);
                    cube.r(cube, 1);
                    cube.B(cube, 2);
                    cube.L(cube, 1);
                }
                //OLL21
                else if (cube.back[2, 2] == cube.up[1, 1] && cube.right[2, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.front[0, 0] == cube.up[1, 1] && cube.left[1, 2] == cube.up[1, 1] && cube.up[0, 0] == cube.up[1, 1] && cube.up[0, 1] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1])
                {
                    cube.L(cube, 1);
                    cube.R(cube, 2);
                    cube.f(cube, 1);
                    cube.R(cube, 1);
                    cube.f(cube, 1);
                    cube.r(cube, 1);
                    cube.F(cube, 2);
                    cube.R(cube, 1);
                    cube.f(cube, 1);
                    cube.R(cube, 1);
                    cube.l(cube, 1);
                }
                //OLL22
                else if (cube.back[2, 0] == cube.up[1, 1] && cube.back[2, 1] == cube.up[1, 1] && cube.right[0, 0] == cube.up[1, 1] && cube.front[0, 2] == cube.up[1, 1] && cube.left[1, 2] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1] && cube.up[2, 0] == cube.up[1, 1] && cube.up[2, 1] == cube.up[1, 1])
                {
                    cube.l(cube, 1);
                    cube.R(cube, 2);
                    cube.B(cube, 1);
                    cube.r(cube, 1);
                    cube.B(cube, 1);
                    cube.R(cube, 1);
                    cube.B(cube, 2);
                    cube.r(cube, 1);
                    cube.B(cube, 1);
                    cube.L(cube, 1);
                    cube.r(cube, 1);
                }
                //OLL23
                else if (cube.back[2, 2] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.front[0, 0] == cube.up[1, 1] && cube.left[0, 2] == cube.up[1, 1] && cube.up[0, 1] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[2, 2] == cube.up[1, 1])
                {
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.F(cube, 1);
                    cube.r(cube, 1);
                    cube.f(cube, 1);
                    cube.U(cube, 1);
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.f(cube, 1);
                }
                //OLL24
                else if (cube.back[2, 0] == cube.up[1, 1] && cube.back[2, 1] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.front[0, 2] == cube.up[1, 1] && cube.left[2, 2] == cube.up[1, 1] && cube.up[0, 2] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[2, 1] == cube.up[1, 1])
                {
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.f(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 2);
                    cube.r(cube, 1);
                }
                //OLL25
                else if (cube.back[2, 0] == cube.up[1, 1] && cube.back[2, 1] == cube.up[1, 1] && cube.right[0, 0] == cube.up[1, 1] && cube.left[2, 2] == cube.up[1, 1] && cube.left[1, 2] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1] && cube.up[2, 1] == cube.up[1, 1] && cube.up[2, 2] == cube.up[1, 1])
                {
                    cube.l(cube, 1);
                    cube.B(cube, 2);
                    cube.R(cube, 1);
                    cube.B(cube, 1);
                    cube.r(cube, 1);
                    cube.B(cube, 1);
                    cube.L(cube, 1);
                }
                //OLL26
                else if (cube.right[2, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.front[0, 0] == cube.up[1, 1] && cube.left[0, 2] == cube.up[1, 1] && cube.left[1, 2] == cube.up[1, 1] && cube.up[0, 2] == cube.up[1, 1] && cube.up[0, 1] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1])
                {
                    cube.L(cube, 1);
                    cube.F(cube, 2);
                    cube.r(cube, 1);
                    cube.f(cube, 1);
                    cube.R(cube, 1);
                    cube.f(cube, 1);
                    cube.l(cube, 1);
                }
                //OLL27
                else if (cube.back[2, 0] == cube.up[1, 1] && cube.back[2, 1] == cube.up[1, 1] && cube.right[0, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.front[0, 2] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1] && cube.up[2, 0] == cube.up[1, 1])
                {
                    cube.L(cube, 1);
                    cube.f(cube, 1);
                    cube.l(cube, 1);
                    cube.u(cube, 1);
                    cube.L(cube, 1);
                    cube.F(cube, 1);
                    cube.l(cube, 1);
                    cube.f(cube, 1);
                    cube.U(cube, 1);
                    cube.F(cube, 1);
                }
                //OLL28
                else if (cube.back[2, 2] == cube.up[1, 1] && cube.back[2, 1] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.front[0, 0] == cube.up[1, 1] && cube.left[0, 2] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1] && cube.up[2, 2] == cube.up[1, 1])
                {
                    cube.r(cube, 1);
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.f(cube, 1);
                    cube.R(cube, 1);
                    cube.F(cube, 1);
                    cube.u(cube, 1);
                    cube.f(cube, 1);
                }
                //OLL29
                else if (cube.back[2, 1] == cube.up[1, 1] && cube.right[2, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.front[0, 0] == cube.up[1, 1] && cube.left[0, 2] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1] && cube.up[0, 2] == cube.up[1, 1])
                {
                    cube.L(cube, 1);
                    cube.F(cube, 1);
                    cube.l(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.L(cube, 1);
                    cube.f(cube, 1);
                    cube.l(cube, 1);
                }
                //OLL30
                else if (cube.back[2, 1] == cube.up[1, 1] && cube.right[0, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.front[0, 2] == cube.up[1, 1] && cube.left[2, 2] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1] && cube.up[0, 0] == cube.up[1, 1])
                {
                    cube.r(cube, 1);
                    cube.f(cube, 1);
                    cube.R(cube, 1);
                    cube.l(cube, 1);
                    cube.u(cube, 1);
                    cube.L(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                }
                //OLL31
                else if (cube.back[2, 0] == cube.up[1, 1] && cube.back[2, 2] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1] && cube.up[0, 1] == cube.up[1, 1] && cube.up[2, 0] == cube.up[1, 1] && cube.up[2, 1] == cube.up[1, 1] && cube.up[2, 2] == cube.up[1, 1])
                {
                    cube.r(cube, 1);
                    cube.U(cube, 2);
                    cube.R(cube, 1);
                    cube.F(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.f(cube, 1);
                }
                //OLL32
                else if (cube.back[2, 0] == cube.up[1, 1] && cube.front[0, 0] == cube.up[1, 1] && cube.up[0, 1] == cube.up[1, 1] && cube.up[0, 2] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1] && cube.up[2, 1] == cube.up[1, 1] && cube.up[2, 2] == cube.up[1, 1])
                {
                    cube.L(cube, 1);
                    cube.F(cube, 1);
                    cube.r(cube, 1);
                    cube.f(cube, 1);
                    cube.l(cube, 1);
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.f(cube, 1);
                }
                //OLL33
                else if (cube.front[0, 2] == cube.up[1, 1] && cube.left[0, 2] == cube.up[1, 1] && cube.up[0, 1] == cube.up[1, 1] && cube.up[0, 2] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1] && cube.up[2, 0] == cube.up[1, 1] && cube.up[2, 1] == cube.up[1, 1])
                {
                    cube.f(cube, 1);
                    cube.L(cube, 1);
                    cube.F(cube, 1);
                    cube.r(cube, 1);
                    cube.f(cube, 1);
                    cube.l(cube, 1);
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                }
                //OLL34
                else if (cube.right[2, 0] == cube.up[1, 1] && cube.front[0, 0] == cube.up[1, 1] && cube.left[0, 2] == cube.up[1, 1] && cube.up[0, 1] == cube.up[1, 1] && cube.up[0, 2] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1] && cube.up[2, 1] == cube.up[1, 1])
                {
                    cube.R(cube, 1);
                    cube.U(cube, 2);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                }
                //OLL35
                else if (cube.back[2, 0] == cube.up[1, 1] && cube.right[0, 0] == cube.up[1, 1] && cube.front[0, 2] == cube.up[1, 1] && cube.up[0, 1] == cube.up[1, 1] && cube.up[2, 0] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1] && cube.up[2, 1] == cube.up[1, 1])
                {
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.U(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 2);
                    cube.r(cube, 1);
                }
                //OLL36
                else if (cube.back[2, 0] == cube.up[1, 1] && cube.back[2, 2] == cube.up[1, 1] && cube.front[0, 0] == cube.up[1, 1] && cube.front[0, 2] == cube.up[1, 1] && cube.up[0, 1] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1] && cube.up[2, 1] == cube.up[1, 1])
                {
                    cube.R(cube, 1);
                    cube.U(cube, 2);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                }
                //OLL37
                else if (cube.back[2, 2] == cube.up[1, 1] && cube.front[0, 2] == cube.up[1, 1] && cube.left[0, 2] == cube.up[1, 1] && cube.left[2, 2] == cube.up[1, 1] && cube.up[0, 1] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1] && cube.up[2, 1] == cube.up[1, 1])
                {
                    cube.R(cube, 1);
                    cube.U(cube, 2);
                    cube.R(cube, 2);
                    cube.u(cube, 1);
                    cube.R(cube, 2);
                    cube.u(cube, 1);
                    cube.R(cube, 2);
                    cube.u(cube, 2);
                    cube.R(cube, 1);
                }
                //OLL38
                else if (cube.right[0, 0] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.right[2, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.up[0, 1] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[0, 0] == cube.up[1, 1] && cube.up[2, 0] == cube.up[1, 1])
                {
                    cube.F(cube, 1);
                    cube.U(cube, 1);
                    cube.R(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.f(cube, 1);
                }
                //OLL39
                else if (cube.back[2, 1] == cube.up[1, 1] && cube.right[0, 0] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.right[2, 0] == cube.up[1, 1] && cube.up[2, 1] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[0, 0] == cube.up[1, 1] && cube.up[2, 0] == cube.up[1, 1])
                {
                    cube.b(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.U(cube, 1);
                    cube.R(cube, 1);
                    cube.B(cube, 1);
                }
                //OLL40
                else if (cube.back[2, 1] == cube.up[1, 1] && cube.right[0, 0] == cube.up[1, 1] && cube.front[0, 0] == cube.up[1, 1] && cube.left[1, 2] == cube.up[1, 1] && cube.up[0, 0] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1] && cube.up[2, 1] == cube.up[1, 1] && cube.up[2, 2] == cube.up[1, 1])
                {
                    cube.R(cube, 1);
                    cube.u(cube, 2);
                    cube.R(cube, 2);
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.f(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 2);
                    cube.r(cube, 1);
                }
                //OLL41
                else if (cube.back[2, 1] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.left[0, 2] == cube.up[1, 1] && cube.left[2, 2] == cube.up[1, 1] && cube.up[0, 2] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1] && cube.up[2, 2] == cube.up[1, 1])
                {
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.f(cube, 1);
                }
                //OLL42
                else if (cube.back[2, 0] == cube.up[1, 1] && cube.back[2, 1] == cube.up[1, 1] && cube.front[0, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.up[0, 2] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1] && cube.up[2, 2] == cube.up[1, 1])
                {
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.f(cube, 1);
                }
                //OLL43
                else if (cube.back[2, 1] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.front[0, 2] == cube.up[1, 1] && cube.left[0, 2] == cube.up[1, 1] && cube.up[0, 2] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1] && cube.up[2, 0] == cube.up[1, 1])
                {
                    cube.R(cube, 1);
                    cube.b(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.B(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                }
                //OLL44
                else if (cube.back[2, 1] == cube.up[1, 1] && cube.back[2, 2] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.left[2, 2] == cube.up[1, 1] && cube.up[0, 0] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1] && cube.up[2, 2] == cube.up[1, 1])
                {
                    cube.r(cube, 1);
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.f(cube, 1);
                    cube.U(cube, 1);
                    cube.R(cube, 1);
                }
                //OLL45
                else if (cube.back[2, 1] == cube.up[1, 1] && cube.right[2, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.left[2, 2] == cube.up[1, 1] && cube.up[0, 0] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1] && cube.up[0, 2] == cube.up[1, 1])
                {
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.b(cube, 1);
                    cube.r(cube, 1);
                    cube.f(cube, 1);
                    cube.B(cube, 1);
                }
                //OLL46
                else if (cube.right[0, 0] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.right[2, 0] == cube.up[1, 1] && cube.left[1, 2] == cube.up[1, 1] && cube.up[0, 0] == cube.up[1, 1] && cube.up[0, 1] == cube.up[1, 1] && cube.up[2, 0] == cube.up[1, 1] && cube.up[2, 1] == cube.up[1, 1])
                {
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.f(cube, 1);
                    cube.U(cube, 1);
                    cube.R(cube, 1);
                }
                //OLL47
                else if (cube.back[2, 0] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.right[2, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.up[0, 1] == cube.up[1, 1] && cube.up[0, 2] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[2, 0] == cube.up[1, 1])
                {
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.U(cube, 1);
                    cube.R(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.f(cube, 1);
                }
                //OLL48
                else if (cube.back[2, 1] == cube.up[1, 1] && cube.right[0, 0] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.front[0, 0] == cube.up[1, 1] && cube.up[0, 0] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[2, 1] == cube.up[1, 1] && cube.up[2, 2] == cube.up[1, 1])
                {
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.U(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.R(cube, 1);
                    cube.b(cube, 1);
                    cube.r(cube, 1);
                    cube.B(cube, 1);
                }
                //OLL49
                else if (cube.back[2, 0] == cube.up[1, 1] && cube.front[0, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.left[1, 2] == cube.up[1, 1] && cube.up[0, 1] == cube.up[1, 1] && cube.up[0, 2] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1] && cube.up[2, 2] == cube.up[1, 1])
                {
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.F(cube, 1);
                    cube.U(cube, 1);
                    cube.R(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.f(cube, 1);
                    cube.R(cube, 1);
                }
                //OLL50
                else if (cube.right[0, 0] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.front[0, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.up[0, 0] == cube.up[1, 1] && cube.up[0, 1] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[2, 2] == cube.up[1, 1])
                {
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.f(cube, 1);
                }
                //OLL51
                else if (cube.back[2, 0] == cube.up[1, 1] && cube.back[2, 2] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.up[0, 1] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[2, 0] == cube.up[1, 1] && cube.up[2, 2] == cube.up[1, 1])
                {
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.U(cube, 1);
                    cube.R(cube, 1);
                    cube.u(cube, 2);
                    cube.r(cube, 1);
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.f(cube, 1);
                }
                //OLL52
                else if (cube.back[2, 1] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.front[0, 0] == cube.up[1, 1] && cube.front[0, 2] == cube.up[1, 1] && cube.up[0, 0] == cube.up[1, 1] && cube.up[0, 2] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[2, 1] == cube.up[1, 1])
                {
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.U(cube, 1);
                    cube.R(cube, 1);
                    cube.u(cube, 1);
                    cube.f(cube, 1);
                }
                //OLL53
                else if (cube.back[2, 1] == cube.up[1, 1] && cube.right[2, 0] == cube.up[1, 1] && cube.left[1, 2] == cube.up[1, 1] && cube.left[2, 2] == cube.up[1, 1] && cube.up[0, 0] == cube.up[1, 1] && cube.up[0, 2] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1] && cube.up[2, 1] == cube.up[1, 1])
                {
                    cube.R(cube, 2);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.b(cube, 1);
                    cube.R(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 2);
                    cube.U(cube, 1);
                    cube.R(cube, 1);
                    cube.B(cube, 1);
                    cube.r(cube, 1);
                }
                //OLL54
                else if (cube.back[2, 0] == cube.up[1, 1] && cube.right[1, 0] == cube.up[1, 1] && cube.front[0, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.up[0, 1] == cube.up[1, 1] && cube.up[0, 2] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[2, 2] == cube.up[1, 1])
                {
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.f(cube, 1);
                    cube.u(cube, 1);
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                }
                //OLL55
                else if (cube.back[2, 0] == cube.up[1, 1] && cube.back[2, 1] == cube.up[1, 1] && cube.front[0, 0] == cube.up[1, 1] && cube.left[1, 2] == cube.up[1, 1] && cube.up[0, 2] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1] && cube.up[2, 1] == cube.up[1, 1] && cube.up[2, 2] == cube.up[1, 1])
                {
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.b(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.U(cube, 1);
                    cube.R(cube, 1);
                    cube.B(cube, 1);
                    cube.r(cube, 1);
                }
                //OLL56
                else if (cube.right[1, 0] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.up[0, 0] == cube.up[1, 1] && cube.up[0, 1] == cube.up[1, 1] && cube.up[0, 2] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[2, 0] == cube.up[1, 1] && cube.up[2, 2] == cube.up[1, 1])
                {
                    cube.L(cube, 1);
                    cube.F(cube, 1);
                    cube.r(cube, 1);
                    cube.f(cube, 1);
                    cube.l(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.R(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                }
                //OLL57
                else if (cube.back[2, 1] == cube.up[1, 1] && cube.front[0, 1] == cube.up[1, 1] && cube.up[0, 0] == cube.up[1, 1] && cube.up[0, 2] == cube.up[1, 1] && cube.up[1, 0] == cube.up[1, 1] && cube.up[1, 2] == cube.up[1, 1] && cube.up[2, 0] == cube.up[1, 1] && cube.up[2, 2] == cube.up[1, 1])
                {
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.L(cube, 1);
                    cube.r(cube, 1);
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.f(cube, 1);
                    cube.l(cube, 1);
                }
                else
                    cube.U(cube, 1);
            }
        }
        //PLL顶层排列调整（21种情况）
        public void PLL(Cube cube)
        {
            int flag = 0;
            while (!(cube.front[0, 0] == cube.front[1, 1] && cube.front[0, 1] == cube.front[1, 1] && cube.front[0, 2] == cube.front[1, 1] && cube.right[0, 0] == cube.right[1, 1] && cube.right[1, 0] == cube.right[1, 1] && cube.right[2, 0] == cube.right[1, 1] && cube.back[2, 0] == cube.back[1, 1] && cube.back[2, 1] == cube.back[1, 1] && cube.back[2, 2] == cube.back[1, 1] && cube.left[0, 2] == cube.left[1, 1] && cube.left[1, 2] == cube.left[1, 1] && cube.left[2, 2] == cube.left[1, 1]))
            {
                //PLL1
                if (cube.back[2, 0] == cube.back[1, 1] && cube.back[2, 1] == cube.back[1, 1] && cube.back[2, 2] == cube.back[1, 1] && cube.right[0, 0] == cube.right[1, 1] && cube.right[1, 0] == cube.left[1, 1] && cube.right[2, 0] == cube.right[1, 1] && cube.front[0, 0] == cube.front[1, 1] && cube.front[0, 1] == cube.right[1, 1] && cube.front[0, 2] == cube.front[1, 1] && cube.left[0, 2] == cube.left[1, 1] && cube.left[1, 2] == cube.front[1, 1] && cube.left[2, 2] == cube.left[1, 1])
                {
                    cube.R(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.R(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 2);
                }
                //PLL2
                else if (cube.back[2, 0] == cube.back[1, 1] && cube.back[2, 1] == cube.back[1, 1] && cube.back[2, 2] == cube.back[1, 1] && cube.right[0, 0] == cube.right[1, 1] && cube.right[1, 0] == cube.front[1, 1] && cube.right[2, 0] == cube.right[1, 1] && cube.front[0, 0] == cube.front[1, 1] && cube.front[0, 1] == cube.left[1, 1] && cube.front[0, 2] == cube.front[1, 1] && cube.left[0, 2] == cube.left[1, 1] && cube.left[1, 2] == cube.right[1, 1] && cube.left[2, 2] == cube.left[1, 1])
                {
                    cube.R(cube, 2);
                    cube.U(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                }
                //PLL3
                else if (cube.back[2, 0] == cube.back[1, 1] && cube.back[2, 2] == cube.back[1, 1] && cube.right[0, 0] == cube.right[1, 1] && cube.right[2, 0] == cube.right[1, 1] && cube.front[0, 0] == cube.front[1, 1] && cube.front[0, 2] == cube.front[1, 1] && cube.left[0, 2] == cube.left[1, 1] && cube.left[2, 2] == cube.left[1, 1] && cube.right[1, 0] == cube.left[1, 1] && cube.front[0, 1] == cube.back[1, 1] && cube.left[1, 2] == cube.right[1, 1] && cube.back[2, 1] == cube.front[1, 1])
                {
                    cube.R(cube, 2);
                    cube.L(cube, 2);
                    cube.D(cube, 1);
                    cube.R(cube, 2);
                    cube.L(cube, 2);
                    cube.D(cube, 2);
                    cube.R(cube, 2);
                    cube.L(cube, 2);
                    cube.D(cube, 1);
                    cube.R(cube, 2);
                    cube.L(cube, 2);
                }
                //PLL4
                else if (cube.back[2, 0] == cube.back[1, 1] && cube.back[2, 2] == cube.back[1, 1] && cube.right[0, 0] == cube.right[1, 1] && cube.right[2, 0] == cube.right[1, 1] && cube.front[0, 0] == cube.front[1, 1] && cube.front[0, 2] == cube.front[1, 1] && cube.left[0, 2] == cube.left[1, 1] && cube.left[2, 2] == cube.left[1, 1] && cube.right[1, 0] == cube.front[1, 1] && cube.front[0, 1] == cube.right[1, 1] && cube.left[1, 2] == cube.back[1, 1] && cube.back[2, 1] == cube.left[1, 1])
                {
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.R(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.R(cube, 2);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.U(cube, 1);
                }
                //PLL5
                else if (cube.back[2, 0] == cube.back[1, 1] && cube.back[2, 1] == cube.back[1, 1] && cube.back[2, 2] == cube.right[1, 1] && cube.right[0, 0] == cube.front[1, 1] && cube.right[1, 0] == cube.right[1, 1] && cube.right[2, 0] == cube.front[1, 1] && cube.front[0, 0] == cube.back[1, 1] && cube.front[0, 1] == cube.front[1, 1] && cube.front[0, 2] == cube.left[1, 1] && cube.left[0, 2] == cube.left[1, 1] && cube.left[1, 2] == cube.left[1, 1] && cube.left[2, 2] == cube.right[1, 1])
                {
                    cube.R(cube, 2);
                    cube.F(cube, 2);
                    cube.r(cube, 1);
                    cube.b(cube, 1);
                    cube.R(cube, 1);
                    cube.F(cube, 2);
                    cube.r(cube, 1);
                    cube.B(cube, 1);
                    cube.r(cube, 1);
                }
                //PLL6
                else if (cube.back[2, 0] == cube.back[1, 1] && cube.back[2, 1] == cube.back[1, 1] && cube.back[2, 2] == cube.front[1, 1] && cube.right[0, 0] == cube.left[1, 1] && cube.right[1, 0] == cube.right[1, 1] && cube.right[2, 0] == cube.back[1, 1] && cube.front[0, 0] == cube.right[1, 1] && cube.front[0, 1] == cube.front[1, 1] && cube.front[0, 2] == cube.right[1, 1] && cube.left[0, 2] == cube.left[1, 1] && cube.left[1, 2] == cube.left[1, 1] && cube.left[2, 2] == cube.front[1, 1])
                {
                    cube.R(cube, 1);
                    cube.b(cube, 1);
                    cube.R(cube, 1);
                    cube.F(cube, 2);
                    cube.r(cube, 1);
                    cube.B(cube, 1);
                    cube.R(cube, 1);
                    cube.F(cube, 2);
                    cube.R(cube, 2);
                }
                //PLL7
                else if (cube.back[2, 0] == cube.left[1, 1] && cube.back[2, 1] == cube.back[1, 1] && cube.back[2, 2] == cube.right[1, 1] && cube.right[0, 0] == cube.front[1, 1] && cube.right[1, 0] == cube.right[1, 1] && cube.right[2, 0] == cube.back[1, 1] && cube.front[0, 0] == cube.left[1, 1] && cube.front[0, 1] == cube.front[1, 1] && cube.front[0, 2] == cube.right[1, 1] && cube.left[0, 2] == cube.front[1, 1] && cube.left[1, 2] == cube.left[1, 1] && cube.left[2, 2] == cube.back[1, 1])
                {
                    cube.R(cube, 1);
                    cube.b(cube, 1);
                    cube.r(cube, 1);
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.B(cube, 1);
                    cube.r(cube, 1);
                    cube.F(cube, 2);
                    cube.l(cube, 1);
                    cube.B(cube, 1);
                    cube.L(cube, 1);
                    cube.F(cube, 1);
                    cube.l(cube, 1);
                    cube.b(cube, 1);
                    cube.L(cube, 1);
                }
                //PLL8
                else if (cube.back[2, 0] == cube.back[1, 1] && cube.back[2, 1] == cube.back[1, 1] && cube.back[2, 2] == cube.right[1, 1] && cube.right[0, 0] == cube.front[1, 1] && cube.right[1, 0] == cube.left[1, 1] && cube.right[2, 0] == cube.back[1, 1] && cube.front[0, 0] == cube.front[1, 1] && cube.front[0, 1] == cube.front[1, 1] && cube.front[0, 2] == cube.right[1, 1] && cube.left[0, 2] == cube.left[1, 1] && cube.left[1, 2] == cube.right[1, 1] && cube.left[2, 2] == cube.left[1, 1])
                {
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.F(cube, 1);
                    cube.R(cube, 2);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.f(cube, 1);
                }
                //PLL9
                else if (cube.back[2, 0] == cube.back[1, 1] && cube.back[2, 1] == cube.front[1, 1] && cube.back[2, 2] == cube.right[1, 1] && cube.right[0, 0] == cube.front[1, 1] && cube.right[1, 0] == cube.right[1, 1] && cube.right[2, 0] == cube.back[1, 1] && cube.front[0, 0] == cube.front[1, 1] && cube.front[0, 1] == cube.back[1, 1] && cube.front[0, 2] == cube.right[1, 1] && cube.left[0, 2] == cube.left[1, 1] && cube.left[1, 2] == cube.left[1, 1] && cube.left[2, 2] == cube.left[1, 1])
                {
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.U(cube, 1);
                    cube.R(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 2);
                    cube.f(cube, 1);
                    cube.u(cube, 1);
                    cube.F(cube, 1);
                    cube.U(cube, 1);
                    cube.R(cube, 1);
                    cube.F(cube, 1);
                    cube.r(cube, 1);
                    cube.f(cube, 1);
                    cube.R(cube, 2);
                }
                //PLL10
                else if (cube.back[2, 0] == cube.front[1, 1] && cube.back[2, 1] == cube.right[1, 1] && cube.back[2, 2] == cube.back[1, 1] && cube.right[0, 0] == cube.right[1, 1] && cube.right[1, 0] == cube.back[1, 1] && cube.right[2, 0] == cube.left[1, 1] && cube.front[0, 0] == cube.front[1, 1] && cube.front[0, 1] == cube.front[1, 1] && cube.front[0, 2] == cube.back[1, 1] && cube.left[0, 2] == cube.right[1, 1] && cube.left[1, 2] == cube.left[1, 1] && cube.left[2, 2] == cube.left[1, 1])
                {
                    cube.r(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.b(cube, 1);
                    cube.D(cube, 1);
                    cube.b(cube, 1);
                    cube.d(cube, 1);
                    cube.B(cube, 2);
                    cube.r(cube, 1);
                    cube.b(cube, 1);
                    cube.R(cube, 1);
                    cube.B(cube, 1);
                    cube.R(cube, 1);
                }
                //PLL11
                else if (cube.back[2, 0] == cube.front[1, 1] && cube.back[2, 1] == cube.left[1, 1] && cube.back[2, 2] == cube.back[1, 1] && cube.right[0, 0] == cube.right[1, 1] && cube.right[1, 0] == cube.right[1, 1] && cube.right[2, 0] == cube.left[1, 1] && cube.front[0, 0] == cube.front[1, 1] && cube.front[0, 1] == cube.front[1, 1] && cube.front[0, 2] == cube.back[1, 1] && cube.left[0, 2] == cube.right[1, 1] && cube.left[1, 2] == cube.back[1, 1] && cube.left[2, 2] == cube.left[1, 1])
                {
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.f(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.f(cube, 1);
                }
                //PLL12
                else if (cube.back[2, 0] == cube.back[1, 1] && cube.back[2, 1] == cube.back[1, 1] && cube.back[2, 2] == cube.back[1, 1] && cube.right[0, 0] == cube.right[1, 1] && cube.right[1, 0] == cube.front[1, 1] && cube.right[2, 0] == cube.front[1, 1] && cube.front[0, 0] == cube.right[1, 1] && cube.front[0, 1] == cube.right[1, 1] && cube.front[0, 2] == cube.left[1, 1] && cube.left[0, 2] == cube.left[1, 1] && cube.left[1, 2] == cube.left[1, 1] && cube.left[2, 2] == cube.front[1, 1])
                {
                    cube.l(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.U(cube, 2);
                    cube.L(cube, 1);
                    cube.u(cube, 1);
                    cube.l(cube, 1);
                    cube.U(cube, 2);
                    cube.L(cube, 1);
                    cube.R(cube, 1);
                    cube.u(cube, 1);
                }
                //PLL13
                else if (cube.back[2, 0] == cube.back[1, 1] && cube.back[2, 1] == cube.back[1, 1] && cube.back[2, 2] == cube.right[1, 1] && cube.right[0, 0] == cube.front[1, 1] && cube.right[1, 0] == cube.front[1, 1] && cube.right[2, 0] == cube.back[1, 1] && cube.front[0, 0] == cube.front[1, 1] && cube.front[0, 1] == cube.right[1, 1] && cube.front[0, 2] == cube.right[1, 1] && cube.left[0, 2] == cube.left[1, 1] && cube.left[1, 2] == cube.left[1, 1] && cube.left[2, 2] == cube.left[1, 1])
                {
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.f(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.F(cube, 1);
                    cube.R(cube, 2);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                }
                //PLL14
                else if (cube.back[2, 0] == cube.right[1, 1] && cube.back[2, 1] == cube.back[1, 1] && cube.back[2, 2] == cube.left[1, 1] && cube.right[0, 0] == cube.back[1, 1] && cube.right[1, 0] == cube.front[1, 1] && cube.right[2, 0] == cube.right[1, 1] && cube.front[0, 0] == cube.front[1, 1] && cube.front[0, 1] == cube.right[1, 1] && cube.front[0, 2] == cube.front[1, 1] && cube.left[0, 2] == cube.back[1, 1] && cube.left[1, 2] == cube.left[1, 1] && cube.left[2, 2] == cube.left[1, 1])
                {
                    cube.r(cube, 1);
                    cube.U(cube, 2);
                    cube.R(cube, 1);
                    cube.U(cube, 2);
                    cube.r(cube, 1);
                    cube.F(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.r(cube, 1);
                    cube.f(cube, 1);
                    cube.R(cube, 2);
                    cube.u(cube, 1);
                }
                //PLL15
                else if (cube.back[2, 0] == cube.back[1, 1] && cube.back[2, 1] == cube.right[1, 1] && cube.back[2, 2] == cube.back[1, 1] && cube.right[0, 0] == cube.right[1, 1] && cube.right[1, 0] == cube.back[1, 1] && cube.right[2, 0] == cube.front[1, 1] && cube.front[0, 0] == cube.right[1, 1] && cube.front[0, 1] == cube.front[1, 1] && cube.front[0, 2] == cube.left[1, 1] && cube.left[0, 2] == cube.left[1, 1] && cube.left[1, 2] == cube.left[1, 1] && cube.left[2, 2] == cube.front[1, 1])
                {
                    cube.R(cube, 1);
                    cube.U(cube, 2);
                    cube.r(cube, 1);
                    cube.U(cube, 2);
                    cube.R(cube, 1);
                    cube.b(cube, 1);
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.R(cube, 1);
                    cube.B(cube, 1);
                    cube.R(cube, 2);
                    cube.U(cube, 1);
                }
                //PLL16
                else if (cube.back[2, 0] == cube.left[1, 1] && cube.back[2, 1] == cube.back[1, 1] && cube.back[2, 2] == cube.back[1, 1] && cube.right[0, 0] == cube.right[1, 1] && cube.right[1, 0] == cube.front[1, 1] && cube.right[2, 0] == cube.left[1, 1] && cube.front[0, 0] == cube.right[1, 1] && cube.front[0, 1] == cube.left[1, 1] && cube.front[0, 2] == cube.back[1, 1] && cube.left[0, 2] == cube.front[1, 1] && cube.left[1, 2] == cube.right[1, 1] && cube.left[2, 2] == cube.front[1, 1])
                {
                    cube.R(cube, 2);
                    cube.d(cube, 1);
                    cube.F(cube, 1);
                    cube.u(cube, 1);
                    cube.F(cube, 1);
                    cube.U(cube, 1);
                    cube.f(cube, 1);
                    cube.D(cube, 1);
                    cube.R(cube, 2);
                    cube.B(cube, 1);
                    cube.u(cube, 1);
                    cube.b(cube, 1);
                }
                //PLL17
                else if (cube.back[2, 0] == cube.right[1, 1] && cube.back[2, 1] == cube.left[1, 1] && cube.back[2, 2] == cube.front[1, 1] && cube.right[0, 0] == cube.left[1, 1] && cube.right[1, 0] == cube.right[1, 1] && cube.right[2, 0] == cube.right[1, 1] && cube.front[0, 0] == cube.left[1, 1] && cube.front[0, 1] == cube.back[1, 1] && cube.front[0, 2] == cube.front[1, 1] && cube.left[0, 2] == cube.back[1, 1] && cube.left[1, 2] == cube.front[1, 1] && cube.left[2, 2] == cube.back[1, 1])
                {
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.F(cube, 2);
                    cube.d(cube, 1);
                    cube.L(cube, 1);
                    cube.u(cube, 1);
                    cube.l(cube, 1);
                    cube.U(cube, 1);
                    cube.l(cube, 1);
                    cube.D(cube, 1);
                    cube.F(cube, 2);
                }
                //PLL18
                else if (cube.back[2, 0] == cube.right[1, 1] && cube.back[2, 1] == cube.left[1, 1] && cube.back[2, 2] == cube.front[1, 1] && cube.right[0, 0] == cube.left[1, 1] && cube.right[1, 0] == cube.back[1, 1] && cube.right[2, 0] == cube.right[1, 1] && cube.front[0, 0] == cube.left[1, 1] && cube.front[0, 1] == cube.front[1, 1] && cube.front[0, 2] == cube.front[1, 1] && cube.left[0, 2] == cube.back[1, 1] && cube.left[1, 2] == cube.right[1, 1] && cube.left[2, 2] == cube.back[1, 1])
                {
                    cube.R(cube, 2);
                    cube.D(cube, 1);
                    cube.b(cube, 1);
                    cube.U(cube, 1);
                    cube.b(cube, 1);
                    cube.u(cube, 1);
                    cube.B(cube, 1);
                    cube.d(cube, 1);
                    cube.R(cube, 2);
                    cube.f(cube, 1);
                    cube.U(cube, 1);
                    cube.F(cube, 1);
                }
                //PLL19
                else if (cube.back[2, 0] == cube.right[1, 1] && cube.back[2, 1] == cube.front[1, 1] && cube.back[2, 2] == cube.back[1, 1] && cube.right[0, 0] == cube.right[1, 1] && cube.right[1, 0] == cube.right[1, 1] && cube.right[2, 0] == cube.left[1, 1] && cube.front[0, 0] == cube.right[1, 1] && cube.front[0, 1] == cube.left[1, 1] && cube.front[0, 2] == cube.back[1, 1] && cube.left[0, 2] == cube.front[1, 1] && cube.left[1, 2] == cube.back[1, 1] && cube.left[2, 2] == cube.front[1, 1])
                {
                    cube.r(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.B(cube, 2);
                    cube.D(cube, 1);
                    cube.l(cube, 1);
                    cube.u(cube, 1);
                    cube.L(cube, 1);
                    cube.u(cube, 1);
                    cube.L(cube, 1);
                    cube.d(cube, 1);
                    cube.B(cube, 2);
                }
                //PLL20
                else if (cube.back[2, 0] == cube.front[1, 1] && cube.back[2, 1] == cube.front[1, 1] && cube.back[2, 2] == cube.back[1, 1] && cube.right[0, 0] == cube.right[1, 1] && cube.right[1, 0] == cube.right[1, 1] && cube.right[2, 0] == cube.left[1, 1] && cube.front[0, 0] == cube.front[1, 1] && cube.front[0, 1] == cube.back[1, 1] && cube.front[0, 2] == cube.back[1, 1] && cube.left[0, 2] == cube.right[1, 1] && cube.left[1, 2] == cube.left[1, 1] && cube.left[2, 2] == cube.left[1, 1])
                {
                    cube.u(cube, 1);
                    cube.L(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 2);
                    cube.l(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.L(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 2);
                    cube.l(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                }
                //PLL21
                else if (cube.back[2, 0] == cube.back[1, 1] && cube.back[2, 1] == cube.front[1, 1] && cube.back[2, 2] == cube.front[1, 1] && cube.right[0, 0] == cube.left[1, 1] && cube.right[1, 0] == cube.right[1, 1] && cube.right[2, 0] == cube.right[1, 1] && cube.front[0, 0] == cube.back[1, 1] && cube.front[0, 1] == cube.back[1, 1] && cube.front[0, 2] == cube.front[1, 1] && cube.left[0, 2] == cube.left[1, 1] && cube.left[1, 2] == cube.left[1, 1] && cube.left[2, 2] == cube.right[1, 1])
                {
                    cube.l(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.U(cube, 2);
                    cube.L(cube, 1);
                    cube.u(cube, 1);
                    cube.l(cube, 1);
                    cube.R(cube, 1);
                    cube.U(cube, 1);
                    cube.r(cube, 1);
                    cube.U(cube, 2);
                    cube.L(cube, 1);
                    cube.u(cube, 1);
                    cube.R(cube, 1);
                    cube.u(cube, 1);
                }
                else
                {
                    if (flag < 4)
                    {
                        cube.U(cube, 1);
                        flag++;
                    }
                    else
                    {
                        count -= 4;
                        cube.Y(cube, 1);
                        flag = 0;
                    }
                }
            }
        }
    }
}
