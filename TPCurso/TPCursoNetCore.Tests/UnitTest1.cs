using System;
using System.Linq;
using Xunit;
using TPCursoNetCore.Dominio;
using TPCursoNetCore.Servicios;
using NHibernate;


namespace TPCursoNetCore.Tests
{
	public class UnitTest1 : IDisposable
    {
		private ISession session;

		public UnitTest1()
		{
			// Do "global" initialization here; Only called once.
			SessionFactoryProviderSQLiteInMemory.Instance.Initialize(false);
			session = SessionFactoryProviderSQLiteInMemory.Instance.OpenSession();
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

			session.SaveOrUpdate(alumno);

			alumno = session.Query<Alumno>().Where<Alumno>(a => a.Nombre == "Pablo").FirstOrDefault<Alumno>();

			Assert.NotNull(alumno);
			Assert.Equal("Pablo", alumno.Nombre);
		}

		[Fact]
		public void Test2()
		{
			Materia materia = new Materia() {
				Nombre = "Matematica",
				CargaHoraria = 4
			};

			//session.SaveOrUpdate(materia);

			Docente docente = new Docente() {
				Nombre = "Valeria", 
				Apellido = "Morelli", 
				FechaNacimiento = new DateTime(1976, 6, 26),
				AnioInicio = 1999
			};

			materia.DocentesDictan.Add(docente);
			docente.MateriasDicta.Add(materia);

			ITransaction trx = session.BeginTransaction();
			session.SaveOrUpdate(docente);
			trx.Commit();

			docente = session.Query<Docente>().Where<Docente>(d => d.Nombre == "Valeria").FirstOrDefault<Docente>();

			materia = session.Query<Materia>().Where<Materia>(m => m.Nombre == "Matematica").FirstOrDefault<Materia>();

			Assert.NotNull(docente);
			Assert.Equal("Valeria", docente.Nombre);
		}

		public void Dispose()
		{
			if (session != null)
			{
				session.Dispose();
				SessionFactoryProviderSQLiteInMemory.Instance.Dispose();
			}

		}

		protected ISession Session
		{
			get { return session; }
		}
	}
}
