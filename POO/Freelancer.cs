using System;

namespace POO
{
    public class Freelancer : Empleado
    {
        protected double ValorHora;
        protected int HorasMensuales;
        public Freelancer(int DNI, string nombre, string apellido, double valorHora, int horasMensuales) 
            : base(DNI, nombre, apellido)
        {
            ValorHora = valorHora;
            HorasMensuales = horasMensuales;
        }

        public override double SueldoMensual()
        {
            return this.ValorHora * this.HorasMensuales;
        }
    }
}