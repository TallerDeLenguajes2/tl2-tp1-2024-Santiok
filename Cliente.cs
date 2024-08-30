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
    
    //Metodo constructor para cliente.
    void CrearCliente()
    {
        Random random = new Random();
        this.Nombre = Nombres[random.Next(0,Nombres.Length)];
        this.Direccion = Direcciones[random.Next(0,Direcciones.Length)];
        this.Telefono = Telefonos[random.Next(0,Telefonos.Length)];

        for (int i = 0; i < 1; i++)
        {
            string aux = DatosRef[random.Next(0,DatosRef.Length)];
            this.DatosReferencia.Add(aux);
        }  
    }
  
 

}