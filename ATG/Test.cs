using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATG
{
	class Graph
	{
		Dictionary<char, Dictionary<char, int>> vertices = new Dictionary<char, Dictionary<char, int>>();

		public void add_vertex(char name, Dictionary<char, int> edges)
		{
			vertices[name] = edges;
		}

		public List<char> shortest_path(char start, char finish)
		{
			Console.WriteLine("Shortest Path from {0} to {1}",start,finish);
			var previous = new Dictionary<char, char>();
			var distances = new Dictionary<char, int>();
			var nodes = new List<char>();

			List<char> path = null;

			foreach (var vertex in vertices)
			{
				if (vertex.Key == start)
				{
					distances[vertex.Key] = 0;
				}
				else
				{
					distances[vertex.Key] = int.MaxValue;
				}
				nodes.Add(vertex.Key);
			}
			
			while (nodes.Count != 0)
			{
				nodes.Sort((x, y) => distances[x] - distances[y]);

				var smallest = nodes[0];
				nodes.Remove(smallest);

				if (smallest == finish)
				{
					Console.WriteLine("LENGTH: " + distances[finish]);
					path = new List<char>();
					while (previous.ContainsKey(smallest))
					{
						path.Add(smallest);
						smallest = previous[smallest];
					}
					path.Reverse();
					break;
				}

				if (distances[smallest] == int.MaxValue)
				{
					break;
				}

				foreach (var neighbor in vertices[smallest])
				{
					var alt = distances[smallest] + neighbor.Value;
					if (alt < distances[neighbor.Key])
					{
						distances[neighbor.Key] = alt;
						previous[neighbor.Key] = smallest;
					}
				}
			}
			return path;
		}
	}

	class MainClass
	{
		public void Test()
		{
			Graph g = new Graph();
			g.add_vertex('A', new Dictionary<char, int>() { { 'B', 10 }, { 'E', 5 } });
			g.add_vertex('B', new Dictionary<char, int>() { { 'C', 1 }, { 'E', 2 } });
			g.add_vertex('C', new Dictionary<char, int>() { { 'D', 4 } });
			g.add_vertex('D', new Dictionary<char, int>() { { 'A', 7 }, {'C',6} });
			g.add_vertex('E', new Dictionary<char, int>() { { 'B', 3 }, {'C',9}, {'D',2} });

			Console.WriteLine();
			g.shortest_path('A', 'C').ForEach(x => Console.Write(x + " "));
			Console.WriteLine();
			g.shortest_path('A', 'D').ForEach(x => Console.Write(x + " "));
			Console.WriteLine();
			g.shortest_path('A', 'E').ForEach(x => Console.Write(x + " "));

		}
	}
}