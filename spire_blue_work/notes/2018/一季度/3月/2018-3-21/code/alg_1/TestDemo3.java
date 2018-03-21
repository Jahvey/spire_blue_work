import java.util.Arrays;
import java.util.Scanner;

import java.math.BigInteger; 


public class TestDemo3{
    
    private static Scanner sc=new Scanner(System.in);
	
	private static void Test1(){
		
		Scanner scan = new Scanner(System.in);  
  
       long  h = scan.nextLong();  
        long s = 0, e = h;  
  
        long result = 0;  
  
        BigInteger rh = BigInteger.valueOf(h);  
  
        while(s + 1< e) {  
  
        long mid = (s + e) / 2;  
  
        BigInteger r = BigInteger.valueOf(mid);  
  
        BigInteger r1 = BigInteger.valueOf(mid  
        + 1);  
  
        r = r.multiply(r1);  
  
        if(r.compareTo(rh) <= 0) {  
  
        s = mid;  
  
        result = mid;  
  
        } else{  
  
        e = mid;  
        }  
        }  
		
		System.out.println(result);  
        scan.close();  
		
	}
	public static void Test2(){
		
		Long h=sc.nextLong();
	   //String h=sc.next();
	   
        long  x=0;
		long count=0;
        while((x+x*x<=h)){
			long mid=(x+h)/2;
			x=mid;
			count++;
			//x++;
			
		}
        x-=count;
        System.out.println(x);
        
		
	}
    
    public static void main(String []args){
        
        Test1();
        
        
        
    }
    
}