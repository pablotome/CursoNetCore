using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return $"Nombre: {nombre} - Apellido: {apellido} - Materias que cursa: {string.Join('\n', cursa.Select(m => m.Nombre))}";
        }

        public override async Task CargarMaterias()
        {
            await CargarMateriasAsync();
        }

        protected override async Task CargarMateriasAsync()
        {
            await Task.Run(() => {
                cursa.Add(new Materia("Matematica", 4));
                cursa.Add(new Materia("Lengua", 5));
                cursa.Add(new Materia("Ingles", 3));
                cursa.Add(new Materia("Geografia", 2));
                cursa.Add(new Materia("Computación", 2));
                cursa.Add(new Materia("Quimica", 3));
                cursa.Add(new Materia("Fisica", 2));
                cursa.Add(new Materia("Historia", 5));
            });
        }
        public override event MateriaExiste EventoMateriaExiste;
        public override void CargarMateria(Materia materia)
        {
            if (cursa.Any(x => x.Nombre == materia.Nombre))
                EventoMateriaExiste(this, materia);
            else
                cursa.Add(materia);
        }
        public override string MensajeMateriaExistente(Materia materia)
        {
            return $"El alumno {this.Nombre} {this.Apellido} ya cursa la materia {materia.Nombre}";
        }

        public override int CantidadMaterias{
            get {
                return cursa.Count;
            }
        }
    }
}