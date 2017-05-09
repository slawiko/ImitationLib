﻿using ImitationLib.Elements;
using ImitationLib.Utils;

namespace ImitationLib
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Logger.InitLogger();

			Generator enter = new Enter(5, 3);
			Executor service = new Service(2);
			Executor service2 = new Service(12);
			Executor service3 = new Service(8);
			Collector exit = new Exit(0);

			Model model = new Model();
			model.LinkElements(enter, exit, service, service2, service3);
			model.Run();
		}
	}
}
