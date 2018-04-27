using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solution2_addtwoNum
{
    class Program
    {

        public class ListNode
        {
       
            public ListNode next;
            public int p;
    

            public ListNode(int p)
            {
               
                this.p = p;
            }
        }
        public  static ListNode addTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode(0);
            ListNode head = result;

            int sum = 0;
            while (l1 != null || l2 != null)
            {
                sum /= 10;

                if (l1 != null)
                {
                    sum += l1.p;
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    sum += l2.p;
                    l2 = l2.next;
                }

                head.next = new ListNode(sum % 10);
                head = head.next;
            }

            if (sum / 10 == 1)
            {
                head.next = new ListNode(1);
            }

            return result.next;


        }
        static void Main(string[] args)
        {
            ListNode node1 = new ListNode(2);
            ListNode node11 = new ListNode(4);
            ListNode node111 = new ListNode(3);
            node1.next = node11;
            node11.next = node111;

            ListNode node2 = new ListNode(5);
            ListNode node22 = new ListNode(6);
            ListNode node222 = new ListNode(4);
            node2.next = node22;
            node22.next = node222;

            ListNode res = addTwoNumbers(node1,node2);
            Console.WriteLine(res.p);

            Console.ReadKey();





        }
    }
}
