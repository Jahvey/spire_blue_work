using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace GDI绘图
{
    /// <summary>
    /// DrawDemo by PDF API
    /// </summary>
    public partial class PDFDrawDemo : Form
    {
        //save graphics state
        private static       PdfGraphicsState state;


        public PDFDrawDemo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// open the process by fileName
        /// </summary>
        /// <param name="fileName"></param>
        private void PDFDocumentViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }

        private void DrawCircleFunc(PdfPageBase page)
        {

             state = page.Canvas.Save();
            
            PdfPen pen = new PdfPen(Color.DeepSkyBlue, 3);//边框的厚度3
            PdfBrush brush1 = new PdfSolidBrush(Color.Red);//画刷，颜色为red

            page.Canvas.ScaleTransform(5f, 5f);//缩放操作
            page.Canvas.TranslateTransform(5f, 1.2f);//平移
            page.Canvas.DrawEllipse(pen,brush1,0,0,20,20);//drawCircle

            //restor graphics
            page.Canvas.Restore(state);
        }

        private void DrawLineFunc(PdfPageBase page)
        {
             state = page.Canvas.Save();

            //Draw Rectagle
            PdfPen pen = PdfPens.DeepSkyBlue;
            PdfBrush brush = new PdfSolidBrush(Color.Red);//画刷，颜色为red
             PdfPath path = new PdfPath();
             float offset = 50;
             PointF[] points = new PointF[] { new PointF(0, 0), new PointF(0, 80), new PointF(80, 80), new PointF(80, 0) };
             for (int i = 0; i < points.Length; i++)
             {
                 points[i].X += offset;
                 points[i].Y += offset;
                 
             }
             path.AddLine(points[0],points[1]);
             path.AddLine(points[1], points[2]);
             path.AddLine(points[2], points[3]);
             path.AddLine(points[3], points[0]);
            
            page.Canvas.DrawPath(pen, path);

            page.Canvas.TranslateTransform(280, 0);
            path.FillMode = PdfFillMode.Winding;
            page.Canvas.DrawPath(pen, brush, path);
            //drawing line
            PdfPath Linepath=new PdfPath();
            Linepath.AddLine(new PointF(70,270),new PointF(96,192));
            page.Canvas.DrawPath(pen,Linepath);

            //restor graphics
            page.Canvas.Restore(state);
        }




        private void drawCircle_Click(object sender, EventArgs e)
        {

            //Create a pdf document.
            PdfDocument doc = new PdfDocument();
            // Create one page
            PdfPageBase page = doc.Pages.Add();
            DrawCircleFunc(page);
            //Save pdf file.
            doc.SaveToFile("PDFDrawDemo.pdf");
            doc.Close();

            //Launching the Pdf file.
            PDFDocumentViewer("PDFDrawDemo.pdf");

        }

        private void drawLine_Click(object sender, EventArgs e)
        {
            //Create a pdf document.
            PdfDocument doc = new PdfDocument();

            // Create one page
            PdfPageBase page = doc.Pages.Add();

            DrawLineFunc(page);

           

            //Save pdf file.
            doc.SaveToFile("PDFDrawDemo.pdf");
            doc.Close();

            //Launching the Pdf file.
            PDFDocumentViewer("PDFDrawDemo.pdf");


        }
    }
}
