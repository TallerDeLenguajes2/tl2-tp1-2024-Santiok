using Cadete;
using Cadeteria;
using Cliente;
using Pedidos;

List<cadete> listaCadetes = new List<cadete>();
cadeteria nuevaCadeteria = null;

//Ubicacion de los archivos csv.
string ubicacionCadete = "C:\\Users\\Alumno\\Desktop\\tl2-tp1-2024-Santiok\\datos_cadetes.csv";
string ubicacionCadeteria = "C:\\Users\\Alumno\\Desktop\\tl2-tp1-2024-Santiok\\datos_cadeteria.csv";

System.IO.StreamReader archivo1 = new System.IO.StreamReader(ubicacionCadete);
System.IO.StreamReader archivo2 = new System.IO.StreamReader(ubicacionCadeteria);

char separador = ',';
string linea1;
string linea2;

//Para eliminar el encabezado.
archivo1.ReadLine();
archivo2.ReadLine();

//Leo cada linea del archivo CSV de cadetes.
while ((linea1 = archivo1.ReadLine()) != null)
{
    //Transformo en arreglo la linea.
    string[] datosCadete = linea1.Split(separador);

    //Verificar que haya al menos 4 columnas en cada linea.
    if (datosCadete.Length >= 4)
    {
        int id = int.Parse(datosCadete[0]);
        string nombre = datosCadete[1];
        string direccion = datosCadete[2];
        string telefono = datosCadete[3];

        //Creo un nuevo objeto cadete y lo agrego a la lista.
        cadete nuevoCadete = new cadete(id, nombre, direccion, telefono);
        listaCadetes.Add(nuevoCadete);
    }
}
//Cierro el archivo.
archivo1.Close();
/*
//Mostrar los cadetes para probar que ande bien.
foreach (var cadete in listaCadetes)
{
    Console.WriteLine($"ID: {cadete.ID}, Nombre: {cadete.Nombre}, Dirección: {cadete.Direccion}, Teléfono: {cadete.Telefono}");
}
*/
//Leo cada linea del archivo CSV de cadeteria.
while ((linea2 = archivo2.ReadLine()) != null)
{
    //Transformo en arreglo la linea.
    string[] datosCadeteria = linea2.Split(separador);

    //Verificar que haya al menos 4 columnas en cada linea.
    if (datosCadeteria.Length >= 2)
    {
        string nombre = datosCadeteria[0];
        string telefono = datosCadeteria[1];

        nuevaCadeteria = new cadeteria(nombre, telefono);
    }
}
//Cierro el archivo.
archivo2.Close();
/*
//Mostrar la cadeteria para ver si anda bien.
if (nuevaCadeteria != null)
{
    Console.WriteLine($"Nombre: {nuevaCadeteria.Nombre}, Teléfono: {nuevaCadeteria.Telefono}");
}
else
{
    Console.WriteLine("No se cargó ninguna cadeteria.");
}
*/
//Creo lista de pedidos.
List<pedidos> listaPedidos = new List<pedidos>();

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

bool continuar = true;
do
{
    int opcion;
    Console.WriteLine("\nIngrese una opción:\n 1) Dar de alta un pedido \n 2) Asignar pedido a cadete \n 3) Cambiar de estado el pedido \n 4) Reasignar el pedido \n 5) Finalizar jornada y mostrar informe");
    int.TryParse(Console.ReadLine(), out opcion);

    switch (opcion)
    {
        case 1:
            DarDeAltaPedido(listaPedidos, arregloClientes);
            break;
        case 2:
            AsignarPedidoACadete(listaPedidos, listaCadetes);
            break;
        case 3:
            CambiarEstadoPedido(listaPedidos);
            break;
        case 4:
            ReasignarPedido(listaPedidos, listaCadetes);
            break;
        case 5:
            MostrarInformeJornada(listaCadetes);
            continuar = false;
            break;
        default:
            Console.WriteLine("\nLa opción ingresada es incorrecta.");
            break;
    }
} while (continuar);

//Metodos del programa.

