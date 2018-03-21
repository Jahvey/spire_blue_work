import java.util.Scanner;
import java.util.Arrays;

import java.util.HashSet;
import java.util.HashMap;


class Node{
		//declare the children of left tree and right tree
		public Node left;
		public Node right;

		
		private int value;
		
		public  Node(int v){
			
			value=v;
		}
		
	}


public class TestDEMO5{
	
	
	//get the tree of function by desc
	private static int Height(Node root){
		
		if(root==null)return -1;
		Node leftValue=root.left;
		Node rightValue=root.right;
		
		int left=0,right=0;
		
		if(leftValue!=null)
			left=Height(leftValue);
		
		if(rightValue!=null)
			right=Height(rightValue);
		
		return ((left>=right)?left:right)+1;
		
		
		
		
	}
	
	private static void Test2(){
		int n=sc.nextInt();//the number of tree nodes
		int  rootvalue=sc.nextInt();//the first value of root
		int  leftvalue=sc.nextInt();//the left value of root.left
		Node root=new Node(rootvalue);//new root node
		Node fleft=new Node(leftvalue);//new the first left node of root.left node
		
		root.left=fleft;
		HashMap<Integer,Node> hash = new HashMap<>();
		
		hash.put(rootvalue,root);
		hash.put(leftvalue,fleft);
		//take care of the number of the first 2 node,so the circle number less 2 (lines).

		for(int i=0;i<n-2;++i){
			int parent=sc.nextInt();
			int child=sc.nextInt();
			
			Node parentval=hash.get(parent);
			Node childval=new Node(child);
			
			if(parentval==null){
				parentval=new Node(parent);
				parentval.left=childval;
				return;
				
			}else{
				
				if(parentval.left==null)parentval.left=childval;
				if(parentval.right==null)parentval.right=childval;
			
			}
				
			
			
			hash.put(parent,parentval);
			hash.put(child,childval);
			
			
			
			
		}
		System.out.println(Height(root));
		sc.close();
		
		
	}
	
	
	
	private static void Test1(){
		
		 int n=sc.nextInt();

		HashSet<String> hash = new HashSet<String>();
        while(sc.hasNext()){
                
            
           String []arr=sc.nextLine().split(" ");
           if(!arr[0].equals("")) hash.add(arr[0]);
            
        }

        if(hash.size()<n/2)
            System.out.println("size1:"+hash.size());
        else
             System.out.println(hash.size()+1);
		
	}
	
	
    private static Scanner sc=new Scanner(System.in);    
    public static void main(String []args){
       
        Test2();
        
        
    }
    
    
}