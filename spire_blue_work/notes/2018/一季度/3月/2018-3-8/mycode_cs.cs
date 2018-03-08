using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Spire.Pdf;
using Spire.Pdf.Graphics;



namespace ConsoleApplication1
{
    class Program
    {



        private void DrawStrightLine(PdfPageBase page)
        {

            PointF[] points = new PointF[4];
            //clear the watermark
            int downRate = 1;
            int leftRate = 2;
            points[0] = new PointF(-1-leftRate, -1+downRate);
            points[1] = new PointF(-1-leftRate, 1+downRate);
            points[2] = new PointF(1-leftRate, 1+downRate);
            points[3] = new PointF(1-leftRate, -1+downRate);

            PdfPath path = new PdfPath();
            path.AddLine(points[0], points[1]);
            path.AddLine(points[1], points[2]);
            path.AddLine(points[2], points[3]);
            path.AddLine(points[3], points[0]);

            //save graphics state
            //PdfGraphicsState state = page.Canvas.Save();
            PdfPen pen = new PdfPen(Color.DeepSkyBlue, 0.02f);
    
            page.Canvas.ScaleTransform(105f, 105f);
            page.Canvas.TranslateTransform(5f, 1.2f);
            page.Canvas.DrawPath(pen, path);

            //drawing a stright line
            PdfPath path2 = new PdfPath();
            path2.AddLine(new PointF(-4.5f, 0), new PointF(-3f, 3.53f));
            PdfPen pen2 = new PdfPen(Color.Red,0.046f);
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

            Program mypro = new Program();

            //Create a pdf document.
            PdfDocument doc = new PdfDocument();

            // Create one page
            PdfPageBase page = doc.Pages.Add();

            //mypro.DrawSpiro(page);
            //mypro. DrawPath(page);
            mypro.DrawStrightLine(page);

            //Save pdf file.
            doc.SaveToFile("DrawShape11111.pdf");
            doc.Close();

            //Launching the Pdf file.
            mypro.PDFDocumentViewer("DrawShape11111.pdf");



        }


    }
}
