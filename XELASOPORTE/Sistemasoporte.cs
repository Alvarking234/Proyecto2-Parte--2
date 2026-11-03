
using System;
using System.Collections.Generic;

namespace XELASOPORTE
{
    public class SistemaSoporte
    {
        public List<Cliente> Clientes { get; private set; }
        public List<Tecnico> Tecnicos { get; private set; }
        public List<Equipo> Equipos { get; private set; }
        public List<Solicitud> Solicitudes { get; private set; }
        public List<Repuesto> Repuestos { get; private set; }

        private Queue<Solicitud> colaUrgente;
        private Queue<Solicitud> colaNormal;
        private int[] cantidadesPorTipo;
        private int[,] cargaTecnicos;
        private Random aleatorio;

        public SistemaSoporte()
        {
            Clientes = new List<Cliente>();
            Tecnicos = new List<Tecnico>();
            Equipos = new List<Equipo>();
            Solicitudes = new List<Solicitud>();
            Repuestos = new List<Repuesto>();

            colaUrgente = new Queue<Solicitud>();
            colaNormal = new Queue<Solicitud>();

            cantidadesPorTipo = new int[3];
            cargaTecnicos = new int[20, 7];
            aleatorio = new Random();
        }

        public bool RegistrarCliente(Cliente cliente)
        {
            if (cliente == null || BuscarCliente(cliente.Codigo) != null)
                return false;

            Clientes.Add(cliente);
            return true;
        }

        public bool RegistrarTecnico(Tecnico tecnico)
        {
            if (tecnico == null || Tecnicos.Count >= 20 ||
                BuscarTecnico(tecnico.Codigo) != null)
                return false;

            Tecnicos.Add(tecnico);
            return true;
        }

        public bool RegistrarEquipo(Equipo equipo)
        {
            if (equipo == null || BuscarEquipo(equipo.Codigo) != null)
                return false;

            if (equipo.Propietario == null ||
                BuscarCliente(equipo.Propietario.Codigo) == null)
                return false;

            foreach (Equipo existente in Equipos)
            {
                if (existente.NumeroSerie.Equals(
                    equipo.NumeroSerie, StringComparison.OrdinalIgnoreCase))
                    return false;
            }

            Equipos.Add(equipo);

            if (equipo is Laptop)
                cantidadesPorTipo[0]++;
            else if (equipo is ComputadoraEscritorio)
                cantidadesPorTipo[1]++;
            else if (equipo is Impresora)
                cantidadesPorTipo[2]++;

            return true;
        }

        public bool RegistrarRepuesto(Repuesto repuesto)
        {
            if (repuesto == null || BuscarRepuesto(repuesto.Codigo) != null)
                return false;

            Repuestos.Add(repuesto);
            return true;
        }

        public bool RegistrarSolicitud(Solicitud solicitud)
        {
            if (solicitud == null ||
                BuscarSolicitudPorCodigo(solicitud.Codigo) != null)
                return false;

            if (solicitud.Cliente == null || solicitud.Equipo == null)
                return false;

            if (BuscarCliente(solicitud.Cliente.Codigo) == null ||
                BuscarEquipo(solicitud.Equipo.Codigo) == null)
                return false;

            foreach (Solicitud existente in Solicitudes)
            {
                if (existente.Equipo.Codigo.Equals(
                    solicitud.Equipo.Codigo,
                    StringComparison.OrdinalIgnoreCase) &&
                    existente.Estado != "Entregada" &&
                    existente.Estado != "Cancelada")
                    return false;
            }

            Solicitudes.Add(solicitud);
            solicitud.Cliente.RegistrarSolicitud();

            if (solicitud.Prioridad.Equals(
                "Urgente", StringComparison.OrdinalIgnoreCase))
                colaUrgente.Enqueue(solicitud);
            else
                colaNormal.Enqueue(solicitud);

            return true;
        }

        public Cliente BuscarCliente(string codigo)
        {
            foreach (Cliente cliente in Clientes)
            {
                if (cliente.Codigo.Equals(
                    codigo, StringComparison.OrdinalIgnoreCase))
                    return cliente;
            }

            return null;
        }

        public Tecnico BuscarTecnico(string codigo)
        {
            foreach (Tecnico tecnico in Tecnicos)
            {
                if (tecnico.Codigo.Equals(
                    codigo, StringComparison.OrdinalIgnoreCase))
                    return tecnico;
            }

            return null;
        }

