
using System;

namespace XELASOPORTE
{
    public class Laptop : Equipo
    {
        private int memoriaRAM;

        public int MemoriaRAM
        {
            get { return memoriaRAM; }
            set { memoriaRAM = value; }
        }

        public Laptop(string codigo, string numeroSerie, string marca,
            string modelo, Cliente propietario, string estadoFisico,
            string accesorios, int memoriaRAM)
            : base(codigo, numeroSerie, marca, modelo, propietario,
                  estadoFisico, accesorios)
        {
            this.memoriaRAM = memoriaRAM;
        }

        public override double CalcularCostoRevision()
        {
            return 75;
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine("Tipo de equipo: Laptop");
            base.MostrarInformacion();
            Console.WriteLine("Memoria RAM: " + memoriaRAM + " GB");
        }
    }
}
