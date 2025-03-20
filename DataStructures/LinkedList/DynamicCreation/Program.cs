using System;

namespace DynamicCreation
{
    class Node{
        public int data;
        public Node next;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Node head = CreateLinkedList(10);
            DisplayLinkedList(head);
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
        
        public static Node CreateLinkedList(int length) {
            if (length < 1) return null;

            Node head, prev;
            int i=0;
            head = new Node();            
            prev = head;
            i++;
            while (i<length){
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
