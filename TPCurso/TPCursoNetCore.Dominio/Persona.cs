using System;
using System.Collections.Generic;
using FluentNHibernate.Mapping;

namespace TPCursoNetCore.Dominio
{
	public class Persona
	{
		public virtual int CodPersona { get; set; }
		public virtual string Nombre { get; set; }
		public virtual string Apellido { get; set; }
		public virtual DateTime FechaNacimiento { get; set; }
	}

	public class PersonaMap : ClassMap<Persona>
	{
		public PersonaMap()
		{
			Table("Persona");

			Id(p => p.CodPersona).GeneratedBy.Identity();
			Map(p => p.Nombre);
			Map(p => p.Apellido);
			Map(p => p.FechaNacimiento);
		}
	}
}
