using System;

namespace POO
{
    public class EmpleadoFullTime : Empleado
    {
        public double Sueldo;
        public EmpleadoFullTime(int DNI, string nombre, string apellido, double sueldo)
            : base(DNI, nombre, apellido)
        {
            Sueldo = sueldo;
        }

        public override double SueldoMensual()
        {
            return Sueldo;
        }
    }
}