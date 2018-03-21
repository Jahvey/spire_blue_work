
import java.math.BigDecimal;
public class demo2{
	
	private static int demo(String arr){
    if(arr.equals(""))return 0;
    String []temp=arr.split(" ");
    if(temp.length==1)return arr.length();
     else{
         String tmp=temp[temp.length-1];
         return tmp.length();

     }   
    
    
   }
	
	
	public static void main(String args[]){
		 //System.out.println(demo("hello world"));
		 System.out.println(demo(" XSUWHQ"));
		 
		
	}
	
}