using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode25_reverse_nodes_in_k_group
{
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
            ListNode node = head;
            ListNode helper = new ListNode(0);//创建一个辅助的头结点；  
            helper.next = head;//当k> length of list时，返回原链表；  
            ListNode lastgroup = helper;//记录上一组结点的尾结点；  
            ListNode nextgroup = head;//辅助记录下一组结点的首结点；  
            ListNode first = nextgroup;//记录下一组结点的首结点； 
            int count = 1;
            while(node!=null){
                if (count < k)
                {

                    count += 1;
                    node = node.next;
                }
                else {
                    nextgroup = node.next;
                    lastgroup.next = reverse(first,node);
                    lastgroup = first;
                    first.next = nextgroup;
                    first = nextgroup;
                    node = first;
                    count = 1;
                
                }
            
            }

            return helper.next;

        }
        /// <summary>
        /// reverse the linkedList
        /// </summary>
        /// <param name="first">head</param>
        /// <param name="node">tail</param>
        /// <returns></returns>
        private ListNode reverse(ListNode first, ListNode node)
        {
         //   throw new NotImplementedException();

            ListNode pre = first;
            ListNode cur = first.next;
            ListNode ne = null;
            while(pre!=node){
                ne = cur.next;
                cur.next = pre;
                pre = cur;
                cur = ne;
            
            }
            first.next = null;
            first = pre;
            return first;


        }

        static void Main(string[] args)
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
                Console.Write("{0}  ",head.val);
                head = head.next;
            }
            Console.WriteLine();
            //  Console.WriteLine("aaa");
            Console.ReadKey();
        }
    }
}
