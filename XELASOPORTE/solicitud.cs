
using System;
using System.Collections.Generic;

namespace XELASOPORTE
{
    public class Solicitud
    {
        private string codigo;
        private Cliente cliente;
        private Equipo equipo;
        private Tecnico tecnico;
        private string descripcionProblema;
        private string prioridad;
        private string estado;
        private DateTime fechaRegistro;
        private string diagnostico;
        private string accionesRealizadas;
        private double costoManoObra;
        private double costoRepuestos;
        private Stack<string> historial;
        private List<Repuesto> repuestos;

        public string Codigo { get { return codigo; } }
        public Cliente Cliente { get { return cliente; } }
        public Equipo Equipo { get { return equipo; } }
        public Tecnico Tecnico { get { return tecnico; } }
        public string DescripcionProblema { get { return descripcionProblema; } }
        public string Prioridad { get { return prioridad; } }
        public string Estado { get { return estado; } }
        public DateTime FechaRegistro { get { return fechaRegistro; } }
        public string Diagnostico { get { return diagnostico; } }
        public string AccionesRealizadas { get { return accionesRealizadas; } }
        public double CostoManoObra
        {
            get { return costoManoObra; }
            set
            {
                if (value >= 0)
                    costoManoObra = value;
            }
        }
        public double Total { get { return CalcularTotal(); } }
        public List<Repuesto> Repuestos { get { return repuestos; } }

        public Solicitud(string codigo, Cliente cliente, Equipo equipo,
            string descripcionProblema, string prioridad)
        {
            this.codigo = codigo;
            this.cliente = cliente;
            this.equipo = equipo;
            tecnico = new Tecnico("", "Sin asignar", "");
            this.descripcionProblema = descripcionProblema;
            this.prioridad = prioridad;
            estado = "Registrada";
            fechaRegistro = DateTime.Now;
            diagnostico = "";
            accionesRealizadas = "";
            costoManoObra = 0;
            costoRepuestos = 0;
            historial = new Stack<string>();
            repuestos = new List<Repuesto>();
        }

        public void AsignarTecnico(Tecnico tecnico)
        {
            if (tecnico != null)
                this.tecnico = tecnico;
        }

        public bool CambiarEstado(string nuevoEstado)
        {
            if (estado == "Entregada" || estado == "Cancelada")
                return false;

            bool permitido = false;

            if (estado == "Registrada" &&
                (nuevoEstado == "En revision" || nuevoEstado == "Cancelada"))
                permitido = true;

            if (estado == "En revision" &&
                (nuevoEstado == "En reparacion" || nuevoEstado == "Cancelada"))
                permitido = true;

            if (estado == "En reparacion" &&
                (nuevoEstado == "Lista para entrega" || nuevoEstado == "Cancelada"))
                permitido = true;

            if (estado == "Lista para entrega" && nuevoEstado == "Entregada")
                permitido = true;

            if (permitido)
            {
                historial.Push(estado);
                estado = nuevoEstado;
                return true;
            }

            return false;
        }

        public bool DeshacerEstado()
        {
            if (historial.Count > 0 &&
                estado != "Entregada" && estado != "Cancelada")
            {
                estado = historial.Pop();
                return true;
            }

            return false;
        }

        public void MostrarHistorial()
        {
            Console.WriteLine("Estado actual: " + estado);
            Console.WriteLine("Estados anteriores:");

            foreach (string anterior in historial)
                Console.WriteLine(anterior);
        }

        public void RegistrarDiagnostico(string diagnostico)
        {
            if (!string.IsNullOrWhiteSpace(diagnostico))
                this.diagnostico = diagnostico;
        }

        public void RegistrarAcciones(string acciones)
        {
            if (!string.IsNullOrWhiteSpace(acciones))
                accionesRealizadas = acciones;
        }

        public bool AgregarRepuesto(Repuesto repuesto, int cantidad)
        {
            if (repuesto != null && cantidad > 0)
            {
                if (repuesto.UtilizarRepuesto(cantidad))
                {
                    repuestos.Add(repuesto);
                    costoRepuestos += repuesto.PrecioVenta * cantidad;
                    return true;
                }
            }

            return false;
        }

        public double CalcularTotal()
        {
            return equipo.CalcularCostoRevision() +
                costoManoObra + costoRepuestos;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine("Codigo: " + codigo);
            Console.WriteLine("Cliente: " + cliente.Nombre);
            Console.WriteLine("Equipo: " + equipo.Marca + " " + equipo.Modelo);
            Console.WriteLine("Tecnico: " + tecnico.Nombre);
            Console.WriteLine("Problema: " + descripcionProblema);
            Console.WriteLine("Prioridad: " + prioridad);
            Console.WriteLine("Estado: " + estado);
            Console.WriteLine("Fecha: " + fechaRegistro);
            Console.WriteLine("Diagnostico: " + diagnostico);
            Console.WriteLine("Acciones realizadas: " + accionesRealizadas);
            Console.WriteLine("Costo de revision: Q" + equipo.CalcularCostoRevision());
            Console.WriteLine("Mano de obra: Q" + costoManoObra);
            Console.WriteLine("Costo de repuestos: Q" + costoRepuestos);
            Console.WriteLine("Total: Q" + CalcularTotal());
        }
    }
}
