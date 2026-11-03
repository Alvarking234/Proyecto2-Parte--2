
using System;

namespace XELASOPORTE
{
    public class Equipo
    {
        protected string codigo;
        protected string numeroSerie;
        protected string marca;
        protected string modelo;
        protected Cliente propietario;
        protected string estadoFisico;
        protected string accesorios;

        public string Codigo { get { return codigo; } }
        public string NumeroSerie { get { return numeroSerie; } }
        public string Marca { get { return marca; } }
        public string Modelo { get { return modelo; } }
        public Cliente Propietario { get { return propietario; } }
        public string EstadoFisico { get { return estadoFisico; } }
        public string Accesorios { get { return accesorios; } }

        public Equipo(string codigo, string numeroSerie, string marca,
            string modelo, Cliente propietario, string estadoFisico,
            string accesorios)
        {
            this.codigo = codigo;
            this.numeroSerie = numeroSerie;
            this.marca = marca;
            this.modelo = modelo;
            this.propietario = propietario;
            this.estadoFisico = estadoFisico;
            this.accesorios = accesorios;
        }

        public virtual double CalcularCostoRevision()
        {
            return 50;
        }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine("Codigo: " + codigo);
            Console.WriteLine("Numero de serie: " + numeroSerie);
            Console.WriteLine("Marca: " + marca);
            Console.WriteLine("Modelo: " + modelo);
            Console.WriteLine("Propietario: " + propietario.Nombre);
            Console.WriteLine("Estado fisico: " + estadoFisico);
            Console.WriteLine("Accesorios: " + accesorios);
            Console.WriteLine("Costo de revision: Q" + CalcularCostoRevision());
        }
    }
}