        public Equipo BuscarEquipo(string codigo)
        {
            foreach (Equipo equipo in Equipos)
            {
                if (equipo.Codigo.Equals(
                    codigo, StringComparison.OrdinalIgnoreCase))
                    return equipo;
            }

            return null;
        }

        public Repuesto BuscarRepuesto(string codigo)
        {
            foreach (Repuesto repuesto in Repuestos)
            {
                if (repuesto.Codigo.Equals(
                    codigo, StringComparison.OrdinalIgnoreCase))
                    return repuesto;
            }

            return null;
        }

        public Solicitud BuscarSolicitudPorCodigo(string codigo)
        {
            foreach (Solicitud solicitud in Solicitudes)
            {
                if (solicitud.Codigo.Equals(
                    codigo, StringComparison.OrdinalIgnoreCase))
                    return solicitud;
            }

            return null;
        }

        public void MostrarClientes()
        {
            Console.WriteLine("===== CLIENTES REGISTRADOS =====");

            if (Clientes.Count == 0)
            {
                Console.WriteLine("No hay clientes registrados.");
                return;
            }

            foreach (Cliente cliente in Clientes)
            {
                cliente.MostrarInformacion();
                Console.WriteLine("----------------------------");
            }

            Console.WriteLine("Total de clientes: " + Clientes.Count);
        }

        public void MostrarTecnicos()
        {
            Console.WriteLine("===== TECNICOS REGISTRADOS =====");

            if (Tecnicos.Count == 0)
            {
                Console.WriteLine("No hay tecnicos registrados.");
                return;
            }

            foreach (Tecnico tecnico in Tecnicos)
            {
                tecnico.MostrarInformacion();
                Console.WriteLine("----------------------------");
            }

            Console.WriteLine("Total de tecnicos: " + Tecnicos.Count);
        }

        public void MostrarEquipos()
        {
            Console.WriteLine("===== EQUIPOS REGISTRADOS =====");

            if (Equipos.Count == 0)
            {
                Console.WriteLine("No hay equipos registrados.");
                return;
            }

            foreach (Equipo equipo in Equipos)
            {
                equipo.MostrarInformacion();
                Console.WriteLine("----------------------------");
            }

            Console.WriteLine("Total de equipos: " + Equipos.Count);
        }

        public void MostrarSolicitudes()
        {
            Console.WriteLine("===== SOLICITUDES REGISTRADAS =====");

            if (Solicitudes.Count == 0)
            {
                Console.WriteLine("No hay solicitudes registradas.");
                return;
            }

            foreach (Solicitud solicitud in Solicitudes)
            {
                solicitud.MostrarInformacion();
                Console.WriteLine("----------------------------");
            }

            Console.WriteLine("Total de solicitudes: " + Solicitudes.Count);
        }

        public void MostrarRepuestos()
        {
            Console.WriteLine("===== REPUESTOS REGISTRADOS =====");

            if (Repuestos.Count == 0)
            {
                Console.WriteLine("No hay repuestos registrados.");
                return;
            }

            foreach (Repuesto repuesto in Repuestos)
            {
                repuesto.MostrarInformacion();
                Console.WriteLine("----------------------------");
            }

            Console.WriteLine("Total de repuestos: " + Repuestos.Count);
        }

        public void MostrarColas()
        {
            Console.WriteLine("===== COLA DE SOLICITUDES URGENTES =====");

            if (colaUrgente.Count == 0)
                Console.WriteLine("No hay solicitudes urgentes.");

            foreach (Solicitud solicitud in colaUrgente)
            {
                Console.WriteLine("Codigo: " + solicitud.Codigo);
                Console.WriteLine("Cliente: " + solicitud.Cliente.Nombre);
                Console.WriteLine("Estado: " + solicitud.Estado);
                Console.WriteLine("Total: Q" + solicitud.CalcularTotal());
                Console.WriteLine("----------------------------");
            }

            Console.WriteLine("===== COLA DE SOLICITUDES NORMALES =====");

            if (colaNormal.Count == 0)
                Console.WriteLine("No hay solicitudes normales.");

            foreach (Solicitud solicitud in colaNormal)
            {
                Console.WriteLine("Codigo: " + solicitud.Codigo);
                Console.WriteLine("Cliente: " + solicitud.Cliente.Nombre);
                Console.WriteLine("Estado: " + solicitud.Estado);
                Console.WriteLine("Total: Q" + solicitud.CalcularTotal());
                Console.WriteLine("----------------------------");
            }
        }

