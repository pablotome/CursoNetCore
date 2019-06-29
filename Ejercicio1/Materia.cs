namespace Ejercicio1
{
    public class Materia
    {
        string nombre;
        int horasSemanales;

        public string Nombre { get => nombre; set => nombre = value; }
        public int HorasSemanales { get => horasSemanales; set => horasSemanales = value; }

        public Materia(string nombre, int horasSemanales)
        {
            this.Nombre = nombre;
            this.HorasSemanales = horasSemanales;
        }
    }
}