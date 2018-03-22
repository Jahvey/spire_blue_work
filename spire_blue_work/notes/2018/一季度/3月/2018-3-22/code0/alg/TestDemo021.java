import java.io.BufferedReader;  
import java.io.InputStreamReader;  
  
public class TestDemo021 {  
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
         sum = (Math.round(sum *100));
            if(sum%100==0) {  
                System.out.println(sum/100 + ".00"); 
            }  
            else if(sum%10==0) {  
                System.out.println(sum/100.0 + "0"); 
            }  
            else  
                System.out.println(sum/100.0);
        }  
}  