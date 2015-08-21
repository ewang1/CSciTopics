using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSci
{
	class GraphBFS
	{
		LinkedList<int>[] graph;

		public GraphBFS(int vertices)
		{
			graph = new LinkedList<int>[vertices];
			for (int i = 0; i < vertices; i++)
			{
				this.graph[i] = new LinkedList<int>();
			}
		}

		public bool AddEdge(int v1, int v2, bool directed)
		{
			if (v1 < 0 || v1 > this.graph.Length || v2 < 0 || v2 > this.graph.Length)
			{
				return false;
			}
			else
			{
				if (directed)
				{
					this.graph[v1].AddLast(v2);
				}
				else
				{
					this.graph[v1].AddLast(v2);
					this.graph[v2].AddLast(v1);
				}
				return true;
			}
		}

		public void PrintGraph()
		{
			System.Console.WriteLine("");
			for (int x = 0; x < this.graph.Length; x++)
			{
				System.Console.Write(x + ": ");
				foreach (int item in this.graph[x])
				{
					System.Console.Write(item + " ");
				}
				System.Console.WriteLine();
			}
		}

		public int SnakesNLadder(int start, int end)
		{
			if (start == end)
			{
				return 0;
			}
			else
			{
				foreach (int x in this.graph[start])
				{
					if (x != start+1)
					{
						//snake
						if (x < start)
						{
							return int.MaxValue;
						}
						else  //ladder
						{
							return this.SnakesNLadder(x, end);
						}
					}
				}

				int min = int.MaxValue;
				for (int dice = 1; dice <=6; dice++)
				{
					if (start + dice <= end)
					{
						int result = this.SnakesNLadder(start + dice, end);
						if (result < min)
						{
							min = result;
						}
					}
				}
				return min + 1;
			}
			
		}
		public static void testGraphBFS()
		{
			GraphBFS test = new GraphBFS(30);
			test.AddEdge(0, 1, true);
			test.AddEdge(1, 2, true);
			//test.AddEdge(2, 3, true);
			test.AddEdge(3, 4, true);
			test.AddEdge(4, 5, true);
			test.AddEdge(5, 6, true);
			test.AddEdge(6, 7, true);
			test.AddEdge(7, 8, true);
			test.AddEdge(8, 9, true);
			test.AddEdge(9, 10, true);
			//test.AddEdge(10, 11, true);
			test.AddEdge(11, 12, true);
			test.AddEdge(12, 13, true);
			test.AddEdge(13, 14, true);
			test.AddEdge(14, 15, true);
			test.AddEdge(15, 16, true);
			//test.AddEdge(16, 17, true);
			test.AddEdge(17, 18, true);
			//test.AddEdge(18, 19, true);
			//test.AddEdge(19, 20, true);
			test.AddEdge(20, 21, true);
			//test.AddEdge(21, 22, true);
			test.AddEdge(22, 23, true);
			test.AddEdge(23, 24, true);
			test.AddEdge(24, 25, true);
			test.AddEdge(25, 26, true);
			//test.AddEdge(26, 27, true);
			test.AddEdge(27, 28, true);
			test.AddEdge(28, 29, true);
			test.AddEdge(2, 21, true);
			test.AddEdge(10, 25, true);
			test.AddEdge(16, 3, true);
			test.AddEdge(18, 6, true);
			test.AddEdge(19, 28, true);
			test.AddEdge(20, 8, true);
			test.AddEdge(26, 0, true);

			test.PrintGraph();

			int steps = test.SnakesNLadder(0, 29);

			System.Console.WriteLine("The SnakeNLadder function says it'll take a minimum of " 
				+ steps + " rolls to win this game");
		}
	}
}
