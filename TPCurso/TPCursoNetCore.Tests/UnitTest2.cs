using System;
using System.Linq;
using Xunit;
using TPCursoNetCore.Dominio;
using TPCursoNetCore.Servicios;
using NHibernate;

namespace TPCursoNetCore.Tests
{
	/// <summary>
	/// https://xunit.net/docs/shared-context
	/// https://stackoverflow.com/questions/13829737/run-code-once-before-and-after-all-tests-in-xunit-net
	/// </summary>
	public class DatabaseFixture : IDisposable
	{
		public DatabaseFixture()
		{
			// ... initialize data in the test database ...
			/*SQLiteSessionFactoryProvider.Instance.Initialize();
			session = SQLiteSessionFactoryProvider.Instance.OpenSession();*/

			session = ServicioSistema<object>.Session;
		}

		public void Dispose()
		{
			if (session != null)
			{
				session.Dispose();
				//SessionFactoryProviderSQLite.Instance.Dispose();
			}
		}

		public ISession Session
		{
			get { return session; }
		}

		private ISession session;
	}

	public class UnitTest2 : IClassFixture<DatabaseFixture>
	{
		DatabaseFixture fixture;

		public UnitTest2(DatabaseFixture fixture)
		{
			this.fixture = fixture;
		}

		// ... write tests, using fixture.Db to get access to the SQL Server ...

		protected ISession Session
		{
			get { return fixture.Session; }
		}

		[Fact]
		public void Test1()
		{
			Alumno alumno = new Alumno()
			{
				Nombre = "Pablo",
				Apellido = "Tome",
				FechaNacimiento = new DateTime(1977, 7, 14),
				AnioIngreso = 1990
			};

			alumno = ServicioSistema<Alumno>.SaveOrUpdate(alumno);

			alumno = ServicioSistema<Alumno>.GetById(a => a.Nombre == "Pablo");

			Assert.NotNull(alumno);
			Assert.Equal("Pablo", alumno.Nombre);
		}

		[Fact]
		public void Test2()
		{
			Materia materia = new Materia()
			{
				Nombre = "Matematica",
				CargaHoraria = 4
			};

			//session.SaveOrUpdate(materia);

			Docente docente = new Docente()
			{
				Nombre = "Valeria",
				Apellido = "Morelli",
				FechaNacimiento = new DateTime(1976, 6, 26),
				AnioInicio = 1999
			};

			materia.DocentesDictan.Add(docente);
			docente.MateriasDicta.Add(materia);

			ServicioSistema<Docente>.SaveOrUpdate(docente);
			/*ITransaction trx = Session.BeginTransaction();
			Session.SaveOrUpdate(docente);
			trx.Commit();*/

			docente = ServicioSistema<Docente>.GetById(d => d.Nombre == "Valeria");

			materia = ServicioSistema<Materia>.GetById(m => m.Nombre == "Matematica");

			Assert.NotNull(docente);
			Assert.Equal("Valeria", docente.Nombre);
		}
	}
}
