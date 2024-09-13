namespace Cadeteria;
using Cadete;
using Pedidos;

public class cadeteria
{
    public string Nombre;
    public string Telefono;
    private List<cadete> listadoCadetes;
    public List<pedidos> listadoPedidos;

    //Metodo constructor.
    public cadeteria(string nom, string tel)
    {
        this.Nombre = nom;
        this.Telefono = tel;
    }

    //Metodo para calcular el jornal.
    public float JornalACobrar(int idCadete)
    {
        cadete? cadeteAux = listadoCadetes.FirstOrDefault(p => p.ID == idCadete);
        int cantPedidos = cadeteAux.cantPedidos;
        return 500 * cantPedidos/*.Where(p => p.estado == Estado.COMPLETADO).Count()*/;
    }

    //Metodo para la asignacion del cadete.
    public void AsignarCadeteAPedido(int idCadete, int idPedido)
    {
        pedidos? pedidoAux = listadoPedidos.FirstOrDefault(p => p.NumeroPedido == idPedido);
        cadete? cadeteAux = listadoCadetes.FirstOrDefault(p => p.ID == idCadete);

        pedidoAux.AgregarCadeteAlPedido(pedidoAux, cadeteAux);
    }
}

