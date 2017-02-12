using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ATG
{
	class FordFulkersonAlg
	{
		public static bool Bfs(int[][] residualGraph, int s, int t, int[] parent)
		{
			int amount = parent.Length;

			bool[] visited = new bool[amount];
			for (int i = 0; i < amount; ++i)
				visited[i] = false;

			Queue<int> queue = new Queue<int>();
			queue.Enqueue(s);
			visited[s] = true;
			parent[s] = -1;

			while (queue.Count != 0)
			{
				if (visited[t])
					break;
				var u = queue.Dequeue();

				for (var v = 0; v < amount; v++)
				{
					if (visited[v] || residualGraph[u][v] <= 0) continue;
					queue.Enqueue(v);
					parent[v] = u;
					visited[v] = true;
				}
			}

			return (visited[t]);
		}

		public static int FordFulkerson(int[][] graph, int s, int t, out int[][] residualGraph)
		{
			residualGraph = new int[graph.Length][];
			for (var i = 0; i < graph.Length; i++)
			{
				residualGraph[i] = new int[graph[i].Length];
				for (var j = 0; j < graph[i].Length; j++)
				{
					residualGraph[i][j] = graph[i][j];
				}
			}
			var parent = new int[graph.Length];
			var maxFlow = 0;
			int v, u;

			while (Bfs(residualGraph, s, t, parent))
			{
				int pathFlow = int.MaxValue;
				for (v = t; v != s; v = parent[v])
				{
					u = parent[v];
					pathFlow = Math.Min(pathFlow, residualGraph[u][v]);
				}
				for (v = t; v != s; v = parent[v])
				{
					u = parent[v];
					residualGraph[u][v] -= pathFlow;
					residualGraph[v][u] += pathFlow;
				}
				maxFlow += pathFlow;
			}
			return maxFlow;
		}

		public void GetInput()
		{
			const int n = 6;
			int source = 0;
			int sink = 5;
			int[][] capacityMatrix = new int[n][]
			{
				//S  A   B  C   D  T 
				new int[] {0, 10, 0, 10, 0, 0}, //S
				new int[] {0, 0, 4, 2, 8, 0}, //A
				new int[] {0, 0, 0, 0, 0, 10}, //B
				new int[] {0, 0, 0, 0, 9, 0}, //C
				new int[] {0, 0, 6, 0, 0, 10}, //D
				new int[] {0, 0, 0, 0, 0, 0} //T
			};
			int[][] residualGraph;
			var maxFlow = FordFulkerson(capacityMatrix, source, sink, out residualGraph);
			Console.WriteLine("Maksymalny przepływ to: " + maxFlow);
			Printedges(residualGraph, capacityMatrix);
		}

		public void Printedges(int[][] residualGraph, int[][] capacityMatrix)
		{
			for (int i = 0; i < residualGraph.Length; i++)
			{
				for (int j = 0; j < residualGraph[i].Length; j++)
				{
					var diff = (capacityMatrix[i][j] - residualGraph[i][j]);
					diff = diff > 0 ? diff : 0;
					Console.Write(diff + " ");
				}
				Console.WriteLine();
			}
		}
	}
}