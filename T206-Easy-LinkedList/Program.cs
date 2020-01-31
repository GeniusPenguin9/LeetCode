using System;

namespace T206_Easy_LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
                return head;

            var temp = head.next;
            var nhead = head;
            nhead.next = null;
            head = temp;
            while (head != null)
            {
                temp = head.next;
                head.next = nhead;
                nhead = head;
                head = temp;
            }
            return nhead;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
