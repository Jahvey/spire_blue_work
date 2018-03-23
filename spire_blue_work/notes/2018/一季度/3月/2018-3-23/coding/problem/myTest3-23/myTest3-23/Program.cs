using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Spire.Pdf.Graphics;
using Spire.Pdf;



namespace myTest3_23
{
    class Program
    {


        private static void TestVertical2()
        {
            String fileName = @"13252_-move.pdf";
            //if (File.Exists(fileName)) File.Delete(fileName);
            PdfDocument doc = new PdfDocument();
            PdfPageBase page = doc.Pages.Add();
            PdfPen pen = new PdfPen(PdfBrushes.Green, 1f);
            float move = 2;
  
            page.Canvas.DrawLine(pen, new PointF(-0.5f, 0), new PointF(-0.5f, 500));
          
            doc.SaveToFile(fileName);

        }
        private static void TestVertical() {
            String fileName = @"13252_1l.pdf";
            //if (File.Exists(fileName)) File.Delete(fileName);
            PdfDocument doc = new PdfDocument();
            PdfPageBase page = doc.Pages.Add();
            PdfPen pen = new PdfPen(PdfBrushes.Green, 1f);
            float move = 2;
            page.Canvas.DrawLine(pen, new PointF(-move, 0), new PointF(-move, 500));
            page.Canvas.DrawLine(pen, new PointF(0, 0), new PointF(0, 500));
            page.Canvas.DrawLine(pen, new PointF(move, 0), new PointF(move, 500));
            //page.Canvas.DrawLine(pen, new PointF(100, 0), new PointF(100, 500));
           // page.Canvas.DrawLine(pen, new PointF(110, 0), new PointF(110, 500));
            doc.SaveToFile(fileName);
        
        }

        private static void TestDrawBlack() {
            String fileName = @"13252_b.pdf";
            if (File.Exists(fileName)) File.Delete(fileName);
            PdfDocument doc = new PdfDocument();
            PdfPageBase page = doc.Pages.Add();
            PdfPen pen = new PdfPen(PdfBrushes.Green, 1f);
            //page.Canvas.DrawLine(pen, new PointF(0, 0), new PointF(0, 500));
            //page.Canvas.DrawLine(pen, new PointF(50, 0), new PointF(50, 500));
            //page.Canvas.DrawLine(pen, new PointF(100, 0), new PointF(100, 500));
            //page.Canvas.DrawLine(pen, new PointF(110, 0), new PointF(110, 500));
            doc.SaveToFile(fileName);
        
        }


        static void Main(string[] args)
        {
            TestVertical2();
           // TestDrawBlack();
        }
    }
}
