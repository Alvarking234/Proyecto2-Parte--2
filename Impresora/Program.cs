
using System;

public class Impresora : Equipo
{
    private string tipoImpresion;

    public string TipoImpresion
    {
        get { return tipoImpresion; }
        set { tipoImpresion = value; }
    }

    public Impresora(string codigo, string numeroSerie, string marca,
        string modelo, Cliente propietario, string estadoFisico,
        string accesorios, string tipoImpresion)
        : base(codigo, numeroSerie, marca, modelo, propietario,
              estadoFisico, accesorios)
    {
        this.tipoImpresion = tipoImpresion;
    }

    public override double CalcularCostoRevision()
    {
        return 45;
    }

    public override void MostrarInformacion()
    {
        Console.WriteLine("Tipo de equipo: Impresora");
        base.MostrarInformacion();
        Console.WriteLine("Tipo de impresion: " + tipoImpresion);
    }
}

