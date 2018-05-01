import java.util.*;
import java.lang.*;


class Solution {
    private char[][] board;  
        private boolean[][] rows;  
        private boolean[][] cols;  
        private boolean[][] subBox;  
        public void solveSudoku(char[][] board) {  
            this.board=board;  
            this.rows=new boolean[9][9];//rows[i][j]��i���Ƿ��Ѿ�ʹ����ֵj+1  
            this.cols=new boolean[9][9];//cols[i][j]��i���Ƿ��Ѿ�ʹ����ֵj+1  
            this.subBox=new boolean[9][9];//subBox[i][j]��i��С�Ź����Ƿ��Ѿ�ʹ����ֵj+1���Ź���������ÿ�д�������,board[i][j]˵����С�Ź���Ϊ(i/3)*3+j/3;(i/3)*3Ϊ����(���ó�,ȥβ��),j/3Ϊ���ƫ��  
            //1.��ʼ�����  
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
            //2.��(0,0)λ�ÿ�ʼ��  
            fillSudoku(0, 0);  
        }  
        //�������,��(i,j)λ���Ƿ���Խ����������  
        private boolean fillSudoku(int i,int j){  
            if(i==9){//�Ѿ��ɹ�����  
                return true;  
            }  
            //������һ��λ��  
            int x=i,y=j;  
            if(y==8){//Ҫ����  
                x++;  
                y=0;  
            }else{  
                y++;  
            }  
            if(board[i][j]=='.'){//��Ҫ���  
                for(int k=1;k<=9;k++){  
                    if(!rows[i][k-1] && !cols[j][k-1] && !subBox[(i/3)*3+j/3][k-1]){//kֵ����ʹ��  
                        rows[i][k-1]=true;  
                        cols[j][k-1]=true;  
                        subBox[(i/3)*3+j/3][k-1]=true;  
                        //�ݹ�  
                        if(fillSudoku(x, y)){//��(i,j)λ����kֵ���������ϣ��򷵻أ�������ݳ�����һ����ѡkֵ  
                            board[i][j]=(char)(k+'0');//������  
                            return true;  
                        }  
                        //����  
                        rows[i][k-1]=false;  
                        cols[j][k-1]=false;  
                        subBox[(i/3)*3+j/3][k-1]=false;  
                    }  
                }  
                return false;  
            }else{//����Ҫ���  
                return fillSudoku(x, y);  
            }  
        } 
}