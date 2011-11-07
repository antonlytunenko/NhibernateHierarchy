using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hierarchy
{
	public class Bus : MotorVehicle
	{
		public virtual int Capacity { get; set; }
		public virtual int DecksCount { get; set; }
	}
}
