using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaCadeteria.Models;

namespace SistemaCadeteria.Controllers
{
    public class CadeteController : Controller
    {
        public ActionResult CrearCadete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearCadete(string nombre , string direccion , string telefono)
        {
            Cadete cadete=new Cadete();
            cadete.asignarNombre(nombre);
            cadete.asignarDireccion(direccion);
            cadete.asignarTelefono(telefono);
            List<Cadete> ListaCadetes = leerCsv();
            string id = Convert.ToString(ListaCadetes.Count());
            cadete.asignarId(id);
            escribirCsv(cadete);
            return RedirectToAction("ListaDeCadetes");
        }

        public ActionResult ListaDeCadetes()
        {
            List<Cadete> ListaCadetes = leerCsv();
            return View(ListaCadetes);
        }

        [HttpGet]
        public ActionResult BorrarCadete(string id)
        {
            List<Cadete> ListaCadetes = leerCsv();
            ListaCadetes.Remove(ListaCadetes.Find(x => x.id == id));

            eliminarCsv();
            crearCsv();

            foreach (Cadete c in ListaCadetes)
            {
                escribirCsv(c);
            }

            return RedirectToAction("ListaDeCadetes");
        }

        private List<Cadete> leerCsv()
        {
            string ruta = "C:\\TallerII\\tl2-tp4-2022-RUIZROCK\\SistemaCadeteria\\Cadeteria.csv";
            List<Cadete> ListaCadetes=new List<Cadete>();
            using (var fileStream = new FileStream(ruta, FileMode.Open/*open,create,append*/))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    string separador = ",";
                    int a = 0;
                    while (!streamReader.EndOfStream)
                    {
                        string[] fila = (streamReader.ReadLine()).Split(separador); //escribe la fila hasta llegar a la ","
                        //id,nombre,direccion,telefono
                        
                        Cadete cadete = new Cadete();
                        cadete.asignarId(fila[0]);
                        cadete.asignarNombre(fila[1]);
                        cadete.asignarDireccion(fila[2]);
                        cadete.asignarTelefono(fila[3]);
                        ListaCadetes.Add(cadete);                    }
                }
            }
            return ListaCadetes;
        }

        public void escribirCsv(Cadete cadete)
        {
            string ruta= "C:\\TallerII\\tl2-tp4-2022-RUIZROCK\\SistemaCadeteria\\Cadeteria.csv";
            using (var fileStream = new FileStream(ruta, FileMode.Append/*open,create,append*/))
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    string contenido = string.Format(cadete.verId() + "," + cadete.verNombre() + "," + 
                        cadete.verDireccion() + "," + cadete.verTelefono());

                    streamWriter.WriteLine(contenido);

                    streamWriter.Close();
                }
            }
        }

        public void eliminarCsv()
        {
            string Archivo= "C:\\TallerII\\tl2-tp4-2022-RUIZROCK\\SistemaCadeteria\\Cadeteria.csv";
            if (System.IO.File.Exists(Archivo))
            {
                System.IO.File.Delete(Archivo);
                Console.WriteLine("Archivo borrado");
            }
            else
            {
                Console.WriteLine("el archivo no existe");
            }
        }

        public void crearCsv()
        {
            string ruta = "C:\\TallerII\\tl2-tp4-2022-RUIZROCK\\SistemaCadeteria\\Cadeteria.csv";
            using (var fileStream = new FileStream(ruta, FileMode.Append/*open,create,append*/)) ;
        }
    }
}
