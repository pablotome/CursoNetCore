using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejercicio1
{
    class Program
    {

        static Persona alumno, profesor;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            alumno = new Alumno("Juan", "Perez");
            profesor = new Profesor("Ruben", "Gomez");

            //TimeSpan ts = EjecucionAsincronica();
            TimeSpan ts = EjecucionSincronica();
            Console.WriteLine($"Duración: {ts.TotalMilliseconds}");

            alumno.EventoMateriaExiste += PersonaTieneMateria;
            profesor.EventoMateriaExiste += PersonaTieneMateria;

            string auxNombre;

            do{
                Console.Write("Ingrese el nombre de la materia: ");
                auxNombre = Console.ReadLine();
                alumno.CargarMateria(new Materia(auxNombre, 5));
                Console.WriteLine($"Cantidad de materias: {alumno.CantidadMaterias}");
            }while(auxNombre != string.Empty);
            
            profesor.CargarMateria(new Materia("Lengua 2", 5));



            Console.WriteLine(alumno.DarInformacion());
            Console.WriteLine(profesor.DarInformacion());

        }

        public static void PersonaTieneMateria(Persona persona, Materia materia)
        {
            Console.WriteLine(persona.MensajeMateriaExistente(materia));
        }

        static TimeSpan EjecucionAsincronica()
        {
            DateTime inicio, fin;
            inicio = DateTime.Now;
            Task tarea1 = Task.Run(() => alumno.CargarMaterias());
            Task tarea2 = Task.Run(() => profesor.CargarMaterias());
            Task.WaitAll(tarea1, tarea2);
            fin = DateTime.Now;

            return fin.Subtract(inicio);
        }

        static TimeSpan EjecucionSincronica()
        {
            DateTime inicio, fin;
            inicio = DateTime.Now;
            alumno.CargarMaterias();
            profesor.CargarMaterias();
            fin = DateTime.Now;

            return fin.Subtract(inicio);
        }
    }
}
