namespace Cliente;

public class cliente
{
    public string Nombre;
    public string Direccion;
    public string Telefono;
    public List<string> DatosReferencia;

    private string []Nombres = {"Santiago","Martin","Alfredo","Mario","Sebastian","Marcela","Paola","Susana"};
    private string []Direcciones = {"Crisostomo 325","San Lorenzo 489","Monteagudo 569","San Juan 698","Simon Bolivar 789","Lavalle 985","Mendoza 110","San Martin 362"};
    private string []Telefonos = {"3814529658","3815269847","3814789625","3814259879","3814789256","3814269587","381479521","3814526985"};
     private string []DatosRef = {"Casa Celeste","Casa Grande","Porton Negro","Puerta Blanca","Puerta Pequeña","Arbol en la Entrada","Ventana Marron","Ventana Grande"};
    

    //Constructor vacío que inicializa DatosReferencia.
    public cliente()
    {
        //Inicializa la lista al crear una instancia de cliente.
        DatosReferencia = new List<string>();  
    }

 
    public static cliente CrearCliente()
    {
        Random random = new Random();
        cliente nuevoCliente = new cliente();
        nuevoCliente.Nombre = nuevoCliente.Nombres[random.Next(0, nuevoCliente.Nombres.Length)];
        nuevoCliente.Direccion = nuevoCliente.Direcciones[random.Next(0, nuevoCliente.Direcciones.Length)];
        nuevoCliente.Telefono = nuevoCliente.Telefonos[random.Next(0, nuevoCliente.Telefonos.Length)];

        nuevoCliente.DatosReferencia.Add(nuevoCliente.DatosRef[random.Next(0, nuevoCliente.DatosRef.Length)]);

        return nuevoCliente;
    }
}
