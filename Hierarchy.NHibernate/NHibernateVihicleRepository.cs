using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;

namespace Hierarchy.NHibernate
{
	public class NHibernateVihicleRepository : IVehicleRepository, IDisposable
	{
		private ISession _session;

		public NHibernateVihicleRepository(ISession session)
		{
			_session = session;
		}

		public void Save(Vehicle v)
		{
			InTransaction(()=>_session.SaveOrUpdate(v));
		}

		public void Delete(Vehicle v)
		{
			InTransaction(()=>_session.Delete(v));
		}

		public IQueryable<T> GetAll<T>() where T: Vehicle
		{
			return (from v in _session.Query<T>() select v);
		}

		public void Dispose()
		{
			_session.Dispose();
		}

		public virtual void InTransaction(Action action)
		{
			if (_session.Transaction == null || !_session.Transaction.IsActive)
			{
				using (_session.BeginTransaction())
				{
					action();
					_session.Transaction.Commit();
				}
			}
			else
			{
				action();
			}
		}
	}
}
