List<Employee> employees = new();

var program = true;
while (program)
{
    Console.Write("\n Menu de opciones para el concurso de canto: " +
                  "\n 1) Guardar empleado " +
                  "\n 2) Mostrar empleado " +
                  "\n 3) Menores de edad " +
                  "\n 4) Numero de empleados " +
                  "\n 5) Editar empleado " +
                  "\n 6) Eliminar empleado " +
                  "\n 7) Salir del programa " +
                  "\n Escoge una opción " +
                  "\n >>>");
    string option = Console.ReadLine()!;
    if (string.IsNullOrWhiteSpace(option) || !"1234567".Contains(option))
    {
        Console.WriteLine("Por favor ingresa una opción válida (1-7).");
        continue;
    }

    switch (option)
    {
        case "1":
            while (true)
            {
                Console.Write("\n Dime el nombre del empleado: ");
                string employeeName = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(employeeName))
                {
                    Console.WriteLine(" Ingresa una entrada valida");
                    continue;
                }
                
                Console.Write("\n Dime la edad del empleado: ");
                string inputAge = Console.ReadLine() ?? "";
                if (!(int.TryParse(inputAge, out int employeeAge)))
                {
                    Console.WriteLine(" Ingresa una entrada valida");
                    continue;
                }
                
                Console.Write("\n Dime el correo electronico del empleado: ");
                string employeeEmail = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(employeeEmail))
                {
                    Console.WriteLine(" Ingresa una entrada valida");
                    continue;
                }
                
                Employee emp = new Employee
                {
                    Name = employeeName,
                    Age = employeeAge,
                    Email = employeeEmail
                };

                employees.Add(emp);
                
                Console.Write("\n Quieres agregar mas participantes (s/n): ");
                string keep = Console.ReadLine()!.ToLower() ?? "";
                if (keep == "n")
                {
                    break;
                }
            }
            break;

        case "2":
            if (employees.Count == 0)
            {
                Console.WriteLine("No hay empleados todavia");
            }
            else
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    var employee = employees[i];
                    Console.WriteLine($" {i}) Nombre: {employee.Name}, Edad: {employee.Age}, Email: {employee.Email}");
                }
            }
            break;

        case "3":
            if (employees.Count == 0)
            {
                Console.WriteLine("No hay empleados todavia");
            }
            else
            {
                Console.WriteLine("\n Mostrando empleados menores de edad...");
                foreach (var employee in employees)
                {
                    if (employee.Age < 18)
                    {
                        Console.WriteLine($" Nombre: {employee.Name}, Edad: {employee.Age}, Email: {employee.Email}");
                    }
                }
            }
            break;

        case "4":
            Console.WriteLine($"\n El total de empleados en la empresa es de {employees.Count}");
            break;

        case "5":
            if (employees.Count == 0)
            {
                Console.WriteLine(" No hay empleados todavia");
            }
            else
            {
                Console.WriteLine("\n Lista de empleados:");
                for (int i = 0; i < employees.Count; i++)
                {
                    var emp = employees[i];
                    Console.WriteLine($" {i}) Nombre: {emp.Name}, Edad: {emp.Age}, Email: {emp.Email}");
                }
                Console.Write("\nIngresa el número del empleado que deseas editar: ");
                string inputIndex = Console.ReadLine() ?? "";
                if (!int.TryParse(inputIndex, out int index) || index < 0 || index >= employees.Count)
                {
                    Console.WriteLine("Índice inválido.");
                    break;
                }
                
                Employee selectedEmployee = employees[index];
                
                Console.WriteLine($" ¿Que dato quieres editar?: \n 1) Nombre \n 2) Edad \n 3) Email");
                var inputEdit = Console.ReadLine() ?? "";
                if (!int.TryParse(inputEdit, out int data) || data < 1 || data > 3)
                {
                    Console.WriteLine("Opción inválida.");
                    break;
                }

                switch (data.ToString())
                {
                    case "1":
                        Console.Write($"\nNuevo nombre (anterior: {selectedEmployee.Name}): ");
                        string newName = Console.ReadLine()!;
                        if (!string.IsNullOrWhiteSpace(newName))
                        {
                            selectedEmployee.Name = newName;
                        }
                        break;

                    case "2":
                        Console.Write($"\nNueva edad (anterior: {selectedEmployee.Age}): ");
                        string newAgeInput = Console.ReadLine() ?? "";
                        if (int.TryParse(newAgeInput, out int newAge))
                        {
                            selectedEmployee.Age = newAge;
                        }
                        break;

                    case "3":
                        Console.Write($"\nNuevo email (anterior: {selectedEmployee.Email}): ");
                        string newEmail = Console.ReadLine()!;
                        if (!string.IsNullOrWhiteSpace(newEmail))
                        {
                            selectedEmployee.Email = newEmail;
                        }
                        break;
                }
            }
            break;

        case "6":
            if (employees.Count == 0)
            {
                Console.WriteLine(" No hay empleados todavia");
            }
            else
            {
                Console.WriteLine("\n Lista de empleados:");
                for (int i = 0; i < employees.Count; i++)
                {
                    var emp = employees[i];
                    Console.WriteLine($" {i}) Nombre: {emp.Name}, Edad: {emp.Age}, Email: {emp.Email}");
                }
                Console.Write("\nIngresa el número del empleado que deseas eliminar: ");
                string inputIndex = Console.ReadLine() ?? "";
                if (!int.TryParse(inputIndex, out int deleteIndex) || deleteIndex < 0 || deleteIndex >= employees.Count)
                {
                    Console.WriteLine("Índice inválido.");
                    break;
                }

                employees.RemoveAt(deleteIndex);
                Console.WriteLine("Empleado eliminado correctamente.");
            }
            break;

        case "7":
            Console.WriteLine("Adiositooo");
            program = false;
            break;
    }
}

class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
}
