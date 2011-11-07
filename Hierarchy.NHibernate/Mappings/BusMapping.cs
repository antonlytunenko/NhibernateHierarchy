using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Hierarchy.NHibernate.Mappings
{
	public class BusMapping : SubclassMap<Bus>
	{
		public BusMapping()
		{
			Map(b => b.Capacity).Not.Nullable();
			Map(b => b.DecksCount).Not.Nullable();
		}
	}
}
