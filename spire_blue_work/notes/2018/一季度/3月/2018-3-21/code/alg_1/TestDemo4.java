import java.util.Scanner;
import java.util.Arrays;
import java.util.HashSet;
import java.util.HashMap;

class Node{
    
    public int index;
    public int next;
    public Node(int index,int next){
        this.index=index;
        this.next=next;
    }
    public String  toString(){
        //System.out.println(index+":"+next);
        return index+":"+next;
        
    }
}
public class TestDemo4{
    private static Scanner sc=new Scanner(System.in);    
    public static void main(String []args){
        int n=sc.nextInt();
        //List<Node> list=new ArrayList();
        //HashMap<String,Integer> hash = new HashMap<String,Integer>();
		HashSet<String> hash = new HashSet<String>();
        while(sc.hasNext()){
                
            
           String []arr=sc.nextLine().split(" ");
           if(!arr[0].equals("")) hash.add(arr[0]);
            
        }
		
		//System.out.print(hash);//默认调用toString  
		//System.out.println("\n----------------------");
		
        //System.out.println("size:"+hash.size());
		//System.out.println("\n----------------------");
        if(hash.size()<n/2)
            System.out.println("size1:"+hash.size());
        else
             System.out.println(hash.size()+1);
        
        
        
    }
    
    
}