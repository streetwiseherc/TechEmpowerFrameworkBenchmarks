using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;

namespace monoservicestack
{
	[Route("/world")]
	public class World 
	{
		public World(int id, int randomNumber)
		{
			Id = id;
			RandomNumber = randomNumber;
		}
		
		public int Id { get; set; }
		public int RandomNumber { get; set; }
	}
}

