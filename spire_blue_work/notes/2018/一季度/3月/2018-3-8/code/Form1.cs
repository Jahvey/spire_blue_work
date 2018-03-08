using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Imaging;
using System.Drawing.Drawing2D;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        Graphics g ;
        GraphicsState gs ;
        Pen p ;//定义了一个蓝色,宽度为的画笔

        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
          gs = g.Save();
            p = new Pen(Color.Blue, 2);//定义了一个蓝色,宽度为的画笔
            
        }

       


        private void button1_Click(object sender, EventArgs e)
        {

           g.Clear(Color.WhiteSmoke);
           // g.TranslateTransform(20, 70);
            g.DrawEllipse(p,0,0,200,200);
         
            g.Restore(gs);
     
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           g.Clear(Color.WhiteSmoke);
            g.DrawLine(p, new PointF(0, 350), new PointF(200, 150));
            g.Restore(gs);


        }
    }
}
