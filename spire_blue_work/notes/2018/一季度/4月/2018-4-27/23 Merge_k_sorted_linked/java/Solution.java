/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode(int x) { val = x; }
 * }
 */
class Solution {
    




       //������������������������ͷ���
        public static  ListNode mergeLinkList(ListNode head1, ListNode head2)
        {

            if (head1 == null && head2 == null)
            { //�����������Ϊ��
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

            ListNode head; //�������ͷ���
            ListNode current; //current���ָ�������� 
            // һ��ʼ��������current���ָ��head1��head2�н�С�����ݣ��õ�head���
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
                    current.next = head1; //�������У�currentָ�����һ������Ӧ��С���Ǹ�����
                    current = current.next; //currentָ������
                    head1 = head1.next;
                }
                else
                {
                    current.next = head2;
                    current = current.next;
                    head2 = head2.next;
                }
            }

            //�ϲ�ʣ���Ԫ��
            if (head1 != null)
            { //˵������2�������ˣ��ǿյ�
                current.next = head1;
            }

            if (head2 != null)
            { //˵������1�������ˣ��ǿյ�
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