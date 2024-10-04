using AccesoADatos;
using Cadete;
using Cadeteria;
using Cliente;
using Pedidos;
using AccesoADatos;

List<cadete> listaCadetes = new List<cadete>();
cadeteria nuevaCadeteria = null;
List<pedidos> listaPedidos = new List<pedidos>();

//Ubicacion de los archivos csv.dotnet run
string ubicacionCadete = "datos_cadetes.csv";
string ubicacionCadeteria = "datos_cadeteria.csv";
//Interfaz para cargar datos
accesoADatos accesoDatos = null;

//Creo un arreglo de clientes.
cliente[] arregloClientes = new cliente[10];
for (int i = 0; i < 10; i++)
{
    arregloClientes[i] = cliente.CrearCliente();
}
/*
foreach (var cliente in arregloClientes)
{
    Console.WriteLine($"Nombre: {cliente.Nombre}, Dirección: {cliente.Direccion}, Teléfono: {cliente.Telefono}, Referencia: {string.Join(", ", cliente.DatosReferencia)}");
}
*/

//Menu de opciones para leer archivos.
bool continuar3 = true;
do
{
    int opcion3;
    Console.WriteLine("\nIngrese que tipo de archivo desea leer:\n 1)Archivo Json \n 2)Archivo CSV \n");
    int.TryParse(Console.ReadLine(), out opcion3);

    switch (opcion3)
    {
        case 1:

            //Usar la clase AccesoJson para cargar desde archivos JSON.
            accesoDatos = new AccesoJson();
            try
            {
                nuevaCadeteria = accesoDatos.CrearCadeteria();
                listaCadetes = accesoDatos.CrearCadetes();
                Console.WriteLine("Datos cargados correctamente desde el archivo JSON.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar datos desde JSON: {ex.Message}");
            }
            continuar3 = false;
            break;

        case 2:

            //Usar la clase AccesoCsv para cargar desde archivos CSV.
            accesoDatos = new AccesoCsv();
            try
            {
                nuevaCadeteria = accesoDatos.CrearCadeteria();
                listaCadetes = accesoDatos.CrearCadetes();
                Console.WriteLine("Datos cargados correctamente desde el archivo CSV.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar datos desde CSV: {ex.Message}");
            }
            continuar3 = false;
            break;

        default:
            Console.WriteLine("\nLa opcion ingresada es incorrecta, vuelva a ingresar.\n");
            break;
    }
} while (continuar3);

//Menu de opciones para operar.
bool continuar = true;
do
{
    int opcion;
    Console.WriteLine("\nIngrese una opción:\n 1) Dar de alta un pedido \n 2) Asignar pedido a cadete \n 3) Cambiar de estado el pedido \n 4) Reasignar el pedido \n 5) Finalizar jornada y mostrar informe");
    int.TryParse(Console.ReadLine(), out opcion);

    switch (opcion)
    {
        case 1:
            DarDeAltaPedido(nuevaCadeteria.ListadoPedidos, arregloClientes);
            break;
        case 2:
            AsignarPedidoACadete(nuevaCadeteria.ListadoPedidos, listaCadetes);
            break;
        case 3:
            CambiarEstadoPedido(nuevaCadeteria.ListadoPedidos);
            break;
        case 4:
            ReasignarPedido(nuevaCadeteria.ListadoPedidos, listaCadetes);
            break;
        case 5:
            MostrarInformeJornada();
            continuar = false;
            break;
        default:
            Console.WriteLine("\nLa opción ingresada es incorrecta.");
            break;
    }
} while (continuar);

//Metodos del programa.

