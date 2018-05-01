import java.util.*;
import java.lang.*;


class Solution {
    private char[][] board;  
        private boolean[][] rows;  
        private boolean[][] cols;  
        private boolean[][] subBox;  
        public void solveSudoku(char[][] board) {  
            this.board=board;  
            this.rows=new boolean[9][9];//rows[i][j]第i行是否已经使用了值j+1  
            this.cols=new boolean[9][9];//cols[i][j]第i列是否已经使用了值j+1  
            this.subBox=new boolean[9][9];//subBox[i][j]第i个小九宫格是否已经使用了值j+1。九宫格按行来，每行从左往右,board[i][j]说属的小九宫格为(i/3)*3+j/3;(i/3)*3为基数(利用除,去尾数),j/3为相对偏移  
            //1.初始化标记  
            int val;  
            for(int i=0;i<9;i++){  
                for(int j=0;j<9;j++){  
                    if(board[i][j]!='.'){  
                        val=board[i][j]-'0';//notice  
                        rows[i][val-1]=true;  
                        cols[j][val-1]=true;  
                        subBox[(i/3)*3+j/3][val-1]=true;  
                    }  
                }  
            }  
            //2.从(0,0)位置开始填  
            fillSudoku(0, 0);  
        }  
        //填充数独,从(i,j)位置是否可以将数独填充完  
        private boolean fillSudoku(int i,int j){  
            if(i==9){//已经成功填完  
                return true;  
            }  
            //计算下一个位置  
            int x=i,y=j;  
            if(y==8){//要换行  
                x++;  
                y=0;  
            }else{  
                y++;  
            }  
            if(board[i][j]=='.'){//需要填充  
                for(int k=1;k<=9;k++){  
                    if(!rows[i][k-1] && !cols[j][k-1] && !subBox[(i/3)*3+j/3][k-1]){//k值可以使用  
                        rows[i][k-1]=true;  
                        cols[j][k-1]=true;  
                        subBox[(i/3)*3+j/3][k-1]=true;  
                        //递归  
                        if(fillSudoku(x, y)){//在(i,j)位置用k值可以填充完毕，则返回；否则回溯尝试下一个可选k值  
                            board[i][j]=(char)(k+'0');//别忘了  
                            return true;  
                        }  
                        //回溯  
                        rows[i][k-1]=false;  
                        cols[j][k-1]=false;  
                        subBox[(i/3)*3+j/3][k-1]=false;  
                    }  
                }  
                return false;  
            }else{//不需要填充  
                return fillSudoku(x, y);  
            }  
        } 
}