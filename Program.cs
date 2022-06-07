using System;
using System.IO;   

namespace tp8
{
    class Program
    {
        public static void Main(string[] args)
        {   
            string path = "";

            do
            {
                Console.WriteLine("Escribir el path de una carpeta para listar su contenido");
                path = Console.ReadLine();

                if (!Directory.Exists(path))
                {
                    Console.Clear();
                    Console.WriteLine("Ese path no existe!...\n\nPresione ENTER para intentar con otro!");
                    Console.ReadLine();
                }
            } while (!Directory.Exists(path));

            string[] directorio = Directory.GetFiles(path);
            var Archivo = new Archivos();
            string[] separado;
            int id = 0;

            foreach (var archivo in directorio)
            {
                separado = archivo.Split('\\','.');
                Archivo.NumeroDeRegistro = id;
                Archivo.Nombre = separado[5];
                Archivo.Extension = separado[6];
                Console.WriteLine((id+1) + ") " + separado[5] + "." + separado[6]);
                id++;
            }
        }
    }

    class Archivos
    {
        int numeroDeRegistro;
        string nombre = "";
        string extension = "";

        public int NumeroDeRegistro{get => numeroDeRegistro; set => numeroDeRegistro = value; }
        public string Nombre{get => nombre; set => nombre = value; }
        public string Extension{get => extension; set => extension = value; }
    }
}