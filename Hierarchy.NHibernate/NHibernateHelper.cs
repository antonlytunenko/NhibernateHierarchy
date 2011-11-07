using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Hierarchy.NHibernate.Mappings;

namespace Hierarchy.NHibernate
{
	public static class NHibernateHelper
	{
		public static FluentConfiguration GetConfiguration(string connectionString)
		{
			return Fluently.Configure().Database(MsSqlConfiguration.MsSql2008.
										ConnectionString(connectionString))
										.Mappings(m => m.FluentMappings.AddFromAssemblyOf<VehicleMapping>())
										.ExposeConfiguration(cfg=>new SchemaUpdate(cfg).Execute(true, true));
		}

		public static ISessionFactory GetSessionFactory(string connectionString)
		{
			return GetConfiguration(connectionString).BuildSessionFactory();
		}

		public static ISession GetSession(string connectionString)
		{
			return GetSessionFactory(connectionString).OpenSession();
		}
	}
}
