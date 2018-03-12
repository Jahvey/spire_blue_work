using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GDI绘图
{
    /// <summary>
    /// DrawDemo by GDI
    /// </summary>
    public partial class Form1 : Form
    {

        private static Graphics g;
        private static GraphicsState gs;
        private static Pen p;

        public Form1()
        {
            InitializeComponent();

            g = this.CreateGraphics();
            p = new Pen(Color.Blue, 2);//定义了一个蓝色,宽度为2的画笔
        }

        private void drawCircle_Click(object sender, EventArgs e)
        {
            gs = g.Save();
             g.Clear(Color.WhiteSmoke);
            g.TranslateTransform(20, 70);
            g.DrawEllipse(p, 0, 0, 200, 200);

            g.Restore(gs);

        }

        private void drawRec_Click(object sender, EventArgs e)
        {
            gs = g.Save();
            g.Clear(Color.WhiteSmoke);
            int offset = 10;
            //创建一个数组来存放矩阵的各个坐标
            PointF[]mypointf=new PointF[] {
                new PointF(0,0), new PointF(0,200) ,//
                new PointF(200,200),new PointF(200,0),//
                new PointF(0,0)};
            for (int i = 0; i < mypointf.Length; i++)
			{
			    mypointf[i].X+=offset;
                mypointf[i].Y+=offset;
			}
            g.DrawLines(p, mypointf);//绘制矩形
            g.DrawLines(p,new PointF[]{new PointF(300,100),new PointF(250,360)});
            
            g.Restore(gs);

        }
    }
}
