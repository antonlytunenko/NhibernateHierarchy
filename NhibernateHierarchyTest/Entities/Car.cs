using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hierarchy
{
	public class Car : MotorVehicle
	{
		/// <summary>
		/// 1 - sedan
		/// 2 - hatchback
		/// 3 - CUV 
		/// </summary>
		public virtual int CarTypeId { get; set; }
	}
}
