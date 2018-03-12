using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Pdf.Graphics;
using Spire.Pdf;
using System.Drawing;
using System.Drawing.Imaging;



namespace DrawImageDemo
{
    class Program
    {

        /// <summary>
        /// 从pdf中抽取出image图片
        /// </summary>
        /// <param name="fileName"></param>
        private static void ExcateImages(String fileName)
        {
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(fileName);
            IList<Image> images = new List<Image>();
            foreach (PdfPageBase page in doc.Pages)
            {
                if (page.ExtractImages() != null)
                {
                    foreach (Image image in page.ExtractImages())
                    {
                        images.Add(image);
                    }
                }
            }
            doc.Close();
            int index = 0;
            foreach (Image image in images)
            {
                String imageFileName = String.Format("Image-{0}.png", index++);

                image.Save(imageFileName, ImageFormat.Png);
            }


        }

        /// <summary>
        /// 根据图片和文字生成方法
        /// </summary>
        /// <param name="ImageFileName"></param>
        /// <param name="pdfFileName"></param>
        private static void GenaratePDF(String ImageFileName, String pdfFileName)
        {
            PdfDocument doc=null;
            PdfPageBase page;
            try
            {
                 doc = new PdfDocument();
                 page = doc.Pages.Add();

                //添加图片

                PdfImage image2 = PdfImage.FromFile(ImageFileName);
                float width = image2.Width * 0.75f;
                float height = image2.Height * 0.75f;
                float x = (page.Canvas.ClientSize.Width - width) / 2;
                //page.Canvas.ClientSize.Width 可绘制的pdf图像的区域的宽
                Console.WriteLine("page.Canvas.ClientSize.Width  =" + page.Canvas.ClientSize.Width);
                Console.WriteLine("width=" + width+",height ="+height);
                Console.WriteLine("x="+x);
                Console.WriteLine("page.Canvas.ClientSize.heigh="+page.Canvas.ClientSize.Height);
                page.Canvas.DrawImage(image2, x, 33);
                doc.SaveToFile(pdfFileName);


                PDFDocumentViewer(pdfFileName);
            }
            catch (Exception e)
            {
                
                throw e;
            }
            finally
            {
                if(!doc.Equals("")||doc!=null)
                doc.Close();
               
                
            }

            


        }

 

        /// <summary>
        /// 根据图片和文字生成方法
        /// </summary>
        /// <param name="ImageFileName"></param>
        /// <param name="pdfFileName"></param>
        private static void GenaratePDF1(String ImageFileName, String pdfFileName)
        {

            PdfDocument doc = new PdfDocument();
            PdfPageBase page = doc.Pages.Add();

            //添加图片

            PdfImage image2 = PdfImage.FromFile(ImageFileName);
            float width = image2.Width * 0.75f;
            float height = image2.Height * 0.75f;
            float x = (page.Canvas.ClientSize.Width - width) / 2;
            Console.WriteLine("page.Canvas.ClientSize.Width  =" + page.Canvas.ClientSize.Width);
            Console.WriteLine("width=" + width);
            page.Canvas.DrawImage(image2, x, 0);//page.Canvas.DrawImage(image2, 0, 0);/与page.Canvas.DrawImage(image2, 0, 0,width,height);等价
            //page.Canvas.DrawImage(image2, x - 100, 0, width, height);
            page.Canvas.DrawString("Demo of extract text and imgae from PDF!",
            new PdfFont(PdfFontFamily.Helvetica, 20f),
            new PdfSolidBrush(Color.Blue), 0, 0);//drawString x,y 表示坐标原点的位置。
            doc.SaveToFile(pdfFileName);


            PDFDocumentViewer(pdfFileName);


        }




        private static void PDFDocumentViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }





        static void Main(string[] args)
        {
              ExcateImages("3 DrawImage.pdf");
            GenaratePDF("Image-0.png", "adonai111.pdf");
        }
    }
}
