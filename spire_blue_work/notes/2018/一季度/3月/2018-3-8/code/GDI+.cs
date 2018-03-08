using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ConsoleApplication1
{
    class demo2
    {

       

       private static    Bitmap myBitmap=null;
       private static Graphics g;
 

        public static void Main03(string[] args)
        {


            init();
            createNewImage(g);


           // DrawString(g);
        }


        private static void pngViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }

        private static Graphics init() {
          myBitmap = new Bitmap(450, 450);
            //create the graphics by image
            g= Graphics.FromImage(myBitmap);
            return g;
        
        
        }



        private  static void DisposeSource(Graphics g)
        {

            myBitmap.Save("result.png", System.Drawing.Imaging.ImageFormat.Png);
            g.Dispose();

        }

        private static void DrawString(Graphics g) {

           
            Font font = new Font("华为宋体", 12);
            //Point一样，只是值是浮点类型
            PointF point = new PointF(50, 50);
            g.DrawString("我是adonai", font, Brushes.Coral, point);
            DisposeSource(g);
            pngViewer("result.png");

        }


        private static void createNewImage( Graphics g)
        {

            
            Pen p = new Pen(Color.Blue, 2);//定义了一个蓝色,宽度为的画笔
            g.RotateTransform(12, System.Drawing.Drawing2D.MatrixOrder.Prepend);
            g.ScaleTransform(2, 2, System.Drawing.Drawing2D.MatrixOrder.Prepend);
            //g.ResetTransform();
            g.DrawLine(p, 25, 25, 100, 100);//在画板上画直线,起始坐标为(10,10),终点坐标为(100,100)
            g.DrawRectangle(p, 25, 10, 100, 100);//在画板上画矩形,起始坐标为(10,10),宽为,高为
          //  g.DrawEllipse(p, 10, 10, 100, 100);//在画板上画椭圆,起始坐标为(10,10),外接矩形的宽为,高为
            

            DisposeSource(g);
            pngViewer("result.png");
        }
    }
}
