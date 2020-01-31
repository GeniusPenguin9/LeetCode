using System;

namespace T148_Middle_Sort_LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var node_1 = new ListNode(-1);
            var node5 = new ListNode(5);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            var node0 = new ListNode(0);
            node_1.next = node5;
            node5.next = node3;
            node3.next = node4;
            node4.next = node0;
            var res = SortList(node_1);
        }
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
        public static ListNode SortList(ListNode head)
        {
            var pre = new ListNode(int.MinValue);
            pre.next = head;

            SortListHelp(pre, null);
            return pre.next;
        }

        public static void SortListHelp(ListNode pre, ListNode tail)
        {
            if (pre.next != tail && pre != tail)
            {
                var midenode = pre.next;
                var currentnode = midenode;
                while(currentnode != null && currentnode.next != tail)
                {
                    if(currentnode.next.val < midenode.val)
                    {
                        var movenode = currentnode.next;
                        currentnode.next = currentnode.next.next;
                        
                        movenode.next = pre.next;
                        pre.next = movenode;
                    }
                    else
                        currentnode = currentnode.next;
                }
                SortListHelp(pre, midenode);
                SortListHelp(midenode, tail);
            }

        }
    }

}
