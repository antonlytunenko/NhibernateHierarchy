using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hierarchy
{
	public class Truck : MotorVehicle
	{
		public virtual float GVWR { get; set; }
	}
}
