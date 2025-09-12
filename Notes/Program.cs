// Notas de un curso

List<int> notes = new();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("-----------Bienvenido al sistema de gestión de notas-----------");
Console.ResetColor();
while (true)
{
    bool flag = false;
    Console.WriteLine(@"Seleccione la opción deseada:
1. Ingresar notas.
2. Ver notas
3. Finalizar");
    string option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Console.WriteLine("¿Cuantás notas desea ingresar?");
            Console.Write("-->");
            int amount = int.Parse(Console.ReadLine());
            Console.WriteLine("A continuación ingrese las notas");
            for (int i = 0; i < amount; i++)
            {
                while (true)
                {
                    Console.Write("-->");
                    string note = Console.ReadLine();
                    if (int.TryParse(note, out int noteNumber) && noteNumber >= 1 && noteNumber <= 5)
                    {
                        notes.Add(noteNumber);
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Debe ingresar un número entre 1 y 5");
                        Console.ResetColor();
                    }
                }
            }
            break;
        case "2":
            if (notes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Aún no hay notas registradas");
                Console.ResetColor();
            }
            else
            {
               Console.WriteLine("Todas las notas:");
               foreach (int note in notes)
               {
                   if (note >= 3)
                   {
                       Console.ForegroundColor = ConsoleColor.Green;
                       Console.WriteLine(note+" Aprovó");
                       Console.ResetColor();
                   }
                   else
                   {
                       Console.ForegroundColor = ConsoleColor.Red;
                       Console.WriteLine(note+" Reprobó");
                       Console.ResetColor();
                   }
               }
               Console.ForegroundColor = ConsoleColor.Green;
               Console.WriteLine("\nEl promedio de las notas es: "+notes.Average());
               Console.ResetColor();
   
               int alert = notes.Find(n => n < 2);
               if (alert != 0)
               {
                   Console.ForegroundColor = ConsoleColor.Yellow;
                   Console.WriteLine("\nHay estudiantes en riesgo académico\n");
                   Console.ResetColor();
               } 
            }
            
            break;
        case "3":
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Que tenga un buen día");
            Console.ResetColor();
            flag = true;
            break;
        default: 
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Debe ingresar una de las opciones");
            Console.ResetColor();
            break;
    }

    if (flag)
    {
        break;
    }
}
