using System;

namespace POO
{
    class Program
    {
        
        static void Main(string[] args)
        {
            A claseA1 = new C();
            claseA1.F();

            A claseA2 = new D();
            claseA2.F();

            //MainCuenta(args);

            Empleado empleado = new EmpleadoFullTime(12345, "Juan", "Perez", 30000);
            Console.WriteLine($"El sueldo de {empleado.Apellido} es de ${empleado.SueldoMensual()}");

            Empleado empleadoFL = new Freelancer(23456, "Luis", "Lopez", 250, 80);
            Console.WriteLine($"El sueldo de {empleadoFL.Apellido} es de ${empleadoFL.SueldoMensual()}");

        }
        
        
        static void MainCuenta(string[] args)
        {
            //MainCoche();

            CuentaCorriente.MetodoEstatico();

            // CuentaCorriente cuenta = new CuentaCorriente();
            // cuenta.Deposito(200.55);
            // Console.WriteLine($"El saldo de la cuenta es de {cuenta.Saldo}");
            // cuenta.Deposito(200.55, 600);
            // Console.WriteLine($"El saldo de la cuenta es de {cuenta.Saldo}");
            // cuenta.Deposito(75.89F);
            // Console.WriteLine($"El saldo de la cuenta es de {cuenta.Saldo}");
            // cuenta.Deposito(10);
            // Console.WriteLine($"El saldo de la cuenta es de {cuenta.Saldo}");
            // cuenta.Deposito(200l);
            // Console.WriteLine($"El saldo de la cuenta es de {cuenta.Saldo}");
            //cuenta.Saldo
        }
        
        static void MainCoche(string[] args)
        {
            //Coche coche = new Coche("AOW 689", "Blanco", "Ford", "Fiesta");
            //CocheInteligente coche = new CocheInteligente("HWW 215", "Azul", "Honda", "Civic");
            Coche coche = new CocheInteligente("HWW 215", "Azul", "Honda", "Civic");

            Console.WriteLine("Los datos de mi choche son:");
            Console.WriteLine($"Marca: {coche.Marca}");
            Console.WriteLine($"Color: {coche.Color}");
            Console.WriteLine($"Patente: {coche.Patente}");
            Console.WriteLine($"Modelo: {coche.Modelo}");

            coche.Acelerar(100);
            Console.WriteLine($"La velocidad actual es de {coche.Velocidad} km/h.");
            
            coche.Frenar(75);
            Console.WriteLine($"La velocidad actual es de {coche.Velocidad} km/h.");

            coche.Girar(45);

            coche.Estacionar();
            Console.WriteLine($"La velocidad actual es de {coche.Velocidad} km/h.");

        }
 

    }
}
