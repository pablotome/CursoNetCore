using System;

namespace POO
{
    public class Coche : ITestInterface
    {
        public string Patente;
        public string Color;
        public string Marca;
        public string Modelo;
        protected double velocidad = 0;

        public double Velocidad { get => velocidad; /*set => velocidad = value;*/ }

        public Coche(string patente, string color, string marca, string modelo)
        {
            this.Patente = patente;
            this.Color = color;
            this.Marca = marca;
            this.Modelo = modelo;
            this.velocidad = 0;
        }

        public virtual void Acelerar(double cantidad)
        {
            Console.WriteLine($"Incrementando la velocidad en {cantidad} km/h");
            this.velocidad += cantidad;
            //Console.WriteLine($"Velocidad actual {this.Velocidad} km/h");
        }

        public void Girar(double cantidad)
        {
            Console.WriteLine($"Girando el coche en {cantidad} grados.");
        }

        public void Frenar(double cantidad)
        {
            Console.WriteLine($"Reduciendo la velocidad en {cantidad} km/h");
            this.velocidad -= cantidad;
            //Console.WriteLine($"Velocidad actual {this.Velocidad} km/h");
        }

        public virtual void Estacionar()
        {
            Console.WriteLine("Estacionando el coche en modo automático normal");
            velocidad = 0;
        }

        public string GetFullDescription()
        {
            return this.Patente + " - " + this.Marca + " - " + this.Modelo;
        }
    }
}