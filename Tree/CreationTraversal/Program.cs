using System;

namespace CreationTraversal
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
            // int height = CalculateTreeHeight(root);
            // Console.WriteLine(height);
             PrintLevelOrderTraversal(root);
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

        public static void PrintLevelOrderTraversal(Node root) {
            int height = CalculateTreeHeight(root);
            for (int i=1; i<=height; i++) {
                PrintCurrentLevel(root, i);
            }

        }

        public static void PrintCurrentLevel(Node root, int level) {

            if (root == null) {
                return;
            }

            if (level == 1) {
                Console.WriteLine(root._data + " ");
            }
            else if (level > 1) {
                PrintCurrentLevel(root.left, level-1);
                PrintCurrentLevel(root.right, level-1);
            }
        }

        public static int CalculateTreeHeight(Node root) {
            if(root == null) {
                return 0;
            }

            int lHeight = CalculateTreeHeight(root.left);
            int rHeight = CalculateTreeHeight(root.right);

            return lHeight > rHeight ? lHeight + 1 : rHeight + 1;
        }
    }
}
