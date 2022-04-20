using System;

namespace Creation
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
            Node head, node1, node2, temp;

            node1 = new Node();
            node1.data = 1;           

            node2 = new Node();
            node2.data = 2;

            node1.next = node2;
            node2.next = null;
            head = node1;
            temp = head;
            DisplayLinkedList(temp);
        }

         public static void DisplayLinkedList(Node temp){
            Console.Write("H->");
            while (temp!= null)
            {
                Console.Write($" [{temp.data}]->");
                temp = temp.next;
            }
            Console.Write(" X");
        }
    }
}
