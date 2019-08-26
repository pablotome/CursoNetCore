using System;
using System.Data;
using System.Web;
using System.Security.Principal;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

using NHibernate;
using NHibernate.Criterion;
using NHibernate.Context;
using NHibernate.Linq;
using System.IO;

namespace TPCursoNetCore.Servicios
{
	/*public class ProviderBD
	{
		public string Engine { get; set; }
		public string ConnectionStrings { get; set; }
	}*/

	public partial class ServicioSistema<T> where T : class
	{
		static object syncObject = new object();
		static ITransaction transaction = null;

		static SessionFactoryProvider SessionFactoryProvider = null;

		protected static IConfigurationRoot configuration = null;

		private static bool _HTTPContext = false;
		private static string _Engine = string.Empty;
		private static string _ConnectionString = string.Empty;

		protected static bool HTTPContext
		{
			get {
				if (configuration == null)
					CargarConfiguracion();
				return _HTTPContext;
			}
		}

		protected static string Engine
		{
			get {
				if (configuration == null)
					CargarConfiguracion();
				return _Engine;
			}
		}

		protected static string ConnectionString
		{
			get
			{
				if (configuration == null)
					CargarConfiguracion();
				return _ConnectionString;
			}
		}

		/// <summary>
		/// http://learningprogramming.net/net/asp-net-core-mvc/read-values-from-appsettings-json-file-in-asp-net-core/
		/// </summary>
		public static void CargarConfiguracion()
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
								.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
								.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
								.Build();

			_HTTPContext = bool.Parse(configuration["ProviderBD:HTTPContext"]);
			_Engine = configuration["ProviderBD:Engine"];
			_ConnectionString = configuration["ProviderBD:ConnectionString"];
		}
		
		public static ISession Session
		{
			get
			{
				try
				{
					SessionFactoryProvider providerBD = GetProviderBD();
					if (!CurrentSessionContext.HasBind(providerBD.SessionFactory))
						CurrentSessionContext.Bind(providerBD.OpenSession());
					return providerBD.SessionFactory.GetCurrentSession();
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}

		}

		protected static SessionFactoryProvider GetProviderBD()
		{
			if (SessionFactoryProvider == null)
			{
				if (Engine == "SQLITEINMEMORY")
					SessionFactoryProvider = new SessionFactoryProviderSQLiteInMemory();
				else if (Engine == "SQLITE")
				{
					SessionFactoryProvider = new SessionFactoryProviderSQLite();
					SessionFactoryProvider.CN = ConnectionString;
				}
				else if (Engine == "SQLSERVER")
				{
					SessionFactoryProvider = new SessionFactoryProviderSQLServer();
					SessionFactoryProvider.CN = ConnectionString;
				}
				else
					throw new Exception("Te la mandaste con el sql provider");

				SessionFactoryProvider.Initialize(HTTPContext);
			}
			//optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

			return SessionFactoryProvider;
		}

		public static T Load(int id)
		{
			return Session.Load<T>(id);
		}
		
		public static IQueryable<T> Get(Expression<Func<T, bool>> predicate)
		{
			return GetAll().Where(predicate);
		}

		public static T GetById(Expression<Func<T, bool>> predicate)
		{
			List<T> listaResultado = GetAll().Where(predicate).ToList<T>();
			if (listaResultado.Count > 0)
				return listaResultado.FirstOrDefault<T>();
			return default(T);
		}

		public static void Delete(Expression<Func<T, bool>> predicate)
		{
			T obj = GetAll().Where(predicate).First<T>();

			ITransaction trans = null;

			try
			{
				trans = Session.BeginTransaction();
				Session.Delete(obj);
				trans.Commit();
			}
			catch (Exception ex)
			{
				trans.Rollback();
				throw ex;
			}
		}

        public static void Delete(T entity)
        {
			Session.Delete(entity);
			Session.Flush();
			return;
        }

		public static IEnumerable<T> SaveOrUpdateAll(params T[] entities)
		{
			foreach (var entity in entities)
			{
				Session.SaveOrUpdate(entity);
			}

			return entities;
		}

        public static T Update(T entity)
        {
            try
            {
                Session.Update(entity);
                Session.Flush();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entity;
        }

		public static T SaveOrUpdate(T entity)
		{
			ITransaction trx = null;

			try
			{
				trx = Session.BeginTransaction();
				Session.SaveOrUpdate(entity);
				Session.Flush();
				trx.Commit();
			}
			catch (Exception ex)
			{
				trx.Rollback();
				throw ex;
			}

			return entity;
		}

        public static T SaveOrUpdateWithoutFlush(T entity)
        {
            Session.SaveOrUpdate(entity);
            return entity;
        }
       

		public static IQueryable<T> GetAll()
		{
			return Session.Query<T>();
		}

        public static void BeginTransaction()
        {
			if (transaction == null || !transaction.IsActive)
				transaction = Session.BeginTransaction();
        }

        public static void CommitTransaction()
        {

            if (transaction != null && transaction.IsActive)
                transaction.Commit();
        }

		public static void RollbackTransaction()
		{
			if (transaction != null && transaction.IsActive)
				transaction.Rollback();
		}

		public static bool Contains(T entity)
		{
			return Session.Contains(entity);
		}

		public static void Flush()
		{
			Session.Flush();
		}

		public static void ExecuteHQL(string hql)
		{
			Session.CreateQuery(hql).ExecuteUpdate();
		}

        public static DateTime GetDate()
        {
            var query = Session.CreateSQLQuery("SELECT Getdate();");
            DateTime results = (DateTime)query.UniqueResult();

            return results;
        }

		public static IList<T> RetrieveAll()
		{
			return RetrieveAll(null);
		}

		public static IList<T> RetrieveAll(Expression<Func<T, bool>> predicate)
		{
			IQueryOver<T> targetObjects;
			if (predicate != null)
				targetObjects = Session.QueryOver<T>().Where(predicate);
			else
				targetObjects = Session.QueryOver<T>();
			IList<T> itemList = targetObjects.List<T>();
			return itemList;
		}

		public static object ExecuteSQLQueryUniqueResult(string sql)
		{
			ISQLQuery sqlQuery = Session.CreateSQLQuery(sql);
			return sqlQuery.UniqueResult();
		}

		//public static DataSet ExecuteSQLQueryDataSet(string sql)
		//{
		//	using (SysNet sysnet = new SysNet(ProviderType.SqlServer, Session.Connection))
		//	{
		//		DataSet ds = sysnet.DB.ExecuteReturnDS(sql);
		//		return ds;
		//	}
		//}

	}
}
