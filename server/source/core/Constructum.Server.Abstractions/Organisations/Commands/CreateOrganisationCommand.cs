using System.Text.Json.Serialization;
using Constructum.Server.Entities;
using Constructum.Server.Organisations.Entities;
using FluentResults;
using Mediator;

namespace Constructum.Server.Organisations.Commands;

[method: JsonConstructor]
public class CreateOrganisationCommand(string name) : ICommand<Result<IOrganisation>>
{
    public string Name => name;
}