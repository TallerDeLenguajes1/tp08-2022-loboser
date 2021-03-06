using System;
using System.IO;   

namespace tp8
{
    class Program
    {
        public static void Main(string[] args)
        {   
            string path;
            int numeroDeRegistro;
            string nombre;
            string extension;

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

            string[] archivos = Directory.GetFiles(path);
            string[] separado;

            var lineas = new List<string>();
            string linea;
            int id = 0;

            foreach (var archivo in archivos)
            {
                separado = archivo.Split('\\','.');

                numeroDeRegistro = id;
                nombre = separado[separado.Length-2];
                extension = separado[separado.Length-1];

                linea = numeroDeRegistro + "," + nombre + "," + extension;
                lineas.Add(linea);

                Console.WriteLine((numeroDeRegistro+1) + ") " + nombre + "." + extension);
                id++;
            }

            File.WriteAllLines("index.csv", lineas);
        }
    }
}