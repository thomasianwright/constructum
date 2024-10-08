using System.Text.Json.Serialization;
using Constructum.Server.Organisations.Dtos;
using Mediator;

namespace Constructum.Server.Organisations.Queries;

[method: JsonConstructor]
public class GetOrganisationsQuery(string? search) : IQuery<IEnumerable<OrganisationDto>>
{
    public string? Search => search;
}