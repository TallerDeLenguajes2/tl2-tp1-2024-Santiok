namespace Pedidos;
using Cliente;

public class pedididos
{
    private int NumeroPedido;
    private string Observacion;
    private cliente infoCliente;
    private bool Estado;

  //Muestro la direccion del cliente.
    public string VerDireccionCliente(cliente clienteAux)
    {
        return $"Direccion del cliente {infoCliente.Direccion}";
    }

    //Muestro los datos del cliente.
    public void VerDatosCliente(cliente clienteAux)
    {
        Console.WriteLine("\nNombre del cliente: " + clienteAux.Nombre);
        Console.WriteLine("\nTelefono del cliente: " + clienteAux.Telefono);
    }
}