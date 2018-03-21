
import java.math.BigDecimal;
public class TestDemo1{
	
	
    private static void result1(){
        String Str = new String("www.google.com");

       // System.out.print("匹配成功返回值 :" );
        System.out.println(Str.replaceAll("(.*)google(.*)", "runoob" ));
       // System.out.print("匹配失败返回值 :" );
        System.out.println(Str.replaceAll("(.*)taobao(.*)", "runoob" ));
        
    }
	public static void main(String args[]){
		

		 result1();
		 
		
	}
	
}