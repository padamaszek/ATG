using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Euler_Circuit_Application
{
	class EulerCircuit
	{
		Stack tempPath = new Stack();
		ArrayList finalPath = new ArrayList(); //to store the final path
		char[] nodeList; //to store the nodes
		static char[,] GraphMatrix; //to store the edge representation of Graph
		static int total; //total->total no of nodes, count->no of even degree node
		int count; //total->total no of nodes, count->no of even degree node

		private void Input()
		{
			const int all = 6;
			total = all;
			GraphMatrix = new char[all,all]
			{
				{'n','y','n','y','n','n' },
				{'y','n','y','n','y','y' },
				{'n','y','n','y','y','y' },
				{'y','n','y','n','n','n' },
				{'n','y','y','n','n','n' },
				{'n','y','y','n','n','n' }

			};
			nodeList = new char[total];
			nodeList[0] = '0';
			nodeList[1] = '1';
			nodeList[2] = '2';
			nodeList[3] = '3';
			nodeList[4] = '4';
			nodeList[5] = '5';
		}

		private int GetDegree(int i)
		{
			int j, deg = 0;
			for (j = 0; j < total; j++)
			{
				if (GraphMatrix[i, j] == 'y') deg++;
			}
			return deg;
		}

		private int FindRoot()
		{
			int root = 1;
			count = 0;
			for (int i = 0; i < total; i++)
			{
				if (GetDegree(i) % 2 != 0)
				{
					count++;
					root = i;
				}
			}
			if (count != 0 )
			{
				return 0;
			}
			else return root;
		}

		private int GetIndex(char c)
		{
			int index = 0;
			while (c != nodeList[index])
				index++;
			return index;
		}

		private Boolean AllVisited(int node)
		{
			for (int l = 0; l < total; l++)
			{
				if (GraphMatrix[node, l] == 'y')
					return false;
			}
			return true;
		}

		private void FindEuler(int root)
		{
			int ind;
			tempPath.Clear();
			tempPath.Push(nodeList[root]);
			while (tempPath.Count != 0)
			{
				ind = GetIndex((char) tempPath.Peek());
				if (AllVisited(ind))
				{
					finalPath.Add(tempPath.Pop());
				}
				else
				{
					for (int j = 0; j < total; j++)
					{
						if (GraphMatrix[ind, j] == 'y')
						{
							GraphMatrix[ind, j] = 'n';
							GraphMatrix[j, ind] = 'n';
							tempPath.Push(nodeList[j]);
							break;
						}
					}
				}
			}
		}

		public void FindEulerCircuit()
		{
			Input();
			int root = FindRoot();

			if (root != 0)
			{
				Console.WriteLine("Available Euler circuit is");
				FindEuler(root);
				PrintEulerCircuit();
			}
			else
			{
				Console.WriteLine("Euler Circuit not Possible");
			}
		}

		public void PrintEulerCircuit()
		{
			for (int i = 0; i < finalPath.Count; i++)
			{
				Console.Write("{0}--->", finalPath[i]);
			}
		}
	}

	class ExecuteEulerCircuit
	{
		public void Init()
		{
			EulerCircuit ec = new EulerCircuit();
			ec.FindEulerCircuit();

			Console.ReadKey();
		}
	}
}