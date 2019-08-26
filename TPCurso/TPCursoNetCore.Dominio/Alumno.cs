using System;
using System.Collections.Generic;
using FluentNHibernate.Mapping;

namespace TPCursoNetCore.Dominio
{
	public class Alumno : Persona
	{
		public virtual int CodAlumno { get { return base.CodPersona; } set { base.CodPersona = value; } }
		public virtual int AnioIngreso { get; set; }
		public virtual Docente Tutor { get; set; }
		public virtual IList<Materia> MateriasCursa { get; set; }
	}

	public class AlumnoMap : SubclassMap<Alumno>
	{
		public AlumnoMap()
		{
			Table("Alumno");
			KeyColumn("CodAlumno");

			Map(a => a.AnioIngreso);
			References(a => a.Tutor).Column("CodDocenteTutor");

			HasManyToMany(d => d.MateriasCursa)
							.Cascade.All()
							.Inverse()
							.Table("Cursa")
							.ParentKeyColumn("CodAlumno")
							.ChildKeyColumn("CodMateria");
		}
	}
}
