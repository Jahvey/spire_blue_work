import java.util.*;
import java.lang.*;

    class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }

    class Program
    {

        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null || head.next == null || k <= 1)
            {
                return head;
            }
             ListNode current = head;  
             ListNode next = null;  
			ListNode prev = null;  
			int count = 0;  
			/*reverse first k nodes of the linked list */  
			while(current!=null&&count<k){
				next=current.next;
				current.next=prev;
				//update the prev current next relationship
				prev=current;
				current=next;
				count+=1;
				
			}
			/* next is now a pointer to (k+1)th node 
       Recursively call for the list starting from current. 
       And make rest of the list as next of first node */ 
			if(next!=null){
				
				head.next=ReverseKGroup(next,k);
				
			}
			/* prev is new head of the input list */  
            return prev;

        }


       public  static void main(String[] args)
        {

            Program s = new Program();

            ListNode n1 = new ListNode(1);
            ListNode n2 = new ListNode(2);
            ListNode n3 = new ListNode(3);
            ListNode n4 = new ListNode(4);
            ListNode n5 = new ListNode(5);

            n1.next = n2;
            n2.next = n3;
            n3.next = n4;
            n4.next = n5;

            //ListNode head = s.ReverseInGroups(n1, 2);  
            ListNode head = s.ReverseKGroup(n1, 2);
            while (head != null)
            {
                System.out.printf("%d  ",head.val);
                head = head.next;
            }
           System.out.println();
        }

	}