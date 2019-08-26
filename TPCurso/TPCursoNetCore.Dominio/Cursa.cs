using FluentNHibernate.Mapping;

namespace TPCursoNetCore.Dominio
{
	public class Cursa
	{
		public virtual int CodCursa { get; set; }
		public virtual Alumno Alumno { get; set; }
		public virtual Materia Materia { get; set; }
	}

	public class CursaMap : ClassMap<Cursa>
	{
		public CursaMap()
		{
			Table("Cursa");

			Id(c => c.CodCursa).GeneratedBy.Identity();
			References(c => c.Alumno).Column("CodAlumno");
			References(c => c.Materia).Column("CodMateria");
		}
	}
}
