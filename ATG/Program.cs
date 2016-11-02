using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATG
{
	class Program
	{
		static void Main(string[] args)
		{
			Ex1 ex1 = new Ex1();
			ex1.init();
			ex1.addNode(6,new List<int>() {0,1,3});
			ex1.printGraph();
			Console.ReadLine();
		}
	}
}
