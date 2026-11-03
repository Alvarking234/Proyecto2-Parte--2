
using System;

namespace XELASOPORTE
{
    class Program
    {
        static SistemaSoporte sistema = new SistemaSoporte();

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("          XELATECH SOPORTE");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Gestion de clientes");
                Console.WriteLine("2. Gestion de tecnicos");
                Console.WriteLine("3. Gestion de equipos");
                Console.WriteLine("4. Gestion de solicitudes");
                Console.WriteLine("5. Gestion de repuestos");
                Console.WriteLine("6. Ordenamientos");
                Console.WriteLine("7. Busquedas");
                Console.WriteLine("8. Reportes");
                Console.WriteLine("9. Generar datos de prueba");
                Console.WriteLine("10. Salir");
                Console.Write("Seleccione una opcion: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                    opcion = 0;

                switch (opcion)
                {
                    case 1:
                        MenuClientes();
                        break;
                    case 2:
                        MenuTecnicos();
                        break;
                    case 3:
                        MenuEquipos();
                        break;
                    case 4:
                        MenuSolicitudes();
                        break;
                    case 5:
                        MenuRepuestos();
                        break;
                    case 6:
                        MenuOrdenamientos();
                        break;
                    case 7:
                        MenuBusquedas();
                        break;
                    case 8:
                        MenuReportes();
                        break;
                    case 9:
                        sistema.GenerarDatosPrueba();
                        Pausa();
                        break;
                    case 10:
                        Console.WriteLine("Gracias por utilizar XelaTech Soporte.");
                        break;
                    default:
                        Console.WriteLine("Opcion no valida.");
                        Pausa();
                        break;
                }

            } while (opcion != 10);
        }

