using System;
using System.Collections.Generic;
using System.IO;

// Estructura de datos para representar una tarea
struct Tarea
{
    public int TareaID;
    public string Descripcion;
    public int Duracion;
}

class Program
{
    static void GuardarSumatoria(int sumatoria)
{
    string rutaDirectorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    string nombreArchivo = "sumatoriaDuracion.txt";
    string rutaCompleta = Path.Combine(rutaDirectorio, nombreArchivo);

    string mensaje = "La suma total de las duraciones es: " + sumatoria;
    File.WriteAllText(rutaCompleta, mensaje);
    Console.WriteLine("La sumatoria se ha guardado en el archivo correctamente.");
}
    //   static void GuardarSumatoria(int sumatoria)
    // {
    //     string rutaDirectorio = @"C:\Users\CLARIBEL\Documents\Repositorios\trabajo88\tl1_tp8_2023-Clari002";
    //     string archivoCreado = @"\sumatoriaDuracion.txt";
    //     if (!File.Exists(archivoCreado))
    //     {
    //         string rutaCompleta = Path.Combine(rutaDirectorio, archivoCreado);
    //         File.WriteAllText(rutaCompleta, "La suma total de las duraciones es: " + sumatoria);
    //     }
    // }
    // Generar N tareas pendientes aleatoriamente
    static List<Tarea> GenerarTareasPendientes(int N)
    {
        List<Tarea> tareas = new List<Tarea>();
        Random random = new Random();
        int sumatoriaDuracion = 0;
        for (int i = 1; i <= N; i++)
        {
            Tarea tarea;
            tarea.TareaID = i;

            // Generar una descripción aleatoria
            int length = random.Next(1, 11); // Longitud de la descripción entre 1 y 10 caracteres
            tarea.Descripcion = "";
            for (int j = 0; j < length; j++)
            {
                tarea.Descripcion += (char)('A' + random.Next(26)); // Carácter aleatorio entre A-Z
            }
        //    Console.WriteLine("Ingrese Descripcion: ");

            tarea.Duracion = random.Next(10, 101); // Duración entre 10 y 100
            sumatoriaDuracion = sumatoriaDuracion + tarea.Duracion;
            tareas.Add(tarea);//agrego la tarea a la lista
        }
        GuardarSumatoria(sumatoriaDuracion);
        return tareas;//retorno la lista de tareas
    }
    //guardar sumatoria de duracion en un archivo de texto
  

    // Mostrar una tarea en pantalla
    static void MostrarTarea(Tarea tarea)
    {
        Console.WriteLine("ID: " + tarea.TareaID);
        Console.WriteLine("Descripción: " + tarea.Descripcion);
        Console.WriteLine("Duración: " + tarea.Duracion);
        Console.WriteLine();
    }

    // Mover una tarea pendiente a realizada
    static void MoverTarea(List<Tarea> pendientes, List<Tarea> realizadas, int tareaID)
    {
        Tarea tarea = pendientes.Find(t => t.TareaID == tareaID);

        if (tarea.TareaID != 0)
        {
            realizadas.Add(tarea);//agregar a realizada
            pendientes.Remove(tarea);//sacar de pendiente
            Console.WriteLine("La tarea con ID " + tareaID + " se ha movido a realizadas.");
        }
        else
        {
            Console.WriteLine("No se encontró una tarea pendiente con ID " + tareaID + ".");
        }
    }

    // Buscar tareas pendientes por descripción
    static void BuscarTareasPorDescripcion(List<Tarea> pendientes, string descripcion)
    {
        List<Tarea> tareasEncontradas = pendientes.FindAll(t => t.Descripcion.Contains(descripcion));

        if (tareasEncontradas.Count == 0)
        {
            Console.WriteLine("No se encontraron tareas pendientes que coincidan con la descripción.");
        }
        else
        {
            Console.WriteLine("Tareas encontradas:");
            foreach (Tarea tarea in tareasEncontradas)
            {
                MostrarTarea(tarea);
            }
        }
    }

    

    static void Main(string[] args)
    {
        List<Tarea> tareasPendientes = GenerarTareasPendientes(10);
        List<Tarea> tareasRealizadas = new List<Tarea>();

        //Mostrar las tareas pendientes generadas
        Console.WriteLine("--------------------------TAREAS PENDIENTES-------------------");
        foreach (Tarea tarea in tareasPendientes)
        {
            MostrarTarea(tarea);
        }

        // Mover una tarea pendiente a realizada ingresando el id
        Console.WriteLine();
        int valor=0;
        Console.WriteLine("---------------------------------------------------------------------");

        Console.WriteLine("Mover una Tarea de Pendiente a Realizado 1(Si) 0(No) ");
        if (!int.TryParse(Console.ReadLine(), out  valor))
        {
            Console.WriteLine("Valor ingresado no valido");
        }
        while (valor != 0)
        {
             Console.WriteLine("Ingrese el ID: ");
            if (!int.TryParse(Console.ReadLine(), out int tareaIDaMover))
            {
                Console.WriteLine("Valor ingresado no valido");
            }

            MoverTarea(tareasPendientes, tareasRealizadas, tareaIDaMover);
            Console.WriteLine();
        Console.WriteLine("---------------------------------------------------------------------");

            Console.WriteLine("Mover una Tarea de Pendiente a Realizado 1(Si) 0(No) ");
           if (!int.TryParse(Console.ReadLine(), out valor))
            {
            Console.WriteLine("Valor ingresado no valido");
            }   
        }
      
        //Mostrar las tareas Realizadas
        
             Console.WriteLine("--------------------------TAREAS REALIZADAS-------------------");
            foreach (Tarea tarea in tareasRealizadas)
            {
                MostrarTarea(tarea);
            }
        

        //Buscar tareas pendientes por descripcion
        Console.WriteLine("---------------------------------------------------------------------");
        Console.WriteLine("Buscar una tarea por su descripcion en tareas pendientes: Si(1) No(0)");
        var resp = 0;
        if (!int.TryParse(Console.ReadLine(), out resp))
            {
                Console.WriteLine("Valor ingresado no valido");
            }
        while (resp != 0)
        {
            Console.WriteLine("Ingrese la Descripcion: ");
            string DES = Console.ReadLine();
           BuscarTareasPorDescripcion(tareasPendientes,DES);
        
        Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("Buscar una tarea por su descripcion en tareas pendientes: Si(1) No(0)");
            
            if (!int.TryParse(Console.ReadLine(), out resp))
            {
                Console.WriteLine("Valor ingresado no valido");
            }    
        }
        
    
}
}