//Dar de alta un pedido.
void DarDeAltaPedido(List<pedidos> listaPedidos, cliente[] arregloClientes)
{
    bool continuar2 = true;
    Random random = new Random();
    int numeroP = random.Next(100, 10000);
    Console.WriteLine("Por favor, ingrese alguna observación:");
    string obs = Console.ReadLine();
    cliente clienteAux = arregloClientes[random.Next(0, arregloClientes.Length)];
    //Añado el pedido a la lista de pedidos.
    pedidos newPedido = new pedidos(numeroP, obs, clienteAux, Estado.PENDIENTE);
    listaPedidos.Add(newPedido);
    Console.WriteLine($"Pedido {newPedido.NumeroPedido} agregado con éxito.");
    //Añado un cadete al pedido.
    do
    {
        Console.WriteLine($"¿Desea asignar este pedido a algun cadete?\n 1)Si \n 2)No");
        int opcion1 = int.Parse(Console.ReadLine());
        if (opcion1 < 1 || opcion1 > 2)
        {
            Console.WriteLine($"La opcion ingresada es incorrecta.");
        }
        else
        {
            continuar2 = false;

            switch (opcion1)
            {
                case 1:
                    Console.WriteLine("Cadetes disponibles:");
                    for (int i = 0; i < listaCadetes.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}) {listaCadetes[i].Nombre}");
                    }

                    Console.WriteLine("Seleccione un cadete:");
                    int indiceCadete = int.Parse(Console.ReadLine() ?? "0") - 1;

                    if (indiceCadete < 0 || indiceCadete >= listaCadetes.Count)
                    {
                        Console.WriteLine("Cadete no encontrado.");
                        return;
                    }
                    var cadeteSeleccionado = listaCadetes[indiceCadete];

                    //Añado al cadete.
                    nuevaCadeteria.AsignarCadeteAPedido(cadeteSeleccionado.Id, numeroP);
                    newPedido.Estado = Estado.COMPLETADO;
                    cadeteSeleccionado.cantPedidos++;
                    break;

                case 2:
                    break;

                default:
                    break;
            }

        }

    } while (continuar2);
}

//Asigno el pedido a cadetes.
void AsignarPedidoACadete(List<pedidos> listaPedidos, List<cadete> listaCadetes)
{
    /*Si el pedido esta en pendiente es porque no fue asignado a ningun cadete o porque el cliente no queria un cadete asignado.*/
    var pedidosPendientes = listaPedidos.Where(p => p.Estado == Estado.PENDIENTE).ToList();
    if (!pedidosPendientes.Any())
    {
        Console.WriteLine("No hay pedidos pendientes para asignar.");
        return;
    }

    Console.WriteLine("Pedidos pendientes:");
    pedidosPendientes.ForEach(p => Console.WriteLine($"Pedido {p.NumeroPedido} - Estado: {p.Estado}"));

    Console.WriteLine("Seleccione un pedido:");
    int numPedido = int.Parse(Console.ReadLine() ?? "0");
    var pedidoSeleccionado = pedidosPendientes.FirstOrDefault(p => p.NumeroPedido == numPedido);

    if (pedidoSeleccionado == null)
    {
        Console.WriteLine("Pedido no encontrado.");
        return;
    }

    Console.WriteLine("Cadetes disponibles:");
    for (int i = 0; i < listaCadetes.Count; i++)
    {
        Console.WriteLine($"{i + 1}) {listaCadetes[i].Nombre}");
    }

    Console.WriteLine("Seleccione un cadete:");
    int indiceCadete = int.Parse(Console.ReadLine() ?? "0") - 1;

    if (indiceCadete < 0 || indiceCadete >= listaCadetes.Count)
    {
        Console.WriteLine("Cadete no encontrado.");
        return;
    }

    var cadeteSeleccionado = listaCadetes[indiceCadete];
    nuevaCadeteria.AsignarCadeteAPedido(cadeteSeleccionado.Id, pedidoSeleccionado.NumeroPedido);
    pedidoSeleccionado.Estado = Estado.COMPLETADO;
    cadeteSeleccionado.cantPedidos++;
    Console.WriteLine($"Pedido {pedidoSeleccionado.NumeroPedido} asignado a {cadeteSeleccionado.Nombre}.");
}

