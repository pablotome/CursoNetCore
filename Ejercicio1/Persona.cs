using System;

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

        public virtual string DarInformacion()
        {
            return string.Empty;
        }
         
        public int Edad{
            get {
                return new TimeSpan(DateTime.Now.Ticks).Subtract(fechaNacimiento.TimeOfDay).Hours;
            }
        }
    }
}