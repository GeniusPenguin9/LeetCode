using System;

namespace T234_Easy_LinkedList_TwoPointers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public bool IsPalindrome(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;

            // 若n % 2 == 0, [0,slow),[slow,end], fast == null
            // 若n % 2 != 0, [0,slow],(slow,end], fast.next == null，中点归于左侧区间
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }

            var reverseHead = fast == null ? ReverseListNode(slow) : ReverseListNode(slow.next);
            while (reverseHead != null)
            {
                if (head.val != reverseHead.val)
                    return false;
                head = head.next;
                reverseHead = reverseHead.next;
            }
            return true; 
        }

        public ListNode ReverseListNode(ListNode head)
        {
            ListNode pre = null;
                        
            while (head != null)
            {
                var tmp = head.next;
                head.next = pre;

                pre = head;
                head = tmp;
            }
            return pre;
        }
    }
}
