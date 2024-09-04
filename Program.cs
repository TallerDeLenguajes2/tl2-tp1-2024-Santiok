using System.IO.StreamReader;
using Cadete;
using Cadeteria;
using Cliente;
using Pedidos;

List<cadete> listaCadetes = new List<cadete>();

//Ubicacion de los archivos csv.
string ubicacionCadete = "C:\\Taller2\\tl2-tp1-2024-Santiok\\datos_cadetes.csv";
string ubicacionCadeteria = "C:\\Taller2\\tl2-tp1-2024-Santiok\\datos_cadeteria.csv";

System.IO.StreamReader archivo1 = new System.IO.StreamReader(ubicacionCadete);
System.IO.StreamReader archivo2 = new System.IO.StreamReader(ubicacionCadeteria);

string separador = ',';
string linea1;
string linea2;

//Para eliminar el encabezado.
archivo1.ReadLine();
archivo2.ReadLine();

//Leo el archivo1.
while ((linea1 = archivo1.ReadLine()) != null)
{
    string[] fila = linea1.Split(separador);
    cadete cadeteAux = CrearCadete(fila[0],fila[1],fila[2],fila[3]);

    listaCadetes.Add(cadeteAux);
}
//Leo el archivo2.
if ((linea2 = archivo2.ReadLine()) != null)
{
    
    string[] fila = linea2.Split(separador);
    cadeteria cadeteriaV = CrearCadeteria(fila[0],fila[1]);
}






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

