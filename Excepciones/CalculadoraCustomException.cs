using System;

namespace Excepciones
{
    public class CalculadoraCustomException : Exception
    {
        private static readonly string _defaultMensaje = "Ocurrió un error personalizado";

        public CalculadoraCustomException() 
            : base(_defaultMensaje)
        {
            
        }

        public CalculadoraCustomException(string mensaje) 
            : base(mensaje)
        {
            
        }

        public CalculadoraCustomException(string mensaje, Exception innerException) 
            : base(mensaje, innerException)
        {
            
        }
    }
}