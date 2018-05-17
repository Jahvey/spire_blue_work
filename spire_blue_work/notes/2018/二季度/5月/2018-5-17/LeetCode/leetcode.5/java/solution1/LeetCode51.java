import java.util.*;
import java.lang.*;

public class LeetCode5{
	public static String longestPalindrome(String s) {
        int max_len=0;
        String res="";
        int ss=s.length();
        int i,j,k;
		//Object[]temp=new Object[3];
		Object[]temp={s,max_len,res};
        for(i=0;i<ss;i++){
            
            
            //findRes( s,i-1,i+1, max_len, res);
			findRes( temp[0]+"",i-1,i+1, (int)temp[1], temp[2]+"");
			s=temp[0]+"";
			max_len=(int)temp[1];
			res=temp[2]+"";
        }
        
        for(i=0;i+1<ss;i++){
            
           // findRes( s,i,i+1, max_len, res);
		   findRes( temp[0]+"",i,i+1, (int)temp[1], temp[2]+"");
		   s=temp[0]+"";
			max_len=(int)temp[1];
			res=temp[2]+"";
            
        }
        return res;
    }
    
       static void findRes( String  s,int j,int k,int  max_len, String  res){
        
        
        int ss=s.length();
        while(j>=0&&k<=ss-1&&s.charAt(j)==s.charAt(k)){
            --j;
            ++k;
            
        }
        
        if(k-j-1 >max_len){
            
            
            max_len=k-j-1;
            res=s.substring(j+1,k);
        }
        
        
    }
	
	public static void main(String []args){
		/**
		//System.out.println("hello world!");
		Integer[] arr={12,1,-3,11,10 ,7,9,99,1101,-20};
		for(Integer i:arr){
			System.out.print(i+" ");
			
		}
		System.out.println();
		bubbleSort(arr);
		for(Integer i:arr){
			System.out.print(i+" ");
			
		}
		System.out.println();
		**/
		
		System.out.println(longestPalindrome("babad"));
		
		
		
		
		
	}
	
}