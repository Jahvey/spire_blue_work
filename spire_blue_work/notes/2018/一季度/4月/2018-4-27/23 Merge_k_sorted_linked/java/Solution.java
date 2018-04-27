/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode(int x) { val = x; }
 * }
 */
class Solution {
    




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

       

        private static ListNode xMain( ListNode[] lists)
        {
            

            if (lists.length == 0) return null;
            int n = lists.length;
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


    public ListNode mergeKLists(ListNode[] arr) {
                //        if (arr.length == 1) return  arr[0];
        //    ListNode res = null;
        //    for (int i = 0; i < arr.length && i != arr.length - 1; i++)
        //    {

        //        res = mergeLinkList(arr[i], arr[i + 1]);
        //    }
        //return res;
        
        return xMain(arr);
        

        
    }
}