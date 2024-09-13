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
    public int cantPedidos;

    //Metodo constructor.
    public cadete(int id, string nom, string dir, string tel)
    {
        this.ID = id;
        this.Nombre = nom;
        this.Direccion = dir;
        this.Telefono = tel;
        this.cantPedidos = 0;
    }
}