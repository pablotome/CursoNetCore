using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNetCore.Http;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Reflection;
using System.Text;
using TPCursoNetCore.Dominio;

namespace TPCursoNetCore.Servicios
{
	/// <summary>
	/// http://nicbell.net/blog/simple-nhibernate-session-manager/
	/// </summary>
	public abstract class SessionFactoryProvider
	{
		protected ISessionFactory _sessionFactory = null;

		protected Configuration configuration;

		//protected readonly IHttpContextAccessor _contextAccessor;

		/*public SessionFactoryProvider(IHttpContextAccessor contextAccessor)
		{
			_contextAccessor = contextAccessor;
		}*/

		protected string _cn = string.Empty;

		public string CN
		{
			get { return _cn; }
			set { _cn = value; }
		}

		public SessionFactoryProvider()
		{
			
		}

		protected virtual ISessionFactory CreateSessionFactory<T>() where T : ICurrentSessionContext
		{
			throw new NotImplementedException();
		}

		public ISessionFactory SessionFactory
		{
			get { return _sessionFactory; }
		}

		public void Initialize(bool httpContext)
		{
			if (_sessionFactory == null)
				_sessionFactory = httpContext ? CreateSessionFactory<WebSessionContext>() : CreateSessionFactory<ThreadStaticSessionContext>();
		}

		public virtual ISession OpenSession()
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			if (_sessionFactory != null)
				_sessionFactory.Dispose();

			_sessionFactory = null;
			configuration = null;
		}
	}
}
