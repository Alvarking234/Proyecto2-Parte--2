
using System;

public class ComputadoraEscritorio : Equipo
{
    private string tipoTorre;

    public string TipoTorre
    {
        get { return tipoTorre; }
        set { tipoTorre = value; }
    }

    public ComputadoraEscritorio(string codigo, string numeroSerie,
        string marca, string modelo, Cliente propietario,
        string estadoFisico, string accesorios, string tipoTorre)
        : base(codigo, numeroSerie, marca, modelo, propietario,
              estadoFisico, accesorios)
    {
        this.tipoTorre = tipoTorre;
    }

    public override double CalcularCostoRevision()
    {
        return 65;
    }

    public override void MostrarInformacion()
    {
        Console.WriteLine("Tipo de equipo: Computadora de escritorio");
        base.MostrarInformacion();
        Console.WriteLine("Tipo de torre: " + tipoTorre);
    }
}
