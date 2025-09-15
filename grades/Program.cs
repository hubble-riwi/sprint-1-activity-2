using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> grades = new();
        var program = true;
        while (program)
        {
            Console.Write("\n Hola profesor mira tu menu de opciones: " +
                          "\n 1) Guardar notas " +
                          "\n 2) Mostrar todas las notas " +
                          "\n 3) Notas aprobadas " +
                          "\n 4) Promedio de grupo " +
                          "\n 5) Mostrar estudiantes con riesgo academico " +
                          "\n 6) Salir del programa " +
                          "\n Escoge una opción " +
                          "\n >>>");
            string option = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(option) || !"123456".Contains(option))
            {
                Console.WriteLine("Por favor ingresa una opción válida (1-6).");
                continue;
            }

            switch (option)
            {
                case "1":
                    var notesCont = 1;
                    Console.Write("\n Bueno profe, ¿cuantas notas quieres agregar?: ");
                    int gradesQuantity = Int32.Parse(Console.ReadLine()!);
        
                    while (gradesQuantity > 0)
                    {
                        Console.Write($" Profe ingresa la nota #{notesCont}: ");
                        while (gradesQuantity > 0)
                        {
                            Console.Write($" Profe ingresa la nota #{notesCont}: ");
                            string input = Console.ReadLine()!;
                            if (int.TryParse(input, out int grade) && grade >= 0 && grade <= 5)
                            {
                                grades.Add(grade); 
                                notesCont++;
                                gradesQuantity--;
                            }
                            else
                            {
                                Console.WriteLine("Nota inválida. Ingresa una nota entre 0 y 5.");
                            }
                        }
                    }
                
                    Console.WriteLine("\n Listo profe, tus notas fueron agregadas correctamente. ");
                    
                    break;
                case "2":
                    Console.WriteLine(" Mostrando todas las notas...");
                    if (grades.Count == 0)
                    {
                        Console.WriteLine("No hay notas todavia");
                    }
                    else
                    {
                        foreach (var grade in grades)
                        {
                            Console.WriteLine(" -" + grade);
                        } 
                    }
                    break;
                
                case "3":
                    Console.WriteLine(" Mostrando todas las notas aprobadas...");
                    if (grades.Count == 0)
                    {
                        Console.WriteLine("No hay notas todavia");
                    }
                    else
                    {
                        foreach (var grade in grades)
                        {
                            if (grade >= 3)
                            {
                                Console.WriteLine(" -" + grade);
                            }
                        } 
                    }    
                    break;
                case "4":
                    Console.WriteLine(" Mostrando el promedio del grupo...");
                    if (grades.Count == 0)
                    {
                        Console.WriteLine(" No hay notas todavia");
                    }
                    else
                    {
                        double averageGroup = grades.Average();
                        Console.WriteLine(" El promedio del grupo es: " + averageGroup);
                    }    
                    break;
                case "5":
                    Console.WriteLine(" Mostrando todas las notas en riesgo academico...");
                    if (grades.Count == 0)
                    {
                        Console.WriteLine("No hay notas todavia");
                    }
                    else
                    {
                        foreach (var grade in grades)
                        {
                            if (grade < 2)
                            {
                                Console.WriteLine(" -" + grade);
                            }
                        } 
                        Console.WriteLine(" Muchooooo ojito con esas notas");
                    } 
                    break;
                case "6":
                    Console.WriteLine("ADIOSITOOOOOO");
                    program = false;
                    break;
                default:
                    Console.WriteLine(" OE BRO ESA NO ES UNA OPCION");
                    break;
            }
        }
    }

        
}






