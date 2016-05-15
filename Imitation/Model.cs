﻿using Imitation.Elements;
using System.Collections.Generic;

namespace Imitation
{
	public class Model
	{
		private Queue<Element> _elementQueue;
		private Generator _entry;
		//private static readonly log4net.ILog log =
		//			log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public Model()
		{
			this._elementQueue = new Queue<Element>();
			this.Init();
			this.Start();
		}
		 
		public void Init()
		{
			Generator enter = new Enter(1);
			Accumulator queue = new Queue(10); 
			Executor service = new Service();
			Exit exit = new Exit();

			this._entry = enter;
			enter.Next += queue.Enter;
			queue.Next += service.Execute;
			service.Next += exit.Collect;
		}

		public void Start()
		{
			while (this.IsReady())
			{
				foreach (var item in this._elementQueue)
				{
					//if (item.Ready) item.Run()
				}
			}
		}

		private bool IsReady()
		{
			foreach (var item in this._elementQueue)
			{
				if (item.Ready) return true;
			}
			return false;
		}
	}
}
