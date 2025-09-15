List<string> participants = new();
var program = true;
while (program)
{
    Console.Write("\n Menu de opciones para el concurso de canto: " +
                  "\n 1) Guardar participante " +
                  "\n 2) Mostrar participantes " +
                  "\n 3) Buscar participante " +
                  "\n 4) Numero de participante " +
                  "\n 5) Eliminar participante " +
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
            while (true)
            {
                Console.Write("\n Dime el nombre del participante que quieras agregar: ");
                string singer = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(singer))
                {
                    Console.WriteLine(" Ingresa una entrada valida");
                    continue;
                }
                else
                {
                    participants.Add(singer);
                    
                }
                Console.Write("\n Quieres agregar mas participantes (s/n): ");
                string keep = Console.ReadLine()!.ToLower() ?? "";
                if (keep == "n")
                {
                    break;
                }

            }
            break;
        case "2":
            Console.WriteLine(" Mostrando todos los participantes...");
            if (participants.Count == 0)
            {
                Console.WriteLine(" No hay participantes todavia");
            }
            else
            {
                foreach (var participant in participants)
                {
                    Console.WriteLine(" -" + participant);
                } 
            }
            break;
        case "3":
            if (participants.Count == 0)
            {
                Console.WriteLine(" \nNo hay participantes todavia \n");
            }
            else
            {
                while (true){
                    Console.Write("\n Dime el nombre del participante que quieres buscar: ");
                    string searchParticipant = Console.ReadLine() ?? "";
                    bool exists = participants.Contains(searchParticipant);
                    if (exists)
                    {
                        Console.WriteLine($" El participante {searchParticipant} si existe");
                    }
                    else
                    {
                        Console.WriteLine($" El participante {searchParticipant} no existe todavia");
                    }
                    Console.Write("\n Quieres buscar mas participantes (s/n): ");
                    string keep = Console.ReadLine()!.ToLower() ?? "";
                    if (keep == "n")
                    {
                        break;
                    }
                } 
            }
            
            
            break;
        case "4":
            if (participants.Count == 0)
            {
                Console.Write($"\n No hay participantes todavia \n");
            }
            else
            { 
                Console.Write($"\n El numero de participantes inscritos hasta el momento es {participants.Count} \n");
            }
            
            break;
        case "5":
            if (participants.Count == 0)
            {
                Console.Write($"\n No hay participantes todavia \n");
            }
            else
            {
                Console.Write("\n Dime el nombre del participante que quieres eliminar: ");
                string deleteParticipant = Console.ReadLine() ?? "";
                bool exist = participants.Remove(deleteParticipant);
                if (exist)
                {
                    Console.WriteLine($" Estas seguro de que quieres eliminar a {deleteParticipant} (s/n): ");
                    string delete = Console.ReadLine()!.ToLower() ?? "";
                    if (delete == "s")
                    {
                        participants.Remove(deleteParticipant);
                        Console.WriteLine($" El participante {deleteParticipant} fue eliminado exitosamente");
                    
                    }else if (delete == "n")
                    {
                        Console.WriteLine("ahhh eso pense");
                    }
                }
                else
                {
                    Console.WriteLine($" El participante {deleteParticipant} no existe");
                }
            }
            break;
        case "6":
            Console.WriteLine("Adiositooo");
            program = false;
            break;
    }
}