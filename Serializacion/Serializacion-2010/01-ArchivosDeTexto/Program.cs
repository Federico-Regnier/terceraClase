using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ArchivoDeTexto01
{
    class Program
    {
        //Creo una constante con el path del archivo
        private const string FILE_NAME = "C:\\TestFile.txt";

        static void Main(string[] args)
        {
            //Crea una instancia de StreamWriter para escribir un texto a un archivo.
            try
            {
                //El bloque using asegura que el objeto invocar� al m�todo Dispose()
                using (StreamWriter sw = new StreamWriter(@"C:\TestFile.txt"))
                {
                    // Agrega alg�n texto al archivo.

                    sw.Write("Este es el ");
                    sw.WriteLine("Encabezado para el archivo.");
                    sw.WriteLine("-----------------------------");

                    // Objetos arbitrarios tambien pueden ser escritos en el archivo.

                    sw.Write("LA FECHA ES: ");
                    sw.WriteLine(DateTime.Now);
                }

                Console.WriteLine("El archivo fue escrito exitosamente.....");
                Console.ReadLine();

                // Crea una instancia de StreamReader para leer desde el archivo.
                using (StreamReader sr = new StreamReader(FILE_NAME))
                {
                    string line;

                    // Lee y muestra l�neas desde el comienzo del archivo 
                    // hasta el fin del mismo.

                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Datos recuperados desde el archivo.....");
                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Error en el archivo ubicado en {0}", FILE_NAME);
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            finally
            {
                Console.WriteLine("Pulse cualquier tecla para salir...");
                Console.ReadLine();
            }
        }
    }
}
