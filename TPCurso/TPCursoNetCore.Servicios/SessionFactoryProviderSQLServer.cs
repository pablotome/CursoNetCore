using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Reflection;
using System.Text;
using TPCursoNetCore.Dominio;

namespace TPCursoNetCore.Servicios
{
	public class SessionFactoryProviderSQLServer : SessionFactoryProvider
	{
		private static SessionFactoryProviderSQLServer instance;
		public static SessionFactoryProviderSQLServer Instance
		{
			get { return instance ?? (instance = new SessionFactoryProviderSQLServer()); }
		}

		protected override ISessionFactory CreateSessionFactory<T>()
		{
			StringBuilder basePath = new StringBuilder(AppDomain.CurrentDomain.BaseDirectory);
			if (basePath.ToString().EndsWith("\\") == false)
				basePath.Append("\\");
			basePath.Append(@"TPCursoNetCore.Dominio.dll");

			Assembly asm = Assembly.LoadFile(basePath.ToString());

			return Fluently.Configure()
					.Database(MsSqlConfiguration.MsSql2008.ConnectionString(CN))
					.Mappings(m => m.FluentMappings.AddFromAssembly(asm))
					.ExposeConfiguration(cfg => configuration = cfg)
					.CurrentSessionContext<T>()
					.BuildSessionFactory();
		}

		public override ISession OpenSession()
		{
			ISession session = _sessionFactory.OpenSession();

			return session;
		}
	}
}
