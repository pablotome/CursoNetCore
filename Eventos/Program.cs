using System;

namespace Eventos
{
    class Program
    {
        static void Main(string[] args)
        {
            Numeros numeros = new Numeros();
            numeros.EventoPar += DeteccionNumeroPar;
            numeros.EventoPar += () => Console.Write($"El numero {numeros.Num} es par");
            numeros.EventoPar += delegate() { Console.Write($"Evento par"); };
            Console.WriteLine("Ingrese un número: ");
            numeros.Num = int.Parse(Console.ReadLine());
        }

        static void DeteccionNumeroPar()
        {
            Console.WriteLine("El numero es par");
        }
    }
}
