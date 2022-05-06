using System;

namespace DFS
{
    class Node {
        public int _data;
        public Node left;
        public Node right;

        public Node(int data) {
            this._data = data;
            this.left = this.right =  null;            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Node root = CreateTree();
            Console.WriteLine("Pre Order");
            PrintPreOrder(root);
            Console.WriteLine("Post Order");
            PrintPostOrder(root);
            Console.WriteLine("In Order");
            PrintInOrder(root);
        }

         /// left : root : right
        public static void PrintInOrder (Node root) {
            if(root == null) {
                return ;
            }
            
            PrintInOrder(root.left);
            Console.WriteLine(root._data);
            PrintInOrder(root.right);
        }

        ///root : left : right
        public static void PrintPreOrder (Node root) {
            if(root == null) {
                return ;
            }
            Console.WriteLine(root._data);
            PrintPreOrder(root.left);
            PrintPreOrder(root.right);
        }

        /// left : right : root
        public static void PrintPostOrder (Node root) {
            if(root == null) {
                return ;
            }
            
            PrintPostOrder(root.left);
            PrintPostOrder(root.right);
            Console.WriteLine(root._data);
        }

        public static Node CreateTree() {

            Node root = new Node(0);
            Node firstLeft = new Node(1);
            Node firstRight = new Node(2);
            Node secondLeft = new Node(3);

            root.left = firstLeft;
            firstLeft.left = secondLeft;
            root.right = firstRight;

            return root;
        }
    }
}
