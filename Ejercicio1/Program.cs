using System;
using System.Collections.Generic;

namespace Ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<Materia> materiasCursa = new List<Materia>();
            List<Materia> materiasDicta = new List<Materia>();

            materiasCursa.Add(new Materia("Matematica", 4));
            materiasCursa.Add(new Materia("Lengua", 5));
            materiasCursa.Add(new Materia("Ingles", 3));
            materiasCursa.Add(new Materia("Geografia", 2));
            
            materiasDicta.Add(new Materia("Computación", 2));
            materiasDicta.Add(new Materia("Quimica", 3));
            materiasDicta.Add(new Materia("Fisica", 2));
            materiasDicta.Add(new Materia("Historia", 5));


            Persona alumno = new Alumno("Juan", "Perez", materiasCursa);
            Persona profesor = new Profesor("Ruben", "Gomez", materiasDicta);

            Console.WriteLine(alumno.DarInformacion());
            
            Console.WriteLine(profesor.DarInformacion());





        }
    }
}
