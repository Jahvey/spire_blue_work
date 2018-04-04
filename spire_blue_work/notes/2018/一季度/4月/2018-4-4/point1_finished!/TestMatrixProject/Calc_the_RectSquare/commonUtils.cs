using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc_the_RectSquare
{

    #region Point  （double x,double y）
    public class Point
    {

        double x;

        public double X
        {
            get { return x; }
            set { x = value; }
        }
        double y;

        public double Y
        {
            get { return y; }
            set { y = value; }
        }



        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {

            //return "This Point is:=["+this.x+","+this.y+"]";
            return "[" + this.x + "," + this.y + "]";
        }


    }
    #endregion


    #region Recatangle  (Point p, double width, double height)
    /// <summary>
    /// 定义了矩形类型
    /// </summary>
    public class Recatangle
    {
        double width;

        public double Width
        {
            get { return width; }
            set { width = value; }
        }
        double height;

        public double Height
        {
            get { return height; }
            set { height = value; }
        }
        Point p;

        public Point P
        {
            get { return p; }
            set { p = value; }
        }

        public Recatangle()
        {

        }
        /// <summary>
        /// Recatangle的构造函数
        /// </summary>
        /// <param name="p">左上角的点</param>
        /// <param name="width">矩形宽度</param>
        /// <param name="height">矩形高度</param>
        public Recatangle(Point p, double width, double height)
        {
            this.p = p;
            this.width = width;
            this.height = height;

        }
        /// <summary>
        /// 根据矩形中的对角线的两个点来确定这个矩形的形状
        /// </summary>
        /// <param name="LT">左上角的点</param>
        /// <param name="RE">右下角的点</param>
        public Recatangle(Point LT, Point RE)
        {
            if ((LT.X - RE.X) > 0 || (RE.Y - LT.Y) > 0)
            {
                Console.WriteLine("不存在这样的矩形，您输入的参数有误，请重新输入！");
                return;
            }
            double width = RE.X - LT.X;
            double height = LT.Y - RE.Y;


            this.p = LT;
            this.width = width;
            this.height = height;


        }


        public override String ToString()
        {
            return "Recatangle is:={p=" + this.p + ",width=" + this.width + " height=" + this.height + "}";
        }



    }
    #endregion



    #region commonUtils
    public class commonUtils
    {

        #region  isOverlap 判断两个轴对齐的矩形是否重叠
        /// <summary>
        /// 判断两个轴对齐的矩形是否重叠
        /// </summary>
        /// <param name="rc1">第1个矩阵的位置</param>
        /// <param name="rc2">第2个矩阵的位置</param>
        /// <returns>两个矩阵是否重叠（边沿重叠，也认为是重叠）</returns>  
        public static bool isOverlap(Recatangle rc1, Recatangle rc2)
        {
            if (rc1.P.X + rc1.Width > rc2.P.X &&
                rc2.P.X + rc2.Width > rc1.P.X &&
                rc1.P.Y + rc1.Height > rc2.P.Y &&
                rc2.P.Y + rc2.Height > rc1.P.Y
               )
                return true;//overlap
            else
                return false;//no overlap
        }
        #endregion
        public static bool isIdentical(Recatangle rc1, Recatangle rc2)
        {
            if (rc1.P.X == rc2.P.X &&
                rc2.P.Y == rc1.P.Y &&
                rc1.Height == rc2.Height &&
                rc2.Width == rc1.Width
               )
                return true;//isSame
            else
                return false;//no overlap
        }


        #region  getMin(double a, double b)
        /// <summary>
        /// getMin Value between double a and double b.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static double getMin(double a, double b)
        {

            return a < b ? a : b;

        }
        #endregion

        #region getMax(double a, double b)
        /// <summary>
        /// getMax Value between double a and double b.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static double getMax(double a, double b)
        {

            return a > b ? a : b;

        }
        #endregion

        #region  bool canClip(Recatangle source, Recatangle target) 此方法用来判断源矩形区域中是否包含目标矩形区域，即是否可以剪切
        /// <summary>
        /// 此方法用来判断源矩形区域中是否包含目标矩形区域，即是否可以剪切
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool canClip(Recatangle source, Recatangle target)
        {
            bool canClip = false;
            //首先判断两个矩形区域是否重合
            if (isOverlap(source, target) && isIdentical(source, target))//首先判断两个矩形是否完全重合
            {
                Console.WriteLine("两个图形完全重合了！！！可以剪切");
                canClip = true;
                return canClip;

            }
            //第1个矩形左上角的坐标
            double ALX = source.P.X;
            double ALY = source.P.Y;
            //第1个矩形右下角的坐标
            double ARX = ALX + source.Width;
            double ARY = ALY - source.Height;

            //第2个矩形左上角的坐标
            double BLX = target.P.X;
            double BLY = target.P.Y;
            //第2个矩形右下角的坐标
            double BRX = BLX + target.Width;
            double BRY = BLY - target.Height;

            double min1 = getMax(getMin(ALX, ARX), getMin(BLX, BRX));
            double min2 = getMax(getMin(ALY, ARY), getMin(BLY, BRY));
            double max1 = getMin(getMax(ALX, ARX), getMax(BLX, BRX));
            double max2 = getMin(getMax(ALY, ARY), getMax(BLY, BRY));
            Console.WriteLine("ALX={0},ALY={1},ARX={2},ARY={3}", ALX, ALY, ARX, ARY);
            Console.WriteLine("BLX={0},BLY={1},BRX={2},BRY={3}", BLX, BLY, BRX, BRY);
            Console.WriteLine("min1={0},min2={1},max1={2},max2={3}", min1, min2, max1, max2);
            Console.WriteLine("max1 - min1={0},max2 - min2={1},(max1 - min1) * (max2 - min2)={2}", max1 - min1, max2 - min2, (max1 - min1) * (max2 - min2));

            if (min1 < max1 && max2 > min2)
            {//说明两个矩形相交

                canClip = false;
                Console.WriteLine("两个矩形有交集！！！");
            }
            else
            {
                //说明这两个矩形有相互包含的情况
                if (source.Width * source.Height != target.Width * target.Height && (max1 - min1) * (max2 - min2) > 0) //说明recA包含recB
                {
                    canClip = true;
                    Console.WriteLine("两个矩形相互包含。");
                }
                else
                {
                    canClip = false;
                    Console.WriteLine("两个矩形相离");
                    Console.WriteLine("出现异常，请检查输入参数是否正确。");
                }

            }
            return canClip;

        }

        #endregion
        #region getSequare 计算两个相交矩形的重叠的面积
        /// <summary>
        /// return the two Recatangle's Sequare
        /// </summary>
        /// <param name="rectA"></param>
        /// <param name="rectB"></param>
        /// <returns></returns>
        public static double getSequare(Recatangle rectA, Recatangle rectB)
        {
            double result = 0.0;
            if (isOverlap(rectA, rectB) && isIdentical(rectA, rectB))//首先判断两个矩形是否完全重合
            {
                result = rectA.Width * rectA.Height;
                Console.WriteLine("两个图形完全重合了！！！两个矩形相交的面积是{0}", result);
                return result;

            }
            //第1个矩形左上角的坐标
            double ALX = rectA.P.X;
            double ALY = rectA.P.Y;
            //第1个矩形右下角的坐标
            double ARX = ALX + rectA.Width;
            double ARY = ALY - rectA.Height;

            //第2个矩形左上角的坐标
            double BLX = rectB.P.X;
            double BLY = rectB.P.Y;
            //第2个矩形右下角的坐标
            double BRX = BLX + rectB.Width;
            double BRY = BLY - rectB.Height;

            double min1 = Math.Max(Math.Min(ALX,ARX),Math.Min(BLX,BRX));
            double min2 = Math.Max(Math.Min(ALY, ARY), Math.Min(BLY, BRY));
            double max1 = Math.Min(Math.Max(ALX, ARX), Math.Max(BLX, BRX));
            double max2 = Math.Min(Math.Max(ALY, ARY), Math.Max(BLY, BRY));
  

            if (min1 < max1 && max2 > min2 )
            {
                Console.WriteLine("ALX={0},ALY={1},ARX={2},ARY={3}", ALX, ALY, ARX, ARY);
                Console.WriteLine("BLX={0},BLY={1},BRX={2},BRY={3}", BLX, BLY, BRX, BRY);
                Console.WriteLine("min1={0},min2={1},max1={2},max2={3}", min1, min2, max1, max2);
                Console.WriteLine("max1 - min1={0},max2 - min2={1},(max1 - min1) * (max2 - min2)={2}", max1 - min1, max2 - min2, (max1 - min1) * (max2 - min2));

                //结果保留2位小数
                result = Convert.ToDouble(decimal.Round(decimal.Parse("" + (max1 - min1) * (max2 - min2)), 2));


            }
            else
            {
                //在这个判断条件当中处理了有关两个矩形的包含的情况
                //说明这两个矩形有相互包含的情况
                if (rectA.Width * rectA.Height > rectB.Width * rectB.Height && (max1 - min1) * (max2 - min2) > 0) //说明recA包含recB
                    result = rectB.Height * rectB.Width;
                else if (rectA.Width * rectA.Height < rectB.Width * rectB.Height && (max1 - min1) * (max2 - min2) > 0)//说明rectB包含rectA
                    result = rectA.Height * rectA.Width;
                else
                {
                    Console.WriteLine("两个矩形相离！！！");
                    Console.WriteLine("Sorry,Somthings Wrong!!,Sequares=0.00");
                    result = 0.00;

                }



            }


            return result;


        }

        #endregion




    }

#endregion

}
