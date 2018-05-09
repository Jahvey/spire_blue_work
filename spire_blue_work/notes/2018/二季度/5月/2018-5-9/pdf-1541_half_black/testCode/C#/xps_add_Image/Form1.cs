using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Xps.Packaging;
using System.Windows;
using System.IO;
using System.IO.Packaging;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using System.Windows.Media;



namespace WinFormDemo0101
{
    /// <summary>
    /// 需要的dll包，
    /// WindowsBase.dll  PresentationCore.dll   ReachFramework.dll  PresentationFramework.dll  
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 用于实现的功能，在xps中添加指定的图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string originalDocument = "";//读取模板
            string detinationDocument = AppDomain.CurrentDomain.BaseDirectory + "newXps.xps";//生成的新文件
            openFileDialog1.Filter = "图片文件(*.xps)|*.xps";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    originalDocument = openFileDialog1.FileName;
                    
                   // int png_x = Convert.ToInt32(txtX.Text.Trim());
                    //int png_y = Convert.ToInt32(txtY.Text.Trim());
                   
                    int png_x=0;
                    int png_y = 0;

                    if (File.Exists(detinationDocument))
                        File.Delete(detinationDocument);
                    using (Package package = Package.Open(originalDocument, FileMode.Open, FileAccess.Read))
                    {
                        using (Package packageDest = Package.Open(detinationDocument))
                        {
                            string inMemoryPackageName = "memorystream://miXps.xps";
                            Uri packageUri = new Uri(inMemoryPackageName);
                            PackageStore.RemovePackage(packageUri);
                            PackageStore.AddPackage(packageUri, package);
                           
                            XpsDocument xpsDocument = new XpsDocument(package, CompressionOption.Maximum, inMemoryPackageName);
                            XpsDocument xpsDocumentDest = new XpsDocument(packageDest, CompressionOption.Normal, detinationDocument);
                            var fixedDocumentSequence = xpsDocument.GetFixedDocumentSequence();
                            DocumentReference docReference = xpsDocument.GetFixedDocumentSequence().References.First();
                            FixedDocument doc = docReference.GetDocument(false);
                            PageContent content = doc.Pages[0];

                            FixedPage fixedPage = content.GetPageRoot(false);
                            //大容器
                            Canvas containCanvas = new Canvas();
                            containCanvas.Width = fixedPage.Width;
                            containCanvas.Height = fixedPage.Height;

                            
                            containCanvas.Background = Brushes.Transparent;
                            
                            xps_search_point p = new xps_search_point(0, 0, 11);
                            //xps缩放比例
                            double RenderTrans = 1;
                            //获得页面宽度和高度
                            string searchText = "姓名";

                            //循环xps字元素，查找指定内容
                            for (int i = 0; i < fixedPage.Children.Count; i++)
                            {
                                UIElement DocFpUiElem = fixedPage.Children[i];
                                if (DocFpUiElem is Glyphs)
                                {
                                    Glyphs gps = (Glyphs)DocFpUiElem;
                                    string strMark = gps.UnicodeString;
                                    //找到位置
                                    if (strMark.Trim() == searchText)
                                    {
                                        p = new xps_search_point(gps.OriginX, gps.OriginY, gps.FontRenderingEmSize);
                                        break;
                                    }
                                    textBox1.Text += strMark;
                                }
                                else if (DocFpUiElem is Canvas)
                                {
                                    Canvas cv1 = (Canvas)DocFpUiElem;
                                    //xps缩放比例
                                    RenderTrans = cv1.RenderTransform.Value.M11;
                                    p = GetGlyphs((Canvas)DocFpUiElem, searchText);
                                }
                            }




                           
                            Image img = new Image();
                            string fn = @"d:\1011.png";
                            img.Source = new BitmapImage(new Uri(fn));
                            Canvas cvs = new Canvas();
                            Canvas.SetLeft(cvs, Convert.ToDouble(png_x));
                            //Y坐标*缩放比例-图像本身高度
                            Canvas.SetTop(cvs, Convert.ToDouble(png_y));
                            img.Width = Convert.ToDouble(62);
                            img.Height = Convert.ToDouble(27);
                            //填入图片
                            cvs.Children.Add(img);
                            //将图片cvs 添加到大容器中
                            containCanvas.Children.Add(cvs);
                            //将大容器填充到 xps Page页面当中
                            fixedPage.Children.Add(containCanvas);
                            ((IAddChild)content).AddChild(fixedPage);
                            //创建写入流，输出保存文件
                            var writter = XpsDocument.CreateXpsDocumentWriter(xpsDocumentDest);
                            writter.Write(fixedPage);
                            
                            //释放
                            xpsDocumentDest.Close();
                            xpsDocument.Close();
                            System.Windows.Forms.MessageBox.Show("操作完成");
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// 递归，获取最子级 文字，查找大夫位置
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="searchText"></param>
        /// <returns></returns>
        private xps_search_point GetGlyphs(Canvas canvas, string searchText)
        {
            xps_search_point p = new xps_search_point(0, 0, 11);
            for (int i = 0; i < canvas.Children.Count; i++)
            {
                UIElement DocFpUiElem = canvas.Children[i];
                if (DocFpUiElem is Glyphs)
                {
                    Glyphs gps = (Glyphs)DocFpUiElem;
                    string strMark = gps.UnicodeString;   //找到位置
                    if (strMark.Trim() == searchText)
                    {
                        p = new xps_search_point(gps.OriginX, gps.OriginY, gps.FontRenderingEmSize);
                        break;
                    }
                    textBox1.Text += strMark;
                }
                else if (DocFpUiElem is Canvas)
                {
                    p = GetGlyphs((Canvas)DocFpUiElem, searchText);
                }
            }
            return p;
        }
        /// <summary>
        /// xps 搜索文字对象
        /// </summary>
        public class xps_search_point
        {
            public xps_search_point(double x, double y, double fontsize)
            {
                X = x;
                Y = y;
                FontSize = fontsize;

            }
            public double X { get; set; }
            public double Y { get; set; }
            public double FontSize { get; set; }
        }

    }
}
