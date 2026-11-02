
using System;
using System.Collections.Generic;

public class SistemaSoporte
{
    private List<Cliente> clientes;
    private List<Tecnico> tecnicos;
    private List<Equipo> equipos;
    private List<Solicitud> solicitudes;
    private List<Repuesto> repuestos;

    private Queue<Solicitud> colaUrgente;
    private Queue<Solicitud> colaNormal;

    private int[,] cargaSemanal;

    public SistemaSoporte()
    {
        clientes = new List<Cliente>();
        tecnicos = new List<Tecnico>();
        equipos = new List<Equipo>();
        solicitudes = new List<Solicitud>();
        repuestos = new List<Repuesto>();

        colaUrgente = new Queue<Solicitud>();
        colaNormal = new Queue<Solicitud>();

        cargaSemanal = new int[0, 7];
    }

    public void RegistrarCliente(Cliente cliente)
    {
        foreach (Cliente c in clientes)
        {
            if (c.Codigo == cliente.Codigo)
            {
                Console.WriteLine("El codigo del cliente ya existe.");
                return;
            }
        }

        clientes.Add(cliente);
        Console.WriteLine("Cliente registrado correctamente.");
    }

    public void RegistrarTecnico(Tecnico tecnico)
    {
        foreach (Tecnico t in tecnicos)
        {
            if (t.Codigo == tecnico.Codigo)
            {
                Console.WriteLine("El codigo del tecnico ya existe.");
                return;
            }
        }

        tecnicos.Add(tecnico);

        int[,] nuevaMatriz = new int[tecnicos.Count, 7];

        for (int i = 0; i < cargaSemanal.GetLength(0); i++)
        {
            for (int j = 0; j < 7; j++)
            {
                nuevaMatriz[i, j] = cargaSemanal[i, j];
            }
        }

        cargaSemanal = nuevaMatriz;

        Console.WriteLine("Tecnico registrado correctamente.");
    }

    public void RegistrarEquipo(Equipo equipo)
    {
        foreach (Equipo e in equipos)
        {
            if (e.Codigo == equipo.Codigo ||
                e.NumeroSerie == equipo.NumeroSerie)
            {
                Console.WriteLine("El codigo o numero de serie ya existe.");
                return;
            }
        }

        equipos.Add(equipo);
        Console.WriteLine("Equipo registrado correctamente.");
    }

    public void RegistrarRepuesto(Repuesto repuesto)
    {
        foreach (Repuesto r in repuestos)
        {
            if (r.Codigo == repuesto.Codigo)
            {
                Console.WriteLine("El codigo del repuesto ya existe.");
                return;
            }
        }

        repuestos.Add(repuesto);
        Console.WriteLine("Repuesto registrado correctamente.");
    }

    public void RegistrarSolicitud(Solicitud solicitud)
    {
        foreach (Solicitud s in solicitudes)
        {
            if (s.Codigo == solicitud.Codigo)
            {
                Console.WriteLine("El codigo de la solicitud ya existe.");
                return;
            }
        }

        if (solicitud.Cliente == null || solicitud.Equipo == null)
        {
            Console.WriteLine("Debe seleccionar un cliente y un equipo.");
            return;
        }

        if (!clientes.Contains(solicitud.Cliente) ||
            !equipos.Contains(solicitud.Equipo))
        {
            Console.WriteLine("El cliente o equipo no esta registrado.");
            return;
        }

        solicitudes.Add(solicitud);

        if (solicitud.Prioridad.ToLower() == "urgente")
        {
            colaUrgente.Enqueue(solicitud);
        }
        else
        {
            colaNormal.Enqueue(solicitud);
        }

        solicitud.Cliente.RegistrarSolicitud();

        Console.WriteLine("Solicitud registrada correctamente.");
    }

    public void MostrarColas()
    {
        Console.WriteLine("SOLICITUDES URGENTES");

        foreach (Solicitud s in colaUrgente)
        {
            Console.WriteLine(s.Codigo + " - " + s.Cliente.Nombre);
        }

        Console.WriteLine("SOLICITUDES NORMALES");

        foreach (Solicitud s in colaNormal)
        {
            Console.WriteLine(s.Codigo + " - " + s.Cliente.Nombre);
        }
    }

    public void AtenderSolicitud()
    {
        if (colaUrgente.Count > 0)
        {
            Solicitud solicitud = colaUrgente.Dequeue();

            Console.WriteLine("Atendiendo solicitud urgente:");
            solicitud.MostrarInformacion();
        }
        else if (colaNormal.Count > 0)
        {
            Solicitud solicitud = colaNormal.Dequeue();

            Console.WriteLine("Atendiendo solicitud normal:");
            solicitud.MostrarInformacion();
        }
        else
        {
            Console.WriteLine("No hay solicitudes pendientes.");
        }
    }

    public void MostrarClientes()
    {
        foreach (Cliente c in clientes)
        {
            c.MostrarInformacion();
            Console.WriteLine("--------------------");
        }
    }

    public void MostrarTecnicos()
    {
        foreach (Tecnico t in tecnicos)
        {
            t.MostrarInformacion();
            Console.WriteLine("--------------------");
        }
    }

    public void MostrarEquipos()
    {
        foreach (Equipo e in equipos)
        {
            e.MostrarInformacion();
            Console.WriteLine("--------------------");
        }
    }

    public void MostrarSolicitudes()
    {
        foreach (Solicitud s in solicitudes)
        {
            s.MostrarInformacion();
            Console.WriteLine("--------------------");
        }
    }

    public void MostrarRepuestos()
    {
        foreach (Repuesto r in repuestos)
        {
            r.MostrarInformacion();
            Console.WriteLine("--------------------");
        }
    }

    public void RegistrarCargaSemanal(int posicionTecnico, int dia)
    {
        if (posicionTecnico >= 0 &&
            posicionTecnico < tecnicos.Count &&
            dia >= 0 && dia < 7)
        {
            cargaSemanal[posicionTecnico, dia]++;
        }
        else
        {
            Console.WriteLine("Posicion o dia incorrecto.");
        }
    }

    public void MostrarCargaSemanal()
    {
        string[] dias = {
            "Lunes", "Martes", "Miercoles",
            "Jueves", "Viernes", "Sabado", "Domingo"
        };

        Console.WriteLine("\nCARGA SEMANAL DE TECNICOS");

        Console.Write("Tecnico\t");

        foreach (string dia in dias)
        {
            Console.Write(dia + "\t");
        }

        Console.WriteLine();

        for (int i = 0; i < tecnicos.Count; i++)
        {
            Console.Write(tecnicos[i].Nombre + "\t");

            for (int j = 0; j < 7; j++)
            {
                Console.Write(cargaSemanal[i, j] + "\t");
            }

            Console.WriteLine();
        }
    }
}
