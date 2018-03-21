
import java.math.BigDecimal;
public class TestDemo2{
	
	
    private static void result1(){
        String Str = new String("www.   google.  com");

  
        System.out.println(Str.replaceAll("(.*)google(.*)", "runoob" ));

        System.out.println(Str.replaceAll("(.*)taobao(.*)", "runoob" ));
		System.out.println(Str.replace(" ", "%20" ));
        
    }
	public static void main(String args[]){
		

		 result1();
		 
		
	}
	
}