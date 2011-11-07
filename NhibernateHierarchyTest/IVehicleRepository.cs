using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hierarchy
{
	public interface IVehicleRepository
	{
		void Save(Vehicle v);

		void Delete(Vehicle v);

		IQueryable<T> GetAll<T>() where T:Vehicle;
	}
}
