using System;

namespace Excepciones
{
    public class Calculadora
    {
        public int Calcular(int numero1, int numero2, string operacion)
        {
            throw new ArgumentNullException(nameof(numero1));
            
            if (operacion == "/")
            {
                try
                {
                    return Division(numero1, numero2);
                }
                catch(DivideByZeroException ex)
                {
                    throw new ArithmeticException("Ocurrio una excepcion durante el cálculo", ex);
                }
            }
            else if (operacion == "*")
                return Multiplicacion(numero1, numero2);
            else if (operacion == "-")
                return Resta(numero1, numero2);
            else if (operacion == "+") 
                return Suma(numero1, numero2);
            else
                throw new Exception("Pasame la operación");
        }

        protected int Division(int numero1, int numero2)
        {
            return numero1 / numero2;
        }

        protected int Multiplicacion(int numero1, int numero2)
        {
            return numero1 * numero2;
        }

        protected int Resta(int numero1, int numero2)
        {
            return numero1 - numero2;
        }

        protected int Suma(int numero1, int numero2)
        {
            return numero1 + numero2;
        }
    }
}