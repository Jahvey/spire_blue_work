using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calc_the_RectSquare
{
    class ConversionCoordinates
    {

        private static double[][]  commonTools(Recatangle origion, List<Matrix> ctms, int startIndex, int endIndex)
        {


            if (startIndex == 0) {
                String funName = (new StackTrace().GetFrame(1).GetMethod()).Name;
                Console.WriteLine("**********" + funName + "************");
            }
           
            
                double ALXO = origion.P.X;
                double ALYO = origion.P.Y;
                double ARXO = origion.P.X + origion.Width;
                double ARYO = origion.P.Y - origion.Height;
                if (startIndex == 0) {
                    Console.WriteLine("ALXO={0},ALYO={1},ARXO={2},ARYO={3}", ALXO, ALYO, ARXO, ARYO);
                }
                
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

                for (int i = startIndex; i <= endIndex; i++)
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
            
            


            return points;
        }

        #region Pattern2UserCoordinateSystem Pattern ->User coordinate System
        /// <summary>
        /// Pattern System ->User coordinate System
        /// </summary>
        /// <param name="origion">原始矩形区域</param>
        /// <param name="ctms">转换矩阵</param>
        /// <param name="target">返回的目标矩形</param>
        /// <returns></returns>
        private static Recatangle Pattern2UserCoordinateSystem(Recatangle origion, List<Matrix> ctms, Recatangle target)
        {

            double[][] points = new double[][] 
            {
                    new double[] { 0, 0, 1 },//左上角的点
                    new double[] { 0,0, 1 },//右下角的点
            };
            points=commonTools(origion, ctms, 0, 0);


            //将计算出来的矩形区域的主对角线的两点分别给相应的（BLX,BLY）(BRX,BRY)赋值，并输出结果矩形
            double BLX = points[0][0];
            double BLY = points[0][1];
            double BRX = points[1][0];
            double BRY = points[1][1];

            target = new Recatangle(new Point(0, 0), 0, 0);
            target.P.X = BLX;
            target.P.Y = BLY;
            target.Width = BRX - BLX;
            target.Height = BLY - BRY;

            return target;

        }

        #endregion


        #region Recatangle Image2patternSystem(Recatangle origion, List<Matrix> ctms, Recatangle target)
        /// <summary>
        /// Image  ->  patternSystem
        /// </summary>
        /// <param name="origion">原始矩形区域</param>
        /// <param name="ctms">转换矩阵</param>
        /// <param name="target">要返回的目标矩形区域</param>
        /// <returns></returns>
        private static Recatangle Image2patternSystem(Recatangle origion, List<Matrix> ctms, Recatangle target)
        {

            double[][] points = new double[][] 
            {
                    new double[] { 0, 0, 1 },//左上角的点
                    new double[] { 0,0, 1 },//右下角的点
            };
            points = commonTools(origion, ctms, 0, 0);


            #region clip operation
            /*
             中间截取一段执行Clip操作，截取可见区域
             */

            Recatangle source = new Recatangle(new Point(points[0][0], points[0][1]), points[1][0] - points[0][0], points[0][1] - points[1][1]);
            target = new Recatangle(new Point(0, 0), 404.5725, 213.4275);
            bool canClipse = commonUtils.canClip(source, target);//判断是否可以截取该区域

            points[1][1] = -213.4275;//更新可见区域
            canClipse = true;//放行
            //Clip操作执行完成
            #endregion
         
            if (canClipse)
            {

                points = commonTools(Matrix.ConvertArr2Rect(points), ctms, 1, ctms.Count - 1);

            }

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
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target">原矩形区域</param>
        /// <returns></returns>
        public static Recatangle Image2UserCoordinateSystem(Recatangle target)
        {

            List<Matrix> ctms = new List<Matrix>();

            Recatangle rect_10 = new Recatangle(new Point(0, 1), 1, 1);

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

            double[][] p21 = new double[][]{
                
                new double[]{ 1, 0,0 },
                new double[]{ 0,1,0 },
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
            Matrix m21 = new Matrix(p21);
            Matrix m3 = new Matrix(p3);
            Matrix m4 = new Matrix(p4);
            ctms.Add(m1);
            ctms.Add(m2);
            ctms.Add(m21);
            ctms.Add(m3);
            ctms.Add(m4);



            Console.WriteLine("###########Image2PatternCoordinateSystem##############");
            //本类中调用,得到的ImageRect结果是没有映射到用户坐标空间中，只是映射到了Pattern坐标空间中
            
            Recatangle imageRect = ConversionCoordinates.Image2patternSystem(rect_10, ctms, target);



            Console.WriteLine("###########Image Transform finished!!!##############");
            Recatangle BBOX = new Recatangle(new Point(-5, 5), 387.19, 257.785);
            List<Matrix> ctms1 = new List<Matrix>();
            ctms1.Add(new Matrix(new double[][]{
                    new double[]{4/3.0000,0,0},
                    new double[]{0 ,4/3.0000 ,0},
                    new double[]{0,792,1}
            
            }));
            Recatangle imageRect1 = null;
            //在本类中调用
            imageRect1 = ConversionCoordinates.Pattern2UserCoordinateSystem(imageRect, ctms1, target);
            Console.WriteLine("================" + imageRect1);
            Console.WriteLine("imageRect");
            Matrix.PrintMatrix(Matrix.ConvertRect2Arr(imageRect1));
            BBOX = ConversionCoordinates.Pattern2UserCoordinateSystem(BBOX, ctms1, target);
            Console.WriteLine(BBOX);

            Console.WriteLine("###########Pattern Transform finished!!!##############");


            Console.WriteLine("imageRect");
            Console.WriteLine("<<<<<<<<<<<<<<<<" + imageRect1);
            Matrix.PrintMatrix(Matrix.ConvertRect2Arr(imageRect1));


            Console.WriteLine("BBOX");
            Matrix.PrintMatrix(Matrix.ConvertRect2Arr(BBOX));


            Console.WriteLine("相交面积");
            Console.WriteLine(commonUtils.getSequare(BBOX, imageRect1));
            Console.WriteLine();


            return imageRect;
        }



        #region Plot2UserCoordinateSystem(Recatangle origion, List<Matrix> ctms, Recatangle target)
        /// <summary>
        /// this method contains the value of User坐标映射
        /// </summary>
        /// <param name="origion">原始矩形区域</param>
        /// <param name="ctms">转换的矩阵</param>
        /// <param name="target">需要返回的矩形区域</param>
        /// <returns></returns>
        private static Recatangle Plot2UserCoordinateSystem(Recatangle origion, List<Matrix> ctms, Recatangle target)
        {
           
            double[][] points = new double[][] 
            {
                    new double[] { 0, 0, 1 },//左上角的点
                    new double[] { 0,0, 1 },//右下角的点
            };
            points = commonTools(origion, ctms, 0, 1);


           


            #region clip operation
            /*
             中间截取一段执行Clip操作
             */
            Recatangle source = new Recatangle(new Point(points[0][0], points[0][1]), points[1][0] - points[0][0], points[0][1] - points[1][1]);
            target = new Recatangle(new Point(0, 0), 612, 792);
            bool canClipse = commonUtils.canClip(source, target);
            //有交集
         
            canClipse = true;



            //Clip操作执行完成
            #endregion


            points = commonTools(Matrix.ConvertArr2Rect(points), ctms, 2, 2);

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

        #endregion


    }
}
