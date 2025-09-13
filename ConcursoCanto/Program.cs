using System.Linq;

Competition CompetitionSigning = new Competition();

bool flag =  true;
string Option;
string Competitor;

while (flag)
{
    Console.Write(@"-- Signing competition --
    1. Save competitor
    2. Update competitor
    3. Delete competitor
    4. Look all competitors
    5. Find competitor
    6. Go out
    >> ");
    Console.Write(" ");
    
    Option = Console.ReadLine();
    //After to do some action the system validate all
    switch (Option)
    {
        case "1":
            Console.Write("Enter name of the competitor: ");
            Competitor = Console.ReadLine();
            CompetitionSigning.AddCompetitor(Competitor);
            
            break;
        
        case "2":
            Console.Write("Enter name of the competitor: ");
            Competitor = Console.ReadLine();


            if (CompetitionSigning.TryFindCompetitor(Competitor, out var CompetitorUpdate))
            {
                Console.Write("Enter a new name for the competitor: ");
                Competitor = Console.ReadLine();
                CompetitionSigning.UpdateCompetitor(CompetitorUpdate, Competitor);
            }
            else
            {
                Console.WriteLine("Competitor not found.");
            }
            break;
        
        case "3":
            Console.Write("Enter name of the competitor to delete: ");
            Competitor = Console.ReadLine();

            if (CompetitionSigning.TryFindCompetitor(Competitor, out var CompetitorDelete ))
            {   
                CompetitionSigning.DeleteCompetitor(CompetitorDelete);
            }
            else
            {
                Console.WriteLine("Competitor not found.");
            }

            break;
        
        case "4":
            CompetitionSigning.PrintCompetitors();

            break;
        
        case "5":
            Console.Write("Enter name of the competitor to find: ");
            Competitor = Console.ReadLine();

            CompetitionSigning.FindCompetitor(Competitor);
            break;
        
        case "6":
            
            flag= false;
            break;
    }
}

class Competitor
{
    public string Name { get; set;  }
    
    //Construct
    public Competitor(string Name)
    {
        this.Name = Name;
    }
}

class Competition
{
    // Here we created a list of competitor types in the class. And we make it private so that it can only be accessed through the class methods.
    private List<Competitor> Competitors { get; set; } = new List<Competitor>();
    
    public void AddCompetitor(string Name)
    {
        Competitors.Add(new Competitor(Name));
        Console.WriteLine($"Competitor {Name} have been saved.");
    }
    
    public void UpdateCompetitor(Competitor com, string NewName)
    {
        com.Name = NewName;
        Console.WriteLine($"Competitor {NewName} have been updated.");
    }

    public void DeleteCompetitor(Competitor competitor)
    {
        Competitors.Remove(competitor);
        Console.WriteLine($"Competitor {competitor.Name} deleted.");
    }

    public void PrintCompetitors()
    {
        Console.WriteLine("All competitors");
        foreach (var competitor in Competitors)
        {
            Console.WriteLine($"- {competitor.Name}");
        }
    }
    
    public bool TryFindCompetitor(string name, out Competitor? competitor)
    {
        competitor = Competitors.FirstOrDefault(com => com.Name == name);
        return competitor != null;
    }

    public void FindCompetitor(string name)
    {
        if (Competitors.Any(com => com.Name == name))
        {
            Console.WriteLine($"Competitor {name} found.");
        }
        else
        {
            Console.WriteLine($"Competitor not found.");
        }
    }
}       