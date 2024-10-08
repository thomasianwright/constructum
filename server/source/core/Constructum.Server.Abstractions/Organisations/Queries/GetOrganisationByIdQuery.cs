using System.Text.Json.Serialization;
using Constructum.Server.Entities;
using Constructum.Server.Organisations.Dtos;
using FluentResults;
using Mediator;

namespace Constructum.Server.Organisations.Queries;

[method: JsonConstructor]
public class GetOrganisationByIdQuery(Guid id) : IQuery<Result<OrganisationDto>>
{
    public Guid Id => id;
}