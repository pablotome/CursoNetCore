using System;
using System.Threading.Tasks;

namespace Ejercicio1
{
    public abstract class Persona
    {
        protected string nombre;

        protected string apellido;

        protected DateTime fechaNacimiento;

        public Persona(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public abstract string DarInformacion();
         
        public int Edad{
            get {
                return new TimeSpan(DateTime.Now.Ticks).Subtract(fechaNacimiento.TimeOfDay).Hours;
            }
        }

        public string Apellido{
            get {
                return apellido;
            }
        }

        public string Nombre{
            get {
                return nombre;
            }
        }

        public abstract Task CargarMaterias();

        protected abstract Task CargarMateriasAsync();

        public abstract void CargarMateria(Materia materia);

        public delegate void MateriaExiste(Persona persona, Materia materia);
        public abstract event MateriaExiste EventoMateriaExiste;

        public abstract string MensajeMateriaExistente(Materia materia);
    }
}