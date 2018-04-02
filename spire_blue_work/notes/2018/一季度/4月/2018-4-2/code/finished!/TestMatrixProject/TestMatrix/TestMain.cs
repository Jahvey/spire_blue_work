using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMatrix
{
    class TestMain
    {
        static void Main(string[] args)
        {
            TestCase();
        }

        private static void TestCase()
        {

            Recatangle rec1 = new Recatangle(new Point(1, 1), 34, 44);
            Recatangle rec3 = new Recatangle(new Point(10, 10), new Point(13, 0));
            // Recatangle rec4 = new Recatangle(new Point(25, -5), 5, 5);
            
            Recatangle rec4 = new Recatangle(new Point(10.08, 10.11), 30, 30);
            // Recatangle rec2 = new Recatangle(new Point(1, 1), 6, 6);//测试两个矩形的包含情况
            // Recatangle rec2 = new Recatangle(new Point(10.08, 10.13), 11.22, 11.22);//测试两个矩形两条边重合的情况（左上角）结果正确

            Recatangle rec2 = new Recatangle(new Point(10.08, 4.1), 5.19, 5.19);//测试两个矩形两条边重合的情况（左下角）结果完全正确



         //   Image2PatternCoordinateSystem();

           // Plot2UserCoordinateSystem();
            Image2pattern.Test();
            Console.ReadKey();


        }

        private static void Plot2UserCoordinateSystem()
        {
            Console.WriteLine();
            Console.WriteLine("**********Plot2UserCoordinateSystem**************");
            Recatangle rect = new Recatangle(new Point(73.79926, -87.735), 303.39074, 160.05);
            List<Matrix> ctms = new List<Matrix>();
            double[][] p1 = new double[][]{
                new double[]{ 4/3.0000, 0,0 },
                new double[]{ 0, 4/3.0000,0 },
                new double[]{ 0, 0,1 }
            };
            double[][] p2 = new double[][]{
                new double[]{ 1, 0,0 },
                new double[]{ 0, 1,0 },
                new double[]{ 0, 0,1 }
            };
            double[][] p3 = new double[][]{
                new double[]{ 1, 0,0 },
                new double[]{ 0, 1,0 },
                new double[]{ 0, 792,1}
            };

        

            Matrix m1 = new Matrix(p1);
            Matrix m2 = new Matrix(p2);
            Matrix m3 = new Matrix(p3);

            ctms.Add(m1);
            ctms.Add(m2);
            ctms.Add(m3);

            //Console.WriteLine(PDF2User.setCTMTransform(rect_10, ctms));


            Console.WriteLine("#########################");
            Recatangle imageRect = Image2pattern.setCTMTransform(rect, ctms);


            Console.ReadKey();
        
        
        }


        private static void Image2PatternCoordinateSystem() { 
        
        
        
        }


        private static void Image2PatternCoordinateSystem1()
        {
            Console.WriteLine("==========================");
            Recatangle rect_10 = new Recatangle(new Point(0, 1), 1, 1);
            List<Matrix> ctms = new List<Matrix>();
            double[][] p1 = new double[][]{
                new double[]{ 404.5714, 0,0 },
                new double[]{ 0, 213.4286,0 },
                new double[]{ 0, -213.4286,1 }
            };
            double[][] p2 = new double[][]{
                new double[]{ 0.00185381, 0,0 },
                new double[]{ 0, 0.00351407,0 },
                new double[]{ 0, 0,1 }
            };
            double[][] p3 = new double[][]{
                new double[]{ 1, 0,0 },
                new double[]{ 0, 1,0 },
                new double[]{ 0, -257.785,1}
            };

            double[][] p4 = new double[][]{
                new double[]{ 1, 0,0 },
                new double[]{ 0, 1,0 },
                new double[]{ 0, 257.785,1}
            };

            Matrix m1 = new Matrix(p1);
            Matrix m2 = new Matrix(p2);
            Matrix m3 = new Matrix(p3);
            Matrix m4 = new Matrix(p4);
            ctms.Add(m1);
            ctms.Add(m2);
            ctms.Add(m3);
            ctms.Add(m4);
            //Console.WriteLine(PDF2User.setCTMTransform(rect_10, ctms));


            Console.WriteLine("###########Image2PatternCoordinateSystem##############");
            Recatangle imageRect = PDF2User.setCTMTransform(rect_10, ctms);
            Console.WriteLine("###########ImageRect finished!!!##############");
            Recatangle BBOX = new Recatangle(new Point(-5, 5), 387.19, 257.785);
            List<Matrix> ctms1 = new List<Matrix>();
            ctms1.Add(new Matrix(new double[][]{
                    new double[]{4/3.0000,0,0},
                    new double[]{0 ,4/3.0000 ,0},
                    new double[]{0,792,1}
            
            }));
            BBOX = PDF2User.setCTMTransform(BBOX, ctms);
            Console.WriteLine("###########BBOX finished!!!##############");


            Console.WriteLine("imageRect");
            Matrix.PrintMatrix(Matrix.ConvertRect2Arr(imageRect));


            Console.WriteLine("BBOX");
            Matrix.PrintMatrix(Matrix.ConvertRect2Arr(BBOX));



            Console.WriteLine("相交面积");
            Console.WriteLine(Rectangles.getSequare(imageRect, BBOX));
            Console.WriteLine();
            //Console.ReadKey();
        }
    }
}
