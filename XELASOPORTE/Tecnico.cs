
using System;

namespace XELASOPORTE
{
    public class Tecnico
    {
        private string codigo;
        private string nombre;
        private string especialidad;
        private bool disponible;
        private int trabajosActivos;
        private int serviciosFinalizados;
        private double calificacionPromedio;
        private double sumaCalificaciones;
        private int cantidadCalificaciones;

        public string Codigo { get { return codigo; } }
        public string Nombre { get { return nombre; } }
        public string Especialidad { get { return especialidad; } }
        public bool Disponible { get { return disponible; } }
        public int TrabajosActivos { get { return trabajosActivos; } }
        public int ServiciosFinalizados { get { return serviciosFinalizados; } }
        public double CalificacionPromedio { get { return calificacionPromedio; } }

        public Tecnico(string codigo, string nombre, string especialidad)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.especialidad = especialidad;
            disponible = true;
            trabajosActivos = 0;
            serviciosFinalizados = 0;
            calificacionPromedio = 0;
            sumaCalificaciones = 0;
            cantidadCalificaciones = 0;
        }

        public bool PuedeRecibirTrabajo()
        {
            return trabajosActivos < 3;
        }

        public void AsignarTrabajo()
        {
            if (PuedeRecibirTrabajo())
            {
                trabajosActivos++;
                disponible = trabajosActivos < 3;
            }
        }

        public void FinalizarTrabajo()
        {
            if (trabajosActivos > 0)
            {
                trabajosActivos--;
                serviciosFinalizados++;
                disponible = true;
            }
        }

        public void RegistrarCalificacion(double calificacion)
        {
            if (calificacion >= 1 && calificacion <= 5)
            {
                sumaCalificaciones += calificacion;
                cantidadCalificaciones++;
                calificacionPromedio =
                    sumaCalificaciones / cantidadCalificaciones;
            }
        }

        public void MostrarInformacion()
        {
            Console.WriteLine("Codigo: " + codigo);
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("Especialidad: " + especialidad);
            Console.WriteLine("Disponible: " + disponible);
            Console.WriteLine("Trabajos activos: " + trabajosActivos);
            Console.WriteLine("Servicios finalizados: " + serviciosFinalizados);
            Console.WriteLine("Calificacion promedio: " + calificacionPromedio);
        }
    }
}
