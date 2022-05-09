using System;
// https://kalkicode.com/pixels/graph/directed-graph-adjacency-matrix.png
namespace GraphArray
{
    public class Graph
{
	// Graph node
	public int[, ] node;
	// Number of nodes
	public int size;
	public Graph(int size)
	{
		if (size <= 0)
		{
			// Invalid number of nodes
			return;
		}
		this.node = new int[size, size];
		this.size = size;
	}
	public void addEdge(int start, int end)
	{
		if (this.size > start && this.size > end)
		{
			// Set the connection
			this.node[start, end] = 1;
		}
	}
	public void adjacencyNode()
	{
		if (this.size > 0)
		{
			for (var row = 0; row < this.size; row++)
			{
				Console.Write("Adjacency Matrix of vertex " + row.ToString() + " :");
				for (var col = 0; col < this.size; col++)
				{
					if (this.node[row, col] == 1) // if edge exist 
					{
						Console.Write(" " + col.ToString());
					}
				}
				Console.Write("\n");
			}
		}
		else
		{
			Console.WriteLine("Empty Graph");
		}
	}
}
    class Program
    {
        static void Main(string[] args)
        {
            CreateGraph();
        }

        public static void CreateGraph () {
            // 6 implies the number of nodes in graph
		var g = new Graph(6);
		//  Add a edge with given nodes
		g.addEdge(0, 1);
		g.addEdge(0, 3);
		g.addEdge(2, 1);
		g.addEdge(2, 3);
		g.addEdge(3, 4);
		g.addEdge(4, 2);
		g.addEdge(4, 5);
		g.addEdge(5, 2);
		// Display node and edge status
		g.adjacencyNode();
        }
    }
}
