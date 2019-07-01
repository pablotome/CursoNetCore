using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public Profesor(string nombre, string apellido) : base(nombre, apellido)
        {
            dicta = new List<Materia>();
        }


        public override string DarInformacion()
        {
            return $"Nombre: {nombre} - Apellido: {apellido} - Materias que dicta: {string.Join('|', dicta.Select(m => m.Nombre))}";
        }

        public override async Task CargarMaterias()
        {
            await CargarMateriasAsync();
        }

        protected override async Task CargarMateriasAsync()
        {
            await Task.Run(() => {
                dicta.Add(new Materia("Matematica 2", 4));
                dicta.Add(new Materia("Lengua 2", 5));
                dicta.Add(new Materia("Ingles 2", 3));
                dicta.Add(new Materia("Geografia 2", 2));
                dicta.Add(new Materia("Computación 2", 2));
                dicta.Add(new Materia("Quimica 2", 3));
                dicta.Add(new Materia("Fisica 2", 2));
                dicta.Add(new Materia("Historia 2", 5));   
            });
        }
        public override event MateriaExiste EventoMateriaExiste;
        public override void CargarMateria(Materia materia)
        {
            if (dicta.Any(x => x.Nombre == materia.Nombre))
                EventoMateriaExiste(this, materia);
            else
                dicta.Add(materia);
        }

        public override string MensajeMateriaExistente(Materia materia)
        {
            return $"El profesor {this.Nombre} {this.Apellido} ya dicta la materia {materia.Nombre}";
        }

        public override int CantidadMaterias{
            get {
                return dicta.Count;
            }
        }


    }
}