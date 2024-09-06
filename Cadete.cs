namespace Cadete;
using Pedidos;
using System.Linq;

public class cadete
{
    private const float pagoPorPedidoEntregado = 500;
    public int ID;
    public string Nombre;
    public string Direccion;
    public string Telefono;
    public List<pedidos> ListadoPedidos;

    //Metodo constructor.
    public cadete(int id, string nom, string dir, string tel)
    {
        this.ID = id;
        this.Nombre = nom;
        this.Direccion = dir;
        this.Telefono = tel;
        this.ListadoPedidos = new List<pedidos>();
    }

    public float JornalACobrar()
    {
        return 500 * ListadoPedidos.Where(p => p.estado == Estado.COMPLETADO).Count();
    }
}

