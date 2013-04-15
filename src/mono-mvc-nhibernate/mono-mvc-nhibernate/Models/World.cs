using System;

namespace monomvcnhibernate
{
	public class World
	{
		public World()
		{
		}

		public World(int id, int randomNumber)
		{
			Id = id;
			RandomNumber = randomNumber;
		}
		
		public virtual int Id { get; set; }
		public virtual int RandomNumber { get; set; }
	}
}

