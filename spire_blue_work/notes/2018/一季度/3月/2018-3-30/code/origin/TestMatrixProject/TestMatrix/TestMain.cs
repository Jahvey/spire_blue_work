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


            /**

            Console.WriteLine(rec1);
            Console.WriteLine(rec3);
            Console.WriteLine(Rectangles.isOverlap(rec1,rec3));
           // Console.WriteLine(decimal.Round(decimal.Parse("0.3333333"), 2));
            Console.WriteLine(Rectangles.getSequare(rec1,rec3));
          

            
            Console.WriteLine(Rectangles.getSequare(rec2, rec4));
            Console.WriteLine("================================");
            Console.WriteLine("矩阵部分");
            //示例矩阵
            double[][] matrix1 = new double[][] 
 {
  new double[] { 1, 2, 3 },
  new double[] { 4, 5, 6 },
  new double[] { 7, 8, 9 }
 };
            double[][] matrix2 = new double[][] 
 {
  new double[] { 2, 3, 4 },
  new double[] { 5, 6, 7 },
  new double[] { 8, 9, 10 }
 };

            //矩阵加法
            Matrix.PrintMatrix(Matrix.MatrixAdd(matrix1, matrix2));
            Console.WriteLine();
            //矩阵取负
            Matrix.PrintMatrix(Matrix.NegtMatrix(matrix1));
            Console.WriteLine();
            //矩阵数乘
            Matrix.PrintMatrix(Matrix.MatrixMult(matrix1, 3));
            Console.WriteLine();
            //矩阵乘法
            Matrix.PrintMatrix(Matrix.MatrixMult(
             new double[][] {
   new double[]{ 4, -1, 2 },
   new double[]{ 1, 1, 0 },
   new double[]{ 0, 3, 1 }},
             new double[][] {
   new double[]{ 1, 2 },
   new double[]{ 0, 1 },
   new double[]{ 3, 0 }}));

            Matrix.PrintMatrix(Matrix.MatrixMult(//成功
             new double[][] {
                new double[]{ 0.10, 0.30, 0.15 },
                new double[]{ 0.30, 0.40, 0.25 },
                new double[]{ 0.10, 0.20, 0.15 }},
             new double[][] {
                 new double[]{ 4000, 4500,4500,4000 },
                new double[]{ 2000,2800,2400,2200},
                 new double[]{ 5800,6200,6000,6000}}));

            Console.WriteLine();

            Matrix.PrintMatrix(Matrix.MatrixMult(//成功
             new double[][] {
                new double[]{ 0.10, 0.30, 0.15 },
                new double[]{ 0.30, 0.40, 0.25 },
                new double[]{ 0.10, 0.20, 0.15 }},
             new double[][] {
                 new double[]{ 4000, 4500,4500,4000 },
                new double[]{ 2000,2800,2400,2200},
                 new double[]{ 5800,6200,6000,6000}}));
             * 
             * 
             *   **/

            Image2PatternCoordinateSystem();

            Plot2UserCoordinateSystem();


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
            Recatangle imageRect = PDF2User.setCTMTransform(rect, ctms);


            Console.ReadKey();
        
        
        }


        private static void Image2PatternCoordinateSystem()
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
