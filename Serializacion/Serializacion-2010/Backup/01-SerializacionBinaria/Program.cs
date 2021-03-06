using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace SerializacionBinaria
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creo un objeto de tipo Dato
            Dato dato = new Dato("Juan", 15, 22222222, "Juancho");

            //Creo un BinaryFormatter para serializar a Binario
            BinaryFormatter ser = new BinaryFormatter();

            //Creo un FileStream para guardar la info
            //Indico que voy a crear el archivo
            FileStream fs = new FileStream("C:\\Dato.dat", FileMode.Create);
            
            Console.WriteLine("Serializando a binario...");
            Console.ReadLine();

            try
            {
                //Utilizo el método Serialize para serializar a Binario
                ser.Serialize(fs, dato);
            }

            catch (SerializationException e)
            {
                Console.WriteLine("Falló la serialización. Razones: " + e.Message);

            }
            catch (Exception e)
            {
                Console.WriteLine("Se ha provocado un error: " + e.Message);
            }
            finally
            {
                fs.Close();
            }

            Console.WriteLine("Deserializando....");
            Console.ReadLine();

            //Creo un FileStream para leer la info
            //Indico que voy a abrir el archivo
            FileStream fst = new FileStream("C:\\Dato.dat", FileMode.Open);
            try
            {

                Dato aux;

                //Utilizo el método Deserialize para recuperar la info
                //'Casteo' a Dato, ya que Deserialize retorna un Object
                aux = (Dato)ser.Deserialize(fst);

                Console.WriteLine(aux.ToString());
                
                Console.ReadLine();
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Falló la deserialización. Razones: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Se ha provocado un error: " + e.Message);
            }
            finally
            {
                fst.Close();
                Console.WriteLine("Pulse una tecla para finalizar...");
                Console.ReadLine();
            }
        }
    }
}
