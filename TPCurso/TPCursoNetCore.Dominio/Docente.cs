using System;
using System.Collections.Generic;
using FluentNHibernate.Mapping;

namespace TPCursoNetCore.Dominio
{
	public class Docente : Persona
	{
		public virtual int CodDocente { get { return base.CodPersona; } set { base.CodPersona = value; } }
		public virtual int AnioInicio { get; set; }
		public virtual IList<Materia> MateriasDicta { get; set; }

		public Docente()
		{
			MateriasDicta = new List<Materia>();
		}

	}

	public class DocenteMap : SubclassMap<Docente>
	{
		public DocenteMap()
		{
			Table("Docente");
			KeyColumn("CodDocente");

			Map(d => d.AnioInicio);

			HasManyToMany(d => d.MateriasDicta)
							.Table("Dicta")
							.Cascade.SaveUpdate()
							.Inverse()
							.ParentKeyColumn("CodDocente")
							.ChildKeyColumn("CodMateria");
		}
	}
}
