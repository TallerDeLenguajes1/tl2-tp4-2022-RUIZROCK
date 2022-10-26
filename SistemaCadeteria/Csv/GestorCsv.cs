namespace SistemaCadeteria.Csv
{
    public class GestorCsv
    {
        public void crearCsv(string ruta)
        {
            using (var fileStream = new FileStream(ruta, FileMode.Append/*open,create,append*/)) ;
        }

        public void leerCsv(string ruta)
        {

            using (var fileStream = new FileStream(ruta, FileMode.Open/*open,create,append*/))
            {
                using (var streamReader = new StreamReader(fileStream))
                {

                    string separador = ",";

                    Console.WriteLine("\n\nResultados:");
                    while (!streamReader.EndOfStream)
                    {
                        string[] fila = (streamReader.ReadLine()).Split(separador); //escribe la fila hasta llegar a la ","

                        string descripcion = fila[0];

                        double precio = Convert.ToDouble(fila[1]);

                        double existencia = Convert.ToDouble(fila[2]);

                        Console.WriteLine("\n\n");

                        Console.WriteLine("Descripcion: " + descripcion + "\nPrecio: " + precio + "\nexistencia: " + existencia);

                        Console.WriteLine("\n\n");
                    }
                }
            }
        }


        //public void escribirCsv(string ruta, datos datos)
        //{
        //    using (var fileStream = new FileStream(ruta, FileMode.Append/*open,create,append*/))
        //    {
        //        using (var streamWriter = new StreamWriter(fileStream))
        //        {
        //            string contenido = string.Format(datos.verDescripcion() + "," + datos.verPrecio() + "," + datos.verExistencia());

        //            streamWriter.WriteLine(contenido);

        //            streamWriter.Close();
        //        }
        //    }
        //}


        public void eliminarCsv(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo))
            {
                File.Delete(nombreArchivo);
                Console.WriteLine("Archivo borrado");
            }
            else
            {
                Console.WriteLine("el archivo no existe");
            }
        }

    }
}
