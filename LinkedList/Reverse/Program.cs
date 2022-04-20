using System;

namespace Reverse
{

    class Node
    {
        public int data;
        public Node next;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Node head = CreateLinkedList(10);
            //Node reversedHead = ReverseLinkedList(head);
            Node reversedHead = ReverseLinkedListRecurssion(head);
            DisplayLinkedList(reversedHead);
        }

        public static Node ReverseLinkedListRecurssion(Node temp){
            if(temp == null ||  temp.next==null)
            return temp;

            Node rest = ReverseLinkedListRecurssion(temp.next);
            temp.next.next = temp;

            temp.next = null;
            return rest;
        }

        public static void DisplayLinkedList(Node temp)
        {
            Console.Write("H->");
            while (temp != null)
            {
                Console.Write($" [{temp.data}]->");
                temp = temp.next;
            }
            Console.Write(" X");
        }

        public static Node ReverseLinkedList(Node temp)
        {
            Node prev, curr, next;
            curr = temp;
            prev = null;

            while (curr != null)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            return prev;
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
