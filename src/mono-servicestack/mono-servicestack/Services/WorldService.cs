using ServiceStack.OrmLite;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;

namespace monoservicestack
{
	[Route("/db")]
	[Route("/db/{Queries}")]
	public class DbTest : IReturn<List<World>>
	{
		public int Queries { get; set; }
	}

	public class WorldService : Service
	{
		// Database details
		private const int DB_ROWS = 10000;

		public object Get(DbTest request) 
		{
			int count = request.Queries.Clamp(1, 500);
			List<World> worlds = new List<World>();
			Random random = new Random(); 
					
			for (int i = 0; i < count; i++) 
			{
				int id = random.Next(1, DB_ROWS);
				worlds.Add(Db.FirstOrDefault<World>(q => q.Id == id));
			}

			return worlds;
		}
	}
}
