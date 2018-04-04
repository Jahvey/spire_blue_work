using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc_the_RectSquare
{
    class Matrix
    {


        private double[][] points = null;

        public double[][] Points
        {
            get { return points; }
            set { points = value; }
        }
        public Matrix(double[][] matrix)
        {
            this.points = matrix;
        }

        public static Recatangle ConvertArr2Rect(double[][] points) {

            Recatangle result = new Recatangle(new Point(points[0][0], points[0][1]),new Point(points[1][0], points[1][1]));
            return result;
        }

        public static double[][] ConvertRect2Arr(Recatangle rect) {
            double rlx = rect.P.X;
            double rly = rect.P.Y;
            double rrx = rect.P.X + rect.Width;
            double rry = rect.P.Y - rect.Height;
            double[][] result=new double[][]{
           

                new double[]{rlx,rly,1},
                new double[]{rrx,rry,1}
            
            };


            return result;
        
        }
        #region bool isMatrix(double[][] matrix)  判断一个二维数组是否为矩阵：如果每行的列数都相等则是矩阵，没有元素的二维数组是矩阵
        /// <summary>
        /// 判断一个二维数组是否为矩阵
        /// </summary>
        /// <param name="matrix">二维数组</param>
        /// <returns>true:是矩阵 false:不是矩阵</returns>
        public static bool isMatrix(double[][] matrix)
        {
            //空矩阵是矩阵
            if (matrix.Length < 1) return true;
            //不同行列数如果不相等，则不是矩阵
            int count = matrix[0].Length;
            for (int i = 1; i < matrix.Length; i++)
            {
                if (matrix[i].Length != count)
                {
                    return false;
                }
            }
            //各行列数相等，则是矩阵
            return true;
        }
        #endregion
        #region int[] MatrixCR(double[][] matrix)  计算一个矩阵的行数和列数：就是计算两个维度的Length属性
        /// <summary>
        /// 计算一个矩阵的行数和列数
        /// </summary>
        /// <param name="matrix">矩阵</param>
        /// <returns>数组：行数、列数</returns>
        public static int[] MatrixCR(double[][] matrix)
        {
            //接收到的参数不是矩阵则报异常
            if (!isMatrix(matrix))
            {
                throw new Exception("接收到的参数不是矩阵");
            }
            //空矩阵行数列数都为0
            if (!isMatrix(matrix) || matrix.Length == 0)
            {
                return new int[2] { 0, 0 };
            }
            return new int[2] { matrix.Length, matrix[0].Length };
        }

        #endregion

        #region  void PrintMatrix(double[][] matrix)  向控制台打印矩阵：注意，如果前后都是两个char类型的量，则运算符+会把前后两个字符转化为整数相加，而不会将前后字符视为字符串连接
        /// <summary>
        /// 打印矩阵
        /// </summary>
        /// <param name="matrix">待打印矩阵</param>
        public static void PrintMatrix(double[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + "\t");
                    //注意不能写为：Console.Write(matrix[i][j] + '\t');
                }
                Console.WriteLine();
            }
        }
        #endregion
        #region  double[][] MatrixAdd(double[][] matrix1, double[][] matrix2) 矩阵加法
        /// <summary>
        /// 矩阵加法
        /// </summary>
        /// <param name="matrix1">矩阵1</param>
        /// <param name="matrix2">矩阵2</param>
        /// <returns>和</returns>
        public static double[][] MatrixAdd(double[][] matrix1, double[][] matrix2)
        {
            //矩阵1和矩阵2须为同型矩阵
            if (MatrixCR(matrix1)[0] != MatrixCR(matrix2)[0] ||
             MatrixCR(matrix1)[1] != MatrixCR(matrix2)[1])
            {
                throw new Exception("不同型矩阵无法进行加法运算");
            }
            //生成一个与matrix1同型的空矩阵
            double[][] result = new double[matrix1.Length][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new double[matrix1[i].Length];
            }
            //矩阵加法：把矩阵2各元素值加到矩阵1上，返回矩阵1
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[i].Length; j++)
                {
                  result[i][j] =  Convert.ToDouble(decimal.Round(decimal.Parse((matrix1[i][j] + matrix2[i][j])+""),4));

                   //result[i][j] = matrix1[i][j] + matrix2[i][j];
                }
            }
            return result;
        }
        #endregion
        #region double[][] NegtMatrix(double[][] matrix) 矩阵取负
        /// <summary>
        /// 矩阵取负
        /// </summary>
        /// <param name="matrix">矩阵</param>
        /// <returns>负矩阵</returns>
        public static double[][] NegtMatrix(double[][] matrix)
        {
            //合法性检查
            if (!isMatrix(matrix))
            {
                throw new Exception("传入的参数并不是一个矩阵");
            }
            //参数为空矩阵则返回空矩阵
            if (matrix.Length == 0)
            {
                return new double[][] { };
            }
            //生成一个与matrix同型的空矩阵
            double[][] result = new double[matrix.Length][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new double[matrix[i].Length];
            }
            //矩阵取负：各元素取相反数
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[0].Length; j++)
                {
                    result[i][j] = -matrix[i][j];
                }
            }
            return result;
        }
        #endregion
        #region double[][] MatrixMult(double[][] matrix, double num) 矩阵数乘
        /// <summary>
        /// 矩阵数乘
        /// </summary>
        /// <param name="matrix">矩阵</param>
        /// <param name="num">常数</param>
        /// <returns>积</returns>
        public static double[][] MatrixMult(double[][] matrix, double num)
        {
            //合法性检查
            if (!isMatrix(matrix))
            {
                throw new Exception("传入的参数并不是一个矩阵");
            }
            //参数为空矩阵则返回空矩阵
            if (matrix.Length == 0)
            {
                return new double[][] { };
            }
            //生成一个与matrix同型的空矩阵
            double[][] result = new double[matrix.Length][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new double[matrix[i].Length];
            }
            //矩阵数乘：用常数依次乘以矩阵各元素
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[0].Length; j++)
                {
                    result[i][j] = matrix[i][j] * num;
                }
            }
            return result;
        }


        #endregion
        #region  double[][] MatrixMult(double[][] matrix1, double[][] matrix2) 矩阵乘法
        /// <summary>
        /// 矩阵乘法
        /// </summary>
        /// <param name="matrix1">矩阵1</param>
        /// <param name="matrix2">矩阵2</param>
        /// <returns>积</returns>
        public static double[][] MatrixMult(double[][] matrix1, double[][] matrix2)
        {
            //合法性检查
            if (MatrixCR(matrix1)[1] != MatrixCR(matrix2)[0])
            {
                throw new Exception("matrix1 的列数与 matrix2 的行数不相等");
            }
            //矩阵中没有元素的情况
            if (matrix1.Length == 0 || matrix2.Length == 0)
            {
                return new double[][] { };
            }
            //matrix1是m*n矩阵，matrix2是n*p矩阵，则result是m*p矩阵
            int m = matrix1.Length, n = matrix2.Length, p = matrix2[0].Length;
            double[][] result = new double[m][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new double[p];
            }
            //矩阵乘法：c[i,j]=Sigma(k=1→n,a[i,k]*b[k,j])
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    //对乘加法则
                    for (int k = 0; k < n; k++)
                    {
                        result[i][j] += Convert.ToDouble(decimal.Round(decimal.Parse("" + (matrix1[i][k] * matrix2[k][j])), 4));
                     // result[i][j] += (matrix1[i][k] * matrix2[k][j]);
                    }
                }
            }
            return result;
        }

        #endregion




    }
}
