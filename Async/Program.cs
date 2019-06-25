using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //LlamadaSincronica();
            await LlamadaAsincronicaAsync();
        }

        static async Task LlamadaAsincronicaAsync()
        {
            DateTime inicio, fin;
            inicio = DateTime.Now;
            Console.WriteLine("Iniciando el programa: {0}", inicio.ToString("hh:mm:ss"));

            Task tarea1 = Task.Run(() => GetUsersListAsync());
            Task tarea2 = Task.Run(() => GetRolesListAsync());
            Task.WaitAll(tarea1, tarea2);

            // Console.WriteLine("Obteniendo usuarios...");
            // List<string> usuarios = GetUsersListAsync();
            // Console.WriteLine("Usuarios obtenidos: {0}", usuarios.Count);
            
            // Console.WriteLine("Obteniendo roles...");
            // List<string> roles = GetRolesListAsync();
            // Console.WriteLine("Roles obtenidos: {0}", roles.Count);

            fin = DateTime.Now;
            Console.WriteLine("Finalizando el programa: {0}", fin.ToString("hh:mm:ss"));

            TimeSpan ts = fin - inicio;
            Console.WriteLine("Finalizando el programa: {0}", ts.TotalSeconds);
        }

        public static async Task<List<string>> GetUsersListAsync()
        {
            Console.WriteLine("Obteniendo usuarios desde la BD");
            List<string> usuarios = await GetUserListFromDBAsync();
            return usuarios;
        }
        public static async Task<List<string>> GetRolesListAsync()
        {
            Console.WriteLine("Obteniendo roles desde la BD");
            List<string> roles = await GetRolesListFromDBAsync();
            return roles;
        }
        private static async Task<List<string>> GetUserListFromDBAsync()
        {
            await Task.Delay(5000);
            return new List<string>(new [] { "jperez", "rgomez" });
        }
        private static async Task<List<string>> GetRolesListFromDBAsync()
        {
            await Task.Delay(2000);
            return new List<string>(new [] { "admin", "user" });
        }



















        // static void LlamadaSincronica()
        // {
        //     DateTime inicio, fin;
        //     inicio = DateTime.Now;
        //     Console.WriteLine("Iniciando el programa: {0}", inicio.ToString("hh:mm:ss"));

        //     Console.WriteLine("Obteniendo usuarios...");
        //     List<string> usuarios = GetUsersFromDB();
        //     Console.WriteLine("Usuarios obtenidos: {0}", usuarios.Count);
            
        //     Console.WriteLine("Obteniendo roles...");
        //     List<string> roles = GetRolesFromDB();
        //     Console.WriteLine("Roles obtenidos: {0}", roles.Count);

        //     fin = DateTime.Now;
        //     Console.WriteLine("Finalizando el programa: {0}", fin.ToString("hh:mm:ss"));

        //     TimeSpan ts = fin - inicio;
        //     Console.WriteLine("Finalizando el programa: {0}", ts.TotalSeconds);
        // }
        // public static List<string> GetUsersFromDB()
        // {
        //     Console.WriteLine("Obteniendo usuarios desde la BD");
        //     List<string> usuarios = GetUserListFromDB();
        //     return usuarios;
        // }
        // public static List<string> GetRolesFromDB()
        // {
        //     Console.WriteLine("Obteniendo roles desde la BD");
        //     List<string> roles = GetRolesListFromDB();
        //     return roles;
        // }
        // private static List<string> GetUserListFromDB()
        // {
        //     Thread.Sleep(3000);
        //     return new List<string>(new [] { "jperez", "rgomez" });
        // }
        // private static List<string> GetRolesListFromDB()
        // {
        //     Thread.Sleep(2000);
        //     return new List<string>(new [] { "admin", "user" });
        // }
    }
}
