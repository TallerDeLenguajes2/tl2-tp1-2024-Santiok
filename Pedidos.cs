namespace Pedidos;
using Cliente;
using Cadete;
public class pedidos
{
    private int numeroPedido;
    private string observacion;
    private cliente infoCliente;
    private  Estado estado;
    private cadete? cadeteAsignado;

    public int NumeroPedido { get => numeroPedido; set => numeroPedido = value;}
    public string Observacion { get => observacion; set => observacion = value;}
    public cliente InfoCliente { get => infoCliente; set => infoCliente = value;}
    public Estado Estado { get => estado; set => estado = value;}
    public cadete? CadeteAsignado { get => cadeteAsignado; set => cadeteAsignado = value;}

    //Metodo constructor.
    public pedidos(int num, string obs, cliente cli, Estado est/*,cadete cadete*/)
    {
        this.numeroPedido = num;
        this.Observacion = obs;
        this.infoCliente = cli;
        this.estado = est;
        
    }

    /*public pedidos(int numeroPedido = 0, string observacion = null, cliente infoCliente = null, Estado estado = default, cadete? cadeteAsignado = null)
    {
        this.numeroPedido = numeroPedido;
        this.observacion = observacion;
        this.infoCliente = infoCliente;
        this.estado = estado;
        this.cadeteAsignado = cadeteAsignado;
        //this.cadeteAsignado = cadete;
    }*/

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
    public string VerNombreCliente(cliente clienteAux)
    {
        return clienteAux.Nombre;
    }

    public string VerTelefonoCliente(cliente clienteAux)
    {
        return clienteAux.Telefono;
    }

    public string GetObservacion()
    {
        return Observacion;
    }
    
}