List<string> contestants = new();
bool menu = true;
while (menu)
{


    Console.WriteLine(
        "\nBienvenido, que desea hacer? \n 1. Registrar concursantes \n 2. Mostrar todos los concursantes \n 3. Buscar un concursante en específico \n 4. Contar cuantos concursantes se han inscrito\n 5. Eliminar concursante \n 6. actualizar concursante");
    int option = int.Parse(Console.ReadLine());

    if (option == 1)
    {
        bool register_more_contestants = true;
        while (register_more_contestants == true)
        {
            Console.WriteLine("Ingrese el nombre del concursante: ");
            string name_contestants = Console.ReadLine();
            contestants.Add(name_contestants);
            Console.WriteLine("Desea agregar otro concursante? ");
            string add_other_contestant = Console.ReadLine();
            if (add_other_contestant == "no")
            {
                register_more_contestants = false;
            }
        }
    }
    else if (option == 2)
    {
        foreach (var contestant in contestants)
        {
            Console.Write(contestant);
            Console.Write(", ");
        }

    }
    
    else if (option == 3)
    {
        Console.WriteLine("Ingrese el nombre del concursante que desea buscar: ");
        string search_contestant = Console.ReadLine();
        string search_name_list= contestants.Find(name => name == search_contestant);
        
        if (search_name_list != null){
        Console.WriteLine("-----------------------------");
        Console.WriteLine(search_name_list + " Está participando");
        Console.WriteLine("-----------------------------");
        }
        if (search_name_list == null)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("El concursante no existe");
            Console.WriteLine("-----------------------------");

        }
    }
    
    else if (option == 4)
    {
        int count_participants = contestants.Count;
        Console.WriteLine("-----------------------------");
        Console.WriteLine($"Existen {count_participants} concursantes");
        Console.WriteLine("-----------------------------");
        
    }
    else if (option == 5)
    {
        Console.WriteLine("Ingrese el nombre del concursante que desea eliminar: ");
        string delete_contestant= Console.ReadLine();
        contestants.Remove(delete_contestant);
    }
    
    else if (option == 6)
    {
        
        Console.WriteLine("Ingrese el nombre del concursante que desea actualizar: ");
        string edit_contestant = Console.ReadLine();
        Console.WriteLine("Ingrese el usuario actualizado: ");
        string update_contestant = Console.ReadLine();
        int index = contestants.IndexOf(edit_contestant);
        contestants[index] = update_contestant;
    }
    
    
}
