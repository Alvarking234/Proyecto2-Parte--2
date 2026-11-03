
using System;

namespace XELASOPORTE
{
    public class Cliente
    {
        private string codigo;
        private string nombre;
        private string telefono;
        private string correo;
        private string tipoCliente;
        private int solicitudes;

        public string Codigo { get { return codigo; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Telefono { get { return telefono; } set { telefono = value; } }
        public string Correo { get { return correo; } set { correo = value; } }
        public string TipoCliente { get { return tipoCliente; } set { tipoCliente = value; } }
        public int Solicitudes { get { return solicitudes; } }

        public Cliente(string codigo, string nombre, string telefono,
            string correo, string tipoCliente)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.telefono = telefono;
            this.correo = correo;
            this.tipoCliente = tipoCliente;
            solicitudes = 0;
        }

        public void RegistrarSolicitud()
        {
            solicitudes++;
        }

        public void ActualizarDatos(string telefono, string correo)
        {
            this.telefono = telefono;
            this.correo = correo;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine("Codigo: " + codigo);
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("Telefono: " + telefono);
            Console.WriteLine("Correo: " + correo);
            Console.WriteLine("Tipo de cliente: " + tipoCliente);
            Console.WriteLine("Solicitudes: " + solicitudes);
        }
    }
}
