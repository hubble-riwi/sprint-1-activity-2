List<Employees> employees = new();
bool returnPrincipalMenu = true;
while (returnPrincipalMenu)
{
        

Console.WriteLine("Bienvenido al sistema de empleados, que desea hacer? \n1. registrar empleados \n2. listar empleados y contar cuantos menores de edad hay y cual es el empleado de mayor edad \n3. CRUD empleados ");
int menuOption = int.Parse(Console.ReadLine());

switch (menuOption)
{
        case 1:
                bool createOtherEmployees = true;
                while (createOtherEmployees)
                {  
                Console.WriteLine("Ingrese el nombre del empleado: ");
                string name = Console.ReadLine();
                Console.WriteLine("Ingrese la edad del empleado: ");
                int edad = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el correo del empleado: ");
                string email = Console.ReadLine();
                employees.Add(new Employees(name, edad, email));
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("El empleado se ha guardado correctamente.");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("Desea crear otro empleado? (si/no)");
                string createNewEmployees = Console.ReadLine();
                if (createNewEmployees == "no")
                {
                        createOtherEmployees = false;
                }
                }
                break;
        case 2:
                foreach (var e in employees)
                {
                        Console.WriteLine("--------------------------------------------------");
                        Console.WriteLine(
                                $"Nombre: {e.nameEmployeed} \nEdad: {e.ageEmployeed} \nCorreo: {e.emailEmployeed}");
                        Console.WriteLine("--------------------------------------------------");
                        int olderAge = e.ageEmployeed;

                }
                int countMinors = employees.Count(e => e.ageEmployeed < 18);
                var employeesolder = employees.MaxBy(a => a.ageEmployeed);
                Console.WriteLine($"El empleado de mayor edad es: {employeesolder.nameEmployeed} Edad: {employeesolder.ageEmployeed} años");
                Console.WriteLine($"hay {countMinors} menores de edad");
                break;
        case 3:
                Console.WriteLine("QUE DESEA HACER? \n          1.editar un empleado\n          2. eliminar un empleado ");
                int optionCrud = int.Parse(Console.ReadLine());
                switch (optionCrud)
                {
                        case 1: 
                                
                                Console.WriteLine("Ingrese el nombre del empleado que desea editar: ");
                                string nameEditEmployees = Console.ReadLine();
                                Console.WriteLine("Que desea editar del empleado \n                      1.nombre\n                      2.edad\n                         3.correo");
                                int editEmployees = int.Parse(Console.ReadLine());
                                int indxEmployes = employees.FindIndex(e => e.nameEmployeed == nameEditEmployees );
                                switch (editEmployees)
                                {
                                        case 1:
                                                
                                                Console.WriteLine($"Ingrese el nombre actualizado de : {nameEditEmployees}");
                                                string nameUpdated = Console.ReadLine();
                                                employees[indxEmployes].nameEmployeed = nameUpdated;
                                                Console.WriteLine($"El empleado se ha actualizado correctamente.");
                                                break;
                                        case 2:
                                                Console.WriteLine($"Ingrese la edad actualizada de : {nameEditEmployees}");
                                                int ageUpdated = int.Parse(Console.ReadLine());
                                                employees[indxEmployes].ageEmployeed = ageUpdated;
                                                Console.WriteLine($"El empleado se ha actualizado correctamente.");
                                                break;
                                        case 3:
                                                Console.WriteLine($"Ingrese el correo actualizado de : {nameEditEmployees}");
                                                string emailUpdated = Console.ReadLine();
                                                employees[indxEmployes].emailEmployeed = emailUpdated;
                                                Console.WriteLine($"El empleado se ha actualizado correctamente.");
                                                break;
                                }
                                {
                                        
                                }
                                break;
                        case 2:
                                Console.WriteLine("Ingrese el nombre del empleado que desea eliminar: ");
                                string nameEmployeesDelete = Console.ReadLine();
                                int indxEmployesDelete = employees.FindIndex(e => e.nameEmployeed == nameEmployeesDelete );
                                Console.WriteLine($"Seguro que quiere eliminar al siguiente empleado: {nameEmployeesDelete}   (si/no) ");
                                string sureDelete = Console.ReadLine();
                                if (sureDelete == "si")
                                {
                                        employees.RemoveAt(indxEmployesDelete);
                                        Console.WriteLine($"El empleado se ha eliminado correctamente.");
                                }
                                else
                                {
                                        
                                }
                                
                                break;
                }
                break;
}
}



class Employees 

{
        public string nameEmployeed { get; set; }
        public int ageEmployeed { get; set; }
        public string emailEmployeed { get; set; }

        public Employees(string name, int age, string email)
        {
                this.nameEmployeed = name;
                this.ageEmployeed = age;
                this.emailEmployeed = email;
        }

}
