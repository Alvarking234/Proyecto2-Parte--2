
using System;

public class Repuesto
{
    private string codigo;
    private string nombre;
    private string categoria;
    private int existencia;
    private int existenciaMinima;
    private double costoUnitario;
    private double precioVenta;
    private int cantidadUtilizada;

    public string Codigo
    {
        get { return codigo; }
        set { codigo = value; }
    }

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public string Categoria
    {
        get { return categoria; }
        set { categoria = value; }
    }

    public int Existencia
    {
        get { return existencia; }
        set
        {
            if (value >= 0)
                existencia = value;
        }
    }

    public int ExistenciaMinima
    {
        get { return existenciaMinima; }
        set
        {
            if (value >= 0)
                existenciaMinima = value;
        }
    }

    public double CostoUnitario
    {
        get { return costoUnitario; }
        set
        {
            if (value >= 0)
                costoUnitario = value;
        }
    }

    public double PrecioVenta
    {
        get { return precioVenta; }
        set
        {
            if (value >= 0)
                precioVenta = value;
        }
    }

    public int CantidadUtilizada
    {
        get { return cantidadUtilizada; }
    }

    public Repuesto(string codigo, string nombre, string categoria,
        int existencia, int existenciaMinima, double costoUnitario,
        double precioVenta)
    {
        this.codigo = codigo;
        this.nombre = nombre;
        this.categoria = categoria;
        this.existencia = existencia;
        this.existenciaMinima = existenciaMinima;
        this.costoUnitario = costoUnitario;
        this.precioVenta = precioVenta;
        cantidadUtilizada = 0;
    }

    public void UtilizarRepuesto(int cantidad)
    {
        if (cantidad > 0 && cantidad <= existencia)
        {
            existencia = existencia - cantidad;
            cantidadUtilizada = cantidadUtilizada + cantidad;

            Console.WriteLine("Repuesto utilizado correctamente.");
        }
        else
        {
            Console.WriteLine("No hay suficiente existencia.");
        }
    }

    public void MostrarInformacion()
    {
        Console.WriteLine("Codigo: " + codigo);
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Categoria: " + categoria);
        Console.WriteLine("Existencia: " + existencia);
        Console.WriteLine("Existencia minima: " + existenciaMinima);
        Console.WriteLine("Costo unitario: Q" + costoUnitario);
        Console.WriteLine("Precio de venta: Q" + precioVenta);
        Console.WriteLine("Cantidad utilizada: " + cantidadUtilizada);

        if (existencia <= existenciaMinima)
        {
            Console.WriteLine("ALERTA: Existencia baja.");
        }
    }
}
