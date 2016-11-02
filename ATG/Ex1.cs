using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATG
{
	public class Ex1
	{
		public SortedDictionary<int, List<int>> graph = new SortedDictionary<int, List<int>>();

		public void init()
		{
			List<int> ed = new List<int>() {0, 1, 0, 1};
			List<int> ed2 = new List<int>() {0, 0, 1, 0};
			List<int> ed3 = new List<int>() {1, 0, 0, 0};
			List<int> ed4 = new List<int>() {0, 1, 0, 0};
			graph.Add(0, ed);
			graph.Add(1, ed2);
			graph.Add(2, ed3);
			graph.Add(3, ed4);
		}

		public void addZeroes()
		{
			foreach (List<int> value in graph.Values)
			{
				value.Add(0);
			}
		}

		public void addNeighbours(int index,List<int> neighbours)
		{
			for (int i = 0; i < neighbours.Count; i++)
			{
				addEdge(index,neighbours[i]);
			}
		}

		public void addNode(int index, List<int> neighbours)
		{
			if (graph.ContainsKey(index))
			{
				graph.Remove(index);
			}
			//TODO: TO JEST COS NIE TAK Z NEIGH
			graph.Add(index, neighbours);
			addZeroes();
			addNeighbours(index,neighbours);
		}

		public void removeNode(int index)
		{
			graph.Remove(index);
			foreach (var graphKey in graph.Keys)
			{
				graph[graphKey].RemoveAt(index - 1);
			}
		}

		public void addEdge(int fromNode, int toNode)
		{
			List<int> keyList = new List<int>(graph.Keys);
			int indexFrom = keyList.IndexOf(fromNode);
			int indexTo = keyList.IndexOf(toNode);
			graph[fromNode][indexTo] = 1;
			graph[toNode][indexFrom] = 1;
		}

		public void removeEdge(int index, int edge)
		{
			if (!graph.ContainsKey(edge))
			{
				Console.WriteLine("NIE MA TAKIEJ KRAWEDZI!");
			}
			else
			{
				graph[index][edge - 1] = 0;
			}
		}

		public int edgeDegree(int index)
		{
			int degree = 0;
			for (int i = 0; i < graph[index].Count; i++)
			{
				if (graph[index][i] == 1)
				{
					degree += 1;
				}
			}
			return degree;
		}

		public void graphDegree()
		{
			int max = 0, min = int.MaxValue, pom;

			foreach (KeyValuePair<int, List<int>> keyValuePair in graph)
			{
				pom = edgeDegree(keyValuePair.Key);
				if (pom > max)
				{
					max = pom;
				}
				if (pom < min)
				{
					min = pom;
				}
			}
			Console.WriteLine("Graph Max Degree: {0}, Graph Min Degree: {1}", max, min);
		}

		public void countEvenAndOddEdges()
		{
			int even = 0, odd = 0;
			foreach (int key in graph.Keys)
			{
				if (edgeDegree(key)%2 == 0)
				{
					even += 1;
				}
				else
				{
					odd += 1;
				}
			}
			Console.WriteLine("Number of even degree: {0}, number of odd degree: {1}", even, odd);
		}

		public void printDegrees()
		{
			List<int> degrees = new List<int>();
			foreach (int key in graph.Keys)
			{
				degrees.Add(edgeDegree(key));
			}
			degrees.Sort();
			degrees.Reverse();
			Console.WriteLine("Degrees:");
			foreach (int degree in degrees)
			{
				Console.Write(degree + " ");
			}
		}

		public void printGraph()
		{
			Console.Write("   ");
			foreach (var key in graph.Keys)
			{
				Console.Write(key + "  ");
			}
			Console.WriteLine();

			foreach (KeyValuePair<int, List<int>> pair in graph)
			{
				if (pair.Key > 9)
				{
					Console.Write(pair.Key + " ");
				}
				else
				{
					Console.Write(pair.Key + "  ");
				}

				foreach (var i in pair.Value)
				{
					Console.Write(i + "  ");
				}
				Console.WriteLine();
			}
		}
	}
}