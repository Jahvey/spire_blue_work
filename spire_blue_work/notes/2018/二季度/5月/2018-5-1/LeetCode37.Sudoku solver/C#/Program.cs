using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solve_sudoku
{
    class Program
    {
        //#region old_method
        //public static bool isRowAndColValid(int x,int y,char[,]filed,int target) {
        //    for (int i = 0; i <9; i++)
        //    {
        //        if (filed[x, i] == target) return false;
        //    }
        //    for (int j = 0; j < 9; j++)
        //    {
        //        if (filed[j, y] == target) return false;   
        //    }
        //    return true;
        
        //}


        //public static bool isSequareValid(int x,int y,char[,]filed,int target) {

        //    int row=(x/3)*3;
        //    int col=(y/3)*3;
        //    for (int i = row; i < row+3; i++)
        //    {
        //        for (int j = col; j < col+3; j++)
        //        {
        //            if (filed[i, j].CompareTo((char)target) == 0) return false;
                    
        //        }
                
        //    }
        //    return true;
        //}


        //public static int[]getNextPoint(char[,]board){
        //    int[] res=new int[2];
        //    for (int i = 0; i <9; i++)
        //    {
        //        for (int j = 0; j <9; j++)
        //        {
        //            if (board[i, j].CompareTo('.') == 0)
        //                res[0] = i;
        //            res[1] = j;
        //            return res;
                    
        //        }
                
        //    }


        //    return res;
        
        //}

        //public static bool DFS(ref char[,]board) {
        //    int[]nextPoint = getNextPoint(board);
        //    if (nextPoint!=null) return true;
        //    for (int i = 1; i <10; i++)
        //    {
        //        if (isRowAndColValid(nextPoint[0], nextPoint[1], board, i) &&//
        //            isSequareValid(nextPoint[0], nextPoint[1], board, i)) {
        //                board[nextPoint[0], nextPoint[1]] = (char)i;
        //        }
        //        if (DFS(ref board)) return true;
        //        board[nextPoint[0], nextPoint[1]] = '.';
                
        //    }

        
        //    return false;
        //}
        //#endregion



        #region new _method to get sudoku

      //  private static char[,] board;
       private static  char[,] board = new char[9, 9] { 
        {'5','3','.','.','7','.','.','.','.'},{'6','.','.','1','9','5','.','.','.'},{'.','9','8','.','.','.','.','6','.'},{'8','.','.','.','6','.','.','.','3'},{'4','.','.','8','.','3','.','.','1'},{'7','.','.','.','2','.','.','.','6'},{'.','6','.','.','.','.','2','8','.'},{'.','.','.','4','1','9','.','.','5'},{'.','.','.','.','8','.','.','7','9'}
            };
        private static bool[,] rows;
        private static bool[,] cols;
        private static bool[,] subBox;
        public static char[,] SolveSudoku(char[,] board)
        {
         //   board = board;
            rows = new bool[9, 9];//rows[i,j]第i行是否已经使用了值j+1  
            cols = new bool[9, 9];//cols[i,j]第i列是否已经使用了值j+1  
            subBox = new bool[9, 9];//subBox[i,j]第i个小九宫格是否已经使用了值j+1。九宫格按行来，每行从左往右,board[i,j]说属的小九宫格为(i/3)*3+j/3;(i/3)*3为基数(利用除,去尾数),j/3为相对偏移  
            //1.初始化标记  
            int val;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i, j] != '.')
                    {
                        val = board[i, j] - '0';//notice  
                        rows[i, val - 1] = true;
                        cols[j, val - 1] = true;
                        subBox[(i / 3) * 3 + j / 3, val - 1] = true;
                    }
                }
            }
            //2.从(0,0)位置开始填  
            fillSudoku(0, 0);
            return board;
        }
        //填充数独,从(i,j)位置是否可以将数独填充完  
        private static bool fillSudoku(int i, int j)
        {
            if (i == 9)
            {//已经成功填完  
                return true;
            }
            //计算下一个位置  
            int x = i, y = j;
            if (y == 8)
            {//要换行  
                x++;
                y = 0;
            }
            else
            {
                y++;
            }
          if (board[i, j] == '.')
            {//需要填充  
                for (int k = 1; k <= 9; k++)
                {
                    if (!rows[i, k - 1] && !cols[j, k - 1] && !subBox[(i / 3) * 3 + j / 3, k - 1])
                    {//k值可以使用  
                        rows[i, k - 1] = true;
                        cols[j, k - 1] = true;
                        subBox[(i / 3) * 3 + j / 3, k - 1] = true;
                        //递归  
                        if (fillSudoku(x, y))
                        {//在(i,j)位置用k值可以填充完毕，则返回；否则回溯尝试下一个可选k值  
                            board[i, j] = (char)(k + '0');//别忘了  
                            return true;
                        }
                        //回溯  
                        rows[i, k - 1] = false;
                        cols[j, k - 1] = false;
                        subBox[(i / 3) * 3 + j / 3, k - 1] = false;
                    }
                }
                return false;
            }
            else
            {//不需要填充  
                return fillSudoku(x, y);
            }
        }  
        #endregion


        //public static char[,] SolveSudoku(char[,] board)
        //{

        // //   DFS(ref board);
        //    return board;
        //}

        /// <summary>
        /// show the data board
        /// </summary>
        /// <param name="board"></param>
        public static void showData(char[,] board)
        {
            int isChange = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    
                        if (isChange!=0& isChange % 3 == 0) Console.Write("{0} ", '|');
              
                        if (isChange++ % 9 == 0) { 
                            Console.WriteLine();
                           
                        }
                     
                        Console.Write("{0} ", board[i, j]);
                  
                    

                }


            }
            Console.WriteLine();

        }


        public static void showData1(char[,]board) {
            int isChange=0;
            for (int i = 0; i <9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (isChange ++% 9 == 0) Console.WriteLine();
                     Console.Write ("{0} ",board[i,j]);
                    
                }
               
                
            }
            Console.WriteLine();
        
        }
        static void Main(string[] args)
        {
          
            showData(board);
       
            showData(SolveSudoku(board));
            Console.ReadKey();
        }
    }
}
