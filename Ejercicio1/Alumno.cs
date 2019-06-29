using System.Collections.Generic;
using System.Linq;

namespace Ejercicio1
{
    public class Alumno : Persona
    {
        List<Materia> cursa;
        
        public Alumno(string nombre, string apellido, List<Materia> materias) : base(nombre, apellido)
        {
            cursa = new List<Materia>();
            cursa.AddRange(materias);
        }

        public Alumno(string nombre, string apellido) : base(nombre, apellido)
        {
            cursa = new List<Materia>();
        }

        public override string DarInformacion()
        {
            return $"Nombre: {nombre} - Apellido: {apellido} - Materias que cursa: {string.Join('|', cursa.Select(m => m.Nombre))}";
        }

        public void AgregarMateriaCursa()
        {
            if (cursa.)
        }
    }
}