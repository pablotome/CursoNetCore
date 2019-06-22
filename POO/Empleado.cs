using System;

namespace POO
{
    public abstract class Empleado
    {
        public int DNI { get; }
        public string Nombre { get; }
        public string Apellido { get; }

        protected Empleado(int DNI, string nombre, string apellido)
        {
            this.DNI = DNI;
            this.Nombre = nombre;
            this.Apellido = apellido;
        }

        public abstract double SueldoMensual();
    }
}