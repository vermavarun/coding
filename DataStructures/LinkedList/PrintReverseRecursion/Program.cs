using System;

namespace PrintReverseRecursion
{
    class Node {
        public int data;
        public Node next;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Node head = CreateLinkedList(10);
            PrintReverse(head);
        }

        public static void PrintReverse(Node head) {
            if(head == null) {
                return ;
            }
            PrintReverse(head.next);
            Console.WriteLine(head.data);
        }

        public static Node CreateLinkedList(int length)
        {
            if (length < 1) return null;

            Node head, prev;
            int i = 0;
            head = new Node();
            prev = head;
            i++;
            while (i < length)
            {
                Node temp = new Node();
                temp.data = i;
                temp.next = null;
                prev.next = temp;
                prev = temp;
                i++;
            }
            return head;
        }
    }
}
