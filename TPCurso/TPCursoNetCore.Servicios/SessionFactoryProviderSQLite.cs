﻿using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNetCore.Http;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Reflection;
using System.Text;
using TPCursoNetCore.Dominio;

namespace TPCursoNetCore.Servicios
{
	public class SessionFactoryProviderSQLite : SessionFactoryProvider
	{
		private static SessionFactoryProviderSQLite instance;

		public static SessionFactoryProviderSQLite Instance
		{
			get {
				return instance ?? (instance = new SessionFactoryProviderSQLite());
			}
		}

		protected override ISessionFactory CreateSessionFactory<T>()
		{
			StringBuilder basePath = new StringBuilder(AppDomain.CurrentDomain.BaseDirectory);
			if (basePath.ToString().EndsWith("\\") == false)
				basePath.Append("\\");
			basePath.Append(@"TPCursoNetCore.Dominio.dll");

			Assembly asm = Assembly.LoadFile(basePath.ToString());

			return Fluently.Configure()
					//.Database(SQLiteConfiguration.Standard.InMemory().ShowSql().UsingFile("BDCurso.db"))
					//.Database(SQLiteConfiguration.Standard.InMemory().ShowSql())
					.Database(SQLiteConfiguration.Standard.ConnectionString(CN).ShowSql())
					.Mappings(m => m.FluentMappings.AddFromAssembly(asm))
					.ExposeConfiguration(cfg => configuration = cfg)
					.CurrentSessionContext<T>()
					.BuildSessionFactory();
		}

		public override ISession OpenSession()
		{
			ISession session = _sessionFactory.OpenSession();

			/*var export = new SchemaExport(configuration);
			export.Execute(true, true, false, session.Connection, null);*/

			return session;
		}
	}
}
