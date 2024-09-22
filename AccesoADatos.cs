namespace AccesoADatos;
using System.Text.Json;
using System.Text.Json.Serialization;
using Cadeteria;
using Cadete;


public interface accesoADatos
{
    List<string> LeerArchivo(string nombreArchivo);
    cadeteria CrearCadeteria();
    List<cadete> CrearCadetes();
}


//Clase para archivos CSV.
public class AccesoCsv : accesoADatos
{
    public cadeteria CrearCadeteria()
    {
        var datosCsv = LeerArchivo("datos_cadeteria.csv");
        var datos = datosCsv[0].Split(",");

        if (datos.Count() < 2) throw new Exception("No hay datos suficientes para instanciar la cadeteria");

        return new cadeteria(datos[0], datos[1]);
    }

    public List<cadete> CrearCadetes()
    {
        var datosCsv = LeerArchivo("datos_cadetes.csv");
        var cadetes = new List<cadete>();

        foreach (var linea in datosCsv)
        {
            var datos = linea.Split(",");

            if (datos.Count() < 4)
            {
                System.Console.WriteLine($"\n[!] No se pudo cargar el cadete: {linea} - {datos}");
                continue;
            }
            if (!int.TryParse(datos[0], out int id))
                continue;

            cadetes.Add(new cadete(id, datos[1], datos[2], datos[3]));
        }

        return cadetes;
    }

    public List<string> LeerArchivo(string nombreArchivo)
    {
        var lineas = new List<string>();

        using (FileStream archivoCsv = new FileStream(nombreArchivo, FileMode.Open))
        {
            using (StreamReader readerCsv = new StreamReader(archivoCsv))
            {
                // salto la cabecera
                readerCsv.ReadLine();

                while (readerCsv.Peek() != -1)
                {
                    var linea = readerCsv.ReadLine();
                    if (!string.IsNullOrWhiteSpace(linea)) lineas.Add(linea);
                }
            }
        }

        return lineas;
    }
}


//Clase para archivos Json.
public class AccesoJson : accesoADatos
{
    public cadeteria CrearCadeteria()
    {
        var datosCadeteriaJson = LeerArchivo("datos_cadeteria.json").FirstOrDefault(); 
        
        if (string.IsNullOrWhiteSpace(datosCadeteriaJson))
            throw new Exception("No se pudieron leer los datos de la cadeteria del json");

        var cadeteria = JsonSerializer.Deserialize<cadeteria>(datosCadeteriaJson);

        if (cadeteria == null)
            throw new Exception("Ha ocurrido un error deserealizando los datos de la cadeteria");

        return cadeteria;
    }

    public List<cadete> CrearCadetes()
    {
        var datosCadetesJson = LeerArchivo("datos_cadetes.json").FirstOrDefault();
        
        if (string.IsNullOrWhiteSpace(datosCadetesJson))
            return new List<cadete>();

        var cadetes = JsonSerializer.Deserialize<List<cadete>>(datosCadetesJson);

        if (cadetes == null)
            return new List<cadete>();

        return cadetes;
    }

    public List<string> LeerArchivo(string nombreArchivo)
    {
        if (!File.Exists(nombreArchivo))
            throw new Exception($"El archivo {nombreArchivo} no existe");

        return new List<string>() { File.ReadAllText(nombreArchivo) };
    }
}