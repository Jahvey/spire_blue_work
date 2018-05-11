using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WinFormDemo0102
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 根据图片路径, 返回一张灰度图
        /// </summary>
        /// <param name="strPicPath">图片路径</param>
        /// <returns>灰度图对象</returns>
        public Image GetGrayPicture(string strPicPath)
        {
            /*
            * Stride: 图像扫描宽度
            * 图像在内存里是按行存储的。扫描行宽度就是存储一行像素，用了多少字节的内存。
            * 比如一个101×200大小的图像，每个像素是32位的（也就是每个像素4个字节），那么实际每行占用的内存大小是101*4=404个字节。
            * 然后一般的图像库都会有个内存对齐。假设按照8字节对齐，那么404按照8字节对齐的话，实际是408个字节。这408个字节就是扫描行宽度。
            * 
            * Interop: 托管/非托管代码之间的互操作
            * 
            * Marshal: 类提供了一个方法集，这些方法用于分配非托管内存、复制非托管内存块、将托管类型转换为非托管类型，
            * 此外还提供了在与非托管代码交互时使用的其他杂项方法
            */
            // Create a new bitmap.
            Bitmap bitmap = new Bitmap(strPicPath);
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            // Lock the bitmap's bits. 
            //转成24rgb颜色 24色就是由r g b, 三个颜色, 每个颜色各用一字节(8位)表示亮度
           // BitmapData bmpData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData bmpData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int iStride = bmpData.Stride; //图片一行象素所占用的字节  

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int iBytes = iStride * bitmap.Height;
            byte[] rgbValues = new byte[iBytes];
           

            // Copy RGB values into the Array
  
            Marshal.Copy(ptr, rgbValues, 0, iBytes);

            for (int y = 0; y < bmpData.Height; ++y)
            {
                for (int x = 0; x < bmpData.Width; ++x)
                {
                    //图像(x, y)坐标坐标中第1个像素中rgbValues中的索引位置(这儿x,y是从0开始记的)
                    //rgbValues每行是扫描宽个字节, 不是bitmap.Width * 3
                    int iThird = iStride * y + 3 * x;
                    byte avg = (byte)((rgbValues[iThird] * 0.299 + rgbValues[iThird + 1] * 0.587 + rgbValues[iThird + 2] * 0.114));//转化成灰度
                    rgbValues[iThird] = avg;
                    rgbValues[iThird + 1] = avg;
                    rgbValues[iThird + 2] = avg;
                }
            }
            // copy到原来图像中
            Marshal.Copy(rgbValues, 0, ptr, rgbValues.Length);

            // Unlock the bits.
            bitmap.UnlockBits(bmpData);
           
            return bitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Image2gray1();



        }

        private void Image2gray1()
        {
            Image image = GetGrayPicture(AppDomain.CurrentDomain.BaseDirectory + "qq1.jpg");
            image.Save(AppDomain.CurrentDomain.BaseDirectory + "11.png");
            // Console.WriteLine(image.ToString());

            System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "11.png");
            // MessageBox.Show("finised!!");
        }
    }
}
