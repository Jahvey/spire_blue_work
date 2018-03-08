using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System.Drawing;

namespace ConsoleApplication1
{
    class Program
    {

        private void DrawStrightLine(PdfPageBase page) {

            PointF[] points = new PointF[4];
       
            points[0] = new PointF(-1,-1);
            points[1] = new PointF(-1, 1);
            points[2] = new PointF(1, 1);
            points[3] = new PointF(1, -1);
            
            PdfPath path = new PdfPath();
            path.AddLine(points[0], points[1]);
            path.AddLine(points[1], points[2]);
            path.AddLine(points[2], points[3]);
            path.AddLine(points[3], points[0]);
           

            //save graphics state
            PdfGraphicsState state = page.Canvas.Save();
            PdfPen pen = new PdfPen(Color.DeepSkyBlue, 0.02f);
           // PdfBrush brush1 = new PdfSolidBrush(Color.CadetBlue);

            page.Canvas.ScaleTransform(80f, 80f);
            page.Canvas.TranslateTransform(5f, 1.2f);
            page.Canvas.DrawPath(pen, path);

            PdfPath path2 = new PdfPath();
            path2.AddLine(new PointF(-3,0),new PointF(-3,3));
            page.Canvas.DrawPath(pen, path2);



 
        
        
        
        
        }



        private void DrawPath(PdfPageBase page)
        {
            PointF[] points = new PointF[5];
            for (int i = 0; i < points.Length; i++)
            {
                float x = (float)Math.Cos(i * 2 * Math.PI / 5);
                float y = (float)Math.Sin(i * 2 * Math.PI / 5);
                points[i] = new PointF(x, y);
            }
            PdfPath path = new PdfPath();
            path.AddLine(points[2], points[0]);
            path.AddLine(points[0], points[3]);
            path.AddLine(points[3], points[1]);
            path.AddLine(points[1], points[4]);
            path.AddLine(points[4], points[2]);

            //save graphics state
            PdfGraphicsState state = page.Canvas.Save();
            PdfPen pen = new PdfPen(Color.DeepSkyBlue, 0.02f);
            PdfBrush brush1 = new PdfSolidBrush(Color.CadetBlue);

            page.Canvas.ScaleTransform(50f, 50f);
            page.Canvas.TranslateTransform(5f, 1.2f);
            page.Canvas.DrawPath(pen, path);

            page.Canvas.TranslateTransform(2f, 0f);
            path.FillMode = PdfFillMode.Alternate;
            page.Canvas.DrawPath(pen, brush1, path);

            page.Canvas.TranslateTransform(2f, 0f);
            path.FillMode = PdfFillMode.Winding;
            page.Canvas.DrawPath(pen, brush1, path);

            PdfLinearGradientBrush brush2 = new PdfLinearGradientBrush(new PointF(-2, 0), new PointF(2, 0), Color.Red, Color.Blue);
            page.Canvas.TranslateTransform(-4f, 2f);
            path.FillMode = PdfFillMode.Alternate;
            page.Canvas.DrawPath(pen, brush2, path);

            PdfRadialGradientBrush brush3 = new PdfRadialGradientBrush(new PointF(0f, 0f), 0f, new PointF(0f, 0f), 1f, Color.Red, Color.Blue);
            page.Canvas.TranslateTransform(2f, 0f);
            path.FillMode = PdfFillMode.Winding;
            page.Canvas.DrawPath(pen, brush3, path);

            PdfTilingBrush brush4 = new PdfTilingBrush(new RectangleF(0, 0, 4f, 4f));
            brush4.Graphics.DrawRectangle(brush2, 0, 0, 4f, 4f);

            page.Canvas.TranslateTransform(2f, 0f);
            path.FillMode = PdfFillMode.Winding;
            page.Canvas.DrawPath(pen, brush4, path);

            //restor graphics
            page.Canvas.Restore(state);
        }

        private void DrawSpiro(PdfPageBase page)
        {
            //save graphics state
            PdfGraphicsState state = page.Canvas.Save();

            //Draw shap - spiro
            PdfPen pen = PdfPens.DeepSkyBlue;

            int nPoints = 1000;
            double r1 = 30;
            double r2 = 25;
            double p = 35;
            double x1 = r1 + r2 - p;
            double y1 = 0;
            double x2 = 0;
            double y2 = 0;

            page.Canvas.TranslateTransform(100, 100);

            for (int i = 0; i < nPoints; i++)
            {
                double t = i * Math.PI / 90;
                x2 = (r1 + r2) * Math.Cos(t) - p * Math.Cos((r1 + r2) * t / r2);
                y2 = (r1 + r2) * Math.Sin(t) - p * Math.Sin((r1 + r2) * t / r2);
                page.Canvas.DrawLine(pen, (float)x1, (float)y1, (float)x2, (float)y2);
                x1 = x2;
                y1 = y2;
            }

            //restor graphics
            page.Canvas.Restore(state);
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
