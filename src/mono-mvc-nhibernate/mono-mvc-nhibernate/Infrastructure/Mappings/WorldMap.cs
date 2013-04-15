using FluentNHibernate.Mapping;
using System;

namespace monomvcnhibernate
{
	public class WorldMap : ClassMap<World>
	{
		public WorldMap()
		{
			Id(x => x.Id);
			Map(x => x.RandomNumber);
		}
	}
}

