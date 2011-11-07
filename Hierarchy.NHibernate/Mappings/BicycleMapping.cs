using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Hierarchy.NHibernate.Mappings
{
	public class BicycleMapping : SubclassMap<Bicycle>
	{
		public BicycleMapping()
		{
			Map(b => b.FrameProducer);
		}
	}
}
