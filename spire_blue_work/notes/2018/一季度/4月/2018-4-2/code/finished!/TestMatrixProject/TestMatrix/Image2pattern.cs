using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMatrix
{
    class Image2pattern
    {
        public static Recatangle Test(){
        
                Recatangle target = new Recatangle(new Point(0, 0), 0, 0);
       
            target = Image2UserCoordinateSystem( target);



            return target;
        
        }
        public static Recatangle setCTMTransform(Recatangle origion, List<Matrix> ctms) {
            Recatangle target = new Recatangle(new Point(0, 0), 0, 0);
            // Image2Pattern(origion, ctms, target);
            //target = BBOX2CoordinateSystem(origion, ctms, target);//BBOX映射到用户坐标空间
          //  target=Image2UserCoordinateSystem(origion, ctms, target);//真正的图片一直映射到用户坐标空间。
            target = Image2UserCoordinateSystem( target);
         // target = Plot2UserCoordinateSystem(origion, ctms, target);


            return target;
        
        
        }


        #region BBOX2CoordinateSystem
        private static Recatangle BBOX2CoordinateSystem( Recatangle origion, List<Matrix> ctms, Recatangle target){
             Console.WriteLine("**********BBOX2CoordinateSystem************");
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
            

             ctm = ctms[0];
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

            /*
            //程序之间相互引用的问题，造成两个指针指向同一块内存地址
             Recatangle r1 = new Recatangle(new Point(0, 0), 0, 0);
             r1.P.X = BLX;
             r1.P.Y = BLY;
             r1.Width = BRX - BLX;
             r1.Height = BLY - BRY;
             */
             target = new Recatangle(new Point(0, 0), 0, 0);
             target.P.X = BLX;
             target.P.Y = BLY;
             target.Width = BRX - BLX;
             target.Height = BLY - BRY;
          
             return target;
        
        }

        #endregion


        #region Recatangle Image2patternSystem(Recatangle origion, List<Matrix> ctms, Recatangle target)
        private static Recatangle Image2patternSystem(Recatangle origion, List<Matrix> ctms, Recatangle target)
         {
             Console.WriteLine("**********Image2patternSystem************");
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


             ctm = ctms[0];
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

           
             #region clip operation
             /*
             中间截取一段执行Clip操作
             */

             Recatangle source = new Recatangle(new Point(points[0][0], points[0][1]), points[1][0] - points[0][0], points[0][1] - points[1][1]);
             target = new Recatangle(new Point(0, 0), 404.5725, 213.4275);
             bool canClipse = Rectangles.canClip(source, target);

             points[1][1] = -213.4275;
             
             //Clip操作执行完成
             #endregion
            canClipse = true;
            if (canClipse)
            {
                for (int i = 1; i < ctms.Count; i++)
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


        public static Recatangle Image2UserCoordinateSystem(Recatangle target)
        {
          
             List<Matrix> ctms=new List<Matrix>();
         
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
      


            Console.WriteLine("###########Image2PatternCoordinateSystem##############");
            //本类中调用,得到的ImageRect结果是没有映射到用户坐标空间中，只是映射到了Pattern坐标空间中

         Recatangle imageRect =Image2pattern.Image2patternSystem(rect_10, ctms,target);
        


            Console.WriteLine("###########ImageRect finished!!!##############");
            Recatangle BBOX = new Recatangle(new Point(-5, 5), 387.19, 257.785);
            List<Matrix> ctms1 = new List<Matrix>();
            ctms1.Add(new Matrix(new double[][]{
                    new double[]{4/3.0000,0,0},
                    new double[]{0 ,4/3.0000 ,0},
                    new double[]{0,792,1}
            
            }));
            Recatangle imageRect1=null;
            //在本类中调用
            imageRect1 = Image2pattern.BBOX2CoordinateSystem(imageRect, ctms1, target);
            Console.WriteLine("================"+imageRect1);
            Console.WriteLine("imageRect");
            Matrix.PrintMatrix(Matrix.ConvertRect2Arr(imageRect1));
            BBOX =Image2pattern.BBOX2CoordinateSystem(BBOX, ctms1,target);
            Console.WriteLine(BBOX);

            Console.WriteLine("###########BBOX finished!!!##############");


            Console.WriteLine("imageRect");
            Console.WriteLine("<<<<<<<<<<<<<<<<"+imageRect1);
            Matrix.PrintMatrix(Matrix.ConvertRect2Arr(imageRect1));


            Console.WriteLine("BBOX");
            Matrix.PrintMatrix(Matrix.ConvertRect2Arr(BBOX));


            Console.WriteLine("相交面积");
            Console.WriteLine(Rectangles.getSequare( BBOX,imageRect1));
            Console.WriteLine();


            return imageRect;
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



    }
}
