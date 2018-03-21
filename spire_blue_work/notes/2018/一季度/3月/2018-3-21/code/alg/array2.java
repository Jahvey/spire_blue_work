
import java.math.BigDecimal;
public class array2{
	
	public static void ShowData(int[][]arr){
		int i=0,j=0;
		for(;i<arr.length;i++){
		for( ;j<arr[i].length;j++){
    
          System.out.print(arr[i][j]+"\t");
       }
	   System.out.println();
  
     }
		
	}
	
	//5,[[1,2,8,9],[2,4,9,12],[4,7,10,13],[6,8,11,15]]
	public static  boolean Find(int target, int [][] a) {
        
     int i,j=0;   
       for(i=0;i<a.length;i++){
       for( j=0;j<a[i].length;j++){
    
          if(target==a[i][j])break;
       }
  
     }
        
        
        if(i>0&&j>0)return true;
        
        return false;

    }
	
	
	
	
	public static void main(String args[]){
		int [][]a=new int[][]{{1,2,8,9},{2,4,9,12},{4,7,10,13},{6,8,11,15}};
		ShowData(a);
		System.out.println(Find(5,a));
		
/* 		int num=0;
		for(int i=0;i<10;++i)
		System.out.println("hello!"+num++); */
		
	}
	
}