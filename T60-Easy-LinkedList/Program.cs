using System;
using System.Collections.Generic;

namespace T60_Easy_LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode a1 = new ListNode(5);
            ListNode a2 = new ListNode(2);
            a1 = a1.next;
            a2 = a2.next;
            if (a1 == a2)
                Console.WriteLine("null == null");
        }
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        // 时间复杂度O(m+m),空间复杂度O(1), MARK:两个指针通过不同节点分别指向Null,此时pA == pB
        public ListNode getIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null) return null;
            ListNode pA = headA, pB = headB;
            while (pA != pB)
            {
                pA = pA == null ? headB : pA.next;
                pB = pB == null ? headA : pB.next;
            }
            return pA;
        }

        
        /* 时间复杂度O(m+m),空间复杂度O(m)
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            List<ListNode> list = new List<ListNode>();
            while (headA != null)
            {
                list.Add(headA);
                headA = headA.next;
            }
            while(headB !=null)
            {
                if (list.Contains(headB))
                    return headB;
                headB = headB.next;
            }
            return null;
        }
        */
    }
}
