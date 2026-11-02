
using System;
using System.Collections.Generic;

public class Solicitud
{
    private string codigo;
    private Cliente cliente;
    private Equipo equipo;
    private string descripcionProblema;
    private DateTime fechaRecepcion;
    private string prioridad;
    private string estado;
    private Tecnico tecnico;
    private string diagnostico;
    private List<Repuesto> repuestos;
    private Stack<string> historialEstados;
    private double costoManoObra;
    private double costoRepuestos;
    private double total;

    public string Codigo
    {
        get { return codigo; }
        set { codigo = value; }
    }

    public Cliente Cliente
    {
        get { return cliente; }
        set { cliente = value; }
    }

    public Equipo Equipo
    {
        get { return equipo; }
        set { equipo = value; }
    }

    public string DescripcionProblema
    {
        get { return descripcionProblema; }
        set { descripcionProblema = value; }
    }

    public DateTime FechaRecepcion
    {
        get { return fechaRecepcion; }
    }

    public string Prioridad
    {
        get { return prioridad; }
        set { prioridad = value; }
    }

    public string Estado
    {
        get { return estado; }
    }

    public Tecnico Tecnico
    {
        get { return tecnico; }
        set { tecnico = value; }
    }

    public string Diagnostico
    {
        get { return diagnostico; }
        set { diagnostico = value; }
    }

    public double CostoManoObra
    {
        get { return costoManoObra; }
        set
        {
            if (value >= 0)
                costoManoObra = value;
        }
    }

    public double CostoRepuestos
    {
        get { return costoRepuestos; }
    }

    public double Total
    {
        get { return total; }
    }

    public Solicitud(string codigo, Cliente cliente, Equipo equipo,
        string descripcionProblema, string prioridad)
    {
        this.codigo = codigo;
        this.cliente = cliente;
        this.equipo = equipo;
        this.descripcionProblema = descripcionProblema;
        this.prioridad = prioridad;

        fechaRecepcion = DateTime.Now;
        estado = "Recibida";
        diagnostico = "Pendiente";
        tecnico = null;

        repuestos = new List<Repuesto>();
        historialEstados = new Stack<string>();

        costoManoObra = 0;
        costoRepuestos = 0;
        total = 0;
    }

    public void CambiarEstado(string nuevoEstado)
    {
        bool cambioValido = false;

        if (estado == "Recibida" &&
            (nuevoEstado == "En espera" || nuevoEstado == "Asignada" || nuevoEstado == "Cancelada"))
        {
            cambioValido = true;
        }
        else if (estado == "En espera" &&
            (nuevoEstado == "Asignada" || nuevoEstado == "Cancelada"))
        {
            cambioValido = true;
        }
        else if (estado == "Asignada" &&
            (nuevoEstado == "En diagnóstico" || nuevoEstado == "Cancelada"))
        {
            cambioValido = true;
        }
        else if (estado == "En diagnóstico" &&
            (nuevoEstado == "En reparación" || nuevoEstado == "Cancelada"))
        {
            cambioValido = true;
        }
        else if (estado == "En reparación" &&
            (nuevoEstado == "Lista para entregar" || nuevoEstado == "Cancelada"))
        {
            cambioValido = true;
        }
        else if (estado == "Lista para entregar" &&
            (nuevoEstado == "Entregada" || nuevoEstado == "Cancelada"))
        {
            cambioValido = true;
        }

        if (cambioValido)
        {
            historialEstados.Push(estado);
            estado = nuevoEstado;
            Console.WriteLine("Estado actualizado correctamente.");
        }
        else
        {
            Console.WriteLine("No se puede realizar ese cambio de estado.");
        }
    }

    public void DeshacerEstado()
    {
        if (estado == "Entregada" || estado == "Cancelada")
        {
            Console.WriteLine("No se puede deshacer el estado de esta solicitud.");
        }
        else if (historialEstados.Count > 0)
        {
            estado = historialEstados.Pop();
            Console.WriteLine("Se deshizo el ultimo cambio de estado.");
        }
        else
        {
            Console.WriteLine("No hay cambios para deshacer.");
        }
    }

    public void MostrarHistorial()
    {
        Console.WriteLine("Historial de estados:");

        foreach (string estadoAnterior in historialEstados)
        {
            Console.WriteLine(estadoAnterior);
        }

        Console.WriteLine("Estado actual: " + estado);
    }

    public void RegistrarDiagnostico(string diagnostico)
    {
        this.diagnostico = diagnostico;
    }

    public void AgregarRepuesto(Repuesto repuesto, int cantidad)
    {
        if (repuesto != null && cantidad > 0)
        {
            if (repuesto.Existencia >= cantidad)
            {
                repuestos.Add(repuesto);

                costoRepuestos = costoRepuestos +
                    (repuesto.PrecioVenta * cantidad);

                repuesto.UtilizarRepuesto(cantidad);

                CalcularTotal();
            }
            else
            {
                Console.WriteLine("No hay suficiente existencia.");
            }
        }
        else
        {
            Console.WriteLine("Datos del repuesto incorrectos.");
        }
    }

    public void CalcularTotal()
    {
        total = costoManoObra + costoRepuestos;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine("Codigo: " + codigo);
        Console.WriteLine("Cliente: " + cliente.Nombre);
        Console.WriteLine("Equipo: " + equipo.Marca + " " + equipo.Modelo);
        Console.WriteLine("Problema: " + descripcionProblema);
        Console.WriteLine("Fecha: " + fechaRecepcion);
        Console.WriteLine("Prioridad: " + prioridad);
        Console.WriteLine("Estado: " + estado);

        if (tecnico != null)
        {
            Console.WriteLine("Tecnico: " + tecnico.Nombre);
        }
        else
        {
            Console.WriteLine("Tecnico: Sin asignar");
        }

        Console.WriteLine("Diagnostico: " + diagnostico);
        Console.WriteLine("Costo de mano de obra: Q" + costoManoObra);
        Console.WriteLine("Costo de repuestos: Q" + costoRepuestos);
        Console.WriteLine("Total: Q" + total);
    }
}
