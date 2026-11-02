
using System;

public class Cliente
{
    private string codigo;
    private string nombre;
    private string telefono;
    private string correo;
    private string tipoCliente;
    private int cantidadSolicitudes;

    public string Codigo
    {
        get { return codigo; }
    }

    public string Nombre
    {
        get { return nombre; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                nombre = value;
        }
    }

    public string Telefono
    {
        get { return telefono; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                telefono = value;
        }
    }

    public string Correo
    {
        get { return correo; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                correo = value;
        }
    }

    public string TipoCliente
    {
        get { return tipoCliente; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                tipoCliente = value;
        }
    }

    public int CantidadSolicitudes
    {
        get { return cantidadSolicitudes; }
    }

    public Cliente(string codigo, string nombre, string telefono,
        string correo, string tipoCliente)
    {
        this.codigo = codigo;
        this.nombre = nombre;
        this.telefono = telefono;
        this.correo = correo;
        this.tipoCliente = tipoCliente;
        cantidadSolicitudes = 0;
    }

    public void RegistrarSolicitud()
    {
        cantidadSolicitudes++;
    }

    public void ActualizarDatos(string telefono, string correo,
        string tipoCliente)
    {
        if (!string.IsNullOrWhiteSpace(telefono) &&
            !string.IsNullOrWhiteSpace(correo) &&
            !string.IsNullOrWhiteSpace(tipoCliente))
        {
            this.telefono = telefono;
            this.correo = correo;
            this.tipoCliente = tipoCliente;
        }
    }

    public void MostrarInformacion()
    {
        Console.WriteLine("Codigo: " + codigo);
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Telefono: " + telefono);
        Console.WriteLine("Correo: " + correo);
        Console.WriteLine("Tipo de cliente: " + tipoCliente);
        Console.WriteLine("Solicitudes: " + cantidadSolicitudes);
    }
}