void DarDeAltaPedido(List<pedidos> listaPedidos, cliente[] arregloClientes)
{
    Random random = new Random();
    int numeroP = random.Next(100, 10000);
    Console.WriteLine("Por favor, ingrese alguna observación:");
    string obs = Console.ReadLine();
    cliente clienteAux = arregloClientes[random.Next(0, arregloClientes.Length)];

    pedidos newPedido = new pedidos(numeroP, obs, clienteAux, Estado.PENDIENTE);
    listaPedidos.Add(newPedido);
    Console.WriteLine($"Pedido {newPedido.NumeroPedido} agregado con éxito.");
}

void AsignarPedidoACadete(List<pedidos> listaPedidos, List<cadete> listaCadetes)
{
    var pedidosPendientes = listaPedidos.Where(p => p.estado == Estado.PENDIENTE).ToList();
    if (!pedidosPendientes.Any())
    {
        Console.WriteLine("No hay pedidos pendientes para asignar.");
        return;
    }

    Console.WriteLine("Pedidos pendientes:");
    pedidosPendientes.ForEach(p => Console.WriteLine($"Pedido {p.NumeroPedido} - Estado: {p.estado}"));

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
    cadeteSeleccionado.ListadoPedidos.Add(pedidoSeleccionado);
    pedidoSeleccionado.estado = Estado.COMPLETADO;
    Console.WriteLine($"Pedido {pedidoSeleccionado.NumeroPedido} asignado a {cadeteSeleccionado.Nombre}.");
}

void CambiarEstadoPedido(List<pedidos> listaPedidos)
{
    Console.WriteLine("Pedidos disponibles:");
    listaPedidos.ForEach(p => Console.WriteLine($"Pedido {p.NumeroPedido} - Estado: {p.estado}"));

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
    pedidoSeleccionado.estado = (Estado)nuevoEstado;
    Console.WriteLine($"Estado del pedido {pedidoSeleccionado.NumeroPedido} actualizado a {pedidoSeleccionado.estado}.");
}

void ReasignarPedido(List<pedidos> listaPedidos, List<cadete> listaCadetes)
{
    Console.WriteLine("Pedidos asignados:");
    var pedidosAsignados = listaPedidos.Where(p => p.estado == Estado.COMPLETADO).ToList();
    pedidosAsignados.ForEach(p => Console.WriteLine($"Pedido {p.NumeroPedido} - Estado: {p.estado}"));

    Console.WriteLine("Seleccione un pedido:");
    int numPedido = int.Parse(Console.ReadLine() ?? "0");
    var pedidoSeleccionado = pedidosAsignados.FirstOrDefault(p => p.NumeroPedido == numPedido);

    if (pedidoSeleccionado == null)
    {
        Console.WriteLine("Pedido no encontrado.");
        return;
    }

    var cadeteActual = listaCadetes.FirstOrDefault(c => c.ListadoPedidos.Contains(pedidoSeleccionado));
    if (cadeteActual != null)
    {
        cadeteActual.ListadoPedidos.Remove(pedidoSeleccionado);
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
    cadeteSeleccionado.ListadoPedidos.Add(pedidoSeleccionado);
    Console.WriteLine($"Pedido {pedidoSeleccionado.NumeroPedido} reasignado a {cadeteSeleccionado.Nombre}.");
}


//Metodo para mostrar el informe al finalizar la jornada.
void MostrarInformeJornada(List<cadete> listaCadetes)
{
    int totalEnvios = 0;
    float montoTotal = 0;

    Console.WriteLine("\nInforme de la jornada:");

    foreach (var cadete in listaCadetes)
    {
        int cantidadEnvios = cadete.ListadoPedidos.Count;

        float montoGanado = cadete.JornalACobrar();

        Console.WriteLine($"Cadete: {cadete.Nombre}");
        Console.WriteLine($"Envíos realizados: {cantidadEnvios}");
        Console.WriteLine($"Monto ganado: ${montoGanado}\n");

        totalEnvios += cantidadEnvios;
        montoTotal += montoGanado;
    }

    //Calculo del promedio de envíos por cadete.
    double promedioEnvios = listaCadetes.Count > 0 ? (double)totalEnvios / listaCadetes.Count : 0;

    Console.WriteLine($"Total de envíos: {totalEnvios}");
    Console.WriteLine($"Monto total ganado: ${montoTotal}");
    Console.WriteLine($"Promedio de envíos por cadete: {promedioEnvios:F2}");
}
