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
