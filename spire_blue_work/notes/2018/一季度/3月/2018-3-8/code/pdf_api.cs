using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Spire.Pdf.Graphics;
using Spire.Pdf;

namespace ConsoleApplication1
{
    class demo1
    {
        /// <summary>
        /// how to draw a strightLine on page
        /// </summary>
        /// <param name="page"></param>
        private void DrawStrightLine01(PdfPageBase page)
        {

            PointF[] points = new PointF[4];

            //points[0] = new PointF(-1, -1);
            //points[1] = new PointF(-1, 1);
            //points[2] = new PointF(1, 1);
            //points[3] = new PointF(1, -1);

            int downRate = 1;
            int leftRate = 2;
            points[0] = new PointF(-1 - leftRate, -1 + downRate);
            points[1] = new PointF(-1 - leftRate, 1 + downRate);
            points[2] = new PointF(1 - leftRate, 1 + downRate);
            points[3] = new PointF(1 - leftRate, -1 + downRate);



            PdfPath path = new PdfPath();
            path.AddLine(points[0], points[1]);
            path.AddLine(points[1], points[2]);
            path.AddLine(points[2], points[3]);
            path.AddLine(points[3], points[0]);


            //save graphics state
            //PdfGraphicsState state = page.Canvas.Save();
            PdfPen pen = new PdfPen(Color.DeepSkyBlue, 0.02f);



            page.Canvas.ScaleTransform(95f, 95f);
            // page.Canvas.RotateTransform(-11.5f);
            page.Canvas.TranslateTransform(5f, 1.2f);
            page.Canvas.DrawPath(pen, path);



            //drawing a stright line
            PdfPath path2 = new PdfPath();
            path2.AddLine(new PointF(-4.5f, 0), new PointF(-4.5f, 3.53f));
            PdfPen pen2 = new PdfPen(Color.Red, 0.046f);
            page.Canvas.DrawPath(pen2, path2);


        }


        private void DrawStrightLine(PdfPageBase page)
        {

            PointF[] points = new PointF[4];



            int downRate = 350;
            int leftRate = 150;
            int baseRate = 94;
            points[0] = new PointF(-baseRate + leftRate, -baseRate + downRate);
            points[1] = new PointF(-baseRate + leftRate, baseRate + downRate);
            points[2] = new PointF(baseRate + leftRate, baseRate + downRate);
            points[3] = new PointF(baseRate + leftRate, -baseRate + downRate);



            PdfPath path = new PdfPath();
            path.AddLine(points[0], points[1]);
            path.AddLine(points[1], points[2]);
            path.AddLine(points[2], points[3]);
            path.AddLine(points[3], points[0]);
            


            //save graphics state
            //PdfGraphicsState state = page.Canvas.Save();
            PdfPen pen = new PdfPen(Color.DeepSkyBlue, 2f);



           // page.Canvas.ScaleTransform(95f, 95f);
            //skewTransform б�任
 
            page.Canvas.SkewTransform(10, 10);
            
             //page.Canvas.RotateTransform(-15.5f);
            //translation operator
             page.Canvas.TranslateTransform(0,-90);//shift shapes
           // page.Canvas.TranslateTransform(5f, 1.2f);
            
            page.Canvas.DrawPath(pen, path);



            //drawing a stright line
            PdfPath path2 = new PdfPath();
            path2.AddLine(new PointF(0,450f), new PointF(258f,450f));
            PdfPen pen2 = new PdfPen(Color.Blue, 3f);
            page.Canvas.DrawPath(pen2, path2);


        }




        private void DrawRectangle(PdfPageBase page)
        {

            //notice the watermarker
            //drawing a stright line
            PdfPath path2 = new PdfPath();
            path2.AddLine(new PointF(1f, 310), new PointF(1f, 50f));
            PdfPen pen2 = new PdfPen(Color.Black, 2f);
            page.Canvas.RotateTransform(-45f);
           // page.Canvas.ScaleTransform(85f,85f);
            page.Canvas.DrawPath(pen2, path2);



        }



        private void PDFDocumentViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }




        static void Main(string[] args)
        {

            demo1 mypro = new demo1();

            //Create a pdf document.
            PdfDocument doc = new PdfDocument();

            // Create one page
            PdfPageBase page1 = doc.Pages.Add();
            PdfPageBase page2 = doc.Pages.Add();

           mypro.DrawStrightLine(page1);
            mypro.DrawRectangle(page2);

            //Save pdf file.
            doc.SaveToFile("DrawShape233.pdf");
            doc.Close();

            //Launching the Pdf file.
            mypro.PDFDocumentViewer("DrawShape233.pdf");



        }


    }
}
