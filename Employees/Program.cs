// Gestión de empleados
List<Employee> employees = new();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("----------- Bienvenido al sistema de gestión de empleados -----------");
Console.ResetColor();

while (true)
{
    ShowMenu();
    string input = Console.ReadLine();
    bool exitFlag = false;

    switch (input)
    {
        case "1":
            AddEmployee();
            break;
        case "2":
            ShowEmployees();
            break;
        case "3":
            CountMinors();
            break;
        case "4":
            FindOldestEmployee();
            break;
        case "5":
            ModifyEmployee();
            break;
        case "6":
            RemoveEmployee();
            break;
        case "7":
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


void ShowMenu()
{
    Console.WriteLine(@"
===== Menú de Empleados =====
1. Agregar Empleado
2. Mostrar Empleados
3. Contar Menores de Edad
4. Encontrar Empleado de Mayor Edad
5. Modificar Empleado
6. Eliminar Empleado
7. Salir
=============================
Elija una opción:");
    Console.Write("--> ");
}

void AddEmployee()
{
    Console.WriteLine("Ingrese el nombre del empleado:");
    Console.Write("--> ");
    string name = Console.ReadLine()?.Trim();

    if (string.IsNullOrWhiteSpace(name))
    {
        Warning("El nombre no puede estar vacío.");
        return;
    }

    Console.WriteLine("Ingrese la edad del empleado:");
    Console.Write("--> ");
    if (!int.TryParse(Console.ReadLine(), out int age) || age < 0)
    {
        Warning("Debe ingresar una edad válida.");
        return;
    }

    Console.WriteLine("Ingrese el correo electrónico del empleado:");
    Console.Write("--> ");
    string email = Console.ReadLine()?.Trim();

    if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
    {
        Warning("Debe ingresar un correo electrónico válido.");
        return;
    }

    employees.Add(new Employee(name, age, email));
    Success("Empleado agregado con éxito.");
}

void ShowEmployees()
{
    Console.WriteLine("\n===== Lista de Empleados =====");

    if (employees.Count == 0)
    {
        Warning("No hay empleados registrados.");
        return;
    }

    foreach (var emp in employees)
    {
        Console.WriteLine($"- Nombre: {emp.Name}, Edad: {emp.Age}, Correo: {emp.Email}");
    }
}

void CountMinors()
{
    int minors = employees.FindAll(e => e.Age < 18).Count;
    Console.WriteLine($"Cantidad de empleados menores de edad: {minors}");
}

void FindOldestEmployee()
{
    if (employees.Count == 0)
    {
        Warning("No hay empleados registrados.");
        return;
    }

    Employee oldest = employees[0];
    foreach (var e in employees)
    {
        if (e.Age > oldest.Age)
            oldest = e;
    }

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"El empleado de mayor edad es: {oldest.Name}, Edad: {oldest.Age}");
    Console.ResetColor();
}

void ModifyEmployee()
{
    Console.WriteLine("Ingrese el nombre del empleado a modificar:");
    Console.Write("--> ");
    string name = Console.ReadLine()?.Trim();

    if (string.IsNullOrWhiteSpace(name))
    {
        Warning("Debe ingresar un nombre válido.");
        return;
    }

    Employee employee = employees.Find(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    if (employee != null)
    {
        Console.WriteLine($"Empleado encontrado: {employee.Name}, Edad actual: {employee.Age}, Correo actual: {employee.Email}");

        Console.WriteLine("Ingrese nueva edad:");
        Console.Write("--> ");
        if (!int.TryParse(Console.ReadLine(), out int newAge) || newAge < 0)
        {
            Warning("Edad inválida.");
            return;
        }

        Console.WriteLine("Ingrese nuevo correo electrónico:");
        Console.Write("--> ");
        string newEmail = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(newEmail) || !newEmail.Contains("@"))
        {
            Warning("Correo inválido.");
            return;
        }

        employee.Age = newAge;
        employee.Email = newEmail;

        Success("Empleado modificado correctamente.");
    }
    else
    {
        Error("Empleado no encontrado.");
    }
}

void RemoveEmployee()
{
    Console.WriteLine("Ingrese el nombre del empleado a eliminar:");
    Console.Write("--> ");
    string name = Console.ReadLine()?.Trim();

    if (string.IsNullOrWhiteSpace(name))
    {
        Warning("Debe ingresar un nombre válido.");
        return;
    }

    Employee employee = employees.Find(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    if (employee != null)
    {
        employees.Remove(employee);
        Success("Empleado eliminado del sistema.");
    }
    else
    {
        Error("Empleado no encontrado.");
    }
}

// Métodos auxiliares para mostrar mensajes con color
void Warning(string message)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(message);
    Console.ResetColor();
}

void Error(string message)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(message);
    Console.ResetColor();
}

void Success(string message)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(message);
    Console.ResetColor();
}


class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }

    public Employee(string name, int age, string email)
    {
        Name = name;
        Age = age;
        Email = email;
    }
}