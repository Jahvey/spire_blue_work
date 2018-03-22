import java.io.BufferedReader;  
import java.io.InputStreamReader;  
  
public class TestDemo022 {  
    public static void main(String[] args) throws Exception{  
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));  
        String inputStr = br.readLine();   
        String[] str = inputStr.split(" ");  
        int n = Integer.parseInt(str[0]);
        int m = Integer.parseInt(str[1]);
        double sum = 0;  
        double temp = n;  
        for(int i = 0; i < m; i++) {  
            sum += temp;  
            temp = Math.sqrt(temp);
          }  
         System.out.printf("%.02f",sum);
   }  
}  