        static void MenuClientes()
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("===== GESTION DE CLIENTES =====");
                Console.WriteLine("1. Registrar cliente");
                Console.WriteLine("2. Mostrar clientes");
                Console.WriteLine("3. Regresar");
                Console.Write("Seleccione: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                    opcion = 0;

                switch (opcion)
                {
                    case 1:
                        RegistrarCliente();
                        break;
                    case 2:
                        sistema.MostrarClientes();
                        Pausa();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Opcion no valida.");
                        Pausa();
                        break;
                }

            } while (opcion != 3);
        }

        static void RegistrarCliente()
        {
            Console.WriteLine("===== REGISTRAR CLIENTE =====");

            Console.Write("Codigo: ");
            string codigo = Console.ReadLine() ?? "";

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine() ?? "";

            Console.Write("Telefono: ");
            string telefono = Console.ReadLine() ?? "";

            Console.Write("Correo: ");
            string correo = Console.ReadLine() ?? "";

            Console.Write("Tipo de cliente: ");
            string tipo = Console.ReadLine() ?? "";

            if (!CamposValidos(codigo, nombre, telefono, correo, tipo))
            {
                Console.WriteLine("Todos los campos son obligatorios.");
            }
            else
            {
                Cliente cliente = new Cliente(
                    codigo, nombre, telefono, correo, tipo);

                if (sistema.RegistrarCliente(cliente))
                    Console.WriteLine("Cliente registrado correctamente.");
                else
                    Console.WriteLine("No se pudo registrar. Verifique que el codigo no exista.");
            }

            Pausa();
        }

        static void MenuTecnicos()
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("===== GESTION DE TECNICOS =====");
                Console.WriteLine("1. Registrar tecnico");
                Console.WriteLine("2. Mostrar tecnicos");
                Console.WriteLine("3. Regresar");
                Console.Write("Seleccione: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                    opcion = 0;

                switch (opcion)
                {
                    case 1:
                        RegistrarTecnico();
                        break;
                    case 2:
                        sistema.MostrarTecnicos();
                        Pausa();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Opcion no valida.");
                        Pausa();
                        break;
                }

            } while (opcion != 3);
        }

        static void RegistrarTecnico()
        {
            Console.WriteLine("===== REGISTRAR TECNICO =====");

            Console.Write("Codigo: ");
            string codigo = Console.ReadLine() ?? "";

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine() ?? "";

            Console.Write("Especialidad: ");
            string especialidad = Console.ReadLine() ?? "";

            if (CamposValidos(codigo, nombre, especialidad))
            {
                Tecnico tecnico = new Tecnico(
                    codigo, nombre, especialidad);

                if (sistema.RegistrarTecnico(tecnico))
                    Console.WriteLine("Tecnico registrado correctamente.");
                else
                    Console.WriteLine("No se pudo registrar el tecnico.");
            }
            else
            {
                Console.WriteLine("Todos los campos son obligatorios.");
            }

            Pausa();
        }

        static void MenuEquipos()
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("===== GESTION DE EQUIPOS =====");
                Console.WriteLine("1. Registrar equipo");
                Console.WriteLine("2. Mostrar equipos");
                Console.WriteLine("3. Regresar");
                Console.Write("Seleccione: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                    opcion = 0;

                switch (opcion)
                {
                    case 1:
                        RegistrarEquipo();
                        break;
                    case 2:
                        sistema.MostrarEquipos();
                        Pausa();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Opcion no valida.");
                        Pausa();
                        break;
                }

            } while (opcion != 3);
        }

        static void RegistrarEquipo()
        {
            Console.WriteLine("===== REGISTRAR EQUIPO =====");

            Console.Write("Codigo del equipo: ");
            string codigo = Console.ReadLine() ?? "";

            Console.Write("Numero de serie: ");
            string serie = Console.ReadLine() ?? "";

            Console.Write("Marca: ");
            string marca = Console.ReadLine() ?? "";

            Console.Write("Modelo: ");
            string modelo = Console.ReadLine() ?? "";

            Console.Write("Codigo del propietario: ");
            string codigoCliente = Console.ReadLine() ?? "";

            if (!CamposValidos(codigo, serie, marca, modelo, codigoCliente))
            {
                Console.WriteLine("Todos los campos son obligatorios.");
                Pausa();
                return;
            }

            Cliente propietario = sistema.BuscarCliente(codigoCliente);

            if (propietario == null)
            {
                Console.WriteLine("El cliente no esta registrado.");
                Console.WriteLine("Primero registre el cliente en Gestion de clientes.");
                Pausa();
                return;
            }

            Console.Write("Estado fisico: ");
            string estado = Console.ReadLine() ?? "";

            Console.Write("Accesorios: ");
            string accesorios = Console.ReadLine() ?? "";

            if (!CamposValidos(estado, accesorios))
            {
                Console.WriteLine("El estado y los accesorios son obligatorios.");
                Pausa();
                return;
            }

            Console.WriteLine("1. Laptop");
            Console.WriteLine("2. Computadora de escritorio");
            Console.WriteLine("3. Impresora");
            Console.Write("Tipo de equipo: ");

            int tipo;

            if (!int.TryParse(Console.ReadLine(), out tipo))
                tipo = 0;

            Equipo equipo = null;

            if (tipo == 1)
            {
                Console.Write("Memoria RAM en GB: ");
                int ram;

                if (int.TryParse(Console.ReadLine(), out ram) && ram > 0)
                {
                    equipo = new Laptop(
                        codigo, serie, marca, modelo, propietario,
                        estado, accesorios, ram);
                }
                else
                {
                    Console.WriteLine("La memoria RAM no es valida.");
                }
            }
            else if (tipo == 2)
            {
                Console.Write("Tipo de torre: ");
                string torre = Console.ReadLine() ?? "";

                if (CamposValidos(torre))
                {
                    equipo = new ComputadoraEscritorio(
                        codigo, serie, marca, modelo, propietario,
                        estado, accesorios, torre);
                }
                else
                {
                    Console.WriteLine("Debe ingresar el tipo de torre.");
                }
            }
            else if (tipo == 3)
            {
                Console.Write("Tipo de impresion: ");
                string impresion = Console.ReadLine() ?? "";

                if (CamposValidos(impresion))
                {
                    equipo = new Impresora(
                        codigo, serie, marca, modelo, propietario,
                        estado, accesorios, impresion);
                }
                else
                {
                    Console.WriteLine("Debe ingresar el tipo de impresion.");
                }
            }
            else
            {
                Console.WriteLine("Tipo de equipo no valido.");
            }

            if (equipo != null)
            {
                if (sistema.RegistrarEquipo(equipo))
                {
                    Console.WriteLine("Equipo registrado correctamente.");
                    Console.WriteLine("Codigo: " + equipo.Codigo);
                    Console.WriteLine("Propietario: " + propietario.Nombre);
                    Console.WriteLine("Total de equipos: " + sistema.Equipos.Count);
                }
                else
                {
                    Console.WriteLine("No se pudo registrar el equipo.");
                    Console.WriteLine("Verifique que el codigo y numero de serie no esten repetidos.");
                }
            }

            Pausa();
        }

        static void MenuSolicitudes()
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("===== GESTION DE SOLICITUDES =====");
                Console.WriteLine("1. Registrar solicitud");
                Console.WriteLine("2. Mostrar solicitudes y precios");
                Console.WriteLine("3. Atender siguiente solicitud");
                Console.WriteLine("4. Mostrar colas");
                Console.WriteLine("5. Cambiar estado");
                Console.WriteLine("6. Asignar tecnico");
                Console.WriteLine("7. Agregar repuesto");
                Console.WriteLine("8. Registrar mano de obra");
                Console.WriteLine("9. Registrar calificacion");
                Console.WriteLine("10. Regresar");
                Console.Write("Seleccione: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                    opcion = 0;

                switch (opcion)
                {
                    case 1:
                        RegistrarSolicitud();
                        break;
                    case 2:
                        sistema.MostrarSolicitudes();
                        Pausa();
                        break;
                    case 3:
                        sistema.AtenderSiguienteSolicitud();
                        Pausa();
                        break;
                    case 4:
                        sistema.MostrarColas();
                        Pausa();
                        break;
                    case 5:
                        CambiarEstadoSolicitud();
                        break;
                    case 6:
                        AsignarTecnico();
                        break;
                    case 7:
                        AgregarRepuestoSolicitud();
                        break;
                    case 8:
                        RegistrarManoObra();
                        break;
                    case 9:
                        RegistrarCalificacion();
                        break;
                    case 10:
                        break;
                    default:
                        Console.WriteLine("Opcion no valida.");
                        Pausa();
                        break;
                }

            } while (opcion != 10);
        }

        static void RegistrarSolicitud()
        {
            Console.WriteLine("===== REGISTRAR SOLICITUD =====");

            Console.Write("Codigo de solicitud: ");
            string codigo = Console.ReadLine() ?? "";

            Console.Write("Codigo del cliente: ");
            string codigoCliente = Console.ReadLine() ?? "";

            Cliente cliente = sistema.BuscarCliente(codigoCliente);

            if (cliente == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                Pausa();
                return;
            }

            Console.Write("Codigo del equipo: ");
            string codigoEquipo = Console.ReadLine() ?? "";

            Equipo equipo = sistema.BuscarEquipo(codigoEquipo);

            if (equipo == null)
            {
                Console.WriteLine("Equipo no encontrado.");
                Pausa();
                return;
            }

            Console.Write("Descripcion del problema: ");
            string problema = Console.ReadLine() ?? "";

            Console.WriteLine("1. Normal");
            Console.WriteLine("2. Urgente");
            Console.Write("Prioridad: ");

            int opcionPrioridad;

            if (!int.TryParse(Console.ReadLine(), out opcionPrioridad))
                opcionPrioridad = 0;

            string prioridad = "";

            if (opcionPrioridad == 1)
                prioridad = "Normal";
            else if (opcionPrioridad == 2)
                prioridad = "Urgente";

            if (CamposValidos(codigo, problema) && prioridad != "")
            {
                Solicitud solicitud = new Solicitud(
                    codigo, cliente, equipo, problema, prioridad);

                if (sistema.RegistrarSolicitud(solicitud))
                {
                    Console.WriteLine("Solicitud registrada correctamente.");
                    Console.WriteLine("Estado: Registrada");
                    Console.WriteLine("Costo de revision: Q" +
                        equipo.CalcularCostoRevision());
                    Console.WriteLine("Mano de obra: Q0");
                    Console.WriteLine("Repuestos: Q0");
                    Console.WriteLine("Total: Q" + solicitud.CalcularTotal());
                }
                else
                {
                    Console.WriteLine("No se pudo registrar la solicitud.");
                    Console.WriteLine("Verifique el codigo y que el equipo no tenga otra solicitud activa.");
                }
            }
            else
            {
                Console.WriteLine("Revise los datos ingresados.");
            }

            Pausa();
        }

        static void CambiarEstadoSolicitud()
        {
            Console.Write("Codigo de solicitud: ");
            string codigo = Console.ReadLine() ?? "";

            Console.WriteLine("Estados disponibles:");
            Console.WriteLine("1. En revision");
            Console.WriteLine("2. En reparacion");
            Console.WriteLine("3. Lista para entrega");
            Console.WriteLine("4. Entregada");
            Console.WriteLine("5. Cancelada");
            Console.Write("Seleccione el nuevo estado: ");

            int opcion;

            if (!int.TryParse(Console.ReadLine(), out opcion))
                opcion = 0;

            string estado = "";

            switch (opcion)
            {
                case 1: estado = "En revision"; break;
                case 2: estado = "En reparacion"; break;
                case 3: estado = "Lista para entrega"; break;
                case 4: estado = "Entregada"; break;
                case 5: estado = "Cancelada"; break;
            }

            if (estado != "")
            {
                if (sistema.CambiarEstadoSolicitud(codigo, estado))
                    Console.WriteLine("Estado actualizado correctamente.");
                else
                    Console.WriteLine("No se pudo cambiar el estado.");
            }
            else
            {
                Console.WriteLine("Opcion no valida.");
            }

            Pausa();
        }

        static void AsignarTecnico()
        {
            Console.Write("Codigo de solicitud: ");
            string solicitud = Console.ReadLine() ?? "";

            Console.Write("Codigo de tecnico: ");
            string tecnico = Console.ReadLine() ?? "";

            if (sistema.AsignarTecnicoASolicitud(solicitud, tecnico))
                Console.WriteLine("Tecnico asignado correctamente.");
            else
                Console.WriteLine("No se pudo asignar el tecnico.");

            Pausa();
        }

        static void AgregarRepuestoSolicitud()
        {
            Console.WriteLine("===== AGREGAR REPUESTO =====");

            Console.Write("Codigo de solicitud: ");
            string codigoSolicitud = Console.ReadLine() ?? "";

            Console.Write("Codigo de repuesto: ");
            string codigoRepuesto = Console.ReadLine() ?? "";

            Console.Write("Cantidad: ");
            int cantidad;

            if (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
            {
                Console.WriteLine("Cantidad no valida.");
                Pausa();
                return;
            }

            if (sistema.AgregarRepuestoASolicitud(
                codigoSolicitud, codigoRepuesto, cantidad))
            {
                Console.WriteLine("Repuesto agregado correctamente.");

                Solicitud solicitud =
                    sistema.BuscarSolicitudPorCodigo(codigoSolicitud);

                if (solicitud != null)
                    Console.WriteLine("Nuevo total: Q" + solicitud.CalcularTotal());
            }
            else
            {
                Console.WriteLine("No se pudo agregar el repuesto.");
                Console.WriteLine("Revise el codigo o la existencia.");
            }

            Pausa();
        }

        static void RegistrarManoObra()
        {
            Console.WriteLine("===== REGISTRAR MANO DE OBRA =====");

            Console.Write("Codigo de solicitud: ");
            string codigo = Console.ReadLine() ?? "";

            Console.Write("Costo de mano de obra: Q");
            double costo;

            if (!double.TryParse(Console.ReadLine(), out costo) || costo < 0)
            {
                Console.WriteLine("Costo no valido.");
                Pausa();
                return;
            }

            if (sistema.RegistrarManoObra(codigo, costo))
            {
                Solicitud solicitud = sistema.BuscarSolicitudPorCodigo(codigo);

                if (solicitud != null)
                {
                    Console.WriteLine("Mano de obra registrada.");
                    Console.WriteLine("Costo de revision: Q" +
                        solicitud.Equipo.CalcularCostoRevision());
                    Console.WriteLine("Mano de obra: Q" + solicitud.CostoManoObra);
                    Console.WriteLine("Total: Q" + solicitud.CalcularTotal());
                }
            }
            else
            {
                Console.WriteLine("No se pudo registrar la mano de obra.");
            }

            Pausa();
        }

        static void RegistrarCalificacion()
        {
            Console.Write("Codigo de solicitud: ");
            string codigo = Console.ReadLine() ?? "";

            Console.Write("Calificacion de 1 a 5: ");
            double calificacion;

            if (!double.TryParse(Console.ReadLine(), out calificacion))
            {
                Console.WriteLine("Calificacion no valida.");
                Pausa();
                return;
            }

            if (sistema.RegistrarCalificacion(codigo, calificacion))
                Console.WriteLine("Calificacion registrada.");
            else
                Console.WriteLine("No se pudo registrar la calificacion.");

            Pausa();
        }

        static void MenuRepuestos()
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("===== GESTION DE REPUESTOS =====");
                Console.WriteLine("1. Registrar repuesto");
                Console.WriteLine("2. Mostrar repuestos");
                Console.WriteLine("3. Mostrar repuestos con stock bajo");
                Console.WriteLine("4. Registrar entrada de repuestos");
                Console.WriteLine("5. Regresar");
                Console.Write("Seleccione: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                    opcion = 0;

                switch (opcion)
                {
                    case 1:
                        RegistrarRepuesto();
                        break;
                    case 2:
                        sistema.MostrarRepuestos();
                        Pausa();
                        break;
                    case 3:
                        sistema.MostrarRepuestosBajoStock();
                        Pausa();
                        break;
                    case 4:
                        RegistrarEntradaRepuesto();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Opcion no valida.");
                        Pausa();
                        break;
                }

            } while (opcion != 5);
        }

        static void RegistrarRepuesto()
        {
            Console.WriteLine("===== REGISTRAR REPUESTO =====");

            Console.Write("Codigo: ");
            string codigo = Console.ReadLine() ?? "";

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine() ?? "";

            Console.Write("Categoria: ");
            string categoria = Console.ReadLine() ?? "";

            Console.Write("Existencia: ");
            int existencia;

            if (!int.TryParse(Console.ReadLine(), out existencia) || existencia < 0)
            {
                Console.WriteLine("Existencia no valida.");
                Pausa();
                return;
            }

            Console.Write("Stock minimo: ");
            int minimo;

            if (!int.TryParse(Console.ReadLine(), out minimo) || minimo < 0)
            {
                Console.WriteLine("Stock minimo no valido.");
                Pausa();
                return;
            }

            Console.Write("Costo de compra: Q");
            double compra;

            if (!double.TryParse(Console.ReadLine(), out compra) || compra < 0)
            {
                Console.WriteLine("Costo no valido.");
                Pausa();
                return;
            }

            Console.Write("Precio de venta: Q");
            double venta;

            if (!double.TryParse(Console.ReadLine(), out venta) || venta < 0)
            {
                Console.WriteLine("Precio no valido.");
                Pausa();
                return;
            }

            if (CamposValidos(codigo, nombre, categoria))
            {
                Repuesto repuesto = new Repuesto(
                    codigo, nombre, categoria, existencia,
                    minimo, compra, venta);

                if (sistema.RegistrarRepuesto(repuesto))
                    Console.WriteLine("Repuesto registrado correctamente.");
                else
                    Console.WriteLine("No se pudo registrar el repuesto.");
            }
            else
            {
                Console.WriteLine("Los campos son obligatorios.");
            }

            Pausa();
        }

        static void RegistrarEntradaRepuesto()
        {
            Console.Write("Codigo del repuesto: ");
            string codigo = Console.ReadLine() ?? "";

            Repuesto repuesto = sistema.BuscarRepuesto(codigo);

            if (repuesto == null)
            {
                Console.WriteLine("Repuesto no encontrado.");
                Pausa();
                return;
            }

            Console.Write("Cantidad que ingresa: ");
            int cantidad;

            if (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
            {
                Console.WriteLine("Cantidad no valida.");
                Pausa();
                return;
            }

            if (repuesto.RegistrarEntrada(cantidad))
                Console.WriteLine("Existencia actualizada.");
            else
                Console.WriteLine("No se pudo registrar la entrada.");

            Console.WriteLine("Existencia actual: " + repuesto.Existencia);
            Pausa();
        }

        static void MenuOrdenamientos()
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("===== ORDENAMIENTOS =====");
                Console.WriteLine("1. Solicitudes por costo");
                Console.WriteLine("2. Tecnicos por servicios finalizados");
                Console.WriteLine("3. Repuestos por existencia");
                Console.WriteLine("4. Solicitudes por fecha");
                Console.WriteLine("5. Regresar");
                Console.Write("Seleccione: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                    opcion = 0;

                switch (opcion)
                {
                    case 1:
                        sistema.OrdenarSolicitudesPorTotal();
                        Pausa();
                        break;
                    case 2:
                        sistema.OrdenarTecnicosPorServicios();
                        Pausa();
                        break;
                    case 3:
                        sistema.OrdenarRepuestosPorExistencia();
                        Pausa();
                        break;
                    case 4:
                        sistema.OrdenarSolicitudesPorFecha();
                        Pausa();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Opcion no valida.");
                        Pausa();
                        break;
                }

            } while (opcion != 5);
        }

        static void MenuBusquedas()
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("===== BUSQUEDAS =====");
                Console.WriteLine("1. Buscar cliente por nombre");
                Console.WriteLine("2. Buscar solicitud por estado");
                Console.WriteLine("3. Buscar equipo por marca");
                Console.WriteLine("4. Buscar solicitud por codigo");
                Console.WriteLine("5. Regresar");
                Console.Write("Seleccione: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                    opcion = 0;

                switch (opcion)
                {
                    case 1:
                        Console.Write("Nombre del cliente: ");
                        string nombre = Console.ReadLine() ?? "";
                        sistema.BuscarClientesPorNombre(nombre);
                        Pausa();
                        break;
                    case 2:
                        Console.Write("Estado de la solicitud: ");
                        string estado = Console.ReadLine() ?? "";
                        sistema.BuscarSolicitudesPorEstado(estado);
                        Pausa();
                        break;
                    case 3:
                        Console.Write("Marca del equipo: ");
                        string marca = Console.ReadLine() ?? "";
                        sistema.BuscarEquiposPorMarca(marca);
                        Pausa();
                        break;
                    case 4:
                        Console.Write("Codigo de solicitud: ");
                        string codigo = Console.ReadLine() ?? "";

                        Solicitud encontrada =
                            sistema.BuscarSolicitudBinaria(codigo);

                        if (encontrada != null)
                            encontrada.MostrarInformacion();
                        else
                            Console.WriteLine("Solicitud no encontrada.");

                        Pausa();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Opcion no valida.");
                        Pausa();
                        break;
                }

            } while (opcion != 5);
        }

        static void MenuReportes()
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("===== REPORTES =====");
                Console.WriteLine("1. Cantidad de equipos por tipo");
                Console.WriteLine("2. Carga de trabajo de tecnicos");
                Console.WriteLine("3. Repuestos con stock bajo");
                Console.WriteLine("4. Cantidad de registros");
                Console.WriteLine("5. Regresar");
                Console.Write("Seleccione: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                    opcion = 0;

                switch (opcion)
                {
                    case 1:
                        sistema.MostrarCantidadesPorTipo();
                        Pausa();
                        break;
                    case 2:
                        sistema.MostrarCargaTecnicos();
                        Pausa();
                        break;
                    case 3:
                        sistema.MostrarRepuestosBajoStock();
                        Pausa();
                        break;
                    case 4:
                        Console.WriteLine("Clientes: " + sistema.Clientes.Count);
                        Console.WriteLine("Tecnicos: " + sistema.Tecnicos.Count);
                        Console.WriteLine("Equipos: " + sistema.Equipos.Count);
                        Console.WriteLine("Solicitudes: " + sistema.Solicitudes.Count);
                        Console.WriteLine("Repuestos: " + sistema.Repuestos.Count);
                        Pausa();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Opcion no valida.");
                        Pausa();
                        break;
                }

            } while (opcion != 5);
        }

        static bool CamposValidos(params string[] campos)
        {
            foreach (string campo in campos)
            {
                if (string.IsNullOrWhiteSpace(campo))
                    return false;
            }

            return true;
        }

        static void Pausa()
        {
            Console.WriteLine();
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
