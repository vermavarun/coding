// using System;

//     namespace CreationTraversal
// {
//     class Node {
//         public int _data;
//         public Node left;
//         public Node right;

//         public Node(int data) {
//             this._data = data;
//             this.left = this.right =  null;
//         }
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Node root = CreateTree(5);
//              int height = CalculateTreeHeight(root);
//              Console.WriteLine(height);
//              PrintLevelOrderTraversal(root, height);
//         }

//         public static Node CreateTree(int numOfNodes) {

//             Node root = new Node(0);
//             Node firstLeft = new Node(1);
//             Node firstRight = new Node(2);
//             Node secondLeft = new Node(3);

//             root.left = firstLeft;
//             firstLeft.left = secondLeft;
//             root.right = firstRight;

//             return root;
//         }

//         public static void PrintLevelOrderTraversal(Node root, int height) {
//             if(root == null) {
//                return;
//             }

//             for (int i = 1; i <= height; i++ ) {
//                 PrintCurrentLevel(root,i);
//             }

//         }

//         public static void PrintCurrentLevel (Node root, int level) {
//             if(root == null) {
//                 return;
//             }

//             if (level == 1) {
//                 Console.Write(root._data + ":");
//             }
//             else if (level > 1) {
//                 PrintCurrentLevel(root.left, level - 1);
//                 PrintCurrentLevel(root.right, level - 1);
//             }
//         }

//         public static int CalculateTreeHeight(Node root) {

//             if(root == null) {
//                 return 0;
//             }

//             int lHeight = CalculateTreeHeight(root.left);
//             int rHeight = CalculateTreeHeight(root.right);

//             return rHeight > lHeight ? rHeight + 1 : lHeight + 1;
//         }
//     }
// }


// using System;

// namespace Graph
// {
//     class Graph {
//         public int[,] node;
//         public int size;

//         public Graph(int size) {
//             this.node = new int [size,size];
//             this.size = size;
//         }

//         public addEdge (int start, int end) {
//             this.node[start,end] = 1;
//         }

//     }

//     class Program {
//         public static void Main(string[] args) {
//             Console.WriteLine("Hey!");
//         }
//     }

// }

using System;
using System.Linq;
using System.Collections.Generic;
namespace Practice
{

    class Practice {
        public static void Main(string[] args) {
            string[] arr = new string[]{"eat","tea","tan","ate","nat","bat"};
            var output = GroupAnagrams(arr);
            foreach(var item in output) {
                Console.WriteLine(string.Join(",", item));
            }
        }

        // static List<List<string>> GroupAnagrams(string[] arr) {
        //     return arr.GroupBy(x => new string(x.OrderBy(c => c).ToArray())).Select(x => x.ToList()).ToList();
        // }
        static List<List<string>> GroupAnagrams(string[] arr) {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            foreach(var item in arr) {
                var key = new string(item.OrderBy(c => c).ToArray());
                if(dict.ContainsKey(key)) {
                    dict[key].Add(item);
                }
                else {
                    dict.Add(key, new List<string>(){item});
                }
            }
            return dict.Values.ToList();
        }
    }
}