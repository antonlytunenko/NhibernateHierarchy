using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Hierarchy.NHibernate.Mappings
{
	public class TruckMapping : SubclassMap<Truck>
	{
		public TruckMapping()
		{
			Map(t => t.GVWR).Not.Nullable();
		}
	}
}
