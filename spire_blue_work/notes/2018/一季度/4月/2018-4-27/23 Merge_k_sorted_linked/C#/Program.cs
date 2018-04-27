using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solution23_Merge_k_sorted_linked
{
    class Program
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }


        public static  void showData(ListNode head)
        {

            if (head == null) return ;
            ListNode current = head;
            while (current != null)
            {
                Console.Write("{0}  ", current .val);
                current = current.next;
            }

            Console.WriteLine();

        }
        public void showData1(ListNode[] lists) {
            //while (head.next!=null)
            //{
            //    Console.Write("{0}\t",head.val);
            //    head = head.next;
            //}
            for (int i = 0; i < lists.Length; i++)
            {
                Console.WriteLine(lists[i].val);
                
            }
        
        }

       //两个参数代表的是两个链表的头结点
        public static  ListNode mergeLinkList(ListNode head1, ListNode head2)
        {

            if (head1 == null && head2 == null)
            { //如果两个链表都为空
                return null;
            }
            if (head1 == null)
            {
                return head2;
            }
            if (head2 == null)
            {
                return head1;
            }

            ListNode head; //新链表的头结点
            ListNode current; //current结点指向新链表 
            // 一开始，我们让current结点指向head1和head2中较小的数据，得到head结点
            if (head1.val < head2.val)
            {
                head = head1;
                current = head1;
                head1 = head1.next;
            }
            else
            {
                head = head2;
                current = head2;
                head2 = head2.next;
            }

            while (head1 != null && head2 != null)
            {
                if (head1.val < head2.val)
                {
                    current.next = head1; //新链表中，current指针的下一个结点对应较小的那个数据
                    current = current.next; //current指针下移
                    head1 = head1.next;
                }
                else
                {
                    current.next = head2;
                    current = current.next;
                    head2 = head2.next;
                }
            }

            //合并剩余的元素
            if (head1 != null)
            { //说明链表2遍历完了，是空的
                current.next = head1;
            }

            if (head2 != null)
            { //说明链表1遍历完了，是空的
                current.next = head2;
            }

            return head;
        }

        static void Main(string[] args)
        {
            ListNode a = new ListNode(1);
            ListNode a1= new ListNode(4);
            ListNode a2 = new ListNode(5);
            a.next = a1;
            a1.next = a2;
            showData(a);

            ListNode b = new ListNode(1);
            ListNode b1 = new ListNode(3);
            ListNode b2 = new ListNode(4);
            b.next = b1;
            b1.next = b2;
            showData(b);

            ListNode c = new ListNode(2);
            ListNode c1 = new ListNode(6);
            c.next = c1;
            showData(c);

         //   method1(a, b, c);
            Console.WriteLine("=====two method!!!======");
            //ListNode res = xMain(new ListNode[] { new ListNode(1) });
            //showData(res);
            ListNode[]tmp={ a,b,c};
            
            ListNode res1 = xMain( tmp);
            showData(res1);


            //method1(a, b, c);

            Console.ReadKey();



        }

        private static ListNode xMain( ListNode[] lists)
        {
            

            if (lists.Length == 0) return null;
            int n = lists.Length;
            while (n > 1)
            {
                int k = (n + 1) / 2;
                for (int i = 0; i < n / 2; ++i)
                {
                    lists[i] = mergeLinkList(lists[i], lists[i + k]);
                }
                n = k;
            }
            return lists[0];

        }


        private static void method1(ListNode a, ListNode b, ListNode c)
        {
            //ListNode res = mergeLinkList(a, b);
            //res = mergeLinkList(res,c);
            //showData(res);
            ListNode[] arr = new ListNode[] { a, b, c };
            if (arr.Length == 1) arr[0] = arr[0];
            ListNode res = null;
            for (int i = 0; i < arr.Length && i != arr.Length - 1; i++)
            {

                res = mergeLinkList(arr[i], arr[i + 1]);
            }
            showData(res);
        }
    }
}
