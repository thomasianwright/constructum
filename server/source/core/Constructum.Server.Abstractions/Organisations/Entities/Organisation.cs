using Constructum.Server.Entities;

namespace Constructum.Server.Organisations.Entities;

public class Organisation : Entity<Guid>, IOrganisation
{
    public string Name { get; set; }

    public Organisation()
    {
        
    }
    
    public Organisation(string name)
    {
        Name = name;
    }
}