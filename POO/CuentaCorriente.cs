using System;

namespace POO
{
    public class CuentaCorriente
    {
        protected double saldo = 0;

        public double Saldo
        {
            get { return saldo; }
        }

        public bool Extraccion(double cantidad)
        {
            if (cantidad < 0) return false;
            this.saldo -= cantidad;
            return true;
        }

        public bool Deposito(double cantidad)
        {
            Console.WriteLine("Ejecutando deposito con double como argumento");
            this.saldo += cantidad;
            return true;
        }

        public bool Deposito(int cantidad)
        {
            Console.WriteLine("Ejecutando deposito con int como argumento");
            this.saldo += cantidad;
            return true;
        }

        public bool Deposito(float cantidad)
        {
            Console.WriteLine("Ejecutando deposito con float como argumento");
            this.saldo += cantidad;
            return true;
        }

        public bool Deposito(long cantidad)
        {
            Console.WriteLine("Ejecutando deposito con long como argumento");
            this.saldo += cantidad;
            return true;
        }

        public static void MetodoEstatico()
        {
            Console.WriteLine("Llamando metodo sin instanciar clase");
        }

        public bool Deposito(double cantidad, double otraCantidad)
        {
            Console.WriteLine("Ejecutando deposito con doble cantidad como argumento");
            this.saldo += cantidad + otraCantidad;
            return true;
        }
    }
}