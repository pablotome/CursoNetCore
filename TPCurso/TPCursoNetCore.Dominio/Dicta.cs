using FluentNHibernate.Mapping;

namespace TPCursoNetCore.Dominio
{
	public class Dicta
	{
		public virtual int CodDicta { get; set; }
		public virtual Docente Docente { get; set; }
		public virtual Materia Materia { get; set; }
	}

	public class DictaMap : ClassMap<Dicta>
	{
		public DictaMap()
		{
			Table("Dicta");

			Id(d => d.CodDicta).GeneratedBy.Identity();
			References(d => d.Docente).Column("CodDocente");
			References(d => d.Materia).Column("CodMateria");
		}
	}
}
