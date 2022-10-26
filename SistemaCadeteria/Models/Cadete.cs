namespace SistemaCadeteria.Models
{
    public class Cadete
    {
        public string id, nombre, direccion, telefono;

        public string verId()
        {
            return this.id;
        }

        public string verNombre()
        {
            return this.nombre;
        }

        public string verDireccion()
        {
            return this.direccion;
        }

        public string verTelefono()
        {
            return this.telefono;
        }

        public void asignarId(string id)
        {
            this.id = id;
        }

        public void asignarNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public void asignarDireccion(string direccion)
        {
            this.direccion = direccion;
        }

        public void asignarTelefono(string telefono)
        {
            this.telefono = telefono;
        }

        public void jornalAcobrar()
        {

        }
    }
}
