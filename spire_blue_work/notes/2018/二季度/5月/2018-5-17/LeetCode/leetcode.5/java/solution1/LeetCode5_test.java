import java.util.*;
import java.lang.*;

public class LeetCode5_test{
	public static  void bubbleSort(Integer []arr){
		
		boolean swap=true;
		do{
			swap=false;
			for(int i=0;i<arr.length-1;i++){
				
				if(arr[i]>arr[i+1]){
					
					//Integer temp=arr[i];
					//arr[i]=arr[i+1];
					//arr[i+1]=temp;
					Integer []haha={arr[i],arr[i+1]};
					swap2(haha);
					arr[i]=haha[0];
					arr[i+1]=haha[1];
					swap=true;
				}
				
			}
			
			
		}while(swap);
		
		
	}
	
	public static void swap1(Integer a,Integer b){
					Integer temp=a;
					a=b;
					b=temp;
	}
	public static void swap2(Integer[] a){
					Integer temp=a[0];
					a[0]=a[1];
					a[1]=temp;
	}
	
	public static void main(String []args){
		
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
		
		
		
		
		
	}
	
}