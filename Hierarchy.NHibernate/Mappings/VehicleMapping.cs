using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Hierarchy.NHibernate.Mappings
{
	public class VehicleMapping : ClassMap<Vehicle>
	{
		public VehicleMapping()
		{
			Id(v => v.Id).GeneratedBy.Guid();
			Map(v => v.Mark).Not.Nullable();
			Map(v => v.Model).Not.Nullable();
			Map(v => v.ProductionDate).Not.Nullable();
			Map(v => v.Weight).Not.Nullable();
		}
	}
}
