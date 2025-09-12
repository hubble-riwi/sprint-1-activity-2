using System.Linq;

    List<Double> notes = new List<Double> { };

    bool flag = true;

    while (flag)
    {
        
        Console.WriteLine("Notificaciones");
        if (notes.Any(x => x < 2))
        {
            Console.WriteLine("Hay estudiantes en riesgo");
        }
        else
        {
            Console.WriteLine("No hay estudiantes en riesgo");
        }
        
        Console.Write(@"
        Sistema de guardado de notas
        1. Guardar notas
        2. Ver todas las notas
        3. Cuales notas aprobaron
        4. Promedio del grupo
        5. Salir
        >> ");

        string option = Console.ReadLine();
        
        switch (option)
        {
            case "1": 
                double NewNote;
                
                Console.Write("Ingrese la nueva nota(separe la parte decimal de la parte entero con una coma): ");
                if (double.TryParse(Console.ReadLine(), out NewNote))
                {   
                    if (NewNote < 1 ||  NewNote > 5.1)
                    {
                        Console.WriteLine("Debe de ingresar una nota de un rango de 1 a 5");
                    }
                    else
                    {
                        notes.Add(NewNote);
                    }
                }
                break;
            
            case "2":
                if (notes.Count == 0)
                {
                    Console.WriteLine("No hay notas en el sistema");
                }
                else
                {
                    Console.WriteLine("Todas las notas");
                    foreach (var note in notes) 
                    {
                        Console.WriteLine($"-  {note}");
                    }
                }
                break;
            
            case "3":
                if (notes.Any(x => x > 3))
                {
                    Console.WriteLine("Notas aprobadas");   
                    foreach (var note in notes)
                    {
                        if (note >= 3)
                        {
                            Console.WriteLine($"- {note}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No hay notas en el sistema");
                }
        
                break;
            
            case "4":
                if (notes.Count == 0)
                {
                    Console.WriteLine("No hay notas en el sistema");
                }
                else
                {
                    Console.WriteLine($"El promedio de notas del grupo es de {(notes.Sum() / notes.Count).ToString("F1")}");
                }
                break;
        
            case "5":
                flag = false;
                break;
                
            default:
                Console.WriteLine("Ingrese una opcion valida");
                break;
        }
    } 

