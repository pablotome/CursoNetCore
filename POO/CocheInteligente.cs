using System;

namespace POO
{
    public class CocheInteligente : Coche
    {
        public CocheInteligente(string patente, string color, string marca, string modelo) 
            : base(patente, color, marca, modelo)
        {

        }

        public override void Estacionar()
        {
            Console.WriteLine("Estacionando el coche en modo automático inteligente");
            velocidad = 0;
        }

        public override void Acelerar(double cantidad)
        {
            Console.WriteLine($"Accionando mecanismo avanzado de aceleracion");
            Console.WriteLine($"Incrementando la velocidad en {cantidad} km/h");
            this.velocidad += cantidad;
            //Console.WriteLine($"Velocidad actual {this.Velocidad} km/h");
        }
    }
}