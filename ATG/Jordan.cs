using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATG
{

	class Jordan
	{
		private static int n;

		private static bool[] visited;
		private static List<int>[] graph;
		private static List<int> leaves;

		private static Stack<int> dfsNodesStack;

		public void init()
		{

			graph = new List<int>[]
		{
			new List<int>() {1,4}, // children of node 0
			new List<int>() {0,2,3}, // children of node 1
			new List<int>() {1}, // children of node 2
			new List<int>() {1}, // children of node 3
			new List<int>() {0,5}, // children of node 4
			new List<int>() {4}, // children of node 5
		};
			n = graph.Length;
			visited = new bool[n];
			dfsNodesStack = new Stack<int>();
			leaves = new List<int>();
			int node = 0;
			do
			{
				leaves.Clear();
				DFS(node);
				node++;
				RemoveLeaves();
			} while (leaves.Count!=0);

		}

		private static void DFS(int node)
		{
			if (!visited[node])
			{
				if (graph[node].Count ==1)
				{
					leaves.Add(node);
					Console.WriteLine($"LISC!!!{node}");
				}
				visited[node] = true;

				foreach (var childNode in graph[node])
				{
					DFS(childNode);
				}
				dfsNodesStack.Push(node);
			}
		}

		private static void RemoveLeaves()
		{
			foreach (int leaf in leaves)
			{
				Console.WriteLine(leaf);
				var next = graph[leaf][0];
				graph[next].Remove(leaf);
				graph[leaf].Clear();
				
			}
		}
	}
}
