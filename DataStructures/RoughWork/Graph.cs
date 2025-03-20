using System;

namespace Graph
{
    class Graph {
        public int[,] node;
        public int size;

        public Graph(int size) {
            this.node = new int [size,size];
            this.size = size;
        }

        public void addEdge (int start, int end) {
            this.node[start,end] = 1;
        }

    }

    class Program {
        // public static void Main(string[] args) {
        //     Console.WriteLine("Hey!");
        // }
    }

}