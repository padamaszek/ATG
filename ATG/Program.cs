using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euler_Circuit_Application;

namespace ATG
{
	class Program
	{
		static void Main(string[] args)
		{
			//Djikstra
			//Start start = new Start();
			//start.init();
			StronglyConnectedComponents scc = new StronglyConnectedComponents();
			//scc.init();
			Jordan jordan = new Jordan();
			//jordan.init();
			ExecuteEulerCircuit ex = new ExecuteEulerCircuit();
			//ex.Init();
			FordFulkersonAlg ff = new FordFulkersonAlg();
			//ff.GetInput();
			Euler euler = new Euler();
			euler.Init();
			Console.ReadLine();
		}
	}
}