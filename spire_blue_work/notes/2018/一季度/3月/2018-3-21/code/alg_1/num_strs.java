import java.util.Arrays;
import java.util.Scanner;
public class num_strs{
    
	public static  boolean compareTo(String o1,String o2){
		
		if((o1+o2).compareTo(o2+o1)>0)return true;
		return false;
		
		
	}
	
	private static void getResult(String []arr){
		StringBuilder sb=new StringBuilder();
		String temp="";
		for(int i=0;i<arr.length;i++)
			for(int j=i+1;j<arr.length;j++){
				if (!compareTo(arr[j] ,arr[i])) {  
                        temp=arr[i];  
                        arr[i]=arr[j];  
                        arr[j]=temp;
                }						
				
			}
		
		
		
		for(String i:arr){
			sb.append(i);
			
			
		}
		System.out.println(sb.toString());
		
		
		
		
	}
	
	private static void showData(String []arr){
		for(String i:arr)
			System.out.println(i);
		
	}
	
    private static Scanner sc=new Scanner(System.in);
    public static void main(String args[]){
		//System.out.println("hello");
		
		
		int n=sc.nextInt();
		String []arr=new String[n];
		while(sc.hasNext()){
			//System.out.println(sc.next());
			arr[n-1]=sc.next();
			n--;
			
		}
		showData(arr);
		
		getResult(arr);
        
        
    }
    
}