using System;

namespace Excepciones
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while(true)
                {
                    Console.WriteLine("Ingrese un número:");
                    int numero1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese otro número:");
                    int numero2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese la operacion:");
                    string operacion = Console.ReadLine();

                    Calculadora calculadora = new Calculadora();
                    Console.WriteLine($"Resultado: {calculadora.Calcular(numero1, numero2, operacion)}");
                }
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Final del programa");
            }
        }
    }
}
