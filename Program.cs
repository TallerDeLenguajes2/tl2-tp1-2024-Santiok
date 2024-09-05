using Cadete;
using Cadeteria;
using Cliente;
using Pedidos;

List<cadete> listaCadetes = new List<cadete>();
cadeteria nuevaCadeteria = null;

//Ubicacion de los archivos csv.
string ubicacionCadete = "C:\\Taller2\\tl2-tp1-2024-Santiok\\datos_cadetes.csv";
string ubicacionCadeteria = "C:\\Taller2\\tl2-tp1-2024-Santiok\\datos_cadeteria.csv";

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
//Mostrar la cadeteria para ver si anda bien.
if (nuevaCadeteria != null)
{
    Console.WriteLine($"Nombre: {nuevaCadeteria.Nombre}, Teléfono: {nuevaCadeteria.Telefono}");
}
else
{
    Console.WriteLine("No se cargó ninguna cadeteria.");
}







/*
do
{
    int opcion;
    Console.WriteLine("\nIngrese una opcion:\n 1)Dar de alta un pedido \n 2)Asignar pedido a cadete \n 3)Cambiar de estado el pedido \n 4)Reasignar el pedido");
    int.TryParse(Console.ReadLine(), out opcion);

    switch (opcion)
    {
        case 1:
        break;

        case 2:
        break;

        case 3:
        break;

        case 4:
        break;

        default:
            Console.WriteLine("\nLa opcion ingresada es incorrecta.");
        break;
    }

} while (true);

*/