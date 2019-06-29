using System.Collections.Generic;
using System.Linq;

namespace Ejercicio1
{
    public class Profesor : Persona
    {
        List<Materia> dicta;
        
        public Profesor(string nombre, string apellido, List<Materia> materias) : base(nombre, apellido)
        {
            dicta = new List<Materia>();
            dicta.AddRange(materias);
        }

        public override string DarInformacion()
        {
            return $"Nombre: {nombre} - Apellido: {apellido} - Materias que dicta: {string.Join('|', dicta.Select(m => m.Nombre))}";
        }

        public void AgregarMateriaDicta()
        {

        }

    }
}