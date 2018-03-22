import java.io.BufferedReader;  
import java.io.InputStreamReader;  
  
public class TestDemo02 {  
    public static void main(String[] args) throws Exception{  
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));  
        String inputStr = br.readLine();   
        String[] str = inputStr.split(" ");  
        int n = Integer.parseInt(str[0]);//数列的第一项为n  
        int m = Integer.parseInt(str[1]);//指定前m项  
        double sum = 0;  
        double temp = n;  
        for(int i = 0; i < m; i++) {  
            sum += temp;  
            temp = Math.sqrt(temp);//求出每一项的值；  
          }  
         sum = (Math.round(sum *100));//四舍五入，然后取整，确保精度保留2位小数  
            if(sum%100==0) {  
                System.out.println(sum/100 + ".00"); //如2*100=200,变为2.00  
            }  
            else if(sum%10==0) {  
                System.out.println(sum/100.0 + "0"); //如1.5*100=150.变为1.50  
            }  
            else  
                System.out.println(sum/100.0);//如3.25*100=325,变为3.25  
        }  
}  