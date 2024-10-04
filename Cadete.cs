namespace Cadete;
using Pedidos;
using System.Linq;
using System.Text.Json.Serialization;


public class cadete
{
    private const float pagoPorPedidoEntregado = 500;
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private int cantPedidos;

    //Metodo constructor.
    public cadete()
    {
        id = 0;
        nombre = string.Empty;
        direccion = string.Empty;
        telefono = string.Empty;
        cantPedidos = 0;
    }

    public cadete(int id, string nom, string dir, string tel)
    {
        this.id = id;
        this.nombre = nom;
        this.direccion = dir;
        this.telefono = tel;
        this.cantPedidos = 0;
    }

    [JsonPropertyName("id")]
    public int Id { get => id; set => id = value; }
    [JsonPropertyName("nombre")]
    public string Nombre { get => nombre; set => nombre = value; }
    [JsonPropertyName("direccion")]
    public string Direccion { get => direccion; set => direccion = value; }
    [JsonPropertyName("telefono")]
    public string Telefono { get => telefono; set => telefono = value; }
    public int CantPedidos { get => cantPedidos; set => cantPedidos = value; }

    public override string ToString()
    {
        return Id + " - " + Nombre + " - " + Direccion + " - " + Telefono;
    }
}