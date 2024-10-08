using System.Text.Json.Serialization;

namespace Constructum.Server.Organisations.Queries;

[method: JsonConstructor]
public class GetOrganisationByNameQuery(string name)
{
    public string Name => name;
}