using Constructum.Server.Entities;

namespace Constructum.Server.Organisations.Entities;

public interface IOrganisation : IEntity<Guid>
{
    public string Name { get; set; }
}