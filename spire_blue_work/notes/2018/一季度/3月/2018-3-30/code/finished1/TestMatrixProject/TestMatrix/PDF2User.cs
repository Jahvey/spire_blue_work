using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace TestMatrix 
{
    /// <summary>
    /// pdf坐标空间的转换
    /// </summary>
     class PDF2User
    {



       /// <summary>
       /// 
       /// </summary>
       /// <param name="origion"></param>
       /// <param name="ctms"></param>
       /// <returns></returns>
        public static Recatangle setCTMTransform(Recatangle origion ,List<Matrix> ctms) {

            Recatangle target = new Recatangle(new Point(0, 0), 0, 0);
           // Image2Pattern(origion, ctms, target);
            target = Plot2UserCoordinateSystem(origion, ctms, target);


            return target;
        
        }
         /// <summary>
         /// this method contains the value of User坐标映射
         /// </summary>
         /// <param name="origion"></param>
         /// <param name="ctms"></param>
         /// <param name="target"></param>
         /// <returns></returns>
        private static Recatangle Plot2UserCoordinateSystem(Recatangle origion, List<Matrix> ctms, Recatangle target)
        {
            double ALXO = origion.P.X;
            double ALYO = origion.P.Y;
            double ARXO = origion.P.X + origion.Width;
            double ARYO = origion.P.Y - origion.Height;
            Console.WriteLine("ALXO={0},ALYO={1},ARXO={2},ARYO={3}", ALXO, ALYO, ARXO, ARYO);
            double[][] points = new double[][] 
            {
                    new double[] { ALXO, ALYO, 1 },//左上角的点
                    new double[] { ARXO, ARYO, 1 },//右下角的点
            };

            double[][] results = new double[][] 
            {
                    new double[] { 0,0, 1 },//左上角的点
                    new double[] { 0, 0, 1 },//右下角的点
            };

            Matrix ctm = null;
            double[][] _ctm = null;
            for (int i = 0; i <= 1; i++)
            {
                //first invoke
                ctm = ctms[i];
                _ctm = ctm.Points;
                Console.WriteLine("origion matrix");
                Matrix.PrintMatrix(points);
                Console.WriteLine();
                Console.WriteLine("CTM matrix");
                Matrix.PrintMatrix(_ctm);
                Console.WriteLine();
                results = Matrix.MatrixMult(points, _ctm);
                Console.WriteLine("result matrix");
                Matrix.PrintMatrix(results);
                Console.WriteLine();
                Console.WriteLine("********************");
                points = results;//update the matrix

            }
            #region clip operation
            /*
             中间截取一段执行Clip操作
             */
            Recatangle source = new Recatangle(new Point(points[0][0], points[0][1]), points[1][0] - points[0][0], points[0][1] - points[1][1]);
            target = new Recatangle(new Point(0, 0), 612, 792);
            bool canClipse = Rectangles.canClip(source, target);
            //有交集
            // points[1][1] = -213.4275;
            canClipse = true;



            //Clip操作执行完成
            #endregion

            ctm = ctms[2];
            _ctm = ctm.Points;
            Console.WriteLine("origion matrix");
            Matrix.PrintMatrix(points);
            Console.WriteLine();
            Console.WriteLine("CTM matrix");
            Matrix.PrintMatrix(_ctm);
            Console.WriteLine();
            results = Matrix.MatrixMult(points, _ctm);
            Console.WriteLine("result matrix");
            Matrix.PrintMatrix(results);
            Console.WriteLine();
            Console.WriteLine("********************");
            points = results;//update the matrix

            //将计算出来的矩形区域的主对角线的两点分别给相应的（BLX,BLY）(BRX,BRY)赋值，并输出结果矩形
            double BLX = points[0][0];
            double BLY = points[0][1];
            double BRX = points[1][0];
            double BRY = points[1][1];
            target.P.X = BLX;
            target.P.Y = BLY;
            target.Width = BRX - BLX;
            target.Height = BLY - BRY;
            return target;
        }



         /// <summary>
         /// content stream to User coordiate system
         /// </summary>
         /// <param name="origion"></param>
         /// <param name="ctms"></param>
         /// <param name="target"></param>
        private static void Image2Pattern(Recatangle origion, List<Matrix> ctms, Recatangle target)
        {
            double[][] points = contentStream2Pattern(origion, ctms);
            double[][] ctm = new double[][] 
            {
                    new double[] { 4/3.0000,0, 0 },
                    new double[] { 0, 4/3.0000, 0 },
                    new double[] { 0, 792, 1 },
            };
            Matrix ctm2user = new Matrix(ctm);
            points = Pattern2User(points, ctm2user);
            //将计算出来的矩形区域的主对角线的两点分别给相应的（BLX,BLY）(BRX,BRY)赋值，并输出结果矩形
            double BLX = points[0][0];
            double BLY = points[0][1];
            double BRX = points[1][0];
            double BRY = points[1][1];
            target.P.X = BLX;
            target.P.Y = BLY;
            target.Width = BRX - BLX;
            target.Height = BLY - BRY;
          
        }

        #region  double[][] Pattern2User(double[][]points, Matrix ctms)
        private static double[][] Pattern2User(double[][]points, Matrix ctm)
        {
           
            double[][] _ctm = ctm.Points;
         

            Console.WriteLine("origion matrix");
            Matrix.PrintMatrix(points);
            Console.WriteLine();
            Console.WriteLine("CTM matrix");
            Matrix.PrintMatrix(_ctm);
            Console.WriteLine();
            points = Matrix.MatrixMult(points, _ctm);
            Console.WriteLine("result matrix");
            Matrix.PrintMatrix(points);
            Console.WriteLine();
            Console.WriteLine("######################");

            return points;

        }
        #endregion


        /// <summary>
         /// get the contentStream2Pattern co-system complete!!!
         /// </summary>
         /// <param name="origion"></param>
         /// <param name="ctms"></param>
         /// <returns></returns>
        private static double[][] contentStream2Pattern(Recatangle origion, List<Matrix> ctms)
        {
            double ALXO = origion.P.X;
            double ALYO = origion.P.Y;
            double ARXO = origion.P.X + origion.Width;
            double ARYO = origion.P.Y - origion.Height;
            Console.WriteLine("ALXO={0},ALYO={1},ARXO={2},ARYO={3}", ALXO, ALYO, ARXO, ARYO);
            double[][] points = new double[][] 
            {
                    new double[] { ALXO, ALYO, 1 },//左上角的点
                    new double[] { ARXO, ARYO, 1 },//右下角的点
            };
            //double[,]results= new double[2,3];
            double[][] results = new double[][] 
            {
                    new double[] { 0,0, 1 },//左上角的点
                    new double[] { 0, 0, 1 },//右下角的点
            };

            //first invoke
            Matrix ctm = ctms[0];
            double[][] _ctm = ctm.Points;
            Console.WriteLine("origion matrix");
            Matrix.PrintMatrix(points);
            Console.WriteLine();
            Console.WriteLine("CTM matrix");
            Matrix.PrintMatrix(_ctm);
            Console.WriteLine();
            results = Matrix.MatrixMult(points, _ctm);
            Console.WriteLine("result matrix");
            Matrix.PrintMatrix(results);
            Console.WriteLine();
            Console.WriteLine("********************");
            points = results;//update the matrix

            Recatangle source = new Recatangle(new Point(points[0][0], points[0][1]), points[1][0] - points[0][0], points[0][1] - points[1][1]);
            Recatangle target = new Recatangle(new Point(0,0),404.5725,213.4275);
            bool canClipse = Rectangles.canClip(source,target);
            //有交集
           // points[1][1] = -213.4275;
            canClipse = true;
            if (canClipse) {
                for (int i = 1; i < ctms.Count; i++)
                {
                    ctm = ctms[i];
                    _ctm = ctm.Points;
                    Console.WriteLine("origion matrix");
                    Matrix.PrintMatrix(points);
                    Console.WriteLine();
                    Console.WriteLine("CTM matrix");
                    Matrix.PrintMatrix(_ctm);
                    Console.WriteLine();
                    results = Matrix.MatrixMult(points, _ctm);
                    Console.WriteLine("result matrix");
                    Matrix.PrintMatrix(results);
                    Console.WriteLine();
                    Console.WriteLine("********************");
                    points = results;//update the matrix


                }
            
            }

           
            return points;
        }


    }
}
