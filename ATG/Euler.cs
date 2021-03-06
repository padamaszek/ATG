﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATG
{
	class Euler
	{
		private static int n;

		private static List<int>[] graph;

		private static bool[] visited;

		private static Stack<int> dfsNodesStack;

		private static bool DoesEulerCycleExist()
		{
			foreach (List<int> list in graph)
			{
				if (list.Count % 2 == 1)
				{
					Console.WriteLine("NIE ISTNIEJE CYKL EULERA");
					return false;
				} 
			}
			return true;
		}

		private static bool ConnectivityOfGraph()
		{
			DFS(0);
			if (dfsNodesStack.Count == n)
			{
				Console.WriteLine("SPOJNY!!!");
				return true;
			}
			else
			{
				Console.WriteLine("NIESPOJNY!!!");
				return false;
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

		private bool AllVisited(int node)
		{
			if (graph[node].Count == 0)
			{
				return true;
			}

			return false;
		}

		public void Init()
		{
			graph = new List<int>[]
			{
				new List<int>() {1,2},
				 // children of node 0
				new List<int>() {0,2,3,4}, // children of node 1
				new List<int>() {0,1}, // children of node 2
				new List<int>() {1,4}, // children of node 3
				new List<int>() {1,3}, // children of node 4
			};
			n = graph.Length;
			visited = new bool[n];
			dfsNodesStack = new Stack<int>();
			if (ConnectivityOfGraph() && DoesEulerCycleExist())
			{
				//for(int node =0;node<n;node++)
				EulerCycle(0);
			}
		}

		private void EulerCycle(int node)
		{
			Stack<int> tempPath = new Stack<int>();
			Stack<int> finalPath = new Stack<int>();
			tempPath.Push(node);
			while (tempPath.Count > 0)
			{
				node = tempPath.Peek();
				if (AllVisited(node))
				{
					finalPath.Push(tempPath.Pop());
				}
				else
				{
					var toNode= graph[node].First();
					graph[node].Remove(toNode);
					graph[toNode].Remove(node);
					tempPath.Push(toNode);
				}

			}

			Console.Write("Euler Cycle: ");
			while (finalPath.Count > 0)
				Console.Write("{0} ", finalPath.Pop() + 1);

			Console.WriteLine();
		}
	}
	}