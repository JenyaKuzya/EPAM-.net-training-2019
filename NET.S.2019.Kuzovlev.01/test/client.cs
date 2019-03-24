using System;
using car;

class Program
{
	static void Main()
	{
		Auto obj1 = new Auto();
		obj1.AutoInfo();
		
		Sportcar obj = new Sportcar();
		obj.InfoSportcar();
		
		Minicar obj2 = new Minicar();
		obj2.MinicarInfo();
		
		Console.ReadLine();
	}
}