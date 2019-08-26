using System.Collections.Generic;
using FluentNHibernate.Mapping;

namespace TPCursoNetCore.Dominio
{
	public class Materia
	{
		public virtual int CodMateria { get; set; }
		public virtual string Nombre { get; set; }
		public virtual int CargaHoraria { get; set; }
		public virtual IList<Docente> DocentesDictan { get; set; }

		public Materia()
		{
			DocentesDictan = new List<Docente>();
		}
	}

	public class MateriaMap : ClassMap<Materia>
	{
		public MateriaMap()
		{
			Table("Materia");

			Id(m => m.CodMateria).GeneratedBy.Identity();
			Map(m => m.Nombre);
			Map(m => m.CargaHoraria);

			HasManyToMany(d => d.DocentesDictan)
							.Table("Dicta")
							.ParentKeyColumn("CodMateria")
							.ChildKeyColumn("CodDocente");
		}
	}
}
