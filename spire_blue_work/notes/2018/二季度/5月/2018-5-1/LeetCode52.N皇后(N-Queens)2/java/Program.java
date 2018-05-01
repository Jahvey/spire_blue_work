import java.util.*;

import java.lang.*;
class Program
    {
        private static int count=0;
        public static int TotalNQueens(int n)
        {

     
           int []state=new int[n];
           helper(state,0);

            return count;

        }


     public static   void helper(int[] state, int row)
    {//放置第row行的皇后
        int n = state.length;
        if(row == n)
        {
            count++;
            return;
        }
        for(int col = 0; col < n; col++)
            if(isValid(state, row, col))
            {
                state[row] = col;
                helper(state, row+1);
                state[row] = -1;
            }
    }
     
    //判断在row行col列位置放一个皇后，是否是合法的状态
    //已经保证了每行一个皇后，只需要判断列是否合法以及对角线是否合法。
    public static boolean isValid(int[] state, int row, int col)
    {
        for(int i = 0; i < row; i++)//只需要判断row前面的行，因为后面的行还没有放置
            if(state[i] == col ||Math.abs(row - i) == Math.abs(col - state[i]))
                return false;
        return true;
    }

       public  static void main(String[] args)
        {
			int n=8;
            System.out.println(TotalNQueens(n));

            
        }
    }

