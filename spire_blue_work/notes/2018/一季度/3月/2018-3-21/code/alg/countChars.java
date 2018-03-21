
import java.math.BigDecimal;
public class countChars{
	
	
    private static int result(String str,char c){
        //String tmp=null;
        int count=0;
        char []cs=str.toCharArray();
         for (int i = 0; i < cs.length; i++) {
            if (c == cs[i]) {
                count++;
            }
         }
        return count;
        
    }
	public static void main(String args[]){
		
		 System.out.println(result("ABCaD",'a'));
		 
		
	}
	
}