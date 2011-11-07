using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Hierarchy.NHibernate.Mappings
{
	public class CarMapping: SubclassMap<Car>
	{
		public CarMapping()
		{
			Map(c => c.CarTypeId);
		}
	}
}
