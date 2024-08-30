using Cadete;
using Cadeteria;
using Cliente;
using Pedidos;

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

