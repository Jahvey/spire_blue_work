import java.util.Scanner;
import java.util.Arrays;

import java.util.HashSet;
import java.util.HashMap;
import java.util.*;
import java.io.*;




public class TestDemo01{
	

	
	private static void Test1(){

		 String []arr=sc.nextLine().split(" ");
        int n=arr.length;
		/**
        String[]temp=new String[n];
        int j=0;
        for(int i=n-1;i>=0;i--){
            temp[j++]=arr[i];
    
        }
		*/
        //Arrays.sort(arr,Collections.reverseOrder());     
        StringBuffer sb=new StringBuffer();
        
	    while(n-->1){
			sb.append(arr[n]+" ");
		}
		sb.append(arr[0]);
	 
        System.out.println(sb.toString());
		
	}
	
	
    private static Scanner sc=new Scanner(System.in);    
    public static void main(String []args){
       
        Test1();
        
        
    }
    
    
}