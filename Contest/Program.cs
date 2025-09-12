// Concurso de canto
List<string> contestants = new();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("----------- Bienvenido al sistema de gestión de concursantes -----------");
Console.ResetColor();

while (true)
{
    Console.WriteLine(@"
Seleccione la opción deseada:
1. Registrar concursantes
2. Mostrar todos los concursantes
3. Buscar concursante
4. Salir");
    Console.Write("--> ");
    string option = Console.ReadLine();

    bool exitFlag = false;

    switch (option)
    {
        case "1":
            RegisterContestants();
            break;

        case "2":
            ShowContestants();
            break;

        case "3":
            SearchContestant();
            break;

        case "4":
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("¡Hasta luego!");
            Console.ResetColor();
            exitFlag = true;
            break;

        default:
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Debe ingresar una opción válida.");
            Console.ResetColor();
            break;
    }

    if (exitFlag)
        break;

    Console.WriteLine("\nPresione una tecla para continuar...");
    Console.ReadKey();
    Console.Clear();
}

void RegisterContestants()
{
    Console.WriteLine("¿Cuántos concursantes desea registrar?");
    Console.Write("--> ");
    string input = Console.ReadLine();

    if (int.TryParse(input, out int amount) && amount > 0)
    {
        for (int i = 0; i < amount; i++)
        {
            Console.Write($"Ingrese el nombre del concursante #{i + 1}: ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                contestants.Add(name.Trim());
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("El nombre no puede estar vacío. Intente de nuevo.");
                Console.ResetColor();
                i--; // repetir esta iteración
            }
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{amount} concursantes registrados correctamente.");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Debe ingresar un número válido mayor que cero.");
        Console.ResetColor();
    }
}

void ShowContestants()
{
    if (contestants.Count == 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("No hay concursantes registrados.");
        Console.ResetColor();
    }
    else
    {
        Console.WriteLine("Concursantes registrados:");
        foreach (var c in contestants)
        {
            Console.WriteLine($"- {c}");
        }
    }
}

void SearchContestant()
{
    Console.WriteLine("Ingrese el nombre del concursante a buscar:");
    Console.Write("--> ");
    string search = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(search))
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Debe ingresar un nombre válido.");
        Console.ResetColor();
        return;
    }

    string found = contestants.Find(c => c.Equals(search.Trim(), StringComparison.OrdinalIgnoreCase));

    if (found != null)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Concursante encontrado: {found}");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Concursante no encontrado.");
        Console.ResetColor();
    }
}
