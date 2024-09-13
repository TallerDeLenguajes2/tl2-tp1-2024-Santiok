namespace Pedidos;
using Cliente;
using Cadete;
public class pedidos
{
    public int NumeroPedido;
    public string Observacion;
    public cliente infoCliente;
    public  Estado estado;
    public cadete? cadeteAsignado;

    //Metodo constructor.
    public pedidos(int num, string obs, cliente cli, Estado est/*, cadete cadete*/)
    {
        this.NumeroPedido = num;
        this.Observacion = obs;
        this.infoCliente = cli;
        this.estado = est;
        //this.cadeteAsignado = cadete;
    }

    //Metodo para agregar cadete.
    public void AgregarCadeteAlPedido(pedidos pedido, cadete cadete)
    {
        pedido.cadeteAsignado = cadete;
    }

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