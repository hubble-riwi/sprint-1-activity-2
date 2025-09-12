using System.Linq;

List<Competitor> competitors = new List<Competitor>();          

bool flag =  false;
string Option;
string competitor;

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
    
    Option = Console.ReadLine();
    
    switch (Option)
    {
        case "1":
            Console.Write("Enter name of the competitor: ");
            competitor = Console.ReadLine();
            
            Competitors.Add(competitor);
            Console.WriteLine("Competitors have been saved.");
            break;
        
        case "2":
            Console.Write("Enter name of the competitor: ");
            competitor = Console.ReadLine();

            if (Competitors.Contains(competitor))
            {
                
            }
            break;
    }
}

class Competitor
{
    public string Name { get; set;  }


    public Competitor(string Name)
    {
        this.Name = Name;
    }

    public void DeleteCompetitor(int id)
    {
        
    }
}