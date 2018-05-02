import java.util.*;
import java.lang.*;

class Program1
 {

 
 
		public static void main(String []args){
			
			//System.out.println("aaaaa");
			System.out.println(isScramble("great","eatrg"));
            System.out.println(isScramble("abcde", "caebd"));
      
			
		}
		//http://www.blogjava.net/sandy/archive/2013/05/22/399605.html
		
		/**
		减少重复计算的方法就是动态规划。动态规划是一种神奇的算法技术，不亲自去写，是很难完全掌握动态规划的。

这里我使用了一个三维数组boolean result[len][len][len],其中第一维为子串的长度，第二维为s1的起始索引，第三维为s2的起始索引。
result[k][i][j]表示s1[i...i+k]是否可以由s2[j...j+k]变化得来。


		*/
        public static boolean isScramble(String s1, String s2)
        {
            //using dynamic programming
            int L1 = s1.length();
            int L2 = s2.length();
            if (L1 != L2) return false;
            if (L1 == 0) return true;

            char[] c1 = s1.toCharArray();
            char[] c2 = s2.toCharArray();
            
			int len=L1;
			boolean[][][] result = new boolean[len][len][len];
        for(int i=0;i<len;++i){
            for(int j=0;j<len;++j){
                result[0][i][j] = (c1[i]==c2[j]);
            }
        }
        
        for(int k=2;k<=len;++k){
            for(int i=len-k;i>=0;--i){
              for(int j=len-k;j>=0;--j){
                  boolean r = false;
                  for(int m=1;m<k && !r;++m){
                      r = (result[m-1][i][j] && result[k-m-1][i+m][j+m]) || (result[m-1][i][j+k-m] && result[k-m-1][i+m][j]);
                  }
                  result[k-1][i][j] = r;
              }
            }
        }
        
        return result[len-1][0][0];
			

        }


 }

