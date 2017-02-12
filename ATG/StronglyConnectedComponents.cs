using System;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.Linq;

class StronglyConnectedComponents
{
	private static int n;

	private static List<int>[] graph;

	private static List<int>[] reverseGraph;

	private static bool[] visited;

	private static Stack<int> dfsNodesStack;

	private static void BuildReverseGraph()
	{
		reverseGraph = new List<int>[n];
		for (int node = 0; node < n; node++)
		{
			reverseGraph[node] = new List<int>();
		}

		for (int node = 0; node < n; node++)
		{
			foreach (var childNode in graph[node])
			{
				reverseGraph[childNode].Add(node);
			}
		}
	}

	private static void DFS(int node)
	{
		if (!visited[node])
		{
			visited[node] = true;
			foreach (var childNode in graph[node])
			{
				DFS(childNode);
			}
			dfsNodesStack.Push(node);
		}
	}

	private static void ReverseDFS(int node)
	{
		if (!visited[node])
		{
			visited[node] = true;
			Console.Write(" {0}", node + 1);
			foreach (var childNode in reverseGraph[node])
			{
				ReverseDFS(childNode);
			}
		}
	}

	private static void FindStronglyConnectedComponents()
	{
		n = graph.Length;
		BuildReverseGraph();

		visited = new bool[n];
		dfsNodesStack = new Stack<int>();
		for (int node = 0; node < n; node++)
		{
			DFS(node);
		}

		visited = new bool[n];
		while (dfsNodesStack.Count > 0)
		{
			var node = dfsNodesStack.Pop();
			if (!visited[node])
			{
				Console.Write("{");
				ReverseDFS(node);
				Console.WriteLine(" }");
			}
		}
	}

	public void init()
	{
		graph = new List<int>[]
		{
			new List<int>() {1}, // children of node 0
			new List<int>() {2}, // children of node 1
			new List<int>() {3}, // children of node 2
			new List<int>() {1, 4, 6}, // children of node 3
			new List<int>() {5}, // children of node 4
			new List<int>() {4}, // children of node 5
			new List<int>() {2}, // children of node 6
		};
		FindStronglyConnectedComponents();
	}
}