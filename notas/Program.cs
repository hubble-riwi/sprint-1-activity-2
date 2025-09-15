
List<int> qualifications = new();
bool end_programm = true;
while (end_programm == true)
{
    
Console.WriteLine("\n Bienvenido, que desea hacer? \n 1. ingresar una nota \n 2. Mostrar todas las notas \n 3. Decir cuantas notas se abrobaron \n 4. Calcular el promedio del grupo");
int option = int.Parse(Console.ReadLine());

if (option == 1)
{
    bool add_qualification = true;
    while (add_qualification == true)
    {
        bool requirement_note = true;
        while (requirement_note == true)
        {
            Console.WriteLine("Ingrese una nota: ");
            int new_qualification = int.Parse(Console.ReadLine());
            if (new_qualification > 5)
            {
                Console.WriteLine("la nota debe ser menor a 5, intentelo de nuevvo");
            }
            else
            {
                qualifications.Add(new_qualification);
                requirement_note = false;
            }
        }
        
        Console.WriteLine("Desea ingresar otra nota? ");
        string cuestion_add_qualification = Console.ReadLine();
        if (cuestion_add_qualification == "no")
        {
            add_qualification = false;
        }
    }
}

if (option == 2)
{
    bool risk_note = false;
    foreach (var qualification in qualifications)
    {
        Console.Write(qualification);
        Console.Write(", ");
        if (qualification < 2)
        {
            risk_note = true;
        }
    }

    if (risk_note == true)
    {
        Console.WriteLine("\nHay estudiantes en riesgo academico");
    }
}

if (option == 3)
{
    List<int> win_qualifications = new();
    foreach (var select_qualifications_win in qualifications)
    {
        if (select_qualifications_win >= 3)
        {
            win_qualifications.Add(select_qualifications_win);
        }
    }

    foreach (var good_qualification in win_qualifications)
    {
        Console.Write(good_qualification);
        Console.Write(", ");
    }
    

}

if (option == 4)
{
    int num = 0;
    foreach (var average_num in qualifications)
    {
         num += average_num ;
    }
    int amount_qualifications = qualifications.Count;
    double average_qualifications = num / amount_qualifications;
    Console.WriteLine($"El promedio de todas las notas es {average_qualifications}");
   
    
    
}

}




