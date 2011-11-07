using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hierarchy
{
	public abstract class MotorVehicle : Vehicle
	{
		public virtual double MotorVolume { get; set; }
		public virtual int ValvesNumber { get; set; }
	}
}
