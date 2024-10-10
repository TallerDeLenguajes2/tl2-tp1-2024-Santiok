namespace Cadeteria;

using System.Text.Json.Serialization;

using Cadete;
using Pedidos;

public class cadeteria
{
    [JsonPropertyName("nombre")]
    private string nombre;
    [JsonPropertyName("telefono")]
    private string telefono;
    private List<cadete> listadoCadetes;
    private List<pedidos> listadoPedidos;

    public List<pedidos> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }
    public List<cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }

    //Metodo constructor.
    public cadeteria()
    {
        Nombre = string.Empty;
        Telefono = string.Empty;
        listadoPedidos = new List<pedidos>();
        listadoCadetes = new List<cadete>();
    }
    public cadeteria(string nom, string tel)
    {
        this.Nombre = nom;
        this.Telefono = tel;
        listadoPedidos = new List<pedidos>();
        listadoCadetes = new List<cadete>();
    }

    //Metodo para calcular el jornal.
    public float JornalACobrar(int idCadete)
    {
        cadete? cadeteAux = listadoCadetes.FirstOrDefault(p => p.Id == idCadete);
        int cantPedidos = cadeteAux.CantPedidos;
        return 500 * cantPedidos;
    }

    //Metodo para la asignacion del cadete.
    public void AsignarCadeteAPedido(int idCadete, int idPedido)
    {
        pedidos pedidoAux = listadoPedidos.FirstOrDefault(p => p.NumeroPedido == idPedido);
        cadete cadeteAux = listadoCadetes.FirstOrDefault(p => p.Id == idCadete);

        pedidoAux.AgregarCadeteAlPedido(pedidoAux, cadeteAux);
    }
}

