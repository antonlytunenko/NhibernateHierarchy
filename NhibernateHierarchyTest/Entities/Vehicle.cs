using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hierarchy
{
	public abstract class Vehicle
	{
		public virtual Guid Id { get; set; }
		public virtual double Weight { get; set; }
		public virtual string Mark { get; set; }
		public virtual string Model { get; set; }
		public virtual DateTime ProductionDate { get; set; }
	}
}
