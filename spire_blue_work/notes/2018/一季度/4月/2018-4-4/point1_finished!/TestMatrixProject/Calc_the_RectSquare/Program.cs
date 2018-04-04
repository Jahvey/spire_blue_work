using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Calc_the_RectSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            TestMatrix();
           // fun();
        }

        //public static  void fun() {
        //    TestMatrix();
        //}

        /// <summary>
        /// Test the matrix values.
        /// </summary>
        private static void TestMatrix()
        {
            Console.WriteLine("hello..........");
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);//获得当前方法名
            Console.WriteLine((new StackTrace().GetFrame(1).GetMethod()).Name);//获得调用当前方法的父方法名

            Recatangle target = new Recatangle(new Point(0, 0), 0, 0);

            target =ConversionCoordinates.Image2UserCoordinateSystem(target);
           Console.WriteLine(target);


            Console.ReadKey();
        }
    }
}