//Cambio el estado del pedido.
void CambiarEstadoPedido(List<pedidos> listaPedidos)
{
    Console.WriteLine("Pedidos disponibles:");
    listaPedidos.ForEach(p => Console.WriteLine($"Pedido {p.NumeroPedido} - Estado: {p.Estado}"));

    Console.WriteLine("Seleccione un pedido:");
    int numPedido = int.Parse(Console.ReadLine() ?? "0");
    var pedidoSeleccionado = listaPedidos.FirstOrDefault(p => p.NumeroPedido == numPedido);

    if (pedidoSeleccionado == null)
    {
        Console.WriteLine("Pedido no encontrado.");
        return;
    }

    Console.WriteLine("Seleccione el nuevo estado (1: PENDIENTE, 2: COMPLETADO):");
    int nuevoEstado = int.Parse(Console.ReadLine() ?? "1");
    pedidoSeleccionado.Estado = (Estado)nuevoEstado;
    Console.WriteLine($"Estado del pedido {pedidoSeleccionado.NumeroPedido} actualizado a {pedidoSeleccionado.Estado}.");
}

//Reasigno el pedido a otro cadete.
void ReasignarPedido(List<pedidos> listaPedidos, List<cadete> listaCadetes)
{
    Console.WriteLine("Pedidos asignados:");
    var pedidosAsignados = listaPedidos.Where(p => p.Estado == Estado.COMPLETADO).ToList();
    pedidosAsignados.ForEach(p => Console.WriteLine($"Pedido {p.NumeroPedido} - Estado: {p.Estado}"));

    Console.WriteLine("Seleccione un pedido:");
    int numPedido = int.Parse(Console.ReadLine() ?? "0");
    var pedidoSeleccionado = pedidosAsignados.FirstOrDefault(p => p.NumeroPedido == numPedido);

    if (pedidoSeleccionado == null)
    {
        Console.WriteLine("Pedido no encontrado.");
        return;
    }

    Console.WriteLine("Cadetes disponibles para reasignar:");
    for (int i = 0; i < listaCadetes.Count; i++)
    {
        Console.WriteLine($"{i + 1}) {listaCadetes[i].Nombre}");
    }

    Console.WriteLine("Seleccione un cadete:");
    int indiceCadete = int.Parse(Console.ReadLine() ?? "0") - 1;

    if (indiceCadete < 0 || indiceCadete >= listaCadetes.Count)
    {
        Console.WriteLine("Cadete no encontrado.");
        return;
    }

    var cadeteSeleccionado = listaCadetes[indiceCadete];

    pedidoSeleccionado.CadeteAsignado = cadeteSeleccionado;

    Console.WriteLine($"Pedido {pedidoSeleccionado.NumeroPedido} reasignado a {cadeteSeleccionado.Nombre}.");
}

//Metodo para mostrar el informe al finalizar la jornada.
void MostrarInformeJornada()
{
    int totalEnvios = 0;
    float montoTotal = 0;

    Console.WriteLine("\n---- Informe de la jornada ----");

    foreach (cadete cad in listaCadetes/*nuevaCadeteria.ListadoCadetes*/)
    {
        //Cantidad de pedidos asignados al cadete.
        int cantidadEnvios = cad.cantPedidos;
        //Monto ganado por cada envio.
        float montoGanado = cantidadEnvios * 500;

        Console.WriteLine($"Cadete: {cad.Nombre}");
        Console.WriteLine($"Cantidad de envíos realizados: {cantidadEnvios}");
        Console.WriteLine($"Monto ganado: ${montoGanado}\n");

        totalEnvios += cantidadEnvios;
        montoTotal += montoGanado;
    }

    //Calculo el promedio de envios por cadete.
    double promedioEnvios = nuevaCadeteria.ListadoCadetes.Count > 0 ? (double)totalEnvios / nuevaCadeteria.ListadoCadetes.Count : 0;

    Console.WriteLine($"Total de envíos realizados: {totalEnvios}");
    Console.WriteLine($"Monto total ganado por los cadetes: ${montoTotal}");
    Console.WriteLine($"Promedio de envíos por cadete: {promedioEnvios:F2}");
}

