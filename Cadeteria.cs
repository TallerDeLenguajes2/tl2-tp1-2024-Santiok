namespace Cadeteria;
using Cadete;
using Pedidos;

public class cadeteria
{
    public string Nombre;
    public string Telefono;
    private List<cadete> listadoCadetes;
    private List<pedidos> listadoPedidos;

    public List<pedidos> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

    public List<cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

    //Metodo constructor.
    public cadeteria(string nom, string tel)
    {
        this.Nombre = nom;
        this.Telefono = tel;
        listadoPedidos = new List<pedidos>();
    }

    //Metodo para calcular el jornal.
    public float JornalACobrar(int idCadete)
    {
        cadete? cadeteAux = listadoCadetes.FirstOrDefault(p => p.ID == idCadete);
        int cantPedidos = cadeteAux.cantPedidos;
        return 500 * cantPedidos/*.Where(p => p.estado == Estado.COMPLETADO).Count()*/;
    }

    public void cargarCadetes(List<cadete> cadetes)
    {
        listadoCadetes = cadetes;
    }

    //Metodo para la asignacion del cadete.
    public void AsignarCadeteAPedido(int idCadete, int idPedido)
    {
        pedidos pedidoAux = listadoPedidos.FirstOrDefault(p => p.NumeroPedido == idPedido);
        cadete cadeteAux = listadoCadetes.FirstOrDefault(p => p.ID == idCadete);

        pedidoAux.AgregarCadeteAlPedido(pedidoAux, cadeteAux);
    }
}

