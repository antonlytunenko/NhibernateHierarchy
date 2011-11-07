using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Hierarchy.NHibernate.Mappings
{
	public class MotorVehicleMapping : SubclassMap<MotorVehicle>
	{
		public MotorVehicleMapping()
		{
			Map(m => m.MotorVolume).Not.Nullable();
			Map(m => m.ValvesNumber).Not.Nullable();
		}
	}
}