        public void BuscarClientesPorNombre(string nombre)
        {
            bool encontrado = false;

            foreach (Cliente cliente in Clientes)
            {
                if (cliente.Nombre.IndexOf(
                    nombre, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    cliente.MostrarInformacion();
                    encontrado = true;
                }
            }

            if (!encontrado)
                Console.WriteLine("No se encontraron clientes.");
        }

        public void BuscarSolicitudesPorEstado(string estado)
        {
            bool encontrado = false;

            foreach (Solicitud solicitud in Solicitudes)
            {
                if (solicitud.Estado.Equals(
                    estado, StringComparison.OrdinalIgnoreCase))
                {
                    solicitud.MostrarInformacion();
                    encontrado = true;
                }
            }

            if (!encontrado)
                Console.WriteLine("No se encontraron solicitudes.");
        }

        public void BuscarEquiposPorMarca(string marca)
        {
            bool encontrado = false;

            foreach (Equipo equipo in Equipos)
            {
                if (equipo.Marca.IndexOf(
                    marca, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    equipo.MostrarInformacion();
                    encontrado = true;
                }
            }

            if (!encontrado)
                Console.WriteLine("No se encontraron equipos.");
        }

        private bool EspecialidadCorrecta(Tecnico tecnico, Equipo equipo)
        {
            string especialidad = tecnico.Especialidad.ToLower();

            if (especialidad == "general")
                return true;

            if (equipo is Laptop)
                return especialidad.Contains("laptop");

            if (equipo is Impresora)
                return especialidad.Contains("impresora");

            if (equipo is ComputadoraEscritorio)
                return especialidad.Contains("computadora");

            return false;
        }

        public bool AsignarTecnicoASolicitud(
            string codigoSolicitud, string codigoTecnico)
        {
            Solicitud solicitud = BuscarSolicitudPorCodigo(codigoSolicitud);
            Tecnico tecnico = BuscarTecnico(codigoTecnico);

            if (solicitud == null || tecnico == null)
                return false;

            if (solicitud.Estado == "Entregada" ||
                solicitud.Estado == "Cancelada")
                return false;

            if (solicitud.Tecnico.Codigo != "")
                return false;

            if (!tecnico.PuedeRecibirTrabajo())
                return false;

            if (!EspecialidadCorrecta(tecnico, solicitud.Equipo))
                return false;

            solicitud.AsignarTecnico(tecnico);
            tecnico.AsignarTrabajo();

            int posicion = Tecnicos.IndexOf(tecnico);
            int dia = (int)DateTime.Now.DayOfWeek;

            if (posicion >= 0 && posicion < 20)
                cargaTecnicos[posicion, dia]++;

            return true;
        }

        public bool CambiarEstadoSolicitud(
            string codigoSolicitud, string nuevoEstado)
        {
            Solicitud solicitud = BuscarSolicitudPorCodigo(codigoSolicitud);

            if (solicitud == null)
                return false;

            bool cambio = solicitud.CambiarEstado(nuevoEstado);

            if (cambio &&
                (nuevoEstado == "Entregada" || nuevoEstado == "Cancelada"))
            {
                if (solicitud.Tecnico.Codigo != "")
                    solicitud.Tecnico.FinalizarTrabajo();
            }

            return cambio;
        }

        public bool AgregarRepuestoASolicitud(
            string codigoSolicitud, string codigoRepuesto, int cantidad)
        {
            Solicitud solicitud = BuscarSolicitudPorCodigo(codigoSolicitud);
            Repuesto repuesto = BuscarRepuesto(codigoRepuesto);

            if (solicitud == null || repuesto == null)
                return false;

            if (solicitud.Estado == "Entregada" ||
                solicitud.Estado == "Cancelada")
                return false;

            return solicitud.AgregarRepuesto(repuesto, cantidad);
        }

        public bool RegistrarManoObra(string codigoSolicitud, double costo)
        {
            Solicitud solicitud = BuscarSolicitudPorCodigo(codigoSolicitud);

            if (solicitud == null || costo < 0)
                return false;

            if (solicitud.Estado == "Entregada" ||
                solicitud.Estado == "Cancelada")
                return false;

            solicitud.CostoManoObra = costo;
            return true;
        }

        public bool RegistrarCalificacion(
            string codigoSolicitud, double calificacion)
        {
            Solicitud solicitud = BuscarSolicitudPorCodigo(codigoSolicitud);

            if (solicitud == null || calificacion < 1 || calificacion > 5)
                return false;

            if (solicitud.Estado != "Entregada" ||
                solicitud.Tecnico.Codigo == "")
                return false;

            solicitud.Tecnico.RegistrarCalificacion(calificacion);
            return true;
        }

        public void AtenderSiguienteSolicitud()
        {
            Solicitud solicitud = null;

            while (colaUrgente.Count > 0 && solicitud == null)
            {
                Solicitud siguiente = colaUrgente.Dequeue();

                if (siguiente.Estado == "Registrada")
                    solicitud = siguiente;
            }

            while (colaNormal.Count > 0 && solicitud == null)
            {
                Solicitud siguiente = colaNormal.Dequeue();

                if (siguiente.Estado == "Registrada")
                    solicitud = siguiente;
            }

            if (solicitud == null)
            {
                Console.WriteLine("No hay solicitudes pendientes.");
                return;
            }

            if (CambiarEstadoSolicitud(solicitud.Codigo, "En revision"))
                Console.WriteLine("Solicitud atendida: " + solicitud.Codigo);
            else
                Console.WriteLine("No se pudo atender la solicitud.");
        }

        public void OrdenarSolicitudesPorTotal()
        {
            for (int i = 0; i < Solicitudes.Count - 1; i++)
            {
                for (int j = 0; j < Solicitudes.Count - 1 - i; j++)
                {
                    if (Solicitudes[j].CalcularTotal() >
                        Solicitudes[j + 1].CalcularTotal())
                    {
                        Solicitud temporal = Solicitudes[j];
                        Solicitudes[j] = Solicitudes[j + 1];
                        Solicitudes[j + 1] = temporal;
                    }
                }
            }

            MostrarSolicitudes();
        }

        public void OrdenarTecnicosPorServicios()
        {
            for (int i = 0; i < Tecnicos.Count - 1; i++)
            {
                int menor = i;

                for (int j = i + 1; j < Tecnicos.Count; j++)
                {
                    if (Tecnicos[j].ServiciosFinalizados <
                        Tecnicos[menor].ServiciosFinalizados)
                        menor = j;
                }

                Tecnico temporal = Tecnicos[i];
                Tecnicos[i] = Tecnicos[menor];
                Tecnicos[menor] = temporal;
            }

            MostrarTecnicos();
        }

        public void OrdenarRepuestosPorExistencia()
        {
            int salto = Repuestos.Count / 2;

            while (salto > 0)
            {
                for (int i = salto; i < Repuestos.Count; i++)
                {
                    Repuesto temporal = Repuestos[i];
                    int j = i;

                    while (j >= salto &&
                        Repuestos[j - salto].Existencia > temporal.Existencia)
                    {
                        Repuestos[j] = Repuestos[j - salto];
                        j -= salto;
                    }

                    Repuestos[j] = temporal;
                }

                salto /= 2;
            }

            MostrarRepuestos();
        }

        public void OrdenarSolicitudesPorFecha()
        {
            QuickSort(0, Solicitudes.Count - 1);
            MostrarSolicitudes();
        }

        private void QuickSort(int inicio, int fin)
        {
            if (inicio < fin)
            {
                int posicion = Particionar(inicio, fin);
                QuickSort(inicio, posicion - 1);
                QuickSort(posicion + 1, fin);
            }
        }

        private int Particionar(int inicio, int fin)
        {
            DateTime pivote = Solicitudes[fin].FechaRegistro;
            int i = inicio - 1;

            for (int j = inicio; j < fin; j++)
            {
                if (Solicitudes[j].FechaRegistro <= pivote)
                {
                    i++;

                    Solicitud temporal = Solicitudes[i];
                    Solicitudes[i] = Solicitudes[j];
                    Solicitudes[j] = temporal;
                }
            }

            Solicitud auxiliar = Solicitudes[i + 1];
            Solicitudes[i + 1] = Solicitudes[fin];
            Solicitudes[fin] = auxiliar;

            return i + 1;
        }

        public void OrdenarSolicitudesPorCodigo()
        {
            for (int i = 0; i < Solicitudes.Count - 1; i++)
            {
                for (int j = 0; j < Solicitudes.Count - 1 - i; j++)
                {
                    if (string.Compare(Solicitudes[j].Codigo,
                        Solicitudes[j + 1].Codigo,
                        StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        Solicitud temporal = Solicitudes[j];
                        Solicitudes[j] = Solicitudes[j + 1];
                        Solicitudes[j + 1] = temporal;
                    }
                }
            }
        }

        public Solicitud BuscarSolicitudBinaria(string codigo)
        {
            OrdenarSolicitudesPorCodigo();

            int inicio = 0;
            int fin = Solicitudes.Count - 1;

            while (inicio <= fin)
            {
                int medio = (inicio + fin) / 2;

                int comparacion = string.Compare(
                    Solicitudes[medio].Codigo,
                    codigo,
                    StringComparison.OrdinalIgnoreCase);

                if (comparacion == 0)
                    return Solicitudes[medio];

                if (comparacion < 0)
                    inicio = medio + 1;
                else
                    fin = medio - 1;
            }

            return null;
        }

        public void MostrarCargaTecnicos()
        {
            string[] dias = {
                "Domingo", "Lunes", "Martes", "Miercoles",
                "Jueves", "Viernes", "Sabado"
            };

            Console.WriteLine("=== CARGA DE TECNICOS ===");
            Console.Write("Tecnico\t");

            foreach (string dia in dias)
                Console.Write(dia + "\t");

            Console.WriteLine();

            for (int i = 0; i < Tecnicos.Count && i < 20; i++)
            {
                Console.Write(Tecnicos[i].Nombre + "\t");

                for (int dia = 0; dia < 7; dia++)
                    Console.Write(cargaTecnicos[i, dia] + "\t");

                Console.WriteLine();
            }
        }

        public void MostrarCantidadesPorTipo()
        {
            Console.WriteLine("=== EQUIPOS REGISTRADOS ===");
            Console.WriteLine("Laptops: " + cantidadesPorTipo[0]);
            Console.WriteLine("Computadoras de escritorio: " + cantidadesPorTipo[1]);
            Console.WriteLine("Impresoras: " + cantidadesPorTipo[2]);
        }

        public void MostrarRepuestosBajoStock()
        {
            bool encontrado = false;

            Console.WriteLine("=== REPUESTOS CON STOCK BAJO ===");

            foreach (Repuesto repuesto in Repuestos)
            {
                if (repuesto.TieneStockBajo())
                {
                    repuesto.MostrarInformacion();
                    encontrado = true;
                }
            }

            if (!encontrado)
                Console.WriteLine("No hay repuestos con stock bajo.");
        }

        public void GenerarDatosPrueba()
        {
            if (Clientes.Count > 0 || Tecnicos.Count > 0 ||
                Equipos.Count > 0 || Solicitudes.Count > 0 ||
                Repuestos.Count > 0)
            {
                Console.WriteLine("Ya existen datos registrados.");
                return;
            }

            for (int i = 1; i <= 5; i++)
            {
                Cliente cliente = new Cliente(
                    "C" + i,
                    "Cliente " + i,
                    "5555" + i,
                    "cliente" + i + "@correo.com",
                    "Regular");

                RegistrarCliente(cliente);
            }

            for (int i = 1; i <= 5; i++)
            {
                Tecnico tecnico = new Tecnico(
                    "T" + i,
                    "Tecnico " + i,
                    "General");

                RegistrarTecnico(tecnico);
            }

            for (int i = 1; i <= 5; i++)
            {
                Cliente cliente = Clientes[i - 1];

                Equipo equipo = new Laptop(
                    "E" + i,
                    "SERIE" + i,
                    "Marca " + i,
                    "Modelo " + i,
                    cliente,
                    "Bueno",
                    "Cargador",
                    aleatorio.Next(4, 17));

                RegistrarEquipo(equipo);
            }

            for (int i = 1; i <= 5; i++)
            {
                Repuesto repuesto = new Repuesto(
                    "R" + i,
                    "Repuesto " + i,
                    "Computacion",
                    aleatorio.Next(5, 30),
                    3,
                    aleatorio.Next(20, 100),
                    aleatorio.Next(100, 250));

                RegistrarRepuesto(repuesto);
            }

            for (int i = 1; i <= 5; i++)
            {
                Solicitud solicitud = new Solicitud(
                    "S" + i,
                    Clientes[i - 1],
                    Equipos[i - 1],
                    "Revision general del equipo",
                    i % 2 == 0 ? "Normal" : "Urgente");

                RegistrarSolicitud(solicitud);
            }

            Console.WriteLine("Datos de prueba registrados.");
        }
    }
}